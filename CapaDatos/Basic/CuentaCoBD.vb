Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio

Namespace Dal
    Public Class CuentaCoBD
        Public Shared Function GetItem(ByVal codigo As Integer) As cuentaCorriente
            Dim objsc As cuentaCorriente = Nothing
            Dim TempList As New DataTable
            Dim oSP As String
            Dim oConexion As New clsConexion
            Dim objReader As DataRow


            Try
                oSP = "select * from basic.ctacte where ctacteid=" & codigo
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

        Public Shared Function GetList(ByVal vCategoriaId As Integer, ByVal vNombre As String) As DataTable
            Dim TempList As New DataTable
            Dim oSP As New clsStored_Procedure("basic.pactacte_leer")
            Dim oConexion As New clsConexion
            Try
                oSP.addParameter("inctacteid", vCategoriaId, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)
                oSP.addParameter("innumero", vNombre, NpgsqlTypes.NpgsqlDbType.Integer, 50, ParameterDirection.Input)

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList
        End Function

        Private Shared Function LlenarDatosRegistro(ByVal objData As DataRow) As cuentaCorriente
            Dim objeto As cuentaCorriente = New cuentaCorriente
            objeto.ctacteid = objData.Item("ctacteid")
            objeto.bancoid = objData.Item("bancoid")
            objeto.empresaid = objData.Item("empresaid")
            objeto.numero = objData.Item("numero")
            objeto.abreviatura = objData.Item("abreviatura")
            objeto.sucursal = objData.Item("sucursal")
            objeto.referencia = objData.Item("referencia")
            objeto.moneda = objData.Item("moneda")
            objeto.empresa = objData.Item("empresa")
            Return objeto


        End Function

        Public Shared Function Grabar(ByRef objc As cuentaCorriente) As DataTable
            Dim oSP As New clsStored_Procedure("basic.pactacte_actualizar")
            'Try
            '    If objc.ctacteid = -1 Then
            '        oSP.addParameter("innew", True, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
            '    Else
            '        oSP.addParameter("innew", False, NpgsqlTypes.NpgsqlDbType.Boolean, 0, ParameterDirection.Input)
            '    End If
            '    oSP.addParameter("inctacteid", objc.ctacteid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

            '    oSP.addParameter("inbancoid", objc.ctacteid, NpgsqlTypes.NpgsqlDbType.Integer, 2, ParameterDirection.Input)

            '    oSP.addParameter("innumero", objc.numero, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

            '    oSP.addParameter("inabreviatura", objc.abreviatura, NpgsqlTypes.NpgsqlDbType.Varchar, 50, ParameterDirection.Input)

            '    Dim oConexion As New clsConexion
            '    Grabar = oConexion.Ejecutar_Consulta(oSP)
            '    oConexion.Cerrar_Conexion()
            '    oConexion = Nothing
            'Finally
            '    oSP = Nothing
            'End Try
        End Function

        Public Shared Function Eliminar(ByVal ctacteid As Integer) As DataTable
            Dim oSP As New clsStored_Procedure("basic.pactacte_eliminar")
            Try
                oSP.addParameter("inctacte", ctacteid, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)
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