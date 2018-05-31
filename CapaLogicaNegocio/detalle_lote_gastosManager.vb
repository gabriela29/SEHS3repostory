Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class detalle_lote_gastosManager

        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Return detalle_lote_gastosBD.GetList(vLote)             
        End Function
        Public Shared Function Consulta_Documentos_Referencia(ByVal vCodigo_Alm As Integer, ByVal vIDProv As Long, ByVal vRuc As String, ByVal vCodigo_Doc As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Return detalle_lote_gastosBD.Consulta_Documentos_Referencia(vCodigo_Alm, vIDProv, vRuc, vCodigo_Doc, vDesde, vHasta)
        End Function
        Public Shared Function Asiento(ByVal vLote As Long) As DataTable
            Return detalle_lote_gastosBD.Asiento(vLote)
        End Function

        Public Shared Function Asiento_Codigocion(ByVal vUnidad As Integer, ByVal vNroCta As String, ByVal vProv As Long, _
                                                  ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Return detalle_lote_gastosBD.Asiento_Codigocion(vUnidad, vNroCta, vProv, vDesde, vHasta)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As detalle_lote_gastos
            Return detalle_lote_gastosBD.GetItem(codigo)
        End Function

        Public Shared Function GetCombos_RC_Cursor(ByVal vCodigo_Alm As Integer, ByVal vTipo_Doc As String, _
                                                   ByVal dtdocumento As DataTable, _
                                                   ByVal dtconcepto_gasto As DataTable, _
                                                   ByVal dtc_costo As DataTable, _
                                                   ByVal dtmoneda As DataTable, _
                                                   ByVal dttipo_importe As DataTable, _
                                                   ByVal dttipo_detraccion As DataTable, _
                                                   ByVal dtf_pago_detracc As DataTable) As Boolean
            Return detalle_lote_gastosBD.GetCombos_RC_Cursor(vCodigo_Alm, vTipo_Doc, dtdocumento, dtconcepto_gasto, dtc_costo, _
                                                                dtmoneda, dttipo_importe, dttipo_detraccion, dtf_pago_detracc)
        End Function

        Public Shared Function GetItem_Cursor(ByVal codigo As Long, ByVal dtDetalle As DataTable, ByVal dtdetrac As DataTable) As detalle_lote_gastos
            Return detalle_lote_gastosBD.GetItem_Cursor(codigo, dtDetalle, dtdetrac)
        End Function
        Public Shared Function Get_Tipo_Detracion(ByVal vCodigo_Det As Long) As DataTable
            Return detalle_lote_gastosBD.Get_Tipo_Detraccion(vCodigo_Det)
        End Function
        Public Shared Function forma_pago_Detraccion(ByVal vCodigo_Det As Long) As DataTable
            Return detalle_lote_gastosBD.forma_pago_Detraccion(vCodigo_Det)
        End Function

        Public Shared Function Grabar(ByRef objdetalle_lote_gastos As detalle_lote_gastos, ByVal vArray As String, ByVal vArray_DT As String, _
                                      ByVal vnombre_prov As String, ByVal vDireccion As String, ByVal vruc As String, ByVal vNCUSPP As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = detalle_lote_gastosBD.Grabar(objdetalle_lote_gastos, vnombre_prov, vDireccion, vruc, vNCUSPP, vArray, vArray_DT)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outID")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                            If rs.DataSet.Tables(0).Rows(0).Item("outerrornumber") = 3 Then
                                If MsgBox("¿Desea Grabar sin retener AFP/ONP", MsgBoxStyle.YesNo, "CONFIRMAR") = MsgBoxResult.Yes Then
                                    rs = detalle_lote_gastosBD.Grabar(objdetalle_lote_gastos, vArray, vArray_DT, vnombre_prov, vDireccion, vruc, vNCUSPP)
                                    If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                                        vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outID")
                                    Else
                                        MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                                    End If
                                End If
                            End If

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
                rs = detalle_lote_gastosBD.Grabar_Distribucion(vCodigo_Det, vArray)

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

        Public Shared Function Eliminar(ByVal Objdetalle_lote_gastos As detalle_lote_gastos) As Boolean
            Dim rs As DataTable
            Try
                rs = detalle_lote_gastosBD.Eliminar(Objdetalle_lote_gastos.codigo)
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
