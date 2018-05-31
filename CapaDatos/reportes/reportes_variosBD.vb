
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class reportes_variosBD
        Public Shared Function Listado_Documentos_Emitidos(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vdocumento As Integer, ByVal vpersona As Long, _
                                                            ByVal vdesde As String, ByVal vhasta As String, ByVal vIM As Boolean, vConsig As Boolean, _
                                                            ByVal vVta As Boolean, ByVal vSM As Boolean) As DataTable
            Dim vCuenta As Integer = 0
            'inventarios.pareporte_guias_emitidas(vunidad integer, valmacen integer, vdocumento integer, vpersona integer, vdesde character varying, vhasta character varying)
            Dim oSP As New clsStored_Procedure("inventarios.pareporte_guias_emitidas")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vCodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("vIM", vIM, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vConsig", vConsig, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vVta", vVta, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vSM", vSM, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                Listado_Documentos_Emitidos = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Listado_Documentos_Emitidos
        End Function
    End Class
End Namespace

