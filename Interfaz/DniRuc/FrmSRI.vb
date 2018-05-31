Imports System.Text.RegularExpressions

Public Class FrmSRI
  Private Sub FrmSRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    WebBrowser2.Navigate("https://declaraciones.sri.gob.ec/consultas-renta-internet/consultaNaturales.jsf")
  End Sub

  Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted

  End Sub

  Private Sub GetInfo()
    Dim pattern As String = "<a id.*?>"
    Dim vInpt As String = WebBrowser2.DocumentText
    Dim vValue As String = ""
    Dim vIdex As String = ""

    For Each m As Match In Regex.Matches(vInpt, pattern)
      vValue = vValue & m.Index & "@" & m.Value & vbNewLine
    Next
    RichTextBox3.Text = vValue

    'RichTextBox1.Text = xresul
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Call GetInfo()
  End Sub
End Class