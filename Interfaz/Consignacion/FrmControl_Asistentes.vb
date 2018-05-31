Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports System.IO

Public Class FrmControl_Asistentes
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

  Private Sub FrmControl_Asistentes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
    Call Totales_Cero()
  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer ', vHasta As String

    xCod_uni = GestionSeguridadManager.gUnidadId
    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If

    'vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

    DtRes = Control_AsistenteManager.Leer_Asistentes(xCod_uni, xCod_Alm, cboCampania.Value)
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

  Private Sub dgvResumen_AfterColRegionScroll(sender As Object, e As ColScrollRegionEventArgs) Handles dgvResumen.AfterColRegionScroll

  End Sub

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

  Public Sub Mostrar_Detalles()
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
    DtColp = Control_AsistenteManager.Leer_Colportores(xCod_uni, xCod_Alm, cboCampania.Value, _codigo)

    e.Result = DtColp
    'Ctas = 0
  End Sub

  Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted

    dgvListado.DataSource = CType(e.Result, DataTable)
    'Call CalcularTotales_Det()

    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    'gpBotones.Enabled = True
    dgvResumen.Enabled = True

    Me.LblRegistros.Text = dgvListado.Rows.Count & " Registros"

  End Sub

  Public Function CalcularTotales_Det() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vDeuda, vPagos, vSaldo As Single
    Dim vCod_a As Long = 0
    vDeuda = 0
    vPagos = 0
    vSaldo = 0
    CalcularTotales_Det = False

    Try
      DtTot = ListadoDoc 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

      For Each Drs In DtTot.Rows

        'Select Case Trim(Drs("tipo").ToString)
        '    Case "M"
        '        vDeudaMora = CSng(Drs("monto").ToString)
        '    Case "V"
        '        vDeudaVenc = CSng(Drs("monto").ToString)
        '    Case "T"
        '        vDeudaSM = CSng(Drs("monto").ToString)

        'End Select
        vDeuda = CSng(Drs("deuda").ToString)
        vPagos = CSng(Drs("pagos").ToString)
        vSaldo = CSng(Drs("saldo").ToString)
        'vTotal = CSng(vDeudaSM + vDeudaMora)

      Next Drs
      'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
      Me.lblTotalDeuda.Text = FormatNumber(vDeuda, 2, TriState.False, TriState.False)
      Me.lblTotalPagos.Text = FormatNumber(vPagos, 2, TriState.False, TriState.False)
      Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
      CalcularTotales_Det = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub Totales_Cero()

    Me.lblTotalDeuda.Text = "0.00"
    Me.lblTotalPagos.Text = "0.00"
    Me.lblTotalSaldo.Text = "0.00"
  End Sub

  Private Sub dgvResumen_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvResumen.DoubleClickRow
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

  Private Sub dgvResumen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvResumen.InitializeLayout
    With dgvResumen.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20
      .Columns(1).Header.Caption = "Documento"
      .Columns(1).Width = 80
      .Columns(2).Header.Caption = "Asistente"
      .Columns(2).Width = 220
      .Columns(3).Hidden = True
      .Columns(4).Header.Caption = "N° Cuenta"
      .Columns(4).Width = 120

      .Columns(5).Width = 80
      .Columns(5).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(5).CellAppearance.TextHAlign = HAlign.Right

      .Columns(9).Width = 150
      .Columns(10).Hidden = True
    End With
  End Sub

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
      .Columns(1).Header.Caption = "Documento"
      .Columns(1).Width = 80
      .Columns(2).Header.Caption = "Colportor"
      .Columns(2).Width = 220

      .Columns(3).Width = 80
      .Columns(3).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(3).CellAppearance.TextHAlign = HAlign.Right

      .Columns(4).Width = 100

    End With
  End Sub

  Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  Private Sub cboAlmacen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.ValueChanged
    dgvResumen.DataSource = Nothing
    dgvListado.DataSource = Nothing
    Call Totales_Cero()
  End Sub


  Private Sub tsdAddAsistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdAddAsistente.Click
    FrmActualizar_Asistente.pCodigo_Alm = cboAlmacen.Value
    FrmActualizar_Asistente.pCampaniaId = cboCampania.Value
    FrmActualizar_Asistente.pCampania = cboCampania.Text
    FrmActualizar_Asistente.ShowDialog()
  End Sub

  Private Sub tsAddColportor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAddColportor.Click
    If Not dgvResumen.DataSource Is Nothing Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        With FrmActualizar_Colportor
          .pCodigo = 0
          .pCodigo_Asis = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .pDniAsis = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          .pNroCuenta = dgvResumen.DisplayLayout.ActiveRow.Cells(4).Value
          .pSaldo = dgvResumen.DisplayLayout.ActiveRow.Cells(5).Value
          .pCodigo_Alm = cboAlmacen.Value
          .pCampaniaId = cboCampania.Value
          .pAlmacen = cboAlmacen.Text
          .pCampania = cboCampania.Text
          .ShowDialog()
        End With

      End If
    End If
  End Sub

  Private Sub tsQuitarAsistente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsQuitarAsistente.Click

    If Not dgvResumen.DataSource Is Nothing Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
          If Control_AsistenteManager.Eliminar(cboCampania.Value, cboAlmacen.Value, (dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value), 0) Then
            If Not bwLlenar_Res.IsBusy Then
              bwLlenar_Res.RunWorkerAsync()
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub tsdQuitarColp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdQuitarColp.Click
    If Not dgvListado.DataSource Is Nothing Then
      If dgvListado.Selected.Rows.Count > 0 Then
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
          If Control_AsistenteManager.Eliminar(cboCampania.Value, cboAlmacen.Value, (dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value), (dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)) Then
            If Not bwLlenar_Res.IsBusy Then
              bwLlenar_Res.RunWorkerAsync()
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub tsExcelAsis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcelAsis.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvResumen, utExcel, "Asistente.xls")
  End Sub

  Private Sub tsExcelColp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcelColp.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, utExcel, "Asistente.xls")
  End Sub

  Private Sub tsAsActualizar_Click(sender As Object, e As EventArgs) Handles tsAsActualizar.Click
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

  Private Sub tsEditColp_Click(sender As Object, e As EventArgs) Handles tsEditColp.Click
    If Not dgvListado.DataSource Is Nothing Then
      If dgvListado.Selected.Rows.Count > 0 Then
        With FrmActualizar_Colportor
          .pCodigo_Asis = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .pDniAsis = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          .pNroCuenta = dgvResumen.DisplayLayout.ActiveRow.Cells(4).Value

          .pCodigo_Alm = cboAlmacen.Value
          .pAlmacen = cboAlmacen.Text

          .pCodigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value


          .pCodigo_Colp = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
          .pDNIColp = dgvListado.DisplayLayout.ActiveRow.Cells("nrodocumento").Value
          .pColportor = dgvListado.DisplayLayout.ActiveRow.Cells("persona").Value
          .pCCOSTO = dgvListado.DisplayLayout.ActiveRow.Cells("observacion").Value
          .pSaldo = dgvListado.DisplayLayout.ActiveRow.Cells("importe").Value
          .ShowDialog()
        End With
      End If
    End If
  End Sub

  Private Sub tsTrasladar_Click(sender As Object, e As EventArgs) Handles tsTrasladar.Click
    If dgvListado.DataSource Is Nothing Then
      MessageBox.Show("Debe seleccionar un colportor")
      Exit Sub
    End If
    If Not dgvListado.Selected.Rows.Count > 0 Then
      MessageBox.Show("Debe seleccionar un colportor")
      Exit Sub
    End If
    If Not dgvResumen.DataSource Is Nothing Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        With FrmTrasladarColp
          .pAsistenteId = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          '.pDniAsis = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          '.pNroCuenta = dgvResumen.DisplayLayout.ActiveRow.Cells(4).Value
          .pSaldo = dgvResumen.DisplayLayout.ActiveRow.Cells(5).Value
          .pAlmacenId = cboAlmacen.Value
          .pAlmacen = cboAlmacen.Text


          .pColoportoId = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
          .pDniColp = dgvListado.DisplayLayout.ActiveRow.Cells("nrodocumento").Value
          .pColportor = dgvListado.DisplayLayout.ActiveRow.Cells("persona").Value
          .pTipo = dgvListado.DisplayLayout.ActiveRow.Cells("observacion").Value
          .pSaldo = dgvListado.DisplayLayout.ActiveRow.Cells("importe").Value
          .ShowDialog()
        End With
      End If
    End If

  End Sub

  Private Sub tsEditarAsis_Click(sender As Object, e As EventArgs) Handles tsEditarAsis.Click

  End Sub

  Private Sub btnTrasladoCamp_Click(sender As Object, e As EventArgs) Handles btnTrasladoCamp.Click

    frmTrasladoCampaniaColp.ShowDialog()
  End Sub
End Class