Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports Npgsql
Imports CapaObjetosNegocio.BO
Namespace Dal
    Public Class unidad_negocioBD
        Public Shared Function GetList_Grupo(ByVal vCodigo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As String 'New clsStored_Procedure("basic.parol_leer")
            Dim oConexion As New clsConexion
            Try

                oSP = "select m.misionid, m.nombre, g.grupoid, g.nombre as grupo "
                oSP = oSP & " from suscripcion.mision m "
                oSP = oSP & " inner join suscripcion.grupo g on g.misionid=m.misionid"
                oSP = oSP & " where m.unidadnegocioid =" & vCodigo
                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function

        Public Shared Function GetList_Iglesia(ByVal vCodigo As Integer) As DataTable
            Dim TempList As New DataTable
            Dim oSP As String 'New clsStored_Procedure("basic.parol_leer")
            Dim oConexion As New clsConexion
            Try

                oSP = "select p.personaid,  p.raz_soc as nombre"
                oSP = oSP & " from basic.persona_juridica p inner join suscripcion.iglesia i on i.personajuridicaid=p.personaid"
                oSP = oSP & " where i.grupoid=" & vCodigo

                TempList = oConexion.Ejecutar_Consulta(oSP)
                oConexion.Cerrar_Conexion()
            Finally
                oConexion = Nothing
                oSP = Nothing
            End Try
            Return TempList

        End Function
   
    End Class
End Namespace
