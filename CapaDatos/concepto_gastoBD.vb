Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class concepto_gastoBD

        Public Shared Function GetItem(ByVal codigo As Integer) As concepto_gasto
            Dim objCG As concepto_gasto = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paconcepto_gasto_getrow")
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
                        objCG = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objCG
        End Function

        Public Shared Function GetList(ByVal vCodigo_Alm As Integer, ByVal vBusca As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paconcepto_gasto_consulta")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vBusca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function
        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As concepto_gasto
            Dim objeto As concepto_gasto = New concepto_gasto
            objeto.codigo = objData.Item("codigo")

            objeto.nombre = objData.Item("nombre")
            objeto.estado = objData.Item("estado")
            Return objeto
        End Function

        Public Shared Function Grabar(ByRef objCG As concepto_gasto, ByVal vCtaMaestra As String, ByVal vCodigo_Alm As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("paconcepto_gasto_actualizar")
            Try
                If objCG.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objCG.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombre", objCG.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)

                oSP.addParameter("inctamaestra", vCtaMaestra, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vcodigo As Long, ByVal vCodigo_Alm As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("paconcepto_gasto_eliminar")
            Try
                oSP.addParameter("incodigo", vcodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                Dim oConexion As New clsConexion
                Eliminar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Cambiar_Estado(ByVal codigo As Long) As DataTable
            Dim oSP As New clsStored_Procedure("paconcepto_gasto_cambiar_estado")
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


