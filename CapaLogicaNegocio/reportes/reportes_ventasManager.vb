Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class reportes_ventasManager

    Public Shared Function List_Dzmo(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer,
                                     ByVal vDetalle As Boolean, ByVal vNC As Boolean) As DataTable
      Return reportes_ventasBD.List_Dzmo(vDesde, vHasta, vCodigo_Alm, vDetalle, vNC)
    End Function

    Public Shared Function Registro_Ingresos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long) As DataTable
      Return reportes_ventasBD.Registro_Ingresos(vCodigo_Alm, vDesde, vHasta, vPersona)
    End Function

    Public Shared Function rptRanking_Ventas(ByVal vTipoRanking As String, ByVal vOpcion As String, ByVal vIndicador As String,
                                                ByVal vDesde As String, ByVal vHasta As String, ByVal vAlmacen As Long,
                                                ByVal vLimite As Long, ByVal vCat As Integer, ByVal vUnidadid As Integer) As DataTable
      Return reportes_ventasBD.rptRanking_Ventas(vTipoRanking, vOpcion, vIndicador, vDesde, vHasta, vAlmacen, vLimite, vCat, vUnidadid)
    End Function

    Public Shared Function Detalle_Documento(ByVal vCondicion As String, ByVal vDesde As String, ByVal vHasta As String,
                                             ByVal vCodigo_Doc As Integer, ByVal vUsuario As String, ByVal vSerie As String,
                                             ByVal vCodigo_Alm As Integer) As DataTable
      Return reportes_ventasBD.Ventas_Documento(vCondicion, vDesde, vHasta, vCodigo_Doc, vUsuario, vSerie, vCodigo_Alm)
    End Function

    Public Shared Function Ventas_SubCategoria(ByVal vCondicion As String, ByVal vDesde As String, ByVal vHasta As String,
                                                ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vUnidadid As Integer) As DataTable
      Return reportes_ventasBD.Ventas_SubCategoria(vCondicion, vDesde, vHasta, vUsuario, vCodigo_Alm, vUnidadid)
    End Function

    Public Shared Function Venta_Guia_IU(ByVal vCodigo As Long) As DataTable
      Return reportes_ventasBD.Ventas_Guia_IU(vCodigo)
    End Function

    Public Shared Function Detalle_Documento_Codigo(ByVal vCodigo As Long) As DataTable
      Return reportes_ventasBD.Detalle_Documento_Codigo(vCodigo)
    End Function

    Public Shared Function Asiento_Prov_Ingreso(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean,
                                                ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Return reportes_ventasBD.Asiento_Prov_Ingreso(vCodigo_Alm, vDesde, vProcesar,
                                              vMes, vAnio, vUsuario, vCaja)
    End Function

    Public Shared Function Asiento_Prov_Dzmo(ByVal vCodigo_Alm As Integer, ByVal vFecha As String) As DataTable
      Return reportes_ventasBD.Asiento_Prov_Dzmo(vCodigo_Alm, vFecha)
    End Function

    Public Shared Function Asiento_NC_Prov_Dzmo(ByVal vCodigo_Alm As Integer, ByVal vMes As Integer, ByVal vAnio As Integer) As DataTable
      Return reportes_ventasBD.Asiento_NC_PROV_Dzmo(vCodigo_Alm, vMes, vAnio)
    End Function

    Public Shared Function Asiento_Prov_Dzmo(ByVal vLote As Long) As DataTable
      Return reportes_ventasBD.Asiento_Prov_Dzmo(vLote)
    End Function

    Public Shared Function Asiento_vta_Ingreso(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean,
                                        ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Return reportes_ventasBD.Asiento_vta_Ingreso(vCodigo_Alm, vDesde, vProcesar,
                                                      vMes, vAnio, vUsuario, vCaja)
    End Function


    Public Shared Function Asiento_Ingresos(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer) As DataTable
      Return reportes_ventasBD.Asiento_Ingreso(vDesde, vHasta, vCodigo_Alm)
    End Function

    Public Shared Function Asiento_Ingresos_NC(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer) As DataTable
      Return reportes_ventasBD.Asiento_Ingreso_NC(vDesde, vHasta, vCodigo_Alm)
    End Function

    Public Shared Function Asiento_Costo_Venta(ByVal vDesde As Integer, ByVal vHasta As Integer, ByVal vCodigo_Alm As Integer) As DataTable
      Return reportes_ventasBD.Asiento_Costo_Venta(vDesde, vHasta, vCodigo_Alm)
    End Function

    Public Shared Function Asiento_Venta_MM_NC(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vCodigo_Alm As Integer) As DataTable
      Return reportes_ventasBD.Asiento_Venta_MM_NC(vMes, vAnio, vCodigo_Alm)
    End Function

    Public Shared Function Asiento_Venta_PROV_NC(ByVal vCodigo_Alm As Integer, ByVal vProcesar As Boolean, ByVal vMes As Integer,
                                 ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Return reportes_ventasBD.Asiento_Venta_PROV_NC(vCodigo_Alm, vProcesar, vMes, vAnio, vUsuario, vCaja)
    End Function

    Public Shared Function Asiento_Venta_PAGOS_NC(ByVal vCodigo_Alm As Integer, ByVal vProcesar As Boolean, ByVal vMes As Integer,
                                                 ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Return reportes_ventasBD.Asiento_Venta_PAGOS_NC(vCodigo_Alm, vProcesar, vMes, vAnio, vUsuario, vCaja)
    End Function

    Public Shared Function Movimiento_Caja(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal xTipo As Integer) As DataTable
      Dim dtTemp As New DataTable
      If xTipo = 1 Then
        dtTemp = reportes_ventasBD.Det_Movimiento_Caja_Ing(vUsuario, vCodigo_Alm, vDesde, vHasta)
      ElseIf xTipo = 2 Then
        dtTemp = reportes_ventasBD.Det_Movimiento_Caja_Sus(vUsuario, vCodigo_Alm, vDesde, vHasta)
      ElseIf xTipo = 3 Then
        dtTemp = reportes_ventasBD.Movimiento_Caja(vUsuario, vCodigo_Alm, vDesde, vHasta)
      End If

      Return dtTemp
    End Function

    Public Shared Function rptVentasxVendedor(ByVal vUnidadid As Integer, ByVal vAlmacenid As Integer,
                                                   ByVal vDesde As String, ByVal vHasta As String,
                                                   ByVal vVendedorid As Long, ByVal vOpcion As String,
                                                   ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As DataTable

      Return reportes_ventasBD.rptVentasxVendedor(vUnidadid, vAlmacenid, vDesde, vHasta, vVendedorid, vOpcion, vMorosos, vMixto)


    End Function

  End Class
End Namespace