Imports System.Data
Public Class DataReaderAdapter
    Inherits System.Data.Common.DataAdapter
    Public Function FillFromReader(ByVal dataTable As DataTable, ByVal dataReader As IDataReader) As Integer
        Return Me.Fill(dataTable, dataReader)
    End Function
End Class
