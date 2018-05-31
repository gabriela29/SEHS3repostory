
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class misionBD

        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            'suscripcion.pamision_leer(vinicio integer, vfin integer, vunionid integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.pamision_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("ininicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("infin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("inunion", vUnion, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("inNombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

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

