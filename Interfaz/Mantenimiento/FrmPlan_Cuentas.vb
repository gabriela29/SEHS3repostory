
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO


Public Class FrmPlan_Cuentas
    Public _codigo As Integer
    Public ListadoDoc As DataTable
    Public IdUsuario, Cod_Emp As Integer

    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmPlan_Cuentas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmPlan_Cuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdUsuario = GestionSeguridadManager.idUsuario

        Call ListarCondicion()

    End Sub

    Public Function ListarCondicion() As Boolean
        Dim objetos As New DataTable
        Try

            If ChkCta.Checked = True Then
                ListadoDoc = plan_cuentasManager.GetList(Trim(txtBuscar.Text), "", CInt(Me.txtLimite.Text))
            Else
                ListadoDoc = plan_cuentasManager.GetList("", Trim(txtBuscar.Text), CInt(Me.txtLimite.Text))
            End If

            dgvListado.DataSource = ListadoDoc
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
        Call ListarCondicion()
    End Sub

    Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
        _codigo = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
    End Sub

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                _codigo = CInt((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
            End If
        End If
    End Sub

    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance


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
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti

        Appearance58.BorderColor = System.Drawing.Color.Transparent
        Appearance58.ForeColor = System.Drawing.Color.Navy
        Me.dgvListado.DisplayLayout.Override.SelectedCellAppearance = Appearance58


        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Me.dgvListado.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListado.Font = New System.Drawing.Font("MS Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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

    Public Function Eliminar_Doc(ByVal _id As Integer) As Boolean
        Dim Objeto As New plan_cuentas
        Try
            Objeto.codigo = _id
            plan_cuentasManager.Eliminar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout

        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True            
            .Columns(1).Width = 80
            .Columns(2).Width = 70
            .Columns(2).CellAppearance.TextHAlign = HAlign.Right
            .Columns(3).Width = 40
            .Columns(4).Width = 360
            .Columns(5).Width = 200
            .Columns(6).Width = 20
            .Columns(6).CellAppearance.TextHAlign = HAlign.Right
        End With

        Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub popupHelper_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelper.PopupClosed
        Dim frm As FrmPlan_cuentasNM = e.Popup
        Call ListarCondicion()

        frm = Nothing
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click

        popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmPlan_cuentasNM = New FrmPlan_cuentasNM()
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

        popupHelper.ShowPopup(Me, frm, locationD)

    End Sub

    Private Sub tsDEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDEditar.Click
        Call FrmPlan_cuentasNM.LimpiarControles()
        If Not dgvListado.Rows.Count > 0 Then
            MsgBox("No hay Documentos Seleccioandos que modificar", MsgBoxStyle.Information, "INFORMACIÓN")
            Exit Sub
        End If

        If Not _codigo = 0 And dgvListado.Selected.Rows.Count > 0 Then
            popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmPlan_cuentasNM = New FrmPlan_cuentasNM()

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
                .TxtContable.Text = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
                .TxtCtaCte.Text = IIf(IsDBNull(dgvListado.DisplayLayout.ActiveRow.Cells(2).Value), 0, (dgvListado.DisplayLayout.ActiveRow.Cells(2).Value))
                .TxtSct.Text = IIf(IsDBNull((dgvListado.DisplayLayout.ActiveRow.Cells(3).Value)), "", (dgvListado.DisplayLayout.ActiveRow.Cells(3).Value))
                .TxtNombre.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)
                .TxtCtaMaestra.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(5).Value)
                .TxtNivel.Text = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(6).Value)
                .txtAbrev.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(7).Value)
                .txtOpcional.Text = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(9).Value)
            End With
            Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc.Left, txtLocaltionDoc.Bottom))

            popupHelper.ShowPopup(Me, frm, locationD)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Call Eliminar_Doc(CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call ListarCondicion()
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Call ListarCondicion()
    End Sub


    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        If e.Row.Cells("nivel").Value = 1 Then
            e.Row.Appearance.FontData.Bold = DefaultableBoolean.True
            e.Row.Appearance.ForeColor = Color.Red
        ElseIf e.Row.Cells("nivel").Value < 5 Then
            e.Row.Appearance.FontData.Bold = DefaultableBoolean.True
        ElseIf e.Row.Cells("nivel").Value = 5 Then
            e.Row.Appearance.FontData.Bold = DefaultableBoolean.True
            e.Row.Appearance.ForeColor = Color.SteelBlue
        End If
    End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
    '    'Me.ExcelExport.Export(dgvListado, "C:\Plan_Cuenta.xls")
    '    'Process.Start("C:\Plan_Cuenta.xls")
    'End Sub

    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '    Me.UltraPrintPreviewDialog1.Show()
    'End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub
End Class