
Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class bonificacion_tipo
        Private mboniftipoid As Long = -1
        Private malmacenid As Integer
        Private mnombre As String
        Private mdesde As String
        Private mhasta As String
        Private morden As Integer
        Private mestado As Boolean

        Public Property boniftipoid() As Long
            Get
                Return mboniftipoid
            End Get
            Set(ByVal value As Long)
                mboniftipoid = value
            End Set
        End Property

        Public Property almacenid() As Integer
            Get
                Return malmacenid
            End Get
            Set(ByVal value As Integer)
                malmacenid = value
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

        Public Property desde() As String
            Get
                Return mdesde
            End Get
            Set(ByVal value As String)
                mdesde = value
            End Set
        End Property

        Public Property hasta() As String
            Get
                Return mhasta
            End Get
            Set(ByVal value As String)
                mhasta = value
            End Set
        End Property

        Public Property orden() As Integer
            Get
                Return morden
            End Get
            Set(ByVal value As Integer)
                morden = value
            End Set
        End Property

        Public Property estado() As Boolean
            Get
                Return mestado
            End Get
            Set(ByVal value As Boolean)
                mestado = value
            End Set
        End Property
    End Class
End Namespace

