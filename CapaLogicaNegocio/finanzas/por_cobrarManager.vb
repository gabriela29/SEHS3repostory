Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
  Public Class por_cobrarManager

    Public Shared Function Leer_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                        ByVal vOpcion As Integer, ByVal vPersona As Long, ByVal t As Boolean) As DataTable
      Dim vdt As New DataTable

      If t Then
        vdt = por_cobrarBD.Leer_Rest(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)
      Else
        vdt = por_cobrarBD.Leer_Res(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)
      End If

      Return vdt
    End Function

    Public Shared Function Grabar(ByRef objmb As por_cobrar) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = por_cobrarBD.Grabar(objmb)
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

    Public Shared Function Leer_Detalles(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                         ByVal vOpcion As Integer, ByVal vPersona As Long, ByVal dtCabecera As DataTable,
                                         ByVal dtDetalle As DataTable, dtAnticipo As DataTable) As Boolean
      Return por_cobrarBD.Leer_Detalles(vUnidad, vAlmacen, vhasta, vOpcion, vPersona, dtCabecera, dtDetalle, dtAnticipo)
    End Function

    Public Shared Function Leer_Experian(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String, ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Return por_cobrarBD.Leer_Experian(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)

    End Function

    Public Shared Function RptPorCobrar_Res(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String,
                                            ByVal vPersona As Long, ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim xDt As New DataTable
      If vPersona > 0 Then
        xDt = por_cobrarBD.RptPorCobrar_Res(vDeno, vDesde, vHasta, vPersona, vCodigo_Alm, vOpcion)
      Else
        xDt = por_cobrarBD.RptPorCobrar_Res_Cons(vDeno, vDesde, vHasta, vPersona, vCodigo_Alm, vOpcion)
      End If
      Return xDt
    End Function

    Public Shared Function RptPorCobrar_Res_Colp(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String,
                                            ByVal vPersona As Long, ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim xDt As New DataTable
      If vPersona > 0 Then
        xDt = por_cobrarBD.RptPorCobrar_Res_Colp(vDeno, vDesde, vHasta, vPersona, vCodigo_Alm, vOpcion)
      Else
        xDt = por_cobrarBD.RptPorCobrar_Res_Cons(vDeno, vDesde, vHasta, vPersona, vCodigo_Alm, vOpcion)
      End If
      Return xDt
    End Function

    Public Shared Function RptPorCobrar_Ndias(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String,
                                              ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer,
                                                ByVal vPersona As Long, ByVal vOpcion As String, ByVal vUsuarioid As Long) As DataTable
      Dim xDt As New DataTable
      xDt = por_cobrarBD.RptPorCobrar_Ndias(vDeno, vDesde, vHasta, vUnidad, vCodigo_Alm, vPersona, vOpcion, vUsuarioid)

      Return xDt
    End Function

    Public Shared Function RptPorCobrar_Res_GP(ByVal vDeno As Boolean, ByVal vDesde As String, ByVal vHasta As String,
                                    ByVal vPersona As Long, ByVal vUnidadId As Integer, ByVal vCodigo_Alm As Integer, ByVal vOpcion As String) As DataTable
      Dim xDt As New DataTable

      xDt = por_cobrarBD.RptPorCobrar_Res_gp(vDeno, vDesde, vHasta, vPersona, vUnidadId, vCodigo_Alm, vOpcion)

      Return xDt
    End Function

    Public Shared Function RptSaldo_Prod_Fact(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vHasta As String) As DataTable
      Return por_cobrarBD.RptSaldo_Prod_Fact(vAlmacenId, vPersonaid, vHasta)
    End Function

    Public Shared Function RptSaldo_Prod_Fact(ByVal vFuncion As String, ByVal vAlmacenId As Integer, ByVal vPersonaid As Long,
                                              ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Return por_cobrarBD.RptSaldo_Prod_Fact(vFuncion, vAlmacenId, vPersonaid, vDesde, vHasta)
    End Function

    Public Shared Function RptImporte_Prod_Fact(ByVal vAlmacenId As Integer, ByVal vPersonaid As Long, ByVal vDesde As String, ByVal vHasta As String) As DataTable
      Return por_cobrarBD.RptImporte_Prod_Fact(vAlmacenId, vPersonaid, vDesde, vHasta)
    End Function

    Public Shared Function RptEstado_Cuenta(ByVal vFuncion As String, ByVal vPersona As Long, ByVal vCodigo_Alm As Integer, ByVal vHasta As String) As DataTable
      Return por_cobrarBD.RptEstado_Cuenta(vFuncion, vPersona, vCodigo_Alm, vHasta)
    End Function

    Public Shared Function RptEstado_Cuenta2(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vhasta As String,
                                             ByVal vOpcion As Integer, ByVal vPersona As Long) As DataTable
      Return por_cobrarBD.RptEstado_Cuenta2(vUnidad, vAlmacen, vhasta, vOpcion, vPersona)
    End Function

    Public Shared Function Info_Sehs(ByVal vPersona As Long, ByVal vDocumento As String) As DataTable
      Return por_cobrarBD.Info_Sehs(vPersona, vDocumento)
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuario As String, ByVal vCaja As String) As Boolean
      Dim rs As DataTable
      Try
        rs = por_cobrarBD.Eliminar(vCodigo, vUsuario, vCaja)
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

    Public Shared Function EmitirCartaG(ByVal vCodigo As Long, ByVal vNum_Carta As Integer) As DataTable

      Return por_cobrarBD.PorCobrarCartaG(vCodigo, vNum_Carta)

    End Function

    Public Shared Function EmitirCarta(ByVal vPersonaid As Long, ByVal vUnidadid As Integer) As DataTable

      Return por_cobrarBD.PorCobrarCarta(vPersonaid, vUnidadid)

    End Function

    Public Shared Function AgregarDP(ByVal vAlmacenid As Integer, ByVal myArr As String, ByVal vTabla As String) As Long
      Dim rs As DataTable
      Dim vCodigo As Long = 0
      Try
        rs = por_cobrarBD.Actualizar_DP(vAlmacenid, myArr, vTabla)

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

    Public Shared Function PorCobrar_Prov_Castigo(ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer,
                                                  ByVal vHastaVence As String, ByVal vNdias As Long) As DataTable
      Dim xDt As New DataTable
      xDt = por_cobrarBD.PorCobrar_Prov_Castigo(vUnidad, vCodigo_Alm, vHastaVence, vNdias)

      Return xDt
    End Function

    Public Shared Function Grabar_Prov_Castigo(ByVal valmacenid As Integer, ByVal vfecha As String, ByVal vvoto As String,
                                                ByVal vdetalle As String, ByVal vfechadias As String, ByVal vndias As Integer,
                                                ByVal myarrcxc As String, ByVal vusuarioid As Long, ByVal vcaja As String) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = por_cobrarBD.Grabar_Prov_Castigo(valmacenid, vfecha, vvoto, vdetalle, vfechadias, vndias, myarrcxc, vusuarioid, vcaja)
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

    Public Shared Function PorCobrar_Prov_Castigo_Leer(ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer,
                                                    ByVal vHastaVence As String) As DataTable
      Dim xDt As New DataTable
      xDt = por_cobrarBD.PorCobrar_Prov_Castigo_Leer(vUnidad, vCodigo_Alm, vHastaVence)

      Return xDt
    End Function

    Public Shared Function PorCobrar_Prov_Castigo_Rpt(ByVal vCodigo As Long, ByVal vUnidad As Integer, ByVal vCodigo_Alm As Integer,
                                                ByVal vHastaVence As String) As DataTable
      Dim xDt As New DataTable
      xDt = por_cobrarBD.PorCobrar_Prov_Castigo_Rpt(vCodigo, vUnidad, vCodigo_Alm, vHastaVence)

      Return xDt
    End Function

  End Class
End Namespace