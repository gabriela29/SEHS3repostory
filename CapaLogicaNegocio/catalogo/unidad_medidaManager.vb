Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class unidad_medidaManager

        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Return unidad_medidaBD.GetList(vNombre)
        End Function

        Public Shared Function GetItem(ByVal grupoId As Long) As unidad_medida
            Return unidad_medidaBD.GetItem(grupoId)
        End Function

        Public Shared Function Grabar(ByRef objUM As unidad_medida) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = unidad_medidaBD.Grabar(objUM)

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

        Public Shared Function Eliminar(ByVal vUMId As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = unidad_medidaBD.Eliminar(vUMId)
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
