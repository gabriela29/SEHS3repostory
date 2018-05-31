Imports System
Imports System.IO

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System.Drawing.Printing

Public Class FrmVisor_Compras
    Public Function RptIngresos_Mercaderia_Detalle(ByVal dtTmp As DataTable, ByVal vEmpresa As String, _
                                                    ByVal vLocal As String, ByVal vDetalle As String) As Boolean
        Try
            Dim rpt As New rptCompras_Detalladas

            rpt.SetDataSource(dtTmp)

            rpt.SetParameterValue(0, vEmpresa)
            rpt.SetParameterValue(1, vLocal)
            rpt.SetParameterValue(2, vDetalle)

            cvCompras.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "VERIFICAR")
        End Try

    End Function

    Private Sub FrmVisor_Compras_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
    End Sub
End Class