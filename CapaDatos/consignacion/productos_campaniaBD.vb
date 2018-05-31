

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class productos_campaniaBD
        Public Shared Function Producto_Campania_leer(ByVal vCampania As Long, ByVal vCodigo_Almacen As Integer, ByVal vAnio As Integer) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproductos_campania_leer")
            Dim oConexion As New clsConexion
            Try
                'colportaje.paproductos_campania_leer(vano integer, valmacen integer, vcampania integer)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As productos_campania
            Dim objp As productos_campania = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproductos_campania_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing
            Try
                oSP.addParameter("vproductocampid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)

                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If

                Try
                    If Not objReader Is Nothing Then
                        objp = LlenarDatosProducto(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objp
        End Function

        Private Shared Function LlenarDatosProducto(ByVal objData As DataRow) As productos_campania
            Dim objeto As productos_campania = New productos_campania
            objeto.productoscampaniaid = Long.Parse(objData.Item("productoscampaniaid"))
            objeto.campaniaid = objData.Item("campaniaid")
            objeto.productoid = objData.Item("productoid")
            objeto.Abreviatura = objData.Item("abreviatura")
            objeto.precio = Single.Parse(objData.Item("precio"))

            objeto.Afecto_Igv = CBool(objData.Item("afecto_igv"))
            objeto.afecto_dzmo = CBool(objData.Item("afecto_dzmo"))
            objeto.afecto_plus_esc = CBool(objData.Item("afecto_plus_esc"))


            objeto.usuarioid = Long.Parse(objData.Item("usuarioid"))
            objeto.caja = (objData.Item("caja"))

            objeto.Producto = objData.Item("producto")
            Return objeto
        End Function

        Public Shared Function Actualizar(ByVal vCodigo As Long, ByVal xNew As Boolean, ByRef objp As productos_campania) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from colportaje.paproductos_campania_actualizar(" & IIf(xNew, "true", "false") & ", "
                vConsulta = vConsulta & " " & Trim(objp.productoscampaniaid) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.campaniaid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.productoid)) & ","
                vConsulta = vConsulta & " '" & Trim(objp.Abreviatura) & "',"
                vConsulta = vConsulta & " " & Trim(Str(objp.precio)) & ","
                vConsulta = vConsulta & " " & IIf(objp.afecto_igv, "true", "false") & ","
                vConsulta = vConsulta & " " & IIf(objp.afecto_dzmo, "true", "false") & ","
                vConsulta = vConsulta & " " & IIf(objp.afecto_plus_esc, "true", "false") & ","

                vConsulta = vConsulta & " " & Trim(Str(objp.usuarioid)) & ", "
                vConsulta = vConsulta & " '" & Trim(objp.caja) & "' "
                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproductos_campania_eliminar")
            Try
                oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

