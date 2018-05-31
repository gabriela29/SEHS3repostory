Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class distritoBD
        Public Shared Function GetItem(ByVal Id As Integer) As distrito
            Dim objstrito As distrito = Nothing
            Dim vCadena As String = ""
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(vCadena)
            objCon = clsConexion.ObtenerConexion
            Dim objParam As New NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padistrito_getrow", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo"
                objParam.Value = Id
                objCmd.Parameters.Add(objParam)
                'objCon.Open()
                'objCmd.Prepare()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader
                Try
                    If objReader.Read Then
                        objstrito = LlenarDatosRegistro(objReader)
                    End If
                    objReader.Close()
                Finally
                    CType(objReader, IDisposable).Dispose()
                End Try
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return objstrito
        End Function
        Public Shared Function GetList(ByVal cod_prov As Integer, ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim objParam As NpgsqlParameter
            Dim Cadena As String
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padistrito_consulta", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo_prov"
                objParam.Value = cod_prov
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "innombre"
                objParam.Value = descripcion
                objCmd.Parameters.Add(objParam)
                'objCon.Open()
                'objCmd.Prepare()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader
                Try
                    Dim dar As DataReaderAdapter = New DataReaderAdapter()
                    dar.FillFromReader(TempList, objReader)
                    objReader.Close()
                Finally
                    CType(objReader, IDisposable).Dispose()
                End Try
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return TempList
        End Function

        Public Shared Function GetUbigeo(ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim objParam As NpgsqlParameter
            Dim Cadena As String
            Cadena = "" ' ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pa_consulta_ubigeo", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "innombre"
                objParam.Value = descripcion
                objCmd.Parameters.Add(objParam)

                'objCon.Open()
                'objCmd.Prepare()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader
                Try
                    Dim dar As DataReaderAdapter = New DataReaderAdapter()
                    dar.FillFromReader(TempList, objReader)
                    objReader.Close()
                Finally
                    CType(objReader, IDisposable).Dispose()
                End Try
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As IDataRecord) As distrito
            Dim objeto As distrito = New distrito
            objeto.codigo = objData.Item("codigo")
            objeto.nombre = objData.Item("nombre")
            objeto.codigo_pro = objData.Item("codigo_pro")
            Return objeto
        End Function
        Public Shared Function Grabar(ByRef objstrito As distrito) As Integer
            Dim Resultado As Integer = 0
            Dim vCadena As String = ""
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(vCadena)
            objCon = clsConexion.ObtenerConexion
            Dim objParam As NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padistrito_actualizar", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Direction = ParameterDirection.Input
                objParam.ParameterName = "innew"
                If objstrito.codigo = -1 Then
                    objParam.Value = True
                Else
                    objParam.Value = False
                End If
                objCmd.Parameters.Add(objParam)
                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo"
                objParam.Value = objstrito.codigo
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.Size = 50
                objParam.ParameterName = "innombre"
                objParam.Value = objstrito.nombre
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo_pro"
                objParam.Value = objstrito.codigo_pro
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "outid"
                objParam.Value = 0
                objParam.Direction = ParameterDirection.Output
                objCmd.Parameters.Add(objParam)
                Dim ValorRet As DbParameter
                ValorRet = objCmd.CreateParameter
                ValorRet.Direction = ParameterDirection.ReturnValue
                objCmd.Parameters.Add(ValorRet)
                'objCon.Open()
                objCmd.ExecuteNonQuery()
                If objstrito.codigo = -1 Then
                    objstrito.codigo = objCmd.Parameters("outid").Value
                End If
                Resultado = objCmd.Parameters("outid").Value
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return Resultado
        End Function
        Public Shared Function Eliminar(ByVal codigo As Integer) As Boolean
            Dim Resultado As Integer = 0
            Dim vCadena As String = ""
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(vCadena)
            objCon = clsConexion.ObtenerConexion
            Dim objParam As NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("padistrito_eliminar", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo"
                objParam.Value = codigo
                objCmd.Parameters.Add(objParam)
                'objCon.Open()
                objCmd.ExecuteNonQuery()
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return Resultado > 0
        End Function
    End Class
End Namespace
