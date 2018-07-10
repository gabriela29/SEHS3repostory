
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll


Public Class FrmCatalogo
    Public _codigo As Long, pCod_Cat As Integer
    Public swNuevo As Boolean
    Public ListadoRegistros As DataTable

  Private Sub FrmCatalogo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F12 Then
      txtBuscar.Focus()
    ElseIf e.KeyCode = Keys.Insert Then
      Call Nuevo()
    ElseIf e.KeyCode = Keys.F9 Then
      If dgvListado.Rows.Count > 0 Then
        dgvListado.Rows(0).Selected = True
      End If
    ElseIf e.KeyCode = Keys.Escape Then
      Me.Close()
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
    dgvCondicion.Enabled = True
  End Sub

  Public Function ListarCondicion() As Boolean
    picAjaxBig.Visible = True
    dgvCondicion.Enabled = False
    If Not bwLlenar_Grid.IsBusy Then
      bwLlenar_Grid.RunWorkerAsync()
    End If

  End Function

  Private Sub dgvListado_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListado.AfterRowsDeleted
    Call Eliminar(Long.Parse(_codigo))
    Call ListarCondicion()
  End Sub

  Private Sub dgvListado_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles dgvListado.AfterRowUpdate
    Call ListarCondicion()
  End Sub

  Private Sub dgvListado_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles dgvListado.BeforeRowsDeleted
    _codigo = Long.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
  End Sub

  Public Function Eliminar(ByVal _id As Long) As Boolean
    Dim vTienePermiso As Boolean = False
    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "producto-delete", vTienePermiso)

    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
      Try
        If MessageBox.Show("¿Está seguro de eliminar este registro?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
          If productoManager.Eliminar(_id) Then
            Eliminar = True
          End If
        End If
      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If

  End Function

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
  End Sub

  Private Sub TpEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpEliminar.Click

    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Call Eliminar(Long.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        Call ListarCondicion()
      End If
    End If

  End Sub

  Private Sub Nuevo()
    'Call FrmProductoNM.LimpiarControles()
    Dim vTienePermiso As Boolean = False
        Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "producto-add", vTienePermiso)

        If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
      Dim frmCP As New FrmProductoNM
      With frmCP
        .xNew = False
        .pCodigo = 0
        .ShowDialog()
      End With
    End If


    'Call ListarCondicion()
  End Sub
  Private Sub TpNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpNuevo.Click
    Call Nuevo()
  End Sub

  Private Sub TpModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TpModificar.Click

    Call Modificar()


  End Sub

  Private Sub Modificar()
    Dim vTienePermiso As Boolean = False
    Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "producto-edit", vTienePermiso)

    If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
      Dim eCodigo As Long
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          eCodigo = Long.Parse(dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
          With FrmProductoNM
            .LblCodigo.Text = Long.Parse(_codigo)
            .pCodigo = _codigo
            '.MostrarDatos(_codigo)
          End With

          FrmProductoNM.ShowDialog()
        Else
          MsgBox("  Debe Seleccionar un Registro Primero ", MsgBoxStyle.Exclamation, "VHDataSoft")
        End If
      End If
    End If

  End Sub

  Private Sub llenar_combos()
    Try
      With dgvCondicion
        .DataSource = Nothing
        .DataSource = subcategoriaManager.GetList(0, "")
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

  Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
    If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
    If e.KeyCode <> Keys.Down Then lblBuscar.Tag = Val(lblBuscar.Tag) + 1
    If e.KeyCode <> Keys.Up Then lblBuscar.Tag = Val(lblBuscar.Tag) - 1
    If Val(lblBuscar.Tag) = 0 Then lblBuscar.Tag = 3
    If Val(lblBuscar.Tag) = 4 Then lblBuscar.Tag = 1
    Select Case Val(lblBuscar.Tag)
      Case Is = 1
        lblBuscar.Text = "Ingrese Nombre:"
        txtBuscar.MaxLength = 50
      Case Is = 2
        lblBuscar.Text = "Ingrese Categoria:"
        txtBuscar.MaxLength = 50
      Case Is = 3
        lblBuscar.Text = "Ingrese Código:"
        txtBuscar.MaxLength = 10
    End Select
  End Sub

  Private Sub dgvListado_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvListado.DoubleClickRow
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then

        Call Modificar()
      End If
    End If
  End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("codigo").Header.Caption = "ID"
      .Columns("codigo").Width = 20
      .Columns("producto").Header.Caption = "PRODUCTO"
      .Columns("producto").Width = 350
      .Columns("codigo_sub").Hidden = True
      .Columns("subcategoria").Header.Caption = "FAMILIA"
      .Columns("subcategoria").Width = 150
      .Columns("precio_com").Hidden = True
      .Columns("stock").Hidden = True
      .Columns("precio_va").Header.Caption = "VENTA"
      .Columns("precio_va").Width = 100
      .Columns("precio_va").CellAppearance.TextHAlign = HAlign.Right
      .Columns("precio_vb").Header.Caption = "VENTA MIN"
      .Columns("precio_vb").Width = 100
      .Columns("precio_vb").CellAppearance.TextHAlign = HAlign.Right
      .Columns("stock_min").Hidden = True
      .Columns("stock_max").Hidden = True
      .Columns("codigo_barras").Header.Caption = "BARRAS"
      .Columns("codigo_barras").Width = 120
      '.Columns("ubicacion").Hidden = True
    End With
  End Sub

  Private Sub tsActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsActualizar.Click
    Call ListarCondicion()
  End Sub

  Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      Call ListarCondicion()
    End If
  End Sub

  Private Sub dgvCondicion_BeforeSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvCondicion.BeforeSelectChange
    pCod_Cat = -1
    If dgvCondicion.Rows.Count > 0 Then
      If e.NewSelections.Rows.Count > 0 Then
        pCod_Cat = dgvCondicion.DisplayLayout.ActiveRow.Cells(0).Value
        Call ListarCondicion()
      End If
    End If

  End Sub

  Private Sub dgvCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvCondicion.InitializeLayout
    With dgvCondicion.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = 200
      .Columns(1).Header.Caption = "SUBCATEGORIAS"
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True

    End With
    Me.dgvCondicion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvCondicion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
  End Sub

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.Enter Then
      If dgvListado.Rows.Count > 0 Then
        Call Modificar()
      End If
    End If
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

  Private Sub tsProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsProveedor.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        FrmProducto_Proveedor.pProductoID = _codigo
        FrmProducto_Proveedor.pProducto = Trim(dgvListado.DisplayLayout.ActiveRow.Cells("producto").Value)
        FrmProducto_Proveedor.ShowDialog()
      Else
        _codigo = 0
      End If
    End If
  End Sub

  Private Sub BtnCatalogoAlm_Click(sender As Object, e As EventArgs) Handles BtnCatalogoAlm.Click
    Dim frm As New FrmCatalogo_Almacen

    Call LibreriasFormularios.Ver_Form(frm, "Catalo Alm.")
  End Sub

    Private Sub btncategoria_Click(sender As Object, e As EventArgs) Handles btncategoria.Click
        Dim frm As FrmCategorias_Sub = New FrmCategorias_Sub
        frm.swNuevo = True
        frm.ShowDialog()
    End Sub

    Private Sub btn_Banco_Click(sender As Object, e As EventArgs) Handles btn_Banco.Click
        Dim frm As FrmBancoLis = New FrmBancoLis
        frm.swNuevoBanco = True
        frm.ShowDialog()
    End Sub

    Private Sub btn_CuentaCo_Click(sender As Object, e As EventArgs) 
        Dim frm As FrmCategorias_Sub = New FrmCategorias_Sub
        frm.swNuevo = True
        frm.ShowDialog()
    End Sub

    Private Sub tsReporte_Click(sender As Object, e As EventArgs) Handles tsReporte.Click
        Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, utExcel, "Asistente.xls")
    End Sub
End Class