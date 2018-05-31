Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConsulta_Productos
    Public Cod_Cat, Op_Sel As Integer, pCodigo_Almacen As Integer
    Public ListadoRegistros As DataTable

    Private Sub FrmListadoClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        lblBuscarpor.Tag = 1
        txtBuscar.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

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

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If Not bwListado.IsBusy Then
            picAjax.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
        If e.KeyCode <> Keys.Down Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) + 1
        If e.KeyCode <> Keys.Up Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) - 1
        If Val(lblBuscarpor.Tag) = 0 Then lblBuscarpor.Tag = 3
        If Val(lblBuscarpor.Tag) = 4 Then lblBuscarpor.Tag = 1
        Select Case Val(lblBuscarpor.Tag)
            Case Is = 1
                lblBuscarpor.Text = "Nombre:"
                txtBuscar.MaxLength = 50
            Case Is = 2
                lblBuscarpor.Text = "Código:"
                txtBuscar.MaxLength = 10
            Case Is = 3
                lblBuscarpor.Text = "Barras:"
                txtBuscar.MaxLength = 50
        End Select
    End Sub

    Private Sub TxtBusca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Not bwListado.IsBusy Then
                picAjax.Visible = True
                bwListado.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub dgvListado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvListado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 30
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Width = 380
            .Columns(1).Header.Caption = "PRODUCTO"
            .Columns(2).Width = 100
            .Columns(2).Header.Caption = "FAMILIA"
            .Columns(3).Width = 80
            .Columns(3).CellAppearance.TextHAlign = HAlign.Right
            .Columns(3).Header.Caption = "PRECIO"
            .Columns(4).Hidden = True
            .Columns(5).Hidden = True
            .Columns(6).Hidden = True
            .Columns(7).Width = 80
            .Columns(7).Header.Caption = "STOCK"
            .Columns(7).CellAppearance.TextHAlign = HAlign.Center
            .Columns(7).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(8).Hidden = True
            .Columns(9).Hidden = True
            .Columns(10).Hidden = True
            .Columns(11).Hidden = True
        End With

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Frmt As New FrmProductoNM
        Frmt.ShowDialog()
    End Sub

    Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim xLimit As Integer
        xLimit = 0

        If IsNumeric(txtLimite.Text) Then
            xLimit = CInt(txtLimite.Text)
        End If

        Try
            Dim dtProducto As New DataTable

            If lblBuscarpor.Tag = 1 Then 'nombre
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, xLimit, txtBuscar.Text.Trim, "", 0, "", False)
            ElseIf lblBuscarpor.Tag = 2 Then 'codigo
                If Not IsNumeric(txtBuscar.Text) Then Exit Sub
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, xLimit, "", "", txtBuscar.Text, "", False)
            ElseIf lblBuscarpor.Tag = 3 Then 'barras
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, xLimit, "", "", 0, txtBuscar.Text.Trim, False)
            End If

            e.Result = dtProducto

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
        'Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjax.Visible = False
    End Sub

    Private Sub FrmConsulta_Personas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Call formatear_grid()
    lblBuscarpor.Tag = 1
  End Sub

    Private Sub TxtApe_Pat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.ValueChanged

    End Sub
End Class