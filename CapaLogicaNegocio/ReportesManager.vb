Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll

  Public Class ReportesManager

    Public Shared Function Registro_Venta(ByVal vUnidadId As Integer, ByVal vAlmacen As Integer, ByVal vanio As Integer, ByVal vmes As Integer,
                                              ByVal vPersona As Long, ByVal vcRUC As String, ByVal vHistorico As Boolean, ByVal vDesde As String,
                                              ByVal vHasta As String, ByVal vDocumentoid As Integer, ByVal vTabla As String) As DataTable
      Return ReportesBD.Registro_Venta(vUnidadId, vAlmacen, vanio, vmes, vPersona, vcRUC, vHistorico, vDesde, vHasta, vDocumentoid, vTabla)
    End Function

    Public Shared Function Registro_Venta_PLE(ByVal vanio As Integer, ByVal vmes As Integer, ByVal vEmpresa As Integer, ByVal vAlmacen As Integer) As DataTable
      Return ReportesBD.Registro_Venta_PLE(vanio, vmes, vEmpresa, vAlmacen)
    End Function

    Public Shared Function Registro_NC(ByVal vcodigo_unidad As Integer, ByVal vmes As Integer,
                                  ByVal vanio As Integer, ByVal vcodigo_documento As Integer, ByVal vRecalcula As Boolean, ByVal vSunat As Boolean) As DataTable
      Return ReportesBD.Registro_NC(vcodigo_unidad, vmes, vanio, vcodigo_documento, vRecalcula, vSunat)
    End Function

    Public Shared Function Registro_Venta_Res(ByVal vcodigo_unidad As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal vcodigo_documento As Integer) As DataTable
      Return ReportesBD.Registro_Venta_Res(vcodigo_unidad, vmes, vanio, vcodigo_documento)
    End Function

    Public Shared Function Registro_Compras(ByVal vcodigo_unidad As Integer, ByVal vAlmacenid As Integer, ByVal vmes As Integer,
                                            ByVal vanio As Integer, ByVal vcodigo_per As Long,
                                            ByVal vRuc As String, ByVal vHistorico As Boolean) As DataTable
      Dim DtTemp As New DataTable

      DtTemp = ReportesBD.Registro_Compras(vcodigo_unidad, vAlmacenid, vmes, vanio, vcodigo_per, vRuc, vHistorico)

      Return DtTemp
    End Function

    Public Shared Function Registro_Compras_PLE(ByVal vanio As Integer, ByVal vmes As Integer,
                                                    ByVal vEmpresa As Integer, ByVal vAlmacen As Integer) As DataTable
      Dim DtTemp As New DataTable

      DtTemp = ReportesBD.Registro_Compras_PLE(vanio, vmes, vEmpresa, vAlmacen)

      Return DtTemp
    End Function

    Public Shared Function Registro_DAOT(ByVal vAlmacenID As Integer, ByVal vmes As Integer, ByVal vVentas As Boolean,
                                            ByVal vanio As Integer, ByVal vMonto As Single) As DataTable
      Dim DtTemp As New DataTable
      If vVentas Then
        DtTemp = ReportesBD.Registro_DAOT_Ventas(vAlmacenID, vmes, vanio, vMonto)
      Else
        DtTemp = ReportesBD.Registro_DAOT(vAlmacenID, vmes, vanio, vMonto)
      End If
      Return DtTemp
    End Function

    Public Shared Function Registro_RH(ByVal vcodigo_Alm As Integer, ByVal vmes As Integer,
                                        ByVal vanio As Integer, ByVal vcodigo_per As Long,
                                        ByVal vcuenta As String, ByVal vswlegal As Boolean) As DataTable
      Dim DtTemp As New DataTable
      'If vMostrar Then
      DtTemp = ReportesBD.Registro_RH(vcodigo_Alm, vmes, vanio, vcodigo_per, 4)
      'End If
      Return DtTemp
    End Function

    Public Shared Function Stock_valorado(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer, ByVal vCategoria As Integer,
                                          ByVal vOpcion As Integer, ByVal vUniId As Integer, ByVal vcCosto As Boolean, ByVal vTipoStock As Integer) As DataTable
      Dim DtTemp As New DataTable
      'If vMostrar Then
      Select Case vOpcion
        Case 0
          DtTemp = ReportesBD.Stock_Valorado(xMes, xAnio, vAlmacen, vCategoria, vUniId, 0, vcCosto, vTipoStock)

      End Select

      'End If
      Return DtTemp
    End Function

    Public Shared Function Stock_Unidades(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer,
                                          ByVal vCategoria As Integer, ByVal vOpcion As Integer, ByVal vUniId As Integer, ByVal vSaldo As Boolean) As DataTable
      Dim DtTemp As New DataTable
      'If vMostrar Then
      Select Case vOpcion
        Case 0
          DtTemp = ReportesBD.Stock_Unidades(xMes, xAnio, vAlmacen, vCategoria, vUniId, vSaldo)

      End Select

      'End If
      Return DtTemp
    End Function

    Public Shared Function Costo_Venta(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vAlmacen As Integer,
                                        ByVal vOpcion As Integer, ByVal vUnidadId As Integer) As DataTable
      Dim DtTemp As New DataTable
      If vOpcion = 1 Then
        DtTemp = ReportesBD.Costo_Venta(vMes, vAnio, vAlmacen, vUnidadId)
      Else
        DtTemp = ReportesBD.Venta_Costo(vMes, vAnio, vAlmacen, vUnidadId)
      End If
      Return DtTemp
    End Function

    Public Shared Function Stock_valorado_Actualziar(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer) As Boolean
      Dim DtTemp As Boolean = False
      'If vMostrar Then
      If ReportesBD.Stock_Valorado_Actualziar(xMes, xAnio, vAlmacen) Then
        DtTemp = True
      End If
      'End If
      Return DtTemp
    End Function

    Public Shared Function Detalle_Documento_Merca(ByVal vFuncion As String, ByVal vDesde As String, ByVal vHasta As String,
                                                    ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long,
                                                    ByVal vProducto As Long) As DataTable
      Dim DtTemp As New DataTable

      DtTemp = ReportesBD.Detalle_Documento_Merca(vFuncion, vDesde, vHasta,
                                                   vUnidad, vAlmacen, vPersona, vProducto)

      'End If
      Return DtTemp
    End Function

    Public Shared Function rptListado_Mov_Caja(ByVal vtipo As String, ByVal vcodigo_alm As Integer, ByVal vdesde As String, ByVal vhasta As String,
                                               ByVal vcuenta As String, ByVal vpersona As Long, ByVal vdocumento As Integer,
                                               ByVal vefectivo As Integer, ByVal vCat_Per As Integer) As DataTable
      Return ReportesBD.rptListado_Mov_Caja(vtipo, vcodigo_alm, vdesde, vhasta,
                                              vcuenta, vpersona, vdocumento, vefectivo, vCat_Per)
    End Function

    Public Shared Function rptListado_PorCobrarN(ByVal vcodigo_Uni As Integer, ByVal vcodigo_alm As Integer, ByVal vdesde As String,
                                                 ByVal vhasta As String, ByVal vdocumento As Integer) As DataTable
      Return ReportesBD.rptListado_PorCobrarN(vcodigo_Uni, vcodigo_alm, vdesde, vhasta, vdocumento)
    End Function

    Public Shared Function Kardex_completo(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vProductoid As Long,
                                           ByVal vAlmacen As Integer, ByVal vFamiliaID As Integer, ByVal vcPrecio As Boolean,
                                           ByVal vunidad As Integer, ByVal vrecalcular As Boolean, ByVal vhistorico As Boolean)
      Return ReportesBD.Kardex_completo(vMes, vAnio, vProductoid, vAlmacen, vFamiliaID, vcPrecio, vunidad, vrecalcular, vhistorico)
    End Function
  End Class
End Namespace
