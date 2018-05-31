

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class reportes_pedidosBD

        Public Shared Function Detalle_Pedido(ByVal vsuscripcionid As Long, ByVal vTipo As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer, _
                                            ByVal vDesde As String, ByVal vHasta As String, ByVal vPersonaid As Long) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.papedido_detalle_reporte")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vsuscripcionid", vsuscripcionid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vtipoid", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

    End Class
End Namespace

