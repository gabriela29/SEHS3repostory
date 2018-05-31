Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win


Public Class FrmPersona_Limite_Credito
    Public pAlmacenId As Integer, vAlmacen As String
    Public pPersonaId As Long, pPersona As String
    Public ModoVentanaFlotante As Boolean

    Public Function Actualizar() As Boolean
        Dim xOk As Boolean = False, vLinea As Single = 0
        If Not pAlmacenId > 0 Then
            MessageBox.Show("No hay un almacén seleccionado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If
        If Not pPersonaId > 0 Then
            MessageBox.Show("No hay una persona seleccionada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If
        If IsNumeric(txtImporte.Text) Then
            If txtImporte.Text > 0 Then
                vLinea = txtImporte.Text
            Else
                MessageBox.Show("Debe ingresar un importe mayor a cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Function
            End If
        Else
            MessageBox.Show("Debe ingresar un importe mayor a cero", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End If

        Try

            If personaManager.Actualizar_Linea_Credito(pAlmacenId, pPersonaId, vLinea) > 0 Then
                xOk = True
                Me.Close()
            End If
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return xOk
    End Function


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmPersona_Limite_Credito_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblAlmacen.Text = vAlmacen
        lblPersona.Text = pPersona
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Call Actualizar()
    End Sub
End Class