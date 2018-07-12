
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO


Public Class FrmBancoLis
    Public _codigo As Integer
    Public dtlistaBanco As DataTable
    Public dtlistacuentaCO As DataTable
    Public IdUsuario As Long
    Public swNuevoBanco As Boolean


    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmSeriesDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub FrmSeriesDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdUsuario = GestionSeguridadManager.idUsuario

        Call ListarBanco("")

    End Sub

    Public Function ListarBanco(ByVal Descripcion As String) As Boolean
        Dim objetos As New DataTable
        Try
            dtlistaBanco = bancoManager.GetList(Descripcion)
            dgvListadobanco.DataSource = dtlistaBanco
            dgvListadobanco.DataBind()
            If dgvListadobanco.Rows.Count() > 0 Then
                dgvListadobanco.Rows(0).Selected = True
                dgvListadobanco.Focus()
                Call Listado_CuentaCo()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Function Listado_CuentaCo() As Boolean
        Dim objetos As New DataTable
        Dim vIDBanco As Integer
        ContBancoLis.Enabled = False
        ContCuentaCo.Enabled = False

        Try
            If dgvListadobanco.Rows.Count > 0 Then
                If dgvListadobanco.Selected.Rows.Count > 0 Then
                    vIDBanco = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value
                End If
            End If
            If vIDBanco > 0 Then
                dtlistacuentaCO = CuentaCoManager.GetList(vIDBanco, "")
                dgvCuentaCo.DataSource = dtlistacuentaCO

                If dgvCuentaCo.Rows.Count() > 0 Then

                End If
            Else
                dgvCuentaCo.DataSource = Nothing

            End If
            ContBancoLis.Enabled = True
            ContCuentaCo.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ELiminar_Banco() As Boolean
        Try
            If dgvListadobanco.Rows.Count > 0 Then
                If dgvListadobanco.Selected.Rows.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If categoriaManager.Eliminar(dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value) Then
                            MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
                            Call ListarBanco("")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Eliminar_CtaCte() As Boolean

        Try
            If dgvCuentaCo.Rows.Count > 0 Then
                If dgvCuentaCo.Selected.Rows.Count > 0 Then
                    If MessageBox.Show("¿Está seguro de eliminar Registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        If subcategoriaManager.Eliminar(dgvCuentaCo.DisplayLayout.ActiveRow.Cells(0).Value) Then
                            MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
                            Call Listado_CuentaCo()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub dgvListadobanco_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListadobanco.BeforeSelectChange
        If dgvListadobanco.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                'codigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
                Call Listado_CuentaCo()
            Else
                _codigo = 0
                dgvCuentaCo.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub dgvListadobanco_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListadobanco.InitializeLayout
        With dgvListadobanco.DisplayLayout.Bands(0)
            .Columns(0).Width = 35
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "NOMBRE"
            ' .Columns(2).Header.Caption = "NOMBRE CORTO"
            ' .Columns(3).Header.Caption = "REFERENCIA"
            .Columns(1).Width = dgvListadobanco.Width - 80
            .Columns(2).Hidden = True
        End With

        Call formatear_grid()
    End Sub

    Private Sub TpEliminarCC_Click(sender As Object, e As EventArgs) Handles TpEliminarCC.Click
        If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then
            If dgvCuentaCo.Selected.Rows.Count > 0 Then
                Call Eliminar_CtaCte()
                Call Listado_CuentaCo()
            End If
        End If
    End Sub

    Private Sub TpNuevoCC_Click(sender As Object, e As EventArgs) Handles TpNuevoCC.Click
        If dgvListadobanco.Rows.Count > 0 Then
            If dgvListadobanco.Selected.Rows.Count > 0 Then
                popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

                Dim frm As FrmCuentaCo = New FrmCuentaCo()
                With frm
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ControlBox = False
                    .ShowInTaskbar = False
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    .TopMost = True
                    .Text = ""
                    .ModoVentanaFlotante = True
                    .VCodigo = 0
                    .pCodigo_banco = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value
                End With
                'Dim location As Point = Me.PointToScreen(New Point(Me..Left, btnLocation.Bottom))

                popupHelper.ShowPopup(Me, frm, Location)
            End If
        End If
    End Sub

    Private Sub popupHelperD_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelperD.PopupClosed
        Dim frm As FrmCuentaCo = e.Popup
        Call Listado_CuentaCo()
        frm = Nothing
    End Sub

    Private Sub TpModificarCC_Click(sender As Object, e As EventArgs) Handles TpModificarCC.Click
        If Not dgvCuentaCo.Rows.Count > 0 Then
            MsgBox("No hay Datos que modificar", MsgBoxStyle.Information, "AVISO")
            Exit Sub

        End If

        If dgvCuentaCo.Selected.Rows.Count > 0 Then
            popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmCuentaCo = New FrmCuentaCo()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True

                .VCodigo = dgvCuentaCo.DisplayLayout.ActiveRow.Cells(0).Value
                .pCodigo_banco = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value

            End With
            ' Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

            popupHelper.ShowPopup(Me, frm, Location)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")

        End If
    End Sub


    Private Sub tsCerrar_Click(sender As Object, e As EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDNuevo_Click(sender As Object, e As EventArgs) Handles tsDNuevo.Click
        Dim xFrmBanco As New frmBanco
        xFrmBanco.vBancoid = 0
        xFrmBanco.ShowDialog()
    End Sub

    Private Sub tsDEditar_Click(sender As Object, e As EventArgs) Handles tsDEditar.Click
        If dgvListadobanco.Rows.Count > 0 Then
            Dim xbancoid As Long = 0
            If dgvListadobanco.Selected.Rows.Count > 0 Then
                xbancoid = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value
                Dim xFrmPer As New frmBanco
                'xFrmPer.vPersonaId = xbancoid
                xFrmPer.ShowDialog()
            End If
        End If
    End Sub



    Private Sub tsDDelete_Click(sender As Object, e As EventArgs) Handles tsDDelete.Click
        If dgvListadobanco.Selected.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Call ListarBanco("")

            End If
        End If
    End Sub




    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        Me.dgvListadobanco.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListadobanco.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListadobanco.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListadobanco.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListadobanco.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListadobanco.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.White
        Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListadobanco.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Me.dgvListadobanco.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Me.dgvListadobanco.DisplayLayout.Override.SelectedRowAppearance = Appearance64
        Me.dgvListadobanco.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListadobanco.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListadobanco.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'para Seleccionar solo una Fila
        Me.dgvListadobanco.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        'Para seleccionar toda la Fila
        Me.dgvListadobanco.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        Me.dgvListadobanco.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus


    End Sub


End Class