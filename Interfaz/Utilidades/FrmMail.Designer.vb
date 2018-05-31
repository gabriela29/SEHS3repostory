<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMail
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
    Me.components = New System.ComponentModel.Container()
    Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
    Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
    Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
    Me.UltraMaskedEdit1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
    Me.UltraListBar1 = New Infragistics.Win.UltraWinListBar.UltraListBar()
    Me.UltraTree1 = New Infragistics.Win.UltraWinTree.UltraTree()
    CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraListBar1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UltraTree1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'UltraGrid1
    '
    Appearance1.BackColor = System.Drawing.SystemColors.Window
    Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
    Me.UltraGrid1.DisplayLayout.Appearance = Appearance1
    Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
    Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
    Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
    Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
    Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
    Appearance2.BorderColor = System.Drawing.SystemColors.Window
    Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance2
    Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
    Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
    Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
    Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
    Appearance4.BackColor2 = System.Drawing.SystemColors.Control
    Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
    Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
    Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
    Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
    Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
    Appearance5.BackColor = System.Drawing.SystemColors.Window
    Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
    Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance5
    Appearance6.BackColor = System.Drawing.SystemColors.Highlight
    Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
    Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance6
    Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
    Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
    Appearance7.BackColor = System.Drawing.SystemColors.Window
    Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance7
    Appearance8.BorderColor = System.Drawing.Color.Silver
    Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
    Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance8
    Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
    Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
    Appearance9.BackColor = System.Drawing.SystemColors.Control
    Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
    Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
    Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
    Appearance9.BorderColor = System.Drawing.SystemColors.Window
    Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance9
    Appearance10.TextHAlignAsString = "Left"
    Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance10
    Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
    Appearance11.BackColor = System.Drawing.SystemColors.Window
    Appearance11.BorderColor = System.Drawing.Color.Silver
    Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance11
    Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
    Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
    Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
    Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
    Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
    Me.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
    Me.UltraGrid1.Location = New System.Drawing.Point(348, 37)
    Me.UltraGrid1.Name = "UltraGrid1"
    Me.UltraGrid1.Size = New System.Drawing.Size(275, 140)
    Me.UltraGrid1.TabIndex = 0
    Me.UltraGrid1.Text = "UltraGrid1"
    '
    'UltraMaskedEdit1
    '
    Me.UltraMaskedEdit1.Location = New System.Drawing.Point(364, 193)
    Me.UltraMaskedEdit1.Name = "UltraMaskedEdit1"
    Me.UltraMaskedEdit1.Size = New System.Drawing.Size(197, 20)
    Me.UltraMaskedEdit1.TabIndex = 1
    Me.UltraMaskedEdit1.Text = "UltraMaskedEdit1"
    '
    'UltraListBar1
    '
    Me.UltraListBar1.Location = New System.Drawing.Point(657, 48)
    Me.UltraListBar1.Name = "UltraListBar1"
    Me.UltraListBar1.Size = New System.Drawing.Size(75, 128)
    '
    'UltraTree1
    '
    Me.UltraTree1.Location = New System.Drawing.Point(769, 43)
    Me.UltraTree1.Name = "UltraTree1"
    Me.UltraTree1.Size = New System.Drawing.Size(147, 199)
    Me.UltraTree1.TabIndex = 3
    '
    'FrmMail
    '
    Me.ClientSize = New System.Drawing.Size(945, 261)
    Me.Controls.Add(Me.UltraTree1)
    Me.Controls.Add(Me.UltraListBar1)
    Me.Controls.Add(Me.UltraMaskedEdit1)
    Me.Controls.Add(Me.UltraGrid1)
    Me.Name = "FrmMail"
    CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraListBar1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UltraTree1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
  Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
  Friend WithEvents UltraMaskedEdit1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
  Friend WithEvents UltraListBar1 As Infragistics.Win.UltraWinListBar.UltraListBar
  Friend WithEvents UltraTree1 As Infragistics.Win.UltraWinTree.UltraTree
End Class
