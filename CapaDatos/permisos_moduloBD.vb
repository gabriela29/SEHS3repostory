Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class permisos_moduloBD

        Public Shared Function Leer_Unidad(ByVal vPersona As Long, ByVal vModulo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paunidad_negocio_consultar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmodulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Almacenes_Unidad(ByVal vPersona As Long, ByVal vModulo As Integer, ByVal vUnidad As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paalmacen_unidad_consultar")
            Dim oConexion As New clsConexion
            'inventarios.paalmacen_unidad_consultar(vcodigo_persona integer, vcodigo_modulo integer, vcodigo_uni integer)
            Try
                oSP.addParameter("inpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmodulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("inunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function Leer_Almacenes(ByVal vPersona As Long, ByVal vModulo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paalmacen_consultar")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inpersona", vPersona, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("inmodulo", vModulo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As permisos_modulo

            Dim objeto As permisos_modulo = New permisos_modulo
            objeto.codigo_per = objData.Item("codigo_per")
            objeto.codigo_alm = objData.Item("codigo_alm")
            objeto.codigo_mod = objData.Item("codigo_mod")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objcc As permisos_modulo, ByVal swNuevo As Boolean) As DataTable

            Dim oSP As String
            oSP = ""
            Try
                oSP = "insert into permisos_modulo values(" & objcc.codigo_per & "," & objcc.codigo_alm & "," & objcc.codigo_mod & ")"

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo_per As Long, ByVal codigo_alm As Integer, ByVal codigo_mod As Integer) As DataTable
            Dim oSP As String
            Try
                oSP = "delete from permisos_modulo where codigo_per=" & codigo_per & " and codigo_alm=" & codigo_alm & " and codigo_mod=" & codigo_mod
                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function
    End Class
End Namespace
