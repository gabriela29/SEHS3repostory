
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class destino_bonificacionBD

        Public Shared Function GetItem(ByVal codigo As Integer) As bonificacion_destino
            Dim objG As bonificacion_destino = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_destino_getrow")
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
                        objG = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objG
        End Function

        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_destino_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As bonificacion_destino
            Dim objeto As bonificacion_destino = New bonificacion_destino
            objeto.bonifdestid = objData.Item("bonificaciondestinoid")
            objeto.nombre = objData.Item("nombre")
            objeto.importemin = objData.Item("importe_min")
            objeto.estado = objData.Item("estado")
            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As bonificacion_destino) As DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_destino_actualizar")
            Try
                If objc.bonifdestid = 0 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If

                oSP.addParameter("incodigo", objc.bonifdestid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombre", objc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inimporte_min", objc.importemin, NpgsqlTypes.NpgsqlDbType.Numeric, 10, ParameterDirection.Input)

                oSP.addParameter("inestado", objc.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)


                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vgrupoId As Long) As DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_destino_eliminar")
            Try
                oSP.addParameter("inbonifdestid", vgrupoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

