
Imports CapaObjetosNegocio.BO




Namespace Dal


    Public Class registrarVBD

        Public Shared Function GetItem(ByVal vRegistrarv As Long) As registrarv
            Dim objregistrarv As registrarv = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("contable.paregistrar_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing
            Try
                oSP.addParameter("inregistrarvid", vRegistrarv, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)

                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If

                Try
                    If Not objReader Is Nothing Then
                        objregistrarv = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objregistrarv

        End Function



        Public Shared Function GetList(ByVal vcodigo_per As Integer, ByVal vidalmacen As Integer,
                                       ByVal vmes As Integer, ByVal vanio As Integer, ByVal vproceso As String,
                                       ByVal varrrol As String, vfilas As Long) As DataTable
            Dim TempList As New DataTable
            Dim vConsulta As String
            Dim oConexion As New clsConexion


            Try
                vConsulta = "select * from contable.paregistrar_consulta ( "
                vConsulta = vConsulta & " '" & vidalmacen & "',"
                vConsulta = vConsulta & " '" & vmes & "',"
                vConsulta = vConsulta & " '" & vanio & "',"
                vConsulta = vConsulta & " " & IIf(varrrol.Trim = "", "null", varrrol) & ","
                vConsulta = vConsulta & " " & vfilas & ","
                vConsulta = vConsulta & " '" & vcodigo_per & ");"

                TempList = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
            End Try
            Return TempList
        End Function



        Public Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As registrarv
            Dim objeto As registrarv = New registrarv

            objeto.codigo_per = objData.Item("codigo_per")
            objeto.emision = objData.Item("emision")
            objeto.nombre_corto = objData.Item("nombre_corto")
            objeto.codigo_sunat = objData.Item("codigo_sunat")
            objeto.numero = objData.Item("numero")
            objeto.tipo_doc_per = objData.Item("tipo_doc_per")
            objeto.numero_doc_per = objData.Item("numero_doc_per")
            objeto.persona = objData.Item("persona")
            objeto.afecto = objData.Item("afecto")
            objeto.noafecto = objData.Item("noafecto")
            objeto.igv = objData.Item("igv")
            objeto.descuento = objData.Item("dscto")
            objeto.total = objData.Item("total")
            objeto.cambio = objData.Item("cambio")
            objeto.estado = objData.Item("estado")
            objeto.fecha_doc_ori = objData.Item("fecha_doc_ori")
            objeto.serie_doc_ori = objData.Item("serie_doc_ori")
            objeto.numero_doc_ori = objData.Item("numero_doc_ori")
            objeto.signo = objData.Item("signo")
            objeto.serie = objData.Item("serie_int")
            objeto.numero_int = objData.Item("numero_int")
            objeto.codigo_doc = objData.Item("codigo_doc")
            objeto.almacenaid = objData.Item("almacenid")
            objeto.tabla = objData.Item("tabla")
            objeto.idtabla = objData.Item("tablaid")
            objeto.cod_ass = objData.Item("codigoassinet")
            objeto.mes = objData.Item("mes")
            objeto.anio = objData.Item("anio")
            Return objeto
        End Function



        Public Shared Function Actualizar(ByVal objR As registrarv, ByVal varralmacenid As String)

            Dim vCadena As String = ""

            Try
                vCadena = "select * from contable.paregistrar_actualizar( "
                vCadena = vCadena & " " & IIf(objR.codigo_per > 0, "false", "true") & ", "
                vCadena = vCadena & " " & Trim(Str(objR.codigo_per)) & ", "
                vCadena = vCadena & " '" & Trim(objR.emision) & "',"
                vCadena = vCadena & " '" & Trim(objR.nombre_corto) & "',"
                vCadena = vCadena & " '" & Trim(objR.codigo_sunat) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero) & "',"
                vCadena = vCadena & " '" & Trim(objR.tipo_doc_per) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero_doc_per) & "',"
                vCadena = vCadena & " '" & Trim(objR.persona) & "',"
                vCadena = vCadena & " '" & Trim(objR.afecto) & "',"
                vCadena = vCadena & " '" & Trim(objR.noafecto) & "',"
                vCadena = vCadena & " '" & Trim(objR.igv) & "',"
                vCadena = vCadena & " '" & Trim(objR.descuento) & "',"
                vCadena = vCadena & " '" & Trim(objR.total) & "',"
                vCadena = vCadena & " '" & Trim(objR.cambio) & "',"
                vCadena = vCadena & " '" & Trim(objR.estado) & "',"
                vCadena = vCadena & " '" & Trim(objR.fecha_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.serie_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero_int) & "',"
                vCadena = vCadena & " '" & Trim(objR.codigo_doc) & "',"
                vCadena = vCadena & " '" & Trim(objR.almacenaid) & "',"
                vCadena = vCadena & " '" & Trim(objR.tabla) & "',"
                vCadena = vCadena & " '" & Trim(objR.idtabla) & "',"
                vCadena = vCadena & " '" & Trim(objR.cod_ass) & "',"
                vCadena = vCadena & " '" & Trim(objR.mes) & "',"
                vCadena = vCadena & " '" & Trim(objR.anio) & "',"


                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try

        End Function


        Public Shared Function Eliminar(ByVal vcodigo_per As Long, ByVal vUsuario As Long, ByVal vIp As String) As DataTable
            Dim vCadena As String = ""

            Try
                vCadena = "select * from contable.paregistrar_eliminar( "
                vCadena = vCadena & " " & Trim(Str(vcodigo_per)) & ", "
                vCadena = vCadena & " " & Trim(vUsuario) & ", "
                vCadena = vCadena & " '" & Trim(vIp) & "');"


                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""

            End Try

        End Function




    End Class



End Namespace