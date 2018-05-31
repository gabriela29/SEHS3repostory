Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO
    Public Class serie
        Private mcodigo As Long = -1

        Private mcodigo_emp As Long
        Private mserie As String
        Private mcodigo_doc As Long
        Private mcorrelativo As Long
        Private mestado As Boolean
        Public Property codigo() As Long
            Get
                Return mcodigo
            End Get
            Set(ByVal value As Long)
                mcodigo = value
            End Set
        End Property
        Public Property codigo_emp() As Long
            Get
                Return mcodigo_emp
            End Get
            Set(ByVal value As Long)
                mcodigo_emp = value
            End Set
        End Property
        Public Property serie() As String
            Get
                Return mserie
            End Get
            Set(ByVal value As String)
                mserie = value
            End Set
        End Property
        Public Property codigo_doc() As Long
            Get
                Return mcodigo_doc
            End Get
            Set(ByVal value As Long)
                mcodigo_doc = value
            End Set
        End Property
        Public Property correlativo() As Long
            Get
                Return mcorrelativo
            End Get
            Set(ByVal value As Long)
                mcorrelativo = value
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
