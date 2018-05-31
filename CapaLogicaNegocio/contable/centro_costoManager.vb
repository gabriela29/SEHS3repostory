Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll

  Public Class centro_costoManager

    Public Shared Function GetList(ByVal Cod_Uni As Integer) As DataTable
      Return centro_costoBD.GetList(Cod_Uni)
    End Function

    Public Shared Function GetListcbo(ByVal Cod_Alm As Integer, ByVal vNum_Grupo As Integer) As DataTable
      Return centro_costoBD.GetListcbo(Cod_Alm, vNum_Grupo)
    End Function
    Public Shared Function GetList(ByVal vcodigo_Det As Long, ByVal Cod_Uni As Integer) As DataTable
      Return centro_costoBD.GetList(vcodigo_Det, Cod_Uni)
    End Function
    Public Shared Function GetItem(ByVal Codigo_Uni As Integer, ByVal C_Costo As Long) As centro_costo
      Return centro_costoBD.GetItem(Codigo_Uni, C_Costo)
    End Function

    Public Shared Function Grabar(ByRef objcc As centro_costo, ByVal swNuevo As Boolean, ByVal vC_Costo_Org As Long) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = centro_costoBD.Grabar(objcc, swNuevo, vC_Costo_Org)

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
    Public Shared Function Eliminar(ByVal vCodigo_Uni As Integer, ByVal vC_Costo As Long) As Boolean
      Dim rs As DataTable
      Try
        rs = centro_costoBD.Eliminar(vCodigo_Uni, vC_Costo)
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
