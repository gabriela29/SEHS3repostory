
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmCategorias_Sub
    Public _codigo As Integer
    Public dtCategoria As DataTable
    Public dtSubCat As DataTable
    Public IdUsuario As Long
    Public swNuevo As Boolean

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
            dtCategoria = categoriaManager.GetList(Descripcion)
            dgvListado.DataSource = dtCategoria
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                dgvListado.Rows(0).Selected = True
                dgvListado.Focus()
                Call Listado_SubCategoria()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function Listado_SubCategoria() As Boolean
        Dim objetos As New DataTable
        Dim vIdCat As Integer 
        ContCat.Enabled = False
        ContSub.Enabled = False
        Try
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    vIdCat = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

                End If
            End If

            If vIdCat > 0 Then

                dtSubCat = subcategoriaManager.GetList(vIdCat, "")
                dgvSubCat.DataSource = dtSubCat
                'dgvSubCat.DataBind()
                If dgvSubCat.Rows.Count() > 0 Then

                End If
            Else
                dgvSubCat.DataSource = Nothing
            End If
            ContCat.Enabled = True
            ContSub.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Eliminar_Categoria() As Boolean

        Try
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If categoriaManager.Eliminar(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value) Then
                            MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
                            Call ListarCondicion("")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Eliminar_SubCat() As Boolean

        Try
            If dgvSubCat.Rows.Count > 0 Then
                If dgvSubCat.Selected.Rows.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If subcategoriaManager.Eliminar(dgvSubCat.DisplayLayout.ActiveRow.Cells(0).Value) Then
                            MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
                            Call Listado_SubCategoria()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                '_codigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
                Call Listado_SubCategoria()
            Else
                _codigo = 0
                dgvSubCat.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "CATEGORÍAS"
            .Columns(1).Width = dgvListado.Width - 80
            .Columns(2).Hidden = True
        End With

        Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvSubCat.Selected.Rows.Count > 0 Then
                Call Eliminar_SubCat()
                Call Listado_SubCategoria()
            End If
        End If
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

                Dim frm As FrmSubCategoriaNM = New FrmSubCategoriaNM()

                With frm
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ControlBox = False
                    .ShowInTaskbar = False
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    .TopMost = True
                    .Text = ""
                    .ModoVentanaFlotante = True
                    .pCodigo = 0
                    .pCodigo_Cat = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
                End With
                Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

                popupHelper.ShowPopup(Me, frm, location)
            End If
        End If

    End Sub

    Private Sub popupHelper_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelper.PopupClosed
        Dim frm As FrmSubCategoriaNM = e.Popup
        Call Listado_SubCategoria()

        frm = Nothing
    End Sub

    Private Sub TpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpModificar.Click

        If Not dgvSubCat.Rows.Count > 0 Then
            MsgBox("No hay Datos que modificar", MsgBoxStyle.Information, "AVISO")
            Exit Sub
        End If

        If dgvSubCat.Selected.Rows.Count > 0 Then
            popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmSubCategoriaNM = New FrmSubCategoriaNM()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .pCodigo = dgvSubCat.DisplayLayout.ActiveRow.Cells(0).Value
                .pCodigo_Cat = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

            End With
            Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

            popupHelper.ShowPopup(Me, frm, location)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub dgvSubCat_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvSubCat.InitializeLayout
        With dgvSubCat.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "SUB CATEGORÍAS"
            .Columns(1).Width = 220
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
        End With
        Me.dgvSubCat.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvSubCat.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click

        popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmCategoriaNM = New FrmCategoriaNM()

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

        If Not dgvListado.Rows.Count > 0 Then
            MsgBox("No hay Documentos Seleccioandos que modificar", MsgBoxStyle.Information, "INFORMACIÓN")
            Exit Sub
        End If

        If Not _codigo = 0 And dgvListado.Selected.Rows.Count > 0 Then
            popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmCategoriaNM = New FrmCategoriaNM()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .pCodigo = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)


            End With
            Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc.Left, txtLocaltionDoc.Bottom))

            popupHelperD.ShowPopup(Me, frm, locationD)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub popupHelperD_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelperD.PopupClosed
        Dim frm As FrmCategoriaNM = e.Popup
        Call ListarCondicion("")

        frm = Nothing
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Call Eliminar_Categoria()
            End If
        End If
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

    
End Class