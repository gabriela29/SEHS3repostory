
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.BLL
Imports CapaObjetosNegocio.BO

Public Class FrmRegistrar_VentaLis
    Public _codigo As Integer
    Public dtlistaregistrov As DataTable
    Public ListadoRegistros As DataTableClearEventArgs
    Public IdUsuario As Long
    Public swNuevoregistro_venta As Boolean

    Private WithEvents popupHelperD As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupHelper As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub FrmSeriesDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmSeriesDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdUsuario = GestionSeguridadManager.idUsuario

        'Call ListarRegistrov()

    End Sub

    Public Function ListarRegistrov() As Boolean
        Dim xlimit As Integer
        Dim vArray As String = ""
        Dim objetos As New DataTable
        xlimit = Integer.Parse(txtLimite.Text)
        Try

            dtlistaregistrov = registrarvManager.GetList(txtcodigo_per.Value, txtalmacen.Value, txtmes.Value, txtanio.Value, xlimit)
            dgvListadoregis.DataSource = dtlistaregistrov

            dgvListadoregis.DataBind()
            If dgvListadoregis.Rows.Count() > 0 Then
                dgvListadoregis.Rows(0).Selected = True
                 dgvListadoregis.Focus()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ELiminar_Registro_venta(ByVal _cod As Integer) As Boolean
        ELiminar_Registro_venta = registrarvManager.Eliminar_Registrar(_cod)
        MessageBox.Show("Registro Eliminado con Éxito", "AVISO")
        Call ListarRegistrov()

    End Function


    Private Sub dgvListadoregis_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListadoregis.BeforeSelectChange
        If dgvListadoregis.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then


            Else
                _codigo = 0 ''''aqui

            End If
        End If

    End Sub



    Private Sub dgvListadoregis_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListadoregis.InitializeLayout
        With dgvListadoregis.DisplayLayout.Bands(0)
            .Columns(0).Width = 40
            .Columns(1).Width = 250
            .Columns(2).Width = 60
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Header.Caption = "PERSONA"
            .Columns(2).Header.Caption = "C. PER"
            .Columns(3).Header.Caption = "ALMACEN"
            .Columns(4).Header.Caption = "COD DOCUMENTO"
            .Columns(5).Header.Caption = "FECHA DE EMISIÓN"
            .Columns(6).Header.Caption = "NOMBRE CORTO"
            .Columns(7).Header.Caption = "CODIGO SUNAT"
            .Columns(8).Header.Caption = "NÚMERO"
            .Columns(9).Header.Caption = "N° DOC"
            .Columns(10).Header.Caption = "TIPO DE DOC"
            .Columns(11).Header.Caption = "AFECTO"
            .Columns(12).Header.Caption = "NOAFECTO"
            .Columns(13).Header.Caption = "IGV"
            .Columns(14).Header.Caption = "DSCTO"
            .Columns(15).Header.Caption = "TOTAL"
            .Columns(16).Header.Caption = "FECHA-DOC"
            .Columns(17).Header.Caption = "SIGNO"
            .Columns(18).Header.Caption = "SERIE INT"
            .Columns(19).Header.Caption = "NÚMERO INT"
            .Columns(20).Header.Caption = "TABLA"
            .Columns(21).Header.Caption = "MES"
            .Columns(22).Header.Caption = "AÑO"


        End With

        Call formatear_grid()
        'dgvListado.DisplayLayout.Override.TemplateAddRowCellAppearance.ForeColor = Color.Azure

    End Sub

    Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
        Me.Close()
    End Sub

    Private Sub TpNuevo_Click(sender As Object, e As EventArgs) Handles TpNuevo.Click
        popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As Registrar_Ventas = New Registrar_Ventas
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
        Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc3.Left, Me.txtLocaltionDoc3.Bottom))

        popupHelperD.ShowPopup(Me, frm, locationD)

    End Sub

    Private Sub TpModificar_Click(sender As Object, e As EventArgs) Handles TpModificar.Click
        If Not dgvListadoregis.Rows.Count > 0 Then
            MsgBox("No hay Datos seleccionados que modificar", MsgBoxStyle.Information, "INFORMACIÓN")
            Exit Sub
        End If

        If dgvListadoregis.Selected.Rows.Count > 0 Then
            popupHelperD = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()
            Dim frm As Registrar_Ventas = New Registrar_Ventas()
            With frm
                .MaximizeBox = False
                .MinimizeBox = False
                .ControlBox = False
                .ShowInTaskbar = False
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopMost = True
                .Text = ""
                .ModoVentanaFlotante = True


                .vtablad = dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Text

            End With
            Dim locationD As Point = Me.PointToScreen(New Point(Me.txtLocaltionDoc3.Left, txtLocaltionDoc3.Bottom))

            popupHelperD.ShowPopup(Me, frm, locationD)

        Else
            MsgBox("Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "DSIAM")
        End If
    End Sub

    Private Sub popupHelperD_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupHelperD.PopupClosed
        Dim frm As Registrar_Ventas = e.Popup
        Call ListarRegistrov()
        frm = Nothing
    End Sub

    Private Sub TpEliminar_Click(sender As Object, e As EventArgs) Handles TpEliminar.Click

        If dgvListadoregis.Selected.Rows.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Call ELiminar_Registro_venta(CInt(dgvListadoregis.DisplayLayout.ActiveRow.Cells(0).Value))

            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call ListarRegistrov()

    End Sub

    Private Sub formatear_grid()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance

        Me.dgvListadoregis.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListadoregis.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvListadoregis.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListadoregis.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListadoregis.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Arial"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.ForeColor = System.Drawing.Color.White
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListadoregis.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.White
        Appearance63.BackColor2 = System.Drawing.Color.SteelBlue
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.dgvListadoregis.DisplayLayout.Override.RowSelectorAppearance = Appearance63
        Me.dgvListadoregis.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        Appearance64.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
        Appearance64.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.FontData.BoldAsString = "True"
        Me.dgvListadoregis.DisplayLayout.Override.SelectedRowAppearance = Appearance64
        Me.dgvListadoregis.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvListadoregis.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed
        Me.dgvListadoregis.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'para Seleccionar solo una Fila
        Me.dgvListadoregis.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        'Para seleccionar toda la Fila
        Me.dgvListadoregis.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        Me.dgvListadoregis.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus


    End Sub

End Class