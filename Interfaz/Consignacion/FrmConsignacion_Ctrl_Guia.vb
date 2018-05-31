

Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports System.IO

Public Class FrmConsignacion_Ctrl_Guia
    Public _codigo As Long
    Public ListadoDoc As DataTable

    Private Sub formatear_grid()
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
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
            With cboUnidad_Negocio
                .DataSource = Nothing
                .DataSource = permisos_moduloManager.Leer_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modVentas)
                .DataBind()
                .ValueMember = "codigo"
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

    Private Sub bwAlmacen_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAlmacen.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Unidad As Integer
        Dim st As New DataTable

        Try
            vCodigo_Unidad = 0
            If Not Trim(cboUnidad_Negocio.Text) = "" Then
                vCodigo_Unidad = CInt(cboUnidad_Negocio.Value)
            End If

            st = permisos_moduloManager.Leer_Almacenes_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modColportaje, vCodigo_Unidad)

            e.Result = st

        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwAlmacen_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAlmacen.RunWorkerCompleted
        'If sender = bwPrecarga Then
        If e.Result Is Nothing Then
            cboAlmacen.DataSource = Nothing
        Else
            With Me.cboAlmacen
                .DataSource = CType(e.Result, DataTable)
                '.DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With
        End If

        picAjax.Visible = False

    End Sub

    Private Sub cboUnidad_Negocio_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnidad_Negocio.InitializeLayout
        With cboUnidad_Negocio.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboUnidad_Negocio.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboUnidad_Negocio_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.Validated
        'If Not bwAlmacen.IsBusy Then
        '    cboAlmacen.Text = [String].Empty
        '    picAjax.Visible = True
        '    bwAlmacen.RunWorkerAsync()
        'End If
    End Sub

    Private Sub cboUnidad_Negocio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad_Negocio.ValueChanged
        cboAlmacen.DataSource = Nothing
        gpCriterios.Enabled = True
        dgvResumen.DataSource = Nothing
        dgvListado.DataSource = Nothing
        Call Totales_Cero()
        If Not bwAlmacen.IsBusy Then
            cboAlmacen.Text = [String].Empty
            picAjax.Visible = True
            bwAlmacen.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
        If cboAlmacen.ActiveRow Is Nothing Then
            If Not cboAlmacen.Text = "" Then
                cboAlmacen.Focus()
            End If
        End If
    End Sub


    Private Sub FrmConsignacion_Ctrl_Guia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        Call formatear_grid()
        Call Totales_Cero()
    End Sub

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        Dim DtRes As New DataTable
        Dim xCod_uni, xCod_Alm As Integer ', vHasta As String

        If Not Trim(cboUnidad_Negocio.Text) = "" Then
            xCod_uni = CInt(cboUnidad_Negocio.Value)
        End If
        If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
        End If

        'vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

        DtRes = consignacionManager.Leer_Consignacion_xGuia_Res(xCod_uni, xCod_Alm, 0, "", "")
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
                vTotal = vTotal + CSng(Drs("stock").ToString)
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

        If Not Trim(cboUnidad_Negocio.Text) = "" Then
            xCod_uni = CInt(cboUnidad_Negocio.Value)
        End If
        If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
        End If
        vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

        ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
        ' create and bind sample DataSet
        DtColp = consignacionManager.Leer_Consignacion_xGuia_Leer(xCod_uni, xCod_Alm, _codigo, "", "")

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
                vDeuda = vDeuda + CSng(Drs("saldo").ToString)
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
            .Columns(1).Header.Caption = "Asistente"
            .Columns(1).Width = 220

            .Columns(2).Width = 80
            '.Columns(2).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(2).CellAppearance.TextHAlign = HAlign.Right

            .Columns(3).Width = 80
            '.Columns(3).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(3).CellAppearance.TextHAlign = HAlign.Right

            .Columns(4).Width = 80
            '.Columns(4).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(4).CellAppearance.TextHAlign = HAlign.Right

            .Columns(5).Width = 80
            .Columns(5).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(5).CellAppearance.TextHAlign = HAlign.Right
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

            .Columns(1).Width = 80
            .Columns(2).Hidden = True

            .Columns(3).Width = 110

            .Columns(4).Width = 50
            .Columns(4).CellAppearance.TextHAlign = HAlign.Right

            .Columns(5).Width = 50
            .Columns(5).CellAppearance.TextHAlign = HAlign.Right

            .Columns(6).Width = 50
            .Columns(6).CellAppearance.TextHAlign = HAlign.Right

            .Columns(7).Width = 50
            .Columns(7).Header.Caption = "Stock"
            .Columns(7).CellAppearance.BackColor = Color.LemonChiffon
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

    Private Sub tsActualziar_Detalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualziar_Detalle.Click
        If _codigo > 0 Then
            Call Mostrar_Detalles()
        End If
    End Sub

End Class