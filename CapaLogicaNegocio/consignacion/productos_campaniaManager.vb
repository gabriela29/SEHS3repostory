
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class productos_campaniaManager

        Public Shared Function Producto_Campania_leer(ByVal vCampania As Long, ByVal vCodigo_Almacen As Integer, ByVal vAnio As Integer) As DataTable

            Return productos_campaniaBD.Producto_Campania_leer(vCampania, vCodigo_Almacen, vAnio)

        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As productos_campania
            Return productos_campaniaBD.GetItem(vCodigo)
        End Function

        Public Shared Function Grabar(ByVal xCodigo As Long, ByVal xNew As Boolean, ByVal objProd As productos_campania) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = productos_campaniaBD.Actualizar(xCodigo, xNew, objProd)

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
                rs = productos_campaniaBD.Eliminar(vCodigo)
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

