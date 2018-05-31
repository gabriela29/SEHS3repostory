Imports CapaLogicaNegocio.Bll
'Imports CapaObjetosNegocio.BO
Public Class FrmVisorGastos

    Public Function RptDigitaLte(ByVal dtFormatLte As DataTable, ByVal vEmpresa As String, ByVal vLocal As String) As Boolean
        Dim rpt As New RptDetalleGastosLte

        rpt.SetDataSource(dtFormatLte)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, "Documentos Registrados por Lote")

        cvProductos.ReportSource = rpt
    End Function

    Public Function RptDetalleLte(ByVal dtFormatLte As DataTable, ByVal vEmpresa As String, ByVal vLocal As String) As Boolean
        Dim rpt As New rptLote_Gastos

        rpt.SetDataSource(dtFormatLte)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, "Documentos Registrados por Lote")
        rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)

        cvProductos.ReportSource = rpt
    End Function

    Public Function RptAsiento_Lote(ByVal dtl As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, _
                                    ByVal vSubTitulo As String, ByVal vLote As String) As Boolean
        Dim rpt As New rptAsientoAssinet  'RptAsiento_Ctr

        rpt.SetDataSource(dtl)

        rpt.SetParameterValue(0, vEmpresa)
        rpt.SetParameterValue(1, vLocal)
        rpt.SetParameterValue(2, vSubTitulo)
        rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)
        rpt.SetParameterValue(4, My.Computer.Name)
        rpt.SetParameterValue(5, vLote)
        cvProductos.ReportSource = rpt
    End Function


End Class