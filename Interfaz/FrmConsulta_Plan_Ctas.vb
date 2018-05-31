Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConsulta_Plan_Ctas
    Private _IdPlanSel As Integer

    Private Sub FrmListadoPlanCtas_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtBusca.Focus()
        CmbOpcion.Text = "Nombre"
    End Sub

    Private Sub FrmListadoPlanCtas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmListadoPlanCtas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtBusca.Focus()
    End Sub

    Private Sub bwPlan_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwPlan.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim oPCta As New plan_cuentas
        Dim Dt As New DataTable
        Try

            If Not Len((TxtBusca.Text)) > 20 Then
                If CmbOpcion.Text = "Cuenta" Then
                    Dt = plan_cuentasManager.GetList(TxtBusca.Text, "", Str(Me.txtLimite.Text))
                Else
                    Dt = plan_cuentasManager.GetList("", TxtBusca.Text, Str(Me.txtLimite.Text))
                End If
            End If

            e.Result = Dt
            oPCta = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwPlan_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwPlan.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        If dgvListado.Rows.Count() > 0 Then
            'dgvListado.ActiveCell = dgvListado.Rows(0).Cells(2)
            dgvListado.Rows(0).Selected = True
            dgvListado.Focus()
        End If
        'Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjax.Visible = False
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With e.Layout.Bands(0)
            .Columns(0).Hidden = True
            '.Columns("Cuenta").Width = 900
            '.Columns("CtaCte").Width = 700
            '.Columns("sct").Width = 400
            .Columns("NombreCta").Width = 280
            '.Columns("CtaMaestra").Width = 1300
            .Columns("Nivel").Hidden = True

        End With

    End Sub

    Private Sub TxtBusca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBusca.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not Len((TxtBusca.Text)) > 20 Then
                If Not bwPlan.IsBusy Then
                    picAjax.Visible = True
                    bwPlan.RunWorkerAsync()
                End If
            End If
        End If
    End Sub

    Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class