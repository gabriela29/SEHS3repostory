Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class rolBD
        Public Shared Function GetItem(ByVal codigo As Integer) As rol
            Dim objrol As rol = Nothing
            Dim cadena As String
            cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(cadena)
            Dim objParam As New NpgsqlParameter
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("parol_getrow", objCon)

                'Dim objCmd As NpgsqlCommand = New NpgsqlCommand("parol_getrow", objCon)
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
                        objrol = LlenarDatosRegistro(objReader)
                    End If
                    objReader.Close()
                Finally
                    CType(objReader, IDisposable).Dispose()
                End Try
                objCon.Close()
            Finally
                CType(objCon, IDisposable).Dispose()
            End Try
            Return objrol
        End Function

        Public Shared Function GetList() As DataTable
            Dim TempList As New DataTable
            Dim oSP As String 'New clsStored_Procedure("basic.parol_leer")
            Dim oConexion As New clsConexion
            Try               
                oSP = "select * from basic.parol_leer()"

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As IDataRecord) As rol
            Dim objeto As rol = New rol
            objeto.rolid = objData.Item("codigo")
            objeto.nombre = objData.Item("nombre")
            objeto.abreviatura = objData.Item("abreviatura")

            objeto.imagen = objData.Item("imagen")
            objeto.estructura = objData.Item("estructura")
            objeto.tipo = objData.Item("tipo")
            objeto.pordefecto = objData.Item("pordefecto")
            objeto.orden = objData.Item("orden")
            objeto.estado = objData.Item("estado")

            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objrol As rol) As DataTable
            Dim oSP As New clsStored_Procedure("basic.parol_actualizar")
            Try
                If objrol.rolid = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("inrolid", objrol.rolid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objrol.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inabrev", objrol.abreviatura, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("inimg", objrol.imagen, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inestruct", objrol.estructura, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("intipo", objrol.tipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inorden", objrol.orden, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inestado", objrol.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As Boolean
            Dim Resultado As Integer = 0
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString)
            Dim objParam As NpgsqlParameter
            Try
                Dim objCmd As NpgsqlCommand = New NpgsqlCommand("parol_eliminar", objCon)
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
