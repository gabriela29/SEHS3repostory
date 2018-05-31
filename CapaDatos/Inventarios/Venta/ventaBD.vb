Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class ventaBD

        Public Shared Function GetItem(ByVal codigo As Long) As venta
            Dim objV As venta = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from venta where codigo=" & codigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objV = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objV
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As venta
            Dim objeto As venta = New venta
            objeto.ventaid = objData.Item("ventaid")
            objeto.Numero = objData.Item("numero")
            objeto.clienteid = objData.Item("clienteid")
            objeto.Referencia = objData.Item("referencia")
            objeto.Codigo_Ref1 = objData.Item("codigo_ref1")
            objeto.Cambio = objData.Item("cambio")
            objeto.centro_costos = objData.Item("centro_costos")
            Return objeto
            objeto = Nothing
        End Function

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paventa_cambiar_estado")
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
            Dim oSP As New clsStored_Procedure("paventa_cambiar_estado_descontar")
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

        Public Shared Function Consulta_Ventas(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, _
                                               ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paConsulta_Ventas")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsigno", vSigno, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                                     ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, _
                                     ByVal vNumHasta As String, ByVal vNumero As String, ByVal vCliente As Long, _
                                     ByVal vRazon_Social As String, ByVal vSigno As String, ByVal vReferencia As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paventa_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vvendedor", vVendedor, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecdesde", vFecDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vfechasta", vFecHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumdesde", vNumDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumhasta", vNumHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vraz_social", vRazon_Social, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)
                oSP.addParameter("vsigno", vSigno, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vreferencia", vReferencia, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)

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
            Dim oSP As New clsStored_Procedure("inventarios.paventa_eliminar")
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

        Public Shared Function Agregar(ByRef objV As venta, ByVal myArr As String, ByVal vArrFP As String, ByVal vPaga As Single, _
                                      ByVal vVuelto As Single, ByVal vMaestra As String, ByVal vCodigo_Serie As Integer, ByVal vCodigo_Seried As Integer, _
                                      ByVal vCodigo_Doc_D As Integer, ByVal vNumeroD As String, ByVal vImporte_D As Single, myArr_CxC As String) As DataTable
            Dim vCadena As String = ""

            Try

                vCadena = "select * from inventarios.paventa_actualizar(true, "
                vCadena = vCadena & " 0,"
                vCadena = vCadena & " " & Trim(Str(objV.almacenid)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.documentoid)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.clienteid)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.vendedorid)) & ","
                vCadena = vCadena & " '" & Trim(objV.fecha) & "',"
                vCadena = vCadena & " '" & Trim(objV.numero) & "',"
                vCadena = vCadena & " '" & Trim(objV.nombre_cli) & "',"
                vCadena = vCadena & " '" & Trim(objV.condicion) & "',"
                vCadena = vCadena & " " & Trim(Str(objV.vta_bruta)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.descuento)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.igv)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.vta_total)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.importe_grabado)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.importe_exonerado)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.redondeo)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.valor_igv)) & ","
                vCadena = vCadena & " " & IIf(objV.incluye_igv, "true", "false") & ","
                vCadena = vCadena & " '" & Trim(objV.moneda) & "',"
                vCadena = vCadena & " " & Trim(Str(objV.cambio)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.comision)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.impresiones)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.usuarioid)) & ","
                vCadena = vCadena & " '" & Trim(objV.caja) & "',"
                vCadena = vCadena & " '" & Trim(objV.signo) & "',"
                vCadena = vCadena & " " & Trim(Str(objV.opcion)) & ","
                vCadena = vCadena & " '" & Trim(objV.referencia) & "',"
                vCadena = vCadena & " " & Trim(Str(objV.codigo_ref)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.codigo_ref1)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.codigo_ref2)) & ","
                vCadena = vCadena & " '" & Trim(objV.observacion) & "',"
                vCadena = vCadena & " " & IIf(objV.descontar_stock, "true", "false") & ","
                vCadena = vCadena & " " & IIf(objV.cerrado, "true", "false") & ","
        vCadena = vCadena & " " & IIf(objV.estado, "true", "false") & ","

        vCadena = vCadena & " " & Trim(myArr) & ","
        vCadena = vCadena & " " & Trim(vArrFP) & ","
                vCadena = vCadena & " " & Trim(Str(vPaga)) & ","
                vCadena = vCadena & " " & Trim(Str(vVuelto)) & ","
                vCadena = vCadena & " '" & Trim(objV.Tipo_per) & "',"
                vCadena = vCadena & " '" & Trim(objV.RUC) & "',"
                vCadena = vCadena & " '" & Trim(objV.DNI) & "',"
                vCadena = vCadena & " '" & Trim(objV.Ape_Pat) & "',"
                vCadena = vCadena & " '" & Trim(objV.Ape_Mat) & "',"
                vCadena = vCadena & " '" & Trim(objV.Nombre) & "',"
                vCadena = vCadena & " '" & Trim(objV.Direccion_Cliente) & "',"
                vCadena = vCadena & " '" & Trim(objV.Vencimiento) & "',"
                vCadena = vCadena & " '" & Trim(vMaestra) & "',"
                vCadena = vCadena & " '" & Trim(objV.centro_costos) & "',"
                vCadena = vCadena & " " & Trim(Str(objV.DireccionId)) & ","

                vCadena = vCadena & " " & Trim(Str(vCodigo_Serie)) & ","
                vCadena = vCadena & " " & Trim(Str(vCodigo_Seried)) & ","
                vCadena = vCadena & " " & Trim(Str(vCodigo_Doc_D)) & ","
                vCadena = vCadena & " '" & Trim(vNumeroD) & "',"
                vCadena = vCadena & " " & Trim(Str(vImporte_D)) & ","

                vCadena = vCadena & " " & Trim(myArr_CxC) & ");"

                Dim oConexion As New clsConexion
                Agregar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

        Public Shared Function Leer_Items(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_leer_items")
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

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_cambiar_cierre")
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

        Public Shared Function Datos_Impresion_Cab(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paimprimir_venta_cabecera")
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

        Public Shared Function Datos_Impresion_Det(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paimprimir_venta_detalle")
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


        Public Shared Function Venta_Guia_Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                                                  ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, _
                                                  ByVal vNumHasta As String, ByVal vNumero As String, ByVal vCliente As Long, _
                                                  ByVal vRazon_Social As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paventa_guia_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecdesde", vFecDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vfechasta", vFecHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumdesde", vNumDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumhasta", vNumHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vcliente", vCliente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vraz_social", vRazon_Social, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)


                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Saldo_Fact_Colportaje_Res(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vDesde As String, _
                                                         ByVal vHasta As String, ByVal vMeta As Single, ByVal vdestinoid As Long, _
                                                         ByVal vtipoid As Integer, ByVal vglosa As String, ByVal vusuarioid As Long, _
                                                         ByVal vcaja As String, ByVal myarray As String) As DataTable
            Dim TempList As New DataTable
            'colportaje.pasaldofacturacion(vAlmacenId integer,  vPersonaid integer, vHastas character varying)
            'vdestinoid integer, vtipoid integer, vglosa varchar, vusuarioid integer, vcaja varchar, myarray

            Dim oCn As New clsConexion, vCadena As String
            Try

                vCadena = "select * from colportaje.pasaldofacturacion_res( "
                vCadena = vCadena & " " & Trim(Str(vAlmacenId)) & ","
                vCadena = vCadena & " " & Trim(Str(vPersonaid)) & ","
                vCadena = vCadena & " '" & vDesde & "',"
                vCadena = vCadena & " '" & vHasta & "',"
                vCadena = vCadena & " " & Trim(Str(vMeta)) & ","
                vCadena = vCadena & " " & Trim(Str(vdestinoid)) & ","
                vCadena = vCadena & " " & Trim(Str(vtipoid)) & ","
                vCadena = vCadena & " '" & vglosa & "',"
                vCadena = vCadena & " " & Trim(Str(vusuarioid)) & ","
                vCadena = vCadena & " '" & vcaja & "',"
                vCadena = vCadena & " " & Trim(myarray) & " "

                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                TempList = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally

                vCadena = ""
            End Try
            Return TempList
        End Function

        Public Shared Function Actualizar_x(ByVal objV As venta) As DataTable
            Dim vCadena As String = ""

            Try
                'inventaid integer, invendedorid integer, infecha date, innumero character varying, invence date)
                vCadena = "select * from inventarios.paventa_actualizar("
                vCadena = vCadena & " " & Trim(Str(objV.ventaid)) & ","
                vCadena = vCadena & " " & Trim(Str(objV.vendedorid)) & ","
                vCadena = vCadena & " '" & Trim(objV.fecha) & "',"
                vCadena = vCadena & " '" & Trim(objV.numero) & "');"

                Dim oConexion As New clsConexion
                Actualizar_x = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function

    Public Shared Function Cambiar_Usuario(ByVal vCodigo As Long, ByVal vUsuarioid As Long, ByVal vCaja As String) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("inventarios.paventa_cambiar_us")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vventaid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vusuarioid", vUsuarioid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
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
