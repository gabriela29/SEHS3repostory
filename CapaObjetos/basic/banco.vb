Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Public Class banco
    Private nbancoid As Integer
    Private nnombre As String
    Private nabreviatura As String
    Private nreferencia As String

    Public Property bancoid() As Integer
        Get
            Return nbancoid
        End Get
        Set(ByVal value As Integer)
            nbancoid = value
        End Set

    End Property

    Public Property nombre() As String
        Get
            Return nnombre
        End Get
        Set(ByVal value As String)
            nnombre = value
        End Set

    End Property

    Public Property abreviatura() As String
        Get
            Return nabreviatura
        End Get
        Set(ByVal value As String)
            nabreviatura = value

        End Set

    End Property

    Public Property referencia() As String
        Get
            Return nreferencia
        End Get
        Set(ByVal value As String)
            nreferencia = value
        End Set

    End Property

End Class
