Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
  Public Class suscripcionBD
    Public Shared Function GetList(ByVal vAlmacenId As Integer, ByVal viglesiaid As Long,
                                   ByVal vperiodoid As Integer, ByVal vpersonaid As Long, ByVal vDM As Long) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_porfacturar_lista")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("valmacen", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersonaid", vpersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdm", vDM, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'inalmacenid integer,
        'iniglesiaid integer,
        'inperiodoid integer,
        'inpersonaid integer

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetListWeb(ByVal vAlmacenId As Integer, ByVal viglesiaid As Long, ByVal vperiodoid As Integer,
                                      ByVal vpersonaid As Long, ByVal vDesde As String, ByVal vHasta As String,
                                      ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("viglesiaid", viglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersonaid", vpersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vcodigoid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Suscribir(ByVal vPeriodo As Integer, ByVal vsuscripcionid As Long) As DataTable
      Dim TempList As New DataTable
      'vperiodoid integer, vsuscripcionid integer
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_material_periodo_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vperiodoid", vPeriodo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vsuscripcionid", vsuscripcionid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Resumen(ByVal vPeriodo As Integer, ByVal vIglesiaid As Long) As DataTable
      Dim TempList As New DataTable
      'vperiodoid integer, vsuscripcionid integer
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_resumen_material")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vperiodoid", vPeriodo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vIglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Suscribir_cursor(ByVal vAlmacenid As Integer, ByVal vPeriodo As Integer, ByVal vsuscripcionid As Long, ByVal vUsuario As Long,
                                                     ByRef dtDoc As DataTable, ByRef dtSuscrip As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vcodigo integer, vmovimiento integer, vmodulo integer
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("suscripcion.pasuscripcion_material_periodo_leer", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacenid"
        objParam.Value = vAlmacenid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vperiodo"
        objParam.Value = vPeriodo
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "suscripcionid"
        objParam.Value = vsuscripcionid
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vusuario"
        objParam.Value = vUsuario
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtDoc, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtSuscrip, objReader)
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
      Return True
    End Function


    Public Shared Function Agregar(ByRef objIM As Suscripcion, ByVal myArr As String) As DataTable
      Dim vCadena As String = "", xNew As Boolean = True
      If objIM.suscripcionid > 0 Then
        xNew = False
      End If

      Try
        vCadena = "select * from suscripcion.pasuscripcion_actualizar(" & xNew & ","
        vCadena = vCadena & " " & Trim(Str(objIM.suscripcionid)) & ","
        vCadena = vCadena & " '" & Trim(objIM.fecha) & "', "
        vCadena = vCadena & " '" & Trim(objIM.numero) & "', "

        vCadena = vCadena & " " & Trim(Str(objIM.periodoid)) & ","
        vCadena = vCadena & " " & Trim(Str(objIM.iglesiaid)) & ","
        vCadena = vCadena & " " & Trim(Str(objIM.personaid)) & ","
        vCadena = vCadena & " '" & Trim(objIM.observacion) & "', "
        vCadena = vCadena & " " & Trim(myArr) & ", "
        vCadena = vCadena & " " & Trim(Str(objIM.usuarioid)) & ", "
        vCadena = vCadena & " '" & Trim(objIM.ip) & "', "
        vCadena = vCadena & " " & Trim(Str(objIM.diap))
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Agregar = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUs As Long, ByVal vCaja As String) As DataTable


      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_eliminar")
      Try
        oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inus", vUs, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("incaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Eliminar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_cambiar_cerrado")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vsuscripcionid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

    Public Shared Function Cambiar_Usuario(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_cambiar_us")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vsuscripcionid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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


    Public Shared Function GetList_PorFacturar(ByVal vSuscripcionId As Long, ByVal vAlmacenid As Integer) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_porfacturar")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("insuscripcionid", vSuscripcionId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inalmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_PorFacturarBloque(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                                     ByVal vSerie As String, ByVal vNumero As Long,
                                                      ByVal indocumentoid As Integer, ByVal infecha As String,
                                                      ByVal inusuarioid As Long, ByVal incaja As String,
                                                      ByVal vCodigo_Serie As Long, ByVal vGlosa As String, ByVal pDMId As Long) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_porfacturar_bloque")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("inserie", vSerie, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("innumero", vNumero, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("indocumentoid", indocumentoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("infecha", infecha, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("inusuarioid", inusuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("incaja", incaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        oSP.addParameter("inseriid", vCodigo_Serie, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("inglosa", vGlosa, NpgsqlTypes.NpgsqlDbType.Varchar, 220, ParameterDirection.Input)
        oSP.addParameter("indmid", pDMId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function GetList_Facturarados(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                               ByVal vPersonaid As Long, ByVal vDocId As Integer, ByVal vDesde As String,
                                               ByVal vHasta As String, ByVal vNum_Desde As String, ByVal vNum_Hasta As String,
                                               ByVal vDMid As Long) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_facturada")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inpersonaid", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("indocumentoid", vDocId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("indesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("inhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        oSP.addParameter("innumdesde", vNum_Desde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("innumhasta", vNum_Hasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        oSP.addParameter("indmid", vDMid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Actualizar_DP(ByRef vAlmacenid As Integer, ByVal myArr As String) As DataTable
      Dim vCadena As String = "", xNew As Boolean = True

      Try
        vCadena = "select * from suscripcion.pasuscripcion_actualizar_dp("
        vCadena = vCadena & " " & Trim(Str(vAlmacenid)) & ","
        vCadena = vCadena & " " & Trim(myArr)
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Actualizar_DP = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function


    Public Shared Function GetList_Ciclo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                         ByVal vDMid As Long, ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      'suscripcion.pasuscripcion_leer(vinicio integer, vfin integer, viglesiaid integer, vperiodoid integer, vpersonaid integer, vdesde character varying, vhasta character varying)
      Dim oSP As New clsStored_Procedure("suscripcion.pasuscripcion_ciclo_leer")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("inalmacenid", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("iniglesiaid", vIglesiaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inperiodoid", vPeriodoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("indmid", vDMid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("indesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("inhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

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


