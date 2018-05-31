Imports CapaLogicaNegocio.Bll

Public Class FrmProducto_Ubicacion
  Public pProductoID As Long, pProducto As String
  Public pAlmacenID As Integer, pAlmacen As String
  Public pUbicacion As String
  Private Sub FrmProducto_Ubicacion_Load(sender As Object, e As EventArgs) Handles Me.Load
    txtUbicacion.Text = ""
    txtUbicacionB.Text = ""
    LblProducto.Text = pProducto
    lblAlmacen.Text = pAlmacen
    txtUbicacion.Text = pUbicacion
  End Sub

  Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
    If pProductoID = 0 Or pAlmacenID = 0 Then
      MessageBox.Show("No hay código producto y/o almacén", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    'If txtUbicacion.Text.Trim = "" Then
    '  MessageBox.Show("Debe ingresar una ubicación", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '  Exit Sub
    'End If

    If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

      Try

        If productotempManager.Actualizar_Ubicacion(pProductoID, pAlmacenID, (txtUbicacion.Text.Trim), "") > 0 Then
          FrmCatalogo_Almacen.ListarCondicion()
          Me.Close()
        End If
        'MessageBox.Show(Objeto.idtipodocid)
      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If
  End Sub

  Private Sub FrmProducto_Ubicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub
End Class