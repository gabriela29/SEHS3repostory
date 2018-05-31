

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConf_Doc_Mov    

    Public Function Listado_Condicion_Detalles() As Boolean
        Dim objetos As New DataTable
        Dim vModulo As Integer = 0, vCodigo_Mov As Integer = 0
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                vCodigo_Mov = Integer.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            End If
        End If

        If Not cboModulo.Text = "" Then
            vModulo = cboModulo.Value
        End If

        Try

            objetos = det_mov_mercaderiaManager.GetList(vCodigo_Mov, vModulo)
            dgvDetalle.DataSource = objetos
            'dgvDetalle.DataBind()
            cboModulo.Enabled = True
            dgvDetalle.Enabled = True
            If dgvDetalle.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub llenar_combos()
        Try
            With cboModulo
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
            Me.dgvDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
            Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DSIAM")
        End Try

    End Sub

    Private Sub FrmConf_Doc_Mov_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()

    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboModulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModulo.Click

    End Sub

    Private Sub cboModulo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboModulo.InitializeLayout
        cboModulo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboModulo.DisplayLayout.Bands(0).Columns(1).Width = cboModulo.Width
    End Sub

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        dgvDetalle.DataSource = Nothing
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                cboModulo.Enabled = False
                dgvDetalle.Enabled = False
                Call Listado_Condicion_Detalles()
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = dgvListado.Width - 50
            .Columns(2).Hidden = True
        End With
    End Sub

    Private Sub dgvDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle.InitializeLayout
        With dgvDetalle.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Width = 250
            .Columns(3).Header.Caption = "Documento"
            .Columns(4).Width = 60
            .Columns(4).Header.Caption = "Signo"
            .Columns(5).Width = 120
            .Columns(5).Header.Caption = "Referencia"
            .Columns(6).Width = 120
            .Columns(6).Header.Caption = "Descuento"
        End With
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
        FrmActualizar_Mov_Mercaderia.pCodigo = 0
        FrmActualizar_Mov_Mercaderia.xNew = True
        FrmActualizar_Mov_Mercaderia.ShowDialog()
    End Sub

    Private Sub TpModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TpModificar.Click
        If dgvDetalle.Rows.Count > 0 Then
            If dgvDetalle.Selected.Rows.Count > 0 Then
                With FrmActualizar_Mov_Mercaderia
                    .pCodigo = Long.Parse(dgvDetalle.DisplayLayout.ActiveRow.Cells(0).Value)
                    .xNew = False
                    .vModulo = cboModulo.Value
                    .vMovimiento = Long.Parse(dgvDetalle.DisplayLayout.ActiveRow.Cells(1).Value)
                    .vDocumento = Long.Parse(dgvDetalle.DisplayLayout.ActiveRow.Cells(2).Value)
                    .vSigno = dgvDetalle.DisplayLayout.ActiveRow.Cells(4).Value
                    .vReferencia = dgvDetalle.DisplayLayout.ActiveRow.Cells(5).Value
                    .vDscto = dgvDetalle.DisplayLayout.ActiveRow.Cells(6).Value
                    .ShowDialog()
                End With
            End If
        End If

    End Sub

    Private Sub cboModulo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModulo.ValueChanged
        cboModulo.Enabled = False
        dgvDetalle.Enabled = False
        Call Listado_Condicion_Detalles()
    End Sub

    Public Function Eliminar(ByVal vCodigo As Integer) As Boolean
        Try
            det_mov_mercaderiaManager.Eliminar(vCodigo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If dgvDetalle.Selected.Rows.Count > 0 Then
            If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then

                Call Eliminar(CInt(dgvDetalle.DisplayLayout.ActiveRow.Cells(0).Value))
                Call Listado_Condicion_Detalles()
            End If
        End If
    End Sub
End Class