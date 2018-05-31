Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class modulo_sistemaBD
        Public Shared Function GetList() As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("pamodulo_sistema_leer")
            Dim oConexion As New clsConexion
            Try
                'oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)
                'oSP.addParameter("incodigo_cat", vCodigo_Cat, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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
