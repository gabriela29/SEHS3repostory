
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class gestion_accesoBD

        Public Shared Function Actualizar_Menu(vPersonaID As Long, ByVal vArray As String, ByVal vusuarioid As Long, vIp As String) As Boolean
            Dim vCadena As String = ""
            Dim vDt As New DataTable, vOk As Boolean = False
            Try

                vCadena = "select * from basic.papermisos_menuwindow_registrar( "
                vCadena = vCadena & " " & Trim(Str(vPersonaID)) & ","
                vCadena = vCadena & " " & Trim(vArray) & ","
                vCadena = vCadena & " " & Trim(Str(vusuarioid)) & ","
                vCadena = vCadena & " '" & Trim(vIp) & "' "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                vDt = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                vOk = True

            Catch ex As Exception
                vCadena = ""
                vOk = False
            End Try
            Return vOk
        End Function

        Public Shared Function Actualizar_ModAlm(vPersonaID As Long, ByVal vArray As String, ByVal vusuarioid As Long, vIp As String) As Boolean
            Dim vCadena As String = ""
            Dim vDt As New DataTable, vOk As Boolean = False
            Try

                vCadena = "select * from basic.papermisos_almacen_registrar( "
                vCadena = vCadena & " " & Trim(Str(vPersonaID)) & ","
                vCadena = vCadena & " " & Trim(vArray) & " "
                'vCadena = vCadena & " " & Trim(Str(vusuarioid)) & ","
                'vCadena = vCadena & " '" & Trim(vIp) & "' "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                vDt = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                vOk = True
            Catch ex As Exception
                vCadena = ""
                vOk = False
            End Try
            Return vOk
        End Function

        Public Shared Function Actualizar_Otros(vPersonaID As Long, ByVal vArray As String, ByVal vusuarioid As Long, vIp As String) As Boolean
            Dim vCadena As String = ""
            Dim vDt As New DataTable, vOk As Boolean = False
            Try

                vCadena = "select * from basic.papermisos_proceso_registrar( "
                vCadena = vCadena & " " & Trim(Str(vPersonaID)) & ","
                vCadena = vCadena & " " & Trim(vArray) & " "
                'vCadena = vCadena & " " & Trim(Str(vusuarioid)) & ","
                'vCadena = vCadena & " '" & Trim(vIp) & "' "
                vCadena = vCadena & " )"

                Dim oConexion As New clsConexion
                vDt = oConexion.Ejecutar_Consulta(vCadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                vOk = True
            Catch ex As Exception
                vCadena = ""
                vOk = False
            End Try
            Return vOk
        End Function



    End Class
End Namespace

