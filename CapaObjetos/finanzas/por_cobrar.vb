Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Namespace BO
    Public Class por_cobrar
        Private pCodigo As Long = -1
        Private pCodigo_Documento As Integer
        Private pNumero As String
        Private Pcondicion As String
        Private pLetra As String
        Private pRenovacion As Integer
        Private pCodigo_Persona As Long
        Private Pfecha As String
        Private pVencimiento As String
        Private pMoneda As String
        Private pImporte As Single
        Private pSaldo As Single
        Private pCambio As Single
        Private pSigno As String
        Private pObservacion As String
        Private pReferencia_Exterior As String
        Private pCodigo1_RefExt As Long
        Private pCodigo2_RefExt As Long
        Private pUsuarioId As Long
        Private Pcaja As String
        Private pCerrado As Boolean
        Private pEstado As Boolean
        Private pCodigo_Almacen As Integer
        Private pFecha_Registro As Date
        Private pIncluir_Registro As Boolean
        Private pNroCuenta As String
        Private pC_Costo As Long

        Public Property Codigo() As Long
            Get
                Return pCodigo
            End Get
            Set(ByVal value As Long)
                pCodigo = value
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

        Public Property condicion() As String
            Get
                Return Pcondicion
            End Get
            Set(ByVal value As String)
                Pcondicion = value
            End Set
        End Property

        Public Property Letra() As String
            Get
                Return pLetra
            End Get
            Set(ByVal value As String)
                pLetra = value
            End Set
        End Property

        Public Property Renovacion() As Integer
            Get
                Return pRenovacion
            End Get
            Set(ByVal value As Integer)
                pRenovacion = value
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

        Public Property fecha() As String
            Get
                Return Pfecha
            End Get
            Set(ByVal value As String)
                Pfecha = value
            End Set
        End Property

        Public Property Vencimiento() As String
            Get
                Return pVencimiento
            End Get
            Set(ByVal value As String)
                pVencimiento = value
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

        Public Property Saldo() As Single
            Get
                Return pSaldo
            End Get
            Set(ByVal value As Single)
                pSaldo = value
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

        Public Property Signo() As String
            Get
                Return pSigno
            End Get
            Set(ByVal value As String)
                pSigno = value
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

        Public Property UsuarioId() As Long
            Get
                Return pUsuarioId
            End Get
            Set(ByVal value As Long)
                pUsuarioId = value
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

        Public Property Cerrado() As Boolean
            Get
                Return pCerrado
            End Get
            Set(ByVal value As Boolean)
                pCerrado = value
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

        Public Property Codigo_Almacen() As Integer
            Get
                Return pCodigo_Almacen
            End Get
            Set(ByVal value As Integer)
                pCodigo_Almacen = value
            End Set
        End Property

        Public Property Fecha_Registro() As Date
            Get
                Return pFecha_Registro
            End Get
            Set(ByVal value As Date)
                pFecha_Registro = value
            End Set
        End Property

        Public Property Incluir_Registro() As Boolean
            Get
                Return pIncluir_Registro
            End Get
            Set(ByVal value As Boolean)
                pIncluir_Registro = value
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

        Public Property C_Costo() As Long
            Get
                Return pC_Costo
            End Get
            Set(ByVal value As Long)
                pC_Costo = value
            End Set
        End Property

    End Class
End Namespace

