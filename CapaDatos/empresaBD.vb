Imports CapaObjetosNegocio
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql

Namespace Dal

    Public Class empresaBD
        Public Shared Function GetItem(ByVal codigo As Integer) As empresa
            Dim objempresa As empresa = Nothing
            Dim TempList As New DataTable
            Dim osP As String = ""
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                ' osP = "select codigo, supper(nombre) as nombre,ruc from empresa where codigo=" & codigo
                osP = "select * from basic.empresa where empresaid=" & codigo
                TempList = oConexion.Ejecutar_Consulta(osP)
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
                osP = Nothing
            End Try
            Return objempresa
        End Function

        Public Shared Function GetList(ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.paempresa_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("empresaid", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
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
            objeto.empresaid = objData.Item("empresaid")
            objeto.nombre = objData.Item("nombre")
            objeto.ruc = objData.Item("ruc")
            objeto.direccion = objData.Item("direccion")
            objeto.url = objData.Item("url")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objempresa As empresa) As DataTable
            Dim oSP As New clsStored_Procedure("basic.paempresa_actualizar")
            Dim ncadena As String = ""
            Try

                ncadena = "select * from basic.paempresa_actualizar("
                ncadena = ncadena & " " & IIf(objempresa.empresaid > 0, "false", "true") & ", "
                ncadena = ncadena & " " & Trim(Str(objempresa.empresaid)) & ","
                ncadena = ncadena & " '" & Trim(objempresa.nombre) & "', "
                ncadena = ncadena & " '" & Trim(objempresa.ruc) & "',"
                ncadena = ncadena & " '" & Trim(objempresa.direccion) & "', "
                ncadena = ncadena & " '" & Trim(objempresa.url) & "' "
                ncadena = ncadena & ")"

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(ncadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                ncadena = ""
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("basic.paempresa_eliminar")
            Try
                oSP.addParameter("inempresaid", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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
