Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class periodoManager
        Public Shared Function GetList(ByVal vInicio As Integer, ByVal vFin As Integer, ByVal vNombre As String) As DataTable
            Return peridoBD.GetList(vInicio, vFin, vNombre)
        End Function
    End Class
End Namespace


