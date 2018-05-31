Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class arqueo_ingresosBD
        Public Shared Function GetList(ByVal vCodigo_Us As Long, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_ingreso_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo_us", vCodigo_Us, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Obtener_Data_Arqueo(ByVal vCodigo_Us As Long, ByVal vCodigo_Alm As Integer, _
                                                    ByVal vDesde As String, ByVal vHasta As String, _
                                                    ByRef dtIngresos As DataTable, ByRef dtDocumentos As DataTable, _
                                                    ByVal dtBill As DataTable, ByVal dtMon As DataTable, ByVal dtDoll As DataTable) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion

            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paplantilla_arqueo_consulta_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                'objParam.addParameter("vcodigo_alumno", vcodigo_alumno, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vcodigo_us"
                objParam.Value = vCodigo_Us
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 15
                objParam.ParameterName = "vdesde"
                objParam.Value = vDesde
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 15
                objParam.ParameterName = "vhasta"
                objParam.Value = vDesde
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "valmacen"
                objParam.Value = vCodigo_Alm
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

                dar.FillFromReader(dtIngresos, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtDocumentos, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtMon, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtBill, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtDoll, objReader)
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

        Public Shared Function Registrar_Arqueo(ByRef obj_Arq As arqueo_ingresos, ByVal MyArr As String) As DataTable

            Dim vConsulta As String

            Try
                'incodigo integer, infecha date, incodigo_alm integer, incodigo_us integer, intotal_ing numeric, 
                'inretiro numeric, indetalle character varying, incaja character varying, myarr character varying[]

                vConsulta = "select * from finanzas.paarqueo_ingreso_actualizar(0,"
                vConsulta = vConsulta & "'" & obj_Arq.fecha.ToString & "',"
                vConsulta = vConsulta & obj_Arq.codigo_alm.ToString & ","
                vConsulta = vConsulta & obj_Arq.codigo_us.ToString & ","
                vConsulta = vConsulta & obj_Arq.total_ing.ToString & ","
                vConsulta = vConsulta & obj_Arq.retiro.ToString & ","
                vConsulta = vConsulta & "'" & obj_Arq.detalle & "',"
                vConsulta = vConsulta & "'" & obj_Arq.caja.ToString & "',"
                vConsulta = vConsulta & MyArr & ")"

                Dim oConexion As New clsConexion
                Registrar_Arqueo = oConexion.Ejecutar_Consulta(vConsulta)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing

            Finally
                'oSP = Nothing
            End Try

        End Function

        Public Shared Function Eliminar(ByVal codigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_ingreso_eliminar")
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

        Public Shared Function Cambiar_Estado(ByVal codigo As Long, ByVal vStado As Boolean) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_ingreso_cambiar_estado")
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("incerrado", vStado, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)
                Dim oConexion As New clsConexion
                Cambiar_Estado = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function GetRpt(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.reporte_arqueo_ingresos")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vCodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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

