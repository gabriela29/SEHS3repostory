Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class frmVisualizador_rpt

    Public Function RptNota_Credito_Prov(ByVal vCodigo As Long, ByVal vRuta As String, ByVal vSerieTk As String) As Boolean
        Dim Report As New Rpt_Registro_Ventas
        Dim opciones(1) As String
        Dim DtOb As New DataTable

        'DtOb = provision_legalManager.Rpt_Provision_Print_NC(vCodigo)

        'Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        '' Indicamos la ruta del archivo del reporte que requerimos. En este caso suponemos que está en la raiz de nuestro proyecto
        ''rpt.FileName = "D:\DiscoC\SoftwareColegio\Interfaz\Reportes\miBoleta.rpt" 'rpt.Load(NameRpt, OpenReportMethod.OpenReportByDefault)

        'rpt.Load(vRuta, OpenReportMethod.OpenReportByDefault)


        '' Establecemos nuestro DataSet como origen de datos de nuestro reporte
        'CrystalReportViewer1.Visible = True
        'rpt.SetDataSource(DtOb)
        'rpt.SetParameterValue(0, vSerieTk)
        '' Indicamos al Report Viewer cual es el reporte que queremos mostrar
        'CrystalReportViewer1.ReportSource = rpt
        'CrystalReportViewer1.DisplayStatusBar = True
        'CrystalReportViewer1.Show()

    End Function

End Class