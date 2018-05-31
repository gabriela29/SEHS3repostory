Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class subcategoria

        Private msubcategoriaid As Long = -1
        Private mcategoriaid As Long
        Private mnombre As String
        Private mabrev As String

        Public Property subcategoriaid() As Long
            Get
                Return msubcategoriaid
            End Get
            Set(ByVal value As Long)
                msubcategoriaid = value
            End Set
        End Property

        Public Property categoriaid() As Integer
            Get
                Return mcategoriaid
            End Get
            Set(ByVal value As Integer)
                mcategoriaid = value
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
