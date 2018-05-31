
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
  Public Class porcobrar_gestionManager
    Public Shared Function porcobrar_Gestion_Leer(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                    ByVal vOpcion As String, ByVal vPersona As Long, ByVal vUs As Long, ByVal vNumCarta As Integer) As DataTable

      porcobrar_Gestion_Leer = porcobrar_gestionBD.porcobrar_Gestion_Leer(vUnidad, vAlmacen, vhasta,
                                                            vOpcion, vPersona, vUs, vNumCarta)

      Return porcobrar_Gestion_Leer
    End Function

    Public Shared Function Grabar(ByRef objmb As porcobrar_gestion) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = porcobrar_gestionBD.Grabar(objmb)
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

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vNum_Carta As Integer, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
      Dim rs As DataTable
      Try
        rs = porcobrar_gestionBD.Eliminar(vCodigo, vNum_Carta, vUsuario, vCaja)
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

