Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class reportes_consignacionBD

        Public Shared Function Datos_Impresion_Dzmo(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.parpt_recibo_diezmo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Datos_Impresion_Dzmo_PWC(ByVal vCodigo As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.parpt_recibo_diezmo_w")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Detalle_Guia(ByVal vCodigo As Long) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pareporte_detalle_consignacion")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vcodigo", vCodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function rptKardex(ByVal vAlmacen As Integer, ByVal vProducto As Long,
                                        ByVal vDesde As String, ByVal vHasta As String, ByVal vPersona As Long) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.parpt_kardex_consignacion")
      Dim oConexion As New clsConexion
      Try

        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vproducto", vProducto, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)


        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function rptStock(ByVal vAlmacen As Integer, ByVal vAsistente As Long, ByVal vDesde As String, ByVal vHasta As String,
                                    ByVal vTipo As Integer, ByVal vOpcion As String, ByVal vCampaniaId As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.padistribucion_asistente_rpt_stock")
      Dim oConexion As New clsConexion
      Try
        'vcampania integer, valmacen integer, vasistente integer, vdesde character varying, vhasta

        oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vasistente", vAsistente, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        'If Not vDesde = "" Then
        oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        ' End If
        oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
        oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("vOpcion", vOpcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
        oSP.addParameter("vcampaniaid", vCampaniaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

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
