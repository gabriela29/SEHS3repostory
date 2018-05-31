Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class arqueo_fondo_fijo
        Private mcodigo As Long = -1

        Private mfecha As String
        Private mcodigo_uni As Long
        Private mcodigo_us As Long
        Private mnumerolote As Long
        Private mfondofijo As Object
        Private mdetalle As String
        Private mcerrado As Boolean
        Private mcaja As String

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property
        Public Property fecha() As String
            Get
                Return mfecha
            End Get
            Set(ByVal value As String)
                mfecha = value
            End Set
        End Property
        Public Property codigo_uni() As Long
            Get
                Return mcodigo_uni
            End Get
            Set(ByVal value As Long)
                mcodigo_uni = value
            End Set
        End Property
        Public Property codigo_us() As Long
            Get
                Return mcodigo_us
            End Get
            Set(ByVal value As Long)
                mcodigo_us = value
            End Set
        End Property
        Public Property numerolote() As Long
            Get
                Return mnumerolote
            End Get
            Set(ByVal value As Long)
                mnumerolote = value
            End Set
        End Property
        Public Property fondofijo() As Object
            Get
                Return mfondofijo
            End Get
            Set(ByVal value As Object)
                mfondofijo = value
            End Set
        End Property
        Public Property detalle() As String
            Get
                Return mdetalle
            End Get
            Set(ByVal value As String)
                mdetalle = value
            End Set
        End Property
        Public Property cerrado() As Boolean
            Get
                Return mcerrado
            End Get
            Set(ByVal value As Boolean)
                mcerrado = value
            End Set
        End Property
        Public Property caja() As String
            Get
                Return mcaja
            End Get
            Set(ByVal value As String)
                mcaja = value
            End Set
        End Property
    End Class
End Namespace
