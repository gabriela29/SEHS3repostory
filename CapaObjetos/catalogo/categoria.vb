Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class categoria

        Private mcategoriaid As Long = -1
        Private mnombre As String
        Private mabrev As String

        Public Property categoriaid() As Long
            Get
                Return mcategoriaid
            End Get
            Set(ByVal value As Long)
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
