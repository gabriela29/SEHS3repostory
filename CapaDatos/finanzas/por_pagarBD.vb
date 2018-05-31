Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class por_pagarBD
        Public Shared Function Leer_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paporpagar_leer_res")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Grabar(ByRef objPC As por_pagar) As DataTable
            Dim vConsulta As String = ""

            Try
                vConsulta = "select * from finanzas.papagar_actualizar(true,"
                vConsulta = vConsulta & " 0,"
                vConsulta = vConsulta & Trim(Str(objPC.Codigo_Almacen)) & ", "
                vConsulta = vConsulta & Trim(Str(objPC.Codigo_Persona)) & ","
                vConsulta = vConsulta & Trim(Str(objPC.Codigo_Documento)) & ",'"
                vConsulta = vConsulta & Trim(objPC.Numero) & "','"
                vConsulta = vConsulta & Trim(objPC.condicion) & "','"
                vConsulta = vConsulta & Trim(objPC.Letra) & "',"
                vConsulta = vConsulta & Trim(Str(objPC.Renovacion)) & ",'"

                vConsulta = vConsulta & (objPC.fecha) & "','"
                vConsulta = vConsulta & (objPC.Vencimiento) & "',"
                vConsulta = vConsulta & Trim(Str(objPC.Importe)) & ","
                vConsulta = vConsulta & Trim(Str(objPC.Saldo)) & ",'"
                vConsulta = vConsulta & Trim(objPC.Moneda) & "',"
                vConsulta = vConsulta & Trim(Str(objPC.Cambio)) & ",'"

                vConsulta = vConsulta & Trim(objPC.Observacion) & "','"

                vConsulta = vConsulta & Trim(objPC.Referencia_Exterior) & "',"
                vConsulta = vConsulta & Trim(Str(objPC.Codigo1_RefExt)) & ","
                vConsulta = vConsulta & Trim(Str(objPC.Codigo2_RefExt)) & ","
                vConsulta = vConsulta & Trim(Str(objPC.UsuarioId)) & ",'"
                vConsulta = vConsulta & Trim(objPC.caja) & "',"
                vConsulta = vConsulta & IIf(objPC.Cerrado, "true", "false") & ","
                vConsulta = vConsulta & IIf(objPC.Estado, "true", "false") & ","

                vConsulta = vConsulta & Trim(objPC.NroCuenta) & "','"
                vConsulta = vConsulta & Trim(objPC.C_Costo) & "'"

                vConsulta = vConsulta & ")"

                'innew boolean, inporcobrarid integer, inalmacenid integer, inclienteid integer, indocumentoid integer, 
                'innumero character varying, incondicion character varying, inletra character varying, inrenovacion integer, 
                'infecha date, invencimiento date, inimporte numeric, insaldo numeric, inmoneda character varying, incambio numeric, 
                'insigno character varying, inobservacion character varying, inreferencia character varying, incodigo_ref1 integer, 
                'incodigo_ref2 integer, inusuarioid integer, incaja character varying, incerrado boolean, inestado boolean, 
                'inincluir_registro boolean, innroctamaestra character varying, inc_costo character varying

                'vArray_DT

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vConsulta = ""
            End Try
        End Function

        Public Shared Function Leer_Detalles(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, _
                                             ByVal vOpcion As Integer, ByVal vPersona As Long, ByVal dtCabecera As DataTable, _
                                             ByVal dtDetalle As DataTable) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion

            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paporpagar_leer_det", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vunidad"
                objParam.Value = vUnidad
                objCmd.Parameters.Add(objParam)

                'objParam.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "valmacen"
                objParam.Value = vAlmacen
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "vhasta"
                objParam.Value = vhasta
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vOpcion"
                objParam.Value = vOpcion
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vpersona"
                objParam.Value = vPersona
                objCmd.Parameters.Add(objParam)


                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtCabecera, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtDetalle, objReader)
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

        Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paporpagar_experian")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function RptPorCobrar_Res(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long, _
                                                ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
            Dim TempList As New DataTable
            'Dim oSP As New clsStored_Procedure("pareporte_list_cxc")  pac_x_c_list_colp
            Dim oSP As New clsStored_Procedure("finanzas.pac_x_p_list_res")
            Dim oConexion As New clsConexion
            Try
                'If Not vDesde = "" Then
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                'End If
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function RptEstado_Cuenta(ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String,
                                            ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("finanzas.paestado_cuenta_pp")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidad", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

            Dim oSP As New clsStored_Procedure("finanzas.paporcobrar_eliminar")
            Try
                oSP.addParameter("incodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("incaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

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


