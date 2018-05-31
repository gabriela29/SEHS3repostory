Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class rolManager
        Public Shared Function GetList() As DataTable
            Return rolBD.GetList()
        End Function
        Public Shared Function GetItem(ByVal codigo As Integer) As rol
            Return rolBD.GetItem(codigo)
        End Function
        Public Shared Function Grabar(ByRef objrol As rol) As Integer
            Try
                Dim rolid = rolBD.Grabar(objrol)
                Return rolid
            Finally
            End Try
        End Function
        Public Shared Function Eliminar(ByVal Objrol As rol) As Boolean
            Return rolBD.Eliminar(Objrol.rolid)
        End Function
    End Class
End Namespace
