

Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid




Public Class FrmEmpresaEdit
    Public vEmpresaid
    Public vcodigo As Integer
    Public ModoVentanaFlotante As Boolean, swNuevo As Boolean

    Private Sub Mostrar_Datos()
        Dim Objc As CapaObjetosNegocio.empresa


        Objc = empresaManager.GetItem(vcodigo)

        If Not Objc Is Nothing Then
            TxtNom_empresa.Text = Objc.nombre
            txtruc.Text = Objc.ruc
            Textdireccion.Text = Objc.direccion
            Texturl.Text = Objc.url
        End If
        Objc = Nothing

    End Sub


    Public Function Actualizar() As Boolean
        Dim Objeto As New CapaObjetosNegocio.empresa
        Try
            With Objeto
                If vcodigo > 0 Then
                    .empresaid = vcodigo
                Else
                    .empresaid = -1
                End If
                .nombre = TxtNom_empresa.Text.Trim
                .ruc = txtruc.Text.Trim
                .direccion = Textdireccion.Text.Trim
                .url = Texturl.Text.Trim
            End With

            empresaManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCancelarEm_Click(sender As Object, e As EventArgs) Handles btnCancelarEm.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptarEm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarEm.Click
        If MessageBox.Show("¿Desea grabar los datos?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not TxtNom_empresa.Text.Trim = "" Then
                    If Actualizar() Then
                        Me.Close()
                    End If
                Else
                    MessageBox.Show("Debe ingresar un nombre", "AVISO", MessageBoxButtons.OK)
                End If

                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FrmEmpresaEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vcodigo > 0 Then
            Call Mostrar_Datos()
        End If
    End Sub

    Private Sub Btncerrar1_Click(sender As Object, e As EventArgs) Handles Btncerrar1.Click
        Me.Close()
    End Sub

    Private Sub FrmEmpresaEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

End Class