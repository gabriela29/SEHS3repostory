Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class por_cobrarBD
    Public Shared Function Leer_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                        ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_leer_res")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Leer_Rest(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                        ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_leer_rest")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Grabar(ByRef objPC As por_cobrar) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from finanzas.paporcobrar_actualizar(true,"
        vConsulta = vConsulta & " 0,"
        vConsulta = vConsulta & Trim(Str(objPC.Codigo_Almacen)) & ", "
        vConsulta = vConsulta & Trim(Str(objPC.Codigo_Persona)) & ","
        vConsulta = vConsulta & Trim(Str(objPC.Codigo_Documento)) & ",'"
        vConsulta = vConsulta & Trim(objPC.Numero) & "','"
        vConsulta = vConsulta & Trim(objPC.condicion) & "','"
        vConsulta = vConsulta & Trim(objPC.Letra) & "',"
        vConsulta = vConsulta & Trim(Str(objPC.Renovacion)) & ",'"

        vConsulta = vConsulta & (objPC.fecha) & "','"
        vConsulta = vConsulta & (objPC.Vencimiento) & "',"
        vConsulta = vConsulta & Trim(Str(objPC.Importe)) & ","
        vConsulta = vConsulta & Trim(Str(objPC.Saldo)) & ",'"
        vConsulta = vConsulta & Trim(objPC.Moneda) & "',"
        vConsulta = vConsulta & Trim(Str(objPC.Cambio)) & ",'"

        vConsulta = vConsulta & Trim(objPC.Signo) & "','"
        vConsulta = vConsulta & Trim(objPC.Observacion) & "','"

        vConsulta = vConsulta & Trim(objPC.Referencia_Exterior) & "',"
        vConsulta = vConsulta & Trim(Str(objPC.Codigo1_RefExt)) & ","
        vConsulta = vConsulta & Trim(Str(objPC.Codigo2_RefExt)) & ","
        vConsulta = vConsulta & Trim(Str(objPC.UsuarioId)) & ",'"
        vConsulta = vConsulta & Trim(objPC.caja) & "',"
        vConsulta = vConsulta & IIf(objPC.Cerrado, "true", "false") & ","
        vConsulta = vConsulta & IIf(objPC.Estado, "true", "false") & ","

        vConsulta = vConsulta & IIf(objPC.Incluir_Registro, "true", "false") & ",'"
        vConsulta = vConsulta & Trim(objPC.NroCuenta) & "','"
        vConsulta = vConsulta & Trim(objPC.C_Costo) & "'"

        vConsulta = vConsulta & ")"

        'innew boolean, inporcobrarid integer, inalmacenid integer, inclienteid integer, indocumentoid integer, 
        'innumero character varying, incondicion character varying, inletra character varying, inrenovacion integer, 
        'infecha date, invencimiento date, inimporte numeric, insaldo numeric, inmoneda character varying, incambio numeric, 
        'insigno character varying, inobservacion character varying, inreferencia character varying, incodigo_ref1 integer, 
        'incodigo_ref2 integer, inusuarioid integer, incaja character varying, incerrado boolean, inestado boolean, 
        'inincluir_registro boolean, innroctamaestra character varying, inc_costo character varying

        'vArray_DT

        Dim oConexion As New clsConexion
        Grabar = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Leer_Detalles(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                         ByVal vOpcion As Integer, ByVal vPersona As Long, ByVal dtCabecera As DataTable,
                                         ByVal dtDetalle As DataTable, dtAnticipo As DataTable) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion

      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paporcobrar_leer_det", objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vunidad"
        objParam.Value = vUnidad
        objCmd.Parameters.Add(objParam)

        'objParam.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "valmacen"
        objParam.Value = vAlmacen
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vhasta"
        objParam.Value = vhasta
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vOpcion"
        objParam.Value = vOpcion
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vpersona"
        objParam.Value = vPersona
        objCmd.Parameters.Add(objParam)


        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtCabecera, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtDetalle, objReader)
        objReader.NextResult()

        dar.FillFromReader(dtAnticipo, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()
        t = Nothing
        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
        objCon.ClearPool()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      objCon = Nothing

      Return True
    End Function

    Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("paporcobrar_experian")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptPorCobrar_Res(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                            ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim TempList As New DataTable
      'Dim oSP As New clsStored_Procedure("pareporte_list_cxc")  pac_x_c_list_colp
      Dim oSP As New clsStored_Procedure("finanzas.pac_x_c_list_res")
      Dim oConexion As New clsConexion
      Try
        'If Not vDesde = "" Then
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        'End If
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptPorCobrar_Res_Colp(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                                ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim TempList As New DataTable
      'Dim oSP As New clsStored_Procedure("pareporte_list_cxc")  pac_x_c_list_colp
      Dim oSP As New clsStored_Procedure("finanzas.pac_x_c_list_res_colp")
      Dim oConexion As New clsConexion
      Try
        'If Not vDesde = "" Then
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        'End If
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptPorCobrar_Ndias(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vUnidad As Integer,
                                                    ByVal vCodigo_Alm As Integer, ByVal vPersona As Long, ByVal vOpcion As String, ByVal vUsuario As Long) As DataTable
      Dim TempList As New DataTable
      'finanzas.paporcobrar_diasvencidos(vunidad integer, valmacen integer, vhasta character varying, vopcion integer, vpersona integer)
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_diasvencidos")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vsuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptPorCobrar_Res_Cons(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                    ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim TempList As New DataTable
      'Dim oSP As New clsStored_Procedure("pareporte_list_cxc")  pac_x_c_list_colp
      Dim oSP As New clsStored_Procedure("finanzas.pac_x_c_list_res_cons")
      Dim oConexion As New clsConexion
      Try
        'If Not vDesde = "" Then
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        'End If
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptPorCobrar_Res_gp(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long,
                                                    ByVal vUnidadId As Integer, ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim TempList As New DataTable
      'Dim oSP As New clsStored_Procedure("pareporte_list_cxc")  pac_x_c_list_colp
      Dim oSP As New clsStored_Procedure("finanzas.pac_x_c_list_resgp")
      Dim oConexion As New clsConexion
      Try
        'If Not vDesde = "" Then
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        'End If
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vUnidadid", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptSaldo_Prod_Fact(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      'colportaje.pasaldofacturacion(vAlmacenId integer,  vPersonaid integer, vHastas character varying)
      Dim oSP As New clsStored_Procedure("colportaje.pasaldofacturacion")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("valmacen", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptSaldo_Prod_Fact(ByVal vFuncion As String, ByVal vAlmacenId As Integer, ByVal vPersonaid As Long,
                                              ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      'colportaje.pasaldofacturacion(vAlmacenId integer,  vPersonaid integer, vHastas character varying)
      '"colportaje.pasaldofacturacion"
      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("valmacen", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptImporte_Prod_Fact(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      'colportaje.pasaldofacturacion(vAlmacenId integer,  vPersonaid integer, vHastas character varying)
      Dim oSP As New clsStored_Procedure("colportaje.pasaldofacturacion")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("valmacen", vAlmacenId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function


    Public Shared Function RptEstado_Cuenta(ByVal vFuncion As String, ByVal vPersona As Long, ByVal vCodigo_Alm As Integer, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)



        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function RptEstado_Cuenta2(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                              ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable

      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paestado_cuenta_02")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList

    End Function

    Public Shared Function Info_Sehs(ByVal vPersona As Long, ByVal vDocumento As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.painfosehs")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdocumento", vDocumento, NpgsqlTypes.NpgsqlDbType.Varchar, 11, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Obtener_Tipo_Documento(ByVal vEmpresa As Integer, ByVal vUnidad As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("paalmacen_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inempresa", vEmpresa, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
        oSP.addParameter("inunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_eliminar")
      Try
        oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("incaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Eliminar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function PorCobrarCartaG(ByVal vCodigo As Long, ByVal vNum_Carta As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_carta")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inporcobrarid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innumcarta", vNum_Carta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function PorCobrarCarta(ByVal vPersonaid As Long, ByVal vUnidadId As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_carta")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inpersonaid", vPersonaid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inunidadid", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Actualizar_DP(ByRef vAlmacenid As Integer, ByVal myArr As String, ByVal vReferencia As String) As DataTable
      Dim vCadena As String = "", xNew As Boolean = True

      Try
        vCadena = "select * from finanzas.paporcobrar_actualizar_dp("
        vCadena = vCadena & " " & Trim(Str(vAlmacenid)) & ","
        vCadena = vCadena & " " & Trim(myArr) & ","
        vCadena = vCadena & " '" & Trim(vReferencia) & "'"
        vCadena = vCadena & ")"

        Dim oConexion As New clsConexion
        Actualizar_DP = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function PorCobrar_Prov_Castigo(ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer,
                                                  ByVal vHastaVence As String, ByVal vNdias As Long) As DataTable
      Dim TempList As New DataTable
      'Select Case* From finanzas.paporcobrar_prov_castigo(3, 0, '2015/12/31', 0)  
      Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_prov_castigo")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHastaVence, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vndiasvence", vNdias, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Grabar_Prov_Castigo(ByVal valmacenid As Integer, ByVal vfecha As String, ByVal vvoto As String,
                                                 ByVal vdetalle As String, ByVal vfechadias As String, ByVal vndias As Integer,
                                                 ByVal myarrcxc As String, ByVal vusuarioid As Long, ByVal vcaja As String) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from finanzas.paprovision_porcobrar_actualizar(true,"
        vConsulta = vConsulta & Trim(Str(valmacenid)) & ", '"
        vConsulta = vConsulta & Trim(vfecha) & "','"
        vConsulta = vConsulta & Trim(vvoto) & "','"
        vConsulta = vConsulta & Trim(vdetalle) & "','"
        vConsulta = vConsulta & Trim(vfechadias) & "',"
        vConsulta = vConsulta & Trim(Str(vndias)) & ","
        vConsulta = vConsulta & " " & Trim(myarrcxc) & ","

        vConsulta = vConsulta & Trim(Str(vusuarioid)) & ",'"
        vConsulta = vConsulta & Trim(vcaja) & "'"

        vConsulta = vConsulta & ")"

        Dim oConexion As New clsConexion
        Grabar_Prov_Castigo = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function PorCobrar_Prov_Castigo_Leer(ByVal vUnidad As Integer, ByVal vAlmacenid As Integer,
                                                          ByVal vHastaVence As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paprovision_porcobrar_leer")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHastaVence, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function PorCobrar_Prov_Castigo_Rpt(ByVal vCodigo As Long, ByVal vUnidad As Integer, ByVal vAlmacenid As Integer,
                                                      ByVal vHastaVence As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paprovision_porcobrar_rpt")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHastaVence, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

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


