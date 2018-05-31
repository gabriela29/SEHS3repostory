Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class reportes_gerencialesBD

        Public Shared Function Ventas_cliente_Audi(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long, _
                                                   ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As String, ByVal myarrrol As String) As DataTable

            Dim vConsulta As String

            Try
                vConsulta = "select * from inventarios.pareporte_ventas_cliente("
                vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
                vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vpersona)) & ","

                vConsulta = vConsulta & " '" & Trim(vdesde) & "',"
                vConsulta = vConsulta & " '" & Trim(vhasta) & "',"
                vConsulta = vConsulta & " '" & Trim(vopcion) & "',"

                vConsulta = vConsulta & " " & Trim(myarrrol) & " "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Ventas_cliente_Audi = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Ventas_cliente_Audi
        End Function

        Public Shared Function Amortizaciones_cliente_Audi(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long, _
                                            ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As String, ByVal myarrrol As String) As DataTable

            Dim vConsulta As String

            Try
                vConsulta = "select * from finanzas.pareporte_amortizaciones_cliente("
                vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
                vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
                vConsulta = vConsulta & " " & Trim(Str(vpersona)) & ","

                vConsulta = vConsulta & " '" & Trim(vdesde) & "',"
                vConsulta = vConsulta & " '" & Trim(vhasta) & "',"
                vConsulta = vConsulta & " '" & Trim(vopcion) & "',"

                vConsulta = vConsulta & " " & Trim(myarrrol) & " "

                vConsulta = vConsulta & " )"


                Dim oConexion As New clsConexion
                Amortizaciones_cliente_Audi = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
            Return Amortizaciones_cliente_Audi
        End Function

    Public Shared Function Saldo_Provisiones(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                             ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As Integer) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from finanzas.paprovision_porcobrar_res("
        'vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " '" & Trim(vhasta) & "',"
        vConsulta = vConsulta & " '" & Trim(vopcion) & "',"
        vConsulta = vConsulta & " " & Trim(Str(vpersona)) & " "

        vConsulta = vConsulta & " )"


        Dim oConexion As New clsConexion
        Saldo_Provisiones = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return Saldo_Provisiones
    End Function

    Public Shared Function PorCobrar_Provisiones_Cast(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                                        ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As Integer) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from finanzas.paporcobrar_castigo_leer_res("
        'vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " '" & Trim(vhasta) & "',"
        vConsulta = vConsulta & " '" & Trim(vopcion) & "',"
        vConsulta = vConsulta & " " & Trim(Str(vpersona)) & " "

        vConsulta = vConsulta & " )"


        Dim oConexion As New clsConexion
        PorCobrar_Provisiones_Cast = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return PorCobrar_Provisiones_Cast
    End Function

    Public Shared Function Stock_Valorado(ByVal vFuncion As String, ByVal vunidad As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal operador As String,
                                              ByVal vstock As Long, ByVal vsubcategoria As Integer, ByRef dtStock As DataTable, ByVal vGrupo As String) As Boolean
      Dim TempList As New DataTable
      Dim Cadena As String
      Dim objParam As NpgsqlParameter
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, operador varchar, vstock integer, vsubcategoria integer
      Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

      Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
      objCon = clsConexion.ObtenerConexion
      Try
        Dim objCmd As NpgsqlCommand = New NpgsqlCommand(vFuncion, objCon)
        objCmd.CommandType = CommandType.StoredProcedure

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vunidad"
        objParam.Value = vunidad
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vmes"
        objParam.Value = vmes
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vanio"
        objParam.Value = vanio
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 4
        objParam.ParameterName = "operador"
        objParam.Value = operador
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vstock"
        objParam.Value = vstock
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
        objParam.Size = 4
        objParam.ParameterName = "vsubcategoria"
        objParam.Value = vsubcategoria
        objCmd.Parameters.Add(objParam)

        objParam = New NpgsqlParameter
        objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
        objParam.Size = 50
        objParam.ParameterName = "vgrupo"
        objParam.Value = vGrupo
        objCmd.Parameters.Add(objParam)

        Dim t As NpgsqlTransaction = objCon.BeginTransaction()
        Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

        Dim dar As DataReaderAdapter = New DataReaderAdapter()

        dar.FillFromReader(dtStock, objReader)
        objReader.NextResult()

        t.Commit()
        t.Dispose()

        objReader.Close()

        CType(objReader, IDisposable).Dispose()
        objCmd = Nothing
        objReader = Nothing
        objCon.Close()
      Finally
        CType(objCon, IDisposable).Dispose()
      End Try
      Return True
    End Function

    Public Shared Function Ventas_Producto(ByVal vSql As String, ByVal vunidad As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal operador As String, _
                                               ByVal vstock As Long, ByVal vsubcategoria As Integer, ByRef dtStock As DataTable, ByVal vGrupo As String, _
                                               ByVal vreferencia As String, ByVal xproducto As Boolean, ByVal vnetas As Boolean, ByVal vigv As Boolean) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion
            'vunidad integer, vmes integer, vanio integer, operador varchar, vstock integer, vsubcategoria integer
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand(vSql, objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vunidad"
                objParam.Value = vunidad
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vdesde"
                objParam.Value = vDesde
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 20
                objParam.ParameterName = "vhasta"
                objParam.Value = vHasta
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 4
                objParam.ParameterName = "operador"
                objParam.Value = operador
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Numeric
                objParam.Size = 4
                objParam.ParameterName = "vstock"
                objParam.Value = vstock
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vsubcategoria"
                objParam.Value = vsubcategoria
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "vgrupo"
                objParam.Value = vGrupo
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "vreferencia"
                objParam.Value = vreferencia
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Size = 2
                objParam.ParameterName = "xproducto"
                objParam.Value = xproducto
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Size = 2
                objParam.ParameterName = "vnetas"
                objParam.Value = vnetas
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Size = 2
                objParam.ParameterName = "vigv"
                objParam.Value = vigv
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtStock, objReader)
                objReader.NextResult()

                t.Commit()
                t.Dispose()

                objReader.Close()

                CType(objReader, IDisposable).Dispose()
                objCmd = Nothing
                objReader = Nothing
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return True
        End Function

    Public Shared Function Movimiento_Producto(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                               ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vCategoria As Integer) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from inventarios.parptproducto_movimiento("
        'vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " '" & Trim(Str(vAnio)) & "',"
        vConsulta = vConsulta & " '" & Trim(Str(vMes)) & "',"
        vConsulta = vConsulta & " " & Trim(Str(vCategoria)) & " "

        vConsulta = vConsulta & " )"

        Dim oConexion As New clsConexion
        Movimiento_Producto = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return Movimiento_Producto
    End Function

    Public Shared Function Producto_NDias_UltimaFech_Comp(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                                            ByVal vAnio As Integer, ByVal vCategoria As Integer, ByVal vProducto As Long, ByVal vSoloStock As Boolean) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from inventarios.parptproducto_ndiascompra("
        'vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " '" & Trim(Str(vAnio)) & "',"
        vConsulta = vConsulta & " '" & Trim(Str(vCategoria)) & "',"
        vConsulta = vConsulta & " " & Trim(Str(vProducto)) & ", "
        vConsulta = vConsulta & " " & IIf(vSoloStock, "True", "False")
        vConsulta = vConsulta & " )"

        Dim oConexion As New clsConexion
        Producto_NDias_UltimaFech_Comp = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return Producto_NDias_UltimaFech_Comp
    End Function

    '========Reportes Financieros
    Public Shared Function Estado_Resultados(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                              ByVal vMes As Integer, ByVal vAnio As Integer) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from finanzas.pareporte_estado_resultado("
        'vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vMes)) & ","

        vConsulta = vConsulta & " " & Trim(vAnio) & ""


        vConsulta = vConsulta & " )"


        Dim oConexion As New clsConexion
        Estado_Resultados = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return Estado_Resultados
    End Function

    Public Shared Function Listado_Pagos_Colportaje(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vAsistente As Long,
                                                    ByVal vPersona As Long, ByVal vDesde As String, ByVal vHasta As String, ByVal vOpcion As String) As DataTable

      Dim vConsulta As String

      Try
        vConsulta = "select * from finanzas.pareporte_amortizaciones_colportajewi("
        vConsulta = vConsulta & " " & Trim(Str(vempresa)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vunidad)) & ","
        vConsulta = vConsulta & " " & Trim(Str(valmacen)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vAsistente)) & ","
        vConsulta = vConsulta & " " & Trim(Str(vPersona)) & ","

        vConsulta = vConsulta & " '" & Trim(vDesde) & "',"
        vConsulta = vConsulta & " '" & Trim(vHasta) & "',"
        vConsulta = vConsulta & " '" & Trim(vOpcion) & "'"

        vConsulta = vConsulta & " )"


        Dim oConexion As New clsConexion
        Listado_Pagos_Colportaje = oConexion.Ejecutar_Consulta(vConsulta)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vConsulta = ""
      End Try
      Return Listado_Pagos_Colportaje
    End Function

  End Class
End Namespace

