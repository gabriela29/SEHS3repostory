Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmClave
    Public pCodigo As Long, zNew As Boolean

    Private Sub Mostrar_Registro()
        Dim ObjC As clave
        ObjC = ClaveManager.GetItemUs(pCodigo)
        zNew = False
        If Not ObjC Is Nothing Then
            lblPersona.Text = ObjC.nombre
            txtUsuario.Text = ObjC.usuario
            If txtUsuario.Text = "" Then
                zNew = True
            End If
        End If
        ObjC = Nothing
    End Sub

    Private Sub FrmClave_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmClave_Load(sender As Object, e As EventArgs) Handles Me.Load
        zNew = False
        Call Mostrar_Registro()
    End Sub

    Private Sub txtUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtClave.Focus()
        End If
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGrabar.Focus()
        End If
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        If txtUsuario.Text = "" Then
            MessageBox.Show("Debe Ingresar un Usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUsuario.Focus()
            Exit Sub
        End If
        If txtClave.Text = "" Then
            MessageBox.Show("Debe Ingresar una Clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtClave.Focus()
            Exit Sub
        End If
        Dim objCx As New clave
        With objCx
            .codigo = pCodigo
            .usuario = txtUsuario.Text
            .clave = txtClave.Text
        End With
        Try
            If ClaveManager.Actualizar(zNew, objCx) Then
                objCx = Nothing
                Me.Close()
            End If
        Catch ex As Exception
            objCx = Nothing
            MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class