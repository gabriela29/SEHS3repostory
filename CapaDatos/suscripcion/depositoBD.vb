Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class depositoBD
        Public Shared Function GetList(ByVal vUnidadid As Integer, ByVal vDMId As Long, ByVal viglesiaid As Long, ByVal vperiodoid As Integer, _
                                       ByVal vresponsableid As Long, ByVal vdesde As String, ByVal vhasta As String, ByVal vOpcion As String, ByVal vTipo As Integer) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            'Dim oSP As New clsStored_Procedure("suscripcion.padeposito_pendiente_leer")
            Dim vCadena As String = ""

            Try
                vCadena = "select * from suscripcion.padeposito_pendiente_leer("
                vCadena = vCadena & " " & Trim(Str(vUnidadid)) & ","
                vCadena = vCadena & " " & Trim(Str(vDMId)) & ","
                vCadena = vCadena & " " & Trim(Str(viglesiaid)) & ","
                vCadena = vCadena & " " & Trim(Str(vperiodoid)) & ","
                vCadena = vCadena & " " & Trim(Str(vresponsableid)) & ","
                vCadena = vCadena & " '" & Trim(vdesde) & "',"
                vCadena = vCadena & " '" & Trim(vhasta) & "',"
                vCadena = vCadena & " '" & Trim(vOpcion) & "',"
                vCadena = vCadena & " " & Trim(Str(vTipo)) & ") "                
                Dim oConexion As New clsConexion
                TempList = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
            Finally
                vCadena = ""
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Facturados(ByVal vAlmacen As Integer, ByVal vUnidadid As Integer, ByVal vDMId As Long, ByVal viglesiaid As Long, ByVal vperiodoid As Integer, _
                               ByVal vresponsableid As Long, ByVal vdesde As String, ByVal vhasta As String, ByVal vTipo As Integer, ByVal vTipoDoc As Integer) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim vCadena As String = ""

            Try
                vCadena = "select * from suscripcion.padeposito_facturado_leer("
                vCadena = vCadena & " " & Trim(Str(vAlmacen)) & ","
                vCadena = vCadena & " " & Trim(Str(vUnidadid)) & ","
                vCadena = vCadena & " " & Trim(Str(vDMId)) & ","
                vCadena = vCadena & " " & Trim(Str(viglesiaid)) & ","
                vCadena = vCadena & " " & Trim(Str(vperiodoid)) & ","
                vCadena = vCadena & " " & Trim(Str(vresponsableid)) & ","
                vCadena = vCadena & " '" & Trim(vdesde) & "',"
                vCadena = vCadena & " '" & Trim(vhasta) & "',"
                vCadena = vCadena & " " & Trim(Str(vTipo)) & ","
                vCadena = vCadena & " " & Trim(Str(vTipoDoc)) & ") "

                'oSP.addParameter("vAlmacenid", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vUnidadid", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vDMId", vDMId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vresponsableid", vresponsableid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                'oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                'oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vtipodoc", vTipoDoc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Dim oConexion As New clsConexion                
                TempList = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
            Finally
                vCadena = ""

            End Try
            Return TempList
        End Function

        Public Shared Function GetList_DxM(ByVal viglesiaid As Long, ByVal vperiodoid As Integer) As DataTable
            Dim TempList As New DataTable
            'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.padeposito_resumen_miembros")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_DSS(ByVal vdistrotid As Integer, ByVal viglesiaid As Long, ByVal vperiodoid As Integer) As DataTable
            Dim TempList As New DataTable
            'vdistrotid integer, viglesiaid integer, vperiodoid integer
            Dim oSP As New clsStored_Procedure("suscripcion.padeposito_sin_suscripcion")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vdistrotid", vdistrotid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Detalle(ByVal vDepositoID As Long, ByVal vTipo As String) As DataTable
            Dim TempList As New DataTable
            Dim vFunction As String = ""

            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            If vTipo = "PA" Then
                vFunction = "suscripcion.padeposito_detalle_leer"
            Else
                vFunction = "suscripcion.papedidoabonovariosdetalle_consulta"
            End If

            Dim oSP As New clsStored_Procedure(vFunction)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vdepositoid", vDepositoID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Cambiar_Estado(ByVal vUsuario As Long, ByVal vCaja As String, myArr As String, ByVal vTipo As String) As DataTable
            Dim vCadena As String = "", vFunction As String = ""

            If vTipo = "" Then
                vFunction = "suscripcion.padeposito_cambiar_cerrado"
            Else
                vFunction = "suscripcion.papedidoabonovarios_cambiar_cerrado"
            End If

            Try
                vCadena = "select * from " & vFunction & "("
                vCadena = vCadena & " " & Trim(Str(vUsuario)) & ","
                vCadena = vCadena & " '" & Trim(vCaja) & "', "
                vCadena = vCadena & " " & Trim(myArr) & ") "

                Dim oConexion As New clsConexion
                Cambiar_Estado = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

    End Class
End Namespace


