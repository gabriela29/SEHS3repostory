Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class bonificacion_destino
        Private mbonifdestid As Long = -1
        Private mnombre As String
        Private mimportemin As Single
        Private morden As Integer
        Private mestado As Boolean

        Public Property bonifdestid() As Long
            Get
                Return mbonifdestid
            End Get
            Set(ByVal value As Long)
                mbonifdestid = value
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

        Public Property importemin() As Single
            Get
                Return mimportemin
            End Get
            Set(ByVal value As Single)
                mimportemin = value
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
