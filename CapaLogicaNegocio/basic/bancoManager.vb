Imports System
Imports System.ComponentModel
Imports CapaDatos.Dal
Imports CapaObjetosNegocio

Namespace BLL



    Public Class bancoManager
        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Return BancoBD.GetList(vNombre)
        End Function

        Public Shared Function GetItem(ByVal bancoid As Integer) As banco
            Return BancoBD.GetItem(bancoid)
        End Function

        Public Shared Function Grabar(ByRef objbanco As banco) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = BancoBD.Grabar(objbanco)
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

        Public Shared Function Eliminar(ByVal vbancoid As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = BancoBD.Eliminar(vbancoid)
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