
Namespace Dal
  Public Class pedidocolpwebBD
    Public Shared Function Leer_Pedido_Pendiente(ByVal vCampania As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long,
                                                  ByVal vDesde As String, ByVal vHasta As String, ByVal vPendiente As Boolean) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.papedido_pendiente_leer")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vpendiente", vPendiente, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        '
        'vunidad integer, valmacen integer, vcampania integer, vpersona integer, 
        'vdocumento integer, vnumero character varying, vfecha_desde character varying, 
        'vfecha_hasta character varying, vtipo integer)
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
      Dim oSP As New clsStored_Procedure("colportaje.papedido_cambiar_cerrado")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vpedidoid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

    Public Shared Function Facturar_Pedido_Web(ByVal vpedidoid As Long, ByVal valmacenid As Integer, ByVal vserie As String, ByVal vnumero As Long, ByVal vdocumentoid As Integer,
                                               ByVal vfecha As String, ByVal vusuarioid As Long, ByVal vcaja As String, ByVal vserieid As Integer, ByVal vdocumentodid As Integer,
                                               ByVal vseried As String, ByVal vnumerod As Long, ByVal vserieidd As Integer, ByVal vglosa As String) As DataTable
      Dim TempList As New DataTable

      Dim oCn As New clsConexion, vCadena As String
      Try
        vCadena = "select * from colportaje.papedido_porfacturar( "
        vCadena = vCadena & " " & Trim(Str(vpedidoid)) & ","
        vCadena = vCadena & " " & Trim(Str(valmacenid)) & ","
        vCadena = vCadena & " '" & vserie & "',"
        vCadena = vCadena & " " & Trim(Str(vnumero)) & ","
        vCadena = vCadena & " " & Trim(Str(vdocumentoid)) & ","
        vCadena = vCadena & " '" & vfecha & "',"
        vCadena = vCadena & " " & Trim(Str(vusuarioid)) & ","
        vCadena = vCadena & " '" & vcaja & "',"
        vCadena = vCadena & " " & Trim(Str(vserieid)) & ","
        vCadena = vCadena & " " & Trim(Str(vdocumentodid)) & ","
        vCadena = vCadena & " '" & vseried & "',"
        vCadena = vCadena & " " & Trim(Str(vnumerod)) & ","
        vCadena = vCadena & " " & Trim(Str(vserieidd)) & ","
        vCadena = vCadena & " '" & vglosa & "'"

        vCadena = vCadena & " )"

        Dim oConexion As New clsConexion
        TempList = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally

        vCadena = ""
      End Try
      Return TempList
    End Function

  End Class
End Namespace


