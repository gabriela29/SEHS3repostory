
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO


Public Class FrmBancoLis
    Public _codigo As Integer
    Public dtlistaBanco As DataTable
    Public dtlistacuentaCO As DataTable
    'Public ListadoRegistros As DataTable
    Public IdUsuario As Long
    Public swNuevoBanco As Boolean


    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

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

    Private Function Listado_CuentaCo() As Boolean
        Dim objetos As New DataTable
        Dim vIDBanco As Integer
        ContBancoLis.Enabled = False
        ContBancoLis.Enabled = False

        Try
            If dgvListadobanco.Rows.Count > 0 Then
                If dgvListadobanco.Selected.Rows.Count > 0 Then
                    vIDBanco = dgvListadobanco.DisplayLayout.ActiveRow.Cells(0).Value
                End If
            End If
            If vIDBanco > 0 Then
                dtlistacuentaCO = CuentaCoManager.GetList(vIDBanco, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListadobanco.BeforeSelectChange
        If dgvListadobanco.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                'codigo = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

            Else
                _codigo = 0
                '   dgvSubCat.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub dgvListadobanco_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvListadobanco.InitializeLayout
        With dgvListadobanco.DisplayLayout.Bands(0)
            .Columns(0).Width = 20
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "NOMBRE"
            .Columns(2).Header.Caption = "NOMBRE CORTO"
            .Columns(3).Header.Caption = "REFERENCIA"
            .Columns(3).Width = dgvListadobanco.Width - 80
            .Columns(4).Hidden = True
        End With

    End Sub

    Private Sub popupHelperD_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelperD.PopupClosed
        Dim frm As frmBanco = e.Popup
        Call ListarBanco("")

        frm = Nothing
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

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
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
                '  .ModoVentanaFlotante = True

                ' .pCodigo = dgvSubCat.DisplayLayout.ActiveRow.Cells(0).Value
                '.pCodigo_Cat = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value
            End With
            ' Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

            popupHelper.ShowPopup(Me, frm, location)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")

        End If




    End Sub
End Class