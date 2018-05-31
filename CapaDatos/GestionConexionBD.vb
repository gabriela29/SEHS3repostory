Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient

Namespace Dal
    Public Class GestionConexionBD
        Public Shared Function CerrarConexion(ByVal ok As Boolean, ByVal oCny As Npgsql.NpgsqlConnection, ByVal myTransi As Npgsql.NpgsqlTransaction) As Boolean
            Try
                If ok Then
                    myTransi.Commit()
                    oCny.Close()
                Else
                    myTransi.Rollback()
                End If
                CerrarConexion = True
            Catch Ex As Exception
                CerrarConexion = False
                MsgBox(Ex.Message)
            End Try
        End Function
    End Class
End Namespace
