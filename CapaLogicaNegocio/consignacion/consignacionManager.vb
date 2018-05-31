Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class consignacionManager

        Public Shared Function Leer_Consignacion_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vPersona As Long, _
                                                     ByVal vDocumento As Integer, ByVal vNumero As String, ByVal vDesde As String, _
                                                     ByVal vHasta As String, ByVal vTipo As Integer) As DataTable
            Return consignacionBD.Leer_Consignacion_Res(vUnidad, vAlmacen, vCampania, vPersona, vDocumento, vNumero, vDesde, vHasta, vTipo)
        End Function

        Public Shared Function Leer_Consignacion(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vPersona As Long, _
                                                     ByVal vDocumento As Integer, ByVal vNumero As String, ByVal vDesde As String, ByVal vHasta As String, _
                                                     ByVal vTipo As Integer) As DataTable
            Return consignacionBD.Leer_Consignacion(vUnidad, vAlmacen, vCampania, vPersona, vDocumento, vNumero, vDesde, vHasta, vTipo)
        End Function

        Public Shared Function Leer_Consignacion_xGuia_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long, _
                                             ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Return consignacionBD.Leer_Consignacion_xGuia_Res(vUnidad, vAlmacen, vPersona, vDesde, vHasta)
        End Function

        Public Shared Function Leer_Consignacion_xGuia_Leer(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long, _
                                     ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Return consignacionBD.Leer_Consignacion_xGuia_Leer(vUnidad, vAlmacen, vPersona, vDesde, vHasta)
        End Function

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As consignacion, ByVal myArr As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = consignacionBD.Agregar(objv, myArr)
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


        Public Shared Function Datos_Impresion_Guia(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresManager.Datos_Imprimir_Guia(vCodigo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle



            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

    End Class
End Namespace