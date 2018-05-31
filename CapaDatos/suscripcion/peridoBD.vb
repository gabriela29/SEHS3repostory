Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class peridoBD
        Public Shared Function GetList(ByVal vInicio As Integer, ByVal vFin As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
            Dim oSP As New clsStored_Procedure("suscripcion.paperiodo_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vinicio", vInicio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfin", vFin, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

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

