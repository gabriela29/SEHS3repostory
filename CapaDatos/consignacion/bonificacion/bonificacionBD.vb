

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class bonificacionBD

        Public Shared Function GetList(ByVal vAlmacenid As Integer, ByVal vTipo As Integer, ByVal vDestino As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pasaldofacturacion_res_cons")
            Dim oConexion As New clsConexion
            Try
                'vunidad integer, valmacenid integer, vpersonaid integer, vdestinoid integer, vtipoid integer
                oSP.addParameter("inunidadid", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inalmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inpersona", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("indestino", vDestino, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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

