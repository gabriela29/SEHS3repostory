
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmIngresar_Importacion
    Public pCodigo As Long, pCodigo_Almacen As Integer, pAlmacen As String
    Public dtDocumento As DataTable, dtAduana As DataTable
    Public vFormato As String = "", vImpresora As String, vSerieTk, vImprimir As Boolean, vCopias As Integer, vSIgno_Positovo As Boolean
    Public vOkR As Boolean, pTipo_Mov As Integer


    Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
        CheckForIllegalCrossThreadCalls = False

        dtDocumento = New DataTable
        dtAduana = New DataTable
        Try
            Call cursoresManager.Datos_Ventana_Importacion(Tipo_Mov_Mercaderia.tCompras, GestionModulos.modIngreso, dtDocumento, dtAduana)
            e.Result = dtDocumento

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted

        With cboDocumento
            .DataSource = Nothing
            .DataSource = CType(e.Result, DataTable)
            .DataBind()
            .ValueMember = "codigo_doc"
            .DisplayMember = "documento"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If pCodigo > 0 Then
                .Value = pCodigo
            Else
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With cboAduana
            .DataSource = Nothing
            .DataSource = dtAduana
            .DataBind()
            .ValueMember = "aduanaid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 8
            If pCodigo > 0 Then
                .Value = pCodigo
            Else
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        picAjax.Visible = False
        'BtnGrabar.Visible = True


    End Sub

    Private Sub Llenar_Combos()

        Dim dtC As DataTable, dtM As DataTable
        Dim x As Integer = 1
        Dim opcionesv(x), opciones(x) As String

        opcionesv(0) = 0
        opcionesv(1) = 1

        opciones(0) = "CREDITO"
        opciones(1) = "CONTADO"

        dtC = DosOpcionesManager.GetList("Condicion", opcionesv, opciones, x)

        With cboCondicion
            .DataSource = dtC
            .ValueMember = "opcionesv"
            .DisplayMember = "opciones"
            If .Rows.Count > 0 Then
                If pCodigo = 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

        Dim m As Integer = 1
        Dim opcionesvm(m), opcionesm(m) As String

        opcionesvm(0) = "NS"
        opcionesvm(1) = "DO"

        opcionesm(0) = "SOLES"
        opcionesm(1) = "DÓLARES"

        dtM = DosOpcionesManager.GetList("Moneda", opcionesvm, opcionesm, m)

        With cboMoneda
            .DataSource = dtM
            .ValueMember = "opcionesv"
            .DisplayMember = "opciones"
            If .Rows.Count > 0 Then
                If pCodigo = 0 Then
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

    End Sub


    Private Sub FrmIngresar_Importacion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F9 Then
            'ugbDetalle_Pago.Visible = True
            'Me.lblTotal_Cobrar.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
            'Me.txtPaga.Text = FormatNumber(Me.lblTotalDoc2.Text, 2, TriState.True, , TriState.False)
            'lblson.Text = Me.lblEnLetras.Text
            'Me.lblVuelto.Text = "0"
            'txtPaga.Focus()
            ''MessageBox.Show("Procesado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf e.KeyCode = Keys.Escape Then
            If gpProductos.Visible = True Then
                dgvListado.Visible = False
                gpProductos.Visible = False
                txtBuscar.Focus()
            Else
                Me.Close()
                MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
            End If
        End If
    End Sub


    Private Sub FrmIngresar_Importacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call Inicializa()
    End Sub

    Public Sub Inicializa()
        Call Llenar_Combos()
        Call LibreriasFormularios.formatear_grid(dgvListado)
        lblBuscarpor.Tag = 1
        If pCodigo_Almacen = 0 Then
            pCodigo_Almacen = 0
            lblAlmacen.Tag = 0
        Else
            lblAlmacen.Tag = pCodigo_Almacen
            lblAlmacen.Text = pAlmacen
        End If
        vOkR = False

        txtEmision.Value = Now.Date
        txtRecepcion.Value = Now.Date

        GestionTablas.dtTemp = ClsGridDetallePagos.Crear_Grid_Venta("ingreso")
        dgvDetalle_venta.DataSource = GestionTablas.dtTemp
        If Not bwDatos.IsBusy Then
            bwDatos.RunWorkerAsync()
        End If
    End Sub
    Private Sub txtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
        If e.KeyCode <> Keys.Down Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) + 1
        If e.KeyCode <> Keys.Up Then lblBuscarpor.Tag = Val(lblBuscarpor.Tag) - 1
        If Val(lblBuscarpor.Tag) = 0 Then lblBuscarpor.Tag = 3
        If Val(lblBuscarpor.Tag) = 4 Then lblBuscarpor.Tag = 1
        Select Case Val(lblBuscarpor.Tag)
            Case Is = 1
                lblBuscarpor.Text = "Nombre:"
                txtBuscar.MaxLength = 50
            Case Is = 2
                lblBuscarpor.Text = "Código:"
                txtBuscar.MaxLength = 10
            Case Is = 3
                lblBuscarpor.Text = "Barras:"
                txtBuscar.MaxLength = 50
        End Select
    End Sub

    Private Sub txtBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then

            Dim dtProducto As New DataTable

            If lblBuscarpor.Tag = 1 Then 'nombre
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, 10, txtBuscar.Text.Trim, "", 0, "", False)
            ElseIf lblBuscarpor.Tag = 2 Then 'codigo
                If Not IsNumeric(txtBuscar.Text) Then Exit Sub
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, 10, "", "", txtBuscar.Text, "", False)
            ElseIf lblBuscarpor.Tag = 3 Then 'barras
                dtProducto = productoManager.Consultar_Registros(Now.Year, pCodigo_Almacen, 10, "", "", 0, txtBuscar.Text.Trim, False)
            End If

            dgvListado.DataSource = dtProducto
            dgvListado.Visible = True
            gpProductos.Visible = True
            If Not dtProducto Is Nothing Then
                If dtProducto.Rows.Count > 0 Then
                    dgvListado.Rows(0).Selected = True
                    dgvListado.Focus()
                Else
                    txtBuscar.Focus()
                End If
            Else
                txtBuscar.Focus()
            End If

        End If

    End Sub

    Private Sub cboCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCondicion.InitializeLayout
        cboCondicion.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboCondicion.DisplayLayout.Bands(0).Columns(1).Width = cboCondicion.Width
    End Sub

    Private Sub cboMoneda_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMoneda.InitializeLayout
        cboMoneda.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboMoneda.DisplayLayout.Bands(0).Columns(0).Width = cboMoneda.Width
    End Sub

    Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
        Dim xNum As Long = 0
        If IsNumeric(txtNumero.Text) Then
            xNum = txtNumero.Text
            txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
        End If
    End Sub

    Private Sub dgvListado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListado.DoubleClick
        If dgvListado.Rows.Count > 0 Then
            If dgvDetalle_venta.Selected.Rows.Count > 0 Then
                Call ActualizarItem(dgvListado.ActiveRow.Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns(0).Width = 30
            .Columns(0).Header.Caption = "ID"
            .Columns(1).Width = 300
            .Columns(1).Header.Caption = "PRODUCTO"
            .Columns(2).Width = 100
            .Columns(2).Header.Caption = "FAMILIA"
            .Columns(3).Width = 80
            .Columns(3).CellAppearance.TextHAlign = HAlign.Right
            .Columns(3).Header.Caption = "PRECIO"
            .Columns(4).Hidden = True
            .Columns(5).Hidden = True
            .Columns(6).Hidden = True
            .Columns(7).Width = 80
            .Columns(7).Header.Caption = "STOCK"
            .Columns(7).CellAppearance.TextHAlign = HAlign.Center
            .Columns(7).CellAppearance.BackColor = Color.LemonChiffon
            .Columns(8).Hidden = True
            .Columns(9).Hidden = True
            .Columns(10).Hidden = True
        End With

    End Sub

    Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvListado.Rows.Count > 0 Then
                Call ActualizarItem(dgvListado.ActiveRow.Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub ActualizarItem(ByVal vCodigo As Long)
        Dim iOk As Boolean = False

        If Existe_Item(dgvDetalle_venta.DataSource, vCodigo) Then
            MsgBox("El producto ya esta registrado en el documento.", vbInformation, "Ventas")
            dgvListado.Focus()
            iOk = False
            Exit Sub
        End If


    Call CalcularTotales()
    End Sub

    Public Function CalcularTotales() As Boolean
        Dim DtTot As New DataTable
        Dim Drs As DataRow
        Dim vImporte_IGV As Single = 0, vImporte As Single = 0
        Dim vIGV As Single = 0, miIGV As Single = 0
        CalcularTotales = False
    miIGV = Configuracion.pIGV
    Try
            DtTot = GestionTablas.dtTemp

            For Each Drs In DtTot.Rows
                If Boolean.Parse(Drs("afecto_igv")) Then
                    vImporte_IGV = vImporte_IGV + Single.Parse(Drs("subtotal").ToString)
                End If
                vImporte = vImporte + Single.Parse(Drs("subtotal").ToString)

            Next Drs

            vIGV = FormatNumber((vImporte_IGV * miIGV / (100 + miIGV)), 2, TriState.False, TriState.False)

            lblIGV.Text = vIGV

            lblSubTotal.Text = FormatNumber(vImporte - vIGV, 2, TriState.False, TriState.False)
            Me.lblTotalDoc.Text = FormatNumber(vImporte, 2, TriState.False, TriState.False)
            Me.lblTotalDoc2.Text = FormatNumber(vImporte, 2, TriState.False, TriState.False)
            'Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
            Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vImporte)
            CalcularTotales = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Existe_Item(ByVal dtGrid As DataTable, ByVal vCodigo As Long) As Boolean
        Dim Filter As String = "id = " & vCodigo
        Dim drArr() As DataRow
        If Not dtGrid Is Nothing Then
            drArr = dtGrid.Select(Filter, Nothing, DataViewRowState.CurrentRows)
            Existe_Item = drArr.Length > 0
        End If

        drArr = Nothing
    End Function

    Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single, _
                                           ByVal vImporte As Single, ByVal vDescuento As Single, ByVal vComision As Single, _
                                           ByVal vAfecto_IGV As Boolean, ByVal vAfecto_Dzmo As Boolean, ByVal xNuevo As Boolean) As Boolean
        Try

            Dim NwRow As DataRow
            If xNuevo Then
                NwRow = GestionTablas.dtTemp.NewRow
                NwRow.Item("id") = vCodigo
                NwRow.Item("cantidad") = vCantidad
                NwRow.Item("producto") = vNombre_Producto
                NwRow.Item("afecto_igv") = vAfecto_IGV
                NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
                NwRow.Item("precio") = FormatNumber((vImporte / vCantidad), 4, TriState.False, TriState.False)
                NwRow.Item("subtotal") = vImporte
                NwRow.Item("dcto") = vDescuento
                NwRow.Item("item") = 0
                GestionTablas.dtTemp.Rows.Add(NwRow)
            Else
                Dim findTheseVals(vCodigo) As Object

                NwRow = GestionTablas.dtTemp.Rows.Find(vCodigo)
                NwRow.Item("id") = vCodigo
                NwRow.Item("cantidad") = vCantidad
                NwRow.Item("producto") = vNombre_Producto
                NwRow.Item("afecto_igv") = vAfecto_IGV
                NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
                NwRow.Item("precio") = FormatNumber((vImporte / vCantidad), 4, TriState.False, TriState.False)
                NwRow.Item("subtotal") = vImporte
                NwRow.Item("dcto") = vDescuento
                NwRow.Item("item") = 0
                'GestionTablas.dtTemp.Rows.Add(NwRow)
                GestionTablas.dtTemp.AcceptChanges()
                GestionTablas.dtTemp.Select()
                vCodigo = 0
            End If
            'Call CalcularTotales()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try

    End Function

    Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
        Call CalcularTotales()
    End Sub

    Private Sub dgvDetalle_venta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.DoubleClick
        Call Editar_Registro()
    End Sub

    Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
        With dgvDetalle_venta.DisplayLayout.Bands(0)
            .Columns("id").Width = 20
            .Columns("cantidad").Width = 60
            .Columns("cantidad").Header.Caption = "Cant"
            .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
            .Columns("producto").Width = 350
            .Columns("afecto_igv").Header.Caption = "IGV"
            .Columns("afecto_igv").Width = 40
            .Columns("afecto_igv").CellAppearance.TextHAlign = HAlign.Center
            .Columns("afecto_dzmo").Hidden = True
            .Columns("precio").Header.Caption = "Precio"
            .Columns("precio").Width = 80
            .Columns("precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("subtotal").Header.Caption = "Sub Total"
            .Columns("subtotal").Width = 100
            .Columns("subtotal").CellAppearance.TextHAlign = HAlign.Right
            .Columns("subtotal").CellAppearance.BackColor = Color.LemonChiffon
            .Columns("dcto").Hidden = True
            .Columns("item").Hidden = True
        End With
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Hidden = True
            .Columns(3).Width = cboDocumento.Width
            .Columns(4).Hidden = True
            .Columns(5).Hidden = True
            .Columns(6).Hidden = True
        End With

    End Sub

    Private Sub cboDocumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDocumento.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtSerie.Focus()
        End If
    End Sub

    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtEmision.Focus()
        End If
    End Sub

    Private Sub txtEmision_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmision.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtRecepcion.Focus()
        End If
    End Sub

    Private Sub txtRecepcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecepcion.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub Consulta_DNI_SUNAT()
        Dim vProv As String = ""
        TxtAnombreD.Text = ""

        If Not Trim(txtRucDni.Text) = "" Then
            If txtRucDni.TextLength = 11 Then
                If Not IsNumeric(txtRucDni.Text) Then Exit Sub
                'If Funciones.Verificar_ruc(txtRucDni.Text) Then
                Dim ObjPe As New persona
                ObjPe = personaManager.Datos_Persona_Basic("J", txtRucDni.Text.Trim, 0)
                If Not ObjPe Is Nothing Then
                    Valores_Temp.pCodigo_Per = Long.Parse(ObjPe.personaid)
                    Valores_Temp.pTipoPer = ObjPe.tipo
                    If Valores_Temp.pTipoPer = "N" Then
                        Me.TxtAnombreD.Text = ObjPe.ape_pat & " " & ObjPe.ape_mat & " " & ObjPe.nombre
                    Else
                        Me.TxtAnombreD.Text = ObjPe.raz_soc
                    End If

                    vOkR = True
                Else
                    'Dim ObjDR As New datos_ruc
                    Dim ObjDR As New persona
                    ObjDR = LibreriasFormularios.Datos_Persona("RUC", txtRucDni.Text)
                    If Not ObjDR Is Nothing Then
                        If ObjDR.raz_soc = "" Then
                            'vDireccion = ""
                            txtRucDni.Focus()
                            vOkR = False
                        Else
                            TxtAnombreD.Text = ObjDR.raz_soc

                            Valores_Temp.pRaz = ObjDR.raz_soc
                            Valores_Temp.pApe_Pat = ObjDR.ape_pat
                            Valores_Temp.pApe_Mat = ObjDR.ape_mat
                            Valores_Temp.pNombre = ObjDR.nombre
                            Valores_Temp.pDNI = ObjDR.dni

                            Valores_Temp.pDireccion = ObjDR.direccion
                            Valores_Temp.pTipoPer = ObjDR.tipo

                            Valores_Temp.pCodigo_Per = 0
                            vOkR = True
                        End If
                    End If
                    ObjDR = Nothing
                End If
                'Else
                '    MessageBox.Show("Número de RUC no válido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    txtRucDni.Focus()
                'End If
            Else
                MsgBox("Debe tener 11 dígitos el RUC", MsgBoxStyle.Exclamation, "AVISO")
                txtRucDni.Focus()
            End If

        End If
    End Sub

    Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call Consulta_DNI_SUNAT()
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub txtRucDni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRucDni.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub cboCondicion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCondicion.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            cboMoneda.Focus()
        End If
    End Sub

    Private Sub cboMoneda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtCambio.Focus()
        End If
    End Sub

    Private Sub txtCambio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCambio.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        If cboDocumento.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboDocumento, "Debe Seleccionar un Documento Primero")
            camposConError.Add("DOCUMENTO")
        Else
            ErrorProvider1.SetError(cboDocumento, Nothing)
        End If

        If Trim(txtSerie.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtSerie, "Falta Ingresar Serie")
            camposConError.Add("SERIE")
        Else
            ErrorProvider1.SetError(txtSerie, Nothing)
        End If

        If Trim(txtNumero.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtNumero, "Falta Ingresar Nro Documento")
            camposConError.Add("NUMERO")
        Else
            ErrorProvider1.SetError(txtNumero, Nothing)
        End If

        If Not IsDate(txtEmision.Value) Then
            valido = False
            ErrorProvider1.SetError(txtEmision, "Falta Ingresar fecha Emisión")
            camposConError.Add("EMISION")
        Else
            ErrorProvider1.SetError(txtEmision, Nothing)
        End If

        If Not IsDate(txtRecepcion.Value) Then
            valido = False
            ErrorProvider1.SetError(txtRecepcion, "Falta Ingresar fecha Recepción")
            camposConError.Add("RECEPCION")
        Else
            ErrorProvider1.SetError(txtRecepcion, Nothing)
        End If

        If cboAduana.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboAduana, "Falta Seleccionar Aduana")
            camposConError.Add("REGISTRO")
        Else
            ErrorProvider1.SetError(cboAduana, Nothing)
        End If

        If Not IsNumeric(txtAnioDua.Text) Then
            valido = False
            ErrorProvider1.SetError(txtAnioDua, "Falta Ingresar Año DUA")
            camposConError.Add("REGISTRO")
        Else
            ErrorProvider1.SetError(txtAnioDua, Nothing)
        End If

        If Not Long.Parse(txtAnioDua.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(txtAnioDua, "Falta Ingresar Año DUA")
            camposConError.Add("REGISTRO")
        Else
            ErrorProvider1.SetError(txtAnioDua, Nothing)
        End If

        If Not txtRucDni.TextLength = 11 Then
            valido = False
            ErrorProvider1.SetError(txtRucDni, "La catidad de Dígitos del RUC debe ser 11")
            camposConError.Add("RUC")
        Else
            ErrorProvider1.SetError(txtRucDni, Nothing)
        End If

        If Not IsNumeric(txtCambio.Text) Then
            valido = False
            ErrorProvider1.SetError(txtCambio, "El tipo de cambio debe se numérico")
            camposConError.Add("TC")
        Else
            ErrorProvider1.SetError(txtCambio, Nothing)
        End If

        If cboMoneda.Value = "DO" And Single.Parse(txtCambio.Text) <= 0 Then
            valido = False
            ErrorProvider1.SetError(cboMoneda, "El tipo de cambio es Dólares y debe especificar el tipo de cambio")
            camposConError.Add("RUC")
        Else
            ErrorProvider1.SetError(cboMoneda, Nothing)
        End If
        If Not vOkR Then
            valido = False
            ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Proveedor")
            camposConError.Add("RUC")
        Else
            ErrorProvider1.SetError(txtRucDni, Nothing)
        End If


        If cboCondicion.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(cboCondicion, "Debe Seleccionar si la compra es el crédito o Contado")
            camposConError.Add("cboCondicion")
        Else
            ErrorProvider1.SetError(cboCondicion, Nothing)
        End If


        If Not CSng(lblTotalDoc.Text) > 0 Then
            valido = False
            ErrorProvider1.SetError(lblTotalDoc, "El Monto debe ser mayor a cero (0)")
            camposConError.Add("TOTALDOC")
        Else
            ErrorProvider1.SetError(lblTotalDoc, Nothing)
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

    Private Function GrabarRegistroDoc() As Boolean

        Dim objIM As New importacion
        Dim dgvRw As UltraGridRow
        Dim FEmi, FRecep As String, vArray As String = "", ok, xIdProv As Long
        Dim xMISC, xMIGV As Single, vTiene As Boolean
        Dim vNow As String = "", vPeso As Single = 0, vLote As Long = 0
        FEmi = ""
        FRecep = ""


        Try

            FEmi = LibreriasFormularios.Formato_Fecha(txtEmision.Text)

            FRecep = LibreriasFormularios.Formato_Fecha(txtRecepcion.Text)

            vNow = LibreriasFormularios.Formato_Fecha(Now.Date)

            xIdProv = 0
            xMISC = 0
      xMIGV = Configuracion.pIGV

      With objIM
                If pCodigo > 0 Then
                    .importacionid = pCodigo
                Else
                    .importacionid = -1
                End If

                .aniodua = Long.Parse(txtAnioDua.Text) 'Tipo_Mov_Mercaderia.tCompras
                .aduanaid = Long.Parse(cboAduana.Value)
                .numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim) & ""
                .documentoid = cboDocumento.Value
                .almacenid = pCodigo_Almacen
                .proveedorid = Valores_Temp.pCodigo_Per

                .fecha_emision = FEmi.Trim
                .fecha_recepcion = FRecep.Trim

                .moneda = cboMoneda.Value
                .condicion = cboCondicion.Text.Trim
                .vta_bruta = Single.Parse(lblSubTotal.Text)
                .descuento = 0
                .igv = Single.Parse(lblIGV.Text)
                .vta_total = Single.Parse(lblTotalDoc2.Text)
                If cboMoneda.Value = "NS" Then
                    .cambio = "0.000"
                Else
                    .cambio = Single.Parse(txtCambio.Text)
                End If

                .usuarioid = GestionSeguridadManager.idUsuario
                .caja = My.Computer.Name
                .estado = True
                .observacion = txtObservacion.Text.Trim & ""
                .cerrado = True
                .incluye_igv = True
                .descontar_stock = True

                .percepcion = 0
                .signo = IIf(vSIgno_Positovo, "+", "-")
                .opcion = IIf(vSIgno_Positovo, 0, 1)

                .valor_igv = xMIGV

                .gRUC = txtRucDni.Text.Trim
                .gDNI = Valores_Temp.pDNI
                .gApe_Pat = Valores_Temp.pApe_Pat
                .gApe_Mat = Valores_Temp.pApe_Mat
                If Valores_Temp.pTipoPer = "J" Then
                    .gNombre = Valores_Temp.pRaz
                Else
                    .gNombre = Valores_Temp.pNombre
                End If
                .gDireccion = Valores_Temp.pDireccion
                .gTipo_per = Valores_Temp.pTipoPer
                vArray = ""
                'Almacenamos el centro de costo
                For Each dgvRw In Me.dgvDetalle_venta.Rows
                    If dgvRw.Band.Index = 0 Then
                        vTiene = True

                        vArray = vArray & "['" & Str(dgvRw.Cells("id").Value).Trim & "', '" & _
                                                 Str(dgvRw.Cells("cantidad").Value).Trim & "','" & _
                                                 Str(dgvRw.Cells("precio").Value).Trim & "','" & _
                                                 Str(dgvRw.Cells("dcto").Value).Trim & "','" & _
                                                 Str(vPeso).Trim & "','" & _
                                                 Str(vLote).Trim & "','" & _
                                                 vNow.Trim & "','" & _
                                                 IIf(CBool(dgvRw.Cells("afecto_igv").Value), "1", "0") & "'],"
                    End If
                Next

                If vTiene Then
                    vArray = Mid(vArray, 1, Len(vArray) - 1)
                    vArray = "array[" & vArray & "]"
                Else
                    vArray = "null"
                End If

            End With

            ok = importacionManager.Agregar(pCodigo, objIM, vArray)

            If Not ok > 0 Then
                GrabarRegistroDoc = False
                Exit Function
            End If
            GrabarRegistroDoc = True
            objIM = Nothing
        Catch ex As Exception
            GrabarRegistroDoc = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub tsGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If GrabarRegistroDoc() Then
                    FrmIngreso_Importacion.Actualizar()
                    Me.Close()
                    MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
                End If
            End If
        End If
    End Sub

    Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
        If Not cboDocumento.DataSource Is Nothing Then
            vSIgno_Positovo = IIf(cboDocumento.ActiveRow.Cells("signo").Value = "+", True, False)
        End If
    End Sub

    Private Sub Editar_Registro()
        If dgvDetalle_venta.Rows.Count > 0 Then
            If dgvDetalle_venta.Selected.Rows.Count > 0 Then
                Dim vCodigo As Long
                vCodigo = (dgvDetalle_venta.ActiveRow.Cells(0).Value)

      End If
        End If
    End Sub


    Private Sub dgvDetalle_venta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle_venta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Editar_Registro()
        End If
    End Sub

    Private Sub txtAnioDua_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioDua.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            txtBuscar.Focus()
        End If
    End Sub

    Private Sub tsImportar_Click(sender As Object, e As EventArgs) Handles tsImportar.Click

        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim vFile As String = ""
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.xls)|*.xlsx"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = openFileDialog1.OpenFile()
                If (myStream IsNot Nothing) Then
                    ' Insert code to read the stream here.
                    vFile = openFileDialog1.FileName.Trim

                    'Dim DS As System.Data.DataSet
                    'Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                    'Dim MyConnection As System.Data.OleDb.OleDbConnection
                    'Try
                    '    'string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
                    '    'MyConnection = New System.Data.OleDb.OleDbConnection( _
                    '    '      "provider=Microsoft.ACE.OLEDB.12.0; " & _
                    '    '      "data source='" & vFile & "'; " & _
                    '    '      "Extended Properties=Excel 12.0 Xml; HDR=yes;")
                    '    MyConnection = New System.Data.OleDb.OleDbConnection(
                    '            "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                    '            "Extended Properties='Excel 12.0 Xml';" & _
                    '            "Data Source=" & vFile)

                    '    '' Select the data from Sheet1 of the workbook.
                    '    'MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [ACES$]", MyConnection)

                    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [ACES$]", MyConnection)
                    '    DS = New System.Data.DataSet()
                    '    MyCommand.Fill(DS)
                    '        Catch ex As Exception
                    '    MessageBox.Show("Error al importar", ex.Message, MessageBoxButtons.OK)
                    'Finally
                    '    'MyConnection.Close()
                    'End Try
                    'LLENAMOS EL GRID
                    'Dim Dt As New DataTable
                    'Dt = GetDataExcel(vFile)
                    'Call loadFile(vFile)
                End If
            Catch Ex As Exception
                MessageBox.Show("Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub

    'Private Shared Function GetDataExcel(rutaLibroExcel As String) As DataTable

    '    'If (String.IsNullOrWhiteSpace(rutaLibroExcel)) Then
    '    '    Throw New ArgumentNullException("rutaLibroExcel")
    '    'End If

    '    ' Cadena de conexión con el libro de Excel
    '    '
    '    Dim cadenaConexion As String =
    '        "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0 Xml';" &
    '        "Data Source=" & rutaLibroExcel '& "Extended Properties=""Excel 8.0;HDR=YES;"

    '    Dim dt As DataTable = Nothing

    '    Using cnn As New OleDbConnection(cadenaConexion)
    '        Dim cmd As OleDbCommand = cnn.CreateCommand()
    '        cmd.CommandText = "SELECT * FROM [Hoja1$]"
    '        Dim da As New OleDbDataAdapter(cmd)
    '        dt = New DataTable()
    '        da.Fill(dt)
    '    End Using

    '    Return dt

    'End Function

    'Private Sub loadFile(sRuta As String)


    '    ' Create new Application.
    '    Dim excel As Application = New Application
    '    ' Open Excel spreadsheet.
    '    'Dim w As Workbook = excel.Workbooks.Open("D:\Horarios\HorarioSetiembre.xls")

    '    Dim w As Workbook = excel.Workbooks.Open(sRuta)        ' Loop over all sheets.
    '    ' For i As Integer = 1 To w.Sheets.Count
    '    Dim i As Integer = w.Sheets.Count
    '    ' Get sheet.
    '    'Dim sheet As Worksheet = w.Sheets(i)
    '    Dim sheet As Worksheet = w.Sheets(1)
    '    ' Get range.
    '    Dim r As Range = sheet.UsedRange
    '    ' Load all cells into 2d array.
    '    Dim array(,) As Object = r.Value(XlRangeValueDataType.xlRangeValueDefault)
    '    ' Scan the cells.
    '    If array IsNot Nothing Then
    '        Console.WriteLine("Length: {0}", array.Length)
    '        ' Get bounds of the array.
    '        Dim bound0 As Integer = array.GetUpperBound(0)
    '        Dim bound1 As Integer = array.GetUpperBound(1)

    '        Console.WriteLine("Dimension 0: {0}", bound0)
    '        Console.WriteLine("Dimension 1: {0}", bound1)

    '        If bound1 = 5 Then
    '            'las columnas exactas
    '            MessageBox.Show("AVISO", "Columnas Exactas", MessageBoxButtons.OK)
    '        Else
    '            MessageBox.Show("AVISO", "La Plantilla de Excel que trata de cargar tiene demasiadas columnas o menos columnas que las requeridas, Corriga la plantilla y vuelva a intentar", MessageBoxButtons.OK)
    '            w.Close()
    '            Exit Sub
    '        End If

    '        If Len(Trim(array(bound0, 1))) = 0 Then
    '            MessageBox.Show("AVISO", "La Plantilla de Excel que trata de cargar tiene Filas en blanco", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            w.Close()
    '            Exit Sub
    '        End If
    '        ' Loop over all elements.

    '        For j As Integer = 2 To bound0
    '            MessageBox.Show(array(j, 1))
    '        Next

    '    End If

    '    w.Close()
    'End Sub

End Class