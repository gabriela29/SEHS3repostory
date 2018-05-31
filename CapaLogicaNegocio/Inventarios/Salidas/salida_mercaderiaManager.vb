Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class salida_mercaderiaManager

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = salida_mercaderiaBD.Cambiar_Estado(vCodigo, vUsuario, vCaja)
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
                rs = salida_mercaderiaBD.Cambiar_Estado_Descontar(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Leer(ByVal valmacen As Integer, ByVal vdocumento As Integer, ByVal vPersona As Long, ByVal vrazsoc As String, _
                                    ByVal vdesde As String, ByVal vhasta As String, ByVal vlimite As Integer) As DataTable

            Return salida_mercaderiaBD.Leer(valmacen, vdocumento, vPersona, vrazsoc, vdesde, vhasta, vlimite)

        End Function

        Public Shared Function Leer_Traslado_Pendiente(ByVal valmacen As Integer) As DataTable

            Return salida_mercaderiaBD.Leer_Traslado_Pendiente(valmacen)

        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = salida_mercaderiaBD.Eliminar(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As salida_mercaderia, ByVal myArr As String, ByVal vSerieId As Long) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = salida_mercaderiaBD.Agregar(objv, myArr, vSerieId)
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
            Return salida_mercaderiaBD.Leer_Items(vCodigo)
        End Function

        Public Shared Function Cambiar_Cierre(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As DataTable

            Return salida_mercaderiaBD.Cambiar_Cierre(vCodigo, vUsuario, vCaja)

        End Function

        Public Shared Function Datos_Impresion(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, ByRef dtDetalle As DataTable) As Boolean
            Dim xok As Boolean = False
            Try
                ' xok = cursoresManager.Datos_Imprimir_salida_mercaderia(vCodigo, dtCabecera, dtDetalle)
                'dtCabecera = dtCabecera
                'dtDetalle = dtDetalle



            Catch ex As Exception
                xok = False
            End Try

            Return xok
        End Function


        'Public Shared Function Datos_Impresion(ByVal vCodigo As Long) As DataTable

        '    Return salida_mercaderiaBD.Eliminar(vCodigo)

        'End Function

        Public Shared Function Consulta_salida_mercaderias(ByVal vAlmacen As Integer, ByVal vSigno As String, ByVal vCliente As Long, ByVal vdocumento As Integer, ByVal vNumero As String) As DataTable

            Return salida_mercaderiaBD.Consulta_Salidas(vAlmacen, vSigno, vCliente, vdocumento, vNumero)

        End Function

    End Class
End Namespace
