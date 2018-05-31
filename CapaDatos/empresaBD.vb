Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class empresaBD
        Public Shared Function GetItem(ByVal codigo As Integer) As empresa
            Dim objempresa As empresa = Nothing
            Dim TempList As New DataTable
            Dim vSql As String = ""
            'Dim oSP As New clsStored_Procedure("paempresa_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                'oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                vSql = "select codigo, supper(nombre) as nombre,ruc from empresa where codigo=" & codigo
                TempList = oConexion.Ejecutar_Consulta(vSql)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objempresa = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                'oSP = Nothing
            End Try
            Return objempresa
        End Function

        Public Shared Function GetItem_x_UNeg(ByVal codigo As Integer) As empresa
            Dim objempresa As empresa = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paempresa_por_uneg")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If Not TempList Is Nothing Then
                    If TempList.Rows.Count > 0 Then
                        objReader = TempList.Rows(0)
                    End If
                End If
                Try
                    If Not objReader Is Nothing Then
                        objempresa = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try

            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objempresa
        End Function

        Public Shared Function GetList(ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.paempresa_leer")
            Dim oConexion As New clsConexion
            Try
                'oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As empresa
            Dim objeto As empresa = New empresa
            objeto.codigo = objData.Item("codigo")
            objeto.nombre = objData.Item("nombre")
            objeto.ruc = objData.Item("ruc")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objempresa As empresa) As DataTable
            Dim oSP As New clsStored_Procedure("paempresa_actualizar")
            Try
                If objempresa.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objempresa.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objempresa.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inruc", objempresa.ruc, NpgsqlTypes.NpgsqlDbType.Varchar, 11, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("paempresa_eliminar")
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
    End Class
End Namespace
