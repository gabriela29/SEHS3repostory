Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports Telerik.WinControls.UI.Docking

Public Class FrmSalida_traslado

    Public _codigo As Long, _Codigo_Doc As Integer
    Private FrmAdd As DocumentWindow

    Private Sub llenar_combos()
        Try


            With cboDocumento
                .DataSource = Nothing
                .DataSource = GestionTablas.dtperdoc
                .Refresh()
                .ValueMember = "documentoid"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End With

            With Me.cboAlmacen
                .DataSource = GestionTablas.dtFAlmacen
                '.DataBind()
                .ValueMember = "almacenid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboUnidad_Negocio_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not bwAlmacen.IsBusy Then
        '    cboAlmacen.Text = [String].Empty
        '    picAjax.Visible = True
        '    bwAlmacen.RunWorkerAsync()
        'End If
        _codigo = 0
    End Sub

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        Dim DtRes As New DataTable
        Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0


        xCod_uni = GestionSeguridadManager.gUnidadId

        If Not Trim(Me.cboAlmacen.Text) = "" Then
            xCod_Alm = CInt(cboAlmacen.Value)
        End If
        vOpcion = cboDocumento.Value
        vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
        vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

        DtRes = salida_mercaderiaManager.Leer(xCod_Alm, 0, 0, "", vDesde, vHasta, 0)

        e.Result = DtRes

    End Sub

    Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

        dgvListado.DataSource = CType(e.Result, DataTable)
        Call CalcularTotales_Res(CType(e.Result, DataTable))
        picAjaxRes.Visible = False
        gpCriterios.Enabled = True
        gpBotones.Enabled = True
        'dgvListado.Refresh()
        Me.lblRegistros_Res.Text = dgvListado.Rows.Count & " Registros"

    End Sub

    Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
        Dim DtTot As New DataTable
        Dim Drs As DataRow
        Dim vDeudaVenc, vDeudaMora, vDeudaSM
        Dim vCod_a As Long = 0
        vDeudaVenc = 0
        vDeudaMora = 0
        vDeudaSM = 0
        CalcularTotales_Res = False
        'If Not Trim(TxtDNI_RUC.Text) = "" Then
        '    vCod_a = CInt(TxtDNI_RUC.Text)
        'End If
        Try
            DtTot = DtTotales 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

            For Each Drs In DtTot.Rows

                'Select Case Trim(Drs("tipo").ToString)
                '    Case "M"
                '        vDeudaMora = CSng(Drs("monto").ToString)
                '    Case "V"
                '        vDeudaVenc = CSng(Drs("monto").ToString)
                '    Case "T"
                '        vDeudaSM = CSng(Drs("monto").ToString)

                'End Select
                'vTotal = vTotal + CSng(Drs("").ToString)
                'vTotal = CSng(vDeudaSM + vDeudaMora)

            Next Drs
            'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
            'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
            'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
            'Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
            CalcularTotales_Res = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
        _codigo = 0
        'Call Totales_Cero()
        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                _Codigo_Doc = Integer.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_doc").Value))
                'Call Mostrar_Detalles()
            Else
                _codigo = 0
            End If
        End If
    End Sub

    Private Sub FrmSalida_traslado_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'Me.Close()
    End Sub

    Private Sub FrmVentas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        cboDesde.Value = ("01/" & Now.Month & "/" & Now.Year)
        cboHasta.Value = Now.Date

    End Sub

    Private Sub tsdProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdProductos.Click

        FrmAdd = Nothing

        If FrmAdd Is Nothing Then
            FrmAdd = New DocumentWindow()
            FrmAdd.Text = "Trasladar"
            FrmAdd.CloseAction = DockWindowCloseAction.Hide

            Dim yForm As New FrmTrasladar
            yForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            yForm.TopLevel = False
            yForm.Dock = DockStyle.Fill
            FrmAdd.Controls.Add(yForm)
            MDIMenu.RadDock1.AddDocument(FrmAdd)

            yForm.pCodigo_Almacen = cboAlmacen.Value
            yForm.pAlmacen = cboAlmacen.Text
            yForm.pTipo_Mov = Tipo_Mov_Mercaderia.tTraslado
            yForm.Show()
        Else
            FrmAdd.Show()
        End If
        MDIMenu.RadDock1.ActiveWindow = FrmAdd
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Actualizar()
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDocumento.Width
            .Columns(2).Hidden = True
          
        End With
    End Sub

    Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsdActualizar.Click
        Call Actualizar()
    End Sub

    Public Sub Actualizar()
        picAjaxRes.Visible = True
        gpCriterios.Enabled = False
        gpBotones.Enabled = False
        dgvListado.DataSource = Nothing
        _codigo = 0
        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub

    Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns("codigo").Header.Caption = "ID"
            .Columns("codigo").Width = 20
            .Columns("tipo_movimiento").Width = 50
            .Columns("tipo_movimiento").Header.Caption = "TIPO"
            .Columns("fecha").Header.Caption = "FECHA"
            .Columns("fecha").Width = 100
            .Columns("codigo_doc").Hidden = True
            .Columns("documento").Width = 100
            .Columns("documento").Header.Caption = "DOCUMENTO"
            .Columns("numero").Width = 110
            .Columns("numero").Header.Caption = "NUMERO"
            .Columns("codigo_per").Hidden = True
            .Columns("nombre_persona").Header.Caption = "PERSONA"
            .Columns("nombre_persona").Width = 200
            .Columns("moneda").Hidden = True
            .Columns("simbolo_moneda").Width = 40
            .Columns("vta_total").Width = 80
            .Columns("vta_total").Header.Caption = "TOTAL"
            .Columns("vta_total").CellAppearance.TextHAlign = HAlign.Right
            .Columns("vta_total").CellAppearance.BackColor = Color.LemonChiffon
            .Columns("usuario").Width = 50
            .Columns("caja").Width = 50
            .Columns("estado").Hidden = True
            .Columns("cerrado").Hidden = True
            .Columns("condicion").Hidden = True
            .Columns("rol").Hidden = True
            .Columns("descontar_stock").Hidden = True
            .Columns("aux_descontar").Width = 30
            .Columns("almacen_destino").Width = 80
            .Columns("codigo_im").Width = 30
        End With
    End Sub

    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        If e.Row.Cells("estado").Value = False Then
            e.Row.Cells("numero").Appearance.Image = Global.Phoenix.My.Resources.Resources.img_anulado
            'Else
            '    e.Row.Cells("numero").Appearance.Image = Global.SoftComNet.My.Resources.Resources.edit_add
        End If
    End Sub

    Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown

        If dgvListado.Rows.Count > 0 Then
            If dgvListado.Selected.Rows.Count > 0 Then
                Dim vTienePermiso As Boolean = False
                If e.KeyData = Keys.Control + Keys.A Then
                    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "salida-anular", vTienePermiso)
                    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
                        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                        If MessageBox.Show("¿Está seguro de Anular este documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            salida_mercaderiaManager.Cambiar_Estado(_codigo, GestionSeguridadManager.idUsuario, My.Computer.Name)
                            Call Actualizar()
                        End If
                    End If
                ElseIf e.KeyData = Keys.Shift + Keys.Delete Then                   
                    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "salida-delete", vTienePermiso)
                    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
                        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                        If MessageBox.Show("¿Está seguro de Eliminar este Documento ?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            salida_mercaderiaManager.Eliminar(_codigo, GestionSeguridadManager.idUsuario, My.Computer.Name)
                            Call Actualizar()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub tsmDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDetalle.Click
        Try
            Dim dtTemp As New DataTable
            _codigo = 0
            'Call Totales_Cero()
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
                End If
            End If
            If _codigo = 0 Then Exit Sub
            dtTemp = reportes_salidasManager.Detalle_Documento(_codigo)


            FrmAdd = Nothing

            If FrmAdd Is Nothing Then
                FrmAdd = New DocumentWindow()
                FrmAdd.Text = "Detalle Salida"
                FrmAdd.CloseAction = DockWindowCloseAction.Hide

                Dim yForm As New FrmVisor_Salida
                yForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                yForm.TopLevel = False
                yForm.Dock = DockStyle.Fill
                FrmAdd.Controls.Add(yForm)
                MDIMenu.RadDock1.AddDocument(FrmAdd)
                yForm.RptSalida_Mercaderia_Detalle(dtTemp, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle Documento de Salida")

                yForm.Show()

            Else
                FrmAdd.Show()
            End If
            MDIMenu.RadDock1.ActiveWindow = FrmAdd

        Catch ex As Exception
            MessageBox.Show(ex.Message, "VERIFICAR")
        End Try
    End Sub

    Private Sub tsbAjuste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjuste.Click
        FrmAdd = Nothing

        If FrmAdd Is Nothing Then
            FrmAdd = New DocumentWindow()
            FrmAdd.Text = "Ajuste Salida"
            FrmAdd.CloseAction = DockWindowCloseAction.Hide

            Dim yForm As New FrmTrasladar
            yForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            yForm.TopLevel = False
            yForm.Dock = DockStyle.Fill
            FrmAdd.Controls.Add(yForm)
            MDIMenu.RadDock1.AddDocument(FrmAdd)

            yForm.pCodigo_Almacen = cboAlmacen.Value
            yForm.pAlmacen = cboAlmacen.Text
            yForm.pTipo_Mov = Tipo_Mov_Mercaderia.tAJUSTE
            yForm.Show()
        Else
            FrmAdd.Show()
        End If
        MDIMenu.RadDock1.ActiveWindow = FrmAdd

    End Sub
End Class