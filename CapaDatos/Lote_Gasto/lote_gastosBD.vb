Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class lote_gastosBD
        Public Shared Function GetItem(ByVal codigo As Integer) As lote_gastos
            Dim objlote_gastos As lote_gastos = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("palote_gastos_getrow")
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objlote_gastos = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objlote_gastos
        End Function

        Public Shared Function GetList(ByVal vCodigo_Uni As Integer, ByVal vBusca As String, ByVal vAnio As Integer, ByVal vTipo As String, ByVal vOpciones As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("palote_gastos_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_uni", vCodigo_Uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vBusca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inanio", vAnio, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                oSP.addParameter("inopciones", vOpciones, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function
        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As lote_gastos
            Dim objeto As lote_gastos = New lote_gastos
            objeto.codigo = objData.Item("codigo")
            objeto.cod_almacen = objData.Item("cod_almacen")
            objeto.descripcion = objData.Item("descripcion")
            objeto.fecha = objData.Item("fecha")
            objeto.tipo = objData.Item("tipo")
            If IsDate(objData.Item("fecha_cierre")) Then
                objeto.fecha_cierre = objData.Item("fecha_cierre")
            End If
            objeto.estado = objData.Item("estado")
            objeto.cod_us = objData.Item("cod_us")
            Return objeto
        End Function
        Public Shared Function Grabar(ByRef objlote_gastos As lote_gastos) As DataTable
            Dim oSP As New clsStored_Procedure("palote_gastos_actualizar")
            Try
                If objlote_gastos.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objlote_gastos.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("incod_almacen", objlote_gastos.cod_almacen, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("indescripcion", objlote_gastos.descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("incod_us", objlote_gastos.cod_us, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("intipo", objlote_gastos.tipo, NpgsqlTypes.NpgsqlDbType.Varchar, 5, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function
        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("palote_gastos_eliminar")
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Cambiar_Estado(ByVal codigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("palote_gastos_cambiar_estado")
            Try
                oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                Dim oConexion As New clsConexion
                Cambiar_Estado = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

    End Class
End Namespace
