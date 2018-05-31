Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmVisualizador_Varios

  Public Function RptRegistro_Ventas_gClie(ByVal vUnidad As Integer, ByVal vAlmacenId As Integer, ByVal vmes As Integer,
                                          ByVal vanio As Integer, ByVal vcod_doc As Integer, ByVal vRuc As String,
                                          ByVal vEmpresa As String, ByVal vLocal As String,
                                          ByVal vSubtitulo As String, ByVal vComentario As String,
                                          ByVal vHstorico As Boolean, ByVal vDesde As String,
                                          ByVal vHasta As String, ByVal vDocumentoid As Integer, ByVal vTabla As String) As Boolean
    Dim Report As New Rpt_Registro_Ventas_gCli
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Registro_Venta(vUnidad, vAlmacenId, vanio, vmes, 0, vRuc, vHstorico, vDesde, vHasta, vDocumentoid, vTabla)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    'Report.SetParameterValue(5, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_NC(ByVal vUnidad As Integer, ByVal vmes As Integer,
                                    ByVal vanio As Integer, ByVal vcod_doc As Integer,
                                    ByVal vEmpresa As String, ByVal vLocal As String,
                                    ByVal vSubtitulo As String, ByVal vComentario As String,
                                    ByVal vSunat As Boolean) As Boolean
    Dim Report As New Rpt_Registro_Ventas
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Registro_NC(vUnidad, vmes, vanio, vcod_doc, False, vSunat)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo & "/" & vComentario)
    'Report.SetParameterValue(5, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_Ventas_Sunat(ByVal vUnidad As Integer, ByVal vAlmacenid As Integer, ByVal vmes As Integer,
                                            ByVal vanio As Integer, ByVal vcod_per As Integer, ByVal vcRUC As String,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vRuc As String, ByVal vHistorico As Boolean,
                                            ByVal vDesde As String, ByVal vHasta As String,
                                           ByVal vDocumentoid As Integer, ByVal vTabla As String) As Boolean
    Dim Report As New rpt_Registro_Venta_Sunat
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Registro_Venta(vUnidad, vAlmacenid, vanio, vmes, vcod_per, vcRUC, vHistorico, vDesde, vHasta, vDocumentoid, vTabla)

    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, "REGISTRO DE VENTA " & vTabla)
    Report.SetParameterValue(1, vSubtitulo)
    Report.SetParameterValue(2, vRuc)
    'Report.SetParameterValue(5, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(3, vEmpresa)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_Ventas_Res(ByVal vUnidad As Integer, ByVal vmes As Integer,
                                            ByVal vanio As Integer, ByVal vcod_doc As Integer,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rpt_Registro_Venta_Cons
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Registro_Venta_Res(vUnidad, vmes, vanio, vcod_doc)

    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    'Report.SetParameterValue(5, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    ''Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_Compras_sunat(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vmes As Integer,
                                              ByVal vanio As Integer, ByVal vcod_per As Long, ByVal vRuc As String, ByVal vHistorico As Boolean,
                                              ByVal vEmpresa As String, ByVal vRuc_EMP As String, ByVal vLocal As String,
                                              ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rpt_Registro_Compras_Sunat
    Dim opciones(1) As String, vTitulo As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Registro_Compras(vUnidad, vAlmacen, vmes, vanio, vcod_per, vRuc, vHistorico)
    If vAlmacen > 0 Or vUnidad > 0 Then
      vTitulo = "REGISTRO DE COMPRAS - " & vUnidad & " " & vLocal
    Else
      vTitulo = "REGISTRO DE COMPRAS"
    End If

    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vTitulo)
    Report.SetParameterValue(1, vComentario)
    Report.SetParameterValue(2, vRuc_EMP)
    Report.SetParameterValue(3, vEmpresa)
    Report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
    Report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_RH(ByVal vUnidad As Integer, ByVal vmes As Integer,
                                          ByVal vanio As Integer, ByVal vEmpresa As String,
                                          ByVal vLocal As String, ByVal vcod_per As Long,
                                          ByVal vcuenta As String, ByVal vswlegal As Boolean, ByVal vRecalcula As Boolean,
                                          ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rpt_Registro_RH
    Dim opciones(1) As String, vTitulo As String
    Dim DtOb As New DataTable
    Dim xUsuario As String = GestionSeguridadManager.sUsuario
    DtOb = ReportesManager.Registro_RH(vUnidad, vmes, vanio, vcod_per, vcuenta, vswlegal)
    If vUnidad > 0 Then
      vTitulo = vLocal
    Else
      vTitulo = "REGISTRO DE RH CONSOLIDADO"
    End If


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vTitulo)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, xUsuario)
    'Report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
    'Report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_Daot(ByVal vAlmacenID As Integer, ByVal vmes As Integer, ByVal vVentas As Boolean,
                                              ByVal vanio As Integer, ByVal vMonto As Single,
                                           ByVal vEmpresa As String, ByVal vRuc As String, ByVal vLocal As String,
                                           ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New Rpt_Compras_DAOT
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    If vVentas Then
      DtOb = ReportesManager.Registro_DAOT(vAlmacenID, vmes, vVentas, vanio, vMonto)
    Else
      DtOb = ReportesManager.Registro_DAOT(vAlmacenID, vmes, vVentas, vanio, vMonto)
    End If


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    'Report.SetParameterValue(5, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptRegistro_Kardex(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vcod_prod As Long,
                                      ByVal vAlmacenid As Integer, ByVal vFamiliaID As Integer, ByVal vCPrecio As Boolean,
                                      ByVal vunidadid As Integer, ByVal vrecalcular As Boolean, ByVal vhistorico As Boolean,
                                      ByVal vRUC As String, ByVal vPeriodo As String, ByVal vEmpresa As String, ByVal vLocal As String) As Boolean
    Dim Report As New rpt_Kadex
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = ReportesManager.Kardex_completo(vMes, vAnio, vcod_prod, vAlmacenid, vFamiliaID, vCPrecio, vunidadid, vrecalcular, vhistorico)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, "REGISTRO DE KARDEX VALORADO (METODO PROMEDIO PONDERADO)")
    Report.SetParameterValue(1, vPeriodo)
    Report.SetParameterValue(2, vRUC)
    Report.SetParameterValue(3, vEmpresa)
    Report.SetParameterValue(4, vLocal)

    Me.CrystalReportViewer1.ReportSource = Report


  End Function

End Class