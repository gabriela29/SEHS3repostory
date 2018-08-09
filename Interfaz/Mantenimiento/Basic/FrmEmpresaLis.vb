

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO




Public Class FrmEmpresaLis
    Public _codigo As Integer
    Public dtlistaempresa As DataTable
    Public ListadoRegistros As DataTableClearEventArgs
    Public IdUsuario As Long
    Public swNuevoempresa As Boolean

    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmSeriesDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub FrmSeriesDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdUsuario = GestionSeguridadManager.idUsuario

        Call ListarEmpresa("")

    End Sub

    Public Function ListarEmpresa(ByVal Descripcion As String) As Boolean
        Dim objetos As New DataTable
        Try
            dtlistaempresa = empresaManager.GetList(Descripcion)
            dgvListadoempresa.DataSource = dtlistaempresa

            dgvListadoempresa.DataBind()
            If dgvListadoempresa.Rows.Count() > 0 Then
                dgvListadoempresa.Rows(0).Selected = True
                dgvListadoempresa.Focus()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ELiminar_Empresa() As Boolean
        Try
            If dgvListadoempresa.Rows.Count > 0 Then
                If dgvListadoempresa.Selected.Rows.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If empresaManager.Eliminar(dgvListadoempresa.DisplayLayout.ActiveRow.Cells(0).Value) Then
                            MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
                            Call ListarEmpresa("")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListadoempresa_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListadoempresa.BeforeSelectChange
        If dgvListadoempresa.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                'codigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

            Else
                _codigo = 0

            End If
        End If
    End Sub

    Private Sub dgvListadoempresa_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListadoempresa.InitializeLayout

        With dgvListadoempresa.DisplayLayout.Bands(0)
            .Columns(0).Width = 30
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "NOMBRE"
            .Columns(2).Header.Caption = "RUC"
            .Columns(3).Header.Caption = "DIRECCION"
            .Columns(4).Header.Caption = "URL"
            .Columns(1).Width = 245
            .Columns(3).Width = 400
            .Columns(4).Width = 180

        End With

        Call formatear_grid()
    End Sub

    Private Sub tpCerrar_Click(sender As Object, e As EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpNuevo_Click(sender As Object, e As EventArgs) Handles TpNuevo.Click
        'Dim xFrmEmpresa As New FrmEmpresaEdit
        'xFrmEmpresa.vEmpresaid = 0
        'xFrmEmpresa.ShowDialog()

        popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmEmpresaEdit = New FrmEmpresaEdit()

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
        Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc2.Left, Me.txtLocaltionDoc2.Bottom))

        popupHelperD.ShowPopup(Me, frm, locationD)

    End Sub

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
        If Not dgvListadoempresa.Rows.Count > 0 Then
            MsgBox("No hay Datos seleccionados que modificar", MsgBoxStyle.Information, "INFORMACIÓN")
            Exit Sub
        End If

        If dgvListadoempresa.Selected.Rows.Count > 0 Then
            popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmEmpresaEdit = New FrmEmpresaEdit()
            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .vcodigo = CInt(dgvListadoempresa.DisplayLayout.ActiveRow.Cells(0).Value)

            End With
            Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc2.Left, txtLocaltionDoc2.Bottom))

            popupHelperD.ShowPopup(Me, frm, locationD)

        Else
            MsgBox("   Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub popupHelperD_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelperD.PopupClosed
        Dim frm As FrmEmpresaEdit = e.Popup
        Call ListarEmpresa("")
        frm = Nothing
    End Sub

    Private Sub TpEliminar_Click(sender As Object, e As EventArgs) Handles TpEliminar.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funcionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvListadoempresa.Selected.Rows.Count > 0 Then
                Call ELiminar_Empresa()
            End If
        End If
    End Sub

    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        Me.dgvListadoempresa.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListadoempresa.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListadoempresa.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListadoempresa.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListadoempresa.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListadoempresa.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.White
        Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListadoempresa.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Me.dgvListadoempresa.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Me.dgvListadoempresa.DisplayLayout.Override.SelectedRowAppearance = Appearance64
        Me.dgvListadoempresa.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListadoempresa.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListadoempresa.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'para Seleccionar solo una Fila
        Me.dgvListadoempresa.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        'Para seleccionar toda la Fila
        Me.dgvListadoempresa.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        Me.dgvListadoempresa.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus


    End Sub


End Class