Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class venta_guia
        Private mventaguiaid As Long
        Private mnumero As String
        Private mventaid As Long
        Private malmacenid As Integer
        Private mclienteid As Long
        Private mtransporteid As Long
        Private mchoferid As Long

        Private mfecha_emi As String
        Private mfecha_tras As String
        Private mhora_tras As String
        Private mdesde As String
        Private mhasta As String

        Private mmarca As String
        Private mplaca As String

        Private mlicencia As String
        Private mconstancia As String
        Private mestado As Boolean

        Private musuario As String
        Private mcaja As String
        Private mimpresiones As Integer
        Private mreservado As Boolean
        Private mdescontar_stock As Boolean
        Private mcerrado As Boolean

        Private vserie As Integer
        Private vCorrelativo As Long



        Public Property ventaguiaid() As Long
            Get
                Return mventaguiaid
            End Get
            Set(ByVal value As Long)
                mventaguiaid = value
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

        Public Property ventaid() As Long
            Get
                Return mventaid
            End Get
            Set(ByVal value As Long)
                mventaid = value
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

        Public Property clienteid() As Long
            Get
                Return mclienteid
            End Get
            Set(ByVal value As Long)
                mclienteid = value
            End Set
        End Property

        Public Property transporteid() As Long
            Get
                Return mtransporteid
            End Get
            Set(ByVal value As Long)
                mtransporteid = value
            End Set
        End Property

        Public Property choferid() As Long
            Get
                Return mchoferid
            End Get
            Set(ByVal value As Long)
                mchoferid = value
            End Set
        End Property

        Public Property fecha_emi() As String
            Get
                Return mfecha_emi
            End Get
            Set(ByVal value As String)
                mfecha_emi = value
            End Set
        End Property

        Public Property fecha_tras() As String
            Get
                Return mfecha_tras
            End Get
            Set(ByVal value As String)
                mfecha_tras = value
            End Set
        End Property

        Public Property hora_tras() As String
            Get
                Return mhora_tras
            End Get
            Set(ByVal value As String)
                mhora_tras = value
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

        Public Property marca() As String
            Get
                Return mmarca
            End Get
            Set(ByVal value As String)
                mmarca = value
            End Set
        End Property

        Public Property placa() As String
            Get
                Return mplaca
            End Get
            Set(ByVal value As String)
                mplaca = value
            End Set
        End Property

        Public Property licencia() As String
            Get
                Return mlicencia
            End Get
            Set(ByVal value As String)
                mlicencia = value
            End Set
        End Property

        Public Property constancia() As String
            Get
                Return mconstancia
            End Get
            Set(ByVal value As String)
                mconstancia = value
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

        Public Property usuario() As String
            Get
                Return musuario
            End Get
            Set(ByVal value As String)
                musuario = value
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

        Public Property impresiones() As Integer
            Get
                Return mimpresiones
            End Get
            Set(ByVal value As Integer)
                mimpresiones = value
            End Set
        End Property

        Public Property reservado() As Boolean
            Get
                Return mreservado
            End Get
            Set(ByVal value As Boolean)
                mreservado = value
            End Set
        End Property

        Public Property descontar_stock() As Boolean
            Get
                Return mdescontar_stock
            End Get
            Set(ByVal value As Boolean)
                mdescontar_stock = value
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

        Public Property serie() As Integer
            Get
                Return vserie
            End Get
            Set(ByVal value As Integer)
                vserie = value
            End Set
        End Property

        Public Property correlativo() As Long
            Get
                Return vCorrelativo
            End Get
            Set(ByVal value As Long)
                vCorrelativo = value
            End Set
        End Property
    End Class
End Namespace
