Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO

    Public Class clave

        Private mcodigo As Long = -1
        Private mtipo As String
        Private mape_pat As String
        Private mape_mat As String
        Private mnombre As String        
        Private musuario As String
        Private mclave As String
        Private mestado As Boolean
        Private mfecha_reg As String
        Private mcodigo_cat As Long
        Private mcodigo_dis As Long

        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
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

        Public Property ape_pat() As String
            Get
                Return mape_pat
            End Get
            Set(ByVal value As String)
                mape_pat = value
            End Set
        End Property

        Public Property ape_mat() As String
            Get
                Return mape_mat
            End Get
            Set(ByVal value As String)
                mape_mat = value
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

        Public Property usuario() As String
            Get
                Return musuario
            End Get
            Set(ByVal value As String)
                musuario = value
            End Set
        End Property
        Public Property clave() As String
            Get
                Return mclave
            End Get
            Set(ByVal value As String)
                mclave = value
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
        Public Property fecha_reg() As String
            Get
                Return mfecha_reg
            End Get
            Set(ByVal value As String)
                mfecha_reg = value
            End Set
        End Property
        Public Property codigo_cat() As Long
            Get
                Return mcodigo_cat
            End Get
            Set(ByVal value As Long)
                mcodigo_cat = value
            End Set
        End Property
        Public Property codigo_dis() As Long
            Get
                Return mcodigo_dis
            End Get
            Set(ByVal value As Long)
                mcodigo_dis = value
            End Set
        End Property
    End Class
End Namespace
