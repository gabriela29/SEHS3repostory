
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class registro_mbManager

        Public Shared Function GetList(ByVal vTabla As String, ByVal vTablaid As String) As DataTable
            Return regitro_mbBD.GetList(vTabla, vTablaid)
        End Function

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As registro_mb, ByVal vAlmacenid As Integer) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = regitro_mbBD.Agregar(objv, vAlmacenid)
                'outerrornumber
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

        Public Shared Function Eliminar(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = regitro_mbBD.Eliminar(vCodigo)
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

