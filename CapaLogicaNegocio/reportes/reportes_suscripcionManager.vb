
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class reportes_suscripcionManager
    Public Shared Function Coordinadores_Periodo_Grupo(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer,
                                                       ByVal vnombre As String) As DataTable

      Return reportes_suscripcionBD.Coordinadores_Periodo_Grupo(vperiodoid, vunionid, vmisionid, vnombre)


    End Function

    Public Shared Function Pedidos_Periodo_Grupo(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer,
                                               ByVal vnombre As String) As DataTable

      Return reportes_suscripcionBD.Pedidos_Periodo_Grupo(vperiodoid, vunionid, vmisionid, vnombre)


    End Function

    Public Shared Function Coordinadores_Periodo_Iglesia(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer,
                                                       ByVal vGrupoId As Long, ByVal vnombre As String) As DataTable

      Return reportes_suscripcionBD.Coordinadores_Periodo_Iglesia(vperiodoid, vunionid, vmisionid, vGrupoId, vnombre)


    End Function

    Public Shared Function Pedidos_Agenda_Detalle(ByVal vperiodoid As Integer, ByVal vmaterialid As Integer,
                                                  ByVal vtipopedido As Integer, ByVal vgrupoid As Long, ByVal vMisionid As Integer) As DataTable

      Return reportes_suscripcionBD.Pedidos_Agenda_Detalle(vperiodoid, vmaterialid, vtipopedido, vgrupoid, vMisionid)


    End Function

    Public Shared Function Pedidos_Periodo_Iglesia(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer,
                                       ByVal vGrupoId As Long, ByVal vnombre As String) As DataTable

      Return reportes_suscripcionBD.Pedidos_Periodo_Iglesia(vperiodoid, vunionid, vmisionid, vGrupoId, vnombre)


    End Function

    Public Shared Function Detalle_Deposito(ByVal vDepositoID As Long) As DataTable

      Return reportes_suscripcionBD.Detalle_Deposito(vDepositoID)


    End Function

    Public Shared Function Detalle_Suscripcion(ByVal vsuscripcionid As Long, ByVal viglesiaid As Long, ByVal vperiodo As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersonaid As Long) As DataTable

      Return reportes_suscripcionBD.Detalle_Suscripcion(vsuscripcionid, viglesiaid, vperiodo, vDesde, vHasta, vPersonaid)

    End Function

    Public Shared Function Detalle_Suscripcion_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer,
                                                    ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vsuscripcionid As Long) As DataTable

      Return reportes_suscripcionBD.Detalle_Suscripcion_Fact(vAlmacenid, viglesiaid, vperiodo, vPersonaid, vDM, vsuscripcionid)

    End Function

    Public Shared Function Detalle_Pedido_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer,
                                            ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vPedidoid As Long, ByVal vTipoID As Integer) As DataTable

      Return reportes_suscripcionBD.Detalle_Pedido_Fact(vAlmacenid, viglesiaid, vperiodo, vPersonaid, vDM, vPedidoid, vTipoID)

    End Function

    Public Shared Function rptSuscripcionxVendedor(ByVal vUnidadid As Integer, ByVal viglesiaid As Integer,
                                                   ByVal vDesde As String, ByVal vHasta As String,
                                                   ByVal vVendedorid As Long, ByVal vOpcion As String,
                                                   ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As DataTable

      Return reportes_suscripcionBD.rptSuscripcionxVendedor(vUnidadid, viglesiaid, vDesde, vHasta, vVendedorid, vOpcion, vMorosos, vMixto)


    End Function

    Public Shared Function rptSuscripcionxVendedor_Cons(ByVal vUnidadid As Integer, ByVal viglesiaid As Integer, ByVal vperiodoid As Long,
                                           ByVal vDesde As String, ByVal vHasta As String, ByVal vCantidad As Long,
                                           ByVal vGrupo As String, ByRef dtO As DataTable) As Boolean
      Dim xoK As Boolean = False

      xoK = reportes_suscripcionBD.rptSuscripcionxVendedor_Cons(vUnidadid, viglesiaid, vperiodoid, vDesde, vHasta, vCantidad, vGrupo, dtO)

      Return xoK
    End Function

  End Class
End Namespace


