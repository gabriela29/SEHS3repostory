Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class suscripcionManager
    Public Shared Function GetList(ByVal vAlmacen As Integer, ByVal viglesiaid As Long,
                                   ByVal vperiodoid As Integer, ByVal vpersonaid As Long, ByVal vDM As Long) As DataTable
      Return suscripcionBD.GetList(vAlmacen, viglesiaid, vperiodoid, vpersonaid, vDM)


    End Function

    Public Shared Function GetListWeb(ByVal vAlmacenId As Integer, ByVal viglesiaid As Long, ByVal vperiodoid As Integer,
                                      ByVal vpersonaid As Long, ByVal vDesde As String, ByVal vHasta As String,
                                      ByVal vCodigo As Long) As DataTable
      Return suscripcionBD.GetListWeb(vAlmacenId, viglesiaid, vperiodoid, vpersonaid, vDesde, vHasta, vCodigo)

    End Function

    Public Shared Function GetList_Suscribir(ByVal vperiodoid As Integer, ByVal vSuscripcionid As Long) As DataTable
      Return suscripcionBD.GetList_Suscribir(vperiodoid, vSuscripcionid)
    End Function

    Public Shared Function GetList_PorFacturar(ByVal vSuscripcionId As Long, ByVal vAlmacenId As Integer) As DataTable
      Return suscripcionBD.GetList_PorFacturar(vSuscripcionId, vAlmacenId)
    End Function

    Public Shared Function GetList_PorFacturar_Bloque(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                                      ByVal vSerie As String, ByVal vNumero As Long,
                                                      ByVal indocumentoid As Integer, ByVal infecha As String,
                                                      ByVal inusuarioid As Long, ByVal incaja As String,
                                                      ByVal vCodigo_Serie As Long, ByVal vGlosa As String, ByVal pDMId As Long) As DataTable
      Return suscripcionBD.GetList_PorFacturarBloque(vAlmacenId, vIglesiaid, vPeriodoId, vSerie, vNumero,
                                                     indocumentoid, infecha, inusuarioid, incaja, vCodigo_Serie, vGlosa, pDMId)
    End Function

    Public Shared Function GetList_Facturarados(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Integer, ByVal vPeriodoId As Integer,
                                                ByVal vPersonaid As Long, ByVal vDocId As Integer, ByVal vDesde As String,
                                                ByVal vHasta As String, ByVal vNum_Desde As String, ByVal vNum_Hasta As String,
                                                ByVal vDMid As Long) As DataTable
      Return suscripcionBD.GetList_Facturarados(vAlmacenId, vIglesiaid, vPeriodoId, vPersonaid, vDocId, vDesde, vHasta, vNum_Desde, vNum_Hasta, vDMid)
    End Function

    Public Shared Function GetList_Resumen(ByVal vperiodoid As Integer, ByVal vIglesiaid As Long) As DataTable
      Return suscripcionBD.GetList_Resumen(vperiodoid, vIglesiaid)

    End Function
    Public Shared Function GetList_Suscribir_Cursor(ByVal vAlmacenid As Integer, ByVal vPeriodo As Integer,
                                                    ByVal vsuscripcionid As Long, ByVal vUsuario As Long,
                                                     ByRef dtDoc As DataTable, ByRef dtSuscrip As DataTable) As Boolean
      Return suscripcionBD.GetList_Suscribir_cursor(vAlmacenid, vPeriodo, vsuscripcionid, vUsuario, dtDoc, dtSuscrip)
    End Function

    Public Shared Function Agregar(ByRef vCodigo As Long, ByVal objv As Suscripcion, ByVal myArr As String) As Long
      Dim rs As DataTable
      vCodigo = 0
      Try
        rs = suscripcionBD.Agregar(objv, myArr)

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


    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUs As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable
      Try
        rs = suscripcionBD.Eliminar(vCodigo, vUs, vCaja)
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

    Public Shared Function Cambiar_Estado(ByVal vSuscripcionID As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = suscripcionBD.Cambiar_Estado(vSuscripcionID, vUsuario, vCaja)
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

    Public Shared Function Cambiar_Usuario(ByVal vSuscripcionID As Long, ByVal vUsuario As Long, ByVal vCaja As String) As Boolean
      Dim rs As DataTable, vOk As Boolean = False

      Try
        rs = suscripcionBD.Cambiar_Usuario(vSuscripcionID, vUsuario, vCaja)
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

    Public Shared Function AgregarDP(ByVal vAlmacenid As Integer, ByVal myArr As String) As Long
      Dim rs As DataTable
      Dim vCodigo As Long = 0
      Try
        rs = suscripcionBD.Actualizar_DP(vAlmacenid, myArr)

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

    Public Shared Function GetList_Ciclo(ByVal vAlmacenId As Integer, ByVal vIglesiaid As Long, ByVal vPeriodoId As Integer,
                                         ByVal vDMid As Long, ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Return suscripcionBD.GetList_Ciclo(vAlmacenId, vIglesiaid, vPeriodoId, vDMid, vDesde, vHasta)
    End Function

  End Class
End Namespace


