Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class empresa
        Private mcodigo As Long = -1

        Private mnombre As String
        Private mruc As String

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property
        Public Property nombre() As String
            Get
                Return mnombre
            End Get
            Set(ByVal value As String)
                mnombre = value
            End Set
        End Property
        Public Property ruc() As String
            Get
                Return mruc
            End Get
            Set(ByVal value As String)
                mruc = value
            End Set
        End Property
    End Class
End Namespace
