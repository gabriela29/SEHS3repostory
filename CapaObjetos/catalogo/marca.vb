Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class marca

        Private mmarcaid As Long = -1
        Private mnombre As String
        Private mabrev As String

        Public Property marcaid() As Long
            Get
                Return mmarcaid
            End Get
            Set(ByVal value As Long)
                mmarcaid = value
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

        Public Property abrev() As String
            Get
                Return mabrev
            End Get
            Set(ByVal value As String)
                mabrev = value
            End Set
        End Property

    End Class
End Namespace
