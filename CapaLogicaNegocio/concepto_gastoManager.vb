Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class concepto_gastoManager

        Public Shared Function GetList(ByVal vCodigo_Alm As Integer, ByVal vBusca As String) As DataTable
            Return concepto_gastoBD.GetList(vCodigo_Alm, vBusca)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As concepto_gasto
            Return concepto_gastoBD.GetItem(codigo)
        End Function

        Public Shared Function Grabar(ByRef objCG As concepto_gasto, ByVal vCtaMaestra As String, ByVal vCodigo_Alm As Integer) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = concepto_gastoBD.Grabar(objCG, vCtaMaestra, vCodigo_Alm)

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

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vCodigo_Alm As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = concepto_gastoBD.Eliminar(vCodigo, vCodigo_Alm)
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

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = concepto_gastoBD.Cambiar_Estado(vCodigo)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Cambiar_Estado = True
                        Else
                            Cambiar_Estado = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Cambiar_Estado = False
            End Try
            Return Cambiar_Estado
        End Function

    End Class
End Namespace
