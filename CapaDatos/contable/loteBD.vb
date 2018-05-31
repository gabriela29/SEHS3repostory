
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class loteBD

    Public Shared Function GetItem(ByVal vLoteID As Long) As lote
      Dim objLG As lote = Nothing
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.palote_getrow")
      Dim oConexion As New clsConexion
      Dim objReader As DataRow
      Try

        oSP.addParameter("inloteid", vLoteID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        objReader = Nothing
        If TempList.Rows.Count > 0 Then
          objReader = TempList.Rows(0)
        End If
        Try
          If Not objReader Is Nothing Then
            objLG = LlenarDatosRegistro(objReader)
          End If
        Finally
          objReader = Nothing
        End Try
      Finally
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return objLG
    End Function

    Public Shared Function GetList(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vTipoId As Integer, ByVal vBusca As String,
                                   ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vFicha As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.palote_consulta")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("incodigo_uni", vCodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipoid", vTipoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innombre", vBusca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inficha", vFicha, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Detalle(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("contable.palote_detalle_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As lote
      Dim objeto As lote = New lote
      objeto.loteid = objData.Item("loteid")
      objeto.almacenid = objData.Item("almacenid")
      objeto.tipoloteid = objData.Item("tipoloteid")
      objeto.nombre = objData.Item("nombre")
      objeto.mes = objData.Item("mes")
      objeto.anio = objData.Item("anio")
      objeto.estado = objData.Item("estado")
      Return objeto

    End Function

    Public Shared Function Grabar(ByRef objlote As lote) As DataTable
      Dim oSP As New clsStored_Procedure("contable.palote_actualizar")
      Try
        If objlote.loteid = -1 Then
          oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        Else
          oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        End If
        oSP.addParameter("inloteid", objlote.loteid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("intipoloteid", objlote.tipoloteid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("inalmacenid", objlote.almacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("innombre", objlote.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        oSP.addParameter("inmes", objlote.mes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("inanio", objlote.anio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("inestado", objlote.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        oSP.addParameter("inusuarioid", objlote.usuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

        oSP.addParameter("incaja", objlote.caja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Grabar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Grabar_Detalle(ByVal vLote_Id As Long, ByVal vArray As String, ByVal vUsID As Long, ByVal vCaja As String) As DataTable
      Dim vConsulta As String

      Try
        vConsulta = "select * from contable.palote_detalle_actualizar ("

        vConsulta = vConsulta & vLote_Id & ","

        vConsulta = vConsulta & vArray & ","

        vConsulta = vConsulta & vUsID & ",'"

        vConsulta = vConsulta & vCaja & "');"

        Dim oConexion As New clsConexion
        Grabar_Detalle = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Procesar_Lote_Gasto_Asientos(ByVal vLote As Long, ByVal DtProvision As DataTable, ByVal dtPagos As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String, xOk As Boolean = False
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.palote_gastos_procesar_asientos", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vlote"
        objParam.Value = vLote
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(DtProvision, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtPagos, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()

      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return xOk
    End Function

    Public Shared Function Asiento_Assinet_Actualizar(ByVal vLote As Long, ByVal vEntidad As Integer, ByVal Lote_Assinet As Long, ByVal vGuid As String, ByVal vTypej As String, ByVal vTipo As String) As DataTable
      Dim TempList As New DataTable

      Dim vFun As String = "contable.paasiento_lote_assinet_actualizar"

      Dim oSP As New clsStored_Procedure(vFun)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("loteid", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("entidad", vEntidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("cod_lote", Lote_Assinet, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("guid", vGuid, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)
        oSP.addParameter("typej", vTypej, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        TempList = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar_Asiento(ByVal codigo As Long, ByVal vUsuarioID As Long, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure("contable.paasiento_lote_eliminar")
      Try
        oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuarioid", vUsuarioID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Eliminar_Asiento = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Eliminar_Lote(ByVal codigo As Long, ByVal vUsuarioID As Long, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure("contable.palote_eliminar")
      Try
        oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSP.addParameter("vusuarioid", vUsuarioID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Eliminar_Lote = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Asiento_Lote(ByVal vLote As Long, ByVal vProcesar As Boolean) As DataTable
      Dim TempList As New DataTable

      Dim vFun As String = "contable.paasiento_lote"

      Dim oSP As New clsStored_Procedure(vFun)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        TempList = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Asiento_Procesado(ByVal vLote As Long) As DataTable
      Dim TempList As New DataTable

      Dim vFun As String = "contable.paasiento_lote_procesado"

      Dim oSP As New clsStored_Procedure(vFun)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function
  End Class
End Namespace

