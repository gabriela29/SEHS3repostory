Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class detalle_lote_gastoBD

        Public Shared Function GetCombos_RC_Cursor(ByVal vCodigo_Alm As Integer, ByVal vTipo_Doc As String, _
                                                    ByVal dtdocumento As DataTable, _
                                                    ByVal dtc_costo As DataTable, _
                                                    ByVal dtmoneda As DataTable, _
                                                    ByVal dttipo_importe As DataTable, _
                                                    ByVal dtfpago As DataTable, ByVal dtOtros As DataTable) As Boolean

            Dim xOk As Boolean = False
            Dim Cadena As String
            'Dim oConexion As New clsConexion
            Dim objParam As NpgsqlParameter

            Cadena = ""  'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paventana_rg_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "inalmacen"
                objParam.Value = vCodigo_Alm
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 4
                objParam.ParameterName = "intipo_doc"
                objParam.Value = vTipo_Doc
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtdocumento, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtc_costo, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtmoneda, objReader)
                objReader.NextResult()

                dar.FillFromReader(dttipo_importe, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtfpago, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtOtros, objReader)
                objReader.NextResult()


                t.Commit()
                t.Dispose()

                objReader.Close()
                xOk = True
                CType(objReader, IDisposable).Dispose()

            Finally
                'CType(objCon, IDisposable).Dispose()
            End Try
            Return xOk
        End Function

        Public Shared Function GetItem_Cursor(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, _
                                                ByRef dtdetalle As DataTable, ByRef dtdetrac As DataTable, _
                                                ByRef dtSustento As DataTable) As Boolean

            Dim xOk As Boolean = False
            Dim Cadena As String
            'Dim oConexion As New clsConexion
            Dim objParam As NpgsqlParameter

            Cadena = ""  'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.palote_gasto_detalle_getrow_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "inalmacen"
                objParam.Value = vCodigo
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtCabecera, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtdetalle, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtdetrac, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtSustento, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()

                objReader.Close()
                xOk = True
                CType(objReader, IDisposable).Dispose()

            Finally
                'CType(objCon, IDisposable).Dispose()
            End Try
            Return xOk
        End Function

        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.padetalle_lote_gastos_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Provisionar(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.padetalle_lote_gastos_provision")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetRpt(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.parpt_lote_gastos_detalle")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Grabar(ByRef objRG As detalle_lote_gasto, ByVal vArray As String, ByVal vArray_DT As String, _
                                      ByVal vArray_FP As String, ByVal vVence As String) As DataTable
            Dim vConsulta As String
            Try
                vConsulta = "select * from finanzas.palote_gastos_detalle_actualizar ("
                If objRG.lotegastosdetalleid = -1 Then
                    vConsulta = vConsulta & "true,"
                Else
                    vConsulta = vConsulta & "False,"
                End If
                vConsulta = vConsulta & objRG.lotegastosdetalleid & ","

                vConsulta = vConsulta & objRG.lotegastosid & ","

                vConsulta = vConsulta & objRG.documentoid & ",'"
                vConsulta = vConsulta & objRG.serie & "','"
                vConsulta = vConsulta & objRG.numero & "',"
                vConsulta = vConsulta & objRG.personaid & ",'"
                vConsulta = vConsulta & objRG.emision & "',"

                If objRG.vencimiento = "" Then
                    vConsulta = vConsulta & "null" & ","
                Else
                    vConsulta = vConsulta & "'" & objRG.vencimiento & "',"
                End If

                vConsulta = vConsulta & objRG.formapago & ",'"
                vConsulta = vConsulta & objRG.glosa & "',"
                vConsulta = vConsulta & objRG.tipo_importe & ","
                vConsulta = vConsulta & objRG.afecto & ","
                vConsulta = vConsulta & objRG.inafecto & ","
                vConsulta = vConsulta & objRG.importe_igv & ","
                vConsulta = vConsulta & objRG.importe_isc & ","
                vConsulta = vConsulta & objRG.importe_renta & ","
                vConsulta = vConsulta & objRG.otros & ","
                vConsulta = vConsulta & objRG.total & ","
                vConsulta = vConsulta & objRG.valor_igv & ","
                vConsulta = vConsulta & objRG.valor_isc & ","
                vConsulta = vConsulta & objRG.valor_renta & ","
                vConsulta = vConsulta & objRG.comision & ",'"
                vConsulta = vConsulta & objRG.moneda & "',"
                vConsulta = vConsulta & objRG.cambio & ",'"
                vConsulta = vConsulta & objRG.signo & "',"
                vConsulta = vConsulta & objRG.codigo_ref & ",'"
                vConsulta = vConsulta & objRG.usuario & "','"
                vConsulta = vConsulta & objRG.caja & "','"
                vConsulta = vConsulta & objRG.aduanaid & "','"
                vConsulta = vConsulta & objRG.anio_dua & "','"
                vConsulta = vConsulta & objRG.numero_dua & "',"
                vConsulta = vConsulta & IIf(objRG.estado, "true", "false") & ","

                vConsulta = vConsulta & vArray & ","
                vConsulta = vConsulta & vArray_DT & ","

                vConsulta = vConsulta & " '" & Trim(objRG.Tipo_per) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.RUC) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.DNI) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.Ape_Pat) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.Ape_Mat) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.Nombre) & "',"
                vConsulta = vConsulta & " '" & Trim(objRG.Direccion_Persona) & "',"
                vConsulta = vConsulta & IIf(objRG.percepcion, "true", "false") & ","
                vConsulta = vConsulta & IIf(objRG.detraccion, "true", "false") & ","
                vConsulta = vConsulta & " '" & Trim(objRG.tipo) & "', "
                vConsulta = vConsulta & vArray_FP & ", '"
                vConsulta = vConsulta & vVence & "' "
                vConsulta = vConsulta & ");"

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

        Public Shared Function Grabar_Distribucion(ByVal vCodigo_Det As Long, ByVal vArray As String) As DataTable
            Dim vConsulta As String

            Try
                vConsulta = "select * from padetalle_lote_gastos_cc_actualizar ("

                vConsulta = vConsulta & vCodigo_Det & ","

                vConsulta = vConsulta & vArray & ")"

                Dim oConexion As New clsConexion
                Grabar_Distribucion = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.padetalle_lote_gastos_eliminar")
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

