
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmArqueo_Fondo_FijoNM

    Public pCodigo_Uni As Integer, pCodigo_Alm As Integer, xCont As Integer = 0, pUsuarioID As Long
    Public dtDocumentos As DataTable, dtMonedas As DataTable, dtBill As DataTable, dtDoll As DataTable
    Public vOk As Boolean

    Private Sub bwSustento_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwSustento.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vFecha As String = LibreriasFormularios.Formato_Fecha(cboFecha.Text)

        dtDocumentos = New DataTable
        dtMonedas = New DataTable
        dtBill = New DataTable
        dtDoll = New DataTable

        vOk = arqueo_fondo_fManager.Obtener_Data_Arqueo(Long.Parse(txtLote.Text), vFecha, dtDocumentos, dtMonedas, dtBill, dtDoll)

        e.Result = vOk

    End Sub

    Private Sub bwSustento_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwSustento.RunWorkerCompleted

        dgvOtros.DataSource = dtDocumentos
        dgvMonedas.DataSource = dtMonedas
        dgvBilletes.DataSource = dtBill
        dgvDolares.DataSource = dtDoll
        Call Calcular_Totales_Grid(dgvOtros)

        BtnGrabar.Enabled = True
        picAjaxM.Visible = False
        picAjaxB.Visible = False
        picAjaxD.Visible = False
        picAjaxO.Visible = False
    End Sub

    Private Sub FrmArqueo_Fondo_FijoNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboFecha.Text = Now.Date
        BtnGrabar.Enabled = True
        picAjaxM.Visible = False
        picAjaxB.Visible = False
        picAjaxD.Visible = False
        picAjaxO.Visible = False
    End Sub

    Private Sub Calcular_Totales_Grid(ByVal gGridu As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
        dtDgv = gGridu
        Dim vImporte As Single = 0
        Dim vnImporte As Single = 0
        For Each dgvRw In dtDgv.Rows
            If dgvRw.Band.Index = 0 Then
                If gGridu.Name = "dgvDolares" Then
                    vnImporte += dgvRw.Cells("nimporte").Value
                End If
                vImporte += dgvRw.Cells("importe").Value
            End If
        Next

        Select Case gGridu.Name
            Case "dgvMonedas"
                Me.lblTotalMO.Text = FormatNumber(vImporte, 2, TriState.True, , TriState.False)
            Case "dgvBilletes"
                Me.LblTotalBI.Text = FormatNumber(vImporte, 2, TriState.True, , TriState.False)
            Case "dgvDolares"
                Me.lblTotalDO.Text = FormatNumber(vnImporte, 2, TriState.True, , TriState.False)
            Case "dgvOtros"
                Me.lblTotalFP.Text = FormatNumber(vImporte, 2, TriState.True, , TriState.False)
        End Select
        lblTotal_Sustento.Text = FormatNumber((CSng(lblTotalMO.Text) + CSng(LblTotalBI.Text) + CSng(lblTotalDO.Text) + CSng(Me.lblTotalFP.Text)), 2, TriState.True, , TriState.False)
        lblSaldo.Text = FormatNumber((CSng(Me.lblTotal_Fondo_Fijo.Text) - CSng(lblTotal_Sustento.Text)), 2, TriState.True, , TriState.False)
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

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim ObjFF As New arqueo_fondo_fijo, xF As Boolean = False, vTiene As Boolean, vFecha As String
        Dim dgvRw As UltraGridRow
        Dim xIdRet As Long = 0
        Dim vArray As String
        Dim vCant As Long = 0
        Dim vImport As Single = 0, vValor As Single = 0, vCambio As Single = 0

        Dim ValidarControles As Boolean = True
        If LblDescripLote.Text = "" Then
            ValidarControles = False
            MessageBox.Show("Número de lote no válido", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If txtLote.Text = "" Then
            ValidarControles = False
            MessageBox.Show("Número de lote no válido", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        If Single.Parse(lblSaldo.Text) > 0 Then
            ValidarControles = False
            MessageBox.Show("El Saldo debe ser Igual a Cero (0)", "VERIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        'infecha,incodigo_uni,incodigo_us,innumerolote,infondofijo,indetalle,incerrado,incaja,in myArr
        vFecha = LibreriasFormularios.Formato_Fecha(cboFecha.Text)
        Try
            If ValidarControles Then
                With ObjFF
                    .fecha = vFecha
                    .codigo_uni = pCodigo_Alm
                    .codigo_us = pUsuarioID
                    .numerolote = txtLote.Text
                    .fondofijo = FormatNumber(Me.lblTotal_Fondo_Fijo.Text, 2, TriState.True, , TriState.False)
                    .detalle = Me.LblDescripLote.Text & ""
                    .cerrado = False
                    .caja = Trim(My.Computer.Name) & ""
                End With

                'Lo metemos en el array los Grid

                vArray = ""

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
                        vArray = vArray & "['" & "OT" & "', '" & Trim(vCant) & "','" & Trim(vValor) & "','" & vImport & "','" & vCambio & "','" & "NS" & "','" & Trim(dgvRw.Cells("detalle").Value) & "','" & "99" & "'],"
                    End If
                Next

                If vTiene Then
                    vArray = Mid(vArray, 1, Len(vArray) - 1)
                    vArray = "array[" & vArray & "]"
                Else
                    vArray = "null"
                    vArray = "null"
                End If

                xIdRet = arqueo_fondo_fManager.Registrar_Arqueo(ObjFF, vArray)
                If xIdRet > 0 Then
                    Me.Close()
                End If

            End If
        Finally
            ObjFF = Nothing
        End Try

    End Sub

    Public Function Existe_Arqueo() As Boolean
        Dim ObjDt As New DataTable
        Dim vlote As Long = 0
        vlote = txtLote.Text
        ObjDt = arqueo_fondo_fManager.GetList(vlote)
        If Not ObjDt Is Nothing Then
            If ObjDt.Rows.Count > 0 Then
                Existe_Arqueo = True
            End If

        End If
        ObjDt = Nothing
        Return Existe_Arqueo
    End Function

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If IsNumeric(txtLote.Text) Then
            'If Existe_Arqueo() Then
            '    MsgBox("Ya Existe un Arqueo en este Día", MsgBoxStyle.Exclamation, "AVISO")
            '    BtnGrabar.Enabled = False
            'Else
            Me.lblTotalMO.Text = "0.00"

            Me.LblTotalBI.Text = "0.00"

            Me.lblTotalDO.Text = "0.00"

            Me.lblTotalFP.Text = "0.00"

            lblTotal_Sustento.Text = "0.00"
            lblSaldo.Text = "0.00"

            Call Obtener_Dato_Lote()

            If Not bwSustento.IsBusy Then
                BtnGrabar.Enabled = False
                picAjaxM.Visible = True
                picAjaxB.Visible = True
                picAjaxD.Visible = True
                picAjaxO.Visible = True
                bwSustento.RunWorkerAsync()
            End If        
        Else
            MsgBox("El Número de Lote debe ser Numérico!!!", MsgBoxStyle.Exclamation, "AVISO")
        End If
    End Sub


    Private Sub dgvOtros_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvOtros.InitializeLayout
        dgvOtros.DisplayLayout.Bands(0).Columns(0).CellActivation = Activation.NoEdit
        dgvOtros.DisplayLayout.Bands(0).Columns(0).Width = 260
        dgvOtros.DisplayLayout.Bands(0).Columns(1).Width = 70
        dgvOtros.DisplayLayout.Bands(0).Columns(1).CellActivation = Activation.NoEdit
        dgvOtros.DisplayLayout.Bands(0).Columns(1).CellAppearance.TextHAlign = HAlign.Right
    End Sub

    Public Sub ListadoLotesAll()
        Dim testDialog As New FrmConsulta_Ltes_Gastos
        testDialog.pCodigo_Uni = pCodigo_Uni
        testDialog.pCodigo_Alm = pCodigo_Alm
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            If testDialog.dgvListado.Rows.Count > 0 Then
                txtLote.Text = CInt(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("lotegastosid").Value)
                LblDescripLote.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("descripcion").Value)

                'If IsDate((testDialog.dgvListado.DisplayLayout.ActiveRow.Cells("fecha_cierre").Value)) Then
                '    LblCerrado.Visible = True
                '    'Call ActivarControls(False)
                '    'Call LimpiarControls()
                '    'Call MostrarDatoGrid()                    
                'Else
                '    LblCerrado.Visible = False
                '    'Call MostrarDatoGrid()                    
                'End If
            Else
                'dgvListado.DataSource = Nothing
            End If

        Else
            'TxtCodAsistente.Text = ""
        End If
        testDialog.Dispose()
    End Sub

    Private Sub BtnLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLote.Click
        Call ListadoLotesAll()
    End Sub

    Private Sub Obtener_Dato_Lote()
        Dim ObjLg As New lote_gasto
        If IsNumeric(txtLote.Text) Then
            ObjLg = lote_gastoManager.GetItem(txtLote.Text)
            If Not ObjLg Is Nothing Then
                Me.LblDescripLote.Text = ObjLg.nombre.ToString
                lblTotal_Fondo_Fijo.Text = ObjLg.importe
            Else
                Me.LblDescripLote.Text = ""
                lblTotal_Fondo_Fijo.Text = "0.00"
            End If
        End If

        ObjLg = Nothing
    End Sub
End Class