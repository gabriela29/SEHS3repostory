Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmProductos_CampaniaNM
  Public pNew As Boolean, pCodigo As Long, pProductoID As Long, pProducto As String, pPrecio As Single, pCampaniaId As Integer

  Private Sub Mostrar_Registro()
    Dim ojPC As New productos_campania
    ojPC = productos_campaniaManager.GetItem(pCodigo)
    If Not ojPC Is Nothing Then
      With ojPC
        pCodigo = .productoscampaniaid

        pProductoID = .productoid
        txtProducto.Text = .Producto
        txtPrecioS.Text = .precio
        chkAfecto_IGV.Checked = .afecto_igv
        ChkAfecto_Dzmo.Checked = .afecto_dzmo
        txtProducto.ReadOnly = True
        txtAbreviatura.Text = .Abreviatura
      End With
    End If

    ojPC = Nothing
  End Sub

  Private Sub txtProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProducto.KeyDown
    If txtProducto.Text.Trim = "" Then
      If e.KeyCode = Keys.Enter Then
        Dim testDialog As New FrmConsulta_Productos

        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
          Me.pProductoID = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
          Me.txtProducto.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
        Else
          txtProducto.Text = ""
          pProductoID = 0
        End If
        testDialog.Dispose()
        txtPrecioS.Focus()
      End If
    End If
  End Sub

  Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
    pNew = True
    If Not pProductoID > 0 Or txtProducto.Text.Trim = "" Then
      MessageBox.Show("Debe seleccionar un Producto", "Aviso", MessageBoxButtons.OK)
      Exit Sub
    End If

    If Not IsNumeric(txtPrecioS.Text) Then
      MessageBox.Show("Debe un precio", "Aviso", MessageBoxButtons.OK)
      Exit Sub
    End If
    If pCodigo > 0 Then
      pNew = False
    End If
    Dim ojbPC As New productos_campania
    With ojbPC
      .productoscampaniaid = pCodigo
      .campaniaid = pCampaniaId
      .productoid = pProductoID
      .Abreviatura = txtAbreviatura.Text
      .precio = txtPrecioS.Text
      .afecto_igv = chkAfecto_IGV.Checked
      .afecto_dzmo = ChkAfecto_Dzmo.Checked
      .afecto_plus_esc = False
      .usuarioid = GestionSeguridadManager.idUsuario
      .caja = My.Computer.Name
    End With
    If productos_campaniaManager.Grabar(pCodigo, pNew, ojbPC) Then
      Call FrmProductos_Campania.Actualizar()
      Me.Close()
    End If
  End Sub

  Private Sub FrmProductos_CampaniaNM_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
    End If
  End Sub

  Private Sub FrmProductos_CampaniaNM_Load(sender As Object, e As EventArgs) Handles Me.Load
    txtProducto.ReadOnly = False
    If pCodigo > 0 Then
      Call Mostrar_Registro()
    End If
  End Sub
End Class