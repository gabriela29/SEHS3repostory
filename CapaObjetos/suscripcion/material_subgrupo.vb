Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class material_subgrupo
        Private msubgrupoid As Long = -1
        Private mgrupoid As Long
        Private mnombre As String
        Private mabrev As String

        Public Property subgrupoid() As Long
            Get
                Return msubgrupoid
            End Get
            Set(ByVal value As Long)
                msubgrupoid = value
            End Set
        End Property

        Public Property grupoid() As Integer
            Get
                Return mgrupoid
            End Get
            Set(ByVal value As Integer)
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

