Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class detalle_lote_gastosBD

        Public Shared Function GetCombos_RC_Cursor(ByVal vCodigo_Alm As Integer, ByVal vTipo_Doc As String, _
                                                   ByVal dtdocumento As DataTable, _
                                                   ByVal dtconcepto_gasto As DataTable, _
                                                   ByVal dtc_costo As DataTable, _
                                                   ByVal dtmoneda As DataTable, _
                                                   ByVal dttipo_importe As DataTable, _
                                                   ByVal dttipo_detraccion As DataTable, _
                                                   ByVal dtf_pago_detracc As DataTable) As Boolean

            Dim xOk As Boolean = False
            Dim Cadena As String
            'Dim oConexion As New clsConexion
            Dim objParam As NpgsqlParameter

            Cadena = ""  'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pacombosrc_cursor", objCon)
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

                dar.FillFromReader(dtconcepto_gasto, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtc_costo, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtmoneda, objReader)
                objReader.NextResult()

                dar.FillFromReader(dttipo_importe, objReader)
                objReader.NextResult()

                dar.FillFromReader(dttipo_detraccion, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtf_pago_detracc, objReader)
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

        Public Shared Function GetItem(ByVal codigo As Integer) As detalle_lote_gastos
            Dim objdetalle_lote_gastos As detalle_lote_gastos = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_lote_gastos_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objdetalle_lote_gastos = LlenarDatosRegistro(objReader, True)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objdetalle_lote_gastos
        End Function

        Public Shared Function GetItem_Cursor(ByVal vcodigo As Long, ByVal dtdetalle As DataTable, ByVal dtdetrac As DataTable) As detalle_lote_gastos

            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim objdetalle_lote_gastos As detalle_lote_gastos = Nothing

            Cadena = ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padetalle_lote_gastos_getrow_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vcodigo"
                objParam.Value = vcodigo
                objCmd.Parameters.Add(objParam)


                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(TempList, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtdetalle, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtdetrac, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()
                objCon.Close()
                If Not objReader Is Nothing Then
                    objReader.Close()
                    CType(objReader, IDisposable).Dispose()
                    If Not objReader Is Nothing Then
                        objdetalle_lote_gastos = LlenarDatosRegistro(TempList.Rows(0), True)
                    End If
                End If
            Finally
                'CType(objCon, IDisposable).Dispose()
            End Try
            Return objdetalle_lote_gastos
        End Function


        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_lote_gastos_consulta")
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

        Public Shared Function Consulta_Documentos_Referencia(ByVal vCodigo_Alm As Integer, ByVal vProv As Long, ByVal vRuc As String, ByVal vCodigo_Doc As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_gasto_referencia")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vproveedor", vProv, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vruc", vRuc, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcodigo_doc", vCodigo_Doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vserie", vCodigo_Doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vCodigo_Doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetDistribucion_C_Costo(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_lote_gastos_consulta")
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

        Public Shared Function Asiento(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paasiento_gastos_lote_net")
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

        Public Shared Function Asiento_Codigocion(ByVal vUnidad As Integer, ByVal vNroCta As String, ByVal vProv As Long, _
                                                  ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paasiento_egresos_cuenta_prov")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcuenta", vNroCta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vproveedor", vProv, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Get_Tipo_Detraccion(ByVal vCodigo_Det As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("patipo_detraccion_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_det", vCodigo_Det, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function forma_pago_Detraccion(ByVal vCodigo_Det As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paforma_pago_detraccion")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_det", vCodigo_Det, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow, ByVal vExtra As Boolean) As detalle_lote_gastos
            Dim objeto As detalle_lote_gastos = New detalle_lote_gastos

            objeto.codigo = objData.Item("codigo")
            objeto.codigo_lote = objData.Item("codigo_lote")
            objeto.codigo_doc = objData.Item("codigo_doc")

            objeto.serie = objData.Item("serie")
            objeto.numero = objData.Item("numero")
            objeto.ruc = objData.Item("ruc")

            objeto.emision = objData.Item("emision")
            If Not objData.Item("vencimiento") Is System.DBNull.Value Then
                objeto.vencimiento = objData.Item("vencimiento")
            Else
                objeto.vencimiento = ""
            End If

            objeto.registro = objData.Item("registro")

            objeto.condicion = objData.Item("condicion")

            objeto.codigo_con = objData.Item("codigo_con")
            objeto.glosa = objData.Item("glosa")

            objeto.tipo_importe = objData.Item("tipo_importe")
            objeto.afecto = objData.Item("afecto")
            objeto.inafecto = objData.Item("inafecto")
            objeto.importe_igv = objData.Item("importe_igv")
            objeto.importe_sc = objData.Item("importe_isc")
            objeto.importe_renta = objData.Item("importe_renta")
            objeto.importe_sp = objData.Item("importe_sp")
            objeto.otros = objData.Item("otros")
            objeto.total = objData.Item("total")
            objeto.valor_igv = objData.Item("valor_igv")
            objeto.valor_isc = objData.Item("valor_isc")
            objeto.valor_renta = objData.Item("valor_renta")

            objeto.comision = objData.Item("comision")
            objeto.tipo_sp = objData.Item("tipo_sp")

            objeto.moneda = objData.Item("moneda")
            objeto.cambio = objData.Item("cambio")

            objeto.signo = objData.Item("signo")
            objeto.codigo_ref = objData.Item("codigo_ref")
            objeto.codigo_usu = objData.Item("codigo_usu")
            objeto.caja = objData.Item("caja")
            objeto.estado = objData.Item("estado")
            If vExtra Then
                If Not objData.Item("ruc") Is System.DBNull.Value Then
                    objeto.ruc = objData.Item("ruc")
                End If
                If Not objData.Item("proveedor") Is System.DBNull.Value Then
                    objeto.proveedor = objData.Item("proveedor")
                End If
                'If Not objData.Item("direccion") Is System.DBNull.Value Then
                '    objeto.direccion = objData.Item("direccion")
                'End If
                If Not objData.Item("numero_ref") Is System.DBNull.Value Then
                    objeto.numero_ref = objData.Item("numero_ref")
                End If
                If Not objData.Item("monto_ref") Is System.DBNull.Value Then
                    objeto.monto_ref = objData.Item("monto_ref")
                End If

            End If

            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objRG As detalle_lote_gastos, ByVal vnombre_prov As String, ByVal vDireccion As String, _
                                      ByVal vruc As String, ByVal vNCUSPP As String, ByVal vArray As String, ByVal vArray_DT As String) As DataTable
            Dim vConsulta As String
            Try
                vConsulta = "select * from padetalle_lote_gastos_actualizar ("
                If objRG.codigo = -1 Then
                    vConsulta = vConsulta & "true,"
                Else
                    vConsulta = vConsulta & "False,"
                End If
                vConsulta = vConsulta & objRG.codigo & ",'"

                vConsulta = vConsulta & objRG.codigo_lote & "',"

                vConsulta = vConsulta & objRG.codigo_doc & ",'"
                vConsulta = vConsulta & objRG.serie & "','"
                vConsulta = vConsulta & objRG.numero & "','"
                vConsulta = vConsulta & objRG.ruc & "','"
                vConsulta = vConsulta & objRG.emision & "',"
                If objRG.vencimiento = "" Then
                    vConsulta = vConsulta & "null,'"
                Else
                    vConsulta = vConsulta & "'" & objRG.vencimiento & "','"
                End If

                vConsulta = vConsulta & objRG.registro & "','"
                vConsulta = vConsulta & objRG.condicion & "',"
                vConsulta = vConsulta & objRG.codigo_con & ",'"
                vConsulta = vConsulta & objRG.nrocuenta & "','"
                vConsulta = vConsulta & objRG.glosa & "',"

                vConsulta = vConsulta & objRG.tipo_importe & ","
                vConsulta = vConsulta & objRG.afecto & ","
                vConsulta = vConsulta & objRG.inafecto & ","
                vConsulta = vConsulta & objRG.importe_igv & ","
                vConsulta = vConsulta & objRG.importe_sc & ","
                vConsulta = vConsulta & objRG.importe_renta & ","
                vConsulta = vConsulta & objRG.importe_sp & ","
                vConsulta = vConsulta & objRG.otros & ","
                vConsulta = vConsulta & objRG.total & ","
                vConsulta = vConsulta & objRG.valor_igv & ","
                vConsulta = vConsulta & objRG.valor_isc & ","
                vConsulta = vConsulta & objRG.valor_renta & ","
                vConsulta = vConsulta & objRG.comision & ","
                vConsulta = vConsulta & objRG.tipo_sp & ",'"
                vConsulta = vConsulta & objRG.moneda & "',"
                vConsulta = vConsulta & objRG.cambio & ",'"
                vConsulta = vConsulta & objRG.signo & "',"
                vConsulta = vConsulta & objRG.codigo_ref & ","
                vConsulta = vConsulta & objRG.codigo_usu & ",'"
                vConsulta = vConsulta & objRG.caja & "',"
                vConsulta = vConsulta & IIf(objRG.activo, "true", "false") & ","
                vConsulta = vConsulta & objRG.mixto & ",'"
                vConsulta = vConsulta & objRG.tipo & "',"
                vConsulta = vConsulta & vArray & ","
                vConsulta = vConsulta & vArray_DT & ",'"

                vConsulta = vConsulta & vnombre_prov & "','"
                vConsulta = vConsulta & vDireccion & "','"
                vConsulta = vConsulta & objRG.numero_f & "','"
                vConsulta = vConsulta & objRG.numero_nodomi & "','"
                vConsulta = vConsulta & objRG.anio_emision & "','"
                vConsulta = vConsulta & objRG.dep_aduanera & "',"
                vConsulta = vConsulta & objRG.estado & ",'"

                vConsulta = vConsulta & vNCUSPP & "',"
                vConsulta = vConsulta & objRG.tipo_sp & ",true);"

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
            Dim oSP As New clsStored_Procedure("padetalle_lote_gastos_eliminar")
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
