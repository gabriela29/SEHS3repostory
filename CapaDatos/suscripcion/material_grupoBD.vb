Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class material_grupoBD
        Public Shared Function GetItem(ByVal codigo As Integer) As material_grupo
            Dim objCat As material_grupo = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow
            Try

                oSP = "select * from suscripcion.pagrupo_getrow (" & codigo & ")"

                TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objCat = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objCat
        End Function

        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialgrupo_leer")
            Dim oConexion As New clsConexion
            'suscripcion.pamaterialgrupo_leer(0, 0, '')
            Try
                oSP.addParameter("ininicio", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("infin", 0, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
                oSP.addParameter("innombre", vNombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As material_grupo
            Dim objeto As material_grupo = New material_grupo
            objeto.grupoid = objData.Item("grupoid")
            objeto.nombre = objData.Item("nombre")
            objeto.abrev = objData.Item("abreviatura")

            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objc As material_grupo) As DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialgrupo_actualizar")
            '    innew boolean,    inmaterialgrupoid integer,    innombre character varying,    inabreviatura character varying,    inestado boolean)
            Try
                If objc.grupoid = -1 Then
                    oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                Else
                    oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
                End If
                oSP.addParameter("ingrupoid", objc.grupoid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("innombre", objc.nombre, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inabrev", objc.abrev, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inestado", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function

        Public Shared Function Eliminar(ByVal vgrupoId As Long) As DataTable
            Dim oSP As New clsStored_Procedure("suscripcion.pamaterialgrupo_eliminar")
            Try
                oSP.addParameter("ingrupoid", vgrupoId, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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

