Imports System
Imports System.ComponentModel
Imports CapaDatos.Dal
Imports CapaObjetosNegocio
Namespace Bll

    Public Class empresaManager

        Public Shared Function GetList(ByVal nruc As String, ByVal apell As String) As DataTable
            Return empresaBD.GetList(nruc, apell)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As empresa
            Return empresaBD.GetItem(codigo)
        End Function



        Public Shared Function Grabar(ByRef objempresa As empresa) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = empresaBD.Grabar(objempresa)

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

        Public Shared Function Eliminar(ByVal Objempresa As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = empresaBD.Eliminar(Objempresa)
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
