
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class material_subgrupoDB

        Public Shared Function GetItem(ByVal codigo As Integer) As material_subgrupo
            Dim objsc As material_subgrupo = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from suscripcion.pamaterialsubgrupo_getrow (" & codigo & ")"
                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objsc = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objsc
        End Function

        Public Shared Function GetList(ByVal vGrupoid As Long, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialsubgrupo_leer")
            Dim oConexion As New clsConexion
            'suscripcion.pamaterialsubgrupo_leer(vinicio integer, vfin integer, vmaterialgrupoid integer, vnombre character varying)
            Try
                oSP.addParameter("ininicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("infin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("grupoid", vGrupoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As material_subgrupo
            Dim objeto As material_subgrupo = New material_subgrupo
            objeto.grupoid = objData.Item("materialsubgrupoid")
            objeto.subgrupoid = objData.Item("materialgrupoid")
            objeto.nombre = objData.Item("nombre")
            objeto.abrev = objData.Item("abreviatura")

            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As material_subgrupo) As DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialsubgrupo_actualizar")
            '    innew boolean,    inmaterialsubgrupoid integer,    inmaterialgrupoid integer,    innombre character varying,    inabreviatura character varying,    inestado boolean)
            Try
                If objc.subgrupoid = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("insubcategoriaid", objc.subgrupoid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("incategoriaid", objc.grupoid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inabrev", objc.abrev, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inestado", True, NpgsqlTypes.NpgsqlDbType.Boolean, 2, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vSubCategoriaId As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialsubgrupo_eliminar")
            Try
                oSP.addParameter("insubcategoriaid", vSubCategoriaId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

