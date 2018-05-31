
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmDestino_BonificacionEdit

    Public pCodigo As Integer

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String


        If Trim(txtDestino.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtDestino, "Falta Ingresar Destino")
            camposConError.Add("txtDestino")
        Else
            ErrorProvider1.SetError(txtDestino, Nothing)
        End If
        If Not IsNumeric(txtImporte.Text) Then
            If Single.Parse(txtImporte.Text) > 0 Then
                valido = False
                ErrorProvider1.SetError(txtImporte, "Debe ingresar un Importe")
                camposConError.Add("IMPORTE")
            Else
                ErrorProvider1.SetError(txtImporte, Nothing)
            End If
        Else
            ErrorProvider1.SetError(txtImporte, Nothing)
        End If


        If Not valido Then
            Lblerror.Text = "Introduzca y/o Seleccione un valor en  "

            For Each campo In camposConError
                Lblerror.Text &= campo & ", "
            Next
            Lblerror.Text = Lblerror.Text.Substring(0, Lblerror.Text.Length - 2)
        End If
        Return valido
    End Function

    Public Function Actualizar() As Boolean
        Dim Objeto As New bonificacion_destino
        Try
            With Objeto
                .bonifdestid = pCodigo
                .nombre = txtDestino.Text.Trim
                .importemin = Single.Parse(txtImporte.Text)
                .estado = ChkEstado.Checked

            End With

            If destino_bonificacionManager.Grabar(Objeto) > 0 Then
                Me.Close()
            End If
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If ValidarDatos() Then

                    Call Actualizar()

                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Mostrar_Registro()
        Dim ojbDB As New bonificacion_destino
        ojbDB = destino_bonificacionManager.GetItem(pCodigo)
        If Not ojbDB Is Nothing Then
            txtDestino.Text = ojbDB.nombre
            txtImporte.Text = ojbDB.importemin
            ChkEstado.Checked = Boolean.Parse(ojbDB.estado)
        End If
        ojbDB = Nothing

    End Sub

    Private Sub FrmDestino_BonificacionEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmDestino_BonificacionEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmDestino_BonificacionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If pCodigo > 0 Then
            Call Mostrar_Registro()
        Else
            txtDestino.Text = ""
            txtImporte.Text = "0.00"
            ChkEstado.Checked = True
        End If
    End Sub
End Class