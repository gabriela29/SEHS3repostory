
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Infragistics.Excel

Public Class FrmKardex
    Public pCodigo As Long = 0, pNombre As String = ""

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
          .SelectedRow = .GetRow(ChildRow.First)
        End If

            End With

            Dim lMeses As New ClsCrearMeses
            With cboAnio
                .DataSource = Nothing
                .DataSource = lMeses.GetList_anios()
                .Refresh()
                .ValueMember = "nombre"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call Exportar_Excel()
    End Sub

    Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "Kardex1.xls")
  End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub FrmKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call llenar_combos()
        Call formatear_grid()
        If pCodigo > 0 Then
            lblProducto.Tag = pCodigo
            lblProducto.Text = pNombre
        End If
        cboAnio.Text = Year(Date.Now)
    End Sub

    Private Sub btnLista_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLista_Producto.Click
        Dim testDialog As New FrmConsulta_Productos

        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.lblProducto.Tag = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            Me.lblProducto.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(1).Value)
        Else
            lblProducto.Text = ""
            lblProducto.Tag = 0
        End If
        testDialog.Dispose()
    End Sub

    Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
        CheckForIllegalCrossThreadCalls = False

        Try
            Dim dtKardex As New DataTable

            dtKardex = productoManager.Consultar_Kardex(lblProducto.Tag, cboAlmacen.Value, cboAnio.Value)

            e.Result = dtKardex

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwListado_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwListado.RunWorkerCompleted
        'dgvListado.DataSource = CType(e.Result, DataTable)
        'If dgvListado.Rows.Count() > 0 Then
        '    dgvListado.Rows(0).Selected = True
        '    dgvListado.Focus()
        'End If
        Call LlenarRsKardexPROMEDIO(CType(e.Result, DataTable))
        'Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjaxBig.Visible = False
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If Not bwListado.IsBusy Then
            picAjaxBig.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub LlenarRsKardexPROMEDIO(ByRef dt As DataTable)
        Try
            'DBGrid1.Groups("totales").Visible = False
            'DBGrid1.Columns("totales").Visible = False
            If Not dt.Rows.Count > 0 Then Exit Sub
            Dim DtTmp As New DataTable, vCount As Long = 0
            Dim Drs As DataRow
            Dim NwRow As DataRow
            Dim dtKadex As New DataTable

            Dim TotalSaldo As Single, CantSaldo As Single, PreSaldo As Single
            dtKadex = ClsTablitas.Crear_Grid_Kardex("kardex")
            DtTmp = dt
            For Each Drs In DtTmp.Rows
                If vCount = 0 Then
                    NwRow = dtKadex.NewRow
                    NwRow.Item("fecha") = CDate(Drs("fecha"))
                    NwRow.Item("Num_Doc") = Trim(Drs("numero"))
                    NwRow.Item("Tipo") = Val(Drs("tipo"))
                    NwRow.Item("detalle") = Trim(Drs("nombre_persona"))
                    NwRow.Item("Cantcompra") = Val(Drs("cantidad_ingreso"))
                    NwRow.Item("precompra") = Val(Drs("precio_ingreso"))
                    NwRow.Item("totcompra") = Val(Drs("total_ingreso"))
                    NwRow.Item("Cantventa") = Val(Drs("cantidad_salida"))
                    NwRow.Item("preventa") = Val(Drs("precio_salida"))
                    NwRow.Item("totventa") = Val(Drs("total_salida"))
                    If Val(Drs("tipo")) = 0 Then 'Compra
                        NwRow.Item("CantSaldo") = Trim(Str(Val(Drs("cantidad_ingreso"))))
                        NwRow.Item("PreSaldo") = Trim(Str(Val(Drs("precio_ingreso"))))
                        NwRow.Item("totsaldo") = Trim(Str(Val(Drs("total_ingreso"))))
                        CantSaldo = Val(Drs("cantidad_ingreso"))
                        PreSaldo = Val(Drs("precio_ingreso"))
                        TotalSaldo = Val(Drs("total_ingreso"))
                    Else 'Venta
                        NwRow.Item("CantSaldo") = Trim(Str(0 - Val(Drs("cantidad_salida"))))
                        NwRow.Item("PreSaldo") = Trim(Str(Val(Drs("precio_salida"))))
                        NwRow.Item("totsaldo") = Trim(Str(Val(Drs("total_salida"))))
                        CantSaldo = 0 - Val(Drs("cantidad_salida"))
                        PreSaldo = 0 - Val(Drs("precio_salida"))
                        TotalSaldo = 0 - Val(Drs("total_salida"))
                    End If
                    NwRow.Item("ref") = Trim(Drs("ref"))
                    NwRow.Item("codigo") = Trim(Drs("codigo"))
                    dtKadex.Rows.Add(NwRow)

                End If
                If vCount >= 1 Then
                    NwRow = dtKadex.NewRow
                    NwRow.Item("fecha") = CDate(Drs("fecha"))
                    NwRow.Item("Num_Doc") = Trim(Drs("numero"))
                    NwRow.Item("Tipo") = Val(Drs("tipo"))
                    NwRow.Item("detalle") = Trim(Drs("nombre_persona"))
                    NwRow.Item("Cantcompra") = Val(Drs("cantidad_ingreso"))
                    NwRow.Item("precompra") = Val(Drs("precio_ingreso"))
                    NwRow.Item("totcompra") = Val(Drs("total_ingreso"))
                    NwRow.Item("Cantventa") = Val(Drs("cantidad_salida"))
                    NwRow.Item("preventa") = Val(Drs("precio_salida"))
                    NwRow.Item("totventa") = Val(Drs("total_salida"))
                    NwRow.Item("ref") = Trim(Drs("ref"))
                    NwRow.Item("codigo") = Trim(Drs("codigo"))
                    If Val(Drs!Tipo) = 0 Then 'Compra
                        CantSaldo = CantSaldo + Val(Drs("cantidad_ingreso"))
                        If CantSaldo <> 0 Then
                            PreSaldo = (TotalSaldo + Val(Drs("total_ingreso"))) / CantSaldo
                        Else
                            PreSaldo = 0
                        End If
                        TotalSaldo = CantSaldo * PreSaldo
                    Else 'Venta
                        CantSaldo = CantSaldo - Val(Drs("cantidad_salida"))
                        If CantSaldo <> 0 Then
                            '***************
                            '***************
                            '*************** presaldo
                            PreSaldo = PreSaldo
                        Else
                            PreSaldo = 0
                        End If
                        TotalSaldo = CantSaldo * PreSaldo
                    End If
                    NwRow.Item("CantSaldo") = Trim(Str(CantSaldo))
                    NwRow.Item("PreSaldo") = Trim(Str(PreSaldo))
                    NwRow.Item("totsaldo") = Trim(Str(TotalSaldo))
                    dtKadex.Rows.Add(NwRow)
                End If
                vCount += 1
            Next
            dgvListado.DataSource = dtKadex
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

      
    End Sub

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout

    ''Dim band As UltraGridBand = Me.dgvListado.DisplayLayout.Bands(0)
    ''Dim Entradas As UltraGridGroup = Nothing
    ''Dim Salidas As UltraGridGroup = Nothing
    ''Dim Saldos As UltraGridGroup = Nothing

    ' '' Clear existing groups if any.
    ''band.Groups.Clear()

    ' '' Add two groups with two different keys. First arguement to the Add call is
    ' '' the key and the second arguement is the caption of the group.
    ''Entradas = band.Groups.Add("Entradas", "ENTRADAS")
    ''Salidas = band.Groups.Add("Salidas", "SALIDAS")
    ''Saldos = band.Groups.Add("Saldos", "SALDOS")

    ' '' If you don't want group headers displayed, set this to false. By default 
    ' '' it's true.
    ''band.GroupHeadersVisible = False

    ' '' Set the LevelCount to desired number of levels. Level 0 is the first row in
    ' '' the group, while level 1 is the second row in the group and so on. Here we 
    ' '' are going to have 2 levels.
    ''band.LevelCount = 2

    ' '' Add ContactName column to the first level (level 0) of group1 with visible 
    ' '' position of 0 (meaning it will appear first in that level. There is only 
    ' '' one header in this particular level level anyways.)
    ''Entradas.Columns.Add(band.Columns("CantCompra"), 0, 0)

    ' '' Add City column to second level (level 1) with visible position of 0. And 
    ' '' also add the Country column to the same level with the visible position of 
    ' '' 1 so that it appears after City column.
    ''Entradas.Columns.Add(band.Columns("PreCompra"), 0, 1)
    ''Entradas.Columns.Add(band.Columns("TotCompra"), 1, 1)

    ' '' Add Fax and Phone columns to group2 on different levels.
    ''Salidas.Columns.Add(band.Columns("CantVenta"), 0, 0)
    ''Salidas.Columns.Add(band.Columns("PreVenta"), 0, 1)
    ''Salidas.Columns.Add(band.Columns("TotVenta"), 0, 1)

    ' '' Add Fax and Phone columns to group2 on different levels.
    ''Saldos.Columns.Add(band.Columns("CantSaldo"), 0, 0)
    ''Saldos.Columns.Add(band.Columns("PreSaldo"), 0, 1)
    ''Saldos.Columns.Add(band.Columns("TotSaldo"), 0, 1)

    ' '' Prevet the users from moving groups and columns by setting AllowGroupMoving 
    ' '' and AllowColMoving to NotAllowed.
    ''band.Override.AllowGroupMoving = AllowGroupMoving.NotAllowed
    ''band.Override.AllowColMoving = AllowColMoving.NotAllowed

    ' '' One could change the various properties like RowSpacingAfter and 
    ' '' BorderStyleRow on the Override change the appearance.
    ''band.Override.RowSpacingAfter = 5
    ''band.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Raised

    Dim group0 = New UltraGridGroup("Datos", 0) ' key + unique id  
    Dim group1 = New UltraGridGroup("Entradas", 1) ' key + unique id  
    Dim group2 = New UltraGridGroup("Salidas", 2)
    Dim group3 = New UltraGridGroup("Saldos", 3)

    dgvListado.DisplayLayout.Bands(0).Groups.Clear()

    ' Add Groups to BAND  
    dgvListado.DisplayLayout.Bands(0).Groups.Add(group0)
    dgvListado.DisplayLayout.Bands(0).Groups.Add(group1)
    dgvListado.DisplayLayout.Bands(0).Groups.Add(group2)
    dgvListado.DisplayLayout.Bands(0).Groups.Add(group3)
    ' *** Assign columns to groups **  

    ' option 1 Through gropus Columns  
    group0.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("Fecha"))
    group0.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("num_doc"))
    group0.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("Detalle"))

    group1.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("CantCompra"))
    group1.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("PreCompra"))
    group1.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("TotCompra"))

    group2.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("CantVenta"))
    group2.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("PreVenta"))
    group2.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("TotVenta"))

    group3.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("CantSaldo"))
    group3.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("PreSaldo"))
    group3.Columns.Add(dgvListado.DisplayLayout.Bands(0).Columns("TotSaldo"))

    With dgvListado.DisplayLayout.Bands(0)
      .Columns("fecha").Header.Caption = "Fecha"
      .Columns("fecha").Width = 80
      .Columns("num_doc").Header.Caption = "Documento"
      .Columns("num_doc").Width = 120
      .Columns("tipo").Hidden = True
      .Columns("Detalle").Header.Caption = "Detalle"
      .Columns("Detalle").Width = 180

      .Columns("CantCompra").Header.Caption = "CANT"
      .Columns("CantCompra").CellAppearance.TextHAlign = HAlign.Right
      .Columns("PreCompra").Header.Caption = "PRECIO"
      .Columns("PreCompra").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotCompra").Header.Caption = "IMPORTE"
      .Columns("TotCompra").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotCompra").Width = 80

      .Columns("CantVenta").Header.Caption = "CANT"
      .Columns("CantVenta").CellAppearance.TextHAlign = HAlign.Right
      .Columns("PreVenta").Header.Caption = "PRECIO"
      .Columns("PreVenta").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotVenta").Header.Caption = "IMPORTE"
      .Columns("TotVenta").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotVenta").Width = 80

      .Columns("CantSaldo").Header.Caption = "CANT"
      .Columns("CantSaldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("CantSaldo").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("PreSaldo").Header.Caption = "PRECIO"
      .Columns("PreSaldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotSaldo").Header.Caption = "IMPORTE"
      .Columns("TotSaldo").CellAppearance.TextHAlign = HAlign.Right
      .Columns("TotSaldo").Width = 80

      .Columns("Totales").Hidden = True
      .Columns("ref").Hidden = True
      .Columns("codigo").Hidden = True
    End With


    Me.dgvListado.DisplayLayout.Override.SelectTypeRow = SelectType.[Single]
    Me.dgvListado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

  End Sub

  Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles dgvListado.InitializeRow
    If e.Row.Band Is Me.dgvListado.DisplayLayout.Bands(0) Then
      If e.Row.Cells("CantVenta").Value > 0 Then
        e.Row.Cells("PreVenta").Value = e.Row.Cells("PreSaldo").Value
        e.Row.Cells("TotVenta").Value = (e.Row.Cells("CantVenta").Value * e.Row.Cells("PreVenta").Value)
      End If
    End If
  End Sub


  Private Sub formatear_grid()
    Dim Appearance1 As Appearance = New Appearance
    Dim Appearance62 As Appearance = New Appearance
    Dim Appearance63 As Appearance = New Appearance
    Dim Appearance64 As Appearance = New Appearance
    'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
    Me.dgvListado.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
    Me.dgvListado.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    'Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    Me.dgvListado.DisplayLayout.Override.AllowColMoving = AllowColMoving.NotAllowed
    Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
    Me.dgvListado.DisplayLayout.CaptionVisible = DefaultableBoolean.[False]

    Appearance1.AlphaLevel = 90
        Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance1.BackColorAlpha = Alpha.UseAlphaLevel
    'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    ''Appearance1.BorderAlpha = Alpha.Opaque

    'Appearance1.BackColor = Color.White
    Appearance1.ImageBackgroundStyle = ImageBackgroundStyle.Centered
    If System.IO.File.Exists(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif") Then
            Appearance1.ImageBackground = Image.FromFile(IO.Directory.GetCurrentDirectory.ToString & "\transparencia.gif")   'Image.FromFile(IO.Directory.GetCurrentDirectory.ToString) 'Global.Cliente.My.Resources.Resources.logoeduadv  'foto_e_commerce_1
        End If

        Me.dgvListado.DisplayLayout.Appearance = Appearance1

        Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
        Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        Appearance62.BackColor = Color.RoyalBlue   'System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        Appearance62.BackColor2 = Color.LightCyan   'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance62.BackGradientStyle = GradientStyle.Vertical
    'Appearance62.FontData.BoldAsString = "True"
    Appearance62.FontData.Name = "Tahoma"
        Appearance62.FontData.SizeInPoints = 10.0!
    Appearance62.ForeColor = Color.Blue
    Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

        Appearance63.BackColor = System.Drawing.Color.SteelBlue
        Appearance63.BackColor2 = System.Drawing.Color.LightCyan
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance63.ThemedElementAlpha = Alpha.UseAlphaLevel
        Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Default

        ''Appearance64.BackColor = System.Drawing.Color.White
        Appearance64.BackColor = System.Drawing.Color.LightSteelBlue
        'Appearance64.BackColor2 = System.Drawing.Color.White
        'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical        
        'Appearance64.FontData.BoldAsString = "True"
        Appearance64.ForeColor = Color.Navy
        'Appearance64.ForeColor = Color.White
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid

        ''Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        'para Seleccionar solo una Fila
        'Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
        'Para seleccionar toda la Fila
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        'Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    End Sub



    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        'Me.ultraGridDocumentExporter1.Export(Me.ultraGrid1, "grid.pdf", GridExportFileFormat.PDF)
    End Sub
End Class