<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsignacion_Asistente
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConsignacion_Asistente))
    Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.gpCriterios = New Infragistics.Win.Misc.UltraGroupBox()
    Me.chkRango = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
    Me.cboDesde = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.cboHasta = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
    Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
    Me.BtnMostrar = New System.Windows.Forms.Button()
    Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel()
    Me.cboAlmacen = New Infragistics.Win.UltraWinGrid.UltraCombo()
    Me.UltraPictureBox1 = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
    Me.tsActualizar_Res = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsmOperaciones = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmnAddConsignacion = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmnBoletear = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmnDevolver = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsmReportes = New System.Windows.Forms.ToolStripDropDownButton()
    Me.tsmStock_Individual = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmStock_Consolidado = New System.Windows.Forms.ToolStripMenuItem()
    Me.tsmDet_Documentos = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDSalir = New System.Windows.Forms.ToolStripButton()
    Me.picAjaxRes = New System.Windows.Forms.PictureBox()
    Me.LblDeudaTotal = New Infragistics.Win.Misc.UltraLabel()
    Me.lblRegistros_Res = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvResumen = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.UltraGroupBox6 = New Infragistics.Win.Misc.UltraGroupBox()
    Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
    Me.tsActualziar_Detalle = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsAgregar_Consignacion = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDetalle_Guia = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.tsDuplicadoGuia = New System.Windows.Forms.ToolStripButton()
    Me.picAjaxBig = New System.Windows.Forms.PictureBox()
    Me.lblTotalGuias = New Infragistics.Win.Misc.UltraLabel()
    Me.LblRegistros = New Infragistics.Win.Misc.UltraLabel()
    Me.dgvListado = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.bwLlenar_Res = New System.ComponentModel.BackgroundWorker()
    Me.bwAlmacen = New System.ComponentModel.BackgroundWorker()
    Me.bwLlenar_Detalle = New System.ComponentModel.BackgroundWorker()
    Me.cboCampania = New Infragistics.Win.UltraWinGrid.UltraCombo()
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpCriterios.SuspendLayout()
    CType(Me.chkRango, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox3.SuspendLayout()
    Me.ToolStrip1.SuspendLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.UltraGroupBox6.SuspendLayout()
    Me.ToolStrip2.SuspendLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cboCampania, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'gpCriterios
    '
    Me.gpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance1.BackColor = System.Drawing.Color.White
    Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20
    Me.gpCriterios.ContentAreaAppearance = Appearance1
    Me.gpCriterios.Controls.Add(Me.cboCampania)
    Me.gpCriterios.Controls.Add(Me.chkRango)
    Me.gpCriterios.Controls.Add(Me.cboDesde)
    Me.gpCriterios.Controls.Add(Me.cboHasta)
    Me.gpCriterios.Controls.Add(Me.UltraLabel1)
    Me.gpCriterios.Controls.Add(Me.BtnMostrar)
    Me.gpCriterios.Controls.Add(Me.UltraLabel12)
    Me.gpCriterios.Controls.Add(Me.cboAlmacen)
    Me.gpCriterios.Controls.Add(Me.UltraPictureBox1)
    Me.gpCriterios.Location = New System.Drawing.Point(-1, -2)
    Me.gpCriterios.Name = "gpCriterios"
    Me.gpCriterios.Size = New System.Drawing.Size(759, 85)
    Me.gpCriterios.TabIndex = 3
    Me.gpCriterios.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'chkRango
    '
    Appearance9.FontData.Name = "Arial"
    Appearance9.FontData.SizeInPoints = 8.0!
    Me.chkRango.Appearance = Appearance9
    Me.chkRango.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
    Me.chkRango.Location = New System.Drawing.Point(643, 23)
    Me.chkRango.Name = "chkRango"
    Me.chkRango.Size = New System.Drawing.Size(108, 18)
    Me.chkRango.TabIndex = 114
    Me.chkRango.Text = "Rango"
    '
    'cboDesde
    '
    Appearance10.FontData.BoldAsString = "True"
    Appearance10.FontData.Name = "Tahoma"
    Appearance10.FontData.SizeInPoints = 10.0!
    Me.cboDesde.Appearance = Appearance10
    Me.cboDesde.DateButtons.Add(DateButton1)
    Me.cboDesde.Location = New System.Drawing.Point(508, 23)
    Me.cboDesde.Name = "cboDesde"
    Me.cboDesde.NonAutoSizeHeight = 21
    Me.cboDesde.Size = New System.Drawing.Size(116, 22)
    Me.cboDesde.TabIndex = 113
    Me.cboDesde.Value = "20/09/2009"
    '
    'cboHasta
    '
    Appearance11.FontData.BoldAsString = "True"
    Appearance11.FontData.Name = "Tahoma"
    Appearance11.FontData.SizeInPoints = 10.0!
    Me.cboHasta.Appearance = Appearance11
    Me.cboHasta.DateButtons.Add(DateButton2)
    Me.cboHasta.Location = New System.Drawing.Point(507, 55)
    Me.cboHasta.Name = "cboHasta"
    Me.cboHasta.NonAutoSizeHeight = 21
    Me.cboHasta.Size = New System.Drawing.Size(116, 22)
    Me.cboHasta.TabIndex = 92
    Me.cboHasta.Value = "20/09/2009"
    '
    'UltraLabel1
    '
    Appearance12.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance12.ForeColor = System.Drawing.Color.SteelBlue
    Appearance12.TextVAlignAsString = "Top"
    Me.UltraLabel1.Appearance = Appearance12
    Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel1.Location = New System.Drawing.Point(58, 3)
    Me.UltraLabel1.Name = "UltraLabel1"
    Me.UltraLabel1.Size = New System.Drawing.Size(408, 28)
    Me.UltraLabel1.TabIndex = 91
    Me.UltraLabel1.Text = "Control por Asistente"
    '
    'BtnMostrar
    '
    Me.BtnMostrar.BackColor = System.Drawing.Color.Transparent
    Me.BtnMostrar.FlatAppearance.BorderSize = 0
    Me.BtnMostrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
    Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.BtnMostrar.Image = Global.Phoenix.My.Resources.Resources.Busca
    Me.BtnMostrar.Location = New System.Drawing.Point(637, 37)
    Me.BtnMostrar.Name = "BtnMostrar"
    Me.BtnMostrar.Size = New System.Drawing.Size(67, 40)
    Me.BtnMostrar.TabIndex = 89
    Me.BtnMostrar.UseVisualStyleBackColor = False
    '
    'UltraLabel12
    '
    Appearance13.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance13.ForeColor = System.Drawing.SystemColors.Desktop
    Appearance13.TextVAlignAsString = "Top"
    Me.UltraLabel12.Appearance = Appearance13
    Me.UltraLabel12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.UltraLabel12.Location = New System.Drawing.Point(61, 35)
    Me.UltraLabel12.Name = "UltraLabel12"
    Me.UltraLabel12.Size = New System.Drawing.Size(362, 15)
    Me.UltraLabel12.TabIndex = 31
    Me.UltraLabel12.Text = "    Almacén                                          Campaña"
    '
    'cboAlmacen
    '
    Appearance14.BackColor = System.Drawing.Color.LemonChiffon
    Appearance14.BackColor2 = System.Drawing.Color.White
    Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20Bright
    Me.cboAlmacen.Appearance = Appearance14
    Appearance15.BackColor = System.Drawing.Color.White
    Me.cboAlmacen.DisplayLayout.Appearance = Appearance15
    Appearance16.BackColor = System.Drawing.Color.Transparent
    Me.cboAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance16
    Appearance17.BackColor = System.Drawing.Color.White
    Appearance17.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance17.FontData.BoldAsString = "True"
    Appearance17.FontData.Name = "Arial"
    Appearance17.FontData.SizeInPoints = 10.0!
    Appearance17.ForeColor = System.Drawing.Color.White
    Appearance17.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance17
    Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance18.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.RowSelectorAppearance = Appearance18
    Appearance19.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance19.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboAlmacen.DisplayLayout.Override.SelectedRowAppearance = Appearance19
    Me.cboAlmacen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboAlmacen.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboAlmacen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboAlmacen.Location = New System.Drawing.Point(13, 54)
    Me.cboAlmacen.Name = "cboAlmacen"
    Me.cboAlmacen.Size = New System.Drawing.Size(213, 23)
    Me.cboAlmacen.TabIndex = 1
    '
    'UltraPictureBox1
    '
    Me.UltraPictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.UltraPictureBox1.BorderShadowColor = System.Drawing.Color.Empty
    Me.UltraPictureBox1.Image = CType(resources.GetObject("UltraPictureBox1.Image"), Object)
    Me.UltraPictureBox1.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.UltraPictureBox1.Location = New System.Drawing.Point(5, 5)
    Me.UltraPictureBox1.Name = "UltraPictureBox1"
    Me.UltraPictureBox1.Size = New System.Drawing.Size(54, 54)
    Me.UltraPictureBox1.TabIndex = 6
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 87)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.UltraGroupBox3)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.UltraGroupBox6)
    Me.SplitContainer1.Size = New System.Drawing.Size(758, 342)
    Me.SplitContainer1.SplitterDistance = 379
    Me.SplitContainer1.TabIndex = 8
    '
    'UltraGroupBox3
    '
    Me.UltraGroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox3.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance20.BackColor = System.Drawing.Color.White
    Appearance20.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox3.ContentAreaAppearance = Appearance20
    Me.UltraGroupBox3.Controls.Add(Me.ToolStrip1)
    Me.UltraGroupBox3.Controls.Add(Me.picAjaxRes)
    Me.UltraGroupBox3.Controls.Add(Me.LblDeudaTotal)
    Me.UltraGroupBox3.Controls.Add(Me.lblRegistros_Res)
    Me.UltraGroupBox3.Controls.Add(Me.dgvResumen)
    Me.UltraGroupBox3.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox3.Name = "UltraGroupBox3"
    Me.UltraGroupBox3.Size = New System.Drawing.Size(373, 336)
    Me.UltraGroupBox3.TabIndex = 6
    Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'ToolStrip1
    '
    Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
    Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualizar_Res, Me.ToolStripSeparator9, Me.tsmOperaciones, Me.ToolStripSeparator3, Me.tsmReportes, Me.ToolStripSeparator11, Me.tsDSalir})
    Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
    Me.ToolStrip1.Name = "ToolStrip1"
    Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip1.Size = New System.Drawing.Size(367, 25)
    Me.ToolStrip1.TabIndex = 89
    Me.ToolStrip1.Text = "ToolStrip2"
    '
    'tsActualizar_Res
    '
    Me.tsActualizar_Res.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsActualizar_Res.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsActualizar_Res.Name = "tsActualizar_Res"
    Me.tsActualizar_Res.Size = New System.Drawing.Size(79, 22)
    Me.tsActualizar_Res.Text = "&Actualizar"
    Me.tsActualizar_Res.ToolTipText = "Actualiza el Resumen"
    '
    'ToolStripSeparator9
    '
    Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
    Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
    '
    'tsmOperaciones
    '
    Me.tsmOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmnAddConsignacion, Me.tsmnBoletear, Me.tsmnDevolver})
    Me.tsmOperaciones.Image = Global.Phoenix.My.Resources.Resources.kservices
    Me.tsmOperaciones.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsmOperaciones.Name = "tsmOperaciones"
    Me.tsmOperaciones.Size = New System.Drawing.Size(83, 22)
    Me.tsmOperaciones.Text = "Procesos"
    '
    'tsmnAddConsignacion
    '
    Me.tsmnAddConsignacion.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsmnAddConsignacion.Name = "tsmnAddConsignacion"
    Me.tsmnAddConsignacion.Size = New System.Drawing.Size(192, 22)
    Me.tsmnAddConsignacion.Text = "Agregar Consignación"
    '
    'tsmnBoletear
    '
    Me.tsmnBoletear.BackColor = System.Drawing.Color.White
    Me.tsmnBoletear.Image = Global.Phoenix.My.Resources.Resources.accept
    Me.tsmnBoletear.Name = "tsmnBoletear"
    Me.tsmnBoletear.Size = New System.Drawing.Size(192, 22)
    Me.tsmnBoletear.Text = "Boletear"
    '
    'tsmnDevolver
    '
    Me.tsmnDevolver.BackColor = System.Drawing.Color.White
    Me.tsmnDevolver.Image = Global.Phoenix.My.Resources.Resources.agt_reload16
    Me.tsmnDevolver.Name = "tsmnDevolver"
    Me.tsmnDevolver.Size = New System.Drawing.Size(192, 22)
    Me.tsmnDevolver.Text = "Devolver"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
    '
    'tsmReportes
    '
    Me.tsmReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmStock_Individual, Me.tsmStock_Consolidado, Me.tsmDet_Documentos})
    Me.tsmReportes.Image = Global.Phoenix.My.Resources.Resources.demo
    Me.tsmReportes.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsmReportes.Name = "tsmReportes"
    Me.tsmReportes.Size = New System.Drawing.Size(82, 22)
    Me.tsmReportes.Text = "&Reportes"
    '
    'tsmStock_Individual
    '
    Me.tsmStock_Individual.BackColor = System.Drawing.Color.White
    Me.tsmStock_Individual.Name = "tsmStock_Individual"
    Me.tsmStock_Individual.Size = New System.Drawing.Size(181, 22)
    Me.tsmStock_Individual.Text = "Estock Individual"
    '
    'tsmStock_Consolidado
    '
    Me.tsmStock_Consolidado.BackColor = System.Drawing.Color.White
    Me.tsmStock_Consolidado.Name = "tsmStock_Consolidado"
    Me.tsmStock_Consolidado.Size = New System.Drawing.Size(181, 22)
    Me.tsmStock_Consolidado.Text = "Stock Consolidado"
    '
    'tsmDet_Documentos
    '
    Me.tsmDet_Documentos.BackColor = System.Drawing.Color.White
    Me.tsmDet_Documentos.Name = "tsmDet_Documentos"
    Me.tsmDet_Documentos.Size = New System.Drawing.Size(181, 22)
    Me.tsmDet_Documentos.Text = "Detalle Documentos"
    Me.tsmDet_Documentos.Visible = False
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
    '
    'tsDSalir
    '
    Me.tsDSalir.Image = CType(resources.GetObject("tsDSalir.Image"), System.Drawing.Image)
    Me.tsDSalir.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDSalir.Name = "tsDSalir"
    Me.tsDSalir.Size = New System.Drawing.Size(59, 22)
    Me.tsDSalir.Text = "&Cerrar"
    Me.tsDSalir.ToolTipText = "Cerrar Ventana"
    '
    'picAjaxRes
    '
    Me.picAjaxRes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxRes.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxRes.Image = CType(resources.GetObject("picAjaxRes.Image"), System.Drawing.Image)
    Me.picAjaxRes.Location = New System.Drawing.Point(3, 28)
    Me.picAjaxRes.Name = "picAjaxRes"
    Me.picAjaxRes.Size = New System.Drawing.Size(366, 272)
    Me.picAjaxRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxRes.TabIndex = 84
    Me.picAjaxRes.TabStop = False
    Me.picAjaxRes.Visible = False
    '
    'LblDeudaTotal
    '
    Me.LblDeudaTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance21.BackColor = System.Drawing.Color.LemonChiffon
    Appearance21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance21.TextHAlignAsString = "Right"
    Appearance21.TextVAlignAsString = "Middle"
    Me.LblDeudaTotal.Appearance = Appearance21
    Me.LblDeudaTotal.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.LblDeudaTotal.Location = New System.Drawing.Point(119, 312)
    Me.LblDeudaTotal.Name = "LblDeudaTotal"
    Me.LblDeudaTotal.Size = New System.Drawing.Size(145, 17)
    Me.LblDeudaTotal.TabIndex = 87
    Me.LblDeudaTotal.Text = "0.00"
    '
    'lblRegistros_Res
    '
    Me.lblRegistros_Res.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance22.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance22.TextHAlignAsString = "Right"
    Appearance22.TextVAlignAsString = "Middle"
    Me.lblRegistros_Res.Appearance = Appearance22
    Me.lblRegistros_Res.Location = New System.Drawing.Point(6, 313)
    Me.lblRegistros_Res.Name = "lblRegistros_Res"
    Me.lblRegistros_Res.Size = New System.Drawing.Size(107, 14)
    Me.lblRegistros_Res.TabIndex = 86
    Me.lblRegistros_Res.Text = "-"
    '
    'dgvResumen
    '
    Me.dgvResumen.AllowDrop = True
    Me.dgvResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance23.BackColor = System.Drawing.Color.White
    Me.dgvResumen.DisplayLayout.Appearance = Appearance23
    Me.dgvResumen.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
    Me.dgvResumen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvResumen.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
    Appearance24.BackColor = System.Drawing.Color.Transparent
    Me.dgvResumen.DisplayLayout.Override.CardAreaAppearance = Appearance24
    Me.dgvResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
    Appearance25.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(150, Byte), Integer))
    Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance25.FontData.BoldAsString = "True"
    Appearance25.FontData.Name = "Arial"
    Appearance25.FontData.SizeInPoints = 10.0!
    Appearance25.ForeColor = System.Drawing.Color.White
    Appearance25.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.dgvResumen.DisplayLayout.Override.HeaderAppearance = Appearance25
    Me.dgvResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Appearance26.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance26.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.RowSelectorAppearance = Appearance26
    Appearance27.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance27.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.dgvResumen.DisplayLayout.Override.SelectedRowAppearance = Appearance27
    Me.dgvResumen.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    Me.dgvResumen.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
    Me.dgvResumen.Location = New System.Drawing.Point(6, 28)
    Me.dgvResumen.Name = "dgvResumen"
    Me.dgvResumen.Size = New System.Drawing.Size(359, 278)
    Me.dgvResumen.TabIndex = 85
    '
    'UltraGroupBox6
    '
    Me.UltraGroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.UltraGroupBox6.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
    Appearance28.BackColor = System.Drawing.Color.White
    Appearance28.BackColor2 = System.Drawing.Color.White
    Me.UltraGroupBox6.ContentAreaAppearance = Appearance28
    Me.UltraGroupBox6.Controls.Add(Me.ToolStrip2)
    Me.UltraGroupBox6.Controls.Add(Me.picAjaxBig)
    Me.UltraGroupBox6.Controls.Add(Me.lblTotalGuias)
    Me.UltraGroupBox6.Controls.Add(Me.LblRegistros)
    Me.UltraGroupBox6.Controls.Add(Me.dgvListado)
    Me.UltraGroupBox6.Location = New System.Drawing.Point(3, 3)
    Me.UltraGroupBox6.Name = "UltraGroupBox6"
    Me.UltraGroupBox6.Size = New System.Drawing.Size(369, 336)
    Me.UltraGroupBox6.TabIndex = 5
    Me.UltraGroupBox6.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
    '
    'ToolStrip2
    '
    Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
    Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsActualziar_Detalle, Me.ToolStripSeparator1, Me.tsAgregar_Consignacion, Me.ToolStripSeparator2, Me.tsDetalle_Guia, Me.ToolStripSeparator4, Me.tsDuplicadoGuia})
    Me.ToolStrip2.Location = New System.Drawing.Point(3, 0)
    Me.ToolStrip2.Name = "ToolStrip2"
    Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
    Me.ToolStrip2.Size = New System.Drawing.Size(363, 25)
    Me.ToolStrip2.TabIndex = 92
    Me.ToolStrip2.Text = "ToolStrip2"
    '
    'tsActualziar_Detalle
    '
    Me.tsActualziar_Detalle.Image = Global.Phoenix.My.Resources.Resources.lightning
    Me.tsActualziar_Detalle.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsActualziar_Detalle.Name = "tsActualziar_Detalle"
    Me.tsActualziar_Detalle.Size = New System.Drawing.Size(79, 22)
    Me.tsActualziar_Detalle.Text = "&Actualizar"
    Me.tsActualziar_Detalle.ToolTipText = "Actualiza el Detalle"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'tsAgregar_Consignacion
    '
    Me.tsAgregar_Consignacion.Image = Global.Phoenix.My.Resources.Resources.add
    Me.tsAgregar_Consignacion.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsAgregar_Consignacion.Name = "tsAgregar_Consignacion"
    Me.tsAgregar_Consignacion.Size = New System.Drawing.Size(69, 22)
    Me.tsAgregar_Consignacion.Text = "A&gregar"
    Me.tsAgregar_Consignacion.ToolTipText = "Agregar Consignación Colportaje"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'tsDetalle_Guia
    '
    Me.tsDetalle_Guia.Image = Global.Phoenix.My.Resources.Resources.monitor
    Me.tsDetalle_Guia.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDetalle_Guia.Name = "tsDetalle_Guia"
    Me.tsDetalle_Guia.Size = New System.Drawing.Size(90, 22)
    Me.tsDetalle_Guia.Text = "Detalle Guia"
    Me.tsDetalle_Guia.ToolTipText = "Mostrar el Detalle de la Guia"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
    '
    'tsDuplicadoGuia
    '
    Me.tsDuplicadoGuia.Image = Global.Phoenix.My.Resources.Resources.printer
    Me.tsDuplicadoGuia.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.tsDuplicadoGuia.Name = "tsDuplicadoGuia"
    Me.tsDuplicadoGuia.Size = New System.Drawing.Size(81, 22)
    Me.tsDuplicadoGuia.Text = "Duplicado"
    '
    'picAjaxBig
    '
    Me.picAjaxBig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.picAjaxBig.BackColor = System.Drawing.Color.Transparent
    Me.picAjaxBig.Image = CType(resources.GetObject("picAjaxBig.Image"), System.Drawing.Image)
    Me.picAjaxBig.Location = New System.Drawing.Point(5, 30)
    Me.picAjaxBig.Name = "picAjaxBig"
    Me.picAjaxBig.Size = New System.Drawing.Size(359, 269)
    Me.picAjaxBig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.picAjaxBig.TabIndex = 84
    Me.picAjaxBig.TabStop = False
    Me.picAjaxBig.Visible = False
    '
    'lblTotalGuias
    '
    Me.lblTotalGuias.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Appearance29.BackColor = System.Drawing.Color.LemonChiffon
    Appearance29.BackHatchStyle = Infragistics.Win.BackHatchStyle.OutlinedDiamond
    Appearance29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
    Appearance29.TextHAlignAsString = "Right"
    Appearance29.TextVAlignAsString = "Middle"
    Me.lblTotalGuias.Appearance = Appearance29
    Me.lblTotalGuias.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
    Me.lblTotalGuias.Location = New System.Drawing.Point(47, 313)
    Me.lblTotalGuias.Name = "lblTotalGuias"
    Me.lblTotalGuias.Size = New System.Drawing.Size(100, 17)
    Me.lblTotalGuias.TabIndex = 90
    Me.lblTotalGuias.Text = "0.00"
    '
    'LblRegistros
    '
    Me.LblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Appearance30.BackColorAlpha = Infragistics.Win.Alpha.Transparent
    Appearance30.ForeColor = System.Drawing.Color.LightSteelBlue
    Appearance30.TextVAlignAsString = "Middle"
    Me.LblRegistros.Appearance = Appearance30
    Me.LblRegistros.Location = New System.Drawing.Point(5, 313)
    Me.LblRegistros.Name = "LblRegistros"
    Me.LblRegistros.Size = New System.Drawing.Size(107, 14)
    Me.LblRegistros.TabIndex = 79
    Me.LblRegistros.Text = "-"
    '
    'dgvListado
    '
    Me.dgvListado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
    Me.dgvListado.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
    Me.dgvListado.Location = New System.Drawing.Point(5, 30)
    Me.dgvListado.Name = "dgvListado"
    Me.dgvListado.Size = New System.Drawing.Size(360, 274)
    Me.dgvListado.TabIndex = 17
    Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    '
    'bwLlenar_Res
    '
    '
    'bwLlenar_Detalle
    '
    '
    'cboCampania
    '
    Appearance2.BackColor = System.Drawing.Color.LemonChiffon
    Me.cboCampania.Appearance = Appearance2
    Appearance3.FontData.BoldAsString = "True"
    Appearance3.FontData.Name = "Tahoma"
    Appearance3.ForeColor = System.Drawing.Color.Red
    Appearance3.TextHAlignAsString = "Right"
    Me.cboCampania.ButtonAppearance = Appearance3
    Appearance4.BackColor = System.Drawing.Color.White
    Me.cboCampania.DisplayLayout.Appearance = Appearance4
    Appearance5.BackColor = System.Drawing.Color.Transparent
    Me.cboCampania.DisplayLayout.Override.CardAreaAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.Color.White
    Appearance6.BackColor2 = System.Drawing.Color.CornflowerBlue
    Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance6.FontData.BoldAsString = "True"
    Appearance6.FontData.Name = "Arial"
    Appearance6.FontData.SizeInPoints = 10.0!
    Appearance6.ForeColor = System.Drawing.Color.White
    Appearance6.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
    Me.cboCampania.DisplayLayout.Override.HeaderAppearance = Appearance6
    Appearance7.BackColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(191, Byte), Integer))
    Appearance7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(112, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(145, Byte), Integer))
    Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboCampania.DisplayLayout.Override.RowSelectorAppearance = Appearance7
    Appearance8.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(148, Byte), Integer))
    Appearance8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(21, Byte), Integer))
    Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Me.cboCampania.DisplayLayout.Override.SelectedRowAppearance = Appearance8
    Me.cboCampania.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
    Me.cboCampania.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
    Me.cboCampania.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cboCampania.Location = New System.Drawing.Point(232, 53)
    Me.cboCampania.Name = "cboCampania"
    Me.cboCampania.Size = New System.Drawing.Size(234, 25)
    Me.cboCampania.TabIndex = 115
    '
    'FrmConsignacion_Asistente
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(758, 431)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Controls.Add(Me.gpCriterios)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.KeyPreview = True
    Me.Name = "FrmConsignacion_Asistente"
    Me.Text = "Consignacion Asistente"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.gpCriterios, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpCriterios.ResumeLayout(False)
    Me.gpCriterios.PerformLayout()
    CType(Me.chkRango, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboDesde, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboHasta, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox3.ResumeLayout(False)
    Me.UltraGroupBox3.PerformLayout()
    Me.ToolStrip1.ResumeLayout(False)
    Me.ToolStrip1.PerformLayout()
    CType(Me.picAjaxRes, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvResumen, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraGroupBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.UltraGroupBox6.ResumeLayout(False)
    Me.UltraGroupBox6.PerformLayout()
    Me.ToolStrip2.ResumeLayout(False)
    Me.ToolStrip2.PerformLayout()
    CType(Me.picAjaxBig, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cboCampania, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gpCriterios As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboAlmacen As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraPictureBox1 As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxRes As System.Windows.Forms.PictureBox
    Friend WithEvents LblDeudaTotal As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblRegistros_Res As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvResumen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox6 As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents picAjaxBig As System.Windows.Forms.PictureBox
    Friend WithEvents lblTotalGuias As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblRegistros As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvListado As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents bwLlenar_Res As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwAlmacen As System.ComponentModel.BackgroundWorker
    Friend WithEvents bwLlenar_Detalle As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsActualziar_Detalle As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsActualizar_Res As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAgregar_Consignacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDetalle_Guia As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmReportes As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmStock_Individual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmStock_Consolidado As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDet_Documentos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboHasta As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents tsmOperaciones As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmnAddConsignacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmnBoletear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmnDevolver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsDuplicadoGuia As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkRango As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents cboDesde As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
  Friend WithEvents cboCampania As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
