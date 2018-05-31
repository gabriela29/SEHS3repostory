Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class distritoManager
        Public Shared Function GetList(ByVal cod_prov As Integer, ByVal Descripcion As String) As DataTable
            Return distritoBD.GetList(cod_prov, Descripcion)
        End Function
        Public Shared Function GetUbigeo(ByVal Descripcion As String) As DataTable
            Return distritoBD.GetUbigeo(Descripcion)
        End Function
        Public Shared Function GetItem(ByVal codigo As Integer) As distrito
            Return distritoBD.GetItem(codigo)
        End Function
        Public Shared Function Grabar(ByRef objstrito As distrito) As Integer
            Try
                Dim idstrito = distritoBD.Grabar(objstrito)
                Return idstrito
            Finally
            End Try
        End Function
        Public Shared Function Eliminar(ByVal Objstrito As distrito) As Boolean
            Return distritoBD.Eliminar(Objstrito.codigo)
        End Function
    End Class
End Namespace
