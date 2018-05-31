Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class distrito
        Private mcodigo As Long = -1

        Private mnombre As String
        Private mcodigo_pro As Long
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
        Public Property codigo_pro() As Long
            Get
                Return mcodigo_pro
            End Get
            Set(ByVal value As Long)
                mcodigo_pro = value
            End Set
        End Property
    End Class
End Namespace
