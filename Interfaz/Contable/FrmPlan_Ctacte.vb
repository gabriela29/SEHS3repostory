Imports Infragistics.Win.UltraWinGrid
Imports CapaLogicaNegocio.BLL
Public Class FrmPlan_Ctacte
    Public pCtaCteId As Long, swNuevo As Boolean
    Public pLoteId As Long, pEntidad As Long
    Public pDtListado As DataTable

    Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork

        pDtListado = New DataTable


        Try
            pDtListado = plan_cuentasManager.Plan_CtaCte_GetList(pEntidad, cboTipo.Text, txtNombre.Text.Trim)

            e.Result = pDtListado

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted
        Try
            lblPendientes.Text = ""
            dgvListado.DataSource = pDtListado
            'dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then
                lblPendientes.Text = dgvListado.Rows.Count()
            End If

            picAjaxBig.Visible = False
            gpConsulta.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub



    Private Sub tsActualizar_Click(sender As Object, e As EventArgs) Handles tsActualizar.Click
        Call ListarCondicion()
    End Sub

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        Call ListarCondicion()
    End Sub

    Private Sub tsNuevo_Click(sender As Object, e As EventArgs) Handles tsNuevo.Click
        Dim frm As FrmPlan_CtaCteNM = New FrmPlan_CtaCteNM
        frm.swNuevo = True
        frm.ShowDialog()

    End Sub

    Private Sub BtnRegistroPDireccion_Click(sender As Object, e As EventArgs) Handles BtnRegistroPDireccion.Click
        Dim frm As FrmPersona_Direccion = New FrmPersona_Direccion
        frm.swNuevo = True
        frm.ShowDialog()
    End Sub

    Private Sub btnRegistroV_Click(sender As Object, e As EventArgs) Handles btnRegistroV.Click
        Dim frm As FrmRegistrar_VentaLis = New FrmRegistrar_VentaLis
        frm.swNuevo = True
        frm.ShowDialog()

    End Sub


    Public Function ListarCondicion() As Boolean
        If cboEntidad.Text.Trim = "" Then
            MessageBox.Show("Debe seleccionar una entidad", "Verificar")
            Exit Function
        End If
        pEntidad = Long.Parse(cboEntidad.Text)
        picAjaxBig.Visible = True
        gpConsulta.Enabled = False
        If Not bwLlenar_Grid.IsBusy Then
            bwLlenar_Grid.RunWorkerAsync()
        End If
    End Function


End Class