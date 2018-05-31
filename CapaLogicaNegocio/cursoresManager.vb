Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class cursoresManager

    Public Shared Function Inicializa_Windows(ByVal vPersonaid As Long, ByRef dtmenu As DataTable, ByRef dtunidad As DataTable,
                                                    ByRef dtAlmacen As DataTable, ByRef dtpermisos As DataTable, ByRef dtperdoc As DataTable,
                                                    ByRef dtplan As DataTable, ByRef dtctacte As DataTable, ByRef dtconf As DataTable) As Boolean
      Return cursoresBD.Inicializa_Windows(vPersonaid, dtmenu, dtunidad, dtAlmacen, dtpermisos, dtperdoc, dtplan, dtctacte, dtconf)
    End Function

    Public Shared Function Permisos_Windows(ByVal vPersonaid As Long, ByRef dtmenu As DataTable, ByRef dtmod_emp As DataTable, ByRef dtotros As DataTable) As Boolean
            Return cursoresBD.Permisos_Windows(vPersonaid, dtmenu, dtmod_emp, dtotros)
        End Function

        Public Shared Function Datos_Ventana_Persona(ByVal vPersonaId As Long, ByRef dtRol As DataTable, ByRef dtEstCivil As DataTable, _
                                               ByRef dtOtroDoc As DataTable, ByRef dtDpto As DataTable, ByRef dtDireccion As DataTable, _
                                               ByRef dtTpTelefono As DataTable, ByRef dtTelefono As DataTable, ByRef dtTipoEmail As DataTable, _
                                               ByRef dtEmail As DataTable, ByRef dtTipoRedes As DataTable, ByRef dtRedes As DataTable, ByRef dtDatos As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Persona(vPersonaId, dtRol, dtEstCivil, dtOtroDoc, dtDpto, dtDireccion, dtTpTelefono, dtTelefono, dtTipoEmail, dtEmail, dtTipoRedes, dtRedes, dtDatos)
        End Function


        Public Shared Function Datos_Ventana_RegisVentas(ByVal Codigo_IdPersona As Long, ByRef tabla As DataTable, ByRef idtabla As DataTable, ByRef mes As DataTable,
                                                        ByRef año As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_RegisVentas(Codigo_IdPersona, tabla, idtabla, mes, año)

        End Function




        Public Shared Function Datos_Ventana_Importacion(ByVal vCodigo_Movimiento As Integer, ByVal vModulo As Integer,
                                                          ByRef dtDocumento As DataTable, ByRef dtAduana As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Importacion(vCodigo_Movimiento, vModulo,
                                                           dtDocumento, dtAduana)
        End Function

        Public Shared Function Datos_Ventana_Ing_Mer_Edit(ByVal vCodigo As Long, ByVal vMov As Integer, ByVal vModulo As Long, _
                                                          ByRef dtDoc As DataTable, ByRef dtCab As DataTable, ByRef dtDet As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Ing_Mer_Edit(vCodigo, vMov, vModulo, dtDoc, dtCab, dtDet)
        End Function


        Public Shared Function Datos_Venta_Cancela_pcp(ByVal vTipo As String, ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                      ByVal vCaja As String, ByVal vDocLegal As Boolean, _
                                                      ByRef dtDocumento As DataTable, ByVal dtTP As DataTable) As Boolean
            Dim rOk As Boolean = False
            If vTipo = "PC" Then
                rOk = cursoresBD.Datos_Venta_Cancela_pc(vAlmacen, vUsuario, vCaja, vDocLegal, dtDocumento, dtTP)
            Else
                rOk = cursoresBD.Datos_Venta_Cancela_pp(vAlmacen, vUsuario, vCaja, vDocLegal, dtDocumento, dtTP)
            End If
            Return rOk
        End Function

        Public Shared Function Datos_Ventana_venta(ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                      ByVal vCaja As String, ByVal vFrm As String, _
                                                      ByRef dtDoc As DataTable, ByRef dtDoc_Dzmo As DataTable, _
                                                      ByRef dtFP As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Venta(vAlmacen, vUsuario, vCaja, vFrm, dtDoc, dtDoc_Dzmo, dtFP)
        End Function

        Public Shared Function Datos_Ventana_Anticipos(ByVal vAlmacen As Integer, ByVal vUsuario As Long, ByVal vCaja As String, _
                                                        ByRef dtDoc As DataTable, ByRef dtFP As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Anticipos(vAlmacen, vUsuario, vCaja, dtDoc, dtFP)
        End Function

        Public Shared Function Datos_Ventana_Bol_Colp(ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                          ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                          ByRef dtDoc_Dzmo As DataTable, ByRef dtFP As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Boleteo_Colp(vAlmacen, vUsuario, vCaja, dtDocumento, dtDoc_Dzmo, dtFP)
        End Function

        Public Shared Function Datos_Ventana_NC_Colp(ByVal vAlmacen As Integer, ByVal vCliente As Long, ByVal vVentaid As Long, ByVal vUsuario As Long, _
                                                  ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                  ByRef dtDoc_Dzmo As DataTable, ByRef dtSaldos As DataTable, _
                                                  ByRef dtCab As DataTable, ByRef dtVenta As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_NC_Colp(vAlmacen, vCliente, vVentaid, vUsuario, vCaja, dtDocumento, dtDoc_Dzmo, dtSaldos, dtCab, dtVenta)
        End Function

    Public Shared Function Datos_Ventana_Web_NC_Colp(ByVal vAlmacen As Integer, ByVal vCliente As Long, ByVal vVentaid As Long, ByVal vDevolverId As Long, ByVal vUsuario As Long,
                                                  ByVal vCaja As String, ByRef dtDocumento As DataTable,
                                                  ByRef dtDoc_Dzmo As DataTable, ByRef dtSaldos As DataTable,
                                                  ByRef dtCab As DataTable, ByRef dtVenta As DataTable) As Boolean
      Return cursoresBD.Datos_Ventana_Web_NC_Colp(vAlmacen, vCliente, vVentaid, vDevolverId, vUsuario, vCaja, dtDocumento, dtDoc_Dzmo, dtSaldos, dtCab, dtVenta)
    End Function

    Public Shared Function Datos_Ventana_Web_NC_Colp(ByVal vAlmacen As Integer, ByVal vAsistenteid As Long, ByVal vDevolverId As Long, ByVal vUsuario As Long,
                                                  ByVal vCaja As String, ByRef dtDocumento As DataTable, dtDetalle As DataTable) As Boolean
      Return cursoresBD.Datos_Ventana_Web_Dev_Asis(vAlmacen, vAsistenteid, vDevolverId, vUsuario, vCaja, dtDocumento, dtDetalle)
    End Function

    Public Shared Function Datos_Ventana_Liquidacion_VIP(ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                              ByVal vCaja As String, ByVal vCodigo_Ref As Long, ByRef dtDocumento As DataTable, _
                                                              ByRef dtGP As DataTable, ByRef dtFP As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Liquidacion_VIP(vAlmacen, vUsuario, vCaja, vCodigo_Ref, dtDocumento, dtGP, dtFP)
        End Function

        Public Shared Function Datos_Ventana_venta_NC(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                        ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                        ByRef dtRef As DataTable, ByRef dtSaldos As DataTable, ByRef dtVenta As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Venta_NC(vCodigo, vAlmacen, vUsuario, vCaja, dtDocumento, dtRef, dtSaldos, dtVenta)
        End Function

        Public Shared Function Datos_Ventana_Compra_NC(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                        ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                        ByRef dtVenta As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Compra_NC(vCodigo, vAlmacen, vUsuario, vCaja, dtDocumento, dtVenta)
        End Function

        Public Shared Function Datos_Ventana_Venta_Guia(ByVal vCodigo As Long, ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                           ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                           ByRef dtVenta As DataTable, ByVal dtVenta_Det As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Venta_Guia(vCodigo, vAlmacen, vUsuario, vCaja, dtDocumento, dtVenta, dtVenta_Det)
        End Function

        Public Shared Function Datos_Ventana_Salida(ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                      ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                      ByRef dtAlm_Dest As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_Salida(vAlmacen, vUsuario, vCaja, dtDocumento, dtAlm_Dest)
        End Function

        Public Shared Function Datos_Ventana_PorCobrar(ByVal vAlmacen As Integer, ByVal vUsuario As Long, _
                                                          ByVal vCaja As String, ByRef dtDocumento As DataTable, _
                                                          ByRef dtCC As DataTable) As Boolean
            Return cursoresBD.Datos_Ventana_PorCobrar(vAlmacen, vUsuario, vCaja, dtDocumento, dtCC)
        End Function

    Public Shared Function Datos_Imprimir_Venta(ByVal vCodigo As Long, ByRef dtCabecera As DataTable,
                                              ByRef dtDetalle As DataTable) As Boolean
      Return cursoresBD.Datos_Imprimir_Venta(vCodigo, dtCabecera, dtDetalle)
    End Function

    Public Shared Function Datos_Imprimir_Venta_PWC(ByVal vCodigo As Long, ByVal vAlmacenid As Integer, ByRef dtCabecera As DataTable,
                                              ByRef dtDetalle As DataTable) As Boolean
      Return cursoresBD.Datos_Imprimir_Venta_PWC(vCodigo, vAlmacenid, dtCabecera, dtDetalle)
    End Function

    Public Shared Function Datos_Imprimir_Guia(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, _
                                      ByRef dtDetalle As DataTable) As Boolean
            Return cursoresBD.Datos_Imprimir_Guia(vCodigo, dtCabecera, dtDetalle)
        End Function

        Public Shared Function Datos_Imprimir_MB(ByVal vCodigo As Long, ByRef dtCabecera As DataTable, _
                                      ByRef dtDetalle As DataTable) As Boolean
            Return cursoresBD.Datos_Imprimir_MB(vCodigo, dtCabecera, dtDetalle)
        End Function

        Public Shared Function Datos_Plan_CtaCte(ByVal vEntidad As Long, ByRef dtPlan As DataTable, _
                              ByRef dtCtaCte As DataTable) As Boolean
            Return cursoresBD.Datos_Plan_cta(vEntidad, dtPlan, dtCtaCte)
        End Function

        Public Shared Function Datos_Ventana_Suscripcion(ByVal vPeriodo As Long, ByVal vUnidadId As Long, _
                                                         ByRef dtDM As DataTable, ByRef dtIglesias As DataTable) As Boolean
            Dim xOk As Boolean = False
            Try
                xOk = cursoresBD.Datos_Ventana_Suscripcion(vPeriodo, vUnidadId, dtDM, dtIglesias)
            Catch ex As Exception
                xOk = False
            End Try
            Return xOk
        End Function

    Public Shared Function Datos_Ventana_Dep_Colp_Web(ByVal vAlmacen As Integer, ByVal vPersonaid As Long, ByVal vUsuario As Long,
                                                        ByVal vCaja As String, ByRef dtDocumento As DataTable, ByRef dtSaldos As DataTable) As Boolean
      Return cursoresBD.Datos_Ventana_Dep_Colp_Web(vAlmacen, vPersonaid, vUsuario, vCaja, dtDocumento, dtSaldos)
    End Function

  End Class
End Namespace


