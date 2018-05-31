Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class por_pagarManager

        Public Shared Function Leer_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Return por_pagarBD.Leer_Res(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)
        End Function

        Public Shared Function Grabar(ByRef objmb As por_pagar) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = por_pagarBD.Grabar(objmb)
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

        Public Shared Function Leer_Detalles(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, _
                                             ByVal vOpcion As Integer, ByVal vPersona As Long, ByVal dtCabecera As DataTable, _
                                             ByVal dtDetalle As DataTable) As Boolean
            Return por_pagarBD.Leer_Detalles(vUnidad, vAlmacen, vhasta, vOpcion, vPersona, dtCabecera, dtDetalle)
        End Function

        Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
            Return por_pagarBD.Leer_Experian(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)

        End Function

        Public Shared Function RptPorCobrar_Res(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String, _
                                                ByVal vPersona As Long, ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
            Return por_pagarBD.RptPorCobrar_Res(vDeno, vDesde, vHasta, vPersona, vCodigo_Alm, vOpcion)
        End Function

    Public Shared Function RptEstado_Cuenta(ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String,
                                            ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Return por_pagarBD.RptEstado_Cuenta(vUnidad, vCodigo_Alm, vDesde, vHasta, vOpcion, vPersona)
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = por_pagarBD.Eliminar(vCodigo, vUsuario, vCaja)
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