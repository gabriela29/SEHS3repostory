
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO


Public Class FrmCentros_Costo
    Public _codigo As Integer
    Public ListadoDoc As DataTable
    Public ListadoDet As DataTable
    Public IdUsuario, Cod_Emp As Integer

    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmCentros_Costo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmCentros_Costo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call ListarCondicion("")

    End Sub

    Public Function ListarCondicion(ByVal Descripcion As String) As Boolean
        Dim objetos As New DataTable
        Try
            ListadoDoc = permisos_moduloManager.Leer_Almacenes(GestionSeguridadManager.idUsuario, GestionModulos.modVentas)
            dgvListado.DataSource = ListadoDoc
            dgvListado.DataBind()
            If dgvListado.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Listado_Condicion_Detalles(ByVal Cod_Uni As Integer) As Boolean
        Dim objetos As New DataTable
        Try
            ListadoDet = centro_costoManager.GetList(Cod_uni)
            dgvDetalle.DataSource = ListadoDet
            dgvDetalle.DataBind()
            If dgvDetalle.Rows.Count() > 0 Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
        Call ListarCondicion("")
    End Sub

    Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
        _codigo = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
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

        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.White
        Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
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

    Public Function Eliminar(ByVal vCodigo_Uni As Integer, ByVal vC_Costo As Long) As Boolean

        Try
            centro_costoManager.Eliminar(vCodigo_Uni, vC_Costo)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        If dgvListado.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                _codigo = CInt((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                Call Listado_Condicion_Detalles(_codigo)
            Else
                _codigo = 0
                dgvDetalle.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout

        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).ColumnChooserCaption = "Almacenes"
            .Columns(1).Width = 200
            .Columns(2).Hidden = True
            '.Columns(3).Hidden = True
            '.Columns(4).Hidden = True
        End With

        Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click
        If dgvDetalle.Selected.Rows.Count > 0 Then
            If MsgBox(" Esta Acción podría Afectar el normal Funncionamiento del Sistema, ¿Desea Continuar?", MsgBoxStyle.YesNo, "Confirme") = MsgBoxResult.Yes Then

                Call Eliminar(CInt(dgvDetalle.DisplayLayout.ActiveRow.Cells(0).Value), CLng(dgvDetalle.DisplayLayout.ActiveRow.Cells(2).Value))
                Call Listado_Condicion_Detalles(_codigo)
            End If
        End If
    End Sub

    Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click

        popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Dim frm As FrmCentro_CostoNM = New FrmCentro_CostoNM()
                Call frm.LimpiarControles()
                frm.swNuevo = True
                frm.vAlmacen = CInt(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
                frm.vNombre_Alm = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
                With frm
                    .MaximizeBox = False
                    .MinimizeBox = False
                    .ControlBox = False
                    .ShowInTaskbar = False
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                    .TopMost = True
                    .Text = ""
                    .ModoVentanaFlotante = True
                End With
                Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

                popupHelper.ShowPopup(Me, frm, location)
            End If
        End If


    End Sub

    Private Sub popupHelper_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelper.PopupClosed
        Dim frm As FrmCentro_CostoNM = e.Popup
        Call Listado_Condicion_Detalles(_codigo)

        frm = Nothing
    End Sub

    Private Sub TpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpModificar.Click

        If Not dgvDetalle.Rows.Count > 0 Then
            MsgBox("No hay Datos que modificar", MsgBoxStyle.Information, "DSIAM")
            Exit Sub
        End If


        If Not _codigo = 0 And dgvDetalle.Selected.Rows.Count > 0 Then
            Call FrmCentro_CostoNM.LimpiarControles()
            popupHelper = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As FrmCentro_CostoNM = New FrmCentro_CostoNM()

            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True
                .swNuevo = False
                .LblCodigo.Text = CInt(dgvDetalle.DisplayLayout.ActiveRow.Cells(0).Value)
                .vAlmacen = CInt(dgvDetalle.DisplayLayout.ActiveRow.Cells(0).Value)
                .vNombre_Alm = Trim(dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
                .txtDescripcion.Text = Trim(dgvDetalle.DisplayLayout.ActiveRow.Cells(1).Value)
                .txtC_costo.Text = Trim(dgvDetalle.DisplayLayout.ActiveRow.Cells(2).Value)
                .vC_Costo = Trim(dgvDetalle.DisplayLayout.ActiveRow.Cells(2).Value)
                .txtC_Costo_Ant.Text = Trim(dgvDetalle.DisplayLayout.ActiveRow.Cells(5).Value)
                .ChkEstado.Checked = CBool(Trim(dgvDetalle.DisplayLayout.ActiveRow.Cells(4).Value))
            End With
            Dim location As Point = Me.PointToScreen(New Point(Me.btnLocation.Left, btnLocation.Bottom))

            popupHelper.ShowPopup(Me, frm, location)

        Else
            MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub dgvDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle.InitializeLayout
        With dgvDetalle.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = (dgvDetalle.Width / 2) - 10
            .Columns(2).Width = 90
            .Columns(3).Width = 50
            '.Columns(4).Width = 30
            .Columns("orden").Hidden = True
            '.Columns(3).Hidden = True
            '.Columns(4).Width = 120
            '.Columns(4).CellAppearance.BackColor = Color.LemonChiffon
            '.Columns(4).CellAppearance.TextHAlign = HAlign.Center

        End With
        Me.dgvDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.dgvDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub


    
    Private Sub tsDEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDEditar.Click

    End Sub
End Class