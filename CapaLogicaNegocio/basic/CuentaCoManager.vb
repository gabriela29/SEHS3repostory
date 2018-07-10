
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Imports CapaObjetosNegocio

Namespace BLL
    Public Class CuentaCoManager

        Public Shared Function GetList(ByVal vCategoriaId As Integer, ByVal vNombre As String) As DataTable
            Return CuentaCoBD.GetList(vCategoriaId, vNombre)
        End Function

        Public Shared Function GetItem(ByVal SubCategoriaId As Integer) As cuentaCorriente
            Return CuentaCoBD.GetItem(SubCategoriaId)
        End Function

        Public Shared Function Grabar(ByRef objsc As cuentaCorriente) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = CuentaCoBD.Grabar(objsc)

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

        Public Shared Function Eliminar(ByVal vCategoriaId As Integer) As Boolean
            Dim rs As DataTable
            Try
                rs = CuentaCoBD.Eliminar(vCategoriaId)
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


