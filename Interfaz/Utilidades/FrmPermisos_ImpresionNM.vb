Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports System.Drawing.Printing

Public Class FrmPermisos_ImpresionNM
    Public vcodigo As Long, ok, vCod_Doc, vCod_serie As Integer
    Public pEmpresaid As Integer, pAlmacenId As Integer, pAlmacen As String
    Public pUsuarioId As Long, pUsuario As String
    Public ModoVentanaFlotante As Boolean

    Private Sub Mostrar_Registro()
        Dim ObjL As New permisos_impresion
        ObjL = permisos_impresionManager.GetItem(vcodigo)
        If Not ObjL Is Nothing Then
            With ObjL
                LblCodigo.Text = .codigo
                vcodigo = .codigo
                pEmpresaid = .codigo_emp
                pAlmacenId = .codigo_alm
                lblAlmacen.Text = pAlmacen
                LblUsuario.Text = pUsuario
                pUsuarioId = .codigo_usu
                LblCod_Us.Text = .codigo_usu
                TxtEquipo.Text = .caja
                CboDocumento.Value = .codigo_doc
                vCod_Doc = .codigo_doc
                vCod_serie = .codigo_ser

                ChkImprimir.Checked = CBool(.impresion)
                TxtImpresora.Text = .impresora
                TxtFormato.Text = .formato
                txtSerie_TK.Text = .serie_TK
            End With
        End If
        ObjL = Nothing
    End Sub
    Public Function Agregar() As Boolean
        Dim Objeto As New permisos_impresion
        Try
            With Objeto
                .codigo = -1
                .codigo_alm = pAlmacenId
                .codigo_usu = Long.Parse(LblCod_Us.Text)
                .caja = TxtEquipo.Text.Trim
                .codigo_doc = CboDocumento.Value
                .codigo_emp = pEmpresaid
                .codigo_ser = CboSeries.Value
                .impresion = ChkImprimir.Checked
                .formato = TxtFormato.Text.Trim
                .impresora = TxtImpresora.Text.Trim
                .serie_TK = txtSerie_TK.Text.Trim & ""
                .copias = 1
            End With

            permisos_impresionManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Modificar() As Boolean
        Dim Objeto As New permisos_impresion
        Try
            With Objeto
                .codigo = vcodigo
                .codigo_alm = pAlmacenId
                .codigo_usu = Long.Parse(LblCod_Us.Text)
                .caja = TxtEquipo.Text.Trim
                .codigo_doc = CboDocumento.Value
                .codigo_emp = pEmpresaid
                .codigo_ser = CboSeries.Value
                .impresion = ChkImprimir.Checked
                .formato = TxtFormato.Text.Trim
                .impresora = TxtImpresora.Text.Trim
                .serie_TK = txtSerie_TK.Text.Trim & ""
                .copias = 1
            End With
            permisos_impresionManager.Grabar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub llenar_combos()

        With CboDocumento
            .DataSource = Nothing
            .DataSource = documentoManager.GetList("")
            .DataBind()
            .ValueMember = "documentoid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If vCod_Doc > 0 Then
                CboDocumento.Value = vCod_Doc
            End If
        End With




    End Sub

    Private Sub FrmPermisos_ImpresionNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
        If e.KeyChar = Chr(Keys.Escape) Then
            If Me.gbImpresoras.Visible = True Then
                gbImpresoras.Visible = False
            End If
        End If
    End Sub

    Private Sub FrmPermisos_ImpresionNM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LimpiarControles()
        Call llenar_combos()
        lblAlmacen.Text = pAlmacen
        lblEmpresa.Text = GestionSeguridadManager.gEmpresa
        pEmpresaid = GestionSeguridadManager.gEmpresaId
        If vcodigo > 0 Then
            Call Mostrar_Registro()
        End If
        If pEmpresaid > 0 And vCod_Doc > 0 Then
            Call Llenar_Series()
        End If


    End Sub

    Private Sub BtnCtrl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCtrl.Click
        Me.Close()
    End Sub

    Private Function Llenar_Series() As Boolean
        Dim xCod_Emp, xTipo_Doc As Integer
        xCod_Emp = pEmpresaid
        xTipo_Doc = vCod_Doc
       
        If Not CboDocumento.ActiveRow Is Nothing Then
            If Not CboDocumento.Text = "" Then
                xTipo_Doc = CboDocumento.Value
            End If
        End If
        With CboSeries
            .DataSource = Nothing
            .DataSource = serieManager.GetList(xCod_Emp, xTipo_Doc)
            .DataBind()
            .ValueMember = "serieid"
            .DisplayMember = "serie"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If vCod_serie > 0 Then
                CboSeries.Value = vCod_serie
            End If
        End With
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "D'SIAM", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try

                If Trim(Me.LblCodigo.Text) = "" Then
                    Call Agregar()
                Else
                    Call Modificar()
                End If
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function LimpiarControles() As Boolean
        Me.LblCodigo.Text = ""
        Me.CboSeries.Text = ""
        lblAlmacen.Text = ""
        Me.lblEmpresa.Text = ""
        Me.CboDocumento.Text = ""
        Me.TxtEquipo.Text = My.Computer.Name
        Me.ChkImprimir.Checked = False
        TxtFormato.Text = ""
        TxtImpresora.Text = ""
        txtSerie_TK.Text = ""
    End Function

    Private Sub CboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboDocumento.InitializeLayout
        With CboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = CboDocumento.Width
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
        End With
    End Sub

    Private Sub CboDocumento_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDocumento.Validated
        If CboDocumento.ActiveRow Is Nothing Then
            If Not CboDocumento.Text = "" Then
                CboSeries.DataSource = Nothing
                CboSeries.Text = ""
                CboDocumento.Focus()
            Else
                Call Llenar_Series()
            End If
        Else
            Call Llenar_Series()
        End If
    End Sub

    Private Sub btnBuscaUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaUs.Click
        Call ListadoClie()
        'Call EncontrarClie_x_idClie()
    End Sub

    Public Sub ListadoClie()
        Dim testDialog As New FrmConsulta_Personas()
        testDialog.Cod_Cat = 1
        LblCod_Us.Text = ""
        LblUsuario.Text = ""
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.LblCod_Us.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            LblUsuario.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("nombre_persona").Value)
        Else
            'TxtCodAsistente.Text = ""
        End If
        testDialog.Dispose()
    End Sub

    Private Function EncontrarClie_x_idClie() As Boolean
        Dim ObjPer As New persona
        Try
            If Not IsNumeric(LblCod_Us.Text) Then Exit Function
            ObjPer = personaManager.GetItem(CInt(LblCod_Us.Text))
            Me.LblUsuario.Text = ""
            If Not IsNothing(ObjPer) Then

                If ObjPer.tipo = "N" Then
                    LblUsuario.Text = CStr(ObjPer.ape_pat) + " " + CStr(ObjPer.ape_mat) + " " + CStr(ObjPer.nombre)
                Else
                    LblUsuario.Text = CStr(ObjPer.raz_soc)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub CboSeries_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboSeries.InitializeLayout
        With CboSeries.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
            .Columns("serie").Width = CboSeries.Width
            .Columns(6).Hidden = True
            .Columns(7).Hidden = True
        End With
    End Sub

    Private Sub btnPtinters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPtinters.Click
        Dim DtP As New DataTable
        Dim Df As New PrintDocument
        Dim Printer As String
        Dim x As Integer = PrinterSettings.InstalledPrinters.Count
        Dim opciones(x) As String
        Dim y As Integer = 0

        Dim sw_Df As String = Df.PrinterSettings.PrinterName

        For Each Printer In PrinterSettings.InstalledPrinters
            opciones(y) = Printer.ToString
            y += 1
        Next

        DtP = OpcionesManager.GetList(opciones)
        dgvListado.DataSource = DtP
        dgvListado.Refresh()
        gbImpresoras.Visible = True
    End Sub

    Private Sub UltraButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormato.Click
        With OpenFileDialog1
            .FileName = ""
            .Filter = "Crystal Reports |*.rpt"
            ' abre el diálogo para seleccionar archivo el del Reporte
            .ShowDialog()

            If .FileName <> "" Then
                Me.TxtFormato.Text = .FileName
            End If
        End With
    End Sub

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
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        Me.dgvListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]

        Appearance1.AlphaLevel = 98
        Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        ''Appearance1.BorderAlpha = Alpha.Opaque

        'Appearance1.BackColor = Color.White
        Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance1.ImageBackground = Global.Phoenix.My.Resources.Resources.fileprint        'foto_e_commerce_1
        Me.dgvListado.DisplayLayout.Appearance = Appearance1

        Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
        Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        '--------------------------
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Tahoma"
        Appearance62.FontData.SizeInPoints = 8.25!
        Appearance62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance62.ImageBackground = CType(Infragistics.Win.Resources.GetObject("Appearance55.ImageBackground"), System.Drawing.Image)
        Appearance62.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled
        Appearance62.TextHAlignAsString = "Left"
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62
        Me.dgvListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed

        '--------------------------
        ''Appearance62.BackColor = Color.RoyalBlue   'System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        ''Appearance62.BackColor2 = Color.LightCyan   'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        ''Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        ' ''Appearance62.FontData.BoldAsString = "True"
        ''Appearance62.FontData.Name = "Tahoma"
        ''Appearance62.FontData.SizeInPoints = 10.0!
        ''Appearance62.ForeColor = System.Drawing.Color.Blue
        ''Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        ''Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

        'Appearance63.BackColor = System.Drawing.Color.SteelBlue
        'Appearance63.BackColor2 = System.Drawing.Color.LightCyan
        'Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        'Appearance63.ThemedElementAlpha = Alpha.Opaque
        'Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default

        ''Appearance64.BackColor = System.Drawing.Color.White
        Appearance64.BackColor = System.Drawing.Color.LemonChiffon
        'Appearance64.BackColor2 = System.Drawing.Color.White
        'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical        
        Appearance64.FontData.BoldAsString = "True"
        Appearance64.ForeColor = Color.Navy
        'Appearance64.ForeColor = Color.White
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        'dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid

        ''Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        'para Seleccionar solo una Fila
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single
        'Para seleccionar toda la Fila
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        ''Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        dgvListado.DisplayLayout.Bands(0).Columns(0).Width = dgvListado.Width - 50
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.BackColor = Color.BlanchedAlmond

        ''dgvListado.DisplayLayout.Override.AllowAddNew = AllowAddNew.FixedAddRowOnBottom
        ''dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.BackColor = Color.BlanchedAlmond
        Call formatear_grid()
    End Sub

    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        e.Row.Cells(0).Appearance.Image = Global.Phoenix.My.Resources.Resources.printer
    End Sub

    Private Sub dgvListado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvListado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    Me.TxtImpresora.Text = Trim(dgvListado.ActiveRow.Cells(0).Text)
                End If
            End If
            gbImpresoras.Visible = False

        End If
    End Sub
End Class