
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class lista_negraBD
        Public Shared Function GetItem(ByVal codigo As Integer) As lista_negra
            Dim objrol As lista_negra = Nothing
            Dim cadena As String
            cadena = "" 'ConfigurationManager.ConnectionStrings("BDPostgresql").ConnectionString
            Dim objCon As NpgsqlConnection = New NpgsqlConnection(cadena)
            Dim objParam As New NpgsqlParameter
            Try
                objCon = clsConexion.ObtenerConexion : Dim objCmd As NpgsqlCommand = New NpgsqlCommand("finanzas.palista_negra_getrow", objCon)

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

        Public Shared Function GetList(ByVal vDesde As String, ByVal vHasta As String, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As String 'New clsStored_Procedure("basic.parol_leer")
            Dim oConexion As New clsConexion
            Try
                oSP = "select * from finanzas.palista_negra_leer('"
                oSP = oSP & vDesde & "','"
                oSP = oSP & vHasta & "','"
                oSP = oSP & vNombre & "');"
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As IDataRecord) As lista_negra
            Dim objeto As lista_negra = New lista_negra
            objeto.personaid = objData.Item("personaid")
            objeto.persona = objData.Item("nom_persona")
            objeto.comentario = objData.Item("comentario")

            Return objeto
        End Function

        Public Shared Function Grabar(ByVal vNew As Boolean, ByRef obj As lista_negra, ByVal vUsuarioId As Long, ByVal vIp As String) As DataTable
            Dim oSP As String = "" 'New clsStored_Procedure("finanzas.palista_negra_actualizar")
            Try
                oSP = "select * from finanzas.palista_negra_actualizar("
                oSP = oSP & IIf(vNew, "true", "false") & ","
                oSP = oSP & obj.personaid & ",'"
                oSP = oSP & obj.comentario & "',"
                oSP = oSP & vUsuarioId & ",'"
                oSP = oSP & vIp & "');"

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("finanzas.palista_negra_eliminar")
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
    End Class

End Namespace
