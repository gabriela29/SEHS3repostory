Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class lista_negra
        Private mpersonaid As Long
        Private mpersona As String
        Private mcomentario As String

        Public Property personaid() As Long
            Get
                Return mpersonaid
            End Get
            Set(value As Long)
                mpersonaid = value
            End Set
        End Property

        Public Property persona() As String
            Get
                Return mpersona
            End Get
            Set(value As String)
                mpersona = value
            End Set
        End Property

        Public Property comentario() As String
            Get
                Return mcomentario
            End Get
            Set(value As String)
                mcomentario = value
            End Set
        End Property
    End Class

End Namespace

