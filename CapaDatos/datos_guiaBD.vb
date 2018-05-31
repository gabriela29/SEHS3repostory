Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class datos_guiaBD
        Public Shared Function GetItem(ByVal codigo As Long) As datos_guia
            Dim objDG As datos_guia = Nothing
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("datos_guia_consulta")
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
                        objDG = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objDG
        End Function

        Public Shared Function GetList(ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padocumento_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Public Shared Function GetList_Tipo(ByVal vTipo As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("padocumento_consulta_tipo")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("intipo", vTipo, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As datos_guia
            Dim objeto As datos_guia = New datos_guia
            objeto.codigo_ven = objData.Item("codigo")
            objeto.fecha_trans = objData.Item("fecha_trans")
            objeto.desde = objData.Item("desde")
            objeto.hasta = objData.Item("hasta")
            objeto.codigo_emp = objData.Item("codigo_emp")
            objeto.ruc_trans = objData.Item("ruc_emp")
            objeto.nombre_trans = objData.Item("nombre_trans")
            objeto.direccion_trans = objData.Item("direccion_trans")
            objeto.marca = objData.Item("marca")
            objeto.placa = objData.Item("placa")
            objeto.codigo_cho = objData.Item("codigo_cho")
            objeto.dni_cho = objData.Item("dni")
            objeto.ape_pat = objData.Item("ape_pat")
            objeto.ape_mat = objData.Item("ape_mat")
            objeto.nombre = objData.Item("nombre")
            objeto.nrolicencia = objData.Item("nrolicencia")

            Return objeto


        End Function

        Public Shared Function Grabar(ByRef objDG As datos_guia) As DataTable
            Dim oSP As New clsStored_Procedure("padatos_guia_actualizar")
            Try
                'incodigo_ven integer, infecha_tras date, indesde character varying, inhasta character varying,
                'incodigo_emp integer, inmarca character varying, inplaca  character varying, incodigo_cho
                oSP.addParameter("incodigo_ven", objDG.codigo_ven, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

                oSP.addParameter("infecha_trans", objDG.fecha_trans, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("indesde", objDG.desde, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)

                oSP.addParameter("inhasta", objDG.hasta, NpgsqlTypes.NpgsqlDbType.Varchar, 150, ParameterDirection.Input)

                oSP.addParameter("incodigo_emp", objDG.codigo_emp, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                oSP.addParameter("inmarca", objDG.marca, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

                oSP.addParameter("inplaca", objDG.placa, NpgsqlTypes.NpgsqlDbType.Varchar, 20, ParameterDirection.Input)

                oSP.addParameter("incodigo_cho", objDG.codigo_cho, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                oSP = Nothing
            End Try
        End Function
        Public Shared Function Eliminar(ByVal codigo As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("padocumento_eliminar")
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
