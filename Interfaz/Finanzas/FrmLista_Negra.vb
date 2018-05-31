Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmLista_Negra
  Public pUsuarioId As Long, pAlmacenId As Integer, pSuscritoID As Long, pSuscrito As String
  Public pVentana As String
  Private Sub FrmLista_Negra_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub FrmLista_Negra_Load(sender As Object, e As EventArgs) Handles Me.Load
    lblSuscrito.Text = pSuscrito
    LblCodigo.Text = pSuscritoID
    Call LibreriasFormularios.formatear_grid(dgvListado)
  End Sub


  Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub tsMostrar_Click(sender As Object, e As EventArgs) Handles tsMostrar.Click
    Call Mostrar()
  End Sub
  Private Sub Mostrar()
    dgvListado.DataSource = lista_negraManager.GetList("", "", "")
    LblRegistros.Text = dgvListado.Rows.Count
  End Sub

  Private Sub tsEliminar_Click(sender As Object, e As EventArgs) Handles tsEliminar.Click
    If dgvListado.Rows.Count > 0 Then
      Dim xLote As String = ""
      If dgvListado.Selected.Rows.Count > 0 Then

        If lista_negraManager.Eliminar(dgvListado.DisplayLayout.ActiveRow.Cells("personaid").Value) Then
          Call Mostrar()
        End If
      End If
    End If
  End Sub
End Class