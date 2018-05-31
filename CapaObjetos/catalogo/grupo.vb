Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class grupo

        Private mgrupoid As Long = -1
        Private mnombre As String
        Private mabrev As String

        Public Property grupoid() As Long
            Get
                Return mgrupoid
            End Get
            Set(ByVal value As Long)
                mgrupoid = value
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
