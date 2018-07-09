Public Class FrmEmpresaLis
    Public _codigo As Integer
    Public ListadoRegistros As DataTableClearEventArgs

    ' Private Sub FrmEmpresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handless Me.KeyPress
    ' If e.KeyChar = Chr(Keys.Enter) Then
    '        SendKeys.Send("{Tab}")
    ' End If
    ' End Sub

    Public Function ListarCondicion() As Boolean
        Dim xLimit As Integer
        Dim vArray As String = "", vTiene As Boolean = False
        'Dim dgvRw As UltraGridRow
        ' xLimit = Integer.Parse(txtLimite.Text)

        'For Each dgvRw.Band.Index = 0 Then
        'vTiene = True
        'vArray = vArray & Trim(Str(dgvRw.Cells("rolid").Value)) & ","
    End Function
End Class