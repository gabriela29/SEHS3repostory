
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmBoleteo_Colportor
    Public pCodigo As Long, pCodigo_Alm As Integer, pAlmacen As String
    Public pTipoPer As String = "", pCodigo_Per As Long, pCodigo_Asis As Long, pDireccion As String = "", pApe_Pat As String = "", pApe_Mat As String = "", pPersona As String = ""
    Public dtDocumento As DataTable, dtDoc_Dzmo As DataTable, dtFP As DataTable
    Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0
    Public vCodigo_Doc As Integer, vFormatoD As String = "", vImpresoraD As String = "", vSerieTkD = "", vImprimirD As Boolean, vCopiasD As Integer
    Public vCodigo_DocD As Integer = 0, vCodigo_SerieD As Long = 0, vSerieD As String = "", vNumeroD As Long = 0
    Public vOkR As Boolean, zReniec As Boolean

    Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Usu As Long, vCaja As String = ""
        dtDocumento = New DataTable
        dtDoc_Dzmo = New DataTable
        dtFP = New DataTable
        vCodigo_Usu = GestionSeguridadManager.idUsuario
        vCaja = My.Computer.Name
        Try
            Call cursoresManager.Datos_Ventana_venta(pCodigo_Alm, vCodigo_Usu, _
                                            vCaja, "VENTACOLP", dtDocumento, dtDoc_Dzmo, dtFP)
            e.Result = dtDocumento

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted

        With cboDocumento
            .DataSource = Nothing
            .DataSource = dtDocumento
            .DataBind()
            .ValueMember = "codigo_serie"
            .DisplayMember = "documento"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If pCodigo > 0 Then
                .Value = pCodigo
            Else
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        If Not dtDoc_Dzmo Is Nothing Then
            If dtDoc_Dzmo.Rows.Count > 0 Then
                Dim objReader As DataRow
                'Dim dSerie As String = "", dNUmero As Long = 0
                objReader = dtDoc_Dzmo.Rows(0)

                vSerieD = objReader.Item("serie")
                vNumeroD = objReader.Item("correlativo")
                txtRecibo_Dzmo.Text = vSerieD & "-" & Format(vNumeroD, "00000000")

                vCodigo_DocD = objReader.Item("documentoid")
                vFormatoD = objReader.Item("formato")
                vImpresoraD = objReader.Item("impresora")
                vSerieTkD = objReader.Item("serie_tk")
                vImprimirD = objReader.Item("imprimir")
                vCopiasD = objReader.Item("copias")
                vCodigo_SerieD = objReader.Item("codigo_serie")
            End If
        End If

        picAjax.Visible = False
        'BtnGrabar.Visible = True


    End Sub

    Private Sub Llenar_Combos()

        Dim dtM As DataTable        
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

            Dim dtProducto As New DataTable, vProdId As Long = 0


            If lblBuscarpor.Tag = 1 Then 'nombre
                dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCodigo_Asis, 0, 50, txtBuscar.Text.Trim, 0, "")
            ElseIf lblBuscarpor.Tag = 2 Then 'codigo
                If IsNumeric(txtBuscar.Text) Then
                    vProdId = Long.Parse(txtBuscar.Text)
                End If
                dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCodigo_Asis, 0, 50, "", vProdId, "")
            ElseIf lblBuscarpor.Tag = 3 Then 'barras
                dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCodigo_Asis, 0, 50, "", 0, txtBuscar.Text.Trim)
            End If

            dgvListado.DataSource = dtProducto
            dgvListado.Visible = True
            gpProductos.Visible = True
            If Not dtProducto Is Nothing Then
                If dtProducto.Rows.Count > 0 Then
                    dgvListado.Focus()
                Else
                    txtBuscar.Focus()
                End If
            Else
                txtBuscar.Focus()
            End If

        End If

    End Sub

    Private Sub Datos_Colportor()
        Dim ObjPe As New persona
        Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

        ObjPe = personaManager.Datos_Persona_Colportaje("N", pCodigo_Alm, pCodigo_Per, "")

        If Not ObjPe Is Nothing Then
            'pCodigo_Per = Long.Parse(ObjP.personaid)
            vApe_Pat = ObjPe.ape_pat
            vApe_Mat = ObjPe.ape_mat
            vNombre = ObjPe.nombre
            TxtAnombreD.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
            lblC_Costo.Text = ObjPe.c_costo & ""
            pCodigo_Asis = Long.Parse(ObjPe.codio_Asis)
            vOkR = True
            Call Datos_Asistente()
            'lblNombreCta.Text = ObjPe.nrocuenta & ""
            'txtBuscar.Focus()
        Else
            TxtAnombreD.Text = ""
            lblC_Costo.Text = ""
            vOkR = False
        End If
    End Sub

    Private Sub Datos_Asistente()
        Dim ObjPe As New persona
        Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

        ObjPe = personaManager.Datos_Persona_Colportaje("N", pCodigo_Alm, pCodigo_Asis, "")

        If Not ObjPe Is Nothing Then

            vApe_Pat = ObjPe.ape_pat
            vApe_Mat = ObjPe.ape_mat
            vNombre = ObjPe.nombre
            txtAsistente.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
            txtNroCuenta.Text = ObjPe.nrocuenta & ""
        Else
            txtAsistente.Text = ""
            txtNroCuenta.Text = ""
        End If
    End Sub

    Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ObjPe As New persona
            Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

            ObjPe = personaManager.Datos_Persona_Basic("N", txtRucDni.Text, pCodigo_Per)

            If Not ObjPe Is Nothing Then
                pCodigo_Per = Long.Parse(ObjPe.personaid)
                vApe_Pat = ObjPe.ape_pat
                vApe_Mat = ObjPe.ape_mat
                vNombre = ObjPe.nombre
                TxtAnombreD.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
                'lblC_Costo.Text = ObjPe.nrocuenta & ""
                Call Datos_Colportor()
                'lblNombreCta.Text = ObjPe.nrocuenta & ""
                txtBuscar.Focus()
            Else
                TxtAnombreD.Text = ""
                txtRucDni.Focus()
            End If
        End If
    End Sub

    Private Sub Nueva_Venta()
        Dim vF As Date = Now.Date
        If IsDate(txtFecha.Value) Then
            vF = txtFecha.Value
        End If

        Call Llenar_Combos()
        'Call formatear_grid()
        lblClientePor.Tag = 1
        lblBuscarpor.Tag = 1
        'Call Habilitar_RUC_DNI(1)
        'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small

        txtFecha.Value = Now.Date
        txtvencimiento.Text = vF.AddDays(15)


        picAjax.Visible = True

        lblAlmacen.Tag = pCodigo_Alm
        lblAlmacen.Text = pAlmacen

        GestionTablas.dtTemp = ClsGridDetallePagos.Crear_Grid_VentaP("venta")
        dgvDetalle_venta.DataSource = GestionTablas.dtTemp
        If Not bwDatos.IsBusy Then
            bwDatos.RunWorkerAsync()
        End If
        'Call CalcularTotales()
        txtRucDni.Focus()
    End Sub

    Private Sub FrmBoleteo_Colportor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtRucDni.Text = ""
        TxtAnombreD.Text = ""
        lblC_Costo.Text = ""

        txtAsistente.Text = ""
        txtNroCuenta.Text = ""
        txtRecibo_Dzmo.Text = ""

        Call Nueva_Venta()
    Call LibreriasFormularios.formatear_grid(dgvListado)

    ugTotales.Text = " Subtotal                                     IGV (" & Configuracion.pIGV & "%)                  DZMO 10%"

  End Sub

    Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
        Call CalcularTotales()
    End Sub

    Private Sub dgvDetalle_venta_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetalle_venta.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvDetalle_venta.Rows.Count > 0 Then
                'Call Editar_Registro()
            End If
        End If
    End Sub

    Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
        With dgvDetalle_venta.DisplayLayout.Bands(0)
            .Columns("id").Width = 20
            .Columns("cantidad").Width = 60
            .Columns("cantidad").Header.Caption = "Cant"
            .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
            .Columns("producto").Width = 300
            .Columns("afecto_igv").Header.Caption = "IGV"
            .Columns("afecto_igv").Width = 40
            .Columns("afecto_igv").CellAppearance.TextHAlign = HAlign.Center
            .Columns("afecto_dzmo").Header.Caption = "DZMO"
            .Columns("afecto_dzmo").Width = 40
            .Columns("afecto_dzmo").CellAppearance.TextHAlign = HAlign.Center
            .Columns("precio").Header.Caption = "Precio"
            .Columns("precio").Width = 80
            .Columns("precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("dcto").Header.Caption = "Dscto"
            .Columns("dcto").Width = 80
            .Columns("dcto").CellAppearance.TextHAlign = HAlign.Right
            .Columns("subtotal").Header.Caption = "Importe"
            .Columns("subtotal").Width = 100
            .Columns("subtotal").CellAppearance.TextHAlign = HAlign.Right
            .Columns("subtotal").CellAppearance.BackColor = Color.LemonChiffon

            .Columns("item").Hidden = True
            .Columns("tipodscto").Hidden = True
            .Columns("xctajedscto").Hidden = True
            .Columns("exonerada").Hidden = True
        End With
    End Sub

    Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
        If Not cboDocumento.DataSource Is Nothing Then
            vCodigo_Doc = cboDocumento.ActiveRow.Cells("documentoid").Value
            txtSerie.Text = cboDocumento.ActiveRow.Cells("serie").Value
            txtNumero.Text = Format((cboDocumento.ActiveRow.Cells("correlativo").Value), "00000000")
            vFormato = cboDocumento.ActiveRow.Cells("formato").Value
            vImpresora = cboDocumento.ActiveRow.Cells("impresora").Value
            vSerieTk = cboDocumento.ActiveRow.Cells("serie_tk").Value
            vImprimir = CBool(cboDocumento.ActiveRow.Cells("imprimir").Value)
            vCopias = cboDocumento.ActiveRow.Cells("copias").Value
            vCodigo_Serie = cboDocumento.ActiveRow.Cells("codigo_serie").Value
        End If
    End Sub

    Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
        Dim xNum As Long = 0
        If IsNumeric(txtNumero.Text) Then
            xNum = txtNumero.Text
            txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
        End If
    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            '.Columns(2).Hidden = True
            .Columns("documento").Width = cboDocumento.Width
            '.Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
            .Columns(5).Hidden = True
            .Columns(6).Hidden = True
            .Columns(7).Hidden = True
            .Columns(8).Hidden = True
            .Columns("codigo_serie").Hidden = True
            .Columns("copias").Hidden = True
        End With
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
                Dim vCodigo As Long
                vCodigo = (dgvListado.ActiveRow.Cells(0).Value)

                If Val(dgvListado.ActiveRow.Cells(7).Value) < 1 Then
                    MessageBox.Show("No hay stock suficiente para vender", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvListado.Focus()
                    Exit Sub
                End If

                If Existe_Item(dgvDetalle_venta.DataSource, vCodigo) Then
                    MsgBox("El producto ya esta registrado en el documento.", vbInformation, "Ventas")
                    dgvListado.Focus()
                    Exit Sub
                End If


                Dim frmIV As New FrmActualizar_Item_Cons
                With frmIV
                    .gQue_Form_Llama = "BOLETEO_COLP"
                    .vStock = Str(dgvListado.ActiveRow.Cells(7).Value)
                    .pVer_Descuento = False '(dgvListado.ActiveRow.Cells(6).Visible)
                    .pVer_Precio = True
                    .pVer_Comision = False
                    .pPrecio = Val(dgvListado.ActiveRow.Cells(4).Value)
                    .pCodigo_Producto = vCodigo
                    .pNombre_Producto = Trim(dgvListado.ActiveRow.Cells(1).Value)
                    .pAfecto_IGV = CBool(dgvListado.ActiveRow.Cells(6).Value)
                    .pAfecto_Dzmo = CBool(dgvListado.ActiveRow.Cells(10).Value)
                    .pCodigo_Almacen = lblAlmacen.Tag
                    .pNuevo = True
                    .pCantidad_Adicional = 0
                    .pDevolucion = False

                    'If Val(Me.lblReferencia.Tag) > 0 Then
                    '    frmActualizar_Item.pDevolucion = True
                    '    frmActualizar_Item.vStock = Str(dgvListado.ActiveRow.Cells(7).Value)
                    'End If
                    'FrmActualizar_Item_Venta.pCantidad = 1
                    gpProductos.Visible = False
                    frmIV.ShowDialog()
                    txtBuscar.Focus()
                    Call CalcularTotales()
                End With

            End If

        End If
    End Sub

    Public Function Existe_Item(ByVal dtGrid As DataTable, ByVal vCodigo As Long) As Boolean
        Dim Filter As String = "id = " & vCodigo
        Dim drArr() As DataRow
        If Not dtGrid Is Nothing Then
            drArr = dtGrid.Select(Filter, Nothing, DataViewRowState.CurrentRows)
            Existe_Item = drArr.Length > 0
        End If

        drArr = Nothing
    End Function

    Private Sub Editar_Registro()
        If dgvDetalle_venta.Rows.Count > 0 Then
            If dgvDetalle_venta.Selected.Rows.Count > 0 Then
                Dim vCodigo As Long, vStock As Long
                vCodigo = (dgvDetalle_venta.ActiveRow.Cells(0).Value)
                vStock = inventariosManager.Mi_Stock(vCodigo, lblAlmacen.Tag, 0)
                Dim frmIV As New FrmActualizar_Item_Cons
                With frmIV
                    .gQue_Form_Llama = "BOLETEO_COLP"
                    .vStock = vStock
                    .pCantidad = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("cantidad").Value)
                    .pVer_Descuento = Not (dgvDetalle_venta.DisplayLayout.Bands(0).Columns("dcto").Hidden)
                    .pVer_Precio = True
                    .pVer_Comision = False
                    .pPrecio = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("precio").Value)

                    .pCodigo_Producto = vCodigo
                    .pNombre_Producto = Trim(dgvDetalle_venta.ActiveRow.Cells("producto").Value)
                    .pAfecto_IGV = CBool(dgvDetalle_venta.ActiveRow.Cells("afecto_igv").Value)
                    .pAfecto_Dzmo = CBool(dgvDetalle_venta.ActiveRow.Cells("afecto_dzmo").Value)
                    If dgvDetalle_venta.ActiveRow.Cells("xctajedscto").Value > 0 Then
                        .pDescuento = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("xctajedscto").Value)
                        .pXctajeDscto = True
                    Else
                        .pDescuento = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("dcto").Value)
                        .pXctajeDscto = False
                    End If


                    .pExonerado = CBool(dgvDetalle_venta.ActiveRow.Cells("exonerada").Value)
                    .pCodigo_Almacen = lblAlmacen.Tag
                    .pNuevo = False
                    .pCantidad_Adicional = 0
                    .pDevolucion = False
                    dgvListado.Visible = False
                    gpProductos.Visible = False
                    txtBuscar.Focus()
                    frmIV.ShowDialog()
                    'txtBuscar.Focus()
                    Call CalcularTotales()
                End With
            End If
        End If
    End Sub

    Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single, _
                                             ByVal vPrecio As Single, ByVal vDescuento As Single, ByVal vComision As Single, _
                                             ByVal vAfecto_IGV As Boolean, ByVal vAfecto_Dzmo As Boolean, ByVal xNuevo As Boolean, ByVal vTipoDscto As Integer, _
                                             ByVal vEsXctaje As Boolean, ByVal vExonerada As Boolean, ByVal vDscto As Single) As Boolean
        Try
            Dim NwRow As DataRow
            If xNuevo Then
                NwRow = GestionTablas.dtTemp.NewRow
                NwRow.Item("id") = vCodigo
                NwRow.Item("cantidad") = vCantidad
                NwRow.Item("producto") = vNombre_Producto
                NwRow.Item("afecto_igv") = vAfecto_IGV
                NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
                NwRow.Item("precio") = vPrecio

                NwRow.Item("subtotal") = ((vCantidad * vPrecio) - (vCantidad * vDscto))
                NwRow.Item("dcto") = vCantidad * vDscto

                NwRow.Item("item") = 0
                NwRow.Item("tipodscto") = vTipoDscto
                NwRow.Item("xctajedscto") = IIf(vEsXctaje, vDescuento, 0)
                NwRow.Item("exonerada") = vExonerada
                GestionTablas.dtTemp.Rows.Add(NwRow)
            Else
                NwRow = GestionTablas.dtTemp.Rows.Find(vCodigo)
                NwRow.Item("id") = vCodigo
                NwRow.Item("cantidad") = vCantidad
                NwRow.Item("producto") = vNombre_Producto
                NwRow.Item("afecto_igv") = vAfecto_IGV
                NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
                NwRow.Item("precio") = vPrecio

                NwRow.Item("subtotal") = ((vCantidad * vPrecio) - (vCantidad * vDscto))
                NwRow.Item("dcto") = vCantidad * vDscto

                NwRow.Item("item") = 0
                NwRow.Item("tipodscto") = vTipoDscto
                NwRow.Item("xctajedscto") = IIf(vEsXctaje, vDescuento, 0)
                NwRow.Item("exonerada") = vExonerada
                GestionTablas.dtTemp.AcceptChanges()
                GestionTablas.dtTemp.Select()
            End If
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO")
            Return False
        End Try

    End Function

  Public Function CalcularTotales() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow
    Dim vImporte_IGV As Single = 0, vImporte As Single = 0
    Dim vPorc_Dzmo As Single = 0, Total_Dzmo As Single = 0
    Dim vIGV As Single = 0, miIGV As Single = 0
    CalcularTotales = False
    miIGV = Configuracion.pIGV
    vPorc_Dzmo = Configuracion.pDZMO

    Try
      DtTot = GestionTablas.dtTemp

      For Each Drs In DtTot.Rows
        If Boolean.Parse(Drs("afecto_igv")) Then
          vImporte_IGV = vImporte_IGV + Single.Parse(Drs("subtotal").ToString)
        End If
        If CBool(Drs("afecto_dzmo")) Then
          Total_Dzmo = Total_Dzmo + (Single.Parse(Drs("subtotal").ToString) * vPorc_Dzmo / 100)
        End If

        vImporte = vImporte + Single.Parse(Drs("subtotal").ToString)

      Next Drs

      vIGV = FormatNumber((vImporte_IGV * miIGV / (100 + miIGV)), 2, TriState.False, TriState.False)

      lblIGV.Text = vIGV

      lblSubTotal.Text = FormatNumber(vImporte - vIGV, 2, TriState.False, TriState.False)
      Me.lblTotalDoc.Text = FormatNumber(vImporte + Total_Dzmo, 2, TriState.False, TriState.False)
      Me.lblTotalDoc2.Text = FormatNumber(vImporte + Total_Dzmo, 2, TriState.False, TriState.False)
      lblDZMO.Text = FormatNumber(Total_Dzmo, 2, TriState.False, TriState.False)
      'Me.lblTotalSaldo.Text = FormatNumber(vSaldo, 2, TriState.False, TriState.False)
      Me.lblEnLetras.Text = Numeros_Letras.EnLetras(vImporte + Total_Dzmo)
      CalcularTotales = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

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

        If Trim(txtSerie.Text) = "" Or vCodigo_Serie = 0 Then
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

        If txtRecibo_Dzmo.Text = "" Or vCodigo_SerieD = 0 Then
            valido = False
            ErrorProvider1.SetError(txtRecibo_Dzmo, "Falta Ingresar Nro RECIBO DIEZMO")
            camposConError.Add("DZMO")
        Else
            ErrorProvider1.SetError(txtRecibo_Dzmo, Nothing)
        End If

        If Not IsDate(txtFecha.Value) Then
            valido = False
            ErrorProvider1.SetError(txtFecha, "Falta Ingresar fecha")
            camposConError.Add("FECHA")
        Else
            ErrorProvider1.SetError(txtFecha, Nothing)
        End If

        If Not IsDate(txtvencimiento.Value) Then
            valido = False
            ErrorProvider1.SetError(txtvencimiento, "Falta Ingresar fecha Vencimiento")
            camposConError.Add("VENCE")
        Else
            ErrorProvider1.SetError(txtFecha, Nothing)
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

        If vOkR = False And (lblClientePor.Tag = 1 Or lblClientePor.Tag = 2) Then
            valido = False
            ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Colportor")
            camposConError.Add("RUC")
        Else
            ErrorProvider1.SetError(txtRucDni, Nothing)
        End If

        If lblC_Costo.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(lblC_Costo, "Falta Ingresar Centro Costo")
            camposConError.Add("CCOSTO")
        Else
            ErrorProvider1.SetError(lblC_Costo, Nothing)
        End If

        If (txtAsistente.Text = "") Then
            valido = False
            ErrorProvider1.SetError(txtAsistente, "Falta Ingresar Nombre Asistente")
            camposConError.Add("ASISTENTE")
        Else
            ErrorProvider1.SetError(txtAsistente, Nothing)
        End If

        If (txtNroCuenta.Text = "") Then
            valido = False
            ErrorProvider1.SetError(txtNroCuenta, "Falta Ingresar nro Cuenta")
            camposConError.Add("NROCUENTA")
        Else
            ErrorProvider1.SetError(txtNroCuenta, Nothing)
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

    Dim objV As New venta
    Dim dgvRw As UltraGridRow
    Dim FEmi, FVence As String, vArray As String = "", vArrFP As String = "", ok, xIdProv As Long
    Dim xMISC, xMIGV As Single, vTiene
    Dim xMiDZMP As Single
    Dim vNow As String = "", vComision As Single = 0, vLote As Long = 0
    Dim vSubTotal As Single = 0, vTotal As Single = 0, vPaga As Single = 0, vVuelto As Single = 0, vNroCuenta As String = ""
    Dim vDZMO As Single = 0
    FEmi = ""
    FVence = ""

    Try

      FEmi = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
      If txtvencimiento.Visible = True Then
        FVence = LibreriasFormularios.Formato_Fecha(txtvencimiento.Text)
      End If

      vNow = LibreriasFormularios.Formato_Fecha(Now.Date)

      xIdProv = 0
      xMISC = 0
      xMIGV = Configuracion.pIGV
      xMiDZMP = Configuracion.pDZMO
      vDZMO = Single.Parse(lblDZMO.Text)
      vTotal = (Single.Parse(lblTotalDoc.Text))
      vSubTotal = (Single.Parse(lblSubTotal.Text))
      With objV
        If pCodigo > 0 Then
          .ventaid = pCodigo
        Else
          .ventaid = -1
        End If

        .numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim) & ""
        .documentoid = vCodigo_Doc
        .almacenid = pCodigo_Alm
        .clienteid = pCodigo_Per
        .nombre_cli = "" 'TxtAnombreD.Text

        Select Case lblClientePor.Tag
          Case Is = 1
            .DNI = txtRucDni.Text
          Case Is = 2
            .RUC = txtRucDni.Text
          Case Is = 3
            .RUC = txtRucDni.Text
            .nombre_cli = TxtAnombreD.Text
        End Select


        .fecha = FEmi.Trim
        .moneda = cboMoneda.Value
        .condicion = "CREDITO"
        .vta_bruta = Single.Parse(vSubTotal) 'Single.Parse(lblSubTotal.Text)
        .descuento = 0
        .igv = Single.Parse(lblIGV.Text)
        .vta_total = Single.Parse(vTotal)

        If cboMoneda.Value = "NS" Then
          .cambio = "0.000"
        Else
          .cambio = Single.Parse(txtCambio.Text)
        End If

        .usuarioid = GestionSeguridadManager.idUsuario
        .caja = My.Computer.Name
        .estado = True
        .observacion = "" 'txtGlosaDP.Text.Trim & ""
        .cerrado = True
        .incluye_igv = True
        .descontar_stock = True
        .vendedorid = GestionSeguridadManager.idUsuario

        .signo = "+"
        .opcion = 0

        .valor_igv = xMIGV

        .centro_costos = lblC_Costo.Text
        .referencia = "BCC" 'Boleteo Credito Colportaje
        .codigo_ref1 = pCodigo_Asis

        vArray = ""
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvDetalle_venta.Rows
          If dgvRw.Band.Index = 0 Then
            vTiene = True

            vArray = vArray & "['" & Str(dgvRw.Cells("id").Value).Trim & "', '" &
                                     Str(dgvRw.Cells("cantidad").Value).Trim & "','" &
                                     Str(dgvRw.Cells("precio").Value).Trim & "','" &
                                     Str(dgvRw.Cells("tipodscto").Value).Trim & "','" &
                                     Str(dgvRw.Cells("xctajedscto").Value).Trim & "','" &
                                     Str(dgvRw.Cells("dcto").Value).Trim & "','" &
                                     Str(vComision).Trim & "','" &
                                     IIf(CBool(dgvRw.Cells("afecto_igv").Value), "1", "0") & "','" &
                                     IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), "1", "0") & "','" &
                                     IIf(CBool(dgvRw.Cells("exonerada").Value), "1", "0") & "'],"

          End If
        Next
        If Not vArray = "" Then
          vArray = Mid(vArray, 1, Len(vArray) - 1)
          vArray = "array[" & vArray & "]"
        Else
          vArray = "null"
        End If
        vArrFP = "null"
        .Vencimiento = FVence

      End With
      vNroCuenta = txtNroCuenta.Text.Trim
      Dim myArr_CxC As String = "null"
      ok = ventaManager.Agregar(ok, objV, vArray, vArrFP, vPaga, vVuelto, vNroCuenta, vCodigo_Serie, vCodigo_SerieD,
                                vCodigo_DocD, txtRecibo_Dzmo.Text.Trim, vDZMO, myArr_CxC)

      If Not ok > 0 Then
        GrabarRegistroDoc = False
        Exit Function
      Else
        Dim vDtCabecera As New DataTable, vDtDetalle As New DataTable, vDtDzmo As New DataTable
        If ventaManager.Datos_Impresion(Long.Parse(ok), vDtCabecera, vDtDetalle) Then
          If Impresion_WSpool.Print_Ticket(vCodigo_Doc, pCodigo_Alm, pAlmacen, GestionSeguridadManager.NombrePC, vDtCabecera, vDtDetalle) Then
            'Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, vCodigo_Doc)
          End If
        End If
        vDtDzmo = reportes_consignacionManager.Detalle_Documento(ok)
        If Impresion_WSpool.Print_Recibo_Dzmo(vCodigo_DocD, pCodigo_Alm, pAlmacen, GestionSeguridadManager.NombrePC, vDtDzmo) Then
          'Call ClsImpresiones.Imprimir_Rpt_DZMO(Long.Parse(ok), pCodigo_Alm, vCodigo_DocD, vFormatoD, vSerieTkD, vCopiasD, vImpresoraD)
        End If
      End If

      GrabarRegistroDoc = True
      objV = Nothing
    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub tsGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If GrabarRegistroDoc() Then
                    Call Nueva_Venta()
                    txtBuscar.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub UltraLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel4.Click
        If Not bwDatos.IsBusy Then
            bwDatos.RunWorkerAsync()
        End If
    End Sub

    Private Sub txtBuscar_ValueChanged(sender As Object, e As EventArgs) Handles txtBuscar.ValueChanged

    End Sub

    Private Sub txtRucDni_ValueChanged(sender As Object, e As EventArgs) Handles txtRucDni.ValueChanged

    End Sub
End Class