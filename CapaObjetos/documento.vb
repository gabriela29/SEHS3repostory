Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class documento
        Private mcodigo As Long = -1

        Private mnombre As String
        Private msigno As String
        Private mnombre_corto As String
        Private mcodigo_contable As String

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
        Public Property signo() As String
            Get
                Return msigno
            End Get
            Set(ByVal value As String)
                msigno = value
            End Set
        End Property
        Public Property nombre_corto() As String
            Get
                Return mnombre_corto
            End Get
            Set(ByVal value As String)
                mnombre_corto = value
            End Set
        End Property
        Public Property codigo_contable() As String
            Get
                Return mcodigo_contable
            End Get
            Set(ByVal value As String)
                mcodigo_contable = value
            End Set
        End Property
    End Class
End Namespace
