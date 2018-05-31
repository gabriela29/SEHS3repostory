
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmUnidad_MedidaNM
    Public pCodigo As Integer
    Public rCodigo As Integer
    Public ModoVentanaFlotante As Boolean

    Private Sub Mostrar_Datos()
        Dim Objc As unidad_medida

        Objc = unidad_medidaManager.GetItem(pCodigo)

        If Not Objc Is Nothing Then
            TxtNombre.Text = Objc.nombre
            txtAbrev.Text = Objc.abrev
            txtCodigo_Conta.Text = Objc.codigo_conta
        End If
        Objc = Nothing

    End Sub


    Public Function Actualizar() As Boolean
        Dim Objeto As New unidad_medida
        Actualizar = False
        Try
            With Objeto
                If pCodigo > 0 Then
                    .unidadmedidaid = pCodigo
                Else
                    .unidadmedidaid = -1
                End If
                .nombre = TxtNombre.Text.Trim
                .abrev = txtAbrev.Text.Trim & ""
                .codigo_conta = txtCodigo_Conta.Text.Trim & ""
            End With
            rCodigo = unidad_medidaManager.Grabar(Objeto)
            If rCodigo > 0 Then
                Actualizar = True
            End If
            Return Actualizar

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

    Private Sub Frmunidad_medidaNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub

    Private Sub Frmunidad_medidaNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If pCodigo > 0 Then
            Call Mostrar_Datos()
        End If
    End Sub
End Class