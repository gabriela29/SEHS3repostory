
Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class FrmBonificacionEdit

    Public vAlmacen As String, vAlmacenId As Integer
    Public dtTipo As DataTable, dtDestino As DataTable, vArray As String = ""

    Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
        Dim DtRes As New DataTable
        Dim vOpcion As Integer = 0, vPersona As Long = 0

        If Not IsDate(lblDesde.Text) Then
            MessageBox.Show("Fecha Inicio no válida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not IsDate(lblHasta.Text) Then
            MessageBox.Show("Fecha Final no válida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cboTipo.Text = "" Then
            MessageBox.Show("Debe seleccionar un tipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim dtDetalle As New DataTable
        Dim vDesde As String = LibreriasFormularios.Formato_Fecha(lblDesde.Text)
        Dim vHasta As String = LibreriasFormularios.Formato_Fecha(lblHasta.Text)
        Dim vMeta As Single = Single.Parse(lblImporte_Min.Text)

        dtDetalle = ventaManager.Saldo_Fact_Colportaje_Res(vAlmacenId, vPersona, vDesde, vHasta, vMeta, 0, 0, "", 0, "", "null")
        e.Result = dtDetalle
      

    End Sub

    Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted
        
        dgvListado.DataSource = CType(e.Result, DataTable)

        picAjax.Visible = False
        ExpanGroup.Enabled = True        
        'dgvListado.Refresh()
        Me.lblRegistros.Text = dgvListado.Rows.Count & " Registros"

    End Sub

    Private Sub Actualizar()
        picAjax.Visible = True
        ExpanGroup.Enabled = False
        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub


    Private Sub LLenar_Combos()

        With cboTipo
            .DataSource = Nothing
            .DataSource = dtTipo
            .DataBind()
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If

        End With

        With cboDestino
            .DataSource = Nothing
            .DataSource = destino_bonificacionManager.GetList("")
            .DataBind()
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If

        End With


    End Sub

    Private Sub FrmBonificacionEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDesde.Text = ""
        lblHasta.Text = ""
        lblAlmacen.Text = vAlmacen
        Call LLenar_Combos()
        Call LibreriasFormularios.formatear_grid_Edit(dgvListado)
    End Sub


    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        Call Actualizar()
    End Sub

    Private Sub cboTipo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboTipo.InitializeLayout
        With cboTipo.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns("nombre").Width = cboTipo.Width
            .Columns("desde").Hidden = True
            .Columns("hasta").Hidden = True
            .Columns("estado").Hidden = True
        End With
    End Sub

    Private Sub cboTipo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.ValueChanged
        dgvListado.DataSource = Nothing
        lblDesde.Text = ""
        lblHasta.Text = ""

        If Not cboTipo.DataSource Is Nothing Then
            lblDesde.Text = cboTipo.ActiveRow.Cells("desde").Value
            lblHasta.Text = cboTipo.ActiveRow.Cells("hasta").Value
        End If

    End Sub

    'Private Sub dgvListado_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvListado.AfterCellUpdate
    '    If e.Cell.Column.Index = 4 Then
    '        If dgvListado.ActiveRow.Cells("destinoid").Value > 0 Then
    '            dgvListado.ActiveRow.Cells("meta").Value = (Single.Parse(cboDestino.ActiveRow.Cells("importe_min").Value))
    '            dgvListado.ActiveRow.Cells("falta").Value = (Single.Parse(dgvListado.ActiveRow.Cells("meta").Value) - Single.Parse(dgvListado.ActiveRow.Cells("neto").Value))
    '            dgvListado.ActiveRow.Cells("sel").Value = True
    '        End If
    '    ElseIf e.Cell.Column.Index = 1 Then
    '        If dgvListado.ActiveRow.Cells("sel").Value = False Then
    '            dgvListado.ActiveRow.Cells("destinoid").Value = 0
    '            dgvListado.ActiveRow.Cells("meta").Value = 0
    '            dgvListado.ActiveRow.Cells("falta").Value = 0
    '        End If
    '    End If
    'End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns("personaid").Width = 20
            .Columns("personaid").CellActivation = Activation.NoEdit

            .Columns("sel").Width = 40
            .Columns("sel").Header.Caption = ""

            .Columns("rucdni").Width = 80
            .Columns("rucdni").Header.Caption = "RUC/DNI"
            .Columns("rucdni").CellActivation = Activation.NoEdit

            .Columns("persona").Width = 200
            .Columns("persona").Header.Caption = "Persona"
            .Columns("persona").CellActivation = Activation.NoEdit

            '.Columns("destinoid").Width = 100
            '.Columns("destinoid").Header.Caption = "Destino"
            '.Columns("destinoid").CellAppearance.BackColor = Color.LemonChiffon

            '.Columns("meta").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("meta").Width = 80
            '.Columns("meta").Header.Caption = "Meta"
            '.Columns("meta").CellActivation = Activation.NoEdit

            '.Columns("falta").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("falta").Width = 80
            '.Columns("falta").Header.Caption = "Falta"
            '.Columns("falta").CellAppearance.BackColor = Color.LemonChiffon
            '.Columns("falta").CellActivation = Activation.NoEdit

            .Columns("facturado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("facturado").Width = 60
            .Columns("facturado").Header.Caption = "Emitido"
            .Columns("facturado").CellActivation = Activation.NoEdit

            .Columns("nc").CellAppearance.TextHAlign = HAlign.Right
            .Columns("nc").Width = 60
            .Columns("nc").Header.Caption = "N.Cred."
            .Columns("nc").CellActivation = Activation.NoEdit

            .Columns("saldo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("saldo").Width = 60
            .Columns("saldo").Header.Caption = "Saldo"
            .Columns("saldo").CellActivation = Activation.NoEdit

            .Columns("neto").CellAppearance.TextHAlign = HAlign.Right
            .Columns("neto").Width = 80
            .Columns("neto").Header.Caption = "Neto"
            .Columns("neto").CellAppearance.BackColor = Color.LemonChiffon
            .Columns("neto").CellActivation = Activation.NoEdit

            .Columns("dzmo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("dzmo").Width = 80
            .Columns("dzmo").Header.Caption = "DZMO"
            .Columns("dzmo").CellActivation = Activation.NoEdit

            .Columns("total").CellAppearance.TextHAlign = HAlign.Right
            .Columns("total").Width = 80
            .Columns("total").Header.Caption = "Total"
            .Columns("total").CellActivation = Activation.NoEdit

            '.Columns("destinoid").ValueList = cboDestino
            '.Columns("destinoid").Style = ColumnStyle.DropDownList
        End With
    End Sub

    Private Sub Exportar_Excel()

    Call LibreriasFormularios.Exportar_UltraGrid_Excel(dgvListado, ugExcelExporter, "boni_tmp.xls")
  End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Call Exportar_Excel()
    End Sub

    Private Sub Detalle_Res()
        Dim vPersonaid As Long = 0

        If vAlmacenId > 0 Then
            If dgvListado.Rows.Count > 0 Then
                If dgvListado.Selected.Rows.Count > 0 Then
                    Dim DtRpt As New DataTable, vDesde As String, vHasta As String, xCondi As String = ""
                    vDesde = LibreriasFormularios.Formato_Fecha(lblDesde.Text)
                    vHasta = LibreriasFormularios.Formato_Fecha(lblHasta.Text)
                    vPersonaid = dgvListado.DisplayLayout.ActiveRow.Cells(0).Value

                    DtRpt = por_cobrarManager.RptImporte_Prod_Fact(vAlmacenId, vPersonaid, vDesde, vHasta)
                    xCondi = "Listado de productos Facturados Desde: " & lblDesde.Text & " Hasta: " & lblHasta.Text
                    Dim frm As New FrmVisor_PorCobrar

                    frm.RptImp_Prod_Fact(DtRpt, GestionSeguridadManager.gEmpresa, vAlmacen, xCondi)
                    frm.MdiParent = Me.MdiParent
                    frm.Show()
                Else

                End If
            End If
        End If

    End Sub

    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        Call Detalle_Res()
    End Sub

    Private Sub cboDestino_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDestino.InitializeLayout
        With cboDestino.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDestino.Width
            .Columns(2).Width = 80
            .Columns(3).Hidden = True
        End With
    End Sub

    Private Sub cboDestino_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDestino.ValueChanged
        lblImporte_Min.Text = "0.00"
        dgvListado.DataSource = Nothing

        If Not cboDestino.DataSource Is Nothing Then
            lblImporte_Min.Text = cboDestino.ActiveRow.Cells("importe_min").Value

        End If
    End Sub

    Private Sub bwAgregar_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAgregar.DoWork
        Dim DtRes As New DataTable
        Dim vOpcion As Integer = 0, vPersona As Long = 0

        If Not IsDate(lblDesde.Text) Then
            MessageBox.Show("Fecha Inicio no válida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Not IsDate(lblHasta.Text) Then
            MessageBox.Show("Fecha Final no válida", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cboTipo.Text = "" Then
            MessageBox.Show("Debe seleccionar un tipo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If cboDestino.Text = "" Then
            MessageBox.Show("Debe seleccionar una meta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Dim dtDetalle As New DataTable
        Dim vDesde As String = LibreriasFormularios.Formato_Fecha(lblDesde.Text)
        Dim vHasta As String = LibreriasFormularios.Formato_Fecha(lblHasta.Text)
        Dim vMeta As Single = Single.Parse(lblImporte_Min.Text)


        dtDetalle = ventaManager.Saldo_Fact_Colportaje_Res(vAlmacenId, vPersona, vDesde, vHasta, vMeta, _
                                                           cboDestino.Value, cboTipo.Value, "", GestionSeguridadManager.idUsuario, _
                                                           My.Computer.Name, vArray)
        e.Result = dtDetalle


    End Sub

    Private Sub bwAgregar_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwAgregar.RunWorkerCompleted

        dgvListado.DataSource = CType(e.Result, DataTable)

        picAjax.Visible = False
        ExpanGroup.Enabled = True
        'dgvListado.Refresh()
        Me.lblRegistros.Text = dgvListado.Rows.Count & " Registros"

    End Sub

    Private Sub Agregar()
        picAjax.Visible = True
        ExpanGroup.Enabled = False
        If Not bwAgregar.IsBusy Then
            bwAgregar.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Dim dgvRw As UltraGridRow, vTiene As Boolean = False

        vArray = ""
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvListado.Rows
            If dgvRw.Band.Index = 0 Then

                If Boolean.Parse(dgvRw.Cells("sel").Value) Then
                    vTiene = True
                    vArray = vArray & "['" & Str(dgvRw.Cells("personaid").Value).Trim & "'],"
                End If

            End If
        Next

        If vTiene Then
            vArray = Mid(vArray, 1, Len(vArray) - 1)
            vArray = "array[" & vArray & "]"
        Else
            vArray = "null"
        End If
        If vTiene Then
            Call Agregar()
            Me.Close()
        Else
            MessageBox.Show("No tiene Registros marcados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub


End Class