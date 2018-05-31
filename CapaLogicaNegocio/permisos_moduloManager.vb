Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll

    Public Class permisos_moduloManager

        Public Shared Function Leer_Unidad(ByVal vPersona As Long, ByVal vModulo As Integer) As DataTable
            Return permisos_moduloBD.Leer_Unidad(vPersona, vModulo)
        End Function

        Public Shared Function Leer_Almacenes_Unidad(ByVal vPersona As Long, ByVal vModulo As Integer, ByVal vUnidad As Integer) As DataTable
            Return permisos_moduloBD.Leer_Almacenes_Unidad(vPersona, vModulo, vUnidad)
        End Function

        Public Shared Function Leer_Almacenes(ByVal vPersona As Long, ByVal vModulo As Integer) As DataTable
            Return permisos_moduloBD.Leer_Almacenes(vPersona, vModulo)
        End Function

        Public Shared Function Grabar(ByRef objpm As permisos_modulo, ByVal swNuevo As Boolean) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = permisos_moduloBD.Grabar(objpm, swNuevo)

                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function
        Public Shared Function Eliminar(ByVal vCodigo_Per As Long, ByVal vCodigo_Alm As Integer, ByVal vCodigo_Mod As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = permisos_moduloBD.Eliminar(vCodigo_Per, vCodigo_Alm, vCodigo_Mod)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar = True
                        Else
                            Eliminar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar = False
            End Try
            Return Eliminar
        End Function
    End Class
End Namespace
