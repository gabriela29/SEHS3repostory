Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop
Imports System.IO
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class FrmPor_Pagar
  Public _codigo As Long, xCodio_Abo As Long = 0, pCodigo_Asis As Long = 0, pAsistente As String = "", pCodigo_Cli As Long = 0
  Public ListadoDoc As DataTable
  Public xCodigo_Doc_Abo As Integer = 0, vDesde As Boolean, pDtCtaCte As DataTable

  Private Sub formatear_grid()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    Me.dgvListado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    'Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    Me.dgvListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
      Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
    End If

    Me.dgvListado.DisplayLayout.Appearance = Appearance1

    Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
    Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

    Appearance62.BackColor = Color.RoyalBlue   'System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance62.BackColor2 = Color.LightCyan   'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
    Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = System.Drawing.Color.Blue
    Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

    Appearance63.BackColor = System.Drawing.Color.SteelBlue
    Appearance63.BackColor2 = System.Drawing.Color.LightCyan
    Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
    Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

    Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default

    ''Appearance64.BackColor = System.Drawing.Color.White
    Appearance64.BackColor = System.Drawing.Color.LightSteelBlue
    'Appearance64.BackColor2 = System.Drawing.Color.White
    'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical        
    'Appearance64.FontData.BoldAsString = "True"
    Appearance64.ForeColor = Color.Navy
    'Appearance64.ForeColor = Color.White
    Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

    Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
    Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid

    ''Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    'para Seleccionar solo una Fila
    'Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
    'Para seleccionar toda la Fila
    Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
    'Me.dgvListado.Name = "dgvListado"
    'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
    'Me.dgvListado.TabIndex = 1
    'Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
  End Sub

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
      pDtCtaCte = New DataTable
      pDtCtaCte = plan_cuentasManager.Plan_CtaCte_GetList(GestionSeguridadManager.gEntidad)
      'Dim dtL As DataTable
      'Dim x As Integer = 6
      'Dim opcionesv(x), opciones(x) As String
      'opcionesv(0) = 0
      'opcionesv(1) = 1
      'opcionesv(2) = 2
      'opcionesv(3) = 3
      'opcionesv(4) = 4
      'opcionesv(5) = 5
      'opcionesv(6) = 6

      'opciones(0) = "Todos"
      'opciones(1) = "Permanentes"
      'opciones(2) = "Estudiantes"
      'opciones(3) = "Nacionales"
      'opciones(4) = "Asistente"
      'opciones(5) = "Individual"
      'opciones(6) = "Iglesia"

      'dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

      'With cboTipo
      '    .DataSource = Nothing
      '    .DataSource = dtL
      '    .Refresh()
      '    .ValueMember = "opcionesv"
      '    .DisplayMember = "opciones"
      '    If .Rows.Count > 0 Then
      '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
      '    End If
      'End With


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
  End Sub

  Private Sub FrmPorPagar_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
    cboDesde.Text = "01/" & Now.Month & "/" & Now.Year
    CboFecha2.Text = Now.Date
    Call formatear_grid()
    Call Totales_Cero()
  End Sub

  Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActualizar.Click
    picAjaxRes.Visible = True
    If Not bwLlenar_Res.IsBusy Then
      bwLlenar_Res.RunWorkerAsync()
    End If
  End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0

    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    'If Not cboTipo.Text = "" Then
    vOpcion = 0
    'End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
    If lblPersonaId.Text > 0 Then
      vPersona = lblPersonaId.Text
    End If

    DtRes = por_pagarManager.Leer_Res(xCod_uni, xCod_Alm, vHasta, vOpcion, vPersona)

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

        'If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value) Then
        '    pCodigo_Asis = Long.Parse((dgvResumen.DisplayLayout.ActiveRow.Cells("codigo_asis").Value))
        '    pAsistente = dgvResumen.DisplayLayout.ActiveRow.Cells("asistente").Value
        'End If

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

    xCod_uni = GestionSeguridadManager.gUnidadId

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

    ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
    ' create and bind sample DataSet
    Call por_pagarManager.Leer_Detalles(xCod_uni, xCod_Alm, vHasta, 0, _codigo, DtSumCargos, DtSumAbonos)
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
      '.Columns(6).Header.Caption = "Asistente"
      '.Columns(6).Width = 160

      '.Columns(7).Width = 20
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
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
              'xCodigo_Doc_Abo = lsel.Cells("documentoid").Value
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

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
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
          Dim FrmDtP As New FrmAbono_PorPagar
          Dim vDocLegal As Integer = 0
          With FrmDtP
            .txtFecha.Value = Date.Now.Date
            .vIngreso = False
            .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
            .pCodigo_Alm = cboAlmacen.Value
            .lblAlmacen.Text = GestionSeguridadManager.gUnidad
            .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
            .txtRucDni.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
            .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
            .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
            .vCodigo_Per1 = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value


            .Text = "Abono por Pagar"
            .pDtCtaCte = pDtCtaCte

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
        End If
      End If

    End If
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

  Private Sub tsDuplicado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDuplicado.Click
    If xCodio_Abo > 0 Then

      ' Call ClsImpresiones.Imprimir_Rpt_MB(Long.Parse(xCodio_Abo), cboAlmacen.Value, xCodigo_Doc_Abo, "XCOBRAR")

    End If
    'FrmPor_CobrarNM.ShowDialog()
  End Sub

  Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
    Dim vTienePermiso As Boolean = False
    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "porcobrar-add", vTienePermiso)
    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
      FrmPor_CobrarNM.pCodigo_Alm = cboAlmacen.Value
      FrmPor_CobrarNM.pAlmacen = cboAlmacen.Text
      FrmPor_CobrarNM.ShowDialog()
    End If
  End Sub

  Private Sub tsmEstadoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEstadoCuenta.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim dtCxC As New DataTable
          Dim vfDesde As String = "", vHasta As String = "", xCondi As String = "", xCod_uni As Integer, xCod_Alm As Integer, vPersona As Long
          vfDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

          vPersona = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          xCod_uni = GestionSeguridadManager.gUnidadId

          If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
          End If
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)


          dtCxC = por_pagarManager.RptEstado_Cuenta(xCod_uni, xCod_Alm, vfDesde, vHasta, 0, vPersona)
          If Not vfDesde = "" Then
            xCondi = "Desde: " & Me.cboDesde.Value
          End If
          xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptEstado_Cuenta2(dtCxC, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Estado de Cuenta por Proveedor Detallado", xCondi)
          'frm.MdiParent = Me.MdiParent
          'frm.Show()

          Call LibreriasFormularios.Ver_Form(frm, "Estado Cuenta 2")
        End If

      End If
    End If

  End Sub

  Private Sub tsExcelRes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExcelRes.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvResumen, ugExcelExporter, "ppr.xls")
  End Sub

  Private Sub tsEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEliminar.Click
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

  Private Sub tsopMnuDsctoNC_Click(sender As Object, e As EventArgs) Handles tsopMnuDsctoNC.Click
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

        Dim FrmDtP As New FrmAbono_PorPagarII

        With FrmDtP
          .txtFecha.Value = Date.Now.Date
          .vIngreso = False
          .pNC = True
          .lblAlmacen.Tag = GestionSeguridadManager.gUnidadId
          .pCodigo_Alm = cboAlmacen.Value
          .lblAlmacen.Text = GestionSeguridadManager.gUnidad
          .LblEmpresa.Text = GestionSeguridadManager.gEmpresa
          .txtRucDni.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(1).Value
          .TxtAnombreD.Tag = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value
          .TxtAnombreD.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value
          .vCodigo_Per1 = dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value

          '.lblNroCuenta.Text = dgvListado.DisplayLayout.ActiveRow.Cells("nrocuenta").Value


          '.lblC_Costo.Text = dgvListado.DisplayLayout.ActiveRow.Cells("c_costo").Value

          If vDocLegal > 0 Then
            .vDoc_Legal = True
          End If

          'If Not IsDBNull(dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value) Then
          '  .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(6).Value
          'Else
          '  .lblPersona2Orig.Text = dgvResumen.DisplayLayout.ActiveRow.Cells(2).Value

          'End If



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

  Private Sub tsmEstadoCtaCons_Click(sender As Object, e As EventArgs) Handles tsmEstadoCtaCons.Click
    If cboAlmacen.Value > 0 Then
      If dgvResumen.Rows.Count > 0 Then
        If dgvResumen.Selected.Rows.Count > 0 Then
          Dim dtCxC As New DataTable
          Dim vfDesde As String = "", vHasta As String = "", xCondi As String = "", xCod_uni As Integer, xCod_Alm As Integer, vPersona As Long
          vfDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)

          vPersona = Long.Parse(dgvResumen.DisplayLayout.ActiveRow.Cells(0).Value)
          xCod_uni = GestionSeguridadManager.gUnidadId

          xCod_Alm = 0

          vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)


          dtCxC = por_pagarManager.RptEstado_Cuenta(xCod_uni, xCod_Alm, vfDesde, vHasta, 0, vPersona)
          If Not vfDesde = "" Then
            xCondi = "Desde: " & Me.cboDesde.Value
          End If
          xCondi = xCondi & " Hasta: " & Me.CboFecha2.Value
          Dim frm As New FrmVisor_PorCobrar

          frm.RptEstado_Cuenta2(dtCxC, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Estado de Cuenta por Proveedor Detallado", xCondi)
          'frm.MdiParent = Me.MdiParent
          'frm.Show()

          Call LibreriasFormularios.Ver_Form(frm, "Estado Cuenta 2")
        End If

      End If
    End If
  End Sub

  Private Sub tsResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsResumen.Click
    If GestionSeguridadManager.gUnidadId > 0 Then
      If cboAlmacen.Value > 0 Then
        Dim DtRpt As New DataTable, vHasta As String, xCondi As String = "", vOpcion As Integer = 0
        'If Not cboTipo.Text = "" Then
        '    vOpcion = cboTipo.Value
        'End If
        vHasta = LibreriasFormularios.Formato_Fecha(CboFecha2.Value)
        DtRpt = por_pagarManager.Leer_Res(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vHasta, vOpcion, 0)
        xCondi = "Listado Resumen Cuentas por Pagar: " & Me.CboFecha2.Value '& " Tipo: " & cboTipo.Text
        Dim frm As New FrmVisor_PorCobrar

        frm.RptResumen_CxC(DtRpt, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, xCondi, pAsistente, False)
        Call LibreriasFormularios.Ver_Form(frm, "Resumen CxP")
      End If
    End If
  End Sub

  Private Sub tsOpImporteConsigFacturado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

  Private Sub tsmExpDetExcel_Click(sender As Object, e As EventArgs) Handles tsmExpDetExcel.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "ppd.xls")
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
End Class