Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class tabla_virtual

        Private mcodigo As Long
        Private mnombre As String
        Private mimporte As Single

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

        Public Property importe() As Single
            Get
                Return mimporte
            End Get
            Set(ByVal value As Single)
                mimporte = value
            End Set
        End Property
    End Class
End Namespace
