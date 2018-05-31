Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class lote_gastosManager

        Public Shared Function GetList(ByVal vCodigo_Alm As Integer, ByVal vBusca As String, ByVal vAnio As Integer, ByVal vTipo As String, ByVal vOpciones As String) As DataTable
            Return lote_gastosBD.GetList(vCodigo_Alm, vBusca, vAnio, vTipo, vOpciones)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As lote_gastos
            Return lote_gastosBD.GetItem(codigo)
        End Function
        Public Shared Function Grabar(ByRef objlote_gastos As lote_gastos) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = lote_gastosBD.Grabar(objlote_gastos)

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
        Public Shared Function Eliminar(ByVal Objlote_gastos As lote_gastos) As Boolean
            Dim rs As DataTable
            Try
                rs = lote_gastosBD.Eliminar(Objlote_gastos.codigo)
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

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = lote_gastosBD.Cambiar_Estado(vCodigo)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Cambiar_Estado = True
                        Else
                            Cambiar_Estado = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Cambiar_Estado = False
            End Try
            Return Cambiar_Estado
        End Function

    End Class
End Namespace
