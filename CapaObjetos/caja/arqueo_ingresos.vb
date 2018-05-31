Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO

    Public Class arqueo_ingresos

        Private mcodigo As Long = -1

        Private mfecha As String
        Private mcodigo_alm As Long
        Private mcodigo_us As Long        
        Private mtotal_ing As Object
        Private mretiro As Object
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
        Public Property codigo_alm() As Long
            Get
                Return mcodigo_alm
            End Get
            Set(ByVal value As Long)
                mcodigo_alm = value
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
    
        Public Property total_ing() As Object
            Get
                Return mtotal_ing
            End Get
            Set(ByVal value As Object)
                mtotal_ing = value
            End Set
        End Property
        Public Property retiro() As Object
            Get
                Return mretiro
            End Get
            Set(ByVal value As Object)
                mretiro = value
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

