Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class consignacionBD

        Public Shared Function Leer_Consignacion_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vPersona As Long, _
                                                     ByVal vDocumento As Integer, ByVal vNumero As String, ByVal vDesde As String, _
                                                     ByVal vHasta As String, ByVal vTipo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paconsignacion_leer_res")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vDocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                'oSP.addParameter("vhistorial", vHistorial, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)
                'vunidad integer, valmacen integer, vcampania integer, vpersona integer, 
                'vdocumento integer, vnumero character varying, vfecha_desde character varying, 
                'vfecha_hasta character varying, vtipo integer)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Consignacion(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vCampania As Integer, ByVal vPersona As Long, _
                                                    ByVal vDocumento As Integer, ByVal vNumero As String, ByVal vDesde As String, _
                                                    ByVal vHasta As String, ByVal vTipo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paconsignacion_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vcampania", vCampania, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdocumento", vDocumento, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vnumero", vNumero, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vtipo", vTipo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Consignacion_xGuia_Res(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long, _
                                                             ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paconsig_ctrl_guia_leer_res")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                'vunidad integer, valmacen integer, vcampania integer, vpersona integer, 
                'vdocumento integer, vnumero character varying, vfecha_desde character varying, 
                'vfecha_hasta character varying, vtipo integer)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Consignacion_xGuia_Leer(ByVal vUnidad As Integer, ByVal vAlmacen As Integer, ByVal vPersona As Long, _
                                                     ByVal vDesde As String, ByVal vHasta As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.paconsig_ctrl_guia_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("vunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("valmacen", vAlmacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("vdesde", vDesde, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                oSP.addParameter("vhasta", vHasta, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)
                'vunidad integer, valmacen integer, vcampania integer, vpersona integer, 
                'vdocumento integer, vnumero character varying, vfecha_desde character varying, 
                'vfecha_hasta character varying, vtipo integer)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function Agregar(ByRef objC As consignacion, ByVal myArr As String) As DataTable
      Dim vCadena As String = ""

      Try
        vCadena = "select * from colportaje.padistribucion_asistente_actualizar(true, "
        vCadena = vCadena & " 0,"
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Documento)) & ","
        vCadena = vCadena & " '" & objC.Numero & "',"
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Almacen)) & ","
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Campania)) & ","
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Asistente)) & ","
        vCadena = vCadena & " '" & Trim(objC.fecha) & "',"
        vCadena = vCadena & " " & Trim(Str(objC.Total)) & ","
        vCadena = vCadena & " " & Trim(Str(objC.porcentaje_dzmo)) & ","
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Usuario)) & ","
        vCadena = vCadena & " '" & objC.caja & "',"
        vCadena = vCadena & " '" & IIf(objC.Signo_Positivo, "+", "-") & "', "
        vCadena = vCadena & " " & Trim(Str(objC.Importe_Dzmo)) & ","
        vCadena = vCadena & " " & Trim(myArr) & ", "
        vCadena = vCadena & " " & Trim(Str(objC.Tipo)) & ", "
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Dist_Ref)) & ", "
        vCadena = vCadena & " " & Trim(Str(objC.Codigo_Ref1)) & " "
        vCadena = vCadena & " )"

        Dim oConexion As New clsConexion
        Agregar = oConexion.Ejecutar_Consulta(vCadena)
        oConexion.Cerrar_Conexion()
        oConexion = Nothing
      Finally
        vCadena = ""
      End Try
    End Function




  End Class

End Namespace
