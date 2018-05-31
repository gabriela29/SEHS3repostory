Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class arqueo_fondo_fBD
        Public Shared Function GetList_Fondo_Fijo(ByVal vCodigo_Usu As Long, ByVal vCodigo_Alm As Integer, ByVal vfdesde As String, ByVal vfHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_fondo_fijo_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo_usu", vCodigo_Usu, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfdesde", vfdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vfHasta", vfHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Obtener_Data_Arqueo(ByVal vLoteID As Long, ByVal vFecha As String, ByRef dtDocumentos As DataTable, _
                                            ByVal dtBill As DataTable, ByVal dtMon As DataTable, ByVal dtDoll As DataTable) As Boolean
            Dim TempList As New DataTable
            Dim Cadena As String
            Dim objParam As NpgsqlParameter
            Dim oConexion As New clsConexion

            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString

            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.paplantilla_arqueo_lote_cursor", objCon)
                objCmd.CommandType = CommandType.StoredProcedure


                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "vlote"
                objParam.Value = vLoteID
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 15
                objParam.ParameterName = "vfecha"
                objParam.Value = vFecha
                objCmd.Parameters.Add(objParam)

                Dim t As NpgsqlTransaction = objCon.BeginTransaction()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader

                Dim dar As DataReaderAdapter = New DataReaderAdapter()

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

        Public Shared Function Registrar_Arqueo(ByRef obj_Arq As arqueo_fondo_fijo, ByVal MyArr As String) As DataTable

            Dim vConsulta As String
            'paarqueo_fondo_fijo_actualizar(incodigo integer, infecha character varying, incodigo_alm integer, incodigo_us integer, innumerolote integer, infondofijo numeric, indetalle character varying, incerrado boolean, incaja character varying, myarr character varying[])
            Try

                vConsulta = "select * from finanzas.paarqueo_fondo_fijo_actualizar(0,"
                vConsulta = vConsulta & "'" & obj_Arq.fecha.ToString & "',"
                vConsulta = vConsulta & obj_Arq.codigo_uni.ToString & ","
                vConsulta = vConsulta & obj_Arq.codigo_us.ToString & ","
                vConsulta = vConsulta & obj_Arq.numerolote.ToString & ","
                vConsulta = vConsulta & obj_Arq.fondofijo.ToString & ","
                vConsulta = vConsulta & "'" & obj_Arq.detalle & "',"
                vConsulta = vConsulta & obj_Arq.cerrado.ToString & ","
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


        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_fondo_fijo_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_uni", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetFondo_Fijo(ByVal vCod_uni As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paalmacen_fondo_fijo_getrow")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_uni", vCod_uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function


        Public Shared Function Eliminar(ByVal codigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_fondo_fijo_eliminar")
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
            Dim oSP As New clsStored_Procedure("finanzas.paarqueo_fondo_fijo_cambiar_estado")
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
            Dim oSP As New clsStored_Procedure("finanzas.pareporte_arqueo_fondo_fijo")
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

