Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
  Public Class monedaBD
    Public Shared Function GetList(ByVal vNombre As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As String 'New clsStored_Procedure("basic.parol_leer")
      Dim oConexion As New clsConexion
      Try
        oSP = "select * from basic.patipo_moneda_leer()"
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

