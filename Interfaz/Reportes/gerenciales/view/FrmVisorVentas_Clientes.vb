Imports Microsoft.Reporting.WinForms

Public Class FrmVisorVentas_Clientes
    Public pdtData As DataTable, pEmpresa As String, pLocal As String, pTitulo As String, pCondicion As String

    Private Sub FrmVisorVentas_Clientes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
    End Sub

    Private Sub FrmVisorVentas_Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim parameters As ReportParameter() = New ReportParameter(3) {}
        parameters(0) = New ReportParameter("Empresa", pEmpresa)
        parameters(1) = New ReportParameter("Local", pLocal)
        parameters(2) = New ReportParameter("Titulo", pTitulo)
        parameters(3) = New ReportParameter("Condicion", pCondicion)
        rvVisor.LocalReport.SetParameters(parameters)

        EGerencialesBindingSource.DataSource = pdtData
        Me.rvVisor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rvVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.rvVisor.RefreshReport()
    End Sub
End Class