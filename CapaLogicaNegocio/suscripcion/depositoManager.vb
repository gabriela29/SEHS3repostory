Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class depositoManager
        Public Shared Function GetList(ByVal vUnidadid As Integer, ByVal vDMId As Long, ByVal viglesiaid As Long, ByVal vperiodoid As Integer, ByVal vresponsableid As Long, _
                                       ByVal vdesde As String, ByVal vhasta As String, ByVal vOpcion As String, vAlmacenid As Integer, ByVal vTipo As Integer, ByVal vTipoDoc As Integer) As DataTable

            If vOpcion = "F" Then
                GetList = depositoBD.GetList_Facturados(vAlmacenid, vUnidadid, vDMId, viglesiaid, vperiodoid, vresponsableid, vdesde, vhasta, vTipo, vTipoDoc)
            Else
                GetList = depositoBD.GetList(vUnidadid, vDMId, viglesiaid, vperiodoid, vresponsableid, vdesde, vhasta, vOpcion, vTipo)
            End If

            Return GetList
        End Function

        Public Shared Function GetList_DxM(ByVal viglesiaid As Long, ByVal vperiodoid As Integer) As DataTable
            Return depositoBD.GetList_DxM(viglesiaid, vperiodoid)
        End Function

        Public Shared Function GetList_DSS(ByVal vDMId As Long, ByVal viglesiaid As Long, ByVal vperiodoid As Integer) As DataTable
            Return depositoBD.GetList_DSS(vDMId, viglesiaid, vperiodoid)
        End Function

        Public Shared Function GetList_Detalle(ByVal vDepositoId As Long, ByVal vTipo As String) As DataTable
            Return depositoBD.GetList_Detalle(vDepositoId, vTipo)
        End Function

        Public Shared Function Cambiar_Estado(ByVal vUsuario As Long, ByVal vCaja As String, ByVal myArr As String, ByVal vTipo As String) As Boolean
            Dim rs As DataTable, vOk As Boolean = False

            Try
                rs = depositoBD.Cambiar_Estado(vUsuario, vCaja, myArr, vTipo)
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

    End Class
End Namespace

