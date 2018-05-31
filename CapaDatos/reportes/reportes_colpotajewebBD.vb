Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
  Public Class reportes_colpotajewebBD
    Public Shared Function Pedido_Detalle_Web(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.papedido_reporte_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Resumen_Pedido_Productos(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.papedido_reporte_res")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function
    '========== Fin Pedido Web Colportaje ===============


    '===========Inicio Depósito Web Colportaje ===============
    Public Shared Function Deposito_Detalle_Web(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.padeposito_detalle_reporte")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    '========Inicio Devoluciones Web=============================
    Public Shared Function Devolucion_Detalle_Web(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.padevolucion_asis_reporte_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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
