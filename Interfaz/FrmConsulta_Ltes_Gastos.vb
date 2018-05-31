Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConsulta_Ltes_Gastos
    Public vTipo As String = "BORRADOR", pCodigo_Uni As Integer, pCodigo_Alm As Integer

    Private Sub llenar_combos()

        Try
            Dim lMeses As New ClsCrearMeses

            With cboMes
                .DataSource = Nothing
                .DataSource = lMeses.GetList(False, False)
                .Refresh()
                .ValueMember = "codigo"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    .Value = Now.Month
                End If

            End With

            With cboAnio
                .DataSource = Nothing
                .DataSource = lMeses.GetList_anios()
                .Refresh()
                .ValueMember = "nombre"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .Text = Year(Now)
                End If




            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmListadoLtsGastos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtBusca.Focus()
    End Sub

    Private Sub FrmListadoLtsGastos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmListadoLtsGastos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        Call ListarCondicion()
    End Sub

    Public Function ListarCondicion() As Boolean
        Dim xBusca As String = ""
        xBusca = Trim(Me.TxtBusca.Text)
        If cboAnio.Text = "" Then
            Exit Function
        End If

        Try

            Me.dgvListado.DataSource = lote_gastoManager.GetList(pCodigo_Uni, pCodigo_Alm, xBusca, Integer.Parse(cboAnio.Text), Integer.Parse(cboMes.Value), Trim(vTipo))

            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                'dgvListado.ActiveCell = dgvListado.Rows(0).Cells(2)
                dgvListado.Rows(0).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        'With e.Layout.Bands(0)
        '    .Columns(0).Width = 115
        '    .Columns(1).Width = 215
        '    .Columns(1).FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        '    '.Columns(2).Width = 70
        '    '.Columns(2).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        '    .Columns(2).Hidden = True
        '    .Columns(3).Hidden = True
        '    .Columns(4).Width = 120
        '    .Columns(5).Width = 80
        '    .Columns(5).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        '    .Columns(6).Hidden = True
        'End With

    End Sub


    Private Sub TxtBusca_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusca.ValueChanged
        If Not Len((TxtBusca.Text)) > 20 Then
            Call ListarCondicion()
        End If
    End Sub

    Private Sub cboAnio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAnio.TextChanged
        Call ListarCondicion()
    End Sub

    Private Sub cboMes_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMes.InitializeLayout
        cboMes.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboMes.DisplayLayout.Bands(0).Columns(1).Width = cboMes.Width
    End Sub

    Private Sub cboMes_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMes.ValueChanged
        Call ListarCondicion()
    End Sub
End Class