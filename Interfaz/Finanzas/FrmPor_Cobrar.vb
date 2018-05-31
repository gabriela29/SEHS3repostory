
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop

Public Class FrmPor_Cobrar
  Public _codigo As Long, xCodio_Abo As Long = 0, pCodigo_Asis As Long = 0, pAsistente As String = "", pCodigo_Cli As Long = 0
  Public xCodigo_Doc_Abo As Integer = 0, vDesde As Boolean, dtAnticipo As DataTable
  Dim objApp As Excel.Application
  Dim objBook As Excel._Workbook
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
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

      Dim dtL As DataTable
      Dim x As Integer = 6
      Dim opcionesv(x), opciones(x) As String
      opcionesv(0) = 0
      opcionesv(1) = 1
      opcionesv(2) = 2

      opciones(0) = "Todos"
      opciones(1) = "Asistente"
      opciones(2) = "Iglesia"

      dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

      With cboTipo
        .DataSource = Nothing
        .DataSource = dtL
        .Refresh()
        .ValueMember = "opcionesv"
        .DisplayMember = "opciones"
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With


      'Dim lMeses As New ClsCrearMeses

      'With cboMes
      '    .DataSource = Nothing
      '    .DataSource = lMeses.GetList(False, False)
      '    .Refresh()
      '    .ValueMember = "codigo"
      '    .DisplayMember = "nombre"
      '    If .Rows.Count > 0 Then
      '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      '    End If

      'End With

      'With cboAnio
      '    .DataSource = Nothing
      '    .DataSource = lMeses.GetList_anios()
      '    .Refresh()
      '    .ValueMember = "nombre"
      '    .DisplayMember = "nombre"
      '    If .Rows.Count > 0 Then
      '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      '    End If

      'End With

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
    _codigo = 0
  End Sub

  Private Sub FrmPor_Cobrar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    cboDesde.Text = "01/" & Now.Month & "/" & Now.Year
    If vDesde Then
      cboDesde.Visible = True
    Else
      cboDesde.Visible = False
    End If
    CboFecha2.Text = Now.Date
    Call LibreriasFormularios.formatear_grid_multiSelect(dgvListado)
    Call LibreriasFormularios.formatear_grid(dgvSobrantes)
    Call Totales_Cero()
  End Sub

  Private Sub cboTipo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboTipo.InitializeLayout
    With cboTipo.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = cboTipo.Width
    End With

  End Sub

  Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActualizar.Click
    picAjaxRes.Visible = True
    gpCriterios.Enabled = False
    gpBotones.Enabled = False
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0

    xCod_uni = GestionSeguridadManager.gUnidadId
    If chkTodos.Checked Then
      xCod_Alm = 0
    Else
      If Not Trim(Me.cboAlmacen.Text) = "" Then
        xCod_Alm = CInt(cboAlmacen.Value)
      End If
    End If


    If Not cboTipo.Text = "" Then
      vOpcion = cboTipo.Value
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    If IsNumeric(lblPersonaId.Text) Then
      vPersona = Long.Parse(lblPersonaId.Text)
    End If
    DtRes = por_cobrarManager.Leer_Res(xCod_uni, xCod_Alm, vHasta, vOpcion, vPersona, chkTodos.Checked)

    e.Result = DtRes

  End Sub

  Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

    dgvResumen.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Res(CType(e.Result, DataTable))
    picAjaxRes.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
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
        vTotal = vTotal + CSng(Drs("deuda").ToString)
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

  Private Sub dgvResumen_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles dgvResumen.AfterSelectChange
    _codigo = 0
    Call Totales_Cero()
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then

        _codigo = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))

        If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
          pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
          pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
        End If

        Call Mostrar_Detalles()

      Else
        _codigo = 0
        dgvListado.DataSource = Nothing
      End If
    End If
  End Sub

  Private Sub dgvResumen_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvResumen.BeforeSelectChange
    '_codigo = 0
    'Call Totales_Cero()
    'If dgvResumen.Rows.Count > 0 Then
    '    If dgvResumen.Selected.Rows.Count > 0 Then

    '        _codigo = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value))

    '        If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
    '            pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
    '            pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
    '        End If

    '        Call Mostrar_Detalles()

    '    Else
    '        _codigo = 0
    '        dgvListado.DataSource = Nothing
    '    End If
    'End If
  End Sub

  Public Sub Mostrar_Detalles()
    picAjaxBig.Visible = True
    dgvListado.DataSource = Nothing
    gpCriterios.Enabled = False
    gpBotones.Enabled = False
    dgvResumen.Enabled = False
    Call Totales_Cero()
    If Not bwLlenar_Detalle.IsBusy Then
      bwLlenar_Detalle.RunWorkerAsync()
    End If
  End Sub

  Private Sub bwLlenar_Detalle_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Detalle.DoWork
    Dim DtSumCargos, DtSumAbonos As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String
    dtAnticipo = New DataTable
    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
    ' create and bind sample DataSet
    Call por_cobrarManager.Leer_Detalles(xCod_uni, xCod_Alm, vHasta, 0, _codigo, DtSumCargos, DtSumAbonos, dtAnticipo)
    'DtSumCargos = obligacionManager.Mostrar_Obligaciones(_codigoA, xCod_uni, xCod_Proc, vDesde, vHasta, Ctas)
    DtSumCargos.TableName = "Cabecera"
    'DtSumAbonos = obligacionManager.Mostrar_Abonos(_codigoA, IIf(Ctas < 2, xCod_uni, 0), xCod_Proc, vDesde, vHasta)
    DtSumAbonos.TableName = "Detalle"

    Dim CtrlPagosData As New clsCtrlPagosDataSet()
    ListadoDoc = DtSumCargos
    e.Result = CtrlPagosData.MkCtrlPagosDataSet(DtSumCargos, DtSumAbonos)
    'Ctas = 0
  End Sub

  Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted

    dgvListado.DataSource = CType(e.Result, DataSet)
    dgvSobrantes.DataSource = dtAnticipo
    Call CalcularTotales_Det()

    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
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
    'If Not Trim(TxtDNI_RUC.Text) = "" Then
    '    vCod_a = CInt(TxtDNI_RUC.Text)
    'End If
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
        vDeuda = vDeuda + CSng(Drs("deuda").ToString)
        vPagos = vPagos + CSng(Drs("pagos").ToString)
        vSaldo = vSaldo + CSng(Drs("saldo").ToString)
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
    Dim xPt As String = ""
    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator

    With dgvResumen.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20

      .Columns(1).Header.Caption = "DNI"
      .Columns(1).Width = 90

      .Columns(2).Header.Caption = "Persona"
      .Columns(2).Width = 180

      .Columns(3).Width = 80
      .Columns(3).CellAppearance.TextHAlign = HAlign.Right
      .Columns(3).Header.Caption = "Línea Crédito"

      .Columns(4).Width = 80
      .Columns(4).Header.Caption = "Deuda"
      .Columns(4).CellAppearance.BackColor = Color.LemonChiffon
      .Columns(4).CellAppearance.TextHAlign = HAlign.Right
      .Columns(4).CellAppearance.FontData.Bold = DefaultableBoolean.True
      If xPt = "." Then
        .Columns(4).Format = "#,###.00"
        .Columns(5).Format = "#,###.00"
      Else
        .Columns(4).Format = "#.###,00"
        .Columns(5).Format = "#.###,00"
      End If
      .Columns(5).Width = 80
      .Columns(5).CellAppearance.TextHAlign = HAlign.Right
      .Columns(5).Header.Caption = "Saldo Crédito"
      .Columns(6).Header.Caption = "Asistente"
      .Columns(6).Width = 160

      .Columns(7).Width = 20
    End With
  End Sub

  Private Sub dgvListado_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles dgvListado.AfterSelectChange
    Dim lsel As UltraGridRow
    Dim SaldoSel As Single
    SaldoSel = 0
    xCodio_Abo = 0
    With dgvListado.Selected
      If .Rows.Count > 0 Then

        For Each lsel In .Rows
          If lsel.Band.Index = 0 Then
            If lsel.Cells("saldo").Value > 0 Then 'And Not (lsel.Cells("orden").Value = 2) Then

              SaldoSel += lsel.Cells("saldo").Value
            Else
              'If (lsel.Cells("orden").Value = 2) Then
              lsel.Selected = False
              'End If

            End If
          ElseIf lsel.Band.Index = 1 Then
            If lsel.Selected Then
              xCodio_Abo = lsel.Cells("codigo_mb").Value
              xCodigo_Doc_Abo = lsel.Cells("documentoid").Value
            End If

          End If

        Next

      End If
    End With
    Me.LblAPagar.Text = FormatNumber(SaldoSel, 2, TriState.True, , TriState.False)
  End Sub

  Private Function Validar() As Integer
    Dim lsel As UltraGridRow
    Dim Fact As Boolean = False, Recibo As Boolean = False


    With dgvListado.Selected
      If .Rows.Count > 0 Then
        For Each lsel In .Rows
          If lsel.Band.Index = 0 Then
            If lsel.Cells("codigo_contable").Value > 0 Then
              Recibo = True
            ElseIf (lsel.Cells("codigo_contable").Value = 0) Then
              Fact = True
            End If
          End If
        Next
      End If
    End With
    If Fact = True And Recibo = True Then
      Validar = 0
    End If
    If Fact = True And Recibo = False Then
      Validar = 1
    End If
    If Fact = False And Recibo = True Then
      Validar = 2
    End If
    Return Validar
  End Function

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.Enter Then
      Dim vEmitir As Integer = 0

      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count Then
          If Not _codigo = CInt((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)) Then
            MessageBox.Show("Inconsistencia, vuelva a actualizar y seleccionar la persona, así como sus cuentas a pagar", "AVISO", MessageBoxButtons.OK)
            Exit Sub
          End If
        End If
      End If

      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          'Buscar.ShowDialog()
          vEmitir = Validar()
          If vEmitir = 0 Then
            MessageBox.Show("Está Intentando Cancelar dos tipos de documentos distintos", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
          End If
          Call Abono_PorCobrar()
        End If
      End If

    End If
  End Sub

  Private Sub Abono_PorCobrar()
    Dim FrmDtP As New FrmAbono_PorCobrar
    Dim vDocLegal As Integer = 0
    With FrmDtP
      .txtFecha.Value = Date.Now.Date
      .vIngreso = True
      .pNC = False
      .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
      .pCodigo_Alm = cboAlmacen.Value
      .lblAlmacen.Text = GestionSeguridadManager.gUnidad
      .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
      .txtRucDni.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
      .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
      .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
      .vCodigo_Per1 = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

      .lblNroCuenta.Text = dgvListado.DisplayLayout.ActiveRow.Cells("nrocuenta").Value


      .lblC_Costo.Text = dgvListado.DisplayLayout.ActiveRow.Cells("c_costo").Value
      vDocLegal = Integer.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("codigo_contable").Value)
      If vDocLegal > 0 Then
        .vDoc_Legal = True
      End If

      If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value) Then
        .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value
      Else
        .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value

      End If
      .DtG = Actiualizar_Grid_Pagos()

      If .DtG.Rows.Count > 0 Then
        .ShowDialog()
        Exit Sub
      End If
      .Dispose()
    End With
  End Sub

  Private Sub Abono_PorCobrarII()
    Dim FrmDtP As New FrmAbono_PorCobrarII
    Dim vDocLegal As Integer = 0
    With FrmDtP
      .pNC = False
      .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
      .pCodigo_Alm = cboAlmacen.Value
      .lblAlmacen.Text = GestionSeguridadManager.gUnidad
      .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
      .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
      .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
      .vCodigo_Per1 = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

      .txtNumDocPer.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value

      vDocLegal = Integer.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("codigo_contable").Value)
      .dtTipo_Pago = dtAnticipo
      .DtG = Actiualizar_Grid_Pagos()

      If .DtG.Rows.Count > 0 Then
        .ShowDialog()
        Exit Sub
      End If
      .Dispose()
    End With
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    Dim xPt As String = ""
    xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("codigo").Header.Caption = "ID"
      .Columns("codigo").Width = 10
      .Columns("documento").Width = 80
      .Columns("fecha").Hidden = True
      .Columns("vencimiento").Width = 75
      .Columns("vencimiento").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("deuda").CellAppearance.TextHAlign = HAlign.Right
      .Columns("deuda").Width = 80
      .Columns("pagos").CellAppearance.TextHAlign = HAlign.Right
      .Columns("pagos").Header.Caption = "Pago"
      .Columns("Pagos").Width = 80
      .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("saldo").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("saldo").Width = 80
      .Columns("saldo").CellAppearance.FontData.Bold = DefaultableBoolean.True
      If xPt = "." Then
        .Columns("deuda").Format = "#,###.00"
        .Columns("saldo").Format = "#,###.00"
      Else
        .Columns("deuda").Format = "#.###,00"
        .Columns("saldo").Format = "#.###,00"
      End If
      ''.Columns("vencimiento").Width = 90
      .Columns("caja").Width = 60
      .Columns("usuario").Width = 60
      .Columns("condicion").Hidden = True
    End With
    If dgvListado.DisplayLayout.Bands.Count > 1 Then
      With dgvListado.DisplayLayout.Bands(1)
        .Columns("codigo").Header.Caption = "IDD"
        .Columns("codigo").Width = 20
        '.Columns("fecha").Header.VisiblePosition = 1
        '.Columns("fecha").Width = 80

        '.Columns("documento").Header.VisiblePosition = 2
        '.Columns("documento").Width = 140
        '.Columns("numero").Header.VisiblePosition = 3
        '.Columns("numero").Width = 120
        .Columns("importe").Header.VisiblePosition = 4
        .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
        .Columns("importe").Width = 90

      End With
    End If
  End Sub

  Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
    e.Row.Expanded = False
    e.Row.ExpansionIndicator = ShowExpansionIndicator.CheckOnDisplay

    Try
      If e.Row.Band.Index = 0 Then

        If e.Row.Cells("saldo").Value > 0 And CDate(Format(e.Row.Cells("vencimiento").Value, "short date")) < CDate(Format(Date.Now, "short date")) Then
          e.Row.Cells("observacion").Appearance.Image = Global.Phoenix.My.Resources.Resources.i_aviso
        End If

      End If
    Finally

    End Try
  End Sub

  Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
    Me.Close()
  End Sub

  Private Sub bwExperian_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwExperian.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim DtRpt As New DataTable, xCondi As String, vMsg As String = ""
    Dim vUni As Integer = 0, vDesde As String = "", vHasta As String = "", vUsuario As Integer = 0
    Dim vMes As Integer = 0, xComen As String = "", vProc As Integer = 0
    Dim vEmpresa As String = "", vRucEmp As String = ""
    Dim xNameFile As String = ""
    Try


      vUni = GestionSeguridadManager.gUnidadId


      If IsDate(CboFecha2.Value) Then
        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
      Else
        vMsg = "Fechas No Válidas"
        Exit Sub
      End If

      If cboAlmacen.Value > 0 Then

        DtRpt = por_cobrarManager.Leer_Experian(vUni, cboAlmacen.Value, vHasta, 0, 0)
        xCondi = "Cuentas por Cobrar de : " & cboAlmacen.Text & " Al: " & Me.CboFecha2.Text

      End If

      e.Result = DtRpt

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwExperian_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwExperian.RunWorkerCompleted

    'If sender = bwPrecarga Then
    If e.Result Is Nothing Then
      cboAlmacen.DataSource = Nothing
    Else

      Dim objBooks As Excel.Workbooks
      Dim objSheets As Excel.Sheets
      Dim objSheet As Excel._Worksheet
      'Dim range As Excel.Range

      objApp = New Excel.Application()
      objBooks = objApp.Workbooks
      objBook = objBooks.Add
      objSheets = objBook.Worksheets
      objSheet = objSheets(1)

      Dim Dtp As New DataTable
      Dim DtRw As DataRow
      Dim xfield, V, H As Long
      Dim Centro_Costo As Long = 0
      Dim xPt As String = ""

      Dtp = CType(e.Result, DataTable)

      'xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


      'objCelda = objHojaExcel.Range("D3", Type.Missing)
      'objCelda.Value = "Precio RD$"
      'objCelda.EntireColumn .Width =
      ''objCelda = ObExel.Range("D2", Type.Missing)
      ''If xPt = "." Then
      ''    objCelda.EntireColumn.NumberFormat = "0.00"
      ''Else
      ''    objCelda.EntireColumn.NumberFormat = "0,00"
      ''End If

      xfield = 1
      V = 2
      H = 1


      'ObExel.Workbooks.Add()
      'Empezamos a Pasar los datos a Excel
      'Primera Linea
      objApp.Cells(1, 1) = "Número Documento"
      objApp.Cells(1, 2) = "Tipo Identificación"
      objApp.Cells(1, 3) = "Número Identificación"
      objApp.Cells(1, 4) = "Nombre Completo"
      objApp.Cells(1, 5) = "Fecha Corte"
      objApp.Cells(1, 6) = "Fecha Vencimiento"
      objApp.Cells(1, 7) = "Moneda"
      objApp.Cells(1, 8) = "Valor Saldo Deuda"
      objApp.Cells(1, 9) = "Estado"
      objApp.Cells(1, 10) = "Dirección"
      objApp.Cells(1, 11) = "Distrito"
      objApp.Cells(1, 12) = "Provincia"
      objApp.Cells(1, 13) = "Departamento"
      objApp.Cells(1, 14) = "Ubigeo"
      objApp.Cells(1, 15) = "Código Ciudad"
      objApp.Cells(1, 16) = "Teléfono"
      objApp.Cells(1, 17) = "Email"

      For Each DtRw In Dtp.Rows
        With objApp

          'Demas Lineas
          .Cells(V, H) = (DtRw("numero"))
          .Cells(V, H + 1) = 1
          .Cells(V, H + 2) = (DtRw("documento_dni"))
          .Cells(V, H + 3) = (DtRw("nombre_persona"))
          .Cells(V, H + 4) = (DtRw("fecha_corte"))
          .Cells(V, H + 5) = (DtRw("vencimiento"))
          .Cells(V, H + 6) = "Soles"
          .Cells(V, H + 7) = FormatNumber(CSng(DtRw("saldo")), 2, TriState.True, TriState.False, TriState.True)

          .Cells(V, H + 8) = (DtRw("estado"))

          .Cells(V, H + 9) = (DtRw("direccion"))

          .Cells(V, H + 10) = (DtRw("distrito"))
          .Cells(V, H + 11) = (DtRw("provincia"))
          .Cells(V, H + 12) = (DtRw("departamento"))
          .Cells(V, H + 13) = (DtRw("telefono"))


          .Cells(V, H + 14) = Trim(DtRw("email"))

        End With
        V = V + 1
      Next DtRw

      objApp.Visible = True
    End If
    picAjaxRes.Visible = False
    picAjaxBig.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
  End Sub

  Private Sub ExportarExcel(ByVal ObExel As Microsoft.Office.Interop.Excel.Application, ByVal Dtp As DataTable, ByVal xCondi As String)

    Dim DtRw As DataRow
    Dim xfield, V, H As Long
    Dim Centro_Costo As Long = 0
    Dim xPt As String = ""
    'xPt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator


    'Dim objCelda As Excel.Range

    ''objCelda = ObExel.Range("E2", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    ''objCelda = ObExel.Range("F3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    ''objCelda = ObExel.Range("G3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 40
    ''objCelda = ObExel.Range("H3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    ''objCelda = ObExel.Range("I3", Type.Missing)
    ''objCelda.EntireColumn.ColumnWidth = 3
    'objCelda = objHojaExcel.Range("C3", Type.Missing)
    'objCelda.Value = "Nombre"

    'objCelda = objHojaExcel.Range("D3", Type.Missing)
    'objCelda.Value = "Precio RD$"
    'objCelda.EntireColumn .Width =
    ''objCelda = ObExel.Range("D2", Type.Missing)
    ''If xPt = "." Then
    ''    objCelda.EntireColumn.NumberFormat = "0.00"
    ''Else
    ''    objCelda.EntireColumn.NumberFormat = "0,00"
    ''End If

    xfield = 1
    V = 2
    H = 1


    'ObExel.Workbooks.Add()
    'Empezamos a Pasar los datos a Excel
    'Primera Linea
    ObExel.Cells(1, 1) = "Número Documento"
    ObExel.Cells(1, 2) = "Tipo Identificación"
    ObExel.Cells(1, 3) = "Número Identificación"
    ObExel.Cells(1, 4) = "Nombre Completo"
    ObExel.Cells(1, 5) = "Fecha Corte"
    ObExel.Cells(1, 6) = "Fecha Vencimiento"
    ObExel.Cells(1, 7) = "Moneda"
    ObExel.Cells(1, 8) = "Estado"
    ObExel.Cells(1, 9) = "Dirección"
    ObExel.Cells(1, 10) = "Distrito"
    ObExel.Cells(1, 11) = "Provincia"
    ObExel.Cells(1, 12) = "Departamento"
    ObExel.Cells(1, 13) = "Ubigeo"
    ObExel.Cells(1, 14) = "Código Ciudad"
    ObExel.Cells(1, 15) = "Teléfono"
    ObExel.Cells(1, 16) = "Email"

    For Each DtRw In Dtp.Rows
      With ObExel

        'Demas Lineas
        .Cells(V, H) = (DtRw("documento")) & " " & (DtRw("numero"))
        .Cells(V, H + 1) = 1
        .Cells(V, H + 2) = (DtRw("documento_dni"))
        .Cells(V, H + 3) = (DtRw("nombre_persona"))
        .Cells(V, H + 4) = (DtRw("fecha_corte"))
        .Cells(V, H + 5) = (DtRw("vencimiento"))
        .Cells(V, H + 6) = "Soles"
        .Cells(V, H + 7) = (DtRw("nombre_persona"))

        .Cells(V, H + 8) = FormatNumber(CSng(DtRw("saldo")), 2, TriState.True, TriState.False, TriState.True)

        .Cells(V, H + 9) = (DtRw("estado"))

        .Cells(V, H + 10) = (DtRw("direccion"))

        .Cells(V, H + 11) = (DtRw("distrito"))
        .Cells(V, H + 12) = (DtRw("provincia"))
        .Cells(V, H + 13) = (DtRw("departamento"))
        .Cells(V, H + 14) = (DtRw("telefono"))


        .Cells(V, H + 15) = Trim(DtRw("email"))

      End With
      V = V + 1
    Next DtRw

    ObExel.Visible = True
  End Sub

  Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
    picAjaxRes.Visible = True
    gpCriterios.Enabled = False
    gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    dgvResumen.DataSource = Nothing
    _codigo = 0
    LblDeudaTotal.Text = "0.00"
    Call Totales_Cero()
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub cboAlmacen_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.ValueChanged
    dgvResumen.DataSource = Nothing
    dgvListado.DataSource = Nothing
    _codigo = 0
    Call Totales_Cero()
  End Sub

  Private Function Actiualizar_Grid_Pagos() As DataTable
    Dim DtTemp As New DataTable, NwRow As DataRow
    Dim dgvPagos As UltraGridRow
    ' Dim ObjTv As tabla_virtual

    DtTemp = ClsGridDetallePagos.Crear_Grid("cancela")

    With dgvListado.Selected
      If .Rows.Count > 0 Then
        For Each dgvPagos In .Rows
          If dgvPagos.Band.Index = 0 Then

            'Val(rsCXC("Importe")), Val(rsCXC("Saldo")), Trim(rsCXC("Moneda")))
            'select doc.codigo, d.nombre_corto,mb.numero,mb.fecha_registro as fecha,det.importe::numeric,mb.observacion
            'codigo,registro,nombre_corto,numero,total,cancela,observacion
            If dgvPagos.Cells("saldo").Value > 0 Then
              NwRow = DtTemp.NewRow
              NwRow.Item("codigo") = dgvPagos.Cells("codigo").Value
              'NwRow.Item("NroCuenta") = (dgvPagos.Cells("nrocuenta").Value)
              'NwRow.Item("C_Costo") = CSng(dgvPagos.Cells("C_Costo").Value)
              NwRow.Item("Nombre_Corto") = dgvPagos.Cells("documento").Value
              NwRow.Item("Número") = dgvPagos.Cells("numero").Value
              NwRow.Item("Vencimiento") = dgvPagos.Cells("vencimiento").Value
              NwRow.Item("Saldo") = CSng(dgvPagos.Cells("saldo").Value)
              NwRow.Item("Amortiza") = CSng(dgvPagos.Cells("saldo").Value)

              NwRow.Item("observacion") = dgvPagos.Cells("observacion").Value
              DtTemp.Rows.Add(NwRow)
            End If
          End If
        Next

      End If
    End With

    Return DtTemp
  End Function

  Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
    Dim vTienePermiso As Boolean = False
    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "porcobrar-add", vTienePermiso)
    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
      FrmPor_CobrarNM.pCodigo_Alm = cboAlmacen.Value
      FrmPor_CobrarNM.pAlmacen = cboAlmacen.Text
      FrmPor_CobrarNM.ShowDialog()
    End If
  End Sub

  Private Sub tsmResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmResumen.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          _codigo = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
            pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
            pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
          End If

        End If
      End If
    End If


    If cboAlmacen.Value > 0 And pCodigo_Asis > 0 Then
      Dim DtRpt As New DataTable, xDesde As String = "", vHasta As String, xCondi As String = "", vOpcion As String = ""

      If cboTipo.Text = "Iglesia" Then
        xCondi = "Listado de Cuenta por Cobrar Iglesias "
        vOpcion = ""
      Else
        xCondi = "Listado de Cuenta por Cobrar Colportores "
        vOpcion = "COLP"
      End If

      If chkConsDinamico.Checked Then
        xDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        xCondi = xCondi & " Desde: " & Me.cboDesde.Value
      End If

      vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
      xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value

      DtRpt = por_cobrarManager.RptPorCobrar_Res(False, xDesde, vHasta, pCodigo_Asis, cboAlmacen.Value, vOpcion)

      Dim frm As New FrmVisor_PorCobrar

      frm.RptPorCobrar_Res(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente)

      Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar Resumen")
    End If
  End Sub

  Private Sub tsmEstadoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEstadoCuenta.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          _codigo = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          DtRpt = por_cobrarManager.RptEstado_Cuenta("finanzas.paestado_cuenta_01", _codigo, cboAlmacen.Value, vHasta)
          xCondi = "Estado de Cuenta Genral (pago detallado) Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptEstado_Cuenta(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente)
          'frm.MdiParent = Me.MdiParent
          'frm.Show()

          Call LibreriasFormularios.Ver_Form(frm, "Estado Cuenta")
        End If
      End If
    End If
  End Sub

  Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvResumen, ugExcelExporter, "pc.xls")
  End Sub

  Private Sub tsExcelRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcelRes.Click
    Call Exportar_Excel()
  End Sub

  Private Sub tsListado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListado.Click
    If GestionSeguridadManager.gUnidadId > 0 Then
      If cboAlmacen.Value > 0 Then
        Dim DtRpt As New DataTable, vHasta As String, xCondi As String = "", vOpcion As Integer = 0
        If Not cboTipo.Text = "" Then
          vOpcion = cboTipo.Value
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
        DtRpt = por_cobrarManager.Leer_Res(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vHasta, vOpcion, Long.Parse(lblPersonaId.Text), chkTodos.Checked) 'por_cobrarManager.RptEstado_Cuenta(_codigo, cboAlmacen.Value, vHasta)
        xCondi = "Listado Resumen Cuentas por Cobrar: " & Me.CboFecha2.Value & " Tipo: " & cboTipo.Text
        Dim frm As New FrmVisor_PorCobrar

        frm.RptResumen_CxC(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente, False)
        Call LibreriasFormularios.Ver_Form(frm, "Resumen CxC")
      End If
    End If
  End Sub


  Private Sub tsResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsResumen.Click
    If GestionSeguridadManager.gUnidadId > 0 Then
      If cboAlmacen.Value > 0 Then
        Dim DtRpt As New DataTable, vHasta As String, xCondi As String = "", vOpcion As Integer = 0
        If Not cboTipo.Text = "" Then
          vOpcion = cboTipo.Value
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
        DtRpt = por_cobrarManager.Leer_Res(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vHasta, vOpcion, Long.Parse(lblPersonaId.Text), chkTodos.Checked) 'por_cobrarManager.RptEstado_Cuenta(_codigo, cboAlmacen.Value, vHasta)
        xCondi = "Listado Totales Cuentas por Cobrar: " & Me.CboFecha2.Value & " Tipo: " & cboTipo.Text
        Dim frm As New FrmVisor_PorCobrar

        frm.RptResumen_CxC(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente, True)
        Call LibreriasFormularios.Ver_Form(frm, "Totales CxC")
      End If
    End If
  End Sub

  Private Sub tsOpSaldoConsigFacturado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsOpSaldoConsigFacturado.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          DtRpt = por_cobrarManager.RptSaldo_Prod_Fact(cboAlmacen.Value, vPersonaid, vHasta)
          xCondi = "Listado de saldo productos Facturados Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptSaldo_Prod_Fact(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Saldo Productos")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub tsOpImporteConsigFacturado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsOpImporteConsigFacturado.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vDesde As String, vHasta As String, xCondi As String = ""
          vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          DtRpt = por_cobrarManager.RptImporte_Prod_Fact(cboAlmacen.Value, vPersonaid, vDesde, vHasta)
          xCondi = "Listado de productos Facturados Desde: " & cboDesde.Value & " Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptImp_Prod_Fact(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Importe Facturados")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub tsMnuDetDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMnuDetDocumentos.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vDesde As String = "", vHasta As String, xSub As String, xCondi As String = ""
          xSub = "Detalle de Productos Facturados"
          If cboDesde.Visible = True Then
            vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
            xCondi = "Desde: " & cboDesde.Value
          End If


          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          DtRpt = ReportesManager.Detalle_Documento_Merca("inventarios.pareporte_ventas_detalladas_producto", vDesde, vHasta,
                                                            GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vPersonaid, 0)
          Dim frm As New FrmVisor_Listado
          xCondi = xCondi & " Hasta: " & CboFecha2.Value
          xCondi = xCondi & " Codigo Persona : " & vPersonaid

          frm.RptDetalle_Doc_Mercaderia(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xSub, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Detalle por Fact.")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub tsmResProdFacturados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmResProdFacturados.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vDesde As String = "", vHasta As String = "", xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          If chkConsDinamico.Checked Then
            vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
            xCondi = xCondi & "Desde: " & cboDesde.Value
          End If

          DtRpt = por_cobrarManager.RptSaldo_Prod_Fact("inventarios.pasaldofacturacion", cboAlmacen.Value, vPersonaid, vDesde, vHasta)
          xCondi = "Listado de saldo productos Facturados "

          xCondi = xCondi & "Hasta: " & Me.CboFecha2.Value

          Dim frm As New FrmVisor_PorCobrar

          frm.RptSaldo_Prod_Fact(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Resumen Facturados")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub tsMnuDetDocCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsMnuDetDocCredito.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vDesde As String = "", vHasta As String, xSub As String, xCondi As String = ""
          xSub = "Detalle de Productos Facturados al crédito"
          If cboDesde.Visible = True Then
            vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
            xCondi = "Desde: " & cboDesde.Value
          End If


          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          DtRpt = ReportesManager.Detalle_Documento_Merca("inventarios.pareporte_ventas_detalladas_credito", vDesde, vHasta,
                                                                        GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vPersonaid, 0)
          Dim frm As New FrmVisor_Listado
          xCondi = xCondi & " Hasta: " & CboFecha2.Value
          xCondi = xCondi & " Codigo Persona : " & vPersonaid

          frm.RptDetalle_Doc_Mercaderia(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xSub, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Detalle Crédito")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub tsMnuDetDocCreditoWeb_Click(sender As Object, e As EventArgs) Handles tsMnuDetDocCreditoWeb.Click
    Dim vPersonaid As Long = 0

    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vDesde As String = "", vHasta As String, xSub As String, xCondi As String = ""
          xSub = "Detalle de Cuentas por cobrar"
          If cboDesde.Visible = True Then
            vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
            xCondi = "Desde: " & cboDesde.Value
          End If


          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersonaid = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          DtRpt = ReportesManager.Detalle_Documento_Merca("finanzas.pareporte_detalle_docs_porcobrar", vDesde, vHasta,
                                                                        GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vPersonaid, 0)
          Dim frm As New FrmVisor_Listado
          xCondi = xCondi & " Hasta: " & CboFecha2.Value
          xCondi = xCondi & " Codigo Persona : " & vPersonaid

          frm.RptDetalle_Doc_Mercaderia_Web(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xSub, xCondi)
          Call LibreriasFormularios.Ver_Form(frm, "Detalle Crédito Web")
        Else

        End If
      End If
    End If
  End Sub

  Private Sub chkConsDinamico_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsDinamico.CheckedChanged
    cboDesde.Visible = chkConsDinamico.Checked
  End Sub

  Private Sub tsmResumenCons_Click(sender As Object, e As EventArgs) Handles tsmResumenCons.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          _codigo = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
            pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
            pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
          End If

        End If
      End If
    End If


    If cboAlmacen.Value > 0 Then
      Dim DtRpt As New DataTable, xDesde As String = "", vHasta As String, xCondi As String = "", vOpcion As String = ""

      If cboTipo.Text = "Iglesia" Then
        xCondi = "Listado de Cuenta por Cobrar Consolidado por D.M. "
        vOpcion = ""
      Else
        xCondi = "Listado de Cuenta por Cobrar Consolidado por Aistente "
        vOpcion = "COLP"
      End If

      If chkConsDinamico.Checked Then
        xDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        xCondi = xCondi & " Desde: " & Me.cboDesde.Value
      End If

      vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
      xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value


      DtRpt = por_cobrarManager.RptPorCobrar_Res(False, xDesde, vHasta, Long.Parse(lblPersonaId.Text), cboAlmacen.Value, vOpcion)


      Dim frm As New FrmVisor_PorCobrar
      pAsistente = "Consolidado"
      frm.RptPorCobrar_Res(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente)


      Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar Resumen Cons")
    End If
  End Sub

  Private Sub tsmSaldoNdias_Click(sender As Object, e As EventArgs) Handles tsmSaldoNdias.Click
    Dim DtRpt As New DataTable, xDesde As String = "", vHasta As String, xCondi As String = "", vOpcion As String = ""

    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value
    vOpcion = cboTipo.Text
    xCondi = xCondi & " - " & cboTipo.Text
    DtRpt = por_cobrarManager.RptPorCobrar_Ndias(False, xDesde, vHasta, 0, cboAlmacen.Value, Long.Parse(lblPersonaId.Text), vOpcion, 0)

    Dim frm As New FrmVisor_PorCobrar
    frm.RptPorCobrar_Ndias(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi)


    Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar N Días")
  End Sub

  Public Sub Listado_clientes()
    Dim testDialog As New FrmConsulta_Personas()
    'testDialog.Cod_Cat = 4
    TxtAnombreD.Text = ""
    lblPersonaId.Text = "-2"

    If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
      Dim objP As New persona
      lblPersonaId.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
      TxtAnombreD.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
    End If
    testDialog.Dispose()
  End Sub

  Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
    Call Listado_clientes()
  End Sub

  Private Sub TxtAnombreD_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAnombreD.KeyDown
    If e.KeyCode = Keys.Enter Then
      If TxtAnombreD.Text = "" Then
        Call Listado_clientes()
      End If
    Else
      TxtAnombreD.Text = ""
      lblPersonaId.Text = "-2"
    End If
  End Sub

  Private Sub tsmEstadoCuenta2_Click(sender As Object, e As EventArgs) Handles tsmEstadoCuenta2.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim dtCxC As New DataTable
          Dim vHasta As String, xCondi As String = "", xCod_uni As Integer, xCod_Alm As Integer, vPersona As Long
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          vPersona = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          xCod_uni = GestionSeguridadManager.gUnidadId

          If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
          End If
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)


          dtCxC = por_cobrarManager.RptEstado_Cuenta2(xCod_uni, xCod_Alm, vHasta, 0, vPersona)
          xCondi = "Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptEstado_Cuenta2(dtCxC, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Estado de Cuenta por Cliente Detallado", xCondi)
          'frm.MdiParent = Me.MdiParent
          'frm.Show()

          Call LibreriasFormularios.Ver_Form(frm, "Estado Cuenta 2")
        End If

      End If
    End If

  End Sub

  Private Sub tsmEstadoCuenta1b_Click(sender As Object, e As EventArgs) Handles tsmEstadoCuenta1b.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          _codigo = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          DtRpt = por_cobrarManager.RptEstado_Cuenta("finanzas.paestado_cuenta_01b", _codigo, cboAlmacen.Value, vHasta)
          xCondi = "Estado de Cuenta Genral (pago resumen) Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptEstado_Cuenta(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente)
          'frm.MdiParent = Me.MdiParent
          'frm.Show()

          Call LibreriasFormularios.Ver_Form(frm, "Estado Cuenta")
        End If
      End If
    End If
  End Sub

  Private Sub opMnuAnticipo_Click(sender As Object, e As EventArgs) Handles opMnuAnticipo.Click
    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        Dim FrmDtP As New FrmMovimiento_BancarioNM

        With FrmDtP
          .txtFecha.Value = Date.Now.Date
          .vIngreso = True
          .pNC = False
          .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
          .pCodigo_Alm = cboAlmacen.Value
          .lblAlmacen.Text = GestionSeguridadManager.gUnidad
          .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
          .txtRucDni.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          .lblNroCuenta.Text = "2139091"

          .pCodigo_Per = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .lblPersonaId.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .vOkR = True
          .ShowDialog()
        End With
      End If
    End If
  End Sub

  Private Sub opMnuDuplicado_Click(sender As Object, e As EventArgs) Handles opMnuDuplicado.Click
    If xCodio_Abo > 0 Then
      Dim xLegal As Boolean = False, xCaja As String = "XCOBRAR"
      If xCodigo_Doc_Abo = 11 Then
        xLegal = True
        xCaja = "XCOBRARNC"
      ElseIf xCodigo_Doc_Abo = 5 Then
        xLegal = False
      Else
        xLegal = True
      End If

      Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(xCodio_Abo), cboAlmacen.Value, xCodigo_Doc_Abo, xCaja, xLegal, False)
    End If
    'FrmPor_CobrarNM.ShowDialog()
  End Sub

  Private Sub opMnuDscto_Click(sender As Object, e As EventArgs) Handles opMnuDscto.Click
    Dim vEmitir As Integer = 0, vDocLegal As Integer = 0

    If dgvResumen.Rows.Count > 0 Then
      If dgvResumen.Selected.Rows.Count > 0 Then
        If Not _codigo = CInt((dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)) Then
          MessageBox.Show("Inconsistencia, vuelva a actualizar y seleccionar la persona, así como sus cuentas a pagar", "AVISO", MessageBoxButtons.OK)
          Exit Sub
        End If
      End If
    End If

    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count = 1 Then
        vDocLegal = Integer.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("codigo_contable").Value)
        If Not vDocLegal > 0 Then
          MessageBox.Show("Sólo debe emitir una nota de crédito de un documento legal", "AVISO", MessageBoxButtons.OK)
          Exit Sub
        End If

        Dim FrmDtP As New FrmAbono_PorCobrar

        With FrmDtP
          .txtFecha.Value = Date.Now.Date
          .vIngreso = True
          .pNC = True
          .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
          .pCodigo_Alm = cboAlmacen.Value
          .lblAlmacen.Text = GestionSeguridadManager.gUnidad
          .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
          .txtRucDni.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          .vCodigo_Per1 = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          .lblNroCuenta.Text = dgvListado.DisplayLayout.ActiveRow.Cells("nrocuenta").Value


          .lblC_Costo.Text = dgvListado.DisplayLayout.ActiveRow.Cells("c_costo").Value

          If vDocLegal > 0 Then
            .vDoc_Legal = True
          End If

          If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value) Then
            .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value
          Else
            .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value

          End If



          'If .TxtAnombreD.Tag = 0 Then
          '    .TxtAnombreD.Tag = Me.TxtDNI_RUC.Text
          'End If
          .DtG = Actiualizar_Grid_Pagos()

          If .DtG.Rows.Count > 0 Then
            .ShowDialog()
            Exit Sub
          End If
          .Dispose()
        End With
      Else
        MessageBox.Show("Sólo debe seleccionar un registro para emitir una nota de crédito", "AVISO", MessageBoxButtons.OK)
        Exit Sub
      End If
    End If
  End Sub

  Private Sub opMnuDelete_Click(sender As Object, e As EventArgs) Handles opMnuDelete.Click
    If cboAlmacen.Value > 0 Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          Dim vTienePermiso As Boolean = False
          Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "porcobrar-delete", vTienePermiso)
          If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
            If MessageBox.Show("¿Está seguro de eliminar este registro, va afectar sus cuentas por cobrar?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
              Dim DtRpt As New DataTable, vIdDet As Long = 0
              vIdDet = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

              If por_cobrarManager.Eliminar(vIdDet, GestionSeguridadManager.sUsuario, My.Computer.Name) Then
                Call Mostrar_Detalles()
              End If
            End If
          End If
        End If
      End If
    End If
  End Sub

  Private Sub opMnuUtilSobrante_Click(sender As Object, e As EventArgs) Handles opMnuUtilSobrante.Click
    Call Abono_PorCobrarII()
  End Sub

  Private Sub tsdpSehs1_Click(sender As Object, e As EventArgs) Handles tsdpSehs1.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim vIdClie As Long = 0, vUnidadId As Long = 0, vSaldo As Single = 0

          vIdClie = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          vUnidadId = GestionSeguridadManager.gUnidadId
          vSaldo = dgvResumen.DisplayLayout.ActiveRow.Cells(4).Value

          If LibreriasFormularios.Emitir_Carta_Sehs("carta1.doc", vIdClie, vUnidadId, vSaldo) Then

          End If

        End If
      End If
    End If
  End Sub

  Private Sub tsmResumenColp_Click(sender As Object, e As EventArgs) Handles tsmResumenColp.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim DtRpt As New DataTable, vHasta As String, xCondi As String = ""
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
          _codigo = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
            pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
            pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
          End If

        End If
      End If
    End If


    If cboAlmacen.Value > 0 And pCodigo_Asis > 0 Then
      Dim DtRpt As New DataTable, xDesde As String = "", vHasta As String, xCondi As String = "", vOpcion As String = ""

      If cboTipo.Text = "Iglesia" Then
        xCondi = "Listado de Cuenta por Cobrar Iglesias "
        vOpcion = ""
      Else
        xCondi = "Listado de Cuenta por Cobrar Colportores "
        vOpcion = "COLP"
      End If

      If chkConsDinamico.Checked Then
        xDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        xCondi = xCondi & " Desde: " & Me.cboDesde.Value
      End If

      vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
      xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value

      DtRpt = por_cobrarManager.RptPorCobrar_Res_Colp(False, xDesde, vHasta, pCodigo_Asis, cboAlmacen.Value, vOpcion)

      Dim frm As New FrmVisor_PorCobrar

      frm.RptPorCobrar_Res_Colp(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente)


      Call LibreriasFormularios.Ver_Form(frm, "Por Cobrar Resumen Colp")
    End If
  End Sub


End Class
