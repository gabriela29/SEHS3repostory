
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class detalle_lote_gastoManager
        Public Shared Function GetCombos_RC_Cursor(ByVal vCodigo_Alm As Integer, ByVal vTipo_Doc As String, _
                                           ByVal dtdocumento As DataTable, _
                                           ByVal dtc_costo As DataTable, _
                                           ByVal dtmoneda As DataTable, _
                                           ByVal dttipo_importe As DataTable, _
                                           ByVal dtfpago As DataTable, ByVal dtOtros As DataTable) As Boolean
            Return detalle_lote_gastoBD.GetCombos_RC_Cursor(vCodigo_Alm, vTipo_Doc, dtdocumento, dtc_costo, _
                                                                dtmoneda, dttipo_importe, dtfpago, dtOtros)
        End Function

        Public Shared Function GetItem_Cursor(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, _
                                                ByRef dtdetalle As DataTable, ByRef dtdetrac As DataTable, _
                                                ByRef dtSustento As DataTable) As Boolean
            Return detalle_lote_gastoBD.GetItem_Cursor(vCodigo, dtCabecera, dtdetalle, _
                                                                dtdetrac, dtSustento)
        End Function

        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Return detalle_lote_gastoBD.GetList(vLote)
        End Function

        Public Shared Function GetList_Provisionar(ByVal vLote As Long) As DataTable
            Return detalle_lote_gastoBD.GetList_Provisionar(vLote)
        End Function

        Public Shared Function GetRpt(ByVal vLote As Long) As DataTable
            Return detalle_lote_gastoBD.GetRpt(vLote)
        End Function

        Public Shared Function Grabar(ByRef objdetalle_lote_gasto As detalle_lote_gasto, ByVal vArray As String, ByVal vArray_DT As String, _
                                      ByVal vArray_FP As String, ByVal vVence As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = detalle_lote_gastoBD.Grabar(objdetalle_lote_gasto, vArray, vArray_DT, vArray_FP, vVence)

                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outID")
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

        Public Shared Function Grabar_Distribucion(ByVal vCodigo_Det As Long, ByVal vArray As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = detalle_lote_gastoBD.Grabar_Distribucion(vCodigo_Det, vArray)

                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outID")
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
                rs = detalle_lote_gastoBD.Eliminar(vCodigo)
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

