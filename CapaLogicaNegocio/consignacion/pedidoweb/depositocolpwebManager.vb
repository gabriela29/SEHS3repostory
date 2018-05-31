Imports CapaDatos.Dal

Namespace Bll
  Public Class depositocolpwebManager
    Public Shared Function Leer_Deposito_Pendiente(ByVal vCampania As Integer, ByVal vAlmacen As Integer, ByVal vAsistente As Long,
                                                  ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Return depositocolpwebBD.Leer_Deposito_Pendiente(vCampania, vAlmacen, vAsistente, vDesde, vHasta)
    End Function

    Public Shared Function Cambiar_Cerrado(ByVal vID As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = depositocolpwebBD.Cambiar_Cerrado(vID, vUsuario, vCaja)
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
      Return pedidocolpwebBD.Facturar_Pedido_Web(vpedidoid, valmacenid, vserie, vnumero, vdocumentoid,
                                               vfecha, vusuarioid, vcaja, vserieid, vdocumentodid,
                                               vseried, vnumerod, vserieidd, vglosa)
    End Function

  End Class

End Namespace

