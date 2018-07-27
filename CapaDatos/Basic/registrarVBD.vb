Imports CapaObjetosNegocio
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql

Namespace Dal


    Public Class registrarVBD

        Public Shared Function GetItem(ByVal codigo As Integer) As registrarv
            Dim objregistrarv As registrarv = Nothing
            Dim TempList As New DataTable
            Dim oSP As String = ""
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing

            Try

                oSP = "select * from contable.registro_venta where codigo_per=" & codigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
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



        Public Shared Function GetList(ByVal numero As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("contable.paregistro_venta_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("numero", numero, NpgsqlTypes.NpgsqlDbType.Varchar, 4, ParameterDirection.Input)
                ' oSP.addParameter("mes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                ' oSP.addParameter("anio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function



        Public Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As registrarv
            Dim objeto As registrarv = New registrarv

            objeto.almacenaid = objData.Item("almacenid")
            objeto.codigo_doc = objData.Item("codigo_doc")
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
            'objeto.fecha_doc_ori = objData.Item("fecha_doc_ori")
            'objeto.cod_doc_ori = objData.Item("cod_doc_ori")
            'objeto.serie_doc_ori = objData.Item("serie_doc_ori")
            'objeto.numero_doc_ori = objData.Item("numero_doc_ori")
            objeto.signo = objData.Item("signo")
            objeto.serie_int = objData.Item("serie_int")
            objeto.numero_int = objData.Item("numero_int")
            objeto.tabla = objData.Item("tabla")
            objeto.idtabla = objData.Item("tablaid")
            objeto.cod_ass = objData.Item("cod_assinet")
            objeto.mes = objData.Item("mes")
            objeto.anio = objData.Item("anio")
            Return objeto
        End Function



        Public Shared Function Grabar(ByVal objR As registrarv) As DataTable
            Dim oSP As New clsStored_Procedure("contable_paregistro_venta_actualizar")
            Dim vCadena As String = ""
            Try
                vCadena = "select * from contable.paregistro_venta_actualizar( "
                vCadena = vCadena & " " & IIf(objR.almacenaid < 0, "false", "true") & ", "
                vCadena = vCadena & " " & Trim(Str(objR.almacenaid)) & ","
                vCadena = vCadena & " " & Trim(objR.codigo_doc) & ","
                vCadena = vCadena & " " & Trim(objR.codigo_per) & ", "
                vCadena = vCadena & " '" & Trim(objR.emision) & "',"
                vCadena = vCadena & " '" & Trim(objR.nombre_corto) & "',"
                vCadena = vCadena & " '" & Trim(objR.codigo_sunat) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero) & "',"
                vCadena = vCadena & " '" & Trim(objR.tipo_doc_per) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero_doc_per) & "',"
                vCadena = vCadena & " '" & Trim(objR.persona) & "',"
                vCadena = vCadena & " " & Trim(objR.afecto) & ","
                vCadena = vCadena & " " & Trim(objR.noafecto) & ","
                vCadena = vCadena & " " & Trim(objR.igv) & ","
                vCadena = vCadena & " " & Trim(objR.descuento) & ","
                vCadena = vCadena & " " & Trim(objR.total) & ","
                vCadena = vCadena & " " & Trim(objR.cambio) & " ,"
                vCadena = vCadena & " " & Trim(objR.estado) & "," 'boolean
                vCadena = vCadena & " '" & Trim(objR.fecha_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.cod_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.serie_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero_doc_ori) & "',"
                vCadena = vCadena & " '" & Trim(objR.signo) & "',"
                vCadena = vCadena & " '" & Trim(objR.serie_int) & "',"
                vCadena = vCadena & " '" & Trim(objR.numero_int) & "',"
                vCadena = vCadena & " '" & Trim(objR.tabla) & "',"
                vCadena = vCadena & " " & Trim(objR.idtabla) & ","
                vCadena = vCadena & " " & Trim(objR.cod_ass) & ","
                vCadena = vCadena & " " & Trim(objR.mes) & ", "
                vCadena = vCadena & " " & Trim(objR.anio) & " "
                vCadena = vCadena & " )"


                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try

        End Function


        Public Shared Function Eliminar(ByVal numero As String) As DataTable
            Dim oSP As New clsStored_Procedure("contable.paregistro_venta_eliminar")
            Try
                oSP.addParameter("numero", numero, NpgsqlTypes.NpgsqlDbType.Varchar, 4, ParameterDirection.Input)
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