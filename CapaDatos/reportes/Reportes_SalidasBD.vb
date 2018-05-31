Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO

Namespace Dal
    Public Class Reportes_SalidasBD
        Public Shared Function Detalle_Documento(ByVal vcodigo As Long) As DataTable

            Dim oSP As New clsStored_Procedure("inventarios.pareporte_salida_mercaderia_documento")
            Dim oConexion As New clsConexion
            Try

                oSP.addParameter("vcodigo", vcodigo, NpgsqlTypes.NpgsqlDbType.Integer, 4, ParameterDirection.Input)

                Detalle_Documento = oConexion.ConsultarPA(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return Detalle_Documento
        End Function
    End Class
End Namespace

