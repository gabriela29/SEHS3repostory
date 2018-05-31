Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class modulo_sistemaManager
        Public Shared Function GetList() As DataTable
            Return modulo_sistemaBD.GetList()
        End Function
    End Class
End Namespace