Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class movimiento_bancario
        Private pCodigo As Long = -1
        Private pTipo As String
        Private pCodigo_Documento As Integer
        Private pNumero As String
        Private Pfecha As String
        Private pCodigo_CtaCte As Integer
        Private pCodigo_Tip As Integer
        Private pCodigo_Persona As Long
        Private pMoneda As String
        Private pImporte As Single
        Private pCambio As Single
        Private pObservacion As String
        Private pCodigo_Usuario As String
        Private pUsuario As String
        Private Pcaja As String
        Private pEstado As Boolean
        Private pCerrado As Boolean
        Private Pcodigo_ref As Long
        Private pReferencia_Exterior As String
        Private pCodigo1_RefExt As Long
        Private pCodigo2_RefExt As Long
        Private pImporte_Pago As Single
        Private pVuelto As Single
        Private pCodigo_alm As Integer
        Private pNroCuenta As String
        Private pImporte_NoGrabado As Single
        Private pValor_igv As Single
        Private pImporte_IGV As Single
        Private pImporte_rh As Single
        Private pValor_Renta As Single
        Private pImporte_Renta As Single
        Private pImporte_Isc As Single
        Private pImporte_Otros_Imp As Single
        Private pCancela As String
        Private pFecha_Registro As String
        Private pCentro_Costo As String
        Private pAnio As Integer
        Private pSobra As Single

        'Get y Set

        Public Property Codigo() As Long
            Get
                Return pCodigo
            End Get
            Set(ByVal value As Long)
                pCodigo = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return pTipo
            End Get
            Set(ByVal value As String)
                pTipo = value
            End Set
        End Property

        Public Property Codigo_Documento() As Integer
            Get
                Return pCodigo_Documento
            End Get
            Set(ByVal value As Integer)
                pCodigo_Documento = value
            End Set
        End Property

        Public Property Numero() As String
            Get
                Return pNumero
            End Get
            Set(ByVal value As String)
                pNumero = value
            End Set
        End Property

        Public Property fecha() As String
            Get
                Return Pfecha
            End Get
            Set(ByVal value As String)
                Pfecha = value
            End Set
        End Property

        Public Property Codigo_CtaCte() As Integer
            Get
                Return pCodigo_CtaCte
            End Get
            Set(ByVal value As Integer)
                pCodigo_CtaCte = value
            End Set
        End Property

        Public Property Codigo_Tip() As Integer
            Get
                Return pCodigo_Tip
            End Get
            Set(ByVal value As Integer)
                pCodigo_Tip = value
            End Set
        End Property

        Public Property Codigo_Persona() As Long
            Get
                Return pCodigo_Persona
            End Get
            Set(ByVal value As Long)
                pCodigo_Persona = value
            End Set
        End Property

        Public Property Moneda() As String
            Get
                Return pMoneda
            End Get
            Set(ByVal value As String)
                pMoneda = value
            End Set
        End Property

        Public Property Importe() As Single
            Get
                Return pImporte
            End Get
            Set(ByVal value As Single)
                pImporte = value
            End Set
        End Property

        Public Property Cambio() As Single
            Get
                Return pCambio
            End Get
            Set(ByVal value As Single)
                pCambio = value
            End Set
        End Property

        Public Property Observacion() As String
            Get
                Return pObservacion
            End Get
            Set(ByVal value As String)
                pObservacion = value
            End Set
        End Property

        Public Property Codigo_Usuario() As String
            Get
                Return pCodigo_Usuario
            End Get
            Set(ByVal value As String)
                pCodigo_Usuario = value
            End Set
        End Property

        Public Property Usuario() As String
            Get
                Return pUsuario
            End Get
            Set(ByVal value As String)
                pUsuario = value
            End Set
        End Property

        Public Property caja() As String
            Get
                Return Pcaja
            End Get
            Set(ByVal value As String)
                Pcaja = value
            End Set
        End Property

        Public Property Estado() As Boolean
            Get
                Return pEstado
            End Get
            Set(ByVal value As Boolean)
                pEstado = value
            End Set
        End Property

        Public Property Cerrado() As Boolean
            Get
                Return pCerrado
            End Get
            Set(ByVal value As Boolean)
                pCerrado = value
            End Set
        End Property

        Public Property codigo_ref() As Long
            Get
                Return Pcodigo_ref
            End Get
            Set(ByVal value As Long)
                Pcodigo_ref = value
            End Set
        End Property

        Public Property Referencia_Exterior() As String
            Get
                Return pReferencia_Exterior
            End Get
            Set(ByVal value As String)
                pReferencia_Exterior = value
            End Set
        End Property

        Public Property Codigo1_RefExt() As Long
            Get
                Return pCodigo1_RefExt
            End Get
            Set(ByVal value As Long)
                pCodigo1_RefExt = value
            End Set
        End Property

        Public Property Codigo2_RefExt() As Long
            Get
                Return pCodigo2_RefExt
            End Get
            Set(ByVal value As Long)
                pCodigo2_RefExt = value
            End Set
        End Property

        Public Property Importe_Pago() As Single
            Get
                Return pImporte_Pago
            End Get
            Set(ByVal value As Single)
                pImporte_Pago = value
            End Set
        End Property

        Public Property Vuelto() As Single
            Get
                Return pVuelto
            End Get
            Set(ByVal value As Single)
                pVuelto = value
            End Set
        End Property

        Public Property Sobra() As Single
            Get
                Return pSobra
            End Get
            Set(ByVal value As Single)
                pSobra = value
            End Set
        End Property

        Public Property Codigo_alm() As Integer
            Get
                Return pCodigo_alm
            End Get
            Set(ByVal value As Integer)
                pCodigo_alm = value
            End Set
        End Property

        Public Property NroCuenta() As String
            Get
                Return pNroCuenta
            End Get
            Set(ByVal value As String)
                pNroCuenta = value
            End Set
        End Property

        Public Property Importe_NoGrabado() As Single
            Get
                Return pImporte_NoGrabado
            End Get
            Set(ByVal value As Single)
                pImporte_NoGrabado = value
            End Set
        End Property

        Public Property Valor_igv() As Single
            Get
                Return pValor_igv
            End Get
            Set(ByVal value As Single)
                pValor_igv = value
            End Set
        End Property

        Public Property Importe_IGV() As Single
            Get
                Return pImporte_IGV
            End Get
            Set(ByVal value As Single)
                pImporte_IGV = value
            End Set
        End Property

        Public Property Importe_rh() As Single
            Get
                Return pImporte_rh
            End Get
            Set(ByVal value As Single)
                pImporte_rh = value
            End Set
        End Property

        Public Property Valor_Renta() As Single
            Get
                Return pValor_Renta
            End Get
            Set(ByVal value As Single)
                pValor_Renta = value
            End Set
        End Property

        Public Property Importe_Renta() As Single
            Get
                Return pImporte_Renta
            End Get
            Set(ByVal value As Single)
                pImporte_Renta = value
            End Set
        End Property

        Public Property Importe_Isc() As Single
            Get
                Return pImporte_Isc
            End Get
            Set(ByVal value As Single)
                pImporte_Isc = value
            End Set
        End Property

        Public Property Importe_Otros_Imp() As Single
            Get
                Return pImporte_Otros_Imp
            End Get
            Set(ByVal value As Single)
                pImporte_Otros_Imp = value
            End Set
        End Property

        Public Property Cancela() As String
            Get
                Return pCancela
            End Get
            Set(ByVal value As String)
                pCancela = value
            End Set
        End Property

        Public Property Fecha_Registro() As String
            Get
                Return pFecha_Registro
            End Get
            Set(ByVal value As String)
                pFecha_Registro = value
            End Set
        End Property

        Public Property Centro_Costo() As String
            Get
                Return pCentro_Costo
            End Get
            Set(ByVal value As String)
                pCentro_Costo = value
            End Set
        End Property

        Public Property Anio() As Integer
            Get
                Return pAnio
            End Get
            Set(ByVal value As Integer)
                pAnio = value
            End Set
        End Property

    End Class
End Namespace

