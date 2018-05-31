Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class importacionBD
        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vdocumento As Integer, ByVal vPersona As Long, ByVal vrazsoc As String, ByVal vdesde As String, ByVal vhasta As String, ByVal vlimite As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vrazsoc", vrazsoc, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_cambiar_estado")
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

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_cambiar_cierre")
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

        Public Shared Function Cambiar_Estado_Descontar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_cambiar_estado_descontar")
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

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_eliminar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

        Public Shared Function Agregar(ByRef objIM As importacion, ByVal myArr As String) As DataTable
            Dim vCadena As String = "", xNew As Boolean = True
            If objIM.importacionid > 0 Then
                xNew = False
            End If
            Try
                vCadena = "select * from inventarios.paimportacion_actualizar(" & xNew & ","
                vCadena = vCadena & " " & Trim(Str(objIM.importacionid)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.documentoid)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.almacenid)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.proveedorid)) & ","

                vCadena = vCadena & " " & Trim(Str(objIM.aduanaid)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.aniodua)) & ","

                vCadena = vCadena & " '" & Trim(objIM.numero) & "', "
                vCadena = vCadena & " '" & Trim(objIM.fecha_emision) & "', "
                vCadena = vCadena & " '" & Trim(objIM.fecha_recepcion) & "', "
                vCadena = vCadena & " " & Trim(Str(objIM.vta_bruta)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.descuento)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.igv)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.vta_total)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.percepcion)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.importe_grabado)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.importe_exonerado)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.redondeo)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.valor_igv)) & ","
                vCadena = vCadena & " " & IIf(objIM.incluye_igv, "true", "false") & ", "
                vCadena = vCadena & " '" & Trim(objIM.moneda) & "', "
                vCadena = vCadena & " '" & Trim(objIM.condicion) & "', "
                vCadena = vCadena & " " & Trim(Str(objIM.cambio)) & ","
                vCadena = vCadena & " '" & Trim(objIM.observacion) & "', "
                vCadena = vCadena & " '" & Trim(Str(objIM.usuarioid)) & "', "
                vCadena = vCadena & " '" & Trim(objIM.caja) & "', "
                vCadena = vCadena & " '" & Trim(objIM.signo) & "', "
                vCadena = vCadena & " " & Trim(Str(objIM.opcion)) & ","
                vCadena = vCadena & " '" & Trim(objIM.referencia) & "', "
                vCadena = vCadena & " " & Trim(Str(objIM.codigo_ref1)) & ","
                vCadena = vCadena & " " & Trim(Str(objIM.codigo_ref2)) & ","
                vCadena = vCadena & " " & IIf(objIM.descontar_stock, "true", "false") & ", "
                vCadena = vCadena & " " & IIf(objIM.cerrado, "true", "false") & ", "
                vCadena = vCadena & " " & IIf(objIM.estado, "true", "false") & ", "
                vCadena = vCadena & " " & Trim(myArr) & ", "

                vCadena = vCadena & " '" & Trim(objIM.gTipo_per) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gDNI) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gRUC) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gApe_Pat) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gApe_Mat) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gNombre) & "', "
                vCadena = vCadena & " '" & Trim(objIM.gDireccion) & "' "

                vCadena = vCadena & ")"

                Dim oConexion As New clsConexion
                Agregar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Agregar_NC(ByRef objIM As importacion, ByVal myArr As String) As DataTable
            Dim vCadena As String = ""
            Dim xNew As Boolean = False
            Try

                vCadena = "select * from paimportacion_actualizar_nc(true,0,"

                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Tipo)) & ","
                'vCadena = vCadena & " '" & Trim(objIM.Numero) & "',"
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Documento)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Almacen)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Persona)) & ","
                'vCadena = vCadena & " '" & objIM.Fecha_Emision & "',"
                'vCadena = vCadena & " '" & objIM.Fecha_Recepcion & "',"
                'vCadena = vCadena & " '" & objIM.Fecha_Registro & "',"
                'vCadena = vCadena & " '" & Trim(objIM.Moneda) & "',"
                'vCadena = vCadena & " '" & objIM.condicion & "',"
                'vCadena = vCadena & " " & Trim(Str(objIM.Vta_Bruta)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Descuento)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.IGV)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Vta_Total)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Cambio)) & ","
                'vCadena = vCadena & " '" & objIM.Usuario & "',"
                'vCadena = vCadena & " '" & objIM.caja & "',"
                'vCadena = vCadena & " " & IIf(objIM.Estado, "true", "false") & ","
                'vCadena = vCadena & " '" & Trim(objIM.Observacion) & "',"
                'vCadena = vCadena & " " & IIf(objIM.Cerrado, "true", "false") & ","
                'vCadena = vCadena & " " & IIf(objIM.Incluye_IGV, "true", "false") & ","
                'vCadena = vCadena & " " & IIf(objIM.Descontar_Stock, "true", "false") & ", "
                'vCadena = vCadena & " " & IIf(objIM.Incluir_Registro, "true", "false") & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Percepcion)) & ","
                'vCadena = vCadena & " '" & IIf(objIM.Signo_Positivo, "+", "-") & "', "
                'vCadena = vCadena & " " & Trim(Str(objIM.Opcion)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Ingreso)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Valor_igv)) & ", "
                'vCadena = vCadena & " '" & Trim(objIM.Detrac_Numero) & "', "
                'vCadena = vCadena & " '" & objIM.Detrac_Fecha & "', "
                'vCadena = vCadena & " " & Trim(myArr) & ", "
                'vCadena = vCadena & " '" & objIM.gTipo_per & "', "
                'vCadena = vCadena & " '" & objIM.RucDNI & "', "
                'vCadena = vCadena & " '" & objIM.gPersona & "', "
                vCadena = vCadena & " '" & objIM.gDireccion & "' "
                vCadena = vCadena & ")"

                Dim oConexion As New clsConexion
                Agregar_NC = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Agregar_Transferencia(ByVal vCodigo As Long, ByVal vUsuarioid As Long, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paimportacion_transferencia")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Modificar(ByRef objIM As importacion, ByVal vCodigo As Long, ByVal myArr As String) As DataTable
            Dim vCadena As String = ""

            Try
                vCadena = "select * from paimportacion_actualizar(false,"
                'vCadena = vCadena & " " & Trim(Str(vCodigo)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Tipo)) & ","
                'vCadena = vCadena & " '" & Trim(objIM.Numero) & "',"
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Documento)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Almacen)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Persona)) & ","
                'vCadena = vCadena & " '" & objIM.Fecha_Emision & "',"
                'vCadena = vCadena & " '" & objIM.Fecha_Recepcion & "',"
                'vCadena = vCadena & " '" & objIM.Fecha_Registro & "',"
                'vCadena = vCadena & " '" & Trim(objIM.Moneda) & "',"
                'vCadena = vCadena & " '" & objIM.condicion & "',"
                'vCadena = vCadena & " " & Trim(Str(objIM.Vta_Bruta)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Descuento)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.IGV)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Vta_Total)) & ","
                'vCadena = vCadena & " " & Trim(Str(objIM.Cambio)) & ","
                'vCadena = vCadena & " '" & objIM.Usuario & "',"
                'vCadena = vCadena & " '" & objIM.caja & "',"
                'vCadena = vCadena & " " & IIf(objIM.Estado, "true", "false") & ","
                'vCadena = vCadena & " '" & Trim(objIM.Observacion) & "',"
                'vCadena = vCadena & " " & IIf(objIM.Cerrado, "true", "false") & ","
                'vCadena = vCadena & " " & IIf(objIM.Incluye_IGV, "true", "false") & ","
                'vCadena = vCadena & " " & IIf(objIM.Descontar_Stock, "true", "false") & ", "
                'vCadena = vCadena & " " & IIf(objIM.Incluir_Registro, "true", "false") & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Percepcion)) & ","
                'vCadena = vCadena & " '" & IIf(objIM.Signo_Positivo, "+", "-") & "', "
                'vCadena = vCadena & " " & Trim(Str(objIM.Opcion)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Codigo_Ingreso)) & ", "
                'vCadena = vCadena & " " & Trim(Str(objIM.Valor_igv)) & ", "
                'vCadena = vCadena & " '" & Trim(objIM.Detrac_Numero) & "', "
                'vCadena = vCadena & " '" & Format(objIM.Detrac_Fecha, "yyyy-mm-dd") & "', "
                'vCadena = vCadena & " " & Trim(myArr) & " "
                vCadena = vCadena & ")"

                Dim oConexion As New clsConexion
                Modificar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Leer_Items(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paimportacion_leer_items")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consulta_Ingresos(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, ByVal vdocumento As Integer, _
                                          ByVal vNumero As String) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paconsulta_Ingresos")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo_alm", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsigno", vSigno, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)


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
