Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

  Public Class almacenManager
    Public Shared Function GetList(ByVal vEmpresa As Integer, ByVal vUnidad As Integer) As DataTable
      Return almacenBD.GetList(vEmpresa, vUnidad)

    End Function

    Public Shared Function GetList_Tipo(ByVal vCodigo_Alm As Integer) As DataTable
      Return almacenBD.GetRow_Entidad(vCodigo_Alm)
    End Function

    Public Shared Function GetItem(ByVal codigo As Integer) As almacen
      Return almacenBD.GetItem(codigo)
    End Function

    Public Shared Function Grabar(ByRef objalmacen As almacen) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = almacenBD.Grabar(objalmacen)

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

    Public Shared Function GetCombo_Resto_Almacen(ByVal vCodigo_Alm As Integer, ByVal vUnidad As Integer) As DataTable
      Return almacenBD.GetCombo_Resto_Almacen(vCodigo_Alm, vUnidad)
    End Function

    Public Shared Function Eliminar(ByVal Objalmacen As almacen) As Boolean
      Dim rs As DataTable
      Try
        rs = almacenBD.Eliminar(Objalmacen.codigo)
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
