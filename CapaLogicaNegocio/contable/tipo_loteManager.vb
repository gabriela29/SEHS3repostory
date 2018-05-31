Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
  Public Class tipo_loteManager

    Public Shared Function GetList(ByVal Descripcion As String) As DataTable
      Return tipo_loteBD.GetList(Descripcion)
    End Function

    Public Shared Function GetItem(ByVal codigo As Integer) As serie
      'Return tipo_loteBD.GetItem(codigo)
    End Function

    'Public Shared Function Grabar(ByRef objserie As serie) As Long
    '  Dim rs As DataTable, vCodigo As Long
    '  vCodigo = 0
    '  Try
    '    rs = serieBD.Grabar(objserie)

    '    If Not rs Is Nothing Then
    '      If rs.DataSet.Tables(0).Rows.Count > 0 Then
    '        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
    '          vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
    '        Else
    '          MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
    '        End If
    '      End If
    '    End If
    '  Finally
    '    rs = Nothing
    '  End Try
    '  Return vCodigo
    'End Function
    'Public Shared Function Eliminar(ByVal Objserie As serie) As Boolean
    '  Dim rs As DataTable
    '  Try
    '    rs = serieBD.Eliminar(Objserie.codigo)
    '    If Not rs Is Nothing Then
    '      If rs.DataSet.Tables(0).Rows.Count > 0 Then
    '        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
    '          Eliminar = True
    '        Else
    '          Eliminar = False
    '          MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
    '        End If
    '      End If
    '      rs = Nothing
    '    End If
    '  Catch ex As Exception
    '    Eliminar = False
    '  End Try
    '  Return Eliminar
    'End Function
  End Class
End Namespace
