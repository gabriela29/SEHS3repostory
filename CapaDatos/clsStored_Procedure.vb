'Imports System.Data.SqlClient
Imports Npgsql
'Imports Microsoft.Data.Odbc

Public Class clsParameter
    Public pNombre As String
    Public pValor As Object
    Public pTipo_Dato As NpgsqlTypes.NpgsqlDbType
    Public pSize As Long
    Public pDireccion As ParameterDirection

    Sub New(ByVal vNombre As String, ByVal vValor As Object, ByVal vTipo_Dato As NpgsqlTypes.NpgsqlDbType, _
            ByVal vSize As Long, ByVal vDireccion As ParameterDirection)
        Me.pNombre = vNombre
        Me.pValor = vValor
        Me.pTipo_Dato = vTipo_Dato
        Me.pSize = vSize
        Me.pDireccion = vDireccion
    End Sub

End Class

Public Class clsStored_Procedure
    Public pNombre As String
    Public pParametros As Collection

    Sub New(ByVal vNombre As String)
        Me.pNombre = vNombre
        Me.pParametros = New Collection
    End Sub

    Public Sub addParameter(ByVal vNombre As String, ByVal vValor As Object, ByVal vType As NpgsqlTypes.NpgsqlDbType, _
                            ByVal vSize As Long, ByVal vDireccion As ParameterDirection)
        Me.pParametros.Add(New clsParameter(vNombre, vValor, vType, vSize, vDireccion), vNombre)

    End Sub
End Class
