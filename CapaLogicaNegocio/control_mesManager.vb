Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class control_mesManager

        Public Shared Function GetItem(ByVal vAlmacenid As Integer, ByVal vmes As Integer, ByVal vAnio As Integer) As control_mes
            Return control_mesBD.GetItem(vAlmacenid, vmes, vAnio)
        End Function

        Public Shared Function Cierre_Mes(ByVal vUnidad As Integer, ByVal vmes As Integer, ByVal vAnio As Integer) As DataTable
            Return control_mesBD.Cierre_Mes(vUnidad, vmes, vAnio)
        End Function

        Public Shared Function Aperturar_Mes(ByVal vUnidad As Integer, ByVal vmes As Integer, ByVal vAnio As Integer) As DataTable
            Return control_mesBD.Aperturar_Mes(vUnidad, vmes, vAnio)
        End Function

        Public Shared Function Grabar(ByRef objcontrol_mes As control_mes) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = control_mesBD.Grabar(objcontrol_mes)

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

        Public Shared Function Cerrar_Aperturar(ByRef objcontrol_mes As control_mes) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = control_mesBD.Cerrar_Aperturar(objcontrol_mes)

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

        Public Shared Function Eliminar(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUnidad As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = control_mesBD.Eliminar(vMes, vAnio, vUnidad)
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
