Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win
Imports Telerik.WinControls.UI.Docking

Public Class FrmProvision_Castigo_Deuda
  Private FrmAdd As DocumentWindow
  Private Sub FrmProvision_Castigo_Deuda_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
  End Sub

  Private Sub llenar_combos()
    Try
      With cboAlmacen
        .DataSource = Nothing
        .DataSource = GestionTablas.dtFAlmacen
        .DataBind()
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

  Private Sub tsDNuevo_Click(sender As Object, e As EventArgs) Handles tsDNuevo.Click
    If cboAlmacen.Text = "" Then
      MessageBox.Show("Debe seleccionar un almacén", "AVISO")
      Exit Sub
    End If
    Dim frm As FrmActualiza_Provision_Castigo_Deuda = New FrmActualiza_Provision_Castigo_Deuda

    With frm
      .vCodigo_Uni = GestionSeguridadManager.gUnidadId
      If chkTodos.Checked Then
        .vAlmacenid = 0
      Else
        If Not cboAlmacen.Text = "" Then
          .vAlmacenid = cboAlmacen.Value
        End If
      End If

      .vUnidad_Negocio = GestionSeguridadManager.gUnidad
      .vAlmacen = cboAlmacen.Text
      Call LibreriasFormularios.Ver_Form(frm, "Provisión Gasto")
    End With
  End Sub

  Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork
    Dim DtGrid As New DataTable
    Dim vAlmacenid As Long = 0, vHasta As String = "", vCodigo_Uni As Integer = GestionSeguridadManager.gUnidadId
    If chkTodos.Checked = False Then
      vAlmacenid = cboAlmacen.Value
    End If

    DtGrid = por_cobrarManager.PorCobrar_Prov_Castigo_Leer(vCodigo_Uni, vAlmacenid, vHasta)

    e.Result = DtGrid

  End Sub

  Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted
    dgvListado.DataSource = CType(e.Result, DataTable)
    picAjaxBig.Visible = False

    ' Me.LblRegistros.Text = "Existen " & dgvListado.Rows.Count & " Registros Mostrados"
  End Sub

  Private Sub tsDActualizar_Click(sender As Object, e As EventArgs) Handles tsDActualizar.Click
    If Not bwLlenar_Grid.IsBusy Then
      picAjaxBig.Visible = True
      bwLlenar_Grid.RunWorkerAsync()
    End If
  End Sub

  Private Sub dgvListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Header.Caption = "ID"
      .Columns(0).Width = 20
    End With
  End Sub

  Private Sub tsCerrar_Click(sender As Object, e As EventArgs) Handles tsCerrar.Click
    Me.Close()
  End Sub

  Private Sub tsDReporte_Click(sender As Object, e As EventArgs) Handles tsDReporte.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim DtGrid As New DataTable, vCodigo As Long = 0
        Dim vAlmacenid As Long = 0, vHasta As String = "", vCodigo_Uni As Integer = GestionSeguridadManager.gUnidadId
        If chkTodos.Checked = False Then
          vAlmacenid = cboAlmacen.Value
        End If
        vCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        DtGrid = por_cobrarManager.PorCobrar_Prov_Castigo_Rpt(vCodigo, vCodigo_Uni, vAlmacenid, vHasta)

        FrmAdd = Nothing

        If FrmAdd Is Nothing Then
          FrmAdd = New DocumentWindow()
          FrmAdd.Text = "Prov. PorCobrar"
          FrmAdd.CloseAction = DockWindowCloseAction.Hide

          Dim yForm As New FrmVisor_PorCobrar
          yForm.FormBorderStyle = FormBorderStyle.None
          yForm.TopLevel = False
          yForm.Dock = DockStyle.Fill
          FrmAdd.Controls.Add(yForm)
          MDIMenu.RadDock1.AddDocument(FrmAdd)
          yForm.RptProvision_PorCobrar(DtGrid, GestionSeguridadManager.gEmpresa, cboAlmacen.Text, "Detalle Provisión Castigo", "Código: " & vCodigo)

          yForm.Show()

        Else
          FrmAdd.Show()
        End If
        MDIMenu.RadDock1.ActiveWindow = FrmAdd

      End If
    End If
  End Sub

  Private Sub tsExcel_Click(sender As Object, e As EventArgs) Handles tsExcel.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "Castigo.xls")
  End Sub

  Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged

  End Sub
End Class