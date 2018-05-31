Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class lote_gastoManager

        Public Shared Function GetItem(ByVal vLoteGastoID As Long) As lote_gasto
            Return lote_gastoBD.GetItem(vLoteGastoID)
        End Function

        Public Shared Function GetList(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vBusca As String, ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vTipo As String) As DataTable
            Return lote_gastoBD.GetList(vCodigo_Uni, vCodigo_Alm, vBusca, vAnio, vMes, vTipo)
        End Function

        Public Shared Function Grabar(ByRef objlote_gasto As lote_gasto) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = lote_gastoBD.Grabar(objlote_gasto)

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

        Public Shared Function Asiento_Lote_Gastos(ByVal vLote As Long, ByVal xTipo As String) As DataTable
            Dim pDtp As New DataTable
            If xTipo = "PROVISIONAR" Then
                pDtp = lote_gastoBD.Asiento_Provision(vLote, False)
            ElseIf xTipo = "PAGOS" Then
                pDtp = lote_gastoBD.Asiento_Pagos(vLote, False)
            ElseIf xTipo = "PROVLG" Or xTipo = "PAGOLG" Then
                pDtp = lote_gastoBD.Asiento_Lote_Gasto_Conta(vLote, xTipo)
            End If
            Return pDtp
        End Function

        Public Shared Function Asiento_Lote_Mercaderia(ByVal vCodigo As Long, ByVal xTipo As String) As DataTable
            Dim pDtp As New DataTable

            If xTipo = "PROVISIONAR" Then
                pDtp = lote_gastoBD.Asiento_Provision_mer(vCodigo, False)
            ElseIf xTipo = "MOVIMIENTO" Then
                pDtp = lote_gastoBD.Asiento_Mov_Mer_Com(vCodigo, False)
            ElseIf xTipo = "PROVLG" Or xTipo = "PAGOLG" Then
                pDtp = lote_gastoBD.Asiento_Lote_Gasto_Conta(vCodigo, xTipo)
            End If

            Return pDtp

        End Function

        Public Shared Function Procesar_Lote_Gasto_Asientos(ByVal vLote As Long, ByVal DtProvision As DataTable, ByVal dtPagos As DataTable) As Boolean

            Dim xOk As Boolean = False
            Try
                xOk = lote_gastoBD.Procesar_Lote_Gasto_Asientos(vLote, DtProvision, dtPagos)
                xOk = True
            Catch ex As Exception
                xOk = False
            End Try

            Return xOk
        End Function

        Public Shared Function Asiento_Assinet_Actualizar(ByVal vLote As Long, ByVal vEntidad As Integer, ByVal Lote_Assinet As Long, ByVal vGuid As String, ByVal vTypej As String, ByVal vTipo As String) As DataTable
            Dim pDtp As New DataTable


            pDtp = lote_gastoBD.Asiento_Assinet_Actualizar(vLote, vEntidad, Lote_Assinet, vGuid, vTypej, vTipo)


            Return pDtp
        End Function

        Public Shared Function Eliminar_Asiento(ByVal vCodigo As Long, ByVal vUsuaroId As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = lote_gastoBD.Eliminar_Asiento(vCodigo, vUsuaroId, vCaja)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar_Asiento = True
                        Else
                            Eliminar_Asiento = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar_Asiento = False
            End Try
            Return Eliminar_Asiento
        End Function

        Public Shared Function Eliminar_Lote(ByVal vCodigo As Long, ByVal vUsuaroId As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = lote_gastoBD.Eliminar_Lote(vCodigo, vUsuaroId, vCaja)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar_Lote = True
                        Else
                            Eliminar_Lote = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar_Lote = False
            End Try
            Return Eliminar_Lote
        End Function

    End Class
End Namespace
