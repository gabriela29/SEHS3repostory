Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class comision_spManager
        Public Shared Function GetList(ByVal vNombre As String) As DataTable
            Return comision_spBD.GetList(vNombre)
        End Function

       
    End Class
End Namespace