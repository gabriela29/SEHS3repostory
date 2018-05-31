
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class reportes_pedidosManager
        Public Shared Function Detalle_Pedido(ByVal vsuscripcionid As Long, ByVal vTipoId As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersonaid As Long) As DataTable

            Return reportes_pedidosBD.Detalle_Pedido(vsuscripcionid, vTipoId, viglesiaid, vperiodo, vDesde, vHasta, vPersonaid)


        End Function
    End Class
End Namespace

