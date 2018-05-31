Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class pedidoManager
    Public Shared Function GetList_Tipo(ByVal vNombre As String) As DataTable
      Return pedidoBD.GetList_Tipo(vNombre)
    End Function

    Public Shared Function GetList(ByVal vTipo As Integer, ByVal viglesiaid As Long, ByVal vperiodoid As Integer,
                            ByVal vpersonaid As Long, ByVal vdesde As String, ByVal vhasta As String) As DataTable
      Return pedidoBD.GetList(vTipo, viglesiaid, vperiodoid, vpersonaid, vdesde, vhasta)
    End Function

    Public Shared Function Cambiar_Estado(ByVal vCodigoID As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = pedidoBD.Cambiar_Estado(vCodigoID, vUsuario, vCaja)
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

    Public Shared Function GetList_PorFacturar(ByVal inpedidoid As Long, ByVal inalmacenid As Integer) As DataTable

      Return pedidoBD.GetList_PorFacturar(inpedidoid, inalmacenid)

    End Function

    Public Shared Function GetList_PorFacturar_Lista(ByVal inpedidoid As Long, ByVal iniglesiaid As Long, ByVal inperiodoid As Integer,
                                                     ByVal inalmacenid As Integer, ByVal ingrupoid As Long, ByVal inunidadnegocioid As Integer,
                                                     ByVal intipopedidoid As Integer) As DataTable

      Return pedidoBD.GetList_PorFacturar_Lista(inpedidoid, iniglesiaid, inperiodoid, inalmacenid, ingrupoid, inunidadnegocioid, intipopedidoid)

    End Function

    Public Shared Function GetList_PorFacturar_Bloque(ByVal vPedidoId As Long, ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                             ByVal vSerie As String, ByVal vNumero As Long,
                                              ByVal indocumentoid As Integer, ByVal infecha As String,
                                              ByVal inusuarioid As Long, ByVal incaja As String,
                                              ByVal vCodigo_Serie As Long, ByVal vGlosa As String, ByVal pDMId As Long,
                                              ByVal pUnidadId As Integer, ByVal pTipoId As Integer) As DataTable
      Return pedidoBD.GetList_PorFacturarBloque(vPedidoId, vAlmacenId, vIglesiaid, vPeriodoId, vSerie, vNumero,
                                                     indocumentoid, infecha, inusuarioid, incaja, vCodigo_Serie, vGlosa, pDMId, pUnidadId, pTipoId)
    End Function

    Public Shared Function GetList_Facturarados(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                                ByVal vPersonaid As Long, ByVal vDocId As Integer, ByVal vDesde As String,
                                                 ByVal vHasta As String, ByVal vNumDesde As String, ByVal vNumHasta As String,
                                                 ByVal vDMid As Long, ByVal vUnidadid As Integer, ByVal vTipo As String) As DataTable
      Return pedidoBD.GetList_Facturarados(vAlmacenId, vIglesiaid, vPeriodoId,
                                              vPersonaid, vDocId, vDesde, vHasta, vNumDesde, vNumHasta, vDMid, vUnidadid, vTipo)
    End Function

    Public Shared Function GetList_Ciclo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                     ByVal vDMid As Long, ByVal vTipo As Integer) As DataTable
      Return pedidoBD.GetList_Ciclo(vAlmacenId, vIglesiaid, vPeriodoId, vDMid, vTipo)
    End Function

    Public Shared Function GetList_Ciclo_Saldo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                                ByVal vDMid As Long, ByVal vTipo As Integer, ByVal vProductoid As Long, ByVal vAll As Boolean) As DataTable
      Return pedidoBD.GetList_Ciclo_saldo(vAlmacenId, vIglesiaid, vPeriodoId, vDMid, vTipo, vProductoid, vAll)
    End Function

  End Class

End Namespace


