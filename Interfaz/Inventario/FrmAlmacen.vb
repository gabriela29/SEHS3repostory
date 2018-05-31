Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmAlmacen
    Public dtAlmacen As DataTable

    Public Function ListarCondicion() As Boolean
        Dim objetos As New DataTable
        Try
            dtAlmacen = almacenManager.GetList(0, 0)
            dgvListado.DataSource = dtAlmacen
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
                'dgvListado.Focus()
                'Call Listado_Subgrupo()
            End If
            lbl.Text = dgvListado.Rows.Count & " Registros Mostrados"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function



    Private Sub FrmAlmacen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call LibreriasFormularios.formatear_grid(dgvListado)
        Call ListarCondicion()
    End Sub
End Class