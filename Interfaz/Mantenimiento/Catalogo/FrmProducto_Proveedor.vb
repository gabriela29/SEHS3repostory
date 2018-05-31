
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmProducto_Proveedor

    Public pProductoID As Long, pProducto As String


    Public Sub ListadoTrans()
        Dim testDialog As New FrmConsulta_Personas()
        'testDialog.Cod_Cat = 4
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.txtRUCDNI.Tag = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("personaid").Value)
            lblCodigo_Prov.Text = Long.Parse(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("personaid").Value)
            Me.txtRUCDNI.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("ruc").Value)
            Me.lblProveedor.Text = testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("nombre_persona").Value
            Me.lblDireccion.Text = testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("direccion").Value
        End If
        testDialog.Dispose()
    End Sub

    Private Sub ObtenerDatos()
        Dim ObjPe As New persona
        Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

        ObjPe = personaManager.Datos_Persona_Basic("J", txtRUCDNI.Text.Trim, 0)
        If Not ObjPe Is Nothing Then
            lblCodigo_Prov.Text = Long.Parse(ObjPe.personaid)
            vApe_Pat = ObjPe.ape_pat
            vApe_Mat = ObjPe.ape_mat
            vNombre = ObjPe.nombre
            lblProveedor.Text = vApe_Pat & " " & vApe_Mat & ", " & vNombre
            lblDireccion.Text = ObjPe.direccion
        Else
            lblCodigo_Prov.Text = ""
            lblProveedor.Text = ""
            lblDireccion.Text = ""
            txtRUCDNI.Focus()
        End If
    End Sub

    Private Sub txtRUCDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUCDNI.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblCodigo_Prov.Text = ""
            lblProveedor.Text = ""
            lblDireccion.Text = ""
            If Trim(txtRUCDNI.Text) = "" Then
                Call ListadoTrans()
                BtnGrabar.Focus()
            Else
                Call ObtenerDatos()
                BtnGrabar.Focus()
            End If
        End If
    End Sub

    Private Sub FrmProducto_Proveedor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblProveedor.Text = ""
        lblDireccion.Text = ""
        lblCodigo_Prov.Text = ""
        txtRUCDNI.Text = ""
        LblProducto.Text = pProducto
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If pProductoID = 0 Then
            MessageBox.Show("No hay código producto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lblCodigo_Prov.Text = "" And txtRUCDNI.Text = "" Then
            MessageBox.Show("No hay código Proveedor y/o RUC", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Try

                If productotempManager.Actualizar_Proveedor(pProductoID, Long.Parse(lblCodigo_Prov.Text), 2015, txtCodigo_Pro_Prov.Text.Trim, Single.Parse(txtPrecioS.Text), Single.Parse(txtPrecioD.Text)) > 0 Then
                    FrmCatalogo.ListarCondicion()
                    Me.Close()
                End If
                'MessageBox.Show(Objeto.idtipodocid)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub UltraLabel1_Click(sender As Object, e As EventArgs) Handles UltraLabel1.Click
        Call ListadoTrans()
        BtnGrabar.Focus()
    End Sub

    Private Sub txtCodigo_Pro_Prov_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo_Pro_Prov.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPrecioS.Focus()
        End If
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub txtPrecioS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioS.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPrecioD.Focus()
        End If
    End Sub

    Private Sub txtPrecioD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRUCDNI.Focus()
        End If
    End Sub

End Class