Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class reportes_consignacionManager
    Public Shared Function Detalle_Documento(ByVal vCodigo As Long) As DataTable
      Return reportes_consignacionBD.Datos_Impresion_Dzmo(vCodigo)
    End Function

    Public Shared Function Datos_Impresion_Dzmo_PWC(ByVal vCodigo As Long) As DataTable
      Return reportes_consignacionBD.Datos_Impresion_Dzmo_PWC(vCodigo)
    End Function

    Public Shared Function Detalle_Guia(ByVal vCodigo As Long) As DataTable
      Return reportes_consignacionBD.Detalle_Guia(vCodigo)
    End Function

    Public Shared Function rptKardex(ByVal vAlmacen As Integer, ByVal vProducto As Long,
                                       ByVal vDesde As String, ByVal vHasta As String,
                                       ByVal vPersona As Long) As DataTable
      Return reportes_consignacionBD.rptKardex(vAlmacen, vProducto, vDesde, vHasta, vPersona)
    End Function

    Public Shared Function rptStock(ByVal vAlmacen As Integer, ByVal vAsistente As Long, ByVal vDesde As String, ByVal vHasta As String,
                                    ByVal vTipo As Integer, ByVal vOpcion As String, ByVal vCampaniaId As Integer) As DataTable
      Return reportes_consignacionBD.rptStock(vAlmacen, vAsistente, vDesde, vHasta, vTipo, vOpcion, vCampaniaId)
    End Function


  End Class

End Namespace

