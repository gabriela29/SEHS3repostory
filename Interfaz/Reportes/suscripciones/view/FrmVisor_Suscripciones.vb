Imports Microsoft.Reporting.WinForms
Public Class FrmVisor_Suscripciones
    Public pdtData As DataTable, pEmpresa As String, pLocal As String, pTitulo As String, pCondicion As String
    Public pRpt As String

    Private Sub FrmVisorVentas_Clientes_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
    End Sub

    Public Sub Coordinador_Periodo_Grupo()


        Dim datasource As New ReportDataSource("Responsables_Grupo", pdtData)

        Me.rvVisor.LocalReport.ReportEmbeddedResource = "Phoenix.rptReponsables_Grupo.rdlc"
        Me.rvVisor.LocalReport.DataSources.Clear()        
        Me.rvVisor.LocalReport.DataSources.Add(datasource)

        Dim parameters As ReportParameter() = New ReportParameter(3) {}
        parameters(0) = New ReportParameter("Empresa", pEmpresa)
        parameters(1) = New ReportParameter("Local", pLocal)
        parameters(2) = New ReportParameter("Titulo", pTitulo)
        parameters(3) = New ReportParameter("Condicion", pCondicion)
        rvVisor.LocalReport.SetParameters(parameters)

        Me.rvVisor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rvVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.rvVisor.RefreshReport()
    End Sub

    Public Sub Pedidos_Periodo_Grupo()


        Dim datasource As New ReportDataSource("Responsables_Grupo", pdtData)

        Me.rvVisor.LocalReport.ReportEmbeddedResource = "Phoenix.rptReponsables_Grupo.rdlc"
        Me.rvVisor.LocalReport.DataSources.Clear()
        Me.rvVisor.LocalReport.DataSources.Add(datasource)

        Dim parameters As ReportParameter() = New ReportParameter(3) {}
        parameters(0) = New ReportParameter("Empresa", pEmpresa)
        parameters(1) = New ReportParameter("Local", pLocal)
        parameters(2) = New ReportParameter("Titulo", pTitulo)
        parameters(3) = New ReportParameter("Condicion", pCondicion)
        rvVisor.LocalReport.SetParameters(parameters)

        Me.rvVisor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rvVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.rvVisor.RefreshReport()
    End Sub

    Private Sub Run()
        Dim report As New LocalReport()

        report.ReportPath = "rptReponsables_Grupo.rdlc"
        report.DataSources.Add(New ReportDataSource("Sales", pdtData))


        Dim datasource As New ReportDataSource("Customers", pdtData)
        Me.rvVisor.LocalReport.ReportPath = "rptReponsables_Grupo.rdlc"
        Me.rvVisor.LocalReport.DataSources.Clear()
        Me.rvVisor.LocalReport.DataSources.Add(datasource)
        Me.rvVisor.RefreshReport()

    End Sub

    Public Sub Coordinador_Periodo_Grupo_Iglesia()


        Dim datasource As New ReportDataSource("Responsable_Iglesia", pdtData)

    Me.rvVisor.LocalReport.ReportEmbeddedResource = "Phoenix.rptResponsable_Iglesia.rdlc" '  "Phoenix.rptReponsable_Iglesia.rdlc"
    Me.rvVisor.LocalReport.DataSources.Clear()
        Me.rvVisor.LocalReport.DataSources.Add(datasource)

    Dim parameters As ReportParameter() = New ReportParameter(4) {}
    parameters(0) = New ReportParameter("Empresa", pEmpresa)
        parameters(1) = New ReportParameter("Local", pLocal)
        parameters(2) = New ReportParameter("Titulo", pTitulo)
        parameters(3) = New ReportParameter("Condicion", pCondicion)
        rvVisor.LocalReport.SetParameters(parameters)

        Me.rvVisor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rvVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.rvVisor.RefreshReport()
    End Sub

    Public Sub Pedidos_Periodo_Grupo_Iglesia()
    Dim Report As New rptDetalle_Suscripcion
    Dim dtOb As New DataTable

    Dim datasource As New ReportDataSource("Responsable_Iglesia", pdtData)

        Me.rvVisor.LocalReport.ReportEmbeddedResource = "Phoenix.rptReponsable_Iglesia.rdlc"
        Me.rvVisor.LocalReport.DataSources.Clear()
        Me.rvVisor.LocalReport.DataSources.Add(datasource)

        Dim parameters As ReportParameter() = New ReportParameter(3) {}
        parameters(0) = New ReportParameter("Empresa", pEmpresa)
        parameters(1) = New ReportParameter("Local", pLocal)
        parameters(2) = New ReportParameter("Titulo", pTitulo)
        parameters(3) = New ReportParameter("Condicion", pCondicion)
        rvVisor.LocalReport.SetParameters(parameters)

        Me.rvVisor.SetDisplayMode(DisplayMode.PrintLayout)
        Me.rvVisor.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        Me.rvVisor.RefreshReport()
    End Sub

    Private Sub FrmVisor_Suscripciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If pRpt = "CDM" Then
            Call Coordinador_Periodo_Grupo()
        ElseIf pRpt = "PPDM" Then
            Call Pedidos_Periodo_Grupo()
        ElseIf pRpt = "CIGLESIAS" Then
            Call Coordinador_Periodo_Grupo_Iglesia()
        ElseIf pRpt = "PPIGLESIAS" Then
      Call Coordinador_Periodo_Grupo_Iglesia()
    End If


        'Me.rvVisor.RefreshReport()


    End Sub
End Class