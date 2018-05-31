Imports System
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMovimiento_Bancario
  Private Sub llenar_combos()
    Try
      With cboAlmacen
        .DataSource = Nothing
        .DataSource = GestionTablas.dtFAlmacen
        .DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If

      End With

      With cboDocumento
        .DataSource = Nothing
        .DataSource = GestionTablas.dtperdoc
        .Refresh()
        .ValueMember = "documentoid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With

      With Me.cboFormaPago
        .DataSource = Nothing
        .DataSource = movimiento_bancarioManager.tipo_forma_pago_leer("")
        .DataBind()
        .ValueMember = "tipofpid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Function Listado_Condicion_series(ByVal xcod_Doc As Integer) As Boolean
    Dim objetos As New DataTable
    Try

      If xcod_Doc > 0 Then
        objetos = serieManager.GetList(1, xcod_Doc)
        cboSerie.DataSource = objetos
        cboSerie.Refresh()
        cboSerie.ValueMember = "serieid"
        cboSerie.DisplayMember = "serie"

        If cboSerie.Rows.Count() > 0 Then

        End If
      Else
        cboSerie.DataSource = Nothing
      End If

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Almacén"
      .Columns(1).Width = cboAlmacen.Width
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
    End With
  End Sub

  Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
    If cboAlmacen.ActiveRow Is Nothing Then
      If Not cboAlmacen.Text = "" Then
        cboAlmacen.Focus()
      End If
    End If

  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0
    Dim vDoc As Integer = 0, vSerie As String = ""


    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    If Not cboDocumento.Text = "" Then
      vDoc = cboDocumento.Value
    End If
    If Not cboSerie.Text = "" Then
      vSerie = cboSerie.Text
    End If
    'vOpcion = cboDocumento.Value
    vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
    vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

    DtRes = movimiento_bancarioManager.pamovimiento_bancario_leer_ing(1, vDoc, vDesde, vHasta, "I", 0, 0, xCod_Alm, 0, vSerie)

    e.Result = DtRes

  End Sub

  Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vTotal As Single = 0
    Dim vCod_a As Long = 0

    CalcularTotales_Res = False
    'If Not Trim(TxtDNI_RUC.Text) = "" Then
    '    vCod_a = CInt(TxtDNI_RUC.Text)
    'End If
    Try
      DtTot = DtTotales 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

      For Each Drs In DtTot.Rows

        'Select Case Trim(Drs("tipo").ToString)
        '    Case "M"
        '        vDeudaMora = CSng(Drs("monto").ToString)
        '    Case "V"
        '        vDeudaVenc = CSng(Drs("monto").ToString)
        '    Case "T"
        '        vDeudaSM = CSng(Drs("monto").ToString)

        'End Select
        vTotal = vTotal + CSng(Drs("ingreso").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      Me.lblTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
      'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
      'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
      'Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
      CalcularTotales_Res = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

    dgvListado.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Res(CType(e.Result, DataTable))
    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    utGrids.Enabled = True
    'dgvListado.Refresh()
    Me.LblRegistros.Text = dgvListado.Rows.Count & " Registros"

  End Sub

  Private Sub FrmMovimiento_Bancario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    cboDesde.Value = ("01/" & Now.Month & "/" & Now.Year)
    cboHasta.Value = Now.Date
    LibreriasFormularios.formatear_grid(dgvListado)
    LibreriasFormularios.formatear_grid(dgvPorFormaPago)
    'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
  End Sub

  Public Sub Actualizar()
    picAjaxBig.Visible = True
    gpCriterios.Enabled = False
    utGrids.Enabled = False
    dgvListado.DataSource = Nothing
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActualizar.Click
    Call Actualizar()
  End Sub

  Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("tipo").Hidden = True
      .Columns("codigo_doc").Hidden = True
      .Columns("codigo_tip").Hidden = True
      .Columns("codigo_per").Hidden = True
      .Columns("moneda").Hidden = True
      .Columns("estado").Hidden = True
      .Columns("cerrado").Hidden = True
      .Columns("referencia").Hidden = True
      .Columns("codigo_ref1").Hidden = True
      .Columns("codigo_ref2").Hidden = True
    End With

  End Sub

  Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
    If e.Row.Cells("estado").Value = False Then
      e.Row.Cells("numero").Appearance.Image = Global.Phoenix.My.Resources.Resources.img_anulado
      'Else
      '    e.Row.Cells("numero").Appearance.Image = Global.SoftComNet.My.Resources.Resources.edit_add
    End If
  End Sub

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.A Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          Dim iMbId As Long = 0, vTipo As String = ""
          iMbId = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
          vTipo = ((dgvListado.DisplayLayout.ActiveRow.Cells("tipo_movimiento_bancario").Value))
          If Not vTipo = "INGRESO POR VENTA" Then
            If MessageBox.Show("¿Está seguro de Anular este documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
              If movimiento_bancarioManager.Cambiar_Estado(iMbId, GestionSeguridadManager.sUsuario, My.Computer.Name) Then
                Call Actualizar()
              End If
            End If
          Else
            MessageBox.Show("Este tipo de registro no puede anular en este módulo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End If
      End If
    ElseIf e.KeyCode = Keys.F2 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          Dim iMbId As Long = 0, vTipo As String = "", vCta As String = ""
          iMbId = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
          vTipo = ((dgvListado.DisplayLayout.ActiveRow.Cells("tipo_movimiento_bancario").Value))
          If Not vTipo = "INGRESO POR VENTA" Then
            If MessageBox.Show("¿Está seguro de Cambiar el número de cuenta de este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
              vCta = Insertar_Cta()
              If vCta.Trim.Length = 7 Then
                If movimiento_bancarioManager.Actualizar_NroCta(iMbId, vCta) Then
                  Call Actualizar()
                End If
              End If
            End If
          Else
            MessageBox.Show("Este tipo de registro no puede anular en este módulo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End If
      End If

    End If
  End Sub

  Private Function Insertar_Cta() As String
    Dim message, title, defaultValue As String
    Dim myValue As Object

    message = "Ingresar Nro Cuenta"

    title = "Cambiar Nro Cuenta"
    defaultValue = "1131001"

    myValue = InputBox(message, title, defaultValue)

    If myValue Is "" Then myValue = defaultValue
    If Not IsNumeric(myValue) Then myValue = defaultValue

    Insertar_Cta = myValue

  End Function

  Private Sub tsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcel.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "MB.xls")
  End Sub

  Private Sub tsdAnticipo_Click(sender As Object, e As EventArgs) Handles tsdAnticipo.Click
    If Not cboAlmacen.Text = "" Then
      FrmMovimiento_BancarioNM.pCodigo_Alm = cboAlmacen.Value
      FrmMovimiento_BancarioNM.pTipo = "ANTICIPO"
      FrmMovimiento_BancarioNM.Show()
    End If

  End Sub

  Private Sub tsmOtrosIng_Click(sender As Object, e As EventArgs) Handles tsmOtrosIng.Click
    If Not cboAlmacen.Text = "" Then
      FrmMovimiento_BancarioNM.pCodigo_Alm = cboAlmacen.Value
      FrmMovimiento_BancarioNM.pTipo = "INGRESO"
      FrmMovimiento_BancarioNM.Show()
    End If
  End Sub

  Private Sub tsDuplicado_Click(sender As Object, e As EventArgs) Handles tsDuplicado.Click

    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim _codigo As Long, _Codigo_Doc As Integer

        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        _Codigo_Doc = Integer.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_doc").Value))

        If _codigo > 0 Then
          Dim xLegal As Boolean = False, xCaja As String = My.Computer.Name
          If _Codigo_Doc = 11 Then
            xLegal = True
            xCaja = "XCOBRARNC"
          ElseIf _Codigo_Doc = 5 Then
            xLegal = False
          Else
            xLegal = True
          End If

          Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(_codigo), cboAlmacen.Value, _Codigo_Doc, xCaja, xLegal, True)
        End If
      End If
    End If


  End Sub

  Private Sub cboDocumento_ValueChanged(sender As Object, e As EventArgs) Handles cboDocumento.ValueChanged
    cboSerie.DataSource = Nothing
    If Not cboDocumento.Text = "" Then
      If Not cboDocumento Is Nothing Then
        Call Listado_Condicion_series(cboDocumento.Value)
      End If
    End If

  End Sub

  Private Sub cboDocumento_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboDocumento.Width
      .Columns(2).Hidden = True
    End With
  End Sub

  Private Sub cboSerie_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboSerie.InitializeLayout
    With cboSerie.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Hidden = True
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      .Columns("serie").Width = cboSerie.Width
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True

    End With
  End Sub

  Private Sub bwFP_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwFP.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0
    Dim vDoc As Integer = 0, vTFP As Integer = 0


    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    If Not cboDocumento.Text = "" Then
      vDoc = cboDocumento.Value
    End If

    If Not cboFormaPago.Text = "" Then
      vTFP = cboFormaPago.Value
    End If
    'vOpcion = cboDocumento.Value
    vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
    vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

    DtRes = movimiento_bancarioManager.Movimiento_BancarioTFP(xCod_uni, xCod_Alm, vTFP, vDesde, vHasta)

    e.Result = DtRes

  End Sub

  Private Sub bwFP_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwFP.RunWorkerCompleted

    dgvPorFormaPago.DataSource = CType(e.Result, DataTable)
    picFP.Visible = False
    gpCriterios.Enabled = True
    utGrids.Enabled = True

    Me.lblRegistrosFP.Text = dgvPorFormaPago.Rows.Count & " Registros"

  End Sub

  Private Sub tsExcelFP_Click(sender As Object, e As EventArgs) Handles tsExcelFP.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvPorFormaPago, ugExcelExporter, "MBFP.xls")
  End Sub

  Public Sub ActualizarFP()
    picFP.Visible = True
    gpCriterios.Enabled = False
    utGrids.Enabled = False
    dgvPorFormaPago.DataSource = Nothing
    If Not bwLlenar_Res.IsBusy Then
      bwFP.RunWorkerAsync()
    End If
  End Sub

  Private Sub tsMostrarFP_Click(sender As Object, e As EventArgs) Handles tsMostrarFP.Click
    Call ActualizarFP()
  End Sub

  Private Sub UltraCombo1_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboFormaPago.InitializeLayout
    With cboFormaPago.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboFormaPago.Width
    End With
  End Sub

  Private Sub cboFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cboFormaPago.KeyDown
    If e.KeyCode = Keys.Delete Then
      cboFormaPago.Text = ""
    End If
  End Sub

  Private Sub dgvPorFormaPago_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvPorFormaPago.InitializeLayout

  End Sub

  Private Sub dgvPorFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvPorFormaPago.KeyDown
    If e.KeyCode = Keys.A Then
      If dgvPorFormaPago.Rows.Count > 0 Then
        If dgvPorFormaPago.Selected.Rows.Count > 0 Then
          Dim iMbId As Long = 0, vTipo As String = ""
          iMbId = Long.Parse((dgvPorFormaPago.DisplayLayout.ActiveRow.Cells(0).Value))
          'vTipo = ((dgvPorFormaPago.DisplayLayout.ActiveRow.Cells("tipo_movimiento_bancario").Value))
          If Not GestionSeguridadManager.idUsuario = 1 Then
            If MessageBox.Show("¿Está seguro de Anular este documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
              If movimiento_bancarioManager.Cambiar_Estado(iMbId, GestionSeguridadManager.sUsuario, My.Computer.Name) Then
                Call Actualizar()
              End If
            End If
          Else
            MessageBox.Show("No tiene Permiso para anular documentos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          End If
        End If
      End If
    End If
  End Sub
End Class