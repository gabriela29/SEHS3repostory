Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class categoriaBD
        Public Shared Function GetItem(ByVal codigo As Integer) As categoria
            Dim objCat As categoria = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from catalogo.categoria where categoriaid=" & codigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objCat = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objCat
        End Function

        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pacategoria_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As categoria
            Dim objeto As categoria = New categoria
            objeto.categoriaid = objData.Item("categoriaid")
            objeto.nombre = objData.Item("nombre")
            objeto.abrev = objData.Item("abreviatura")

            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As categoria) As DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pacategoria_actualizar2")
            Dim vCadena As String = ""
            Try

                vCadena = "select * from catalogo.pacategoria_actualizar2( "
                vCadena = vCadena & " " & IIf(objc.categoriaid > 0, "false", "true") & ", "
                vCadena = vCadena & " " & Trim(Str(objc.categoriaid)) & ","
                vCadena = vCadena & " '" & Trim(objc.nombre) & "', "
                vCadena = vCadena & " '" & Trim(objc.abrev) & "' "
                vCadena = vCadena & ")"

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                vCadena = ""
            End Try
        End Function



        Public Shared Function Eliminar(ByVal vCategoriaId As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("catalogo.pacategoria_eliminar")
            Try
                oSP.addParameter("incategoriaid", vCategoriaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
