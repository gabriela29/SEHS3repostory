Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class ingreso_mercaderia
        Enum vTipos_Opcion
            opcIngreso = 0
            opcDevolucion = 1
            opcDescuento = 2
        End Enum

        Private mingmerid As Long = -1
        Private mtipomovmerid As Integer
        Private mdocumentoid As Integer
        Private malmacenid As Integer
        Private mproveedorid As Long
        Private mnumero As String
        Private mfecha_emision As String
        Private mfecha_recepcion As String
        Private mvta_bruta As Single
        Private mdescuento As Single
        Private migv As Single
        Private mvta_total As Single
        Private mpercepcion As Single
        Private mimporte_grabado As Single
        Private mimporte_exonerado As Single
        Private mredondeo As Single
        Private mvalor_igv As Single
        Private mincluye_igv As Boolean
        Private mmoneda As String
        Private mcondicion As String
        Private mcambio As Single
        Private mobservacion As String
        Private musuarioid As Long
        Private mcaja As String
        Private msigno As String
        Private mopcion As Integer
        Private mreferencia As String
        Private mcodigo_ref1 As Long
        Private mcodigo_ref2 As Long
        Private mdescontar_stock As Boolean
        Private mcerrado As Boolean
        Private mestado As Boolean


        Private mDNI As String
        Private mRUC As String
        Private mApe_Pat As String
        Private mApe_Mat As String
        Private mNombre As String
        Private mRaz_Soc As String
        Private mDireccion As String
        Private mTipo_per As String

        Public Property ingmerid() As Long
            Get
                Return mingmerid
            End Get
            Set(ByVal value As Long)
                mingmerid = value
            End Set
        End Property

        Public Property tipomovmerid() As Integer
            Get
                Return mtipomovmerid
            End Get
            Set(ByVal value As Integer)
                mtipomovmerid = value
            End Set
        End Property

        Public Property documentoid() As Integer
            Get
                Return mdocumentoid
            End Get
            Set(ByVal value As Integer)
                mdocumentoid = value
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

        Public Property proveedorid() As Long
            Get
                Return mproveedorid
            End Get
            Set(ByVal value As Long)
                mproveedorid = value
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

        Public Property fecha_emision() As String
            Get
                Return mfecha_emision
            End Get
            Set(ByVal value As String)
                mfecha_emision = value
            End Set
        End Property

        Public Property fecha_recepcion() As String
            Get
                Return mfecha_recepcion
            End Get
            Set(ByVal value As String)
                mfecha_recepcion = value
            End Set
        End Property

        Public Property vta_bruta() As Single
            Get
                Return mvta_bruta
            End Get
            Set(ByVal value As Single)
                mvta_bruta = value
            End Set
        End Property

        Public Property descuento() As Single
            Get
                Return mdescuento
            End Get
            Set(ByVal value As Single)
                mdescuento = value
            End Set
        End Property

        Public Property igv() As Single
            Get
                Return migv
            End Get
            Set(ByVal value As Single)
                migv = value
            End Set
        End Property

        Public Property vta_total() As Single
            Get
                Return mvta_total
            End Get
            Set(ByVal value As Single)
                mvta_total = value
            End Set
        End Property

        Public Property percepcion() As Single
            Get
                Return mpercepcion
            End Get
            Set(ByVal value As Single)
                mpercepcion = value
            End Set
        End Property

        Public Property importe_grabado() As Single
            Get
                Return mimporte_grabado
            End Get
            Set(ByVal value As Single)
                mimporte_grabado = value
            End Set
        End Property

        Public Property importe_exonerado() As Single
            Get
                Return mimporte_exonerado
            End Get
            Set(ByVal value As Single)
                mimporte_exonerado = value
            End Set
        End Property

        Public Property redondeo() As Single
            Get
                Return mredondeo
            End Get
            Set(ByVal value As Single)
                mredondeo = value
            End Set
        End Property

        Public Property valor_igv() As Single
            Get
                Return mvalor_igv
            End Get
            Set(ByVal value As Single)
                mvalor_igv = value
            End Set
        End Property

        Public Property incluye_igv() As Boolean
            Get
                Return mincluye_igv
            End Get
            Set(ByVal value As Boolean)
                mincluye_igv = value
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

        Public Property condicion() As String
            Get
                Return mcondicion
            End Get
            Set(ByVal value As String)
                mcondicion = value
            End Set
        End Property

        Public Property cambio() As Single
            Get
                Return mcambio
            End Get
            Set(ByVal value As Single)
                mcambio = value
            End Set
        End Property

        Public Property observacion() As String
            Get
                Return mobservacion
            End Get
            Set(ByVal value As String)
                mobservacion = value
            End Set
        End Property

        Public Property usuarioid() As Long
            Get
                Return musuarioid
            End Get
            Set(ByVal value As Long)
                musuarioid = value
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

        Public Property signo() As String
            Get
                Return msigno
            End Get
            Set(ByVal value As String)
                msigno = value
            End Set
        End Property

        Public Property opcion() As Integer
            Get
                Return mopcion
            End Get
            Set(ByVal value As Integer)
                mopcion = value
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

        Public Property codigo_ref1() As Long
            Get
                Return mcodigo_ref1
            End Get
            Set(ByVal value As Long)
                mcodigo_ref1 = value
            End Set
        End Property

        Public Property codigo_ref2() As Long
            Get
                Return mcodigo_ref2
            End Get
            Set(ByVal value As Long)
                mcodigo_ref2 = value
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

        Public Property estado() As Boolean
            Get
                Return mestado
            End Get
            Set(ByVal value As Boolean)
                mestado = value
            End Set
        End Property

        Public Property gDNI() As String
            Get
                Return mDNI
            End Get
            Set(ByVal value As String)
                mDNI = value
            End Set
        End Property

        Public Property gRUC() As String
            Get
                Return mRUC
            End Get
            Set(ByVal value As String)
                mRUC = value
            End Set
        End Property

        Public Property gApe_Pat() As String
            Get
                Return mApe_Pat
            End Get
            Set(ByVal value As String)
                mApe_Pat = value
            End Set
        End Property

        Public Property gApe_Mat() As String
            Get
                Return mApe_Mat
            End Get
            Set(ByVal value As String)
                mApe_Mat = value
            End Set
        End Property

        Public Property gNombre() As String
            Get
                Return mNombre
            End Get
            Set(ByVal value As String)
                mNombre = value
            End Set
        End Property

        Public Property gRaz_Soc() As String
            Get
                Return mRaz_Soc
            End Get
            Set(ByVal value As String)
                mRaz_Soc = value
            End Set
        End Property

        Public Property gDireccion() As String
            Get
                Return mDireccion
            End Get
            Set(ByVal value As String)
                mDireccion = value
            End Set
        End Property

        Public Property gTipo_per() As String
            Get
                Return mTipo_per
            End Get
            Set(ByVal value As String)
                mTipo_per = value
            End Set
        End Property
    End Class
End Namespace


