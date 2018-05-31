
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmPersona_Direccion
    Public swNuevo As Boolean
    Public pPersonaId As Long, pCodigo As Long
    Public ListadoRegistros As DataTable

    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        'Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        'Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(208, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62


        'Appearance63.BackColor = System.Drawing.Color.White
        'Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        'Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        'Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Appearance63.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance63.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(208, Byte), Integer))
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle


        'Appearance64.BackColor = System.Drawing.Color.LightCyan
        'Appearance64.BackColor2 = System.Drawing.Color.White
        'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        'Appearance64.FontData.BoldAsString = "True"
        'Appearance64.ForeColor = Color.Navy
        'Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Appearance64.ForeColor = Color.Navy
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Me.dgvListado.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'para Seleccionar solo una Fila
        Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        'Para seleccionar toda la Fila
        Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        pCodigo = 0
        ugpActualizar.Visible = True
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If Not bwListado.IsBusy Then
            picAjax.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub dgvListado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvListado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
        CheckForIllegalCrossThreadCalls = False

        Try
            ListadoRegistros = personaManager.GetList_Direccion(pPersonaId)
            e.Result = ListadoRegistros
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwListado_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwListado.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        If dgvListado.Rows.Count() > 0 Then
            dgvListado.Rows(0).Selected = True
            dgvListado.Focus()
        End If
        Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjax.Visible = False
    End Sub

    Private Sub FrmPersona_Direccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call formatear_grid()
        If Not bwListado.IsBusy Then
            picAjax.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim vOk As Long = 0
        If txtSucursal.Text.Trim = "" Or txtDireccion.Text.Trim = "" Then
            MessageBox.Show("Debe Ingresar datos Requeridos", "Corregir", MessageBoxButtons.OK)
            Exit Sub
        End If
        vOk = personaManager.Persona_Direccion_Actualizar(pCodigo, pPersonaId, txtSucursal.Text.Trim, txtDireccion.Text.Trim)

        If vOk > 0 Then
            txtSucursal.Text = ""
            txtDireccion.Text = ""
            ugpActualizar.Visible = False
            If Not bwListado.IsBusy Then
                picAjax.Visible = True
                bwListado.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        pCodigo = -1
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                pCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                If pCodigo > 0 Then
                    txtSucursal.Text = (dgvListado.DisplayLayout.ActiveRow.Cells("sucursal").Value)
                    txtDireccion.Text = (dgvListado.DisplayLayout.ActiveRow.Cells("direccion").Value)
                    ugpActualizar.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnGuardar.Focus()
        End If
    End Sub
End Class