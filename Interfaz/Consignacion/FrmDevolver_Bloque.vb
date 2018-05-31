
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmDevolver_Bloque
  Public pCodigo As Long, pCodigo_Per As Long, pCodigo_Asis As Long, pCodigo_Alm As Integer, pNombre_Almacen As String, pTipo As Integer
  Public pCampaniaid As Integer, pCampania As String
  Public dtDocumento As DataTable, dtForma_Pago As DataTable
  Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtForma_Pago = New DataTable
    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = "DEVOLVER" 'My.Computer.Name
    Try
      dtDocumento = permisos_impresionManager.Obtener_Documentos_Modulo(pCodigo_Alm, vCodigo_Usu,
                                                                          vCaja, GestionModulos.modColportaje)

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
      .ValueMember = "codigo"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If pCodigo > 0 Then
        .Value = pCodigo
      Else
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    picAjax.Visible = False
    'BtnGrabar.Visible = True


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
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCampaniaid, pCodigo_Asis, pTipo, 50, txtBuscar.Text.Trim, 0, "")
      ElseIf lblBuscarpor.Tag = 2 Then 'codigo
        If IsNumeric(txtBuscar.Text) Then
          vProdId = Long.Parse(txtBuscar.Text)
        End If
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCampaniaid, pCodigo_Asis, pTipo, 50, "", vProdId, "")
      ElseIf lblBuscarpor.Tag = 3 Then 'barras
        dtProducto = productoManager.Consultar_Registros_Asistente(Now.Year, pCodigo_Alm, pCampaniaid, pCodigo_Asis, pTipo, 50, "", 0, txtBuscar.Text.Trim)
      End If

      dgvListado.DataSource = dtProducto
      gpProductos.Visible = True

      If Not dtProducto Is Nothing Then
        If dtProducto.Rows.Count > 0 Then
          dgvListado.Focus()
        Else
          txtBuscar.Focus()
        End If
      End If


    End If

  End Sub

  Private Sub FrmVender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F9 Then

      MessageBox.Show("Procesado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
    ElseIf e.KeyCode = Keys.Escape Then
      If MessageBox.Show("¿Está seguro de cerrar la ventana?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
      End If
    End If
  End Sub

  Private Sub Habilitar_RUC_DNI(ByVal vTipo As Integer)

    Select Case vTipo
      Case 1
        lblClientePor.Text = "DNI:"
        txtRucDni.MaxLength = 8
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        txtAnombreD.Visible = True
      Case 2
        lblClientePor.Text = "RUC:"
        txtRucDni.MaxLength = 11
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        txtAnombreD.Visible = False
      Case 3
        lblClientePor.Text = "OTRO:"
        txtRucDni.MaxLength = 11
        txtRucDni.Text = "00000000000"
        txtRucDni.ReadOnly = True
        txtAnombreD.Visible = False
    End Select

  End Sub

  Private Sub FrmVender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Call LibreriasFormularios.formatear_grid(dgvListado)

    lblBuscarpor.Tag = 1

    'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small
    txtFecha.Value = Now.Date
    picAjax.Visible = True
    lblAlmacen.Text = pNombre_Almacen
    lblcampania.Text = pCampania
    GestionTablas.dtTemp = ClsGridDetallePagos.Crear_Grid_Venta("consignacion")
    dgvDetalle_venta.DataSource = GestionTablas.dtTemp
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
    Dim Objp As New persona

    Objp = personaManager.Datos_Persona_Basic("N", "", pCodigo_Per)
    If Not Objp Is Nothing Then
      txtRucDni.Text = Objp.dni
      txtAnombreD.Text = Objp.ape_pat & " " & Objp.ape_mat & " " & Objp.nombre
    End If
    Objp = Nothing
  End Sub

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    If pCodigo_Per = 0 Or pCodigo_Alm = 0 Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Seleccinar y/o ingresar Asistente y/o Almacen")
      camposConError.Add("Codigo Per / Codigo Alm")
    Else
      ErrorProvider1.SetError(txtRucDni, Nothing)
    End If

    If Trim(txtRucDni.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Ingresar Nro Documento")
      camposConError.Add("txtDNI")
    Else
      ErrorProvider1.SetError(txtRucDni, Nothing)
    End If

    If txtAnombreD.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(txtAnombreD, "Debe Seleccionar Asistente")
      camposConError.Add("Asistente")
    Else
      ErrorProvider1.SetError(txtAnombreD, Nothing)
    End If


    'If lblNombreCta.Text.Trim = "" Then
    '    valido = False
    '    ErrorProvider1.SetError(lblNombreCta, "Debe Seleccionar una cuenta")
    '    camposConError.Add("Nombre Cuenta")
    'Else
    '    ErrorProvider1.SetError(lblNombreCta, Nothing)
    'End If

    If Not valido Then
      Lblerror.Text = "Introduzca y/o Seleccione un valor en  "

      For Each campo In camposConError
        Lblerror.Text &= campo & ", "
      Next
      Lblerror.Text = Lblerror.Text.Substring(0, Lblerror.Text.Length - 2)
    End If
    Return valido
  End Function

  Private Sub tsGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
    If MessageBox.Show("¿Desea grabar los datos?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
      Try
        If ValidarDatos() Then

          Call Actualizar()

        End If


      Catch ex As Exception
        MsgBox(ex.Message)
      End Try
    End If
  End Sub

  Public Function Actualizar() As Boolean
    Dim Objeto As New consignacion
    Dim vNumero As String = "", vFecha As String
    Dim dgvRw As UltraGridRow, xCodigo_Det As Integer = 0
    Try
      vNumero = txtSerie.Text & "-" & txtNumero.Text
      vFecha = LibreriasFormularios.Formato_Fecha(txtFecha.Value)

      With Objeto
        .Codigo_Documento = Val(cboDocumento.Value)
        .Numero = Trim(vNumero)
        .Codigo_Almacen = pCodigo_Alm
        .Codigo_Campania = 0
        .Codigo_Asistente = pCodigo_Asis
        .fecha = vFecha
        .Total = Single.Parse(lblTotalDoc2.Text)
        .porcentaje_dzmo = Configuracion.pDZMO   'Val(cmdDzmo.Tag)
        .Codigo_Usuario = GestionSeguridadManager.idUsuario
        .caja = My.Computer.Name
        .Estado = True
        .Tipo = pTipo
        .Signo_Positivo = False
        .Importe_Dzmo = Single.Parse(lblDZMO.Text)

      End With

      'Lo metemos en el array
      Dim vArray As String, vTiene As Boolean, VAfDzmo As Integer, vValor_Dzmo As Single = 0
      vArray = ""
      For Each dgvRw In Me.dgvDetalle_venta.Rows
        If dgvRw.Band.Index = 0 Then
          vTiene = True
          VAfDzmo = IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), 1, 0)
          vValor_Dzmo = IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), Configuracion.pDZMO, 0)

          vArray = vArray & "['" & Trim(Str(xCodigo_Det)) & "','" &
                                             Str(dgvRw.Cells("id").Value).Trim & "', '" &
                                             Str(dgvRw.Cells("cantidad").Value).Trim & "','" &
                                             Str(dgvRw.Cells("precio").Value).Trim & "','" &
                                             Str(VAfDzmo) & "','" &
                                             Str(vValor_Dzmo) & "','" &
                                             Str("0") & "','" &
                                             Str("0") & "'],"
        End If
      Next
      If vTiene Then
        vArray = Mid(vArray, 1, Len(vArray) - 1)
        vArray = "array[" & vArray & "]"
      Else
        vArray = "null"
      End If

      If consignacionManager.Agregar(pCodigo, Objeto, vArray) > 0 Then
        Me.Close()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
    If Not cboDocumento.DataSource Is Nothing Then
      txtSerie.Text = cboDocumento.ActiveRow.Cells("serie").Value
      txtNumero.Text = Format((cboDocumento.ActiveRow.Cells("correlativo").Value), "00000000")
      vFormato = cboDocumento.ActiveRow.Cells("formato").Value
      vImpresora = cboDocumento.ActiveRow.Cells("impresora").Value
      vSerieTk = cboDocumento.ActiveRow.Cells("serie_tk").Value
      vImprimir = CBool(cboDocumento.ActiveRow.Cells("imprimir").Value)
      vCopias = cboDocumento.ActiveRow.Cells("copias").Value
    End If
  End Sub

  Private Sub txtBuscar_ValueChanged(sender As Object, e As EventArgs) Handles txtBuscar.ValueChanged

  End Sub

  Private Sub cboDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
    With cboDocumento.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(2).Hidden = True
      .Columns("documento").Width = cboDocumento.Width
      .Columns(2).Hidden = True
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
      .Columns(8).Hidden = True
      .Columns("codigo_serie").Hidden = True
    End With
  End Sub

  Private Sub txtNumero_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Validated
    Dim xNum As Long = 0
    If IsNumeric(txtNumero.Text) Then
      xNum = txtNumero.Text
      txtNumero.Text = Format(xNum, "00000000") '& txtNumero.Text
    End If
  End Sub

  Private Sub dgvListado_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvListado.DoubleClickRow
    'Call dgvListado_KeyDown(e.Row.ro , 0)
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
          .gQue_Form_Llama = "DEVOLUCION_BLK"
          .vStock = Str(dgvListado.ActiveRow.Cells(7).Value)
          .pVer_Descuento = False '(dgvListado.ActiveRow.Cells(6).Visible)
          .pVer_Precio = True
          .pVer_Comision = False



          .pCodigo_Producto = vCodigo
          .pNombre_Producto = Trim(dgvListado.ActiveRow.Cells(1).Value)
          .pAfecto_IGV = CBool(dgvListado.ActiveRow.Cells(6).Value)
          If pTipo = 0 Then
            .pPrecio = Val(dgvListado.ActiveRow.Cells(4).Value)
            .pAfecto_Dzmo = CBool(dgvListado.ActiveRow.Cells(10).Value)
          Else
            .pPrecio = Val(dgvListado.ActiveRow.Cells(3).Value)
            .pAfecto_Dzmo = False
          End If

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

  Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns(0).Width = 30
      .Columns(0).Header.Caption = "ID"
      .Columns(1).Width = 300
      .Columns(1).Header.Caption = "PRODUCTO"
      .Columns(2).Width = 100
      .Columns(2).Header.Caption = "FAMILIA"
      .Columns(3).Hidden = True
      .Columns(4).Hidden = True
      If pTipo = 0 Then
        .Columns(4).Width = 80
        .Columns(4).CellAppearance.TextHAlign = HAlign.Right
        .Columns(4).Header.Caption = "PRECIO"
        .Columns(4).Hidden = False
      Else
        .Columns(3).Width = 80
        .Columns(3).CellAppearance.TextHAlign = HAlign.Right
        .Columns(3).Header.Caption = "PRECIO"
        .Columns(3).Hidden = False
      End If
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

  Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single,
                                          ByVal vPrecio As Single, ByVal vDescuento As Single, ByVal vComision As Single,
                                          ByVal vAfecto_IGV As Boolean, ByVal vAfecto_Dzmo As Boolean) As Boolean
    Try
      Dim NwRow As DataRow

      NwRow = GestionTablas.dtTemp.NewRow
      NwRow.Item("id") = vCodigo
      NwRow.Item("cantidad") = vCantidad
      NwRow.Item("producto") = vNombre_Producto
      NwRow.Item("afecto_igv") = vAfecto_IGV
      NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
      NwRow.Item("precio") = vPrecio
      NwRow.Item("subtotal") = vCantidad * vPrecio - vDescuento
      NwRow.Item("dcto") = vDescuento
      NwRow.Item("item") = 0
      GestionTablas.dtTemp.Rows.Add(NwRow)

      Return True

    Catch ex As Exception
      Return False
    End Try

  End Function

  Public Function CalcularTotales() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow, vPorc_Dzmo As Single = 0
    Dim vImporte As Single = 0, vSubTotal As Single = 0, Total_Dzmo As Single = 0

    CalcularTotales = False
    vPorc_Dzmo = Configuracion.pDZMO
    Try
      DtTot = GestionTablas.dtTemp

      For Each Drs In DtTot.Rows
        vSubTotal = (CSng(Drs("cantidad").ToString) * CSng(Drs("precio").ToString) - CSng(Drs("dcto").ToString))
        If CBool(Drs("afecto_dzmo")) Then
          Total_Dzmo = Total_Dzmo + (vSubTotal * vPorc_Dzmo / 100)
        End If

        vImporte = vImporte + CSng(Drs("subtotal").ToString)

      Next Drs
      lblSubTotal.Text = FormatNumber((vImporte), 2, TriState.False, TriState.False)
      lblDZMO.Text = FormatNumber(Total_Dzmo, 2, TriState.False, TriState.False)
      Me.lblTotalDoc.Text = FormatNumber((vImporte + Total_Dzmo), 2, TriState.False, TriState.False)
      Me.lblTotalDoc2.Text = FormatNumber((vImporte + Total_Dzmo), 2, TriState.False, TriState.False)

      Me.lblEnLetras.Text = Numeros_Letras.EnLetras((vImporte + Total_Dzmo))
      CalcularTotales = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
    Call CalcularTotales()
  End Sub

  Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
    With dgvDetalle_venta.DisplayLayout.Bands(0)
      .Columns("id").Width = 20
      .Columns("cantidad").Width = 60
      .Columns("cantidad").Header.Caption = "Cant"
      .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
      .Columns("producto").Width = 350
      .Columns("afecto_dzmo").Header.Caption = "DZMO"
      .Columns("afecto_dzmo").Width = 40
      .Columns("afecto_dzmo").CellAppearance.TextHAlign = HAlign.Center
      .Columns("afecto_igv").Hidden = True
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

  Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
    If e.KeyCode = Keys.Enter Then
      Dim ObjPe As New persona
      Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

      ObjPe = personaManager.Datos_Persona_Basic(pCodigo_Alm, "N", txtRucDni.Text.Trim)

      If Not ObjPe Is Nothing Then
        pCodigo_Per = Long.Parse(ObjPe.personaid)
        vApe_Pat = ObjPe.ape_pat
        vApe_Mat = ObjPe.ape_mat
        vNombre = ObjPe.nombre
        txtAnombreD.Text = vApe_Pat & " " & vApe_Mat & " " & vNombre
        lblNombreCta.Text = ObjPe.nrocuenta & ""
        txtBuscar.Focus()
        Call CalcularTotales()
      Else
        txtAnombreD.Text = ""
        txtRucDni.Focus()
      End If
    End If
  End Sub

End Class