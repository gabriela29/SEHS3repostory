Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class pedidoBD
        Public Shared Function GetList_Tipo(ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.patipopedido_leer(-1)")
            Dim oConexion As New clsConexion
            Try

                'oSP.addParameter("vnombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList(ByVal vTipo As Integer, ByVal viglesiaid As Long, ByVal vperiodoid As Integer, _
                                ByVal vpersonaid As Long, ByVal vdesde As String, ByVal vhasta As String) As DataTable
            Dim TempList As New DataTable
            'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.papedido_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vinicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vtipopedido", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersonaid", vpersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.papedido_cambiar_cerrado")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vpedidoid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_PorFacturar(ByVal inpedidoid As Long, ByVal inalmacenid As Integer) As DataTable
            Dim TempList As New DataTable
            'suscripcion.papedido_porfacturar_lista(inpedidoid integer, iniglesiaid integer, inperiodoid integer, inalmacenid integer, ingrupoid integer,
            'inunidadnegocioid integer, intipopedidoid integer)

            Dim oSP As New clsStored_Procedure("suscripcion.papedido_porfacturar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inpedidoid", inpedidoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inalmacenid", inalmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_PorFacturar_Lista(ByVal inpedidoid As Long, ByVal iniglesiaid As Long, ByVal inperiodoid As Integer, _
                                                         ByVal inalmacenid As Integer, ByVal ingrupoid As Long, ByVal inunidadnegocioid As Integer, _
                                                         ByVal intipopedidoid As Integer) As DataTable
            Dim TempList As New DataTable
            'suscripcion.papedido_porfacturar_lista(inpedidoid integer, iniglesiaid integer, inperiodoid integer, inalmacenid integer, ingrupoid integer,
            'inunidadnegocioid integer, intipopedidoid integer)

            Dim oSP As New clsStored_Procedure("suscripcion.papedido_porfacturar_lista")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inpedidoid", inpedidoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("iniglesiaid", iniglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inperiodoid", inperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inalmacenid", inalmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("ingrupoid", ingrupoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inunidadnegocioid", inunidadnegocioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipopedidoid", intipopedidoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_PorFacturarBloque(ByVal vPedidoId As Long, ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer, _
                                                 ByVal vSerie As String, ByVal vNumero As Long, _
                                                  ByVal indocumentoid As Integer, ByVal infecha As String, _
                                                  ByVal inusuarioid As Long, ByVal incaja As String, _
                                                  ByVal vCodigo_Serie As Long, ByVal vGlosa As String, ByVal pDMId As Long, _
                                                  ByVal pUnidadId As Integer, ByVal pTipoId As Integer) As DataTable
            Dim TempList As New DataTable
            Dim vFuncion As String = ""
            'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
            If pTipoId = 0 Then
                vFuncion = "suscripcion.papedido_porfacturar_bloque"
            Else
                vFuncion = "suscripcion.papedido_porfacturar_bloqueb"
            End If

            Dim oSP As New clsStored_Procedure(vFuncion)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inpedidoid", vPedidoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("indmid", pDMId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inunidadid", pUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipopedidoid", pTipoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inserie", vSerie, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("innumero", vNumero, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("indocumentoid", indocumentoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("infecha", infecha, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("inusuarioid", inusuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("incaja", incaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inseriid", vCodigo_Serie, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Facturarados(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer, _
                                           ByVal vPersonaid As Long, ByVal vDocId As Integer, ByVal vDesde As String, _
                                           ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                                           ByVal vDMid As Long, ByVal vUnidadid As Integer, ByVal vTipo As String) As DataTable
            Dim TempList As New DataTable
            'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.papedido_facturado")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inpersonaid", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("indocumentoid", vDocId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("indesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("inhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("innumdesde", vNumDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("innumhasta", vNumHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("indmid", vDMid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inunidadid", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function GetList_Ciclo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                     ByVal vDMid As Long, ByVal vTipo As Integer) As DataTable
      Dim TempList As New DataTable

      Dim oSP As New clsStored_Procedure("suscripcion.papedido_ciclo_leer")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("indmid", vDMid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipopedidoid", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Ciclo_saldo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                 ByVal vDMid As Long, ByVal vTipo As Integer, ByVal vProductoid As Long, ByVal vAll As Boolean) As DataTable
      Dim TempList As New DataTable

      Dim oSP As New clsStored_Procedure("suscripcion.papedido_ciclo_saldo")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("indmid", vDMid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipopedidoid", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inproductoid", vProductoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inall", vAll, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

  End Class
End Namespace
