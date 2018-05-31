Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Namespace BO

    Public Class detalle_lote_gasto

        Private mlotegastosdetalleid As Long = -1
        Private mlotegastosid As Long
        Private mdocumentoid As Integer
        Private mserie As String
        Private mnumero As String
        Private mpersonaid As Long
        Private memision As String
        Private mvencimiento As String
        Private mformapago As Integer
        Private mglosa As String
        Private mtipo_importe As Integer
        Private mafecto As Single
        Private minafecto As Single
        Private mimporte_igv As Single
        Private mimporte_isc As Single
        Private mimporte_renta As Single
        Private motros As Single
        Private mtotal As Single
        Private mvalor_igv As Single
        Private mvalor_isc As Single
        Private mvalor_renta As Single
        Private mcomision As Single
        Private mmoneda As String
        Private mcambio As Single
        Private msigno As String
        Private mcodigo_ref As Long
        Private musuario As String
        Private mcaja As String
        Private maduanaid As String
        Private manio_dua As String
        Private mnumero_dua As String
        Private mestado As Boolean
        Private mpercepcion As Boolean
        Private mdetraccion As Boolean
        Private mtipo As String
        'Datos extras        
        Private mTipo_per As String
        Private mRUC As String
        Private mDNI As String
        Private mApe_Pat As String
        Private mApe_Mat As String
        Private mNombre As String
        Private mRaz_Soc As String
        Private mDireccion_Persona As String

        Public Property lotegastosdetalleid() As Long
            Get
                Return mlotegastosdetalleid
            End Get
            Set(ByVal value As Long)
                mlotegastosdetalleid = value
            End Set
        End Property

        Public Property lotegastosid() As Long
            Get
                Return mlotegastosid
            End Get
            Set(ByVal value As Long)
                mlotegastosid = value
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

        Public Property serie() As String
            Get
                Return mserie
            End Get
            Set(ByVal value As String)
                mserie = value
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

        Public Property personaid() As Long
            Get
                Return mpersonaid
            End Get
            Set(ByVal value As Long)
                mpersonaid = value
            End Set
        End Property

        Public Property emision() As String
            Get
                Return memision
            End Get
            Set(ByVal value As String)
                memision = value
            End Set
        End Property

        Public Property vencimiento() As String
            Get
                Return mvencimiento
            End Get
            Set(ByVal value As String)
                mvencimiento = value
            End Set
        End Property

        Public Property formapago() As Integer
            Get
                Return mformapago
            End Get
            Set(ByVal value As Integer)
                mformapago = value
            End Set
        End Property

        Public Property glosa() As String
            Get
                Return mglosa
            End Get
            Set(ByVal value As String)
                mglosa = value
            End Set
        End Property

        Public Property tipo_importe() As Integer
            Get
                Return mtipo_importe
            End Get
            Set(ByVal value As Integer)
                mtipo_importe = value
            End Set
        End Property

        Public Property afecto() As Single
            Get
                Return mafecto
            End Get
            Set(ByVal value As Single)
                mafecto = value
            End Set
        End Property

        Public Property inafecto() As Single
            Get
                Return minafecto
            End Get
            Set(ByVal value As Single)
                minafecto = value
            End Set
        End Property

        Public Property importe_igv() As Single
            Get
                Return mimporte_igv
            End Get
            Set(ByVal value As Single)
                mimporte_igv = value
            End Set
        End Property

        Public Property importe_isc() As Single
            Get
                Return mimporte_isc
            End Get
            Set(ByVal value As Single)
                mimporte_isc = value
            End Set
        End Property

        Public Property importe_renta() As Single
            Get
                Return mimporte_renta
            End Get
            Set(ByVal value As Single)
                mimporte_renta = value
            End Set
        End Property

        Public Property otros() As Single
            Get
                Return motros
            End Get
            Set(ByVal value As Single)
                motros = value
            End Set
        End Property

        Public Property total() As Single
            Get
                Return mtotal
            End Get
            Set(ByVal value As Single)
                mtotal = value
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

        Public Property valor_isc() As Single
            Get
                Return mvalor_isc
            End Get
            Set(ByVal value As Single)
                mvalor_isc = value
            End Set
        End Property

        Public Property valor_renta() As Single
            Get
                Return mvalor_renta
            End Get
            Set(ByVal value As Single)
                mvalor_renta = value
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

        Public Property signo() As String
            Get
                Return msigno
            End Get
            Set(ByVal value As String)
                msigno = value
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

        Public Property aduanaid() As String
            Get
                Return maduanaid
            End Get
            Set(ByVal value As String)
                maduanaid = value
            End Set
        End Property

        Public Property anio_dua() As String
            Get
                Return manio_dua
            End Get
            Set(ByVal value As String)
                manio_dua = value
            End Set
        End Property

        Public Property numero_dua() As String
            Get
                Return mnumero_dua
            End Get
            Set(ByVal value As String)
                mnumero_dua = value
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

        Public Property percepcion() As Boolean
            Get
                Return mpercepcion
            End Get
            Set(ByVal value As Boolean)
                mpercepcion = value
            End Set
        End Property

        Public Property detraccion() As Boolean
            Get
                Return mdetraccion
            End Get
            Set(ByVal value As Boolean)
                mdetraccion = value
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

        Public Property Direccion_Persona() As String
            Get
                Return mDireccion_Persona
            End Get
            Set(ByVal value As String)
                mDireccion_Persona = value
            End Set
        End Property

    End Class
End Namespace
