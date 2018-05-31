Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmLote_Detalle
  Public CtaMstra As String, _NroReg As Integer, vCentro_Costo As Long, xBA As Boolean = False, vTipo As String
  Public NroLote As Long, Lote As String, vCodigo_Almacen As Integer, vAlmacen As String, vCerrado As Boolean
  Public pAnio As String, pMes As String, pEntidad As Long, DtAsiento As DataTable
  Public pDtPlan As DataTable, pDtCtaCte As DataTable, pDtAsiento As DataTable
  Public vSubCta As Boolean = False, vFila As Long = 0, vIDr As Long = 0

  Private Function Agregar_Items_Asiento(ByVal dtDist As DataTable) As Boolean
    Dim NwRow As DataRow, dtRow As DataRow
    Dim xAdd As Boolean = False

    DtAsiento = New DataTable
    DtAsiento = ClsTablitas.Get_Asiento("asientov")
    dgvDetalle.DataSource = DtAsiento

    For Each dtRow In dtDist.Rows
      vFila = vFila + 1
      If CSng(dtRow("importe").ToString) <> 0 Then
        NwRow = DtAsiento.NewRow
        NwRow.Item("codigo") = dtRow("lotedetalleid").ToString
        NwRow.Item("fecha") = dtRow("fecha").ToString
        NwRow.Item("cuenta") = dtRow("cuenta").ToString
        NwRow.Item("nom_cuenta") = dtRow("nom_cuenta").ToString
        NwRow.Item("ctacte") = dtRow("ctacte").ToString
        NwRow.Item("nom_ctacte") = dtRow("nom_ctacte").ToString
        NwRow.Item("fondoid") = dtRow("fondoid").ToString
        NwRow.Item("fondo") = dtRow("fondo").ToString
        NwRow.Item("centro_costo") = dtRow("ccosto").ToString
        NwRow.Item("restriccion") = dtRow("restriccion").ToString
        NwRow.Item("importe") = CSng(dtRow("importe").ToString)
        NwRow.Item("importeme") = CSng(dtRow("importeme").ToString)
        NwRow.Item("glosa") = dtRow("glosa").ToString
        NwRow.Item("id") = dtRow("lotedetalleid").ToString
        DtAsiento.Rows.Add(NwRow)
        vIDr = 0
        xAdd = True
      End If
    Next
    Call Calcular_Totales_Grid()
    Return xAdd
  End Function

  Private Sub tsCerrar_Click(sender As Object, e As EventArgs) Handles tsCerrar.Click

    Me.Close()
    MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
  End Sub

  Private Sub tsGrabar_Click(sender As Object, e As EventArgs) Handles tsGrabar.Click
    Dim vArray As String = "", vTiene As Boolean = False, ok As Long = 0
    Dim dgvRw As UltraGridRow

    vTiene = False
    For Each dgvRw In Me.dgvDetalle.Rows
      If dgvRw.Band.Index = 0 Then
        vTiene = True
        vArray = vArray & "['" & Trim(Str(dgvRw.Cells("cuenta").Value)) & "', '" &
                                     Trim((dgvRw.Cells("ctacte").Value)) & "', '" &
                                     Trim(Str(dgvRw.Cells("fondoid").Value)) & "', '" &
                                     Trim((dgvRw.Cells("centro_costo").Value)) & "', '" &
                                     Trim(Str(dgvRw.Cells("importe").Value)) & "', '" &
                                     Trim(Str(dgvRw.Cells("importeme").Value)) & "', '" &
                                     Trim((dgvRw.Cells("glosa").Value)) & "', '" &
                                     Trim((dgvRw.Cells("id").Value)) & "'],"
      End If
    Next

    If vTiene Then
      vArray = Mid(vArray, 1, Len(vArray) - 1)
      vArray = "array[" & vArray & "]"
    Else
      vArray = "null"
    End If

    ok = loteManager.Grabar_Detalle(NroLote, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name)

  End Sub

  Public Function ObtenerSubCtas(ByVal vSubCtaCode As String) As Boolean
    Dim Filter As String = "subctacode = '" & vSubCtaCode & "'"
    Dim dv As DataView
    If Not pDtPlan Is Nothing Then
      dv = New DataView(pDtCtaCte, Filter, "", DataViewRowState.CurrentRows)
      If dv.Count > 0 Then 'Sino hay datos
        cboCtaCte.DataSource = dv
      End If
    Else
      cboCtaCte.Enabled = False
      lblNombre_CtaCte.Text = ""
    End If

  End Function

  Private Sub Calcular_Totales_Grid()
    Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
    dtDgv = dgvDetalle
    Dim vDebito As Single = 0, vCredito As Single = 0, vDif As Single = 0
    xBA = False
    'Call Calcular_Total_Doc()
    For Each dgvRw In dtDgv.Rows
      If dgvRw.Band.Index = 0 Then
        If dgvRw.Cells("importe").Value > 0 Then
          vDebito += dgvRw.Cells("importe").Value
        Else
          vCredito += dgvRw.Cells("importe").Value
        End If

      End If
    Next
    lblDebito.Text = FormatNumber(vDebito, 2, TriState.True, , TriState.False)
    lblCredito.Text = FormatNumber(vCredito, 2, TriState.True, , TriState.False)
    Me.lblDiferencia.Text = FormatNumber(vDebito - (vCredito * -1), 2, TriState.True, , TriState.False)

  End Sub

  Private Sub cboTipo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboTipo.InitializeLayout

  End Sub

  Private Sub Incializar()

    pDtPlan = GestionTablas.dtplan
    pDtCtaCte = New DataTable
    pDtCtaCte = plan_cuentasManager.Plan_CtaCte_GetList(GestionSeguridadManager.gEntidad)

    DtAsiento = New DataTable
    DtAsiento = ClsTablitas.Get_Asiento("distribucion")
    dgvDetalle.DataSource = DtAsiento

    With cboCuenta
      .DataSource = Nothing
      .DataSource = pDtPlan
      .DataBind()
      .ValueMember = "plancuentaid"
      .DisplayMember = "cuenta"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
    End With

    With cboCentro_Costo
      .DataSource = Nothing
      .DataSource = centro_costoManager.GetListcbo(vCodigo_Almacen, 0)
      .DataBind()
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    Dim x As Integer = 1
    Dim opcionesv(x), opciones(x) As String
    Dim dtC As DataTable
    opcionesv(0) = "D"
    opcionesv(1) = "C"

    opciones(0) = "DEBITO"
    opciones(1) = "CREDITO"

    dtC = DosOpcionesManager.GetList("Tipo", opcionesv, opciones, x)

    With cboTipo
      .DataSource = dtC
      .ValueMember = "opcionesv"
      .DisplayMember = "opciones"
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With


    If Agregar_Items_Asiento(loteManager.GetList_Detalle(NroLote)) Then

    End If

  End Sub

  Private Sub FrmLote_Detalle_Load(sender As Object, e As EventArgs) Handles Me.Load
    LblNroLote.Text = NroLote
    LblNroLote.Tag = NroLote
    LblDescripLote.Text = Lote
    LblDescripLote.Tag = vCodigo_Almacen
    lblUnidad_Negocio.Text = vTipo & "-" & vAlmacen

    Call Incializar()
  End Sub

  Private Sub cboCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCuenta.Validated
    If cboCuenta.ActiveRow Is Nothing Then
      If Not cboCuenta.Text = "" Then
        cboCuenta.Focus()
        lblNombre_Cta.Text = ""
      End If
    Else
      Dim vCtaCde As String = ""
      vCtaCde = cboCuenta.ActiveRow.Cells("subctacode").Value
      lblNombre_Cta.Text = cboCuenta.ActiveRow.Cells("nombre").Value
      lblRestriccion.Text = cboCuenta.ActiveRow.Cells("restrincode").Value
      cboCtaCte.DataSource = Nothing
      If Not vCtaCde.Trim = "" Then
        If ObtenerSubCtas(vCtaCde) Then

        End If

      End If
    End If
  End Sub

  Private Sub cboCuenta_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.ValueChanged
    lblNombre_Cta.Text = ""
    lblNombre_CtaCte.Text = ""
    cboCtaCte.Text = ""
    lblNombre_CtaCte.Text = ""
    lblRestriccion.Text = ""
    vSubCta = False
  End Sub

  Private Sub cboCuenta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCuenta.InitializeLayout
    With cboCuenta.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns("cuenta").Width = cboCuenta.Width
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      '.Columns(3).Hidden = True
      .Columns(4).Hidden = True
    End With
  End Sub

  Private Sub cboCtaCte_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCtaCte.Validated
    If cboCtaCte.ActiveRow Is Nothing Then
      If Not cboCtaCte.Text = "" Then
        cboCtaCte.Focus()
        lblNombre_CtaCte.Text = ""
      End If
    Else
      lblNombre_CtaCte.Text = cboCtaCte.ActiveRow.Cells("nombre").Value
    End If
  End Sub

  Private Sub cboCtaCte_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCtaCte.InitializeLayout
    With cboCtaCte.DisplayLayout.Bands(0)
      '.Columns(0).Hidden = True
      .Columns("ctacte").Width = cboCtaCte.Width
      '.Columns("nombre").Width = cboCuenta.Width
      '.Columns(2).Hidden = True
      .Columns(3).Hidden = True

    End With
  End Sub

  Private Sub FrmLote_Detalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{TAB}")
    End If
  End Sub

  Private Function Validar_Distribucion() As Boolean
    Dim valido As Boolean = True

    If Not (cboCuenta.Text = "" Or lblNombre_Cta.Text = "") Then
      If Not cboCuenta.ActiveRow.Cells("subctacode").Value = "" Then
        If Trim(cboCtaCte.Text) = "" Or lblNombre_CtaCte.Text = "" Then
          valido = False
          MessageBox.Show("Debe seleccionar una Cta. Cte.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
          cboCtaCte.Focus()
        Else

        End If
      End If
    Else
      valido = False
      MessageBox.Show("Debe seleccionar una Cuenta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      cboCuenta.Focus()
    End If
    If cboCentro_Costo.Text = "" Then
      valido = False
      MessageBox.Show("Debe seleccionar un Centro de Costo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      cboCentro_Costo.Focus()
    End If
    If TxtGlosa.Text = "" Then
      valido = False
      MessageBox.Show("Debe Ingresar una glosa", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      TxtGlosa.Focus()
    End If


    Return valido

  End Function

  Private Function Agregar_Item_Asiento() As Boolean
    Dim NwRow As DataRow
    Dim xAdd As Boolean = False

    If Validar_Distribucion() Then
      If vIDr = 0 Then
        vFila = vFila + 1
        NwRow = DtAsiento.NewRow

        NwRow.Item("codigo") = vFila
        NwRow.Item("fecha") = Now.Date
        NwRow.Item("cuenta") = cboCuenta.Text.Trim
        NwRow.Item("nom_cuenta") = lblNombre_Cta.Text
        NwRow.Item("ctacte") = cboCtaCte.Text.Trim
        NwRow.Item("nom_ctacte") = lblNombre_CtaCte.Text
        NwRow.Item("fondoid") = 10
        NwRow.Item("fondo") = "Fondo Operacional"
        NwRow.Item("centro_costo") = cboCentro_Costo.Value
        NwRow.Item("restriccion") = lblRestriccion.Text
        NwRow.Item("importe") = CSng(txtImporteD.Text)
        NwRow.Item("importeme") = CSng(txtImporteME.Text)
        NwRow.Item("glosa") = TxtGlosa.Text.Trim & ""
        'NwRow.Item("num_factura") = txtNroFactura.Text.Trim & ""

        'If IsDate(txtFecha.Text) Then
        '  NwRow.Item("fecha_factura") = LibreriasFormularios.Formato_Fecha(txtFecha.Text.Trim)
        'Else
        '  NwRow.Item("fecha_factura") = ""
        'End If
        'If IsDate(txtFecha.Text) Then
        '  NwRow.Item("vence_factura") = LibreriasFormularios.Formato_Fecha(txtVencimiento.Text.Trim)
        'Else
        '  NwRow.Item("vence_factura") = ""
        'End If

        NwRow.Item("id") = Long.Parse(vFila)

        DtAsiento.Rows.Add(NwRow)
        vIDr = 0
        xAdd = True
      Else
        'NwRow = DtAsiento.NewRow
        Dim findTheseVals(vIDr) As Object

        NwRow = DtAsiento.Rows.Find(vIDr)

        NwRow.Item("fecha") = Now.Date
        NwRow.Item("cuenta") = cboCuenta.Text.Trim
        NwRow.Item("nom_cuenta") = lblNombre_Cta.Text
        NwRow.Item("ctacte") = cboCtaCte.Text.Trim
        NwRow.Item("nom_ctacte") = lblNombre_CtaCte.Text
        NwRow.Item("fondoid") = 10
        NwRow.Item("fondo") = "Fondo Operacional"
        NwRow.Item("centro_costo") = cboCentro_Costo.Value
        NwRow.Item("restriccion") = lblRestriccion.Text
        NwRow.Item("importe") = CSng(txtImporteD.Text)
        NwRow.Item("importeme") = CSng(txtImporteME.Text)
        NwRow.Item("glosa") = TxtGlosa.Text.Trim & ""
        'If IsDate(txtFecha.Text) Then
        '  NwRow.Item("fecha_factura") = LibreriasFormularios.Formato_Fecha(txtFecha.Text.Trim)
        'Else
        '  NwRow.Item("fecha_factura") = ""
        'End If
        'If IsDate(txtFecha.Text) Then
        '  NwRow.Item("vence_factura") = LibreriasFormularios.Formato_Fecha(txtVencimiento.Text.Trim)
        'Else
        '  NwRow.Item("vence_factura") = ""
        'End If
        DtAsiento.AcceptChanges()
        DtAsiento.Select()
        vIDr = 0
        'DtAsiento.Rows.
        xAdd = True
      End If


    End If
    Return xAdd
  End Function

  Private Sub TxtGlosa_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGlosa.KeyDown
    If e.KeyCode = Keys.Enter Then

      If Not Validar_Distribucion() Then
        Exit Sub
      End If
      If Agregar_Item_Asiento() Then
        txtImporteD.Text = "0.00"
        cboCtaCte.Text = ""
        lblNombre_CtaCte.Text = ""
        lblRestriccion.Text = ""
        Call Calcular_Totales_Grid()

        cboCuenta.Focus()

      End If

    End If
  End Sub

  Private Sub dgvDetalle_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvDetalle.DoubleClickRow
    'If dgvDetalle.Rows.Count > 0 Then
    '  cboCuenta.Text = e.Row.Cells("cuenta").Value
    '  cboCtaCte.Text = e.Row.Cells("ctacte").Value
    '  cboCentro_Costo.Value = e.Row.Cells("centro_costo").Value
    '  txtImporteD.Text = e.Row.Cells("importe").Value
    '  TxtGlosa.Text = e.Row.Cells("glosa").Value
    '  vIDr = e.Row.Cells("id").Value
    'End If
  End Sub

  Private Sub dgvDetalle_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvDetalle.InitializeLayout
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

    With dgvDetalle.DisplayLayout.Bands(0)
      '.Columns(0).Width = 30
      '.Columns(0).Header.Caption = "FDO"
      .Columns("cuenta").Width = 70
      .Columns("ctacte").Width = 90
      .Columns("centro_costo").Width = 65
      .Columns("centro_costo").Header.Caption = "DPTO"
      .Columns("importe").Width = 70
      .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
      .Columns("importe").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("importe").CellAppearance.ForeColor = Color.Red
      .Columns("glosa").Width = 100
      .Columns("id").Hidden = True
    End With

    Appearance1.AlphaLevel = 90
    Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    Appearance1.BorderColor = Color.Black
    Appearance1.BorderAlpha = Alpha.Default

    Me.dgvDetalle.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    'Appearance1.BackColor = Color.White
    ''Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
    ''Appearance1.ImageBackground = Global.Cliente.My.Resources.Resources.kexibig     'foto_e_commerce_1
    Me.dgvDetalle.DisplayLayout.Appearance = Appearance1
    Me.dgvDetalle.DisplayLayout.Appearance.ForeColor = Color.RoyalBlue
    Me.dgvDetalle.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
    Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
  End Sub

  Private Sub dgvDetalle_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvDetalle.AfterCellUpdate

    Call Calcular_Totales_Grid()

  End Sub

  Private Sub dgvDetalle_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.AfterRowsDeleted
    Call Calcular_Totales_Grid()
  End Sub

  Private Sub cboTipo_ValueChanged(sender As Object, e As EventArgs) Handles cboTipo.ValueChanged
    Dim xValor As Single = 0
    If txtImporteD.Text = "" Then
      txtImporteD.Text = "0.00"
    Else
      If IsNumeric(txtImporteD.Text) Then
        xValor = txtImporteD.Text
        If cboTipo.Value = "C" Then
          txtImporteD.Text = "-" & txtImporteD.Text
        Else
          txtImporteD.Text = Math.Abs(xValor)
        End If
      Else
        txtImporteD.Text = "0.00"
      End If
    End If

  End Sub
End Class