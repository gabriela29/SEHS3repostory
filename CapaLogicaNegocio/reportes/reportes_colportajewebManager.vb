
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class reportes_colportajewebManager
    Public Shared Function Detalle_Documento(ByVal vCodigo As Long) As DataTable
      Return reportes_colpotajewebBD.Pedido_Detalle_Web(vCodigo)
    End Function

    Public Shared Function Resumen_Pedido_Productos(ByVal vCodigo As Long) As DataTable
      Return reportes_colpotajewebBD.Resumen_Pedido_Productos(vCodigo)
    End Function

    '=========Inicio Depósitos =======
    Public Shared Function Deposito_Detalle_Web(ByVal vCodigo As Long) As DataTable
      Return reportes_colpotajewebBD.Deposito_Detalle_Web(vCodigo)
    End Function

    '=======Inicio Devolución Web======
    Public Shared Function Devolucion_Detalle_Web(ByVal vCodigo As Long) As DataTable
      Return reportes_colpotajewebBD.Devolucion_Detalle_Web(vCodigo)
    End Function

  End Class

End Namespace
