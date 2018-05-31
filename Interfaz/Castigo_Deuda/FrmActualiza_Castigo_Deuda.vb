Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmActualiza_Castigo_Deuda
    Public vUnidad_Negocio As String, vCodigo_Uni, vCodigo_Pro As Long, vProceso As String, xCalcular As Boolean = True

    Private Sub formatear_grid()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        'Dim resourcesx As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controles))
        Me.dgvListado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
        Me.dgvListado.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        'Me.dgvListado.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvListado.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
        Me.dgvListado.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.dgvListado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvListado.DisplayLayout.Override.CardAreaAppearance.BackColor = Color.Transparent
        Me.dgvListado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]

        Appearance1.AlphaLevel = 98
        Appearance1.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance1.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        'Appearance1.ImageBackgroundAlpha = Infragistics.Win.Alpha.UseAlphaLevel
        ''Appearance1.BorderAlpha = Alpha.Opaque

        'Appearance1.BackColor = Color.White
        Appearance1.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Centered
        Appearance1.ImageBackground = Global.Cliente.My.Resources.Resources.fileprint        'foto_e_commerce_1
        Me.dgvListado.DisplayLayout.Appearance = Appearance1

        Me.dgvListado.DisplayLayout.Appearance.ForeColor = Color.Navy
        Me.dgvListado.DisplayLayout.Appearance.ForegroundAlpha = Alpha.Opaque
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        '--------------------------
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.None
        Appearance62.FontData.BoldAsString = "True"
        Appearance62.FontData.Name = "Tahoma"
        Appearance62.FontData.SizeInPoints = 8.25!
        Appearance62.ForeColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Appearance62.ImageBackground = CType(Infragistics.Win.Resources.GetObject("Appearance55.ImageBackground"), System.Drawing.Image)
        Appearance62.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Tiled
        Appearance62.TextHAlignAsString = "Left"
        Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62
        Me.dgvListado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed

        '--------------------------
        ''Appearance62.BackColor = Color.RoyalBlue   'System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(214, Byte), Integer))
        ''Appearance62.BackColor2 = Color.LightCyan   'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        ''Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        ' ''Appearance62.FontData.BoldAsString = "True"
        ''Appearance62.FontData.Name = "Tahoma"
        ''Appearance62.FontData.SizeInPoints = 10.0!
        ''Appearance62.ForeColor = System.Drawing.Color.Blue
        ''Appearance62.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        ''Me.dgvListado.DisplayLayout.Override.HeaderAppearance = Appearance62

        'Appearance63.BackColor = System.Drawing.Color.SteelBlue
        'Appearance63.BackColor2 = System.Drawing.Color.LightCyan
        'Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        'Appearance63.ThemedElementAlpha = Alpha.Opaque
        'Me.dgvListado.DisplayLayout.Override.RowSelectorAppearance = Appearance63

        Me.dgvListado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle

        ''Appearance64.BackColor = System.Drawing.Color.White
        Appearance64.BackColor = System.Drawing.Color.LemonChiffon
        'Appearance64.BackColor2 = System.Drawing.Color.White
        'Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical        
        Appearance64.FontData.BoldAsString = "True"
        Appearance64.ForeColor = Color.Navy
        'Appearance64.ForeColor = Color.White
        Me.dgvListado.DisplayLayout.Override.SelectedRowAppearance = Appearance64

        Me.dgvListado.DisplayLayout.RowConnectorColor = Color.SteelBlue    'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        'dgvListado.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
        Me.dgvListado.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid

        ''Me.dgvListado.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        'para Seleccionar solo una Fila
        'Me.dgvListado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single

        'Para seleccionar toda la Fila
        'Me.dgvListado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect

        'Me.dgvListado.Location = New System.Drawing.Point(0, 60)
        'Me.dgvListado.Name = "dgvListado"
        'Me.dgvListado.Size = New System.Drawing.Size(656, 239)
        'Me.dgvListado.TabIndex = 1
        ''Me.dgvListado.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
    End Sub

    Private Sub FrmActualiza_Castigo_Deuda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvListado.DataSource = Nothing
        dgvTemp.DataSource = Nothing
        Call formatear_grid()
        Me.dgvTemp.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        txtFecha.Value = Date.Now.Date
        LblProceso_Matricula.Tag = vCodigo_Pro
        LblProceso_Matricula.Text = vProceso
        LblUnidad.Text = vUnidad_Negocio
        Call Llenar_Combo()
    End Sub

    Private Sub Llenar_Combo()
        Dim DtProv_C As New DataTable        

        DtProv_C = castigo_deudaManager.GetCombo(vCodigo_Uni)
        cboProvision_Castigo.DataSource = DtProv_C
        cboProvision_Castigo.ValueMember = "codigo"
        cboProvision_Castigo.DisplayMember = "observacion"
    End Sub

    Private Sub bwLlenar_Grid_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Grid.DoWork
        Dim DtObl_L As New DataTable, DtGrid As New DataTable

        DtObl_L = obligacion_legalManager.Mostrar_Obligacion_For_Castigo(cboProvision_Castigo.Value)

        e.Result = DtObl_L

    End Sub

    Private Sub bwLlenar_Grid_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Grid.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        picAjax.Visible = False
        'dgvListado.Refresh()
        Me.LblRegistros.Text = "Existen " & dgvListado.Rows.Count & " Registros Mostrados"
    End Sub



    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Width = 20
            .Columns(3).Style = ColumnStyle.CheckBox

            .Columns(4).Width = 250
            .Columns(4).CellActivation = Activation.NoEdit
            .Columns(5).Width = 150
            .Columns(5).CellActivation = Activation.NoEdit
            .Columns(6).CellActivation = Activation.NoEdit
            .Columns(7).CellAppearance.TextHAlign = HAlign.Right
            .Columns(7).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(7).CellActivation = Activation.NoEdit
        End With
    End Sub

    Private Sub Calcular_Totales_Grid(ByVal sender As Object, ByVal xG As Boolean)
        Dim dtDgv As UltraGrid, dgvRw As UltraGridRow
        dtDgv = dgvListado
        Dim vPaga As Single = 0

        For Each dgvRw In dtDgv.Rows
            If dgvRw.Band.Index = 0 Then
                If xG Then
                    If dgvRw.Cells("sel").Text = "True" Then
                        vPaga += dgvRw.Cells("importe").Value
                    End If
                Else
                    vPaga += dgvRw.Cells("importe").Value
                End If
            End If
        Next
        If xG Then
            Me.LblTotalSel.Text = FormatNumber(vPaga, 2, TriState.True, , TriState.False)
        Else
            Me.lblTotalTemp.Text = FormatNumber(vPaga, 2, TriState.True, , TriState.False)
        End If

    End Sub

    Private Sub dgvListado_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles dgvListado.BeforeCellUpdate

        If e.Cell.Column.Index = 3 Then
            dgvListado.Update()            
        End If
        If xCalcular Then
            Call Calcular_Totales_Grid(sender, True)
        End If
    End Sub

    Private Function Actiualizar_Grid_Temp(ByVal sender As Object) As DataTable
        Dim DtTemp As New DataTable, NwRow As DataRow
        Dim dtGrid As UltraGrid, dgvTemp As UltraGridRow
        DtTemp = ClsGridDetallePagos.Crear_Grid_Castigo_Deuda("castigo_deuda")
        dtGrid = sender
        For Each dgvTemp In dtGrid.Rows
            If dgvTemp.Band.Index = 0 Then

                'If dgvTemp.Cells("sel").Text = "True" Then
                If dgvTemp.Cells("importe").Value > 0 Then
                    NwRow = DtTemp.NewRow
                    NwRow.Item("codigo") = dgvTemp.Cells("codigo").Value
                    NwRow.Item("codigo_alu") = dgvTemp.Cells("codigo_alu").Value
                    NwRow.Item("codigo_con") = dgvTemp.Cells("codigo_con").Value
                    NwRow.Item("alumno") = dgvTemp.Cells("alumno").Value
                    NwRow.Item("concepto") = dgvTemp.Cells("concepto").Value
                    NwRow.Item("vencimiento") = dgvTemp.Cells("vencimiento").Value
                    NwRow.Item("importe") = CSng(dgvTemp.Cells("importe").Value)
                    DtTemp.Rows.Add(NwRow)
                End If

                'End If
            End If
        Next

        Return DtTemp
    End Function


    Private Sub btnPasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasar.Click
        dgvTemp.DataSource = Actiualizar_Grid_Temp(dgvListado)
        dgvTemp.Visible = True
        Call Calcular_Totales_Grid(dgvTemp, False)
    End Sub

    Private Sub dgvTemp_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvTemp.InitializeLayout
        With dgvTemp.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Width = 250
            .Columns(3).CellActivation = Activation.NoEdit
            .Columns(4).Width = 150
            .Columns(4).CellActivation = Activation.NoEdit
            .Columns(5).CellActivation = Activation.NoEdit
            .Columns(6).CellAppearance.TextHAlign = HAlign.Right
            .Columns(6).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(6).CellActivation = Activation.NoEdit
            Me.dgvListado.DisplayLayout.Appearance.BackColor = Color.White
        End With
    End Sub

    Private Function ValidarControles() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        'Concepto
        If cboProvision_Castigo.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboProvision_Castigo, "Debe Seleccionar una provisión")
            camposConError.Add("Concepto")
        Else
            ErrorProvider1.SetError(cboProvision_Castigo, Nothing)
        End If

        'Nro Voto
        If txtNroVoto.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(txtNroVoto, "Debe ingresar nro de Voto, de lo contrario registrar (0)")
            camposConError.Add("NROVOTO")
        Else
            ErrorProvider1.SetError(txtNroVoto, Nothing)
        End If

        ' Fecha
        If Not IsDate(Me.txtFecha.Value) Then
            valido = False
            ErrorProvider1.SetError(txtFecha, "Fecha No Válida")
            camposConError.Add("FECHA")
        Else
            ErrorProvider1.SetError(txtFecha, Nothing)
        End If

        If Not IsDate(Me.lblFechaProv.Text) Then
            valido = False
            ErrorProvider1.SetError(lblFechaProv, "Fecha No Válida")
            camposConError.Add("FECHA Prov")
        Else
            ErrorProvider1.SetError(lblFechaProv, Nothing)
        End If

        'If IsDate(txtFecha.Value) And IsDate(lblFechaProv.Text) Then
        '    Dim xAñosDIf As Long
        '    xAñosDIf = DateDiff(DateInterval.Year, CDate(lblFechaProv.Text), CDate(txtFecha.Value), , )
        '    If xAñosDIf < 1 Then
        '        valido = False
        '        MessageBox.Show("Está intentando Castigar una deuda en un periodo provisionada menor a un año", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Else
        '        valido = True
        '    End If

        'End If

        ' Observación
        If Trim(Me.txtObservacion.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtObservacion, "Debe Registrar una Observación")
            camposConError.Add("Observacion")
        Else
            ErrorProvider1.SetError(txtObservacion, Nothing)
        End If

        ' lblProceso
        If (Me.LblProceso_Matricula.Text) = "" Or LblProceso_Matricula.Tag = 0 Then
            valido = False
            ErrorProvider1.SetError(LblProceso_Matricula, "No hay Proceso Activo")
            camposConError.Add("Proceso")
        Else
            ErrorProvider1.SetError(LblProceso_Matricula, Nothing)
        End If

        ' Unidad
        If (Me.LblUnidad.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(LblUnidad, "Datos de Colegio no válido")
            camposConError.Add("UNIDAD")
        Else
            ErrorProvider1.SetError(LblUnidad, Nothing)
        End If

        ' Grid
        If Not (Me.dgvTemp.Rows.Count) > 0 Then
            valido = False
            ErrorProvider1.SetError(dgvTemp, "No hay Registros que Registrar")
            camposConError.Add("DETALLES")
        Else
            ErrorProvider1.SetError(dgvTemp, Nothing)
        End If

        ' Total a Cobrar
        If Not CSng(Me.lblTotalTemp.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(lblTotalTemp, "El monto a Castigar debe ser Mayor de Cero(0)")
            camposConError.Add("TOTAL")
        Else
            ErrorProvider1.SetError(lblTotalTemp, Nothing)
        End If




        If Not valido Then
            Lblerror.Text = "Introduzca y/o Seleccione un valor en  "

            For Each campo In camposConError
                Lblerror.Text &= campo & ", "
            Next
            Lblerror.Text = Lblerror.Text.Substring(0, Lblerror.Text.Length - 2)
        End If

        Return valido
    End Function

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim ObjO As New castigo_deuda, vTiene As Boolean = False
        Dim dgvRw As UltraGridRow
        Dim xIdRet As Long = 0, vCod_us As Long = GestionSeguridadManager.idUsuario
        Dim vCod_Apo As Long = 0, vSerie As Long = 0
        Dim vArray_O, xFecha As String

        If MessageBox.Show("¿Está Seguro de Grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Try

            If ValidarControles() Then
                If BtnGrabar.Text = "&Grabar" Then

                    With ObjO
                        .codigo_uni = vCodigo_Uni
                        .codigo_con = cboProvision_Castigo.DisplayLayout.ActiveRow.Cells(1).Value
                        .numero = Trim(txtNroVoto.Text)
                        xFecha = Year(txtFecha.Value) & "/" & Format(Month(txtFecha.Value), "00") & "/" & Format(Day(txtFecha.Value), "00")
                        .fecha = xFecha.Trim
                        .observacion = Trim(txtObservacion.Text)
                        .caja = My.Computer.Name & ""
                        .codigo_usu = GestionSeguridadManager.idUsuario
                    End With

                    'Lo metemos en el array los Grid
                    vArray_O = ""

                    'Deudas a Castigar
                    For Each dgvRw In Me.dgvTemp.Rows
                        If dgvRw.Band.Index = 0 Then
                            vTiene = True
                            vArray_O = vArray_O & "['" & Trim(Str(dgvRw.Cells("codigo").Value)) & "', '" & _
                                                         Trim((dgvRw.Cells("importe").Value)) & "','" &  "'],"
                        End If
                    Next
                    If vTiene Then
                        vArray_O = Mid(vArray_O, 1, Len(vArray_O) - 1)
                        vArray_O = "array[" & vArray_O & "]"
                    Else
                        vArray_O = "null"
                    End If
                    
                    xIdRet = castigo_deudaManager.Grabar(ObjO, vArray_O, cboProvision_Castigo.Value)
                    'If ClsImpresiones.Imprimir_Rpt_Cursor(xIdRet) Then 'If ClsImpresiones.Imprimir_Rpt(xIdRet) Then
                    '    'If operacionManager.Incrementar_Impresiones(xIdRet) Then
                    '    '    Cerrar = True
                    '    'End If
                    'End If
                    'FrmControl_Pagos.bwLlenar_Grid.RunWorkerAsync()

                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        If Not cboProvision_Castigo.Text = "" Then
            If Not bwLlenar_Grid.IsBusy Then
                picAjax.Visible = True
                bwLlenar_Grid.RunWorkerAsync()
            End If
        End If    

    End Sub

    Private Sub chkActivar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivar.CheckedChanged
        Dim dgvRw As UltraGridRow
        xCalcular = False
        For Each dgvRw In dgvListado.Rows
            If dgvRw.Band.Index = 0 Then
                'If dgvRw.Cells("sel").Text = "True" Then
                dgvRw.Cells("sel").Value = chkActivar.Checked
                'Else
                'dgvRw.Cells("sel").Value = 1
                'End If
            End If
        Next
        Call Calcular_Totales_Grid(sender, True)
    End Sub

    Private Sub cboProvision_Castigo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboProvision_Castigo.InitializeLayout

    End Sub

    Private Sub cboProvision_Castigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvision_Castigo.Validated
        If Not bwLlenar_Grid.IsBusy Then
            picAjax.Visible = True
            bwLlenar_Grid.RunWorkerAsync()
            lblFechaProv.Text = cboProvision_Castigo.DisplayLayout.ActiveRow.Cells(2).Value
        End If
    End Sub

End Class