Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class marcaManager
        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Return marcaBD.GetList(vNombre)
        End Function

        Public Shared Function GetItem(ByVal MarcaId As Long) As marca
            Return marcaBD.GetItem(MarcaId)
        End Function

        Public Shared Function Grabar(ByRef objMarca As marca) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = marcaBD.Grabar(objMarca)

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

        Public Shared Function Eliminar(ByVal vMarcaId As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = marcaBD.Eliminar(vMarcaId)
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
