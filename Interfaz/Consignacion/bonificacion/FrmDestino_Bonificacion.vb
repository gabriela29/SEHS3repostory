
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmDestino_Bonificacion

    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmDestino_Bonificacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmDestino_Bonificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call ListarCondicion("")
        Call LibreriasFormularios.formatear_grid(dgvListado)
    End Sub

    Public Function ListarCondicion(ByVal Descripcion As String) As Boolean
        Dim dtDB As New DataTable
        Try
            dtDB = destino_bonificacionManager.GetList(Descripcion)
            dgvListado.DataSource = dtDB
            'dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
                'dgvListado.Focus()
                'Call Listado_Subgrupo()
            End If
            lbl.Text = dgvListado.Rows.Count & " Registros Mostrados"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
        FrmDestino_BonificacionEdit.pCodigo = 0
        FrmDestino_BonificacionEdit.ShowDialog()

    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsDEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDEditar.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                FrmDestino_BonificacionEdit.pCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                FrmDestino_BonificacionEdit.ShowDialog()
                Call ListarCondicion("")
            End If

        End If
    End Sub

    Private Sub tsDDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDDelete.Click
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                If MessageBox.Show("Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim vCodigo As Integer
                    vCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                    If destino_bonificacionManager.Eliminar(vCodigo) Then
                        Call ListarCondicion("")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsDActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDActualizar.Click
        Call ListarCondicion("")
    End Sub
End Class