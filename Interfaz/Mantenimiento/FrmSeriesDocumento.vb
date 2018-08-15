
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmSeriesDocumento
    Public _codigo As Integer
    Public ListadoRegistros As DataTable
    Public ListadoSeries As DataTable
    Public IdUsuario, Cod_Emp As Integer

    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmSeriesDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub



    Private Sub FrmSeriesDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdUsuario = GestionSeguridadManager.idUsuario

        Call ListarCondicion("")

    End Sub

    Public Function ListarCondicion(ByVal Descripcion As String) As Boolean
        Dim objetos As New DataTable
        Try
            ListadoRegistros = documentoManager.GetList(Descripcion)
            dgvListado.DataSource = ListadoRegistros
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function Listado_Condicion_series(ByVal cod_Doc As Integer) As Boolean
        Dim objetos As New DataTable
        Try
            Cod_Emp = 0
            If Not cboEmpresa.Text = "" Then
                Cod_Emp = cboEmpresa.Value
            End If
            If cod_Doc > 0 And Cod_Emp > 0 Then
                ListadoSeries = serieManager.GetList(Cod_Emp, cod_Doc)
                dgvSeries.DataSource = ListadoSeries
                dgvSeries.DataBind()
                If dgvSeries.Rows.Count() > 0 Then

                End If
            Else
                dgvSeries.DataSource = Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvseries_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListado.AfterRowsDeleted
        Call Eliminar_Doc(CInt(_codigo))
        Call ListarCondicion("")
    End Sub

    Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
        Call ListarCondicion("")
    End Sub

    Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
        _codigo = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
    End Sub


    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.White
        Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64
        Me.dgvListado.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'para Seleccionar solo una Fila
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        'Para seleccionar toda la Fila
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    End Sub

    Public Function Eliminar(ByVal _id As Integer) As Boolean
        Dim Objeto As New serie
        Try
            Objeto.codigo = _id
            serieManager.Eliminar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Eliminar_Doc(ByVal _id As Integer) As Boolean
        Dim Objeto As New documento
        Try
            Objeto.codigo = _id
            documentoManager.Eliminar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                _codigo = CInt((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call Listado_Condicion_series(_codigo)
            Else
                _codigo = 0
                dgvSeries.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).ColumnChooserCaption = "Documento"
            .Columns(1).Width = 250
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
        End With

        Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvSeries.Selected.Rows.Count > 0 Then
                Call Eliminar(CInt(dgvSeries.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondicion("")
            End If
        End If
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click

        popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmSeriesDocumentoNM = New FrmSeriesDocumentoNM()
        Call frm.LimpiarControles()
        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = False
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
        End With
        Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

        popupHelper.ShowPopup(Me, frm, location)

    End Sub

    Private Sub popupHelper_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelper.PopupClosed
        Dim frm As FrmSeriesDocumentoNM = e.Popup
        Call Listado_Condicion_series(_codigo)

        frm = Nothing
    End Sub

    Private Sub TpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpModificar.Click
        Call FrmSeriesDocumentoNM.LimpiarControles()
        If Not dgvSeries.Rows.Count > 0 Then
            MsgBox("No hay Datos que modificar", MsgBoxStyle.Information, "DSIAM")
            Exit Sub
        End If

        If Not _codigo = 0 And dgvSeries.Selected.Rows.Count > 0 Then
            popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmSeriesDocumentoNM = New FrmSeriesDocumentoNM()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .LblCodigo.Text = CInt(dgvSeries.DisplayLayout.ActiveRow.Cells(0).Value)
                .id_almacen = CInt(dgvSeries.DisplayLayout.ActiveRow.Cells(1).Value)
                .id_tipoDoc = CInt(dgvSeries.DisplayLayout.ActiveRow.Cells(3).Value)
                .txtSerie.Text = Trim(dgvSeries.DisplayLayout.ActiveRow.Cells(5).Value)
                .txtNroDoc.Text = Trim(dgvSeries.DisplayLayout.ActiveRow.Cells(6).Value)
                .ChkEstado.Checked = CBool(dgvSeries.DisplayLayout.ActiveRow.Cells(7).Value)
            End With
            Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

            popupHelper.ShowPopup(Me, frm, location)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub dgvSeries_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvSeries.InitializeLayout
        With dgvSeries.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
            .Columns(5).Width = 60
            .Columns(6).CellAppearance.TextHAlign = HAlign.Right
        End With
        Me.dgvSeries.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvSeries.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboEmpresa.InitializeLayout
        With cboEmpresa.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 260
            .Columns(2).Width = 160
            '.Columns(3).Hidden = True
            '.Columns(4).Hidden = True
            '.Columns(5).Hidden = True
        End With

    End Sub

    Private Sub cboEmpresa_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpresa.ValueChanged
        _codigo = 0
        If dgvListado.Selected.Rows.Count > 0 Then
            _codigo = CInt((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        End If
        Call Listado_Condicion_series(_codigo)
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click

        popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmsDocumentoNM = New FrmsDocumentoNM()
        Call frm.LimpiarControles()
        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = False
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
        End With
        Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc.Left, Me.txtLocaltionDoc.Bottom))

        popupHelperD.ShowPopup(Me, frm, locationD)

    End Sub

    Private Sub tsDEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDEditar.Click
        Call FrmsDocumentoNM.LimpiarControles()
        If Not dgvListado.Rows.Count > 0 Then
            MsgBox("No hay Documentos Seleccioandos que modificar", MsgBoxStyle.Information, "INFORMACIÓN")
            Exit Sub
        End If

        If Not _codigo = 0 And dgvListado.Selected.Rows.Count > 0 Then
            popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmsDocumentoNM = New FrmsDocumentoNM()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .LblCodigo.Text = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
                .TxtNombre.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
                .cboSigno.Value = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(2).Value)
                .id_tipoDoc = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
                .txtAbrev.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(3).Value)
                .txtCod_Conta.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)

            End With
            Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc.Left, txtLocaltionDoc.Bottom))

            popupHelperD.ShowPopup(Me, frm, locationD)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Call Eliminar_Doc(CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondicion("")
            End If
        End If
    End Sub
End Class