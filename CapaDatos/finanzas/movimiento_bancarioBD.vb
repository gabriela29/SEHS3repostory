Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
  Public Class movimiento_bancarioBD

    Public Shared Function pamovimiento_bancario_leer_ing(ByVal vcuenta As Integer, ByVal vdocumento As Integer, ByVal vdesde As String, ByVal vhasta As String,
                                                           ByVal vtipo As String, ByVal vcodigo_tip As Integer, ByVal vpersona As Long, ByVal valmacen As Integer,
                                                           ByVal vlote As Long, ByVal vSerie As String)
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.pamovimiento_bancario_leer_ing")
      Dim oConexion As New clsConexion
      Try
        'oSP.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vtipo", vtipo, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vcodigo_tip", vcodigo_tip, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", valmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vlote", vlote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vserie", vSerie, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    'de pagos a cuenta
    Public Shared Function Reporte_Recibo_Interno_pc(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("pamovimiento_bancario_recibo_pc")
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

    Public Shared Function Registrar_Anticipo_Web(ByRef objMB As movimiento_bancario, ByVal vTipoFpId As Integer, ByVal vSerieId As Long,
                                                  ByVal myArr_MB As String, ByVal myArr_RMB As String) As DataTable
      Dim vConsulta As String = ""
      'intipo character varying, intipomovbanid integer, indocumentoid integer, inalmacenid integer, infecha date, intotal numeric, inmoneda character varying,
      'incambio numeric, inobservacion character varying, inusuarioid integer, incaja character varying, inestado boolean, incerrado boolean, inreferencia character varying,
      'incodigo_ref2 integer, innrocuenta character varying, inc_costo character varying, inimporte_paga numeric, invuelto numeric, myarr_mb character varying[], myarr_rmb character varying[])

      Try
        vConsulta = "select * from finanzas.padepositos_web_registrar("
        vConsulta = vConsulta & " '" & objMB.Tipo & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Tip)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Documento)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_alm)) & ", "
        vConsulta = vConsulta & " '" & (objMB.fecha) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Importe)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Moneda) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Cambio)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Observacion) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Usuario)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.caja) & "',"
        vConsulta = vConsulta & " " & IIf(objMB.Estado, "true", "false") & ","
        vConsulta = vConsulta & " " & IIf(objMB.Cerrado, "true", "false") & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Referencia_Exterior) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo2_RefExt)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.NroCuenta) & "', "
        vConsulta = vConsulta & " '" & Trim(objMB.Centro_Costo) & "', "
        vConsulta = vConsulta & " " & Trim(Str(objMB.Importe_Pago)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Vuelto)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vTipoFpId)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vSerieId)) & ","
        vConsulta = vConsulta & " " & Trim(myArr_MB) & ","
        vConsulta = vConsulta & " " & Trim(myArr_RMB) & " "

        vConsulta = vConsulta & " )"

        'vConsulta = vConsulta & IIf(vRetener, "true", "false") & ")"

        'vArray_DT

        Dim oConexion As New clsConexion
        Registrar_Anticipo_Web = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Grabar(ByRef objMB As movimiento_bancario, ByVal myArrFP As String, ByVal myArrCXC_CXP As String, ByVal myArrPre As String) As DataTable
      Dim vConsulta As String, vCuspp As String = "", vTipoAFP As Integer = 0, vAFP_ONP As Integer = 0
      'innew boolean, inmovbanid integer, intipo character varying, intipomovbanid integer, indocumentoid integer, innumero character varying, 
      'inalmacenid integer, inpersonaid integer, infecha_emision date, infecha_cancela date, inimporte numeric, inmoneda character varying, 
      'incambio numeric, inobservacion character varying, inusuarioid integer, incaja character varying, inestado boolean, incerrado boolean, 
      'incodigo_ref integer, inreferencia character varying, incodigo_ref1 integer, incodigo_ref2 integer, innrocuenta character varying, 
      'inc_costo character varying, inimporte_paga numeric, invuelto numeric, myarr_formapago character varying[], myarrcxc_cxp character varying[]

      Try
        vConsulta = "select * from finanzas.pamovimiento_bancario_actualizar(true,"
        vConsulta = vConsulta & " 0,"
        vConsulta = vConsulta & " '" & objMB.Tipo & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Tip)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Documento)) & ","
        vConsulta = vConsulta & " '" & objMB.Numero & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_alm)) & ", "
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Persona)) & ","
        vConsulta = vConsulta & " '" & (objMB.fecha) & "',"
        vConsulta = vConsulta & " '" & (objMB.Cancela) & "', "
        vConsulta = vConsulta & " " & Trim(Str(objMB.Importe)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Moneda) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Cambio)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Observacion) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo_Usuario)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.caja) & "',"
        vConsulta = vConsulta & " " & IIf(objMB.Estado, "true", "false") & ","
        vConsulta = vConsulta & " " & IIf(objMB.Cerrado, "true", "false") & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.codigo_ref)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.Referencia_Exterior) & "',"
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo1_RefExt)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Codigo2_RefExt)) & ","
        vConsulta = vConsulta & " '" & Trim(objMB.NroCuenta) & "', "
        vConsulta = vConsulta & " '" & Trim(objMB.Centro_Costo) & "', "
        vConsulta = vConsulta & " " & Trim(Str(objMB.Importe_Pago)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Vuelto)) & ","
        vConsulta = vConsulta & " " & Trim(Str(objMB.Sobra)) & ","

        vConsulta = vConsulta & " " & Trim(myArrFP) & ","
        vConsulta = vConsulta & " " & Trim(myArrCXC_CXP) & ", "
        vConsulta = vConsulta & " " & Trim(myArrPre) & " "
        vConsulta = vConsulta & " )"

        'vConsulta = vConsulta & IIf(vRetener, "true", "false") & ")"

        'vArray_DT

        Dim oConexion As New clsConexion
        Grabar = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.pamovimiento_bancario_cambiar_estado")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure("pamovimiento_bancario_eliminar")
      Try
        oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("incaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        Dim oConexion As New clsConexion
        Eliminar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Actualizar_NroCta(ByVal xCodigo As Long, ByVal xNroCta As String) As Boolean
      Dim vCadena As String = "", vFree As String = "", xDt As New DataTable
      'inpersonaid, inusuario_nuevo, inclave_nueva, inclave_temporal, inrenovar_clave, intipo_cambio
      Try

        vCadena = "Update finanzas.movimiento_bancario set "
        vCadena = vCadena & " nrocuenta='" & xNroCta & "'"
        vCadena = vCadena & " where movbanid=" & xCodigo


        Dim oConexion As New clsConexion
        xDt = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
        Return True
      Finally
        vCadena = ""
      End Try
    End Function

    Public Shared Function Registrar_Uso_Sobrante(ByVal vMBID As Long, ByVal myArr_cxc As String) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from finanzas.paporcobrar_abono_actualizar("
        vConsulta = vConsulta & " " & Trim(Str(vMBID)) & ","
        vConsulta = vConsulta & " " & Trim(myArr_cxc) & " "

        vConsulta = vConsulta & " )"

        Dim oConexion As New clsConexion
        Registrar_Uso_Sobrante = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Movimiento_BancarioTFP(ByVal vUni As Integer, ByVal vAlmId As Integer, ByVal vTFP As Integer,
                                                     ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.pamovimiento_bancario_leerfp")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inunidadid", vUni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inalmacenid", vAlmId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vtipofpid", vTFP, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

    Public Shared Function tipo_forma_pago_leer(ByVal vNombre As String) As DataTable
      Dim vConsulta As String = ""
      Dim TempList As DataTable
      Try
        vConsulta = "select tipofpid, nombre from finanzas.tipo_forma_pago order by 2"

        Dim oConexion As New clsConexion
        TempList = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return TempList
    End Function

  End Class
End Namespace

