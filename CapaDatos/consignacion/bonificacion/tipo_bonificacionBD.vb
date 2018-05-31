
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal

    Public Class tipo_bonificacionBD

        Public Shared Function GetItem(ByVal codigo As Integer) As bonificacion_tipo
            Dim objG As bonificacion_tipo = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_tipo_getrow")
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

        Public Shared Function GetList(ByVal vAlmacenid As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_tipo_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inalmacenid", vAlmacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As bonificacion_tipo
            Dim objeto As bonificacion_tipo = New bonificacion_tipo
            objeto.boniftipoid = objData.Item("bonificaciontipoid")
            objeto.nombre = objData.Item("nombre")
            objeto.desde = objData.Item("desde")
            objeto.hasta = objData.Item("hasta")
            objeto.estado = objData.Item("estado")
            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As bonificacion_tipo) As DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_tipo_actualizar")
            Try
                If objc.boniftipoid = 0 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If

                oSP.addParameter("incodigo", objc.boniftipoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inalmacenid", objc.almacenid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("innombre", objc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("indesde", objc.desde, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)

                oSP.addParameter("inhasta", objc.hasta, NpgsqlTypes.NpgsqlDbType.Varchar, 15, ParameterDirection.Input)

                oSP.addParameter("inestado", objc.estado, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)


                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vCodigoId As Long) As DataTable
            Dim oSP As New clsStored_Procedure("colportaje.pabonificacion_tipo_eliminar")
            Try
                oSP.addParameter("inboniftipoid", vCodigoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

