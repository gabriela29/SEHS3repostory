Imports CapaLogicaNegocio.Bll

Public Class FrmProducto_Precio
  Public pProductoID As Long, pProducto As String
  Public pAlmacenID As Integer, pAlmacen As String
  Public pPrecio As Single, pPrecioB As Single

  Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub FrmProducto_Precio_Load(sender As Object, e As EventArgs) Handles Me.Load
    txtPrecio.Text = "0.00"
    txtPrecioB.Text = "0.00"
    LblProducto.Text = pProducto
    lblAlmacen.Text = pAlmacen
    txtPrecio.Text = pPrecio
    txtPrecioB.Text = pPrecioB
  End Sub

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
    If pProductoID = 0 Or pAlmacenID = 0 Then
      MessageBox.Show("No hay código producto y/o almacén", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    If Not IsNumeric(txtPrecio.Text) Then
      MessageBox.Show("Debe ingresar un dato numérico", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If
    If Not IsNumeric(txtPrecioB.Text) Then
      MessageBox.Show("Debe ingresar un dato numérico", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

      Try

        If productotempManager.Actualizar_Precio_Almacen(pProductoID, pAlmacenID, Single.Parse(txtPrecio.Text), Single.Parse(txtPrecioB.Text)) > 0 Then
          FrmCatalogo_Almacen.ListarCondicion()
          Me.Close()
        End If
        'MessageBox.Show(Objeto.idtipodocid)
      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If
  End Sub

  Private Sub FrmProducto_Precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub
End Class