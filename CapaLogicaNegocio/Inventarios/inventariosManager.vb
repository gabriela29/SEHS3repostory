Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class inventariosManager
        Public Shared Function Mi_Stock(ByVal vProductoId As Long, ByVal vAlmacenid As Integer, ByVal vAnio As Integer) As Long
            Dim rs As DataTable, vOk As Long = 0

            Try
                rs = inventariosBD.Mi_Stock(vProductoId, vAlmacenid, vAnio)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        'If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                        vOk = rs.DataSet.Tables(0).Rows(0).Item(0)
                        'Else
                        '    MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        'End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vOk
        End Function

        Public Shared Function Transferencia_Stock(ByVal vPositivos As Boolean, ByVal vAno_Origen As Integer, ByVal vAno_Destino As Integer, _
                                                        ByVal vCodigo_Almacen As Integer, ByVal vCodigo_Tipo As Integer, ByVal vCodigo_Documento As Integer, _
                                                        ByVal vCodigo_Proveedor As Long, ByVal vUsuario As String, ByVal vCaja As String, _
                                                        ByVal vCantidad As Integer) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = inventariosBD.Transferencia_Stock(vPositivos, vAno_Origen, vAno_Destino, _
                                                                 vCodigo_Almacen, vCodigo_Tipo, vCodigo_Documento, _
                                                                 vCodigo_Proveedor, vUsuario, vCaja, vCantidad)
                'outerrornumber
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        'If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                        vOk = True
                        'Else
                        '    MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        'End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vOk
        End Function
    End Class
End Namespace


