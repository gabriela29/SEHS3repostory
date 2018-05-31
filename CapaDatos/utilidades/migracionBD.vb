Namespace Dal
  Public Class migracionBD
    Public Shared Function GetList(ByVal vano_origen As String) As DataTable

      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("pamigracion_leer")
      Dim oConexion As New clsConexion

      Try
        oSP.addParameter("vopcion", vano_origen, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

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

