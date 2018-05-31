Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll

    Public Class misionManager
        Public Shared Function GetList(ByVal vUnion As Integer, ByVal vNombre As String) As DataTable
            Return misionBD.GetList(vUnion, vNombre)
        End Function
    End Class
End Namespace