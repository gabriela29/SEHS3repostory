Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
  Public Class reportes_gerencialesManager
    Public Shared Function Ventas_cliente_Audi(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                               ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As String, ByVal myarrrol As String) As DataTable

      Return reportes_gerencialesBD.Ventas_cliente_Audi(vempresa, vunidad, valmacen, vpersona,
                                                          vdesde, vhasta, vopcion, myarrrol)


    End Function

    Public Shared Function Amortizaciones_cliente_Audi(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                       ByVal vdesde As String, ByVal vhasta As String, ByVal vopcion As String, ByVal myarrrol As String) As DataTable

      Return reportes_gerencialesBD.Amortizaciones_cliente_Audi(vempresa, vunidad, valmacen, vpersona,
                                                          vdesde, vhasta, vopcion, myarrrol)


    End Function

    Public Shared Function Saldo_Provisiones(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                              ByVal vDesde As String, ByVal vhasta As String, ByVal vopcion As Integer) As DataTable

      Return reportes_gerencialesBD.Saldo_Provisiones(vempresa, vunidad, valmacen, vpersona, vDesde, vhasta, vopcion)


    End Function

    Public Shared Function PorCobrar_Provisiones_Cast(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vpersona As Long,
                                                    ByVal vDesde As String, ByVal vhasta As String, ByVal vopcion As Integer) As DataTable

      Return reportes_gerencialesBD.PorCobrar_Provisiones_Cast(vempresa, vunidad, valmacen, vpersona, vDesde, vhasta, vopcion)


    End Function

    Public Shared Function Stock_valorado(ByVal vunidad As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal operador As String,
                                          ByVal vstock As Long, ByVal vsubcategoria As Integer, ByRef dtStock As DataTable, ByVal vGrupo As String,
                                          ByVal vDesde As String, ByVal vHasta As String, ByVal vFicha As String, ByVal vSql As String,
                                           ByVal vreferencia As String, ByVal xproducto As Boolean, ByVal vnetas As Boolean, ByVal vIgv As Boolean) As Boolean

      Dim xok As Boolean = False
      If vFicha = "STOCK" Then
        xok = reportes_gerencialesBD.Stock_Valorado(vSql, vunidad, vmes, vanio, operador, vstock, vsubcategoria, dtStock, vGrupo)
      ElseIf vFicha = "VENTA" Then
        xok = reportes_gerencialesBD.Ventas_Producto(vSql, vunidad, vDesde, vHasta, operador, vstock, vsubcategoria,
                                                     dtStock, vGrupo, vreferencia, xproducto, vnetas, vIgv)
      End If

      'End If
      Return xok

    End Function

    Public Shared Function Movimiento_Producto(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                               ByVal vAnio As Integer, ByVal vMes As Integer, ByVal vCategoria As Integer) As DataTable

      Return reportes_gerencialesBD.Movimiento_Producto(vempresa, vunidad, valmacen, vAnio, vMes, vCategoria)


    End Function

    Public Shared Function Producto_NDias_UltimaFech_Comp(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                                            ByVal vAnio As Integer, ByVal vCategoria As Integer, ByVal vProducto As Long, ByVal vSoloStock As Boolean) As DataTable

      Return reportes_gerencialesBD.Producto_NDias_UltimaFech_Comp(vempresa, vunidad, valmacen, vAnio, vCategoria, vProducto, vSoloStock)


    End Function

    '========Reportes Financieros
    Public Shared Function Estado_Resultados(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer,
                                              ByVal vMes As Integer, ByVal vAnio As Integer) As DataTable

      Return reportes_gerencialesBD.Estado_Resultados(vempresa, vunidad, valmacen, vMes, vAnio)


    End Function

    Public Shared Function Listado_Pagos_Colportaje(ByVal vempresa As Integer, ByVal vunidad As Integer, ByVal valmacen As Integer, ByVal vAsistente As Long,
                                                    ByVal vPersona As Long, ByVal vDesde As String, ByVal vHasta As String, ByVal vOpcion As String) As DataTable

      Return reportes_gerencialesBD.Listado_Pagos_Colportaje(vempresa, vunidad, valmacen, vAsistente, vPersona, vDesde, vHasta, vOpcion)


    End Function


  End Class
End Namespace

