Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class subcategoriaBD

        Public Shared Function GetItem(ByVal codigo As Integer) As subcategoria
            Dim objsc As subcategoria = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from catalogo.subcategoria where subcategoriaid=" & codigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objsc = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objsc
        End Function

        Public Shared Function GetList(ByVal vCategoriaId As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pasubcategoria_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incategoriaid", vCategoriaId, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As subcategoria
            Dim objeto As subcategoria = New subcategoria
            objeto.categoriaid = objData.Item("categoriaid")
            objeto.subcategoriaid = objData.Item("subcategoriaid")
            objeto.nombre = objData.Item("nombre")
            objeto.abrev = objData.Item("abreviatura")

            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As subcategoria) As DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pasubcategoria_actualizar")
            Try
                If objc.subcategoriaid = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("insubcategoriaid", objc.subcategoriaid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("incategoriaid", objc.categoriaid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inabrev", objc.abrev, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vSubCategoriaId As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pasubcategoria_eliminar")
            Try
                oSP.addParameter("insubcategoriaid", vSubCategoriaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
