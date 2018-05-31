Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class venta
        Private mventaid As Long = -1
        Private malmacenid As Integer
        Private mdocumentoid As Integer
        Private mclienteid As Long
        Private mvendedorid As Long
        Private mfecha As String
        Private mnumero As String
        Private mnombre_cli As String
        Private mcondicion As String
        Private mvta_bruta As Single
        Private mdescuento As Single
        Private migv As Single
        Private mvta_total As Single
        Private mimporte_grabado As Single
        Private mimporte_exonerado As Single
        Private mredondeo As Single
        Private mvalor_igv As Single
        Private mincluye_igv As Boolean
        Private mmoneda As String
        Private mcambio As Single
        Private mcomision As Single
        Private mimpresiones As Integer
        Private musuarioid As Long
        Private mcaja As String
        Private msigno As String
        Private mcentro_costos As String
        Private mopcion As Integer
        Private mreferencia As String
        Private mcodigo_ref As Long
        Private mcodigo_ref1 As Long
        Private mcodigo_ref2 As Long
        Private mobservacion As String
        Private mdescontar_stock As Boolean
        Private mcerrado As Boolean
        Private mestado As Boolean


        Private mVencimiento As String

        Private vserie As Integer
        Private vCorrelativo As Long

        Private mTipo_per As String
        Private mRUC As String
        Private mDNI As String
        Private mApe_Pat As String
        Private mApe_Mat As String
        Private mNombre As String
        Private mRaz_Soc As String
        Private mDireccion_Cliente As String
        Private mDireccionId As Long

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

        Public Property documentoid() As Integer
            Get
                Return mdocumentoid
            End Get
            Set(ByVal value As Integer)
                mdocumentoid = value
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

        Public Property vendedorid() As Long
            Get
                Return mvendedorid
            End Get
            Set(ByVal value As Long)
                mvendedorid = value
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

        Public Property numero() As String
            Get
                Return mnumero
            End Get
            Set(ByVal value As String)
                mnumero = value
            End Set
        End Property

        Public Property nombre_cli() As String
            Get
                Return mnombre_cli
            End Get
            Set(ByVal value As String)
                mnombre_cli = value
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

        Public Property cambio() As Single
            Get
                Return mcambio
            End Get
            Set(ByVal value As Single)
                mcambio = value
            End Set
        End Property

        Public Property comision() As Single
            Get
                Return mcomision
            End Get
            Set(ByVal value As Single)
                mcomision = value
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

        Public Property centro_costos() As String
            Get
                Return mcentro_costos
            End Get
            Set(ByVal value As String)
                mcentro_costos = value
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

        Public Property codigo_ref() As Long
            Get
                Return mcodigo_ref
            End Get
            Set(ByVal value As Long)
                mcodigo_ref = value
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

        Public Property observacion() As String
            Get
                Return mobservacion
            End Get
            Set(ByVal value As String)
                mobservacion = value
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

        Public Property Vencimiento() As String
            Get
                Return mVencimiento
            End Get
            Set(ByVal value As String)
                mVencimiento = value
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

        Public Property Correlativo() As Long
            Get
                Return vCorrelativo
            End Get
            Set(ByVal value As Long)
                vCorrelativo = value
            End Set
        End Property

        Public Property Tipo_per() As String
            Get
                Return mTipo_per
            End Get
            Set(ByVal value As String)
                mTipo_per = value
            End Set
        End Property

        Public Property RUC() As String
            Get
                Return mRUC
            End Get
            Set(ByVal value As String)
                mRUC = value
            End Set
        End Property

        Public Property DNI() As String
            Get
                Return mDNI
            End Get
            Set(ByVal value As String)
                mDNI = value
            End Set
        End Property

        Public Property Ape_Pat() As String
            Get
                Return mApe_Pat
            End Get
            Set(ByVal value As String)
                mApe_Pat = value
            End Set
        End Property

        Public Property Ape_Mat() As String
            Get
                Return mApe_Mat
            End Get
            Set(ByVal value As String)
                mApe_Mat = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return mNombre
            End Get
            Set(ByVal value As String)
                mNombre = value
            End Set
        End Property

        Public Property Raz_Soc() As String
            Get
                Return mRaz_Soc
            End Get
            Set(ByVal value As String)
                mRaz_Soc = value
            End Set
        End Property

        Public Property Direccion_Cliente() As String
            Get
                Return mDireccion_Cliente
            End Get
            Set(ByVal value As String)
                mDireccion_Cliente = value
            End Set
        End Property

        Public Property DireccionId() As Long
            Get
                Return mDireccionId
            End Get
            Set(ByVal value As Long)
                mDireccionId = value
            End Set
        End Property

    End Class
End Namespace
