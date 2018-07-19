Imports System
Imports System.ComponentModel
Imports System.Diagnostics

Public Class empresa
        Private mempresaid As Long = -1
        Private mnombre As String
        Private mruc As String
        Private mdireccion As String
        Private murl As String


        Public Property empresaid() As Long
            Get
                Return mempresaid
            End Get
            Set(ByVal value As Long)
                mempresaid = value
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
        Public Property ruc() As String
            Get
                Return mruc
            End Get
            Set(ByVal value As String)
                mruc = value
            End Set
        End Property

        Public Property direccion() As String
            Get
                Return mdireccion
            End Get
            Set(ByVal value As String)
                mdireccion = value
            End Set
        End Property

        Public Property url() As String
            Get
                Return murl
            End Get
            Set(ByVal value As String)
                murl = value
            End Set
        End Property


    End Class




