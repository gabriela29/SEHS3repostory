Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class det_mov_mercaderiaBD

        Public Shared Function GetList(ByVal vCodigo_Mov As Integer, ByVal vModulo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_movimiento_mercaderia_leer_documentos")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_mov", vCodigo_Mov, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmodulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetCombos_Cursor(ByRef dtModulo As DataTable, ByRef dtMov As DataTable, ByRef dtDoc As DataTable) As Boolean

            Dim xOk As Boolean = False
            Dim Cadena As String, xNom As String = ""
            'Dim oConexion As New clsConexion
            Dim objParam As NpgsqlParameter

            Cadena = ""  'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padet_mov_combo_cursor", objCon)
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

                dar.FillFromReader(dtModulo, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtMov, objReader)
                objReader.NextResult()

                dar.FillFromReader(dtDoc, objReader)
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

        Public Shared Function Grabar(ByRef objdmm As det_mov_mercaderia, ByVal swNuevo As Boolean) As DataTable

            Dim oSP As New clsStored_Procedure("padetalle_movimiento_mercaderia_actualizar")
            Try
                'incodigo_uni,innombre,incentro_costo,inorden, inestado
                If swNuevo Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If

                oSP.addParameter("incodigo", objdmm.Codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_modulo", objdmm.codigo_modulo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_mov", objdmm.codigo_movimiento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incodigo_doc", objdmm.codigo_doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("insigno", objdmm.signo, NpgsqlTypes.NpgsqlDbType.Varchar, 4, ParameterDirection.Input)

                oSP.addParameter("inincluir_ref", objdmm.Incluir_Ref, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)

                oSP.addParameter("incol_dscto", objdmm.Columna_Dscto, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)


                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("padetalle_movimiento_mercaderia_eliminar")
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

        Public Shared Function Eliminar(ByVal vCodigo_Movimiento As Integer, ByVal vModulo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("padetalle_movimiento_mercaderia_leer_documentos")
            Try
                oSP.addParameter("vCodigo_Movimiento", vCodigo_Movimiento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vModulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
