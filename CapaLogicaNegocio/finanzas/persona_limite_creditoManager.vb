

Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class persona_limite_creditoManager
        Public Shared Function GetList(ByVal vUnidadId As Integer, ByVal vAlmacenid As Integer, ByVal vNumero As String, ByVal vPaterno As String, _
                                       ByVal vMaterno As String, ByVal vNombre As String, ByVal vTipo As String, ByVal vLimite As Long) As DataTable
            Return persona_limite_creditoBD.GetList(vUnidadId, vAlmacenid, vNumero, vPaterno, vMaterno, vNombre, vTipo, vLimite)
        End Function

        Public Shared Function Actualizar(ByRef vAlmacenid As Integer, vPersonaid As Long, vImporte As Single) As Long
            Dim rs As DataTable
            Dim vCodigo As Long = 0
            Try
                rs = persona_limite_creditoBD.Actualizar(vAlmacenid, vPersonaid, vImporte)
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

    End Class

End Namespace
