
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class transferis_stockManager
        Public Shared Function GetList(ByVal vano_origen As Integer, ByVal vano_destino As Integer, ByVal vcodigo_almacen As Integer, _
                                       ByRef TOrigen As Single, ByRef tDestino As Single) As Boolean
            Dim rs As DataTable, vOk As Boolean = False, dr As DataRow
            rs = transferir_stockBD.GetList(vano_origen, vano_destino, vcodigo_almacen)
            dr = rs.Rows(0)
            If Not rs Is Nothing Then
                If rs.DataSet.Tables(0).Rows.Count > 0 Then

                    TOrigen = rs.Rows(0).Item("origen")
                    tDestino = rs.Rows(0).Item("destino")
                    vOk = True
                Else
                    vOk = False

                End If
            End If

            Return vOk
        End Function

        Public Shared Function Transferir(ByVal vano_origen As Integer, ByVal vano_destino As Integer, _
                               ByVal vcodigo_almacen As Integer, ByVal vcodigo_tipo As Integer, ByVal vcodigo_doc As Integer, _
                               ByVal vcodigo_persona As Long, ByVal vusuario As Long, ByVal vcaja As String) As Boolean
            Dim rds As New DataTable, vK As Boolean = False
            Try
                rds = transferir_stockBD.Transferir(vano_origen, vano_destino, vcodigo_almacen, vcodigo_tipo, vcodigo_doc, _
                                                    vcodigo_persona, vusuario, vcaja)
                vK = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                vK = False
            End Try

            Return vK
        End Function

    End Class

End Namespace
