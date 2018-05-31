Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class permisos_impresionManager

        Public Shared Function GetList(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vdocumento As Integer) As DataTable
            Return permisos_impresionBD.GetList(vunidad, vpersona, vdocumento)
        End Function

        Public Shared Function Get_Dato_Impresion(ByVal vUsuario As Long, ByVal vAlmacen As Integer, ByVal vCaja As String, _
                                                  ByVal vDocumento As Integer, ByVal vCodigo_Distinto As Long) As permisos_impresion
            Return permisos_impresionBD.Get_Dato_Impresion(vUsuario, vAlmacen, vCaja, vDocumento, vCodigo_Distinto)
        End Function

        Public Shared Function Obtener_Documentos_Permisos(ByVal vunidad As Integer, ByVal vpersona As Integer, _
                                                            ByVal vcaja As String, ByVal dtDocumentoL As DataTable, _
                                                            ByVal dtDocumentoI As DataTable) As Boolean
            Return permisos_impresionBD.Obtener_Documentos_Permisos_Leer(vunidad, vpersona, vcaja, dtDocumentoL, dtDocumentoI)
        End Function

        Public Shared Function Obtener_Documentos(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vcaja As String) As DataTable
            Return permisos_impresionBD.Obtener_Documentos(vunidad, vpersona, vcaja)
        End Function

        Public Shared Function Obtener_Serie_Numero(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vdocumento As Integer, ByVal vcaja As String) As DataTable
            Return permisos_impresionBD.Obtener_Serie_Numero(vunidad, vpersona, vdocumento, vcaja)
        End Function

        Public Shared Function Obtener_Documentos_Modulo(ByVal vunidad As Integer, ByVal vpersona As Integer, ByVal vcaja As String, ByVal vModulo As Integer) As DataTable
            Return permisos_impresionBD.Obtener_Documentos_Modulo(vunidad, vpersona, vcaja, vModulo)
        End Function

        Public Shared Function GetItem(ByVal codigo As Integer) As permisos_impresion
            Return permisos_impresionBD.GetItem(codigo)
        End Function

        Public Shared Function Existe_Codigo(ByVal vUsuario As Long, ByVal vAlmacen As Integer, ByVal vCaja As String, ByVal vDocumento As Integer, ByVal vCodigo_Distinto As Long) As Long
            Return permisos_impresionBD.Existe_Codigo(vUsuario, vAlmacen, vCaja, vDocumento, vCodigo_Distinto)
        End Function

        Public Shared Function Grabar(ByRef objpermisos_impresion As permisos_impresion) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = permisos_impresionBD.Grabar(objpermisos_impresion)

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

        Public Shared Function Eliminar(ByVal Objpermisos_impresion As permisos_impresion) As Boolean
            Dim rs As DataTable
            Try
                rs = permisos_impresionBD.Eliminar(Objpermisos_impresion.codigo)
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
