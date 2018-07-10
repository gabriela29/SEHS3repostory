
Imports System
Imports System.ComponentModel
Imports System.Diagnostics




Public Class cuentaCorriente

    Private mctacteid As Long = -1
    Private mbancoid As Integer
    Private mempresaid As Integer
    Private mnumero As String
    Private mabreviatura As String
    Private msucursal As String
    Private mreferencia As String
    Private mmoneda As String
    Private mempresa As Boolean


    Public Property ctacteid() As Long
        Get
            Return mctacteid
        End Get
        Set(ByVal value As Long)
            mctacteid = value
        End Set
    End Property


    Public Property bancoid() As Integer
        Get
            Return mbancoid
        End Get
        Set(ByVal value As Integer)
            mbancoid = value
        End Set
    End Property

    Public Property numero() As String
        Get
            Return mnumero
        End Get
        Set(ByVal value As String)
            mnumero = value
        End Set
    End Property

    Public Property empresaid() As Integer
        Get
            Return mempresaid
        End Get
        Set(ByVal value As Integer)
            mempresaid = value
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

    Public Property sucursal() As String
        Get
            Return msucursal
        End Get
        Set(ByVal value As String)
            msucursal = value
        End Set
    End Property

    Public Property referencia() As String
        Get
            Return mreferencia
        End Get
        Set(ByVal value As String)
            mreferencia = value
        End Set
    End Property

    Public Property moneda() As String
        Get
            Return mmoneda
        End Get
        Set(ByVal value As String)
            mmoneda = value
        End Set
    End Property

    Public Property empresa() As Boolean
        Get
            Return mempresa
        End Get
        Set(ByVal value As Boolean)
            mempresa = value
        End Set
    End Property
End Class
