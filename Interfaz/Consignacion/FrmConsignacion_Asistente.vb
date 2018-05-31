Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmConsignacion_Asistente

  Public _codigo As Long
  Public ListadoDoc As DataTable


  Private Sub llenar_combos()
    Try
      With Me.cboAlmacen
        .DataSource = GestionTablas.dtFAlmacen
        '.DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If

      End With
      With cboCampania
        .DataSource = campaniaManager.Campania_leer("")
        .ValueMember = "campaniaid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          'If pCodigo > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
          '  cboTipo.Value = pCCOSTO
          'End If
        End If
      End With
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Almacén"
      .Columns(1).Width = cboAlmacen.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
    If cboAlmacen.ActiveRow Is Nothing Then
      If Not cboAlmacen.Text = "" Then
        cboAlmacen.Focus()
      End If
    End If
  End Sub


  Private Sub FrmConsignacion_Asistente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
    Call Totales_Cero()
    cboDesde.Value = "01/01/" & Now.Date.Year
    cboHasta.Value = Now.Date
  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer ', vHasta As String


    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If

    'vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

    DtRes = consignacionManager.Leer_Consignacion_Res(xCod_uni, xCod_Alm, cboCampania.Value, 0, 0, "", "", "", 0)
    e.Result = DtRes

  End Sub

  Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

    dgvResumen.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Res(CType(e.Result, DataTable))
    picAjaxRes.Visible = False
    gpCriterios.Enabled = True
    'gpBotones.Enabled = True
    'dgvListado.Refresh()
    Me.lblRegistros_Res.Text = dgvResumen.Rows.Count & " Registros"

  End Sub

  Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vDeudaVenc, vDeudaMora, vDeudaSM, vTotal As Single
    Dim vCod_a As Long = 0
    vDeudaVenc = 0
    vDeudaMora = 0
    vDeudaSM = 0
    CalcularTotales_Res = False

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
        vTotal = vTotal + CSng(Drs("importe").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
      'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
      'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
      Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
      CalcularTotales_Res = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub dgvResumen_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvResumen.BeforeSelectChange
    _codigo = 0
    Call Totales_Cero()
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then

        _codigo = CInt((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))
        Call Mostrar_Detalles()

      Else
        _codigo = 0
        dgvListado.DataSource = Nothing
      End If
    End If
  End Sub

  Private Sub Mostrar_Detalles()
    picAjaxBig.Visible = True
    dgvListado.DataSource = Nothing
    gpCriterios.Enabled = False
    'gpBotones.Enabled = False
    dgvResumen.Enabled = False
    Call Totales_Cero()
    If Not bwLlenar_Detalle.IsBusy Then
      bwLlenar_Detalle.RunWorkerAsync()
    End If
  End Sub

  Private Sub bwLlenar_Detalle_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Detalle.DoWork
    Dim DtColp As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String


    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

    ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
    ' create and bind sample DataSet
    DtColp = consignacionManager.Leer_Consignacion(xCod_uni, xCod_Alm, cboCampania.Value, _codigo, 0, "", "", "", 0)

    e.Result = DtColp
    'Ctas = 0
  End Sub

  Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted

    dgvListado.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Det(CType(e.Result, DataTable))

    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    'gpBotones.Enabled = True
    dgvResumen.Enabled = True

    Me.LblRegistros.Text = dgvListado.Rows.Count & " Registros"

  End Sub

  Public Function CalcularTotales_Det(ByVal DtTot As DataTable) As Boolean
    'Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vDeuda, vPagos, vSaldo As Single
    Dim vCod_a As Long = 0
    vDeuda = 0
    vPagos = 0
    vSaldo = 0
    CalcularTotales_Det = False

    Try
      'DtTot = ListadoDoc 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

      For Each Drs In DtTot.Rows

        'Select Case Trim(Drs("tipo").ToString)
        '    Case "M"
        '        vDeudaMora = CSng(Drs("monto").ToString)
        '    Case "V"
        '        vDeudaVenc = CSng(Drs("monto").ToString)
        '    Case "T"
        '        vDeudaSM = CSng(Drs("monto").ToString)

        'End Select
        vDeuda = vDeuda + CSng(Drs("total").ToString)
        'vPagos = CSng(Drs("pagos").ToString)
        'vSaldo = CSng(Drs("saldo").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
      Me.lblTotalGuias.Text = FormatNumber(vDeuda, 2, TriState.False, TriState.False)
      CalcularTotales_Det = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub Totales_Cero()

    Me.lblTotalGuias.Text = "0.00"

  End Sub

  Private Sub dgvResumen_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvResumen.DoubleClickRow
    _codigo = 0
    Call Totales_Cero()
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then

        _codigo = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))
        Call Mostrar_Detalles()

      Else
        _codigo = 0
        dgvListado.DataSource = Nothing
      End If
    End If
  End Sub

  Private Sub dgvResumen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvResumen.InitializeLayout
    With dgvResumen.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20
      .Columns(1).Header.Caption = "Asistente"
      .Columns(1).Width = 220

      .Columns(2).Width = 80
      .Columns(2).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(2).CellAppearance.TextHAlign = HAlign.Right

      .Columns(3).Width = 80
      '.Columns(3).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(3).CellAppearance.TextHAlign = HAlign.Right

      .Columns(4).Width = 80
      '.Columns(4).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(4).CellAppearance.TextHAlign = HAlign.Right

      '.Columns(8).Width = 150
      '.Columns(9).Hidden = True
    End With
  End Sub

  ''Private Sub dgvListado_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgvListado.AfterSelectChange
  ''    ' Dim lsel As UltraGridRow
  ''    Dim SaldoSel As Single
  ''    SaldoSel = 0

  ''    'With dgvListado.Selected
  ''    '    If .Rows.Count > 0 Then

  ''    '        For Each lsel In .Rows
  ''    '            If lsel.Band.Index = 0 Then
  ''    '                If lsel.Cells("total").Value > 0 Then 'And Not (lsel.Cells("orden").Value = 2) Then

  ''    '                    SaldoSel += lsel.Cells("total").Value
  ''    '                Else
  ''    '                    'If (lsel.Cells("orden").Value = 2) Then
  ''    '                    lsel.Selected = False
  ''    '                    'End If

  ''    '                End If
  ''    '            End If

  ''    '        Next

  ''    '    End If
  ''    'End With
  ''    'Me.LblAPagar.Text = FormatNumber(SaldoSel, 2, TriState.True, , TriState.False)
  ''End Sub

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.Enter Then
      Dim vEmitir As Integer = 0
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          'Buscar.ShowDialog()
          'vEmitir = Validar()
          'If vEmitir = 0 Then
          '    MessageBox.Show("Está Intentando Cancelar conceptos que corresponden a dos tipos de Documentos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          '    Exit Sub
          'End If

          ''Dim FrmDtP As New FrmActualizar_Operaciones
          ''With FrmDtP
          ''    .txtAlumno.Tag = Me.TxtCodigo_per.Text
          ''    .txtAlumno.Text = Me.LblNombre.Text
          ''    .txtFecha.Value = Date.Now.Date

          ''    .lblUnidad_Negocio.Tag = cboUnidad_Negocio.Value

          ''    .lblUnidad_Negocio.Text = cboUnidad_Negocio.Text
          ''    .vCodigo_Pro = vCodigo_Pros
          ''    .TxtAnombreD.Tag = Codigo_Apo 'Cod_Apoderado.ToString
          ''    If .TxtAnombreD.Tag = 0 Then
          ''        .TxtAnombreD.Tag = Me.TxtCodigo_per.Text
          ''    End If
          ''    If vEmitir = 1 Then
          ''        .vDoc_Legal = True
          ''    End If
          ''    .DtG = Actiualizar_Grid_Pagos()

          ''    If .DtG.Rows.Count > 0 Then
          ''        .ShowDialog()
          ''        Exit Sub
          ''    End If
          ''    .Dispose()
          ''End With
        End If
      End If

    End If
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout

    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20
      .Columns(1).Header.Caption = "Fecha"
      .Columns(1).Width = 80
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Width = 130
      .Columns(5).Width = 70
      .Columns(5).Header.Caption = "Dzmo"
      .Columns(5).CellAppearance.TextHAlign = HAlign.Right

      .Columns(6).Width = 90
      .Columns(6).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(6).CellAppearance.TextHAlign = HAlign.Right

      .Columns(7).Width = 40
      .Columns(7).Header.Caption = "%Dzmo"
      .Columns(7).CellAppearance.TextHAlign = HAlign.Right

      .Columns(8).Width = 70
      .Columns(9).Width = 70

      .Columns(10).Hidden = True
      .Columns(11).Hidden = True

    End With
  End Sub

  Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
    picAjaxRes.Visible = True
    gpCriterios.Enabled = False
    'gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    dgvResumen.DataSource = Nothing
    LblDeudaTotal.Text = "0.00"
    Call Totales_Cero()
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub cboAlmacen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.ValueChanged
    dgvResumen.DataSource = Nothing
    dgvListado.DataSource = Nothing
    Call Totales_Cero()
  End Sub

  Private Sub tsActualziar_Detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualziar_Detalle.Click
    If _codigo > 0 Then
      Call Mostrar_Detalles()
    End If
  End Sub

  Private Sub tsActualizar_Res_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar_Res.Click
    picAjaxRes.Visible = True
    gpCriterios.Enabled = False
    'gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    dgvResumen.DataSource = Nothing
    LblDeudaTotal.Text = "0.00"
    Call Totales_Cero()
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub tsAgregar_Consignacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAgregar_Consignacion.Click
    Dim frm As New FrmActualizar_Consignacion
    frm.pTipo = 0
    frm.pCodigo_Alm = cboAlmacen.Value
    frm.pNombre_Almacen = cboAlmacen.Text
    Call LibreriasFormularios.Ver_Form(frm, "Actualizar Consignación")
  End Sub

  Private Sub tsDetalle_Guia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDetalle_Guia.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0
        tCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        dtTemp = reportes_consignacionManager.Detalle_Guia(tCodigo)

        Dim frm As New FrmVisor_Consignacion

        frm.RptDetalle_Guia(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle Documento")
        Call LibreriasFormularios.Ver_Form(frm, "Detalle Doc.")
      End If
    End If
  End Sub

  Private Sub tsmStock_Individual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmStock_Individual.Click
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0, vHasta As String = "", vCond As String = "", vDesde As String = ""
        If chkRango.Checked Then
          vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)
        tCodigo = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))
        vCond = "Hasta : " & cboHasta.Value
        dtTemp = reportes_consignacionManager.rptStock(cboAlmacen.Value, tCodigo, vDesde, vHasta, 0, "", cboCampania.Value)

        Dim frm As New FrmVisor_Consignacion

        frm.RptStock(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Stock Consignación Individual", vCond)
        Call LibreriasFormularios.Ver_Form(frm, "Stock")
      End If
    End If
  End Sub

  Private Sub tsmStock_Consolidado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmStock_Consolidado.Click
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0, vHasta As String = "", vCond As String = "", vDesde As String = ""
        If chkRango.Checked Then
          vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)
        tCodigo = 0 'Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))
        vCond = "Hasta : " & cboHasta.Value
        dtTemp = reportes_consignacionManager.rptStock(cboAlmacen.Value, tCodigo, vDesde, vHasta, 0, "", cboCampania.Value)

        Dim frm As New FrmVisor_Consignacion

        frm.RptStock(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Stock Consignación Consolidado", vCond)
        Call LibreriasFormularios.Ver_Form(frm, "Stock Cons")
      End If
    End If
  End Sub

  Private Sub tsmnAddConsignacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmnAddConsignacion.Click
    Dim frm As New FrmActualizar_Consignacion
    frm.pTipo = 0
    frm.pCodigo_Alm = cboAlmacen.Value
    frm.pCampaniaId = cboCampania.Value
    frm.pCampania = cboCampania.Text
    frm.pNombre_Almacen = cboAlmacen.Text
    Call LibreriasFormularios.Ver_Form(frm, "Actualizar Consignación")
  End Sub

  Private Sub tsmnBoletear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmnBoletear.Click
    Dim Frm As New FrmBoleteo_Colportor
    With Frm
      .pCodigo_Alm = cboAlmacen.Value
      .pAlmacen = cboAlmacen.Text
    End With
    Call LibreriasFormularios.Ver_Form(Frm, "Boleteo Colp.")
  End Sub

  Private Sub tsmnDevolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmnDevolver.Click
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        Dim tCodigo As Long = 0

        tCodigo = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))
        If tCodigo > 0 Then
          Dim frm As New FrmDevolver_Bloque
          frm.pTipo = 0
          frm.pCodigo_Asis = tCodigo
          frm.pCodigo_Per = tCodigo
          frm.pCodigo_Alm = cboAlmacen.Value
          frm.pNombre_Almacen = cboAlmacen.Text
          frm.pCampaniaid = cboCampania.Value
          frm.pCampania = cboCampania.Text
          Call LibreriasFormularios.Ver_Form(frm, "Devolver Consig.")
        End If
      End If
    End If
  End Sub

  Private Sub tsDuplicadoGuia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDuplicadoGuia.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim dtTempC As New DataTable, dtTempD As New DataTable, tCodigo As Long = 0, tCodigo_Doc As Integer = 0
        tCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        tCodigo_Doc = Integer.Parse((dgvListado.ActiveRow.Cells("codigo_doc").Value))

        Dim frm As New FrmVisor_Consignacion

        frm.Imprimir_Guia(tCodigo, cboAlmacen.Value, tCodigo_Doc)
        Call LibreriasFormularios.Ver_Form(frm, "Duplicado")


      End If
    End If
  End Sub
End Class