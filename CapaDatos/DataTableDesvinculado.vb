Imports System
Imports System.ComponentModel

Namespace Dal

    Public Class DataTableDesvinculadoBD
        Public Shared Function GenerarDataTable(ByVal NombreTabla As String, ByVal MisParametros() As Object, ByVal MisTipos() As Object) As DataTable
            ' Create new DataTable.
            Dim table As DataTable = New DataTable(NombreTabla)
            ' Declare DataColumn and DataRow variables.
            Dim column As DataColumn
            For x As Integer = 0 To MisParametros.GetUpperBound(0) - 1
                column = New DataColumn
                column.DataType = System.Type.GetType(MisTipos(x))  'System.Type.GetType("")
                column.ColumnName = MisParametros(x)
                table.Columns.Add(column)
            Next
            Return table
        End Function
    End Class
End Namespace