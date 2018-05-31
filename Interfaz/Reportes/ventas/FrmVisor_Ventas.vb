Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmVisor_Ventas

  Public Function rptLista_Dzmo(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String,
                                  ByVal vDetalle As Boolean, ByVal vNC As Boolean,
                                  ByVal vEmpresa As String, ByVal vLocal As String,
                                  ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptListDzmo
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.List_Dzmo(vDesde, vHasta, vCodigo_Alm, vDetalle, vNC)

    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function RptAsiento_Prov_Ingresos(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                          ByVal vLocal As String, ByVal vSubTitulo As String, ByVal vLote As String) As Boolean
    Try
      Dim rpt As New rptAsientoAssinet  'RptAsiento_Ctr

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vSubTitulo)
      rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)
      rpt.SetParameterValue(4, My.Computer.Name)
      rpt.SetParameterValue(5, vLote)
      crvVisor.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptAsiento_Prov_NC_Ingresos(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                                  ByVal vLocal As String, ByVal vSubTitulo As String, ByVal vLote As String) As Boolean
    Try
      Dim rpt As New rptAsientoAssinet  'RptAsiento_Ctr

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vSubTitulo)
      rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)
      rpt.SetParameterValue(4, My.Computer.Name)
      rpt.SetParameterValue(5, vLote)
      crvVisor.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function rptRegistro_Ingresos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                  ByVal vEmpresa As String, ByVal vLocal As String,
                                  ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptRegistro_Ingresos
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Registro_Ingresos(vCodigo_Alm, vDesde, vHasta, vPersona)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptRanking_Ventas(ByVal vTipoRanking As String, ByVal vOpcion As String, ByVal vIndicador As String,
                                      ByVal vDesde As String, ByVal vHasta As String, ByVal vAlmacen As Long, ByVal vLimite As Long,
                                         ByVal vEmpresa As String, ByVal vLocal As String,
                                         ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vCat As Integer, ByVal vUnidadId As Integer) As Boolean

    Dim Report As New rptRanking
    Dim opciones(1) As String
    Dim DtOb As New DataTable
    'Set Ranking = oCn.Ejecutar_Consulta_SQL("select * from paRanking('" & Trim(tipoRanking) & "', '" & vOpcion & "', '" & 
    'vIndicador & "', '" & Format(vdesde, "yyyy-mm-dd") & "', '" & Format(vhasta, "yyyy-mm-dd") & "', " & 
    'Trim(Str(vAlmacen)) & ", " & Trim(Str(vlimite)) & ")")
    DtOb = reportes_ventasManager.rptRanking_Ventas(vTipoRanking, vOpcion, vIndicador, vDesde, vHasta, vAlmacen, vLimite, vCat, vUnidadId)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptVentas_Documento(ByVal vCondicion As String, ByVal vDesde As String,
                                        ByVal vHasta As String, ByVal vCodigo_Doc As Integer,
                                        ByVal vUsuario As String, ByVal vSerie As String, ByVal vCodigo_Alm As Integer,
                                        ByVal vEmpresa As String, ByVal vLocal As String,
                                        ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptVentas_Documento
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Detalle_Documento(vCondicion, vDesde, vHasta, vCodigo_Doc, vUsuario, vSerie, vCodigo_Alm)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptVentas_SubCategoria(ByVal vCondicion As String, ByVal vDesde As String,
                                            ByVal vHasta As String, ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vUnidadId As Integer) As Boolean

    Dim Report As New rptResumen_Familias
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Ventas_SubCategoria(vCondicion, vDesde, vHasta, vUsuario, vCodigo_Alm, vUnidadId)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptMovimiento_Caja(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                        ByVal vEmpresa As String, ByVal vLocal As String,
                                        ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptMovimiento_Caja
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Movimiento_Caja(vPersona, vCodigo_Alm, vDesde, vHasta, 3)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Report.SetParameterValue(5, My.Computer.Name)

    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptDet_Movimiento_Caja_Ing(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                               ByVal vEmpresa As String, ByVal vLocal As String,
                                               ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptDet_Mov_Caja
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Movimiento_Caja(vPersona, vCodigo_Alm, vDesde, vHasta, 1)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Report.SetParameterValue(5, My.Computer.Name)

    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptDet_Movimiento_Caja_Sus(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                               ByVal vEmpresa As String, ByVal vLocal As String,
                                               ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean

    Dim Report As New rptDet_Mov_Caja_Sus
    Dim opciones(1) As String
    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Movimiento_Caja(vPersona, vCodigo_Alm, vDesde, vHasta, 2)


    Report.SetDataSource(DtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Report.SetParameterValue(5, My.Computer.Name)

    Me.crvVisor.ReportSource = Report

  End Function

  Public Function rptVentas_Guia(ByVal vCodigo As Long) As Boolean

    Dim Report As New rptGuiaIU

    Dim DtOb As New DataTable

    DtOb = reportes_ventasManager.Venta_Guia_IU(vCodigo)


    Report.SetDataSource(DtOb)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report

  End Function

  Public Function RptVenta_Mercaderia_Detalle(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                              ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptCompras_Detalladas

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)

      crvVisor.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptAsiento_Ingresos(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                          ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New RptAsiento_Ctr

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)
      crvVisor.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptAsiento_Costo_Venta(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                          ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptAsiento_CV

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      'rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)
      crvVisor.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptVentaxVendedor(ByVal dtData As DataTable, ByVal vEmpresa As String, ByVal vLocal As String,
                                        ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptSuscripcionPorVendedor

    Report.SetDataSource(dtData)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report


  End Function

  Public Function RptSuscripcionxVendedorDP(ByVal DtData As DataTable, ByVal vEmpresa As String, ByVal vLocal As String,
                                          ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptSuscripcionPorVendedorDP

    Report.SetDataSource(DtData)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Me.crvVisor.ReportSource = Report


  End Function

End Class