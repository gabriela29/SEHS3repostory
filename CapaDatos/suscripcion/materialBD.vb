Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class MaterialBD

        Public Shared Function material_leerBD(ByVal vmaterialgrupoid As Integer, ByVal vmaterialsubgrupoid As Integer, ByVal vnombre As String) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_leer")
            Dim oConexion As New clsConexion
            Try
                'suscripcion.pamaterial_leer(vinicio integer, vfin integer, vmaterialgrupoid integer, vmaterialsubgrupoid integer, vnombre character varying)
                oSP.addParameter("vinicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vmaterialgrupoid", vmaterialgrupoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vmaterialsubgrupoid", vmaterialsubgrupoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnombre", vnombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As material
            Dim objm As material = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing
            Try
                oSP.addParameter("vmaterialid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)

                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If

                Try
                    If Not objReader Is Nothing Then
                        objm = LlenarDatosProducto(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objm
        End Function

        Private Shared Function LlenarDatosProducto(ByVal objData As DataRow) As material
            Dim objeto As material = New material
            objeto.materialid = Long.Parse(objData.Item("materialid"))
            objeto.nombre = objData.Item("nombre")
            objeto.descripcion = objData.Item("descripcion")
            objeto.precio = Single.Parse(objData.Item("precio"))

            objeto.materialsubgrupoid = Long.Parse(objData.Item("materialsubgrupoid"))
            objeto.estado = CBool(objData.Item("estado"))

            Return objeto
        End Function

        Public Shared Function Actualizar(ByVal vCodigo As Long, ByVal xNew As Boolean, ByRef objp As material) As DataTable
            Dim vConsulta As String = ""
            'suscripcion.pamaterial_actualizar(innew boolean, inmaterialid integer, innombre character varying, indescripcion character varying, inprecio numeric, 
            'inedad_detalle character varying, inmaterialsubgrupoid integer, inestado boolean)
            Try

                vConsulta = "select * from suscripcion.pamaterial_actualizar(" & IIf(xNew, "true", "false") & ", "
                vConsulta = vConsulta & vCodigo & " ,"
                vConsulta = vConsulta & " '" & Trim(objp.nombre) & "',"
                vConsulta = vConsulta & " '" & Trim(objp.descripcion) & "',"
                vConsulta = vConsulta & " " & Trim(Str(objp.precio)) & ","
                vConsulta = vConsulta & " '" & Trim(objp.edad_detalle) & "',"
                vConsulta = vConsulta & " " & Trim(Str(objp.materialsubgrupoid)) & ","
                vConsulta = vConsulta & " " & IIf(objp.estado, "true", "false") & " "

                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_eliminar")
            'suscripcion.pamaterial_eliminar(inmaterialid integer)
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

        Public Shared Function material_noperiodo_leerBD(ByVal vperiodoid As Integer, ByVal vlimite As Integer, ByVal vnombre As String) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_noperiodo")
            Dim oConexion As New clsConexion
            Try
                'suscripcion.pamaterial_noperiodo(vperiodoid integer, vlimite integer, vnombre character varying)
                oSP.addParameter("vperiodoid", vperiodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnombre", vnombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Material_Periodo(ByVal vPeriodoid As Long) As DataTable
            Dim TempList As New DataTable

            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_periodo_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inperiodo", vPeriodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Material_Pedido_Periodo(ByVal vPeriodoid As Long, ByVal vTipo As Integer) As DataTable
            Dim TempList As New DataTable

            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_periodo_pedidos_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inperiodo", vPeriodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Material_Periodo_Actualizar(ByVal vnew As Boolean, ByVal inperiodoid As Integer, ByVal inmaterialid As Long, ByVal indetalle As String, _
                                                            ByVal inprecio As Single, ByVal incantidad As Long, ByVal inusuarioid As Long, ByVal inip As String) As DataTable
            Dim vConsulta As String = ""
            'suscripcion.pamaterial_periodo_actualizar(innew boolean, inperiodoid integer, inmaterialid integer, inprecio numeric, 
            'incantidad integer, indetalle character varying, inusuarioid integer, inip character varying)
            Try
                vConsulta = "select * from suscripcion.pamaterial_periodo_actualizar(" & IIf(vnew, "true", "false") & ", "
                vConsulta = vConsulta & Trim(Str(inperiodoid)) & " ,"
                vConsulta = vConsulta & Trim(Str(inmaterialid)) & " ,"
                vConsulta = vConsulta & Trim(Str(inprecio)) & " ,"
                vConsulta = vConsulta & Trim(Str(incantidad)) & " ,'"
                vConsulta = vConsulta & Trim((indetalle)) & "' ,"
                vConsulta = vConsulta & Trim(Str(inusuarioid)) & ", '"
                vConsulta = vConsulta & Trim((inip)) & "' "

                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Material_Periodo_Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Material_Periodo_Eliminar(ByVal vPeriodoid As Long, ByVal vArr As String) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from suscripcion.pamaterial_periodo_delete("
                vConsulta = vConsulta & Trim(Str(vPeriodoid)) & " ,"
                vConsulta = vConsulta & Trim((vArr)) & " "

                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Material_Periodo_Eliminar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Material_Producto_Periodo(ByVal vPeriodoid As Long, ByVal vMaterialid As Long, ByVal vProductoid As Long) As DataTable
            Dim TempList As New DataTable

            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_producto_periodo_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inperiodo", vPeriodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmaterialid", vMaterialid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inproductoid", vProductoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Material_Periodo_Producto_Actualizar(ByVal vnew As Boolean, ByVal tipoPedidoID As Integer, ByVal inperiodoid As Integer, _
                                                                    ByVal inmaterialid As Long, ByVal inproductoid As Long, ByVal inprecio As Single, _
                                                                    ByVal incantidad As Long, ByVal inusuarioid As Long, ByVal inip As String) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from suscripcion.pamaterial_producto_periodo_actualizar(" & IIf(vnew, "true", "false") & ", "
                vConsulta = vConsulta & Trim(Str(tipoPedidoID)) & " ,"
                vConsulta = vConsulta & Trim(Str(inperiodoid)) & " ,"
                vConsulta = vConsulta & Trim(Str(inmaterialid)) & " ,"
                vConsulta = vConsulta & Trim(Str(inproductoid)) & " ,"
                vConsulta = vConsulta & Trim(Str(inprecio)) & " ,"
                vConsulta = vConsulta & Trim(Str(incantidad)) & " ,"
                vConsulta = vConsulta & Trim(Str(inusuarioid)) & ", '"
                vConsulta = vConsulta & Trim((inip)) & "' "

                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Material_Periodo_Producto_Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Material_Periodo_Producto_Eliminar(ByVal vTipoPedidoid As Integer, ByVal vPeriodoid As Long, ByVal vMaterialId As Long, ByVal vArr As String, ByVal vUsuarioId As Long, ByVal vCaja As String) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from suscripcion.pamaterial_producto_periodo_eliminar("
                vConsulta = vConsulta & Trim(Str(vTipoPedidoid)) & ", "
                vConsulta = vConsulta & Trim(Str(vPeriodoid)) & ", "
                vConsulta = vConsulta & Trim(Str(vMaterialId)) & ", "
                vConsulta = vConsulta & Trim((vArr)) & ", "
                vConsulta = vConsulta & Trim(Str(vUsuarioId)) & ", '"
                vConsulta = vConsulta & Trim((vCaja)) & "' "

                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Material_Periodo_Producto_Eliminar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Material_Producto_Periodo_rpt(ByVal vPeriodoid As Long, ByVal vTipoPedidoid As Long, ByVal vMaterialid As Long) As DataTable
            Dim TempList As New DataTable

            Dim oSP As New clsStored_Procedure("suscripcion.pamaterial_producto_periodo_rpt")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inperiodo", vPeriodoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipopedidoid", vTipoPedidoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmaterialid", vMaterialid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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