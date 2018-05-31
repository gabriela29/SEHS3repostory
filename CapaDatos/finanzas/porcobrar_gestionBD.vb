Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class porcobrar_gestionBD
    Public Shared Function porcobrar_Gestion_Leer(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                    ByVal vOpcion As String, ByVal vPersona As Long, ByVal vUs As Long, ByVal vNumCarta As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.pagestion_porcobrar_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuario", vUs, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vnumcarta", vNumCarta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Grabar(ByRef objPG As porcobrar_gestion) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from finanzas.paporcobrar_gestion_actualizar(true,"
        vConsulta = vConsulta & Trim(Str(objPG.Porcobrarid)) & ", "
        vConsulta = vConsulta & Trim(Str(objPG.Num_Carta)) & ",'"

        vConsulta = vConsulta & Trim(objPG.Emision) & "',"
        vConsulta = vConsulta & Trim(Str(objPG.Ndias)) & ","
        vConsulta = vConsulta & Trim(Str(objPG.Deuda)) & ","
        vConsulta = vConsulta & Trim(Str(objPG.Adicional)) & ","
        vConsulta = vConsulta & Trim(Str(objPG.Responsableid)) & ","
        vConsulta = vConsulta & Trim(Str(objPG.Estado)) & ",'"
        vConsulta = vConsulta & Trim(objPG.Observacion) & "',"
        vConsulta = vConsulta & Trim(Str(objPG.UsuarioId)) & ",'"
        vConsulta = vConsulta & Trim(objPG.caja) & "'"


        vConsulta = vConsulta & ")"

        Dim oConexion As New clsConexion
        Grabar = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vNum_Carta As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure("finanzas.finanzas.paporcobrar_gestion_eliminar")
      Try
        oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innumcarta", vNum_Carta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSP.addParameter("inusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        'oSP.addParameter("incaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

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

