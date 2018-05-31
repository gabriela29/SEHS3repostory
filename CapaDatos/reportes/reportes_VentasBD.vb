Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class reportes_ventasBD

        Public Shared Function List_Dzmo(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer, _
                                         ByVal vDetalle As Boolean, ByVal vNC As Boolean) As DataTable
            'parpt_listado_dzmo('2014/12/01', '2014/12/25', 20, false)
            Dim oSP As New clsStored_Procedure("colportaje.pareporte_listado_dzmo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdetallado", vDetalle, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vnc", vNC, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                List_Dzmo = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return List_Dzmo
        End Function

        Public Shared Function Registro_Ingresos(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long) As DataTable

            Dim oSP As New clsStored_Procedure("finanzas.paregistro_ingresos")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Registro_Ingresos = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Registro_Ingresos
        End Function

    Public Shared Function rptRanking_Ventas(ByVal vTipoRanking As String, ByVal vOpcion As String, ByVal vIndicador As String, ByVal vDesde As String,
                                                    ByVal vHasta As String, ByVal vAlmacen As Long, ByVal vLimite As Long, ByVal vCat As Integer, ByVal vUnidadid As Integer) As DataTable

      Dim oSP As New clsStored_Procedure("inventarios.paranking")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("tipoRanking", vTipoRanking, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vOpcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vIndicador", vIndicador, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

        oSP.addParameter("vDesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vHasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

        oSP.addParameter("vAlmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("vlimite", vLimite, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("vcat", vCat, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        oSP.addParameter("vUnidadid", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        rptRanking_Ventas = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
        '(character varying, character varying, character varying, character varying, character varying, integer, integer)
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return rptRanking_Ventas
    End Function

    Public Shared Function Ventas_Documento(ByVal vCondicion As String, ByVal vDesde As String, ByVal vHasta As String, _
                                                ByVal vCodigo_Doc As Integer, ByVal vUsuario As String, ByVal vSerie As String, _
                                                ByVal vCodigo_Alm As Integer) As DataTable

            Dim oSP As New clsStored_Procedure("inventarios.pareporte_ventas_detalladas")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcondicion", vCondicion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
                oSP.addParameter("vcodigo_doc", vCodigo_Doc, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vusuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vserie", vSerie, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Ventas_Documento = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Ventas_Documento
        End Function

    Public Shared Function Ventas_SubCategoria(ByVal vCondicion As String, ByVal vDesde As String, ByVal vHasta As String,
                                                ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vUnidadid As Integer) As DataTable
      'select * from paventas_subcategoria('2015/01/01', '2015/01/31', 0, 2, 'TODOS')
      Dim oSP As New clsStored_Procedure("inventarios.paventas_subcategoria")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)
        oSP.addParameter("vcodigo_us", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vcondicion", vCondicion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vcodigo_uni", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        Ventas_SubCategoria = oConexion.ConsultarPA(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return Ventas_SubCategoria
    End Function

    Public Shared Function Ventas_Guia_IU(ByVal vCodigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("paimprimir_venta_guia")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Ventas_Guia_IU = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Ventas_Guia_IU
        End Function

        Public Shared Function Detalle_Documento_Codigo(ByVal vcodigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("inventarios.pareporte_ventas_detalle_documento")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcodigo", vcodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Detalle_Documento_Codigo = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Detalle_Documento_Codigo
        End Function

        Public Shared Function Asiento_Prov_Dzmo(ByVal vCodigo_Alm As Integer, ByVal vFecha As String) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_dzmo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vFecha, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Asiento_Prov_Dzmo = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Prov_Dzmo
        End Function

        Public Shared Function Asiento_NC_PROV_Dzmo(ByVal vCodigo_Alm As Integer, ByVal vMes As Integer, ByVal vAnio As Integer) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_nc_vta_dzmo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_NC_PROV_Dzmo = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_NC_PROV_Dzmo
        End Function

        Public Shared Function Asiento_Prov_Dzmo(ByVal vLote As Long) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_dzmo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vlote", vLote, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_Prov_Dzmo = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Prov_Dzmo
        End Function


        Public Shared Function Asiento_Prov_Ingreso(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean, _
                                                    ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_provision")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Asiento_Prov_Ingreso = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Prov_Ingreso
        End Function

        Public Shared Function Asiento_vta_Ingreso(ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vProcesar As Boolean, _
                                            ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim vCuenta As Integer = 0
            'finanzas.paasiento_vta_provision(3, '2015/01/05', false, 1, 2015 ,'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_ingresos")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Asiento_vta_Ingreso = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_vta_Ingreso
        End Function



        Public Shared Function Resumen_mov_caja(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vFecha As String) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paingresos_mov_caja")
            Dim oConexion As New clsConexion
            Try
                'incodigo_usu integer, incodigo_alm integer, infecha
                oSP.addParameter("vusuario", vCuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vFecha, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Resumen_mov_caja = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Resumen_mov_caja
        End Function

        Public Shared Function Ingresos_mov_caja_Sus(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vFecha As String) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paingresos_mov_caja")
            Dim oConexion As New clsConexion
            Try
                'incodigo_usu integer, incodigo_alm integer, infecha
                oSP.addParameter("vusuario", vCuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vfecha", vFecha, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Ingresos_mov_caja_Sus = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Ingresos_mov_caja_Sus
        End Function

        Public Shared Function Asiento_Ingreso(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paasiento_ingresosb")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcuenta", vCuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_Ingreso = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Ingreso
        End Function

        Public Shared Function Asiento_Ingreso_NC(ByVal vDesde As String, ByVal vHasta As String, ByVal vCodigo_Alm As Integer) As DataTable
            'paasiento_nota_credito(integer, character varying, character varying, integer)
            '	vCuenta:=$1;	vDesde:=cast($2 as date);	vHasta:=cast($3 as date); 	vAlmacen:=$4;
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paasiento_nota_credito")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcuenta", vCuenta, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_Ingreso_NC = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Ingreso_NC
        End Function

        Public Shared Function Movimiento_Caja(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paingresos_mov_caja")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcuenta", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Movimiento_Caja = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Movimiento_Caja
        End Function

        Public Shared Function Det_Movimiento_Caja_Ing(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("padet_ingresos_mov_caja")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcuenta", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Det_Movimiento_Caja_Ing = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Det_Movimiento_Caja_Ing
        End Function

        Public Shared Function Det_Movimiento_Caja_Sus(ByVal vUsuario As Long, ByVal vCodigo_Alm As Integer, ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("padet_ingresos_mov_caja_sus")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcuenta", vUsuario, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Det_Movimiento_Caja_Sus = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Det_Movimiento_Caja_Sus
        End Function

        Public Shared Function Asiento_Costo_Venta(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vCodigo_Alm As Integer) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("inventarios.paasiento_costo_venta")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_Costo_Venta = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Costo_Venta
        End Function

        Public Shared Function Asiento_Venta_MM_NC(ByVal vMes As Integer, ByVal vAnio As Integer, ByVal vCodigo_Alm As Integer) As DataTable
            Dim vCuenta As Integer = 0

            Dim oSP As New clsStored_Procedure("paasiento_vta_mm_nc")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vdesde", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vhasta", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Asiento_Venta_MM_NC = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Venta_MM_NC
        End Function

        Public Shared Function Asiento_Venta_PROV_NC(ByVal vCodigo_Alm As Integer, ByVal vProcesar As Boolean, ByVal vMes As Integer, _
                                                     ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim vCuenta As Integer = 0
            '(3, false, 3, 2015, 'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_provision_nc")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Asiento_Venta_PROV_NC = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Venta_PROV_NC
        End Function

        Public Shared Function Asiento_Venta_PAGOS_NC(ByVal vCodigo_Alm As Integer, ByVal vProcesar As Boolean, ByVal vMes As Integer, _
                                                        ByVal vAnio As Integer, ByVal vUsuario As String, ByVal vCaja As String) As DataTable
            Dim vCuenta As Integer = 0
            '(3, false, 3, 2015, 'admin', 'dsfot')
            Dim oSP As New clsStored_Procedure("finanzas.paasiento_vta_ingresos_nc")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vprocesar", vProcesar, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                oSP.addParameter("vmes", vMes, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vsuario", vUsuario, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vcaja", vCaja, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Asiento_Venta_PAGOS_NC = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Asiento_Venta_PAGOS_NC
        End Function

    Public Shared Function rptVentasxVendedor(ByVal vUnidadid As Integer, ByVal vAlmacenid As Integer,
                                           ByVal vDesde As String, ByVal vHasta As String,
                                           ByVal vVendedorid As Long, ByVal vOpcion As String,
                                           ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As DataTable
      Dim TempList As New DataTable
      'suscripcion.paperiodo_leer(vinicio integer, vfin integer, vnombre character varying)
      Dim oSP As New clsStored_Procedure("finanzas.paventasxvendedor")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vunidadid", vUnidadid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("viglesiaid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vpersona", vVendedorid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vopcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vmorosos", vMorosos, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
        oSP.addParameter("vmixto", vMixto, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

  End Class
End Namespace