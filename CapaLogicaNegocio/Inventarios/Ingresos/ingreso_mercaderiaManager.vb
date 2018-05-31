Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class ingreso_mercaderiaManager
        Public Shared Function Leer(ByVal vAlmacen As Integer, ByVal vdocumento As Integer, ByVal vPersona As Long, _
                             ByVal vrazsoc As String, ByVal vdesde As String, ByVal vhasta As String, _
                             ByVal vlimite As Integer) As DataTable
            Return ingreso_mercaderiaBD.Leer(vAlmacen, vdocumento, vPersona, vrazsoc, vdesde, vhasta, vlimite)

        End Function

        Public Shared Function Cambiar_Estado(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = ingreso_mercaderiaBD.Cambiar_Estado(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
            Dim rs As DataTable
            Try
                rs = ingreso_mercaderiaBD.Eliminar(vCodigo, vUsuario, vCaja)
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

        Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As ingreso_mercaderia, ByVal myArr As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = ingreso_mercaderiaBD.Agregar(objv, myArr)

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

        Public Shared Function Agregar_NC(ByRef vCodigo As Long, ByVal objv As ingreso_mercaderia, ByVal myArr As String) As Long
            Dim rs As DataTable
            vCodigo = 0
            Try
                rs = ingreso_mercaderiaBD.Agregar_NC(objv, myArr)

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

        Public Shared Function Agregar_Transferencia(ByVal xCodigo As Long, ByVal vUsuarioId As Long, ByVal vCaja As String) As Long
            Dim rs As DataTable
            Dim vCodigo As Long = 0
            Try
                rs = ingreso_mercaderiaBD.Agregar_Transferencia(xCodigo, vUsuarioId, vCaja)

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
            Return ingreso_mercaderiaBD.Leer_Items(vCodigo)
        End Function

        Public Shared Function Leer_Tipo_Documentos(ByVal vCodigo_Movimiento As Integer, ByVal vModulo As Integer) As DataTable
            Return ingreso_mercaderiaBD.Leer_Tipo_Documentos(vCodigo_Movimiento, vModulo)
        End Function

    End Class
End Namespace
