
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmGrupoNM
    Public pCodigo As Integer
    Public rCodigo As Integer
    Public ModoVentanaFlotante As Boolean

    Private Sub Mostrar_Datos()
        Dim Objc As grupo

        Objc = grupoManager.GetItem(pCodigo)

        If Not Objc Is Nothing Then
            TxtNombre.Text = Objc.nombre
            txtAbrev.Text = Objc.abrev
        End If
        Objc = Nothing

    End Sub


    Public Function Actualizar() As Boolean
        Dim Objeto As New grupo
        Actualizar = False
        Try
            With Objeto
                If pCodigo > 0 Then
                    .grupoid = pCodigo
                Else
                    .grupoid = -1
                End If
                .nombre = TxtNombre.Text.Trim
                .abrev = txtAbrev.Text.Trim

            End With
            rCodigo = grupoManager.Grabar(Objeto)
            If rCodigo > 0 Then
                Actualizar = True
            End If
            Return Actualizar
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If Not TxtNombre.Text.Trim = "" Then
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

    Private Sub FrmgrupoNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub FrmgrupoNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If pCodigo > 0 Then
            Call Mostrar_Datos()
        End If
    End Sub
End Class