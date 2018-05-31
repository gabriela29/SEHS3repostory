
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class productoBD

        Public Shared Function Consultar_Registros(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 10, _
                                                      Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                      Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "", _
                                                      Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta")
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
                oSP.addParameter("vconsaldo", vCon_Saldo, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consultar_Registros_Colp(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 10, _
                                                          Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                          Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "", _
                                                          Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproducto_consulta")
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
                oSP.addParameter("vconsaldo", vCon_Saldo, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consultar_Registros_Consig(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 10, _
                                                          Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                          Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "", _
                                                          Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta_consig")
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
                oSP.addParameter("vconsaldo", vCon_Saldo, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consultar_Registros_Salida(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 20, _
                                                      Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                      Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta_salida")
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

        Public Shared Function Consultar_Registros_Compra(ByVal vCodigo_C As Long, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 200, _
                                                            Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                            Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta_compra")
            Dim oConexion As New clsConexion
            Try
                '(vcodigo integer, valmacen integer, vlimite integer, vnombre character varying, vcategoria character varying, vproducto integer, vidbarras character varying)
                oSP.addParameter("vcodigo", vCodigo_C, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta_venta")
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

    Public Shared Function Consultar_Registros_Asistente(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vCampaniaId As Integer, ByVal vCodigo_Asis As Long,
                                                              ByVal vTipo As Integer, Optional ByVal vlimite As Integer = 50,
                                                              Optional ByVal vNombre As String = "", Optional ByVal vProducto As Long = 0,
                                                              Optional ByVal vCodigo_Barras As String = "") As DataTable

      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.paproductos_campania_asis_leer")
      Dim oConexion As New clsConexion

      Try
        'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
        oSP.addParameter("vano", vAno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcampania", vCampaniaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vNombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vproducto", vProducto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vbarras", vCodigo_Barras, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vasistente", vCodigo_Asis, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Consultar_Registros_Bloque(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vCodigo_Asis As Long, _
                                                       ByVal vTipo As Integer, Optional ByVal vlimite As Integer = 50, _
                                                       Optional ByVal vNombre As String = "", Optional ByVal vProducto As Long = 0, _
                                                       Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproductos_bloque_leer")
            Dim oConexion As New clsConexion
            Dim vCampania As Integer = 0
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vano", vAno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vNombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vproducto", vProducto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vbarras", vCodigo_Barras, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vasistente", vCodigo_Asis, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consultar_Productos_Campania(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vCodigo_Asis As Long, _
                                                      ByVal vTipo As Integer, Optional ByVal vlimite As Integer = 50, _
                                                      Optional ByVal vNombre As String = "", Optional ByVal vProducto As Long = 0, _
                                                      Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paproductos_campania_asis_leer")
            Dim oConexion As New clsConexion
            Dim vCampania As Integer = 0
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vano", vAno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vNombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vproducto", vProducto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vbarras", vCodigo_Barras, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vasistente", vCodigo_Asis, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vlimite", vlimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Consultar_Registros_Plan_Venco(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 10, _
                                                                  Optional ByVal vNombre As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                                  Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_Barras As String = "") As DataTable

            Dim TempList As New DataTable
            'paproducto_consulta_plan_venco(vano integer, valmacen integer, vlimite integer, vnombre character varying, vcategoria character varying, vproducto integer, vidbarras character varying)
            Dim oSP As New clsStored_Procedure("inventarios.paproducto_consulta_plan_venco")
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

        Public Shared Function Leer(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vlimite As Integer, _
                                    ByVal vNombre_Presentacion As String, ByVal vNombre_Categoria As String, _
                                    ByVal vCodigo_Producto As Long, ByVal vCodigo_SubCategoria As Integer, _
                                    ByVal vCodigo_Categoria As Integer, ByVal vCodigo_Marca As Integer, _
                                    ByVal vCodigo_Unidad As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("catalogo.paproducto_leer")
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
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("catalogo.paproducto_combo_cursor", objCon)
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

        Public Shared Function Actualizar(ByVal vCodigo As Long, ByVal xNew As Boolean, ByRef objp As producto, vArrLibro As String) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from catalogo.paproducto_actualizar(" & IIf(xNew, "true", "false") & ", "
                vConsulta = vConsulta & vCodigo & " ,"
                vConsulta = vConsulta & " '" & Trim(objp.Nombre_Producto) & "',"
                vConsulta = vConsulta & " '" & Trim(objp.Presentacion) & "',"
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_Compra)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VA)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VB)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VC)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Precio_VD)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Peso)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Stock_Minimo)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.Stock_Maximo)) & ","
                vConsulta = vConsulta & " '" & objp.Codigo_Barras & "',"
                vConsulta = vConsulta & " " & IIf(objp.Exonerado, "true", "false") & ","
                vConsulta = vConsulta & " " & IIf(objp.Afecto_Igv, "true", "false") & ","

                vConsulta = vConsulta & " " & IIf(objp.fraccion, "true", "false") & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.fraccionproductoid)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.fraccioncantidad)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.marcaid)) & ","

                vConsulta = vConsulta & " " & Trim(Str(objp.SubCategoriaId)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.GrupoId)) & ","
                vConsulta = vConsulta & " " & Trim(Str(objp.UnidadMedidaId)) & ", "

                vConsulta = vConsulta & " " & IIf(objp.estado, "true", "false") & ", "
                vConsulta = vConsulta & " " & Trim(Str(objp.usuarioid)) & ", "
                vConsulta = vConsulta & " " & Trim(vArrLibro) & " "
                vConsulta = vConsulta & " )"

                Dim oConexion As New clsConexion
                Actualizar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Private Shared Function LlenarDatosProducto(ByVal objData As DataRow) As producto
            Dim objeto As producto = New producto
            objeto.ProductoId = Long.Parse(objData.Item("productoid"))
            objeto.Nombre_Producto = objData.Item("nombre")
            objeto.Presentacion = objData.Item("presentacion")
            objeto.Precio_Compra = objData.Item("precio_com")
            objeto.Precio_VA = Single.Parse(objData.Item("precio_va"))
            objeto.Precio_VB = Single.Parse(objData.Item("precio_vb"))
            objeto.Stock_Minimo = Single.Parse(objData.Item("stock_min"))
            objeto.Stock_Maximo = Single.Parse(objData.Item("stock_max"))
            objeto.Codigo_Barras = Trim(objData.Item("codigo_barras"))
            objeto.Exonerado = CBool(objData.Item("exonerado"))
            objeto.Afecto_Igv = CBool(objData.Item("afecto_igv"))
            objeto.SubCategoriaId = Long.Parse(objData.Item("subcategoriaid"))
            objeto.GrupoId = Long.Parse(objData.Item("grupoid"))
            objeto.UnidadMedidaId = Long.Parse(objData.Item("unidadmedidaid"))

            objeto.editorialid = Long.Parse(objData.Item("editorialid"))
            objeto.editorial = objData.Item("editorial")
            objeto.edicion = objData.Item("edicion")
            objeto.paginas = Long.Parse(objData.Item("paginas"))
            objeto.alto = Long.Parse(objData.Item("alto"))
            objeto.ancho = Long.Parse(objData.Item("ancho"))
            objeto.autorid = Long.Parse(objData.Item("autorid"))
            objeto.autor = (objData.Item("autor"))

            Return objeto
        End Function


        Public Shared Function GetItem(ByVal vCodigo As Long) As producto
            Dim objp As producto = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("catalogo.paproducto_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow = Nothing
            Try
                oSP.addParameter("vproductoid", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

        Public Shared Function Eliminar(ByVal codigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("catalogo.paproducto_eliminar")
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


        Public Shared Function Consultar_Kardex(ByVal vProductoID As Long, ByVal vCodigo_Almacen As Integer, ByVal vAnio As Integer) As DataTable

            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.pakardex_leer")
            Dim oConexion As New clsConexion
            Try
                'vano, valmacen, vlimite, vnombre, vcategoria, vproducto integer, vidbarras
                oSP.addParameter("vproductoid", vProductoID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

