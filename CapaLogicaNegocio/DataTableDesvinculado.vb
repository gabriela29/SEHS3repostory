Imports System
Imports System.ComponentModel
Imports CapaDatos.Dal
Namespace Bll
    Public Class DataTableDesvinculado
        Public Shared Function GenerarDataTable(ByVal NombreTabla As String, ByVal MisParametros() As Object, ByVal MisTipos() As Object) As DataTable
            Return DataTableDesvinculadoBD.GenerarDataTable(NombreTabla, MisParametros, MisTipos)
        End Function
    End Class
End Namespace
