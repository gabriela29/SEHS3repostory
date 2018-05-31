Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class loteManager

    Public Shared Function GetItem(ByVal vLoteID As Long) As lote
      Return loteBD.GetItem(vLoteID)
    End Function

    Public Shared Function GetList(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vTipoId As Integer, ByVal vBusca As String,
                                   ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vFicha As String) As DataTable
      Return loteBD.GetList(vCodigo_Uni, vCodigo_Alm, vTipoId, vBusca, vAnio, vMes, vFicha)
    End Function

    Public Shared Function GetList_Detalle(ByVal vCodigo As Long) As DataTable
      Return loteBD.GetList_Detalle(vCodigo)
    End Function

    Public Shared Function Grabar(ByRef objlote_gasto As lote) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = loteBD.Grabar(objlote_gasto)

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

    Public Shared Function Grabar_Detalle(ByVal vLote_Id As Long, ByVal vArray As String, ByVal vUsID As Long, ByVal vCaja As String) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = loteBD.Grabar_Detalle(vLote_Id, vArray, vUsID, vCaja)

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

    Public Shared Function Eliminar_Asiento(ByVal vCodigo As Long, ByVal vUsuaroId As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable
      Try
        rs = loteBD.Eliminar_Asiento(vCodigo, vUsuaroId, vCaja)
        If Not rs Is Nothing Then
          If rs.DataSet.Tables(0).Rows.Count > 0 Then
            If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
              Eliminar_Asiento = True
            Else
              Eliminar_Asiento = False
              MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
            End If
          End If
          rs = Nothing
        End If
      Catch ex As Exception
        Eliminar_Asiento = False
      End Try
      Return Eliminar_Asiento
    End Function

    Public Shared Function Asiento_Lote(ByVal vLote As Long, ByVal vProcesar As Boolean) As DataTable
      Dim pDtp As New DataTable

      pDtp = loteBD.Asiento_Lote(vLote, vProcesar)

      Return pDtp
    End Function

    Public Shared Function Asiento_Procesado(ByVal vLote As Long) As DataTable
      Dim pDtp As New DataTable

      pDtp = loteBD.Asiento_Procesado(vLote)

      Return pDtp
    End Function

    Public Shared Function Eliminar_Lote(ByVal vCodigo As Long, ByVal vUsuaroId As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable
      Try
        rs = loteBD.Eliminar_Lote(vCodigo, vUsuaroId, vCaja)
        If Not rs Is Nothing Then
          If rs.DataSet.Tables(0).Rows.Count > 0 Then
            If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
              Eliminar_Lote = True
            Else
              Eliminar_Lote = False
              MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
            End If
          End If
          rs = Nothing
        End If
      Catch ex As Exception
        Eliminar_Lote = False
      End Try
      Return Eliminar_Lote
    End Function

    Public Shared Function Asiento_Assinet_Actualizar(ByVal vLote As Long, ByVal vEntidad As Integer, ByVal Lote_Assinet As Long, ByVal vGuid As String, ByVal vTypej As String, ByVal vTipo As String) As DataTable
      Dim pDtp As New DataTable


      pDtp = loteBD.Asiento_Assinet_Actualizar(vLote, vEntidad, Lote_Assinet, vGuid, vTypej, vTipo)


      Return pDtp
    End Function

  End Class
End Namespace
