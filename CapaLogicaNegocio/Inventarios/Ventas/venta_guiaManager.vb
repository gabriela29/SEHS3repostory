Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class venta_guiaManager

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = venta_guiaBD.Cambiar_Estado(vCodigo, vUsuario, vCaja)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vOk = True
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vOk
        End Function

        Public Shared Function Cambiar_Estado_Descontar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = venta_guiaBD.Cambiar_Estado_Descontar(vCodigo, vUsuario, vCaja)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vOk = True
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vOk
        End Function

        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vlimite As Long, ByVal vdocumento As Integer, ByVal vVendedor As Long, _
                             ByVal vFecDesde As String, ByVal vFecHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String, _
                             ByVal vNumero As String, ByVal vCliente As Long, ByVal vRazon_Social As String, ByVal vSigno As String, ByVal vRef As String) As DataTable

            Return venta_guiaBD.Leer(vAlmacen, vlimite, vdocumento, vVendedor, vFecDesde, vFecHasta, vNumDesde, vNumHasta, vNumero, vCliente, vRazon_Social, vSigno, vRef)

        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = venta_guiaBD.Eliminar(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objvg As venta_guia, ByVal myArr As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = venta_guiaBD.Agregar(objvg, myArr)
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

        Public Shared Function Leer_Items(ByVal vCodigo As Long) As DataTable
            Return venta_guiaBD.Leer_Items(vCodigo)
        End Function

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

            Return venta_guiaBD.Cambiar_Cierre(vCodigo, vUsuario, vCaja)

        End Function

        Public Shared Function Datos_Impresion(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                xok = cursoresManager.Datos_Imprimir_Venta(vCodigo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle



            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function

        Public Shared Function Consulta_Ventas(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable

            Return venta_guiaBD.Consulta_Ventas(vAlmacen, vSigno, vCliente, vdocumento, vNumero)

        End Function

    End Class
End Namespace
