Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class centro_costoBD

        Public Shared Function GetItem(ByVal Codigo_Alm As Integer, ByVal C_Costo As Long) As centro_costo
            Dim objccosto As centro_costo = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP = "select * from centro_costos where codigo_alm=" & Codigo_Alm & " and centro_costo=" & C_Costo

                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objccosto = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objccosto
        End Function

        Public Shared Function GetList(ByVal Codigo_Alm As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("pacentro_costos_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("valmacen", Codigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList(ByVal vCodigo_Det As Long, ByVal vCodigo_Uni As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padetalle_lote_gastos_c_c_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo", vCodigo_Det, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("incodigo_uni", vCodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

    Public Shared Function GetListcbo(ByVal Codigo_Alm As Integer, ByVal vNum_Grupo As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("colportaje.pacentro_costos_leer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("inalmacenid", Codigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
        oSP.addParameter("innumgrupo", vNum_Grupo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList

    End Function


    Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As centro_costo

            Dim objeto As centro_costo = New centro_costo            
            objeto.nombre = objData.Item("nombre")
            objeto.codigo_alm = objData.Item("codigo_alm")
            objeto.centro_costo = objData.Item("centro_costo")
            objeto.orden = objData.Item("orden")
            objeto.estado = objData.Item("estado")
            objeto.c_costo_old = objData.Item("c_costo_old")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objcc As centro_costo, ByVal swNuevo As Boolean, ByVal vC_Costo_Org As Long) As DataTable

            Dim oSP As New clsStored_Procedure("pacentro_costos_actualizar")
            Try
                'incodigo_uni,innombre,incentro_costo,inorden, inestado
                If swNuevo Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If

                oSP.addParameter("incodigo_uni", objcc.codigo_alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombre", objcc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("incentro_costo", objcc.centro_costo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inorden", objcc.orden, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inestado", objcc.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 1, ParameterDirection.Input)

                oSP.addParameter("incosto_old", objcc.c_costo_old, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("invcosto", vC_Costo_Org, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal codigo_alm As Integer, ByVal c_costo As Long) As DataTable
            Dim oSP As String
            Try
                oSP = "delete from centro_costos where codigo_alm=" & codigo_alm & " and centro_costo=" & c_costo
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
