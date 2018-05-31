Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class reportes_salidasManager
        Public Shared Function Detalle_Documento(ByVal vCodigo As Long) As DataTable
            Return Reportes_SalidasBD.Detalle_Documento(vCodigo)
        End Function
    End Class
End Namespace

