Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
Public Class documentoBD
        Public Shared Function GetItem(ByVal codigo As Integer) As documento
             Dim objdocumento As documento = Nothing
             Dim TempList As New DataTable
             Dim oSP As New clsStored_Procedure("padocumento_getrow")
             Dim oConexion As New clsConexion
             Dim objReader As DataRow 
            Try
             oSP.addParameter("incodigo", codigo, NpgsqlTypes.NpgsqlDbType.Integer,4,ParameterDirection.Input)
             TempList = oConexion.Ejecutar_Consulta(oSP)
                objReader = Nothing
                If TempList.Rows.Count > 0 Then
                    objReader = TempList.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objdocumento = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return objdocumento
        End Function

        Public Shared Function GetList(ByVal descripcion As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.padocumento_leer")
            Dim oConexion As New clsConexion
           Try
               oSP.addParameter("innombre", descripcion, NpgsqlTypes.NpgsqlDbType.VarChar, 50, ParameterDirection.Input)
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

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As documento
            Dim objeto As documento = New documento
            objeto.codigo = objData.Item("codigo")
            objeto.nombre = objData.Item("nombre")
            objeto.signo = objData.Item("signo")
            objeto.nombre_corto = objData.Item("nombre_corto")
            objeto.codigo_contable = objData.Item("codigo_contable")
            Return objeto
        End Function
        Public Shared Function Grabar(ByRef objdocumento As documento) As DataTable
           Dim oSP As New clsStored_Procedure("padocumento_actualizar")
           Try
               If objdocumento.codigo = -1 Then
               oSP.addParameter("innew", True,NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
               Else
               oSP.addParameter("innew", False,NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
               End If
               oSP.addParameter("incodigo", objdocumento.codigo, NpgsqlTypes.NpgsqlDbType.Integer,2,ParameterDirection.Input)

               oSP.addParameter("innombre", objdocumento.nombre, NpgsqlTypes.NpgsqlDbType.varchar,30,ParameterDirection.Input)

               oSP.addParameter("insigno", objdocumento.signo, NpgsqlTypes.NpgsqlDbType.varchar,1,ParameterDirection.Input)

               oSP.addParameter("innombre_corto", objdocumento.nombre_corto, NpgsqlTypes.NpgsqlDbType.varchar,5,ParameterDirection.Input)

                oSP.addParameter("incodigo_contable", objdocumento.codigo_contable, NpgsqlTypes.NpgsqlDbType.Varchar, 2, ParameterDirection.Input)

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
                       oSP.addParameter("incodigo",codigo,NpgsqlTypes.NpgsqlDbType.Integer,4,ParameterDirection.Input)
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
