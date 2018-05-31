
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports System.Text.RegularExpressions

Public Class FrmCapcha
  Public pNumero As String, pPersonaid As Long = 0
  Dim myInfo_RUC As New LibSunat.info_SUNAT


  Sub CargarImagen()
    Try
      'If myInfo = Nothing Then
      myInfo_RUC = New LibSunat.info_SUNAT
      'End If
      Me.pictureCapcha.Image = myInfo_RUC.Persona

    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try

  End Sub

  Private Function Obener_Datos_RUC(ByRef vMessage As String) As Boolean
    Dim xOkz As Boolean = False, vMess As String = ""
    Try
      Dim xResult As String = ""
      Dim vObjs As datos_ruc
      If myInfo_RUC.GetInfo(txtRucDni.Text, txtCapcha.Text, xResult, vObjs) Then
        With vObjs
          txtRuc.Text = .ruc
          txtRazSocial.Text = Replace(.Razon_Social, "'", " ")
          If Mid(.Tipo_Per, 1, 15) = "PERSONA NATURAL" Then
            txtTipoPer.Text = "N"
          Else
            txtTipoPer.Text = "J"
          End If
          txtDNID.Text = .Dni

          txtActivo.Text = .Estado

          TxtHabido.Text = .Condicion

          txtDireccion.Text = Replace(.Direccion, "'", " ")
          txtTelefonos.Text = .Telefonos

        End With
        vObjs = Nothing

        If txtActivo.Text = "ACTIVO" Then
          xOkz = True
        Else
          vMess = "ESTADO= " & txtActivo.Text
        End If
        If TxtHabido.Text = "HABIDO" Then
          xOkz = True
          vMess = "HABIDO= " & TxtHabido.Text
        End If

      End If
      vMessage = vMess
      If txtTipoPer.Text = "J" And xOkz Then
        Dim objP As New persona
        With objP
          .tipo = "J"
          .ruc = txtRuc.Text
          .dni = ""
          .raz_soc = txtRazSocial.Text
          .direccion = txtDireccion.Text & ""
          .ape_mat = ""
          .nombre = txtRazSocial.Text
        End With
        pPersonaid = personaManager.Actualizar_Basic(objP, 2)
        objP = Nothing
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    Return xOkz
  End Function

  Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnCerrar.Click
    Me.Close()
  End Sub

  Private Sub FrmCapcha_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    txtRucDni.Text = pNumero
    Call CargarImagen()
  End Sub

  Private Sub btnMostrarImg_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnMostrarImg.Click
    Call CargarImagen()
  End Sub

  Private Function Obtener_Datos() As Boolean
    txtTipoPer.Text = "J"
    Dim vMessage As String = ""
    If Obener_Datos_RUC(vMessage) Then

      Me.DialogResult = DialogResult.OK
      Me.Close()

    Else
      MessageBox.Show(vMessage, "AVISO", MessageBoxButtons.OK)
    End If
  End Function
  Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnOk.Click
    Call Obtener_Datos()
  End Sub

  Private Sub txtCapcha_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCapcha.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call Obtener_Datos()
    End If
  End Sub

  Private Sub txtCapcha_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtCapcha.ValueChanged
    txtCapcha.CharacterCasing = CharacterCasing.Upper
  End Sub
End Class