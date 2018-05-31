Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class arqueo_ingresosManager
        Public Shared Function GetList(ByVal vCodigo_Usu As Long, ByVal vCodigo_Alm As Integer, ByVal vfdesde As String, ByVal vfHasta As String) As DataTable

            Return arqueo_ingresosBD.GetList(vCodigo_Usu, vCodigo_Alm, vfdesde, vfHasta)

        End Function

        Public Shared Function Obtener_Data_Arqueo(ByVal vCodigo_Us As Long, ByVal vCodigo_Alm As Integer, _
                                                    ByVal vDesde As String, ByVal vHasta As String, _
                                                    ByRef dtIngresos As DataTable, ByRef dtDocumentos As DataTable, _
                                                    ByVal dtBill As DataTable, ByVal dtMon As DataTable, ByVal dtDoll As DataTable) As Boolean
            Dim yOk As Boolean = False
            yOk = arqueo_ingresosBD.Obtener_Data_Arqueo(vCodigo_Us, vCodigo_Alm, vDesde, vHasta, dtIngresos, dtDocumentos, dtBill, dtMon, dtDoll)
            If Not dtIngresos Is Nothing Then
                If dtIngresos.Rows.Count > 0 Then
                    yOk = True
                Else
                    yOk = False
                End If
            End If
            Return yOk

        End Function

        Public Shared Function Registrar_Arqueo(ByRef objarqueo_ingreso As arqueo_ingresos, ByVal mArr As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = arqueo_ingresosBD.Registrar_Arqueo(objarqueo_ingreso, mArr)

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
                rs = arqueo_ingresosBD.Eliminar(vCodigo)
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

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vStado As Boolean) As Boolean
            Dim rs As DataTable
            Try
                rs = arqueo_ingresosBD.Cambiar_Estado(vCodigo, vStado)
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

        Public Shared Function GetRpt(ByVal vCodigo As Long) As DataTable
            Return arqueo_ingresosBD.GetRpt(vCodigo)
        End Function

    End Class
End Namespace
