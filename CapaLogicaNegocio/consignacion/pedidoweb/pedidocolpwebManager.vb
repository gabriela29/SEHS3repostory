Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class pedidocolpwebManager
    Public Shared Function Leer_Pedido_Pendiente(ByVal vCampania As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long,
                                                  ByVal vDesde As String, ByVal vHasta As String, ByVal vPendiente As Boolean) As DataTable
      Return pedidocolpwebBD.Leer_Pedido_Pendiente(vCampania, vAlmacen, vPersona, vDesde, vHasta, vPendiente)
    End Function

    Public Shared Function Cambiar_Cerrado(ByVal vSuscripcionID As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = pedidocolpwebBD.Cambiar_Cerrado(vSuscripcionID, vUsuario, vCaja)
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

    Public Shared Function Facturar_Pedido_Web(ByVal vpedidoid As Long, ByVal valmacenid As Integer, ByVal vserie As String, ByVal vnumero As Long, ByVal vdocumentoid As Integer,
                                                 ByVal vfecha As String, ByVal vusuarioid As Long, ByVal vcaja As String, ByVal vserieid As Integer, ByVal vdocumentodid As Integer,
                                                 ByVal vseried As String, ByVal vnumerod As Long, ByVal vserieidd As Integer, ByVal vglosa As String) As DataTable
      Dim rs As New DataTable
      Try
        rs = pedidocolpwebBD.Facturar_Pedido_Web(vpedidoid, valmacenid, vserie, vnumero, vdocumentoid,
                                                 vfecha, vusuarioid, vcaja, vserieid, vdocumentodid,
                                                 vseried, vnumerod, vserieidd, vglosa)

        If Not rs Is Nothing Then
          If rs.DataSet.Tables(0).Rows.Count > 0 Then
            If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
            Else
              MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
            End If
          End If
        End If
      Finally

      End Try

      Return rs
    End Function

  End Class

End Namespace
