
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class lote_gastoBD

        Public Shared Function GetItem(ByVal vLoteID As Long) As lote_gasto
            Dim objLG As lote_gasto = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.palote_gastos_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP.addParameter("inlotegastoid", vLoteID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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

    Public Shared Function GetList(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vBusca As String, ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vTipo As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.palote_gastos_consulta")
      Dim oConexion As New clsConexion
      Try
        'select * from finanzas.palote_gastos_consulta(1, 0, '', 0, 2015, '')
        oSP.addParameter("incodigo_uni", vCodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innombre", vBusca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As lote_gasto
            Dim objeto As lote_gasto = New lote_gasto
            objeto.lotegastoid = objData.Item("lotegastosid")
            objeto.nombre = objData.Item("nombre")
            objeto.mes = objData.Item("mes")
            objeto.anio = objData.Item("anio")
            objeto.usuarioid = objData.Item("usuarioid")
            objeto.caja = objData.Item("caja")
            objeto.importe = objData.Item("importe")
            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objlote As lote_gasto) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.palote_gastos_actualizar")
            Try
                If objlote.lotegastoid = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("inloteid", objlote.lotegastoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inalmacenid", objlote.almacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombre", objlote.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inmes", objlote.mes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inanio", objlote.anio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inestado", objlote.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                oSP.addParameter("inusuarioid", objlote.usuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incaja", objlote.caja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Asiento_Provision_mer(ByVal vCodigo As Long, ByVal vProcesar As Boolean) As DataTable
            Dim TempList As New DataTable

            Dim vFun As String = "finanzas.paasiento_prov_compra_mer"

            Dim oSP As New clsStored_Procedure(vFun)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Asiento_Mov_Mer_Com(ByVal vCodigo As Long, ByVal vProcesar As Boolean) As DataTable
            Dim TempList As New DataTable

            Dim vFun As String = "finanzas.paasiento_mov_mer_com"

            Dim oSP As New clsStored_Procedure(vFun)
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Asiento_Provision(ByVal vLote As Long, ByVal vProcesar As Boolean) As DataTable
            Dim TempList As New DataTable

            Dim vFun As String = "finanzas.paasiento_gastos_lote_prov"

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

        Public Shared Function Asiento_Pagos(ByVal vLote As Long, ByVal vProcesar As Boolean) As DataTable
            Dim TempList As New DataTable

            Dim vFun As String = "finanzas.paasiento_gastos_lote_pagos"

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

        Public Shared Function Asiento_Lote_Gasto_Conta(ByVal vLote As Long, ByVal vTipo As String) As DataTable
            Dim TempList As New DataTable

            Dim vFun As String = "finanzas.paasiento_gastos_lote_conta"

            Dim oSP As New clsStored_Procedure(vFun)
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

            Dim vFun As String = "finanzas.paasiento_lg_assinet_actualizar"

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

        Public Shared Function Eliminar_Asiento(ByVal codigo As Long, ByVal vUsuarioID As Long, ByVal vCaja As String) As DataTable

            Dim oSP As New clsStored_Procedure("finanzas.paasiento_gastos_eliminar")
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

            Dim oSP As New clsStored_Procedure("finanzas.palote_gastos_eliminar")
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuarioid", vUsuarioID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Eliminar_Lote = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

    End Class
End Namespace

