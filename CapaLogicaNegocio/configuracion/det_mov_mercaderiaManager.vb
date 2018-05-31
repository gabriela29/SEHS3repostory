Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class det_mov_mercaderiaManager
        Public Shared Function GetList(ByVal vCodigo_Mov As Integer, ByVal vModulo As Integer) As DataTable
            Return det_mov_mercaderiaBD.GetList(vCodigo_Mov, vModulo)
        End Function

        Public Shared Function GetCombos_Cursor(ByRef dtModulo As DataTable, _
                                        ByRef dtMov As DataTable, ByRef dtDoc As DataTable) As Boolean
            Return det_mov_mercaderiaBD.GetCombos_Cursor(dtModulo, dtMov, dtDoc)
        End Function

        Public Shared Function Grabar(ByRef objcc As det_mov_mercaderia, ByVal swNuevo As Boolean) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = det_mov_mercaderiaBD.Grabar(objcc, swNuevo)

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
                rs = det_mov_mercaderiaBD.Eliminar(vCodigo)
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