Imports CapaObjetosNegocio.BO
Namespace Dal
  Public Class devolucionasiswebBD
    Public Shared Function Leer_Dev_Asis_Pendiente(ByVal vCampania As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long,
                                              ByVal vDesde As String, ByVal vHasta As String, ByVal vEs_NC As Boolean, ByVal vPendiente As Boolean) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.padevolucion_asis_pendiente_leer")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vesnc", vEs_NC, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        oSP.addParameter("vpendiente", vPendiente, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        '

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Cambiar_Cerrado(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.padevolucion_asis_cambiar_cerrado")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vdevolucionid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
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

