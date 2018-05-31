Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class documentoManager
        Public Shared Function GetList(ByVal Descripcion As String) As DataTable
            Return documentoBD.GetList(Descripcion)
        End Function

        Public Shared Function GetList_Tipo(ByVal vTipo As String) As DataTable
            Return documentoBD.GetList_Tipo(vTipo)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As documento
            Return documentoBD.GetItem(codigo)
        End Function
        Public Shared Function Grabar(ByRef objdocumento As documento) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = documentoBD.Grabar(objdocumento)

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
        Public Shared Function Eliminar(ByVal Objdocumento As documento) As Boolean
            Dim rs As DataTable
            Try
                rs = documentoBD.Eliminar(Objdocumento.codigo)
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
