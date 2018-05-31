Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class comision_spBD
    Public Shared Function GetList(ByVal vNombre As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("pacomision_sp_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList

    End Function

    Public Shared Function Consulta(ByVal vnombre As String, ByVal vcategoria As Integer, ByVal vsolo_activos As Boolean, ByVal vlimit As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("paconsulta_comision_sp")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vnombre", vnombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vcategoria", vcategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vsolo_activos", vsolo_activos, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        oSP.addParameter("vlimit", vlimit, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function


    Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
      Dim oSP As New clsStored_Procedure("pacomision_sp_eliminar")
      Try
        oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        Dim oConexion As New clsConexion
        Eliminar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function
  End Class
End Namespace