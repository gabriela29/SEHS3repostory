Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class Reportes_VariosManager
        Public Shared Function Listado_Documentos_Emitidos(ByVal vCodigo_Uni As Integer, ByVal vCodigo_Alm As Integer, ByVal vdocumento As Integer, ByVal vpersona As Long, _
                                                            ByVal vdesde As String, ByVal vhasta As String, ByVal vIM As Boolean, vConsig As Boolean, _
                                                            ByVal vVta As Boolean, ByVal vSM As Boolean) As DataTable
            Return reportes_variosBD.Listado_Documentos_Emitidos(vCodigo_Uni, vCodigo_Alm, vdocumento, vpersona, _
                                                                    vdesde, vhasta, vIM, vConsig, vVta, vSM)
        End Function
    End Class
End Namespace


