
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal

    Public Class distrito_misioneroBD

        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String, ByVal vMisionId As Integer, ByVal vdepartamentoid As Long) As DataTable
            Dim TempList As New DataTable
            'suscripcion.pagrupo_leer(vinicio integer, vfin integer, vunionid integer, vmisionid integer, vnombre character varying, vdepartamentoid integer)
            Dim oSP As New clsStored_Procedure("suscripcion.pagrupo_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("ininicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("infin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inunion", vUnion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmisionid", vMisionId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inNombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("indepartamentoid", vdepartamentoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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