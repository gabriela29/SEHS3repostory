Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class campaniaBD
    Public Shared Function Campania_leer(ByVal vNombre As String) As DataTable

      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.pacampania_leer()")
      Dim oConexion As New clsConexion
      Try
        'colportaje.paproductos_campania_leer(vano integer, valmacen integer, vcampania integer)
        'oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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

