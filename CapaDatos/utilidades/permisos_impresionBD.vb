Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class permisos_impresionBD
        Public Shared Function GetItem(ByVal codigo As Integer) As permisos_impresion
            Dim objpermisos_impresion As permisos_impresion = Nothing
            Dim TempList As New DataTable
            'Dim oSP As New clsStored_Procedure("papermisos_impresion_getrow")

            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                'oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta("select * from inventarios.permisos_impresion where permisosimpresionid=" & codigo)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objpermisos_impresion = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                'oSP = Nothing
            End Try
            Return objpermisos_impresion
        End Function

        Public Shared Function Get_Dato_Impresion(ByVal vUsuario As Long, ByVal vAlmacen As Integer, ByVal vCaja As String, _
                                                  ByVal vDocumento As Integer, ByVal vCodigo_Distinto As Long) As permisos_impresion
            Dim objPere As permisos_impresion = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow
            Dim oConexion As New clsConexion
            Dim vCadena As String = ""

            Try
                vCadena = "select permisosimpresionid, usuarioid, almacenid, documentoid, serieid, caja, imprimir, formato, impresora, empresaid, serie_tk, copias "
                vCadena = vCadena & " from inventarios.permisos_impresion where usuarioid=" & Trim(Str(vUsuario))
                vCadena = vCadena & " and almacenid=" & Trim(Str(vAlmacen))
                vCadena = vCadena & " and upper(caja)='" & Trim(vCaja.ToUpper)
                vCadena = vCadena & "' and documentoid=" & Trim(Str(vDocumento))
                vCadena = vCadena & " and permisosimpresionid!=" & Trim(Str(vCodigo_Distinto))
                vCadena = vCadena & " limit 1"

                myRs = oConexion.Ejecutar_Consulta(vCadena)

                objReader = Nothing
                If myRs.Rows.Count > 0 Then
                    objReader = myRs.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objPere = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    'objPere = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            End Try
            Return objPere
        End Function

        Public Shared Function Existe_Codigo(ByVal vUsuario As Long, ByVal vAlmacen As Integer, ByVal vCaja As String, ByVal vDocumento As Integer, ByVal vCodigo_Distinto As Long) As Long
            Dim objpersona As persona = Nothing
            Dim myRs As DataTable
            Dim oConexion As New clsConexion
            Existe_Codigo = 0
            Try
                myRs = oConexion.Ejecutar_Consulta("select codigo from permisos_impresion where codigo_usu=" & Trim(Str(vUsuario)) & _
                                                    " and codigo_uni=" & Trim(Str(vAlmacen)) & _
                                                    " and upper(caja)='" & Trim(vCaja.ToUpper) & _
                                                    "' and codigo_doc=" & Trim(Str(vDocumento)) & _
                                                    " and codigo!=" & Trim(Str(vCodigo_Distinto)))


                If myRs.Rows.Count > 0 Then
                    Existe_Codigo = myRs.Rows(0).Item("codigo")
                End If
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            End Try
            Return Existe_Codigo
        End Function


        Public Shared Function GetList(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vdocumento As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.papermisos_impresion_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vunidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Obtener_Documentos(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vcaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("papermisos_documento_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vunidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vcaja, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Obtener_Serie_Numero(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vdocumento As Integer, ByVal vcaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("papermisos_impresion_leer_permiso")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vunidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vcaja, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Obtener_Documentos_Modulo(ByVal vAlmacen As Integer, ByVal vPersona As Long, ByVal vcaja As String, ByVal vModulo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.papermisos_impresion_modulo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vAlmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vcaja, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)
                oSP.addParameter("vModulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As permisos_impresion
            Dim objeto As permisos_impresion = New permisos_impresion
            objeto.codigo = objData.Item("permisosimpresionid")
            objeto.codigo_usu = objData.Item("usuarioid")
            objeto.codigo_alm = objData.Item("almacenid")
            objeto.caja = objData.Item("caja")
            objeto.formato = objData.Item("formato")
            objeto.codigo_ser = objData.Item("serieid")
            objeto.impresora = objData.Item("impresora")
            objeto.codigo_doc = objData.Item("documentoid")
            objeto.impresion = objData.Item("imprimir")
            objeto.codigo_emp = objData.Item("empresaid")
            objeto.serie_TK = objData.Item("serie_tk")
            objeto.copias = objData.Item("copias")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objpermisos_impresion As permisos_impresion) As DataTable
            Dim oSP As New clsStored_Procedure("inventarios.papermisos_impresion_actualizar")
            Try
                If objpermisos_impresion.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objpermisos_impresion.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_usu", objpermisos_impresion.codigo_usu, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_alm", objpermisos_impresion.codigo_alm, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("incodigo_doc", objpermisos_impresion.codigo_doc, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("incodigo_ser", objpermisos_impresion.codigo_ser, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                'innew boolean, incodigo integer, incodigo_usu integer, incodigo_alm integer, incodigo_doc integer, incodigo_ser integer, 
                oSP.addParameter("incaja", objpermisos_impresion.caja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inimpresion", objpermisos_impresion.impresion, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)

                oSP.addParameter("informato", objpermisos_impresion.formato, NpgsqlTypes.NpgsqlDbType.Varchar, 1000, ParameterDirection.Input)

                oSP.addParameter("inimpresora", objpermisos_impresion.impresora, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)

                'incaja character varying, inimprimir boolean, informato character varying, inimpresora character varying, 

                oSP.addParameter("incodigo_emp", objpermisos_impresion.codigo_emp, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("inserietk", objpermisos_impresion.serie_TK, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("incopias", objpermisos_impresion.copias, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'incodigo_emp integer, inserietk character varying, incopias integer
                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("inventarios.papermisos_impresion_eliminar")
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

        Public Shared Function Obtener_Documentos_Permisos_Leer(ByVal vCodigo_Uni As Integer, ByVal vUsuario As Long, _
                                                    ByVal vCaja As String, ByVal dtDocumentoL As DataTable, _
                                                    ByVal dtDocumentoI As DataTable) As Boolean

            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter

            Cadena = ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padocumentos_permisos_leer", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                'objParam.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vcodigo_unidad"
                objParam.Value = vCodigo_Uni
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vUsuario"
                objParam.Value = vUsuario
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "vcaja"
                objParam.Value = vCaja
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtDocumentoL, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtDocumentoI, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()

                objReader.Close()

                CType(objReader, IDisposable).Dispose()
                'objCon.Close()
            Finally
                'CType(objCon, IDisposable).Dispose()
            End Try
            Return True
        End Function

    End Class
End Namespace
