Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmArqueo_IngresosNM
    Public pCodigo As Long, pCodigo_Us As Long, pCodigo_Alm As Integer, pAlmacen As String
    Public dtIngresos As DataTable, dtDocumentos As DataTable, dtMonedas As DataTable, dtBill As DataTable, dtDoll As DataTable
    Public vOk As Boolean

    Private Sub bwIngresos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwIngresos.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vFecha As String = ""

        dtIngresos = New DataTable
        dtDocumentos = New DataTable
        dtMonedas = New DataTable
        dtBill = New DataTable
        dtDoll = New DataTable

        vFecha = Year(cboFecha.Value) & "/" & Format(Month(cboFecha.Value), "00") & "/" & Format(Day(cboFecha.Value), "00")

        vOk = arqueo_ingresosManager.Obtener_Data_Arqueo(pCodigo_Us, pCodigo_Alm, vFecha, vFecha, dtIngresos, dtDocumentos, dtMonedas, dtBill, dtDoll)

        e.Result = vOk

    End Sub

    Private Sub bwIngresos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwIngresos.RunWorkerCompleted
        dgvIngresos.DataSource = Nothing
        dgvOtros.DataSource = Nothing
        dgvMonedas.DataSource = Nothing
        dgvBilletes.DataSource = Nothing
        dgvDolares.DataSource = Nothing
        Me.lblIngresos.Text = "0.00"

        Me.lblTotalMO.Text = "0.00"

        Me.LblTotalBI.Text = "0.00"

        Me.lblTotalDO.Text = "0.00"

        Me.lblTotalFP.Text = "0.00"

        lblTotal_Sustento.Text = "0.00"
        lblSaldo.Text = "0.00"

        If vok Then
            dgvIngresos.DataSource = dtIngresos
            dgvOtros.DataSource = dtDocumentos
            dgvMonedas.DataSource = dtMonedas
            dgvBilletes.DataSource = dtBill
            dgvDolares.DataSource = dtDoll
        ElseIf Not dtDocumentos Is Nothing Then
            'dgvOtros.DataSource = dtDocumentos
        End If

        Call Calcular_Totales_Grid(dgvIngresos)
        Call Calcular_Totales_Grid(dgvOtros)
        tsGrabar.Enabled = True
        picAjaxI.Visible = False
        picAjaxS.Visible = False
    End Sub

    Private Sub Calcular_Totales_Grid(ByVal gGridu As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
        dtDgv = gGridu
        Dim vIngresos As Single = 0
        Dim vImporte As Single = 0
        Dim vnImporte As Single = 0
        Dim voImporte As Single = 0
        For Each dgvRw In dtDgv.Rows
            If dgvRw.Band.Index = 0 Then
                If gGridu.Name = "dgvOtros" Then
                    voImporte = dgvRw.Cells("suma").Value
                End If
                If gGridu.Name = "dgvIngresos" Then
                    vIngresos = dgvRw.Cells("suma").Value
                End If
                If gGridu.Name = "dgvDolares" Then
                    vnImporte += dgvRw.Cells("nimporte").Value
                End If
                vImporte += dgvRw.Cells("importe").Value
            End If
        Next

        Select Case gGridu.Name
            Case "dgvIngresos"
                Me.lblIngresos.Text = FormatNumber(vIngresos, 2, TriState.True, , TriState.False)
            Case "dgvMonedas"
                Me.lblTotalMO.Text = FormatNumber(vImporte, 2, TriState.True, , TriState.False)
            Case "dgvBilletes"
                Me.LblTotalBI.Text = FormatNumber(vImporte, 2, TriState.True, , TriState.False)
            Case "dgvDolares"
                Me.lblTotalDO.Text = FormatNumber(vnImporte, 2, TriState.True, , TriState.False)
            Case "dgvOtros"
                Me.lblTotalFP.Text = FormatNumber(voImporte, 2, TriState.True, , TriState.False)
        End Select
        lblTotal_Sustento.Text = FormatNumber((CSng(lblTotalMO.Text) + CSng(LblTotalBI.Text) + CSng(lblTotalDO.Text) + CSng(Me.lblTotalFP.Text)), 2, TriState.True, , TriState.False)
        lblSaldo.Text = FormatNumber((CSng(Me.lblIngresos.Text) - CSng(lblTotal_Sustento.Text)), 2, TriState.True, , TriState.False)

    End Sub

    Private Sub dgv_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) _
                                        Handles dgvMonedas.AfterCellUpdate, dgvBilletes.AfterCellUpdate, dgvDolares.AfterCellUpdate
        Dim gGridu As Infragistics.Win.UltraWinGrid.UltraGrid
        gGridu = sender
        If e.Cell.Column.Index = 1 Then
            gGridu.ActiveRow.Cells("importe").Value = FormatNumber(CSng(gGridu.ActiveRow.Cells("cantidad").Value) * CSng(gGridu.ActiveRow.Cells("valor").Value), 2, TriState.True, , TriState.False)
            gGridu.ActiveRow.Cells("nimporte").Value = FormatNumber(CSng(gGridu.ActiveRow.Cells("importe").Value) * CSng(gGridu.ActiveRow.Cells("cambio").Value), 2, TriState.True, , TriState.False)
        End If
        If e.Cell.Column.Index = 4 Then
            gGridu.ActiveRow.Cells("nimporte").Value = FormatNumber(CSng(gGridu.ActiveRow.Cells("importe").Value) * CSng(gGridu.ActiveRow.Cells("cambio").Value), 2, TriState.True, , TriState.False)
        End If
        Call Calcular_Totales_Grid(sender)
    End Sub

    Private Sub dgv_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) _
                                    Handles dgvMonedas.BeforeCellUpdate, dgvBilletes.BeforeCellUpdate, dgvDolares.BeforeCellUpdate
        Dim gGrids As Infragistics.Win.UltraWinGrid.UltraGrid
        gGrids = sender
        If e.Cell.Column.Index = 1 Then
            If Not IsNumeric(e.Cell.Text) Then
                MsgBox("La Cantidad debe ser Numérica", MsgBoxStyle.Exclamation, "AVISO")
                e.Cell.CancelUpdate()
                e.Cancel = True
                Exit Sub
            Else
                'gGrids.ActiveRow.Cells(3).Value = FormatNumber(CSng(e.Cell.Text) * CSng(gGrids.ActiveRow.Cells(2).Value), 2, TriState.True, , TriState.False)
            End If
        End If
    End Sub

    Private Sub dgv_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) _
                                            Handles dgvMonedas.InitializeLayout, dgvBilletes.InitializeLayout, dgvDolares.InitializeLayout
        Dim gGrid As Infragistics.Win.UltraWinGrid.UltraGrid
        gGrid = sender
        With gGrid.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 40
            .Columns(1).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(2).Width = 50
            .Columns(2).CellActivation = Activation.NoEdit
            .Columns(2).CellAppearance.TextHAlign = HAlign.Right
            .Columns(3).Width = 70
            .Columns(3).CellAppearance.TextHAlign = HAlign.Right
            .Columns(3).CellActivation = Activation.NoEdit
            If Not gGrid.Name = "dgvDolares" Then
                .Columns(4).Hidden = True
                .Columns(5).Hidden = True
            Else
                .Columns(3).Width = 60
                .Columns(4).Width = 40
                .Columns(4).CellAppearance.TextHAlign = HAlign.Right
                .Columns(4).CellAppearance.BackColor = Color.LemonChiffon

                .Columns(5).Width = 50
                .Columns(5).CellAppearance.TextHAlign = HAlign.Right
                .Columns(5).CellActivation = Activation.NoEdit
            End If
            .Columns(6).Hidden = True
        End With


    End Sub

    Private Sub dgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
                            Handles dgvMonedas.KeyDown, dgvBilletes.KeyDown, dgvDolares.KeyDown

        If e.KeyValue = Keys.Up Or e.KeyValue = Keys.Down Or _
            e.KeyValue = Keys.Left Or e.KeyValue = Keys.Right Then

            Call LibreriasFormularios.Navy_Cells_uGrid(sender, e)

        End If

    End Sub

    Private Sub dgvOtros_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvOtros.InitializeLayout
        With dgvOtros.DisplayLayout.Bands(0)
            .Columns(0).CellActivation = Activation.NoEdit
            .Columns(0).Width = 70
            .Columns(1).Width = 150
            .Columns(1).CellActivation = Activation.NoEdit
            .Columns(1).CellAppearance.TextHAlign = HAlign.Right
            .Columns(1).CellAppearance.BackColor = Color.LemonChiffon
            .Columns("orden").Hidden = True
            .Columns("suma").Hidden = True
        End With

    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click

        Call Actualizar()

    End Sub

    Public Sub Actualizar()
        tsGrabar.Enabled = False
        If Not bwIngresos.IsBusy Then
            picAjaxI.Visible = True
            picAjaxS.Visible = True
            bwIngresos.RunWorkerAsync()
        End If
    End Sub

    Private Sub tsGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGrabar.Click

        If Not dgvIngresos.Rows.Count > 0 Then
            MessageBox.Show("No hay Registros que grabar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Not lblSaldo.Text = 0 Then
            MessageBox.Show("El Saldo debe ser cero (0) ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim ObjM As New arqueo_ingresos, xF As Boolean = False, vTiene As Boolean
        Dim dgvRw As UltraGridRow
        Dim xIdRet As Long = 0
        Dim vArray As String
        Dim vCant As Long = 0
        Dim vImport As Single = 0, vValor As Single = 0, vCambio As Single = 0

        Dim ValidarControles As Boolean = True
        'infecha,incodigo_uni,incodigo_us,innumeroini,innumerofin,intotal_ing,inretiro,indetalle,incerrado
        Try
            If ValidarControles Then
                With ObjM
                    .fecha = Year(cboFecha.Value) & "/" & Format(Month(cboFecha.Value), "00") & "/" & Format(Day(cboFecha.Value), "00")
                    .codigo_alm = pCodigo_Alm
                    .codigo_us = pCodigo_Us
                    .total_ing = FormatNumber(Me.lblIngresos.Text, 2, TriState.True, , TriState.False)
                    .retiro = 0
                    .cerrado = False
                    .detalle = ""
                    .caja = Trim(My.Computer.Name) & ""
                End With

                'Lo metemos en el array los Grid

                vArray = ""

                ''Ingresos
                For Each dgvRw In Me.dgvIngresos.Rows
                    If dgvRw.Band.Index = 0 Then
                        vTiene = True
                        vCant = 1
                        vValor = 1
                        vImport = FormatNumber(CSng((dgvRw.Cells("importe").Value)), 2, TriState.True, , TriState.False)
                        vArray = vArray & "['" & "AA" & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & "0" & "','" & "NS" & "','" & Trim((dgvRw.Cells("documento").Value)) & "','" & Trim(Str(99)) & "'],"
                    End If
                Next

                'Monedas
                For Each dgvRw In Me.dgvMonedas.Rows
                    If dgvRw.Band.Index = 0 Then
                        vTiene = True
                        vCant = Trim(Str(dgvRw.Cells("cantidad").Value))
                        vValor = FormatNumber(CSng((dgvRw.Cells("valor").Value)), 2, TriState.True, , TriState.False)
                        vImport = FormatNumber(CSng((dgvRw.Cells("importe").Value)), 2, TriState.True, , TriState.False)
                        vArray = vArray & "['" & Trim(dgvRw.Cells("tipo").Value) & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & "0" & "','" & "NS" & "','" & "-" & "','" & Trim(Str(dgvRw.Cells("codigo").Value)) & "'],"
                    End If
                Next

                'Billetes

                For Each dgvRw In Me.dgvBilletes.Rows
                    If dgvRw.Band.Index = 0 Then
                        vTiene = True
                        vCant = Trim(Str(dgvRw.Cells("cantidad").Value))
                        vValor = FormatNumber(CSng((dgvRw.Cells("valor").Value)), 2, TriState.True, , TriState.False)
                        vImport = FormatNumber(CSng((dgvRw.Cells("importe").Value)), 2, TriState.True, , TriState.False)
                        vArray = vArray & "['" & Trim(dgvRw.Cells("tipo").Value) & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & "0" & "','" & "NS" & "','" & "-" & "','" & Trim(Str(dgvRw.Cells("codigo").Value)) & "'],"
                    End If
                Next

                'Dolares

                For Each dgvRw In Me.dgvDolares.Rows
                    If dgvRw.Band.Index = 0 Then
                        xF = True
                        vCant = Trim(Str(dgvRw.Cells("cantidad").Value))
                        vValor = FormatNumber(CSng((dgvRw.Cells("valor").Value)), 2, TriState.True, , TriState.False)
                        vImport = FormatNumber(CSng((dgvRw.Cells("nimporte").Value)), 2, TriState.True, , TriState.False)
                        vCambio = FormatNumber(CSng((dgvRw.Cells("cambio").Value)), 2, TriState.True, , TriState.False)
                        vArray = vArray & "['" & Trim(dgvRw.Cells("tipo").Value) & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & vCambio & "','" & "DO" & "','" & "-" & "','" & Trim(Str(dgvRw.Cells("codigo").Value)) & "'],"
                    End If
                Next

                'Otros

                For Each dgvRw In Me.dgvOtros.Rows
                    If dgvRw.Band.Index = 0 Then
                        vTiene = True
                        vCant = 1 'Trim(Str(dgvRw.Cells("cantidad").Value))
                        vValor = 1
                        vImport = FormatNumber(CSng((dgvRw.Cells("importe").Value)), 2, TriState.True, , TriState.False)
                        vCambio = 0
                        vArray = vArray & "['" & "OT" & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & vCambio & "','" & "NS" & "','" & Trim(dgvRw.Cells("documento").Value) & "','" & "999" & "'],"
                    End If
                Next

                If vTiene Then
                    vArray = Mid(vArray, 1, Len(vArray) - 1)
                    vArray = "array[" & vArray & "]"
                Else
                    vArray = "null"
                    vArray = "null"
                End If

                xIdRet = arqueo_ingresosManager.Registrar_Arqueo(ObjM, vArray)
                Me.Close()
            End If
        Finally
            ObjM = Nothing
        End Try

    End Sub


    Private Sub dgvIngresos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvIngresos.InitializeLayout
        With dgvIngresos.DisplayLayout.Bands(0)
            .Columns(0).Width = 200
            .Columns(0).CellActivation = Activation.NoEdit
            .Columns(1).CellAppearance.TextHAlign = HAlign.Right
            .Columns(1).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(1).CellActivation = Activation.NoEdit
            .Columns(2).Hidden = True
            .Columns("orden").Hidden = True
        End With
    End Sub

    Private Sub FrmArqueo_IngresosNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboFecha.Value = Now.Date

        dgvIngresos.DataSource = Nothing
        dgvOtros.DataSource = Nothing
        dgvMonedas.DataSource = Nothing
        dgvBilletes.DataSource = Nothing
        dgvDolares.DataSource = Nothing
    End Sub

    Private Sub tsCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCerrar.Click
        Me.Close()
    End Sub

    Private Sub tsmSustento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSustento.Click
        If Not lblIngresos.Text = "" Then
            If IsNumeric(lblIngresos.Text) Then
                Dim xTipo As String = ""

                FrmRegistro_MBNM.NroLote = 0
                FrmRegistro_MBNM.Lote = "Ingresos del: " & cboFecha.Value
                FrmRegistro_MBNM.vCodigo_Almacen = pCodigo_Alm
                FrmRegistro_MBNM.vAlmacen = pAlmacen
                FrmRegistro_MBNM.vCerrado = False
                FrmRegistro_MBNM.pMes = 0
                FrmRegistro_MBNM.pAnio = cboFecha.Value
                FrmRegistro_MBNM.vFecha_Reg = cboFecha.Value
                FrmRegistro_MBNM.pTotal = Single.Parse(lblIngresos.Text)
                FrmRegistro_MBNM.pTabla = "LI"
                FrmRegistro_MBNM.pTablaId = pCodigo_Alm
                FrmRegistro_MBNM.pEntidad = GestionSeguridadManager.gEntidad
                'FrmRegistro_MB.MdiParent = MDIMenu
                FrmRegistro_MBNM.ShowDialog()
                'End With
            Else
                MessageBox.Show("No hay registros", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub tsEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEliminar.Click
        If dgvOtros.Rows.Count > 0 Then
            If dgvOtros.Selected.Rows.Count Then
                Dim xCod As Long

                xCod = ((dgvOtros.DisplayLayout.ActiveRow.Cells("orden").Value))

                If registro_mbManager.Eliminar(xCod) Then
                    Call Actualizar()
                End If
            End If
        End If


    End Sub

    Private Sub tsActualizar_Click(sender As Object, e As EventArgs) Handles tsActualizar.Click
        Call Actualizar()
    End Sub

    Private Sub tsSusExel_Click(sender As Object, e As EventArgs) Handles tsSusExel.Click
        If LibreriasFormularios.Exportar_UltraGrid_Excel(dgvOtros, utExcel, "Suscripciones.xls") Then

        End If
    End Sub
End Class