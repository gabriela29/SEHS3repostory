Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class categoria_personaBD
        Public Shared Function GetItem(ByVal codigo As Integer) As categoria_persona
            Dim objcategoria_persona As categoria_persona = Nothing
            Dim cadena As String
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)

            'Dim objCon As NpgsqlConnection = New NpgsqlConnection(ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString)
            Dim objParam As New NpgsqlParameter
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pacategoria_persona_getrow", objCon)

                'Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pacategoria_persona_getrow", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo"
                objParam.Value = codigo
                objCmd.Parameters.Add(objParam)
                objCon.Open()
                objCmd.Prepare()
                Dim objReader As NpgsqlDataReader = objCmd.ExecuteReader
                Try
                    If objReader.Read Then
                        objcategoria_persona = LlenarDatosRegistro(objReader)
                    End If
                    objReader.Close()
                Finally
                    CType(objReader, IDisposable).Dispose()
                End Try
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return objcategoria_persona
        End Function

        Public Shared Function GetList() As DataTable
            Dim TempList As New DataTable
            Dim objParam As NpgsqlParameter
            Dim vNombre As String = ""
            Dim Cadena As String
            Cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(Cadena)
            objCon = clsConexion.ObtenerConexion
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("catalogo.parol_leer", objCon)
                objCmd.CommandType = CommandType.StoredProcedure

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar
                objParam.ParameterName = "vnombre"
                objParam.Value = vNombre
                objCmd.Parameters.Add(objParam)


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

        Private Shared Function LlenarDatosRegistro(ByVal objData As IDataRecord) As categoria_persona
            Dim objeto As categoria_persona = New categoria_persona
            Objeto.codigo = objData.Item("codigo")
            Objeto.nombre = objData.Item("nombre")
            Return objeto
        End Function
        Public Shared Function Grabar(ByRef objcategoria_persona As categoria_persona) As Integer
            Dim Resultado As Integer = 0
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString)
            Dim objParam As NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pacategoria_persona_actualizar", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Boolean
                objParam.Direction = ParameterDirection.Input
                objParam.ParameterName = "innew"
                If objcategoria_persona.codigo = -1 Then
                    objParam.Value = True
                Else
                    objParam.Value = False
                End If
                objCmd.Parameters.Add(objParam)
                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.Size = 4
                objParam.ParameterName = "incodigo"
                objParam.Value = objcategoria_persona.codigo
                objCmd.Parameters.Add(objParam)

                objParam = New NpgsqlParameter
                objParam.Direction = ParameterDirection.Input
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.varchar
                objParam.Size = 50
                objParam.ParameterName = "innombre"
                objParam.Value = objcategoria_persona.nombre
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
                objCon.Open()
                objCmd.ExecuteNonQuery()
                If objcategoria_persona.codigo = -1 Then
                    objcategoria_persona.codigo = objCmd.Parameters("outid").Value
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
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString)
            Dim objParam As NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("pacategoria_persona_eliminar", objCon)
                objCmd.CommandType = CommandType.StoredProcedure
                objParam = New NpgsqlParameter
                objParam.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Integer
                objParam.ParameterName = "incodigo"
                objParam.Value = codigo
                objCmd.Parameters.Add(objParam)
                objCon.Open()
                objCmd.ExecuteNonQuery()
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return Resultado > 0
        End Function
    End Class
End Namespace
