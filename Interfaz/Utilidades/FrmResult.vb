Imports System.Xml

Public Class FrmResult
    Public pXml As String

    Private Sub FrmRequest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet()
        Dim sr As New System.IO.StringReader(pXml)
        Dim reader As XmlTextReader

        'Create the XML Reader
        reader = New XmlTextReader(sr)

        ds.ReadXml(reader)

        dgvResultado.DataSource = ds
        txtResult.Text = pXml
    End Sub
End Class