Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal
Namespace Bll
    Public Class tipo_mov_mercaderiaManager
        Public Shared Function GetList() As DataTable
            Return tipo_mov_mercaderiaBD.GetList()
        End Function
    End Class
End Namespace