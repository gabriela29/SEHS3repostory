
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class reportes_suscripcionBD

        Public Shared Function Coordinadores_Periodo_Grupo(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer, _
                                                           ByVal vnombre As String) As DataTable

            Dim vConsulta As String
            'suscripcion.paperiodo_grupo_reporte(vperiodoid integer, vunionid integer, vmisionid integer, vnombre character varying)
            Try
                vConsulta = "select * from suscripcion.paperiodo_grupo_reporte("
                vConsulta = vConsulta & " " & Trim(Str(vperiodoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vmisionid)) & ","

                vConsulta = vConsulta & " '" & Trim(vnombre) & "' "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Coordinadores_Periodo_Grupo = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Coordinadores_Periodo_Grupo
        End Function

        Public Shared Function Pedidos_Periodo_Grupo(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer, _
                                                   ByVal vnombre As String) As DataTable

            Dim vConsulta As String
            'suscripcion.paperiodo_grupo_reporte(vperiodoid integer, vunionid integer, vmisionid integer, vnombre character varying)
            Try
                vConsulta = "select * from suscripcion.papedidos_periodo_grupo_reporte("
                vConsulta = vConsulta & " " & Trim(Str(vperiodoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vmisionid)) & ","

                vConsulta = vConsulta & " '" & Trim(vnombre) & "' "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Pedidos_Periodo_Grupo = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Pedidos_Periodo_Grupo
        End Function

        Public Shared Function Coordinadores_Periodo_Iglesia(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer, _
                                                             ByVal vgrupoid As Long, ByVal vnombre As String) As DataTable

            Dim vConsulta As String
            'suscripcion.paperiodo_iglesia_reporte(vperiodoid integer, vunionid integer, vmisionid integer, vgrupoid integer, vnombre character varying)
            Try
                vConsulta = "select * from suscripcion.paperiodo_iglesia_reporte("
                vConsulta = vConsulta & " " & Trim(Str(vperiodoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vmisionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vgrupoid)) & ","

                vConsulta = vConsulta & " '" & Trim(vnombre) & "' "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Coordinadores_Periodo_Iglesia = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Coordinadores_Periodo_Iglesia
        End Function

        Public Shared Function Pedidos_Periodo_Iglesia(ByVal vperiodoid As Integer, ByVal vunionid As Integer, ByVal vmisionid As Integer, _
                                                     ByVal vgrupoid As Long, ByVal vnombre As String) As DataTable

            Dim vConsulta As String
            'suscripcion.paperiodo_iglesia_reporte(vperiodoid integer, vunionid integer, vmisionid integer, vgrupoid integer, vnombre character varying)
            Try
                vConsulta = "select * from suscripcion.paperiodo_pedido_iglesia_reporte("
                vConsulta = vConsulta & " " & Trim(Str(vperiodoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vmisionid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vgrupoid)) & ","

                vConsulta = vConsulta & " '" & Trim(vnombre) & "' "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Pedidos_Periodo_Iglesia = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Pedidos_Periodo_Iglesia
        End Function

        Public Shared Function Pedidos_Agenda_Detalle(ByVal vperiodoid As Integer, ByVal vmaterialid As Integer, _
                                                      ByVal vtipopedido As Integer, ByVal vgrupoid As Long, ByVal vMisionid As Integer) As DataTable

            Dim vConsulta As String
            'suscripcion.pareporte_pedido_material_detalle(vpedidoid integer, vmaterialid integer, vtipopedido integer)
            Try
                vConsulta = "select * from suscripcion.pareporte_pedido_material_detalle("
                vConsulta = vConsulta & " " & Trim(Str(vperiodoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vmaterialid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vtipopedido)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vgrupoid)) & ", "
                vConsulta = vConsulta & " " & Trim(Str(vMisionid)) & " "
                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Pedidos_Agenda_Detalle = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Pedidos_Agenda_Detalle
        End Function

        Public Shared Function Detalle_Deposito(ByVal vDepositoId As Long) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.padeposito_detalle_reporte")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vDepositoId", vDepositoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Detalle_Suscripcion(ByVal vsuscripcionid As Long, ByVal viglesiaid As Long, ByVal vperiodo As Integer, _
                                                    ByVal vDesde As String, ByVal vHasta As String, ByVal vPersonaid As Long) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_detalle_reporte")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vsuscripcionid", vsuscripcionid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodo", vperiodo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Detalle_Suscripcion_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer, _
                                                        ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vsuscripcionid As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_facturarado_rpt")
            Dim oConexion As New clsConexion

            Try
                oSP.addParameter("valmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodo", vperiodo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdmid", vDM, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsuscripcionid", vsuscripcionid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Public Shared Function Detalle_Pedido_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer, _
                                                    ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vpedidoid As Long, ByVal vTipoID As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.papedido_facturarado_rpt")
            Dim oConexion As New clsConexion

            Try
                oSP.addParameter("valmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodo", vperiodo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdmid", vDM, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpedidoid", vpedidoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vtipoid", vTipoID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Public Shared Function rptSuscripcionxVendedor(ByVal vUnidadid As Integer, ByVal viglesiaid As Integer, _
                                                       ByVal vDesde As String, ByVal vHasta As String, _
                                                       ByVal vVendedorid As Long, ByVal vOpcion As String, _
                                                       ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcionxvendedor")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidadid", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vpersona", vVendedorid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vmorosos", vMorosos, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmixto", vMixto, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function rptSuscripcionxVendedor_Cons(ByVal vUnidadid As Integer, ByVal viglesiaid As Integer, ByVal vperiodoid As Long, _
                                               ByVal vDesde As String, ByVal vHasta As String, ByVal vCantidad As Long, _
                                               ByVal vGrupo As String, ByRef dtO As DataTable) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion
            'vcodigo integer, vmovimiento integer, vmodulo integer
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("suscripcion.pareporte_suscripcion_cons_usuario", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vUnidadid"
                objParam.Value = vUnidadid
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "viglesiaid"
                objParam.Value = viglesiaid
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vperiodoid"
                objParam.Value = vperiodoid
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vDesde"
                objParam.Value = vDesde
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vhasta"
                objParam.Value = vHasta
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vcantidad"
                objParam.Value = vCantidad
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vgrupo"
                objParam.Value = vGrupo
                objCmd.Parameters.Add(objParam)


                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtO, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()

                objReader.Close()

                CType(objReader, IDisposable).Dispose()
                objCmd = Nothing
                objReader = Nothing
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return True
        End Function

    End Class
End Namespace

