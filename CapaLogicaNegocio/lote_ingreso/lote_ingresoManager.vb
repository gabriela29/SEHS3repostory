
Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class lote_ingresoManager
    Public Shared Function GetList_Pendientes(ByVal vCodigo_Alm As Integer, ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vTipo As String) As DataTable
      Dim xDt As New DataTable
      If vTipo = "PROVING" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paprovision_vta_por_dias")
      ElseIf vTipo = "PAGOING" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paingreso_por_dias")
      ElseIf vTipo = "PROVNC" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paprovision_vta_nc_por_dias")
      ElseIf vTipo = "DZMOPROV" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_dzmo_dias")
      ElseIf vTipo = "DZMONC" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_dzmo_nc_dias")
      ElseIf vTipo = "INGNC" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_nc_ingresos_dias")
      ElseIf vTipo = "VTAF" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_costo_venta_dias")
      ElseIf vTipo = "TRANS" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.patransferencia_por_dias")
      ElseIf vTipo = "NCDSCTO" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_porpagar_nc_dias")
      ElseIf vTipo = "PROVINCO" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_provision_incobrables_dias")

      ElseIf vTipo = "INGPROVM" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias")
      ElseIf vTipo = "INGMOVM" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_mov_mercaderia_dias")
      ElseIf vTipo = "INGTRANS" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.patransferencia_ing_dias")
      ElseIf vTipo = "INGNCP" Then
        'xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias_nc")
      ElseIf vTipo = "INGNCM" Then
        xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias_nc")
      Else
        'xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "finanzas.paingreso_por_dias")
      End If


      Return xDt
    End Function

    Public Shared Function GetListConta(ByVal vEntidad As Integer, ByVal vCodigo_Alm As Integer, ByVal vBusca As String,
                                            ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vTipo As String, ByVal vAssi As Boolean) As DataTable
      Dim xDt As New DataTable
      If vTipo = "INGPROVM" Then
        xDt = lote_ingresoBD.GetList_Contabilizado("contable.palote_ing_mercaderia_procesado_leer", vEntidad, vCodigo_Alm, vBusca, vAnio, vMes, vTipo, vAssi)
      ElseIf vTipo = "INGMOVM" Then
        xDt = lote_ingresoBD.GetList_Contabilizado("contable.palote_ing_mercaderia_procesado_leer", vEntidad, vCodigo_Alm, vBusca, vAnio, vMes, vTipo, vAssi)
      ElseIf vTipo = "INGNCP" Then
        'xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias_nc")
      ElseIf vTipo = "INGNCM" Then
        xDt = lote_ingresoBD.GetList_Contabilizado("contable.palote_ing_mercaderia_procesado_leer", vEntidad, vCodigo_Alm, vBusca, vAnio, vMes, vTipo, vAssi)
      Else
        xDt = lote_ingresoBD.GetList_Contabilizado("contable.palote_ingreso_procesado_leer", vEntidad, vCodigo_Alm, vBusca, vAnio, vMes, vTipo, vAssi)
      End If

      Return xDt
    End Function

    Public Shared Function Asiento_Lote_Ingreso_Conta(ByVal vLote As Long, ByVal vTipo As String) As DataTable
      Dim pDtp As New DataTable

      '"finanzas.paasiento_ingresos_lote_conta"
      '"contable.paasiento_ing_mer_lote_conta"
      If vTipo = "INGPROVM" Then
        pDtp = lote_ingresoBD.Asiento_Lote_Ingreso_Conta("contable.paasiento_ing_mer_lote_conta", vLote, vTipo)
      ElseIf vTipo = "INGMOVM" Then
        pDtp = lote_ingresoBD.Asiento_Lote_Ingreso_Conta("contable.paasiento_ing_mer_lote_conta", vLote, vTipo)
      ElseIf vTipo = "INGNCP" Then
        'xDt = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias_nc")
      ElseIf vTipo = "INGNCM" Then
        pDtp = lote_ingresoBD.Asiento_Lote_Ingreso_Conta("contable.paasiento_ing_mer_lote_conta", vLote, vTipo)
      Else
        pDtp = lote_ingresoBD.Asiento_Lote_Ingreso_Conta("finanzas.paasiento_ingresos_lote_conta", vLote, vTipo)
      End If



      Return pDtp
    End Function

    Public Shared Function Procesar_Lote_Ingreso_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean,
                                                    ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String,
                                                    ByVal DtProvision As DataTable, ByVal dtPagos As DataTable) As Boolean

      Dim xOk As Boolean = False
      Try
        xOk = lote_ingresoBD.Procesar_Lote_Ingresos_Asientos(vCodigo_Alm, vDesde, vProcesar, vMes, vAnio, vUsuario, vCaja, DtProvision, dtPagos)
        xOk = True
      Catch ex As Exception
        xOk = False
      End Try

      Return xOk
    End Function

    Public Shared Function Eliminar(ByVal vCodigo As Long, ByVal vUsuaroId As Long, ByVal vCaja As String, ByVal vTipo As String) As Boolean
      Dim rs As DataTable, vFun As String = ""
      Try

        If vTipo = "INGPROVM" Then
          vFun = "contable.paasiento_ingresos_mer_eliminar"
        ElseIf vTipo = "INGMOVM" Then
          vFun = "contable.paasiento_ingresos_mer_eliminar"
        ElseIf vTipo = "INGNCP" Then
          'vFun = lote_ingresoBD.GetList_Pendientes(vCodigo_Alm, vAnio, vMes, "contable.paasiento_ing_mercaderia_dias_nc")
        ElseIf vTipo = "INGNCM" Then
          vFun = "contable.paasiento_ingresos_mer_eliminar"
        Else
          vFun = "finanzas.paasiento_ingresos_eliminar"
        End If

        rs = lote_ingresoBD.Eliminar(vFun, vCodigo, vUsuaroId, vCaja)
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


    Public Shared Function Reporte_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vLote As Long,
                                             ByVal vMes As Integer, ByVal vAnio As Integer, vNodo As String) As DataTable
      Dim vFuncion As String = "", xDt As New DataTable
      If vNodo = "PROVING" Then
        vFuncion = "contable.pareporte_asiento_vta_provision"

      ElseIf vNodo = "DZMOPROV" Then
        vFuncion = "contable.pareporte_asiento_vta_dzmo"

      ElseIf vNodo = "PROVNC" Then
        vFuncion = "contable.pareporte_asiento_vta_provision_nc"

      ElseIf vNodo = "PAGOING" Then
        vFuncion = "contable.pareporte_asiento_vta_ingresos"

      ElseIf vNodo = "DZMONC" Then
        vFuncion = "contable.pareporte_asiento_nc_dzmo"

      ElseIf vNodo = "INGNC" Then
        vFuncion = "contable.pareporte_ingresos_nc"

      ElseIf vNodo = "VTAF" Then
        vFuncion = "contable.pareporte_costo_venta"
      ElseIf vNodo = "TRANS" Then
        vFuncion = "contable.pareporte_asiento_trans_salida"
      ElseIf vNodo = "NCDSCTO" Then
        vFuncion = "contable.pareporte_asiento_porpagar_nc"
      ElseIf vNodo = "PROVINCO" Then
        vFuncion = "contable.pareporte_asiento_provision_incobrables"
      ElseIf vNodo = "PROVINCO" Then
        vFuncion = "contable.pareporte_asiento_provision_incobrables"
      ElseIf vNodo = "INGTRANS" Then
        vFuncion = "contable.pareporte_asiento_trans_im"
      End If

      xDt = lote_ingresoBD.Reporte_Asientos(vCodigo_Alm, vDesde, vLote, vMes, vAnio, vFuncion)

      Return xDt
    End Function

    Public Shared Function Procesar_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vMes As Integer,
                                             ByVal vAnio As Integer, vNodo As String, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Dim vFuncion As String = "", xDt As New DataTable
      If vNodo = "PROVING" Then
        vFuncion = "contable.paprocesar_asiento_vta_provision"

      ElseIf vNodo = "DZMOPROV" Then
        vFuncion = "contable.paprocesar_asiento_vta_dzmo"

      ElseIf vNodo = "PROVNC" Then
        vFuncion = "contable.paprocesar_asiento_vta_provision_nc"

      ElseIf vNodo = "PAGOING" Then
        vFuncion = "contable.paprocesar_vta_ingresos"

      ElseIf vNodo = "DZMONC" Then
        vFuncion = "contable.paprocesar_asiento_nc_dzmo"

      ElseIf vNodo = "INGNC" Then
        vFuncion = "contable.paprocesar_ingresos_nc"

      ElseIf vNodo = "VTAF" Then
        vFuncion = "contable.paprocesar_costo_venta"
      ElseIf vNodo = "TRANS" Then
        vFuncion = "contable.paprocesar_asiento_trans_salida"
      ElseIf vNodo = "NCDSCTO" Then
        vFuncion = "contable.paprocesar_asiento_porpagar_nc"

      ElseIf vNodo = "PROVINCO" Then
        vFuncion = "contable.paprocesar_asiento_provision_incobrables"
      ElseIf vNodo = "INGTRANS" Then
        vFuncion = "contable.paprocesar_asiento_trans_im"
      End If

      xDt = lote_ingresoBD.Procesar_Asientos(vCodigo_Alm, vDesde, vMes, vAnio, vFuncion, vUsuario, vCaja)

      Return xDt
    End Function

    Public Shared Function Reporte_Procesar_Asientos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vMes As Integer, ByVal vProcesar As Boolean,
                                                      ByVal vAnio As Integer, vNodo As String, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
      Dim vFuncion As String = "", xDt As New DataTable
      If vNodo = "INGPROVM" Then
        vFuncion = "contable.paasiento_prov_compra_mer"

      ElseIf vNodo = "INGMOVM" Then
        vFuncion = "contable.paasiento_mov_mer_com"
      End If

      xDt = lote_ingresoBD.Reporte_Procesar_Asientos(vCodigo_Alm, vDesde, vMes, vAnio, vProcesar, vFuncion, vUsuario, vCaja)

      Return xDt
    End Function

    Public Shared Function Asiento_Assinet_Actualizar(ByVal vLote As Long, ByVal vEntidad As Integer, ByVal Lote_Assinet As Long, ByVal vGuid As String, ByVal vTypej As String, ByVal vTipo As String) As DataTable
      Dim pDtp As New DataTable


      pDtp = lote_ingresoBD.Asiento_Assinet_Actualizar(vLote, vEntidad, Lote_Assinet, vGuid, vTypej, vTipo)


      Return pDtp
    End Function
  End Class
End Namespace

