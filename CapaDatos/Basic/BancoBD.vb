Imports CapaObjetosNegocio
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql

Namespace Dal
    Public Class BancoBD
        Public Shared Function GetItem(ByVal codigo As Integer) As banco
            Dim objbanco As banco = Nothing
            Dim Templist As New DataTable
            Dim osP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow

            Try
                osP = "select * from basic.banco where bancoid=" & codigo
                Templist = oConexion.Ejecutar_Consulta(osP)
                objReader = Nothing
                If Templist.Rows.Count > 0 Then
                    objReader = Templist.Rows(0)
                End If
                Try
                    If Not objReader Is Nothing Then
                        objbanco = LlenarDatosRegistro(objReader)
                    End If
                Finally
                    objReader = Nothing
                End Try
            Finally
                oCOnexion.Cerrar_Conexion()
                oCOnexion = Nothing
                osP = Nothing
            End Try
            Return objbanco
        End Function

        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.pabanco_leer")
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

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As banco
            Dim objeto As banco = New banco
            objeto.bancoid = objData.Item("bancoid")
            objeto.nombre = objData.Item("nombre")
            objeto.abreviatura = objData.Item("abreviatura")
            objeto.referencia = objData.Item("referencia")
            Return objeto

        End Function

        Public Shared Function Grabar(ByRef objb As banco) As DataTable
            Dim oSP As New clsStored_Procedure("basic.pabanco_actualizar")
            Dim ncadena As String = ""
            Try
                ncadena = "select * from basic.pabanco_actualizar("
                ncadena = ncadena & " " & IIf(objb.bancoid > 0, "false", "true") & ", "
                ncadena = ncadena & " " & Trim(Str(objb.bancoid)) & ","
                ncadena = ncadena & " '" & Trim(objb.nombre) & "', "
                ncadena = ncadena & " '" & Trim(objb.abreviatura) & "',"
                ncadena = ncadena & " '" & Trim(objb.referencia) & "' "
                ncadena = ncadena & ")"

                Dim oConexion As New clsConexion
                Grabar = oConexion.Ejecutar_Consulta(ncadena)
                oConexion.Cerrar_Conexion()
                oConexion = Nothing
            Finally
                ncadena = ""
            End Try
        End Function
        Public Shared Function Eliminar(ByVal inbancoid As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("basic.pabanco_eliminar")
            Try
                oSP.addParameter("inbancoid", inbancoid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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