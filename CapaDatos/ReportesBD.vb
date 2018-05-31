Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

  Public Class ReportesBD

    Public Shared Function Registro_Venta(ByVal vUnidadId As Integer, ByVal vAlmacen As Integer, ByVal vanio As Integer, ByVal vmes As Integer,
                                          ByVal vPersona As Long, ByVal vcRUC As String, ByVal vHistorico As Boolean, ByVal vDesde As String,
                                          ByVal vHasta As String, ByVal vDocumentoid As Integer, ByVal vTabla As String) As DataTable

      Dim oSD As New clsStored_Procedure("contable.pareporte_registro_ventas")
      Dim oConexion As New clsConexion
      Try
        oSD.addParameter("vunidadid", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcruc", vcRUC, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSD.addParameter("vhistorico", vHistorico, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        oSD.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSD.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSD.addParameter("vdocumentoid", vDocumentoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSD.addParameter("vtabla", vTabla, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        Registro_Venta = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_Venta
    End Function

    Public Shared Function Registro_Venta_PLE(ByVal vanio As Integer, ByVal vmes As Integer, ByVal vEmpresa As Integer, ByVal vAlmacen As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("contable.paregistro_ventas_ple")
      Dim oConexion As New clsConexion
      Try
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vempresa", vEmpresa, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        Registro_Venta_PLE = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_Venta_PLE
    End Function

    Public Shared Function Registro_NC(ByVal vcodigo_unidad As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal vcodigo_documento As Integer, ByVal Recalcula As Boolean, ByVal Sunat As Boolean) As DataTable

      Dim oSD As New clsStored_Procedure("papreporte_registro_nc")
      Dim oConexion As New clsConexion
      Try
        oSD.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcodigo_documento", vcodigo_documento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vrecalcula", Recalcula, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)
        oSD.addParameter("vsunat", Sunat, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)

        Registro_NC = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_NC
    End Function

    Public Shared Function Registro_Venta_Res(ByVal vcodigo_unidad As Integer, ByVal vmes As Integer, ByVal vanio As Integer, ByVal vcodigo_documento As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("papreporte_registro_venta_res")
      Dim oConexion As New clsConexion
      Try
        oSD.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcodigo_documento", vcodigo_documento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        Registro_Venta_Res = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_Venta_Res
    End Function

    Public Shared Function Registro_Compras(ByVal vcodigo_unidad As Integer, ByVal vAlmacenid As Integer, ByVal vmes As Integer,
                                            ByVal vanio As Integer, ByVal vcodigo_per As Long, ByVal vRuc As String, ByVal vHistorico As Boolean) As DataTable

      Dim oSD As New clsStored_Procedure("contable.pareporte_registro_compras")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("vcodigo_unidad", vcodigo_unidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcodigo_per", vcodigo_per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vruc", vRuc, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSD.addParameter("vhistorico", vHistorico, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

        Registro_Compras = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_Compras
    End Function

    Public Shared Function Registro_Compras_PLE(ByVal vAnio As Integer, ByVal vmes As Integer,
                                                ByVal vEmpresa As Integer, ByVal vAlmacen As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("contable.paregistro_compra_ple")
      Dim oConexion As New clsConexion

      Try

        oSD.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vEmpresa", vEmpresa, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vAlmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        Registro_Compras_PLE = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_Compras_PLE
    End Function

    Public Shared Function Registro_DAOT(ByVal vAlmacenID As Integer, ByVal vmes As Integer,
                                            ByVal vanio As Integer, ByVal vMonto As Single) As DataTable

      Dim oSD As New clsStored_Procedure("contable.pareprote_registro_compras_daot")
      Dim oConexion As New clsConexion
      '	vAlmacen:=$1; vAno:=$2; vMes:=$3; vDigitos_Serie:=$4; vMonto:=$5;
      Try
        oSD.addParameter("valmacenid", vAlmacenID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmonto", vMonto, NpgsqlTypes.NpgsqlDbType.Numeric, 8, ParameterDirection.Input)


        Registro_DAOT = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_DAOT
    End Function

    Public Shared Function Registro_DAOT_Ventas(ByVal vAlmacenID As Integer, ByVal vmes As Integer,
                                                ByVal vanio As Integer, ByVal vMonto As Single) As DataTable

      Dim oSD As New clsStored_Procedure("contable.paregistro_ventas_daot")
      Dim oConexion As New clsConexion
      '	vAlmacen:=$1; vAno:=$2; vMes:=$3; vDigitos_Serie:=$4; vMonto:=$5;
      Try
        oSD.addParameter("valmacenid", vAlmacenID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmonto", vMonto, NpgsqlTypes.NpgsqlDbType.Numeric, 8, ParameterDirection.Input)

        Registro_DAOT_Ventas = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_DAOT_Ventas
    End Function

    Public Shared Function Registro_RH(ByVal vcodigo_Alm As Integer, ByVal vmes As Integer,
                            ByVal vanio As Integer, ByVal vcodigo_per As Long, ByVal vSerie_Digitos As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("contable.pareprte_registro_rh")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("vcodigo_alm", vcodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vanio", vanio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vmes", vmes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vidigtos_serie", vSerie_Digitos, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcodigo_per", vcodigo_per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        'oSD.addParameter("vswlegal", vswlegal, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        'oSD.addParameter("vrecalcula", vRecalcula, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

        Registro_RH = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Registro_RH
    End Function

    Public Shared Function Stock_Valorado(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer,
                                          ByVal vCategoria As Integer, ByVal vUni As Integer, ByVal vOpcion As Integer,
                                          ByVal vconCosto As Boolean, ByVal vTipoStock As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("inventarios.parptstock_valorado")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("xmes", xMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("xanio", xAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcategoria", vCategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vuni", vUni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSD.addParameter("vcosto", vconCosto, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        oSD.addParameter("vtipostock", vTipoStock, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


        'oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        '


        Stock_Valorado = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Stock_Valorado
    End Function

    Public Shared Function Stock_Unidades(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer,
                                          ByVal vCategoria As Integer, ByVal vUni As Integer, ByVal vSaldo As Boolean) As DataTable

      Dim oSD As New clsStored_Procedure("inventarios.parptstock_unidades")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("xmes", xMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("xanio", xAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcategoria", vCategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vuni", vUni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vsaldo", vSaldo, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)


        Stock_Unidades = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Stock_Unidades
    End Function

    Public Shared Function Costo_Venta(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer, ByVal vUnidadId As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("inventarios.pareporte_costo_venta")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("xmes", xMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("xanio", xAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vUnidadId", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        'oSD.addParameter("vcategoria", vCategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcodigo_per", vcodigo_per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        'oSD.addParameter("vswlegal", vswlegal, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        'oSD.addParameter("vrecalcula", vRecalcula, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

        Costo_Venta = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Costo_Venta
    End Function

    Public Shared Function Venta_Costo(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer, ByVal vUnidadId As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("inventarios.pareporte_venta_costo")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("xmes", xMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("xanio", xAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcategoria", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vUnidadId", vUnidadId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcodigo_per", vcodigo_per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        'oSD.addParameter("vswlegal", vswlegal, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        'oSD.addParameter("vrecalcula", vRecalcula, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

        Venta_Costo = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Venta_Costo
    End Function

    Public Shared Function Stock_Valorado_Actualziar(ByVal xMes As Integer, ByVal xAnio As Integer, ByVal vAlmacen As Integer) As Boolean

      Dim oSD As New clsStored_Procedure("inventarios.pastock_valorado_actualizar")
      Dim oConexion As New clsConexion
      Dim DtT As New DataTable
      Stock_Valorado_Actualziar = False
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("xmes", xMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("xanio", xAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcategoria", vCategoria, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcodigo_per", vcodigo_per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        'oSD.addParameter("vswlegal", vswlegal, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
        'oSD.addParameter("vrecalcula", vRecalcula, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

        DtT = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
        If Not DtT Is Nothing Then
          Stock_Valorado_Actualziar = True
        End If

      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Stock_Valorado_Actualziar
    End Function

    Public Shared Function Detalle_Documento_Merca(ByVal vFuncion As String, ByVal vDesde As String, ByVal vHasta As String,
                                                    ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long,
                                                    ByVal vProducto As Long) As DataTable

      Dim oSP As New clsStored_Procedure(vFuncion)
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        If vProducto > 0 Then
          oSP.addParameter("vproducto", vProducto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        End If
        Detalle_Documento_Merca = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return Detalle_Documento_Merca
    End Function

    Public Shared Function rptListado_Mov_Caja(ByVal vtipo As String, ByVal vcodigo_alm As Integer, ByVal vdesde As String, ByVal vhasta As String,
                                               ByVal vcuenta As String, ByVal vpersona As Long, ByVal vdocumento As Integer,
                                               ByVal vefectivo As Integer, ByVal vCat_Per As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("pareporte_list_mov_caja")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("vtipo", vtipo, NpgsqlTypes.NpgsqlDbType.Varchar, 10, ParameterDirection.Input)
        oSD.addParameter("vcodigo_alm", vcodigo_alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSD.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)

        oSD.addParameter("vcuenta", vcuenta, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSD.addParameter("vcodigo_per", vpersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vefectivo", vefectivo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcat_per", vCat_Per, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        rptListado_Mov_Caja = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return rptListado_Mov_Caja
    End Function

    Public Shared Function rptListado_PorCobrarN(ByVal vcodigo_Uni As Integer, ByVal vcodigo_alm As Integer, ByVal vdesde As String,
                                                 ByVal vhasta As String, ByVal vdocumento As Integer) As DataTable

      Dim oSD As New clsStored_Procedure("finanzas.parpt_porcobrar")
      Dim oConexion As New clsConexion
      'vunidad integer, vmes integer, vanio integer, vcodigo_per integer, vcuenta character varying, vswlegal boolean)
      Try
        oSD.addParameter("inunidadid", vcodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vcodigo_alm", vcodigo_alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vdesde", vdesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSD.addParameter("vhasta", vhasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSD.addParameter("vdocumento", vdocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


        rptListado_PorCobrarN = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return rptListado_PorCobrarN
    End Function

    Public Shared Function Kardex_completo(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vProductoid As Long,
                                            ByVal vAlmacen As Integer, ByVal vFamiliaID As Integer, ByVal vcPrecio As Boolean,
                                           ByVal vunidad As Integer, ByVal vrecalcular As Boolean, ByVal vhistorico As Boolean) As DataTable

      Dim oSD As New clsStored_Procedure("inventarios.pakardex_fisico_valorado")
      Dim oConexion As New clsConexion
      Try
        oSD.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("inmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSD.addParameter("vunidad", vunidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSD.addParameter("vfamilia", vFamiliaID, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSD.addParameter("vproducto", vProductoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSD.addParameter("vcprecio", vcPrecio, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        oSD.addParameter("vrecalcular", vrecalcular, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        oSD.addParameter("vhistorico", vhistorico, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)


        Kardex_completo = oConexion.ConsultarPA(oSD)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSD = Nothing
      End Try
      Return Kardex_completo
    End Function

  End Class
End Namespace
