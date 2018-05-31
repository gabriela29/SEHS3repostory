Imports System.Web.Mail

Public Class FrmMail

    Private Sub btnEnviarCorreo_Click(ByVal sender As System.Object, _
                                      ByVal e As System.EventArgs)

        Dim smtp As New System.Net.Mail.SmtpClient
        Dim correo As New System.Net.Mail.MailMessage
        Dim adjunto As System.Net.Mail.Attachment

        With smtp
            .Port = 25
            .Host = "smtp.elrincondelprogramador.net"
            .Credentials = New System.Net.NetworkCredential("usuario-smtp", "clave-smtp")
            .EnableSsl = False
        End With
        'adjunto = New System.Net.Mail.Attachment("C:\Temp\Adjunto.pdf")
        With correo
            .From = New System.Net.Mail.MailAddress("mail@elrincondelprogramador.net")
            .To.Add("destinatario@sudominio.com")
            .Subject = "Asunto del correo"
            .Body = "<strong>Texto del mensaje de correo</strong>"
            .IsBodyHtml = True
            .Priority = System.Net.Mail.MailPriority.Normal
            .Attachments.Add(adjunto)
        End With

        Try
            smtp.Send(correo)
            MessageBox.Show("Su mensaje de correo ha sido enviado.", _
                            "Correo enviado", _
                             MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, _
                            "Error al enviar correo", _
                             MessageBoxButtons.OK)
        End Try

    End Sub

End Class