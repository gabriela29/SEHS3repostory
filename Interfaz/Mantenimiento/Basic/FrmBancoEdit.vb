

Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmBanco
    Public vBancoid
    Public pcodigo As Integer
    Public ModoVentanaFlotante As Boolean, swNuevo As Boolean


    Private Sub Mostrar_Datos()
        Dim Objc As banco

        Objc = bancoManager.GetItem(pcodigo)

        If Not Objc Is Nothing Then
            TxtNom_banco.Text = Objc.nombre
            txtabreviatura.Text = Objc.abreviatura
            Textreferencia.Text = Objc.referencia

        End If
        Objc = Nothing

    End Sub

    Public Function Actualizar() As Boolean
        Dim Objeto As New banco
        Try
            With Objeto
                If pcodigo > 0 Then
                    .bancoid = pcodigo
                Else
                    .bancoid = -1
                End If
                .nombre = TxtNom_banco.Text.Trim
                .abreviatura = txtabreviatura.Text.Trim
                .referencia = Textreferencia.Text.Trim
            End With

            bancoManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not TxtNom_banco.Text.Trim = "" Then
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

    Private Sub FrmBancoEdiNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub








End Class