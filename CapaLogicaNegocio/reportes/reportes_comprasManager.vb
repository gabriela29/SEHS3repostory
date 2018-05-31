Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class Reportes_ComprasManager
        Public Shared Function Detalle_Documento(ByVal vCodigo As Long) As DataTable
            Return Reportes_ComprasBD.Detalle_Documento(vCodigo)
        End Function
    End Class
End Namespace

