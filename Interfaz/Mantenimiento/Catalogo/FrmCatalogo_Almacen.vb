Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win

Public Class FrmCatalogo_Almacen

  Public _codigo As Long, pCod_Cat As Integer
  Public ListadoRegistros As DataTable

  Private Sub FrmCatalogo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F12 Then
      txtBuscar.Focus()
    ElseIf e.KeyCode = Keys.F9 Then
      If dgvListado.Rows.Count > 0 Then
        dgvListado.Rows(0).Selected = True
      End If
    ElseIf e.KeyCode = Keys.Escape Then
      Me.Close()
      MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
    End If
  End Sub

  Private Sub FrmCatalogo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub

  Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork

    Dim Fecha_Actual As Date = Now.Date
    Dim vAlmacen As Integer = 0, vFilas As Integer = 0
    vFilas = Long.Parse(txtFilas.Text)
    vAlmacen = cboAlmacen.Value
    Try
      If Trim(txtBuscar.Text) <> "" Then
        Select Case Val(lblBuscar.Tag)
          Case Is = 1
            ListadoRegistros = productoManager.Leer(Year(Fecha_Actual), vAlmacen, vFilas, Trim(txtBuscar.Text), "", 0)
          Case Is = 2
            ListadoRegistros = productoManager.Leer(Year(Fecha_Actual), vAlmacen, vFilas, "", Trim(txtBuscar.Text), 0)
          Case Is = 3
            ListadoRegistros = productoManager.Leer(Year(Fecha_Actual), vAlmacen, vFilas, "", "", Val(txtBuscar.Text))
        End Select
      Else
        ListadoRegistros = productoManager.Leer(Year(Fecha_Actual), vAlmacen, vFilas, Trim(txtBuscar.Text), "", 0, pCod_Cat)
      End If

      e.Result = ListadoRegistros

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted

    dgvListado.DataSource = ListadoRegistros

    picAjaxBig.Visible = False

    dgvListado.Enabled = True

    If dgvListado.Rows.Count > 0 Then
      dgvListado.Focus()
    Else
      txtBuscar.Focus()
    End If

    Me.lbl.Text = dgvListado.Rows.Count & " Registros"
    'dgvCondicion.Enabled = True
  End Sub

  Public Function ListarCondicion() As Boolean
    picAjaxBig.Visible = True
    'dgvCondicion.Enabled = False
    If Not bwLlenar_Grid.IsBusy Then
      bwLlenar_Grid.RunWorkerAsync()
    End If

  End Function

  Private Sub dgvListado_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListado.AfterRowsDeleted
    Call ListarCondicion()
  End Sub

  Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
    Call ListarCondicion()
  End Sub

  Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
    _codigo = Long.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
  End Sub

  Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
    If dgvListado.Rows.Count > 0 Then
      If e.NewSelections.Rows.Count > 0 Then
        _codigo = CInt((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
      Else
        _codigo = 0
      End If
    End If
  End Sub

  Private Sub tpCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tpCerrar.Click
    Me.Close()
    MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
  End Sub

  Private Sub llenar_combos()
    Try
      'With dgvCondicion
      '  .DataSource = Nothing
      '  .DataSource = subcategoriaManager.GetList(0, "")
      'End With
      With cboAlmacen
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
      MsgBox(ex.Message, MsgBoxStyle.Exclamation, "DSIAM")
    End Try

  End Sub


  Private Sub FrmCatalogo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call llenar_combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
    lblBuscar.Tag = 1
  End Sub

  Private Sub BtnMostrar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call ListarCondicion()
    lblBuscar.Tag = 1
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("codigo").Header.Caption = "ID"
      .Columns("codigo").Width = 20
      .Columns("producto").Header.Caption = "PRODUCTO"
      .Columns("producto").Width = 350
      .Columns("codigo_sub").Hidden = True
      .Columns("subcategoria").Header.Caption = "FAMILIA"
      .Columns("subcategoria").Width = 180
      .Columns("precio_com").Hidden = True
      .Columns("stock").Header.Caption = "Stock"
      .Columns("stock").Width = 70
      .Columns("stock").CellAppearance.TextHAlign = HAlign.Right
      .Columns("proveedor").Hidden = True
      .Columns("precio_va").Header.Caption = "PRECIO A"
      .Columns("precio_va").Width = 80
      .Columns("precio_va").CellAppearance.TextHAlign = HAlign.Right
      .Columns("precio_vb").Header.Caption = "PRECIO B"
      .Columns("precio_vb").Width = 80
      .Columns("precio_vb").CellAppearance.TextHAlign = HAlign.Right
      .Columns("codigo_prov").Hidden = True
      .Columns("precio_s").Hidden = True
      .Columns("precio_d").Hidden = True
      .Columns("stock_min").Hidden = True
      .Columns("stock_max").Hidden = True
      .Columns("codigo_barras").Header.Caption = "BARRAS"
      .Columns("codigo_barras").Width = 120
      .Columns("ubicacion").Width = 200
    End With
  End Sub

  Private Sub tsActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar.Click
    Call ListarCondicion()
  End Sub

  Private Sub tsKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsKardex.Click
    Dim kCodigo As Long
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        kCodigo = Long.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
        Dim frm As New FrmKardex

        frm.pCodigo = Long.Parse(kCodigo)
        frm.pNombre = (dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
        Call LibreriasFormularios.Ver_Form(frm, "Kardex")
        '.MostrarDatos(_codigo)
      End If
    End If
  End Sub

  Private Sub tsUbicacion_Click(sender As Object, e As EventArgs) Handles tsUbicacion.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        FrmProducto_Ubicacion.pProductoID = _codigo
        FrmProducto_Ubicacion.pProducto = Trim(dgvListado.DisplayLayout.ActiveRow.Cells("producto").Value)
        FrmProducto_Ubicacion.pAlmacenID = cboAlmacen.Value
        FrmProducto_Ubicacion.pAlmacen = cboAlmacen.Text

        FrmProducto_Ubicacion.pUbicacion = Trim(dgvListado.DisplayLayout.ActiveRow.Cells("ubicacion").Value)

        FrmProducto_Ubicacion.ShowDialog()
      Else
        _codigo = 0
      End If
    End If
  End Sub

  Private Sub tsPrevioVta_Click(sender As Object, e As EventArgs) Handles tsPrevioVta.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        FrmProducto_Precio.pProductoID = _codigo
        FrmProducto_Precio.pProducto = Trim(dgvListado.DisplayLayout.ActiveRow.Cells("producto").Value)
        FrmProducto_Precio.pAlmacenID = cboAlmacen.Value
        FrmProducto_Precio.pAlmacen = cboAlmacen.Text

        FrmProducto_Precio.pPrecio = Single.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("precio_va").Value)
        FrmProducto_Precio.pPrecioB = Single.Parse(dgvListado.DisplayLayout.ActiveRow.Cells("precio_vb").Value)

        FrmProducto_Precio.ShowDialog()
      Else
        _codigo = 0
      End If
    End If
  End Sub

  Private Sub cboAlmacen_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout

  End Sub

  Private Sub tsReporte_Click(sender As Object, e As EventArgs) Handles tsReporte.Click
    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, utExcel, "Prod_Alm.xls")
  End Sub

  Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged
    dgvListado.DataSource = Nothing
  End Sub
End Class