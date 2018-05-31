
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class material_grupoManager
        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Return material_grupoBD.GetList(vNombre)
        End Function

        Public Shared Function GetItem(ByVal grupoId As Long) As material_grupo
            Return material_grupoBD.GetItem(grupoId)
        End Function

        Public Shared Function Grabar(ByRef objgrupo As material_grupo) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = material_grupoBD.Grabar(objgrupo)

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

        Public Shared Function Eliminar(ByVal vgrupoId As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = material_grupoBD.Eliminar(vgrupoId)
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

