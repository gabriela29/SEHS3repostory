Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmVisor_Listado
  Dim rptSV As rptStock_Valorado
  Dim rptHT As rptStock_HT
  Dim rptCV As rptCosto_Venta
  Dim rptVC As rptVenta_Costo

  Public Function RptStock_Valorado_Balance(ByVal vEmpresa As String, ByVal vLocal As String, ByVal xSubt As String,
                                            ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer,
                                            ByVal vOpcion As Integer, ByVal xCondicion As String, ByVal vResumen As Boolean,
                                            ByVal xFamilia As Integer, ByVal vUniId As Integer, ByVal vConSaldo As Boolean,
                                            ByVal cCosto As Boolean, ByVal vTipoStock As Integer) As Boolean
    'Dim rpt As New rptStock_Valorado
    Dim DtSV As New DataTable
    Dim xUsuario As String = GestionSeguridadManager.sUsuario
    Select Case vOpcion
      Case 0
        rptSV = New rptStock_Valorado
        DtSV = ReportesManager.Stock_valorado(xMes, xAnio, vAlmacen, xFamilia, 0, vUniId, cCosto, vTipoStock)
        rptSV.SetDataSource(DtSV)

        rptSV.SetParameterValue(0, vEmpresa)
        rptSV.SetParameterValue(1, vLocal)
        rptSV.SetParameterValue(2, xSubt)
        rptSV.SetParameterValue(3, xCondicion)
        rptSV.SetParameterValue(4, xUsuario)
        rptSV.GroupHeaderSection1.SectionFormat.EnableSuppress = vResumen
        rptSV.Section3.SectionFormat.EnableSuppress = vResumen
        cvProductos.ReportSource = rptSV
      Case 1
        rptCV = New rptCosto_Venta
        DtSV = ReportesManager.Costo_Venta(xMes, xAnio, vAlmacen, 1, vUniId)
        rptCV.SetDataSource(DtSV)

        rptCV.SetParameterValue(0, vEmpresa)
        rptCV.SetParameterValue(1, vLocal)
        rptCV.SetParameterValue(2, xSubt)
        rptCV.SetParameterValue(3, xCondicion)

        cvProductos.ReportSource = rptCV
      Case 2
        rptVC = New rptVenta_Costo
        DtSV = ReportesManager.Costo_Venta(xMes, xAnio, vAlmacen, 2, vUniId)
        rptVC.SetDataSource(DtSV)

        rptVC.SetParameterValue(0, vEmpresa)
        rptVC.SetParameterValue(1, vLocal)
        rptVC.SetParameterValue(2, xSubt)
        rptVC.SetParameterValue(3, xCondicion)
        rptVC.SetParameterValue(4, xUsuario)
        cvProductos.ReportSource = rptVC

      Case 3
        rptHT = New rptStock_HT
        DtSV = ReportesManager.Stock_valorado(xMes, xAnio, vAlmacen, xFamilia, 0, vUniId, cCosto, vTipoStock)
        rptHT.SetDataSource(DtSV)

        rptHT.SetParameterValue(0, vEmpresa)
        rptHT.SetParameterValue(1, vLocal)
        rptHT.SetParameterValue(2, xSubt)
        rptHT.SetParameterValue(3, xCondicion)
        rptHT.SetParameterValue(4, xUsuario)
        rptHT.GroupHeaderSection1.SectionFormat.EnableSuppress = vResumen
        rptHT.Section3.SectionFormat.EnableSuppress = vResumen
        cvProductos.ReportSource = rptHT
    End Select



  End Function

  Public Function RptDetalle_Doc_Mercaderia(ByVal dtData As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal xSubt As String, ByVal xCondi As String) As Boolean
    Dim rpt As New RptDetalle_Doc_Mercaderia

    rpt.SetDataSource(dtData)

    rpt.SetParameterValue(0, vEmpresa)
    rpt.SetParameterValue(1, vLocal)
    rpt.SetParameterValue(2, xSubt)
    rpt.SetParameterValue(3, xCondi)
    rpt.SetParameterValue(4, GestionSeguridadManager.sUsuario)

    cvProductos.ReportSource = rpt
  End Function

  Public Function RptDetalle_Doc_Mercaderia_Web(ByVal dtData As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal xSubt As String, ByVal xCondi As String) As Boolean
    Dim rpt As New RptDetalle_PorCobrar

    rpt.SetDataSource(dtData)

    rpt.SetParameterValue(0, vEmpresa)
    rpt.SetParameterValue(1, vLocal)
    rpt.SetParameterValue(2, xSubt)
    rpt.SetParameterValue(3, xCondi)
    rpt.SetParameterValue(4, GestionSeguridadManager.sUsuario)

    cvProductos.ReportSource = rpt
  End Function

  Public Function RptGestionCobranza(ByVal dtData As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal xSubt As String, ByVal xCondi As String) As Boolean
    Dim rpt As New rptGestionCobrabza

    rpt.SetDataSource(dtData)

    rpt.SetParameterValue(0, vEmpresa)
    rpt.SetParameterValue(1, vLocal)
    rpt.SetParameterValue(2, xSubt)
    rpt.SetParameterValue(3, xCondi)
    'rpt.SetParameterValue(4, GestionSeguridadManager.sUsuario)

    cvProductos.ReportSource = rpt
  End Function

  Public Function RptArchivo_BCP(ByVal dtFormatLte As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal xSubt As String) As Boolean
    'Dim rpt As New RptArchivo_BCP

    'rpt.SetDataSource(dtFormatLte)

    'rpt.SetParameterValue(0, vEmpresa)
    'rpt.SetParameterValue(1, vLocal)
    'rpt.SetParameterValue(2, xSubt)

    'cvProductos.ReportSource = rpt
  End Function

End Class