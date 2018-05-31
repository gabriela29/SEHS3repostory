Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO


Namespace Dal
    Public Class productotmpBD
        Public Shared Function Consultar_Registros(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 20, _
                                                 Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                 Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paproducto_consulta")
            Dim oConexion As New clsConexion
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vano", vAno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vcategoria", vNombre_Categoria, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vproducto", vCodigo_Producto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vidbarras", vCodigo_Barras, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function
        'vcodigo_ven integer, valmacen integer, vlimite integer, vnombre character varying, vcategoria character varying, vproducto integer, vidbarras
        Public Shared Function Consultar_Registros_Venta(ByVal vCodigo_V As Long, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 200, _
                                                            Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                            Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paproducto_consulta_venta")
            Dim oConexion As New clsConexion
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vcodigo_ven", vCodigo_V, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vcategoria", vNombre_Categoria, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vproducto", vCodigo_Producto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vidbarras", vCodigo_Barras, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vlimite As Integer, _
                                    ByVal vNombre_Presentacion As String, ByVal vNombre_Categoria As String, _
                                    ByVal vCodigo_Producto As Long, ByVal vCodigo_SubCategoria As Integer, _
                                    ByVal vCodigo_Categoria As Integer, ByVal vCodigo_Marca As Integer, _
                                    ByVal vCodigo_Unidad As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paproducto_leer")
            Dim oConexion As New clsConexion
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vano", vAno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("vnombre_presentacion", vNombre_Presentacion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vnombre_categoria", vNombre_Categoria, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vcodigo_producto", vCodigo_Producto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_subcategoria", vCodigo_SubCategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_categoria", vCodigo_Categoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_marca", vCodigo_Marca, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_unidad", vCodigo_Unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetCombos_Cursor(ByRef dtFamilia As DataTable, ByRef dtGrupo As DataTable, ByRef dtMedida As DataTable) As Boolean

            Dim xOk As Boolean = False
            Dim Cadena As String, xNom As String = ""
            'Dim oConexion As New clsConexion
            Dim objParam As NpgsqlParameter

            Cadena = ""  'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("paproducto_combo_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "innombre"
                objParam.Value = xNom
                objCmd.Parameters.Add(objParam)


                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtFamilia, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtGrupo, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtMedida, objReader)
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

        Public Shared Function Actualizar(ByVal vCodigo As Long, ByVal xNew As Boolean, ByRef objp As productotmp) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from paproducto_actualizar(" & IIf(xNew, "true", "false") & ", "
                vConsulta = vConsulta & vCodigo & " ,"
                vConsulta = vConsulta & " '" & Trim(objp.Nombre_Producto) & "',"
                vConsulta = vConsulta & " '" & Trim(objp.Presentacion) & "',"
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_Compra)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VA)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VB)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Stock_Minimo)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Stock_Maximo)) & ","
                vConsulta = vConsulta & " '" & objp.Codigo_Barras & "',"
                vConsulta = vConsulta & " " & IIf(objp.Afecto_Dzmo, "true", "false") & ","
                vConsulta = vConsulta & " " & IIf(objp.Afecto_Igv, "true", "false") & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Codigo_SubCategoria)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Codigo_Grupo)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Codigo_Unidad_Medida)) & ", "
                vConsulta = vConsulta & " " & Trim(Str(objp.Paginas)) & " "
                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function


        Private Shared Function LlenarDatosProducto(ByVal objData As DataRow) As productotmp
            Dim objeto As productotmp = New productotmp
            objeto.Codigo = Long.Parse(objData.Item("codigo"))
            objeto.Nombre_Producto = objData.Item("nombre")
            objeto.Presentacion = objData.Item("presentacion")
            objeto.Precio_Compra = objData.Item("precio_com")
            objeto.Precio_VA = Single.Parse(objData.Item("precio_va"))
            objeto.Precio_VB = Single.Parse(objData.Item("precio_vb"))
            objeto.Stock_Minimo = Single.Parse(objData.Item("stock_min"))
            objeto.Stock_Maximo = Single.Parse(objData.Item("stock_max"))
            objeto.Codigo_Barras = Trim(objData.Item("codigo_barras"))
            objeto.Afecto_Dzmo = CBool(objData.Item("afecto_dzmo"))
            objeto.Afecto_Igv = CBool(objData.Item("afecto_igv"))
            objeto.Codigo_SubCategoria = Long.Parse(objData.Item("codigo_sub"))
            objeto.Codigo_Grupo = Long.Parse(objData.Item("codigo_gru"))
            objeto.Codigo_Unidad_Medida = Long.Parse(objData.Item("codigo_uni"))
            objeto.Paginas = Long.Parse(objData.Item("paginas"))
            Return objeto
        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As productotmp
            Dim objProd As productotmp = Nothing
            Dim myRs As DataTable
            Dim objReader As DataRow
            Dim oConexion As New clsConexion
            Dim vCadena As String
            vCadena = "select * from producto where codigo= " & vCodigo

            myRs = oConexion.Ejecutar_Consulta(vCadena)

            Try
                objReader = Nothing
                If myRs.Rows.Count > 0 Then
                    objReader = myRs.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objProd = LlenarDatosProducto(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try

            Catch ex As Exception
                Exit Try
            End Try
            oConexion.Cerrar_Conexion()
            oConexion = Nothing
            Return objProd
        End Function

        Public Shared Function Eliminar(ByVal codigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("paproducto_eliminar")
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


        Public Shared Function GetList_SUBCAT(ByVal vNombre As String, ByVal vCodigo_Cat As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("pasubcategoria_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)
                oSP.addParameter("incodigo_cat", vCodigo_Cat, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Actualizar_Proveedor(ByVal vCodigo_pro As Long, ByVal vCodigo_per As Long, ByVal vAnio As Integer, _
                                                    ByVal vCodigo_Pro_Prov As String, ByVal vPrecioS As Single, ByVal vPrecioD As Single) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from catalogo.paproducto_proveedor_actualizar("
                vConsulta = vConsulta & vCodigo_pro & " ,"
                vConsulta = vConsulta & vCodigo_per & " ,"
                vConsulta = vConsulta & vAnio & ", '"
                vConsulta = vConsulta & vCodigo_Pro_Prov & "', "
                vConsulta = vConsulta & vPrecioS & ", "
                vConsulta = vConsulta & vPrecioD & " "
                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Actualizar_Proveedor = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

    Public Shared Function Actualizar_Ubicacion(ByVal vCodigo_pro As Long, ByVal vCodigo_Alm As Integer,
                                                ByVal vUbicacion As String, ByVal vUbicacionB As String) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from catalogo.paproducto_ubigeo_almacen_actualizar("
        vConsulta = vConsulta & vCodigo_pro & ", "
        vConsulta = vConsulta & vCodigo_Alm & ", '"
        vConsulta = vConsulta & vUbicacion & "', '"
        vConsulta = vConsulta & vUbicacionB & "' "
        vConsulta = vConsulta & " )"

        Dim oConexion As New clsConexion
        Actualizar_Ubicacion = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

    Public Shared Function Actualizar_Precio_Almacen(ByVal vProductoid As Long, ByVal vAlmacenid As Integer,
                                                      ByVal vPrecio As Single, ByVal vPrecioB As Single) As DataTable
      Dim vConsulta As String = ""

      Try
        vConsulta = "select * from catalogo.paproducto_almacen_precio_actualizar("
        vConsulta = vConsulta & vProductoid & ", "
        vConsulta = vConsulta & vAlmacenid & ", "
        vConsulta = vConsulta & vPrecio & ", "
        vConsulta = vConsulta & vPrecioB & " "
        vConsulta = vConsulta & " )"

        Dim oConexion As New clsConexion
        Actualizar_Precio_Almacen = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
    End Function

  End Class
End Namespace
