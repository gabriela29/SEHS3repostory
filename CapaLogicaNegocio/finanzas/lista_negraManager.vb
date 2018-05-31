
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class lista_negraManager
        Public Shared Function GetList(ByVal vDesde As String, ByVal vHasta As String, ByVal vNombre As String) As DataTable
            Return lista_negraBD.GetList(vDesde, vHasta, vNombre)
        End Function

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal vNew As Boolean, ByVal objv As lista_negra, ByVal vUsuarioID As Long, ByVal vIp As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = lista_negraBD.Grabar(vNew, objv, vUsuarioID, vIp)
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
                rs = lista_negraBD.Eliminar(vCodigo)
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

