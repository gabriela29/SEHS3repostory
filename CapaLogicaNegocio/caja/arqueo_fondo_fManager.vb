Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class arqueo_fondo_fManager
        Public Shared Function GetList_Fondo_Fijo(ByVal vCodigo_Usu As Long, ByVal vCodigo_Alm As Integer, ByVal vfdesde As String, ByVal vfHasta As String) As DataTable

            Return arqueo_fondo_fBD.GetList_Fondo_Fijo(vCodigo_Usu, vCodigo_Alm, vfdesde, vfHasta)

        End Function

        Public Shared Function Obtener_Data_Arqueo(ByVal vLoteID As Long, ByVal vFecha As String, ByRef dtDocumentos As DataTable, _
                                            ByVal dtBill As DataTable, ByVal dtMon As DataTable, ByVal dtDoll As DataTable) As Boolean
            Dim yOk As Boolean = False
            yOk = arqueo_fondo_fBD.Obtener_Data_Arqueo(vLoteID, vFecha, dtDocumentos, dtBill, dtMon, dtDoll)
            If Not dtMon Is Nothing Then
                If dtMon.Rows.Count > 0 Then
                    yOk = True
                Else
                    yOk = False
                End If
            End If
            Return yOk

        End Function

        Public Shared Function Registrar_Arqueo(ByRef objarqueo_fondo_fijo As arqueo_fondo_fijo, ByVal mArr As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = arqueo_fondo_fBD.Registrar_Arqueo(objarqueo_fondo_fijo, mArr)

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

        Public Shared Function GetList(ByVal vLote As Long) As DataTable
            Return arqueo_fondo_fBD.GetList(vLote)
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = arqueo_fondo_fBD.Eliminar(vCodigo)
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
                rs = arqueo_fondo_fBD.Cambiar_Estado(vCodigo, vStado)
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
            Return arqueo_fondo_fBD.GetRpt(vCodigo)
        End Function

    End Class
End Namespace
