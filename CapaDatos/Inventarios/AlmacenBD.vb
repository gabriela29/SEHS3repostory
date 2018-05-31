Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class almacenBD
        Public Shared Function GetItem(ByVal codigo As Integer) As almacen
            Dim objalmacen As almacen = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from almacen where codigo=" & codigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objalmacen = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objalmacen
        End Function

        Public Shared Function GetList(ByVal vEmpresa As Integer, ByVal vUnidad As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("inventarios.paalmacen_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inempresa", vEmpresa, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("inunidad", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetRow_Entidad(ByVal vCodigo_Alm As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("paalmacen_fondo_fijo_getrow")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As almacen
            Dim objeto As almacen = New almacen
            objeto.codigo = objData.Item("codigo")
            objeto.nombre = objData.Item("nombre")
            objeto.direccion = objData.Item("direccion")
            objeto.codigo_uni = objData.Item("codigo_uni")
            objeto.monto = objData.Item("monto")
            objeto.telefono = objData.Item("telefono")
            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objalmacen As almacen) As DataTable
            Dim oSP As New clsStored_Procedure("paalmacen_actualizar")
            Try
                If objalmacen.codigo = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("incodigo", objalmacen.codigo, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objalmacen.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("direccion", objalmacen.direccion, NpgsqlTypes.NpgsqlDbType.Varchar, 100, ParameterDirection.Input)

                oSP.addParameter("codigo_uni", objalmacen.codigo_uni, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("monto", objalmacen.monto, NpgsqlTypes.NpgsqlDbType.Numeric, 10, ParameterDirection.Input)

                oSP.addParameter("telefono", objalmacen.telefono, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

    Public Shared Function GetCombo_Resto_Almacen(ByVal vCodigo_Alm As Integer, ByVal vUnidad As Integer) As DataTable
      Dim TempList As New DataTable
      Dim oSP As New clsStored_Procedure("inventarios.paalmacen_restoleer")
      Dim oConexion As New clsConexion
      Try
        oSP.addParameter("incodigo_alm", vCodigo_Alm, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
        oSP.addParameter("incodigo_uni", vUnidad, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
        TempList = oConexion.Ejecutar_Consulta(oSP)
        oConexion.Cerrar_Conexion()
      Finally
        oConexion = Nothing
        oSP = Nothing
      End Try
      Return TempList
    End Function

    Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("paalmacen_eliminar")
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
    End Class
End Namespace
