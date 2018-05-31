
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Telerik.WinControls.UI

Public Class FrmGestion_Acceso
    Public ListadoRegistros As DataTable

    Private Sub LoadMenu(dtPMenu As DataTable)
        Dim index As Integer = 0
        Dim watch As Stopwatch = Stopwatch.StartNew()

        Dim FilterP As String = "padre = 0 "
        Dim dvP As DataView, dtRowP As DataRowView
        If Not dtPMenu Is Nothing Then
            dvP = New DataView(dtPMenu, FilterP, "", DataViewRowState.CurrentRows)

        Else
            Me.TMenu.Nodes.Clear()
            Exit Sub
        End If

        Using Me.TMenu.DeferRefresh()
            Me.TMenu.Nodes.Clear()
            For Each dtRowP In dvP
                index += 1

                Dim node As New RadTreeNode '(dtRowP.Item("titulo").ToString, My.Resources.application_home, IIf(index = 1, True, False))
                node.Value = dtRowP.Item("menuwindowid")
                node.Text = dtRowP.Item("titulo").ToString
                node.Image = My.Resources.application_view_tile
                'node.Nodes.Add(node)

                Dim FilterH As String = "padre = " & dtRowP.Item("menuwindowid").ToString
                Dim dvH As DataView, dtRowH As DataRowView


                dvH = New DataView(dtPMenu, FilterH, "", DataViewRowState.CurrentRows)


                For Each dtRowH In dvH
                    Dim child As New RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)
                    child.Value = dtRowH.Item("menuwindowid")
                    child.Text = dtRowH.Item("titulo")
                    child.Checked = IIf(Boolean.Parse(dtRowH.Item(3)), True, False)
                    child.Image = My.Resources.page_add
                    node.Nodes.Add(child)
                Next

                Me.TMenu.Nodes.Add(node)
            Next
        End Using
        watch.[Stop]()
        Me.TMenu.ExpandAll()

        'Me.radProgressBar1.Value1 = 50000
        'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
    End Sub

    Private Sub LoadModulos(dtModEmp As DataTable)
        Dim index As Integer = 0
        Dim watch As Stopwatch = Stopwatch.StartNew()

        Dim FilterP As String = "padre = 0 "
        Dim dvP As DataView, dtRowP As DataRowView
        If Not dtModEmp Is Nothing Then
            dvP = New DataView(dtModEmp, FilterP, "", DataViewRowState.CurrentRows)

        Else
            Me.TModulos.Nodes.Clear()
            Exit Sub
        End If

        Using Me.TModulos.DeferRefresh()
            Me.TModulos.Nodes.Clear()
            For Each dtRowP In dvP
                index += 1

                Dim node As New RadTreeNode '(dtRowP.Item("titulo").ToString, My.Resources.application_home, IIf(index = 1, True, False))
                node.Value = dtRowP.Item("codigo")
                node.Text = dtRowP.Item("nombre").ToString
                node.Image = My.Resources.application_home

                Dim FilterH As String = "padre = " & dtRowP.Item("codigo").ToString
                Dim dvH As DataView, dtRowH As DataRowView

                dvH = New DataView(dtModEmp, FilterH, "", DataViewRowState.CurrentRows)


                For Each dtRowH In dvH
                    Dim child As New RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)
                    child.Value = dtRowH.Item("codigo")
                    child.Text = dtRowH.Item("nombre")
                    child.Checked = IIf(Boolean.Parse(dtRowH.Item(3)), True, False)
                    child.Image = My.Resources.application_view_list
                    node.Nodes.Add(child)
                Next

                Me.TModulos.Nodes.Add(node)
            Next
        End Using
        watch.[Stop]()
        Me.TModulos.ExpandAll()

        'Me.radProgressBar1.Value1 = 50000
        'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
    End Sub

    Private Sub LoadOtros(dtPermisos As DataTable)
        Dim index As Integer = 0
        Dim watch As Stopwatch = Stopwatch.StartNew()

        Dim FilterP As String = "padre = 0 "
        Dim dvP As DataView, dtRowP As DataRowView
        If Not dtPermisos Is Nothing Then
            dvP = New DataView(dtPermisos, FilterP, "", DataViewRowState.CurrentRows)

        Else
            Me.TOtros.Nodes.Clear()
            Exit Sub
        End If

        Using Me.TOtros.DeferRefresh()
            Me.TOtros.Nodes.Clear()
            For Each dtRowP In dvP
                index += 1

                Dim node As New RadTreeNode '(dtRowP.Item("titulo").ToString, My.Resources.application_home, IIf(index = 1, True, False))
                node.Value = dtRowP.Item("codigo")
                node.Text = dtRowP.Item("nombre").ToString
                node.Image = My.Resources.minilist
                'node.Nodes.Add(node)

                Dim FilterH As String = "padre = " & dtRowP.Item("codigo").ToString
                Dim dvH As DataView, dtRowH As DataRowView


                dvH = New DataView(dtPermisos, FilterH, "", DataViewRowState.CurrentRows)


                For Each dtRowH In dvH
                    Dim child As New RadTreeNode '(dtRowH.Item("titulo"), My.Resources.application_add)
                    child.Value = dtRowH.Item("codigo")
                    child.Text = dtRowH.Item("nombre")
                    child.Checked = IIf(Boolean.Parse(dtRowH.Item(3)), True, False)
                    child.Image = My.Resources.cal
                    node.Nodes.Add(child)
                Next

                Me.TOtros.Nodes.Add(node)
            Next
        End Using
        watch.[Stop]()
        Me.TOtros.ExpandAll()

        'Me.radProgressBar1.Value1 = 50000
        'radLabel1.Text = "Time elapsed: " & (watch.ElapsedMilliseconds / 1000.0).ToString("0.00") & " sec"
    End Sub

    Private Sub Mostrar_Tree(vPersonaID As Long)
        Dim dtPMenu As New DataTable, dtModEmp As New DataTable, dtPermisos As New DataTable
        GPUsuarios.Enabled = False
        uTabs.Enabled = False
        If cursoresManager.Permisos_Windows(vPersonaID, dtPMenu, dtModEmp, dtPermisos) Then
            Call LoadMenu(dtPMenu)
            Call LoadModulos(dtModEmp)
            Call LoadOtros(dtPermisos)
        End If
        GPUsuarios.Enabled = True
        uTabs.Enabled = True
    End Sub
    Public Function ListarCondicion() As Boolean
        Dim xLimit As Integer
        Dim vArray As String = "1,11", vTiene As Boolean = False
        Dim xTabla As New DataTable, Drs As DataRow, NwRow As DataRow
        xLimit = 20
        vArray = "array[" & vArray & "]"

        Try
            ListadoRegistros = personaManager.GetList(Trim(Me.txtBuscar.Text), txtApe_Mat.Text, txtNombre.Text, "", vArray, xLimit, 0)

            xTabla = ClsTablitas.Get_Persona_Us("personaus")
            For Each Drs In ListadoRegistros.Rows
                NwRow = xTabla.NewRow
                NwRow.Item("personaid") = Long.Parse(Drs("personaid").ToString)
                NwRow.Item("nombre") = (Drs("nombre_persona").ToString)
                NwRow.Item("acceso") = "ACCESO"
                xTabla.Rows.Add(NwRow)
            Next Drs


            dgvCondicion.DataSource = xTabla
            'dgvListado.DataBind()
            If dgvCondicion.Rows.Count() > 0 Then
                'dgvListado.Rows(0).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If ListarCondicion() Then

        End If

    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs)

        Dim n As RadTreeNode
        For Each n In TMenu.Nodes
            MessageBox.Show("Parent Node Id" & n.Value, n.Text)
            Dim CNode As RadTreeNode
            For Each CNode In n.Nodes
                If CNode.Checked Then
                    MessageBox.Show("ChilID: " & CNode.Value, " ||  Child Node " & CNode.Text)
                End If
            Next
        Next

    End Sub

    Private Sub FrmGestion_Acceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TMenu.ItemHeight = 27
        Me.TMenu.AllowDefaultContextMenu = True
        Me.TMenu.CheckBoxes = True
        Me.TMenu.TriStateMode = True

        Me.TModulos.ItemHeight = 27
        Me.TModulos.AllowDefaultContextMenu = True
        Me.TModulos.CheckBoxes = True
        Me.TModulos.TriStateMode = True

        Me.TOtros.ItemHeight = 27
        Me.TOtros.AllowDefaultContextMenu = True
        Me.TOtros.CheckBoxes = True
        Me.TOtros.TriStateMode = True

        Call LibreriasFormularios.formatear_grid_Panel(dgvCondicion)
    End Sub

    Private Sub dgvCondicion_BeforeSelectChange(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeSelectChangeEventArgs) Handles dgvCondicion.BeforeSelectChange
        If dgvCondicion.Rows.Count > 0 Then
            If e.NewSelections.Rows.Count > 0 Then
                Call Mostrar_Tree(Integer.Parse(dgvCondicion.DisplayLayout.ActiveRow.Cells(0).Value))
            End If
        End If
    End Sub

    Private Sub dgvCondicion_ClickCellButton1(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvCondicion.ClickCellButton
        'MessageBox.Show("You clicked the " & e.Cell.Row.Cells("personaid").Value & " button" & vbCrLf & "in Row " & e.Cell.Row.Index, "Click")
        Dim xFrm As New FrmClave
        With xFrm
            .pCodigo = e.Cell.Row.Cells("personaid").Value
            .ShowDialog()
        End With
        'MessageBox.Show("You clicked the " + e.Cell.Column.Key.ToString() & " button" & vbCrLf & "in Row " & e.Cell.Row.Index, "Click")
    End Sub

    Private Sub dgvCondicion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvCondicion.InitializeLayout
        With dgvCondicion.DisplayLayout.Bands(0)
            .Columns(0).Header.Caption = "ID"
            .Columns(0).Width = 20
            .Columns("nombre").Header.Caption = "NOMBRE"
            .Columns("nombre").Width = 250
            .Columns("acceso").Width = 80
        End With
        Me.dgvCondicion.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button ' = ColumnStyle.Button

        Me.dgvCondicion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
        Me.dgvCondicion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub TMenu_NodeMouseClick(sender As Object, e As RadTreeViewEventArgs) Handles TMenu.NodeMouseClick
        e.Node.Checked = Not e.Node.Checked
    End Sub

    Private Sub TModulos_NodeMouseClick(sender As Object, e As RadTreeViewEventArgs) Handles TModulos.NodeMouseClick
        e.Node.Checked = Not e.Node.Checked
    End Sub

    Private Sub TOtros_NodeMouseClick(sender As Object, e As RadTreeViewEventArgs) Handles TOtros.NodeMouseClick
        e.Node.Checked = Not e.Node.Checked
    End Sub

    Private Sub FrmGestion_Acceso_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TMenu.Width = uTabs.Width - 220
        TModulos.Width = uTabs.Width - 220
        TOtros.Width = uTabs.Width - 220
    End Sub

    'Private Sub GetAllNodes(ByVal aTreeView As TreeView)
    '    Dim n As TreeNode
    '    For Each n In aTreeView.Nodes
    '        MessageBox.Show("Parent Node " & n.Text)
    '        Dim CNode As TreeNode
    '        For Each CNode In n.Nodes
    '            MessageBox.Show("Child Node " & CNode.Text)
    '        Next
    '    Next
    'End Sub

    Private Sub chkMenu_CheckedChanged(sender As Object, e As EventArgs) Handles chkMenu.CheckedChanged
        If TMenu.Nodes.Count = 0 Then
            Exit Sub
        End If
        Dim childNode As RadTreeNode
        For Each childNode In TMenu.Nodes
            ''If Not childNode.Checked Then
            childNode.Checked = chkMenu.Checked
            ''End If
            ' Recursively check the children of the current child node. 
            'If HasCheckedChildNodes(childNode) Then
            '    Return True
            'End If
        Next childNode

    End Sub

    Private Sub chkModulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModulos.CheckedChanged
        If TModulos.Nodes.Count = 0 Then
            Exit Sub
        End If
        Dim childNode As RadTreeNode
        For Each childNode In TModulos.Nodes

            childNode.Checked = chkModulos.Checked

        Next childNode
    End Sub

    Private Sub chkOtros_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtros.CheckedChanged
        If TOtros.Nodes.Count = 0 Then
            Exit Sub
        End If
        Dim childNode As RadTreeNode
        For Each childNode In TOtros.Nodes

            childNode.Checked = chkOtros.Checked

        Next childNode
    End Sub

    Private Sub dgvCondicion_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvCondicion.InitializeRow
        'If e.Row.Cells("estado").Value = False Then
        e.Row.Cells("acceso").Appearance.Image = Global.Phoenix.My.Resources.Resources.lock
        'Else
        '    e.Row.Cells("numero").Appearance.Image = Global.SoftComNet.My.Resources.Resources.edit_add
        'End If
    End Sub

    Private Sub BtnGrabarMenu_Click(sender As Object, e As EventArgs) Handles BtnGrabarMenu.Click

        Dim n As RadTreeNode, vArray As String = ""
        For Each n In TMenu.Nodes
            'MessageBox.Show("Parent Node Id" & n.Value, n.Text)
            Dim CNode As RadTreeNode
            For Each CNode In n.Nodes
                If CNode.Checked Then
                    ' MessageBox.Show("ChilID: " & CNode.Value, " ||  Child Node " & CNode.Text)

                    If CNode.Checked Then
                        vArray = vArray & Str(CNode.Value).Trim & ","
                    End If

                End If
            Next
        Next

        If Not vArray = "" Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If

        If dgvCondicion.Rows.Count > 0 Then
            If dgvCondicion.Selected.Rows.Count > 0 Then
                Dim xCodigo As Long = dgvCondicion.ActiveRow.Cells(0).Value
                If gestion_accesoManager.Actualizar_Menu(xCodigo, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    MessageBox.Show("Se actualizó correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If


    End Sub

    Private Sub btnGrabarModAlm_Click(sender As Object, e As EventArgs) Handles btnGrabarModAlm.Click
        Dim n As RadTreeNode, vArray As String = ""
        For Each n In TModulos.Nodes
            'MessageBox.Show("Parent Node Id" & n.Value, n.Text)
            Dim CNode As RadTreeNode
            For Each CNode In n.Nodes
                If CNode.Checked Then
                    ' MessageBox.Show("ChilID: " & CNode.Value, " ||  Child Node " & CNode.Text)
                    If CNode.Checked Then
                        vArray = vArray & "[" & Str(CNode.Value).Trim & "," & _
                                                Str(n.Value) & "],"
                    End If

                End If
            Next
        Next

        If Not vArray = "" Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If
        If dgvCondicion.Rows.Count > 0 Then
            If dgvCondicion.Selected.Rows.Count > 0 Then
                Dim xCodigo As Long = dgvCondicion.ActiveRow.Cells(0).Value
                If gestion_accesoManager.Actualizar_Mod_alm(xCodigo, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    MessageBox.Show("Se actualizó correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btnGrabarOtros_Click(sender As Object, e As EventArgs) Handles btnGrabarOtros.Click
        Dim n As RadTreeNode, vArray As String = ""
        For Each n In TOtros.Nodes
            'MessageBox.Show("Parent Node Id" & n.Value, n.Text)
            Dim CNode As RadTreeNode
            For Each CNode In n.Nodes
                If CNode.Checked Then
                    ' MessageBox.Show("ChilID: " & CNode.Value, " ||  Child Node " & CNode.Text)
                    If CNode.Checked Then
                        vArray = vArray & Str(CNode.Value).Trim & ","
                    End If

                End If
            Next
        Next

        If Not vArray = "" Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If
        If dgvCondicion.Rows.Count > 0 Then
            If dgvCondicion.Selected.Rows.Count > 0 Then
                Dim xCodigo As Long = dgvCondicion.ActiveRow.Cells(0).Value
                If gestion_accesoManager.Actualizar_Otros(xCodigo, vArray, GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    MessageBox.Show("Se actualizó correctamente", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
End Class