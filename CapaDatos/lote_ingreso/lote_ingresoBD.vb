Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class lote_ingresoBD
        Public Shared Function GetList_Pendientes(ByVal vCodigo_Alm As Integer, ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vFunction As String) As DataTable
            Dim TempList As New DataTable
            'finanzas.paingreso_por_dias(almacenid integer, vmes integer, vanio integer)
            Dim oSP As New clsStored_Procedure(vFunction)
            Dim oConexion As New clsConexion
            Try
                'select * from finanzas.palote_gastos_consulta(1, 0, '', 0, 2015, '')
                oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function GetList_Contabilizado(ByVal vFuncion As String, ByVal vEntidad As Integer, ByVal vCodigo_Alm As Integer, ByVal vBusca As String,
                                                     ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vTipo As String, ByVal vAssi As Boolean) As DataTable
      Dim TempList As New DataTable
      'finanzas.palote_ingreso_consulta(incodigo_uni integer, incodigo_alm integer, innombre character varying, inmes integer, inanio integer, intipo character varying)
      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try
        'select * from finanzas.palote_gastos_consulta(1, 0, '', 0, 2015, '')
        oSP.addParameter("inentidad", vEntidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innombre", vBusca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("inassi", vAssi, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Procesar_Lote_Ingresos_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean, _
                                                        ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String, _
                                                        ByVal DtProvision As DataTable, ByVal dtPagos As DataTable) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String, xOk As Boolean = False
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion

            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.palote_ingresos_procesar_asientos", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "valmacen"
                objParam.Value = vCodigo_Alm
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vdesde"
                objParam.Value = vDesde
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Size = 2
                objParam.ParameterName = "vprocesar"
                objParam.Value = vProcesar
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vmes"
                objParam.Value = vMes
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vanio"
                objParam.Value = vAnio
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "vusuario"
                objParam.Value = vUsuario
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 100
                objParam.ParameterName = "vcaja"
                objParam.Value = vCaja
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


    Public Shared Function Asiento_Lote_Ingreso_Conta(ByVal vFuncion As String, ByVal vLote As Long, ByVal vTipo As String) As DataTable
      Dim TempList As New DataTable
      'este
      '"finanzas.paasiento_ingresos_lote_conta"
      '"contable.paasiento_ing_mer_lote_conta"
      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        TempList = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar(ByVal vFuncion As String, ByVal codigo As Long, ByVal vUsuarioID As Long, ByVal vCaja As String) As DataTable

      Dim oSP As New clsStored_Procedure(vFuncion) '"finanzas.paasiento_ingresos_eliminar")
      Try
        oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuarioid", vUsuarioID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        Dim oConexion As New clsConexion
        Eliminar = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        oSP = Nothing
      End Try
    End Function

    Public Shared Function Reporte_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vLote As Long, _
                                                    ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vFuncion As String) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure(vFuncion)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


                Reporte_Asientos = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Reporte_Asientos
        End Function


        Public Shared Function Procesar_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vMes As Integer, _
                                                ByVal vAnio As Integer, ByVal vFuncion As String, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure(vFuncion)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vprocesar", True, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vUsuario", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vCaja", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Procesar_Asientos = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Procesar_Asientos
        End Function

    Public Shared Function Reporte_Procesar_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vMes As Integer, ByVal vAnio As Integer,
                                                      ByVal vProcesar As Boolean, ByVal vFuncion As String, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Dim vCuenta As Integer = 0
      'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vfecha", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vUsuario", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vCaja", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        Reporte_Procesar_Asientos = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return Reporte_Procesar_Asientos
    End Function

    Public Shared Function Asiento_Assinet_Actualizar(ByVal vLote As Long, ByVal vEntidad As Integer, ByVal Lote_Assinet As Long, ByVal vGuid As String, ByVal vTypej As String, ByVal vTipo As String) As DataTable
      Dim TempList As New DataTable

      Dim vFun As String = "contable.paasiento_li_assinet_actualizar"

      Dim oSP As New clsStored_Procedure(vFun)
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("loteingresoid", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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


  End Class
End Namespace

