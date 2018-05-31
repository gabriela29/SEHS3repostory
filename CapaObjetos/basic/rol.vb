Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class rol
        Private mrolid As Long = -1
        Private mnombre As String

        Private mabreviatura As String
        Private mimagen As String
        Private mestructura As String
        Private mtipo As String
        Private mpordefecto As Boolean
        Private morden As Integer
        Private mestado As Boolean

        Public Property rolid() As Long
            Get
                Return mrolid
            End Get
            Set(ByVal value As Long)
                mrolid = value
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

        Public Property abreviatura() As String
            Get
                Return mabreviatura
            End Get
            Set(ByVal value As String)
                mabreviatura = value
            End Set
        End Property

        Public Property imagen() As String
            Get
                Return mimagen
            End Get
            Set(ByVal value As String)
                mimagen = value
            End Set
        End Property

        Public Property estructura() As String
            Get
                Return mestructura
            End Get
            Set(ByVal value As String)
                mestructura = value
            End Set
        End Property

        Public Property tipo() As String
            Get
                Return mtipo
            End Get
            Set(ByVal value As String)
                mtipo = value
            End Set
        End Property

        Public Property pordefecto() As Boolean
            Get
                Return mpordefecto
            End Get
            Set(ByVal value As Boolean)
                mpordefecto = value
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