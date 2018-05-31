Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmReniec
  Public myInfo As New LibReniec.Info, vOkR As Boolean, pPersonaid As Long = 0
  Public pNumero As String, pRUC As String
  Public pApe_Pat As String = "", pApe_Mat As String = "", pPersona As String = ""

  Sub CargarImagen()
    'Dim myInfo As New ser
    myInfo = Nothing
    Try
      gpCapcha.Visible = True
      If myInfo Is Nothing Then
        myInfo = New LibReniec.Info
      End If
      Me.pictureCapcha.Image = myInfo.GetCapcha
      txtCapcha.Focus()
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try

  End Sub

  Private Function CaptionResul() As Boolean
    ' Dim myInfo As New LibReniec.Info
    'Me.LblResul.Text = String.Format("Nombre(s): {0}" & Environment.NewLine & "Apellidos Paterno: {1}" & Environment.NewLine & "Apellidos Paterno: {2}", myInfo.Nombres, myInfo.ApePaterno, myInfo.ApeMaterno)
    vOkR = False
    'Valores_RENIEC.pApe_Pat = ""
    'Valores_RENIEC.pApe_Mat = ""
    'Valores_RENIEC.pNombre = ""
    'Valores_RENIEC.pOk = False
    Try

      Select Case myInfo.GetResul
        Case LibReniec.Info.Resul.Ok
          txtApe_Pat.Text = Replace(myInfo.ApePaterno, "�", "Ñ")
          txtApe_Mat.Text = Replace(myInfo.ApeMaterno, "�", "Ñ")
          txtNombre.Text = Replace(myInfo.Nombres, "�", "Ñ")
          'Valores_RENIEC.pApe_Pat = txtApe_Pat.Text
          'Valores_RENIEC.pApe_Mat = txtApe_Mat.Text
          'Valores_RENIEC.pNombre = txtNombre.Text
          'Valores_RENIEC.pOk = True
          vOkR = True
          'gpCapcha.Visible = False
        Case LibReniec.Info.Resul.NoResul
          Me.LblResul.Text = "No existe DNI"
                    ' break;
        Case LibReniec.Info.Resul.ErrorCapcha
          CargarImagen()
          Me.LblResul.Text = "Ingrese imagen correctamente"
                    ' break;
        Case LibReniec.Info.Resul.Error
          Me.LblResul.Text = "Error Desconocido"
          ' break;

      End Select
      Return vOkR
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try

  End Function

  Private Sub txtCapcha_ValueChanged(sender As Object, e As EventArgs) Handles txtCapcha.ValueChanged

  End Sub

  Sub Consultar_Reniec()
    ' Dim myInfo As New ControlesPersonalizados.LibReniec.Info
    Try
      If Me.txtRucDni.Text.Length <> 8 Then
        MessageBox.Show("Ingrese Dni Valido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return
      End If
      If Not Me.txtCapcha.Text.Length > 0 Then
        MessageBox.Show("Ingrese CAPCHA", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return
      End If

      myInfo.GetInfo(Me.txtRucDni.Text, UCase(Me.txtCapcha.Text))

      If CaptionResul() Then
        Dim objP As New persona
        With objP
          .tipo = "N"
          .dni = pNumero
          .ruc = pRUC
          .ape_pat = txtApe_Pat.Text
          .ape_mat = txtApe_Mat.Text
          .nombre = txtNombre.Text
        End With



        pPersonaid = personaManager.Actualizar_Basic(objP, 2)
        objP = Nothing
        Me.DialogResult = DialogResult.OK
        Me.Close()

      Else
        Call CargarImagen()
      End If


    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub

  Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
    Call Consultar_Reniec()
  End Sub

  Private Sub txtCapcha_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapcha.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      Call Consultar_Reniec()
    End If
  End Sub

  Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click, UltraButton1.Click
    Me.Close()
  End Sub

  Private Sub FrmReniec_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    txtRucDni.Text = pNumero
    txtApe_Pat.Text = ""
    txtApe_Mat.Text = ""
    txtNombre.Text = ""
    pPersonaid = 0
    Call CargarImagen()
  End Sub

End Class