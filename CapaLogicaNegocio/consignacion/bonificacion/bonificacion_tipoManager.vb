
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class bonificacion_tipoManager
        Public Shared Function GetItem(ByVal codigo As Integer) As bonificacion_tipo
            Return tipo_bonificacionBD.GetItem(codigo)
        End Function

        Public Shared Function GetList(ByVal vAlmacenId As Integer, ByVal Descripcion As String) As DataTable
            Return tipo_bonificacionBD.GetList(vAlmacenId, Descripcion)
        End Function

        Public Shared Function Grabar(ByRef objDB As bonificacion_tipo) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = tipo_bonificacionBD.Grabar(objDB)

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

        Public Shared Function Eliminar(ByVal vCodigo As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = tipo_bonificacionBD.Eliminar(vCodigo)
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

