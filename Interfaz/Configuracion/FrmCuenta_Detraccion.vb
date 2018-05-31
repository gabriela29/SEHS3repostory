
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmCuenta_Detraccion
    Public Function Listado_Condicion_Detalles() As Boolean
        Dim objetos As New DataTable
        Dim vModulo As Integer = 0, vCodigo_Mov As Integer = 0
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                vCodigo_Mov = Integer.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            End If
        End If

        If Not cboAlmacen.Text = "" Then
            vModulo = cboAlmacen.Value
        End If

        Try

            objetos = det_mov_mercaderiaManager.GetList(vCodigo_Mov, vModulo)
            cboAlmacen.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub llenar_combos()
        Try
            With cboAlmacen
                .DataSource = Nothing
                .DataSource = modulo_sistemaManager.GetList()
                .DataBind()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4

            End With
            With dgvListado
                .DataSource = Nothing
                .DataSource = tipo_mov_mercaderiaManager.GetList()
            End With
            Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
            Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DSIAM")
        End Try

    End Sub

    Private Sub FrmCuenta_Detraccion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call llenar_combos()
    End Sub
End Class