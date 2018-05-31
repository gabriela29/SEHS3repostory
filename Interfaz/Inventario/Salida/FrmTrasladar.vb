
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmTrasladar
  Public pCodigo As Long, pCodigo_Per As Long, pCodigo_Almacen As Integer, pAlmacen As String
  Public pTipoPer As String = "", pDireccion As String = "", pApe_Pat As String = "", pApe_Mat As String = "", pPersona As String = ""
  Public dtDocumento As DataTable, dtAlm_Destino As DataTable
  Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0
  Public vOkR As Boolean, zReniec As Boolean
  Public pTipo_Mov As Integer

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtAlm_Destino = New DataTable
    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = My.Computer.Name
    Try
      Call cursoresManager.Datos_Ventana_Salida(pCodigo_Almacen, vCodigo_Usu,
                                                  vCaja, dtDocumento, dtAlm_Destino)

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
      .ValueMember = "documentoid"
      .DisplayMember = "documento"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4

      If pCodigo > 0 Then
        .Value = pCodigo
      Else
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    With cboAlmacen
      .DataSource = dtAlm_Destino 'almacenManager.GetList(0, 0)
      .ValueMember = "almacenid"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        If pCodigo = 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
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

    opciones(0) = "CONTADO"
    opciones(1) = "CREDITO"

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
        dtProducto = productoManager.Consultar_Registros_Salida(Now.Year, pCodigo_Almacen, 10, txtBuscar.Text.Trim, "", 0, "")
      ElseIf lblBuscarpor.Tag = 2 Then 'codigo
        If IsNumeric(txtBuscar.Text) Then
          vProdId = Long.Parse(txtBuscar.Text)
        End If
        dtProducto = productoManager.Consultar_Registros_Salida(Now.Year, pCodigo_Almacen, 10, "", "", vProdId, "")
      ElseIf lblBuscarpor.Tag = 3 Then 'barras
        dtProducto = productoManager.Consultar_Registros_Salida(Now.Year, pCodigo_Almacen, 10, "", "", 0, txtBuscar.Text.Trim)
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

  Private Sub Habilitar_RUC_DNI(ByVal vTipo As Integer)

    Select Case vTipo
      Case 1
        lblClientePor.Text = "DNI:"
        txtRucDni.MaxLength = 10
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        TxtAnombreD.ReadOnly = True
        txtApe_Pat.Visible = True
        txtApe_Mat.Visible = True
        txtNombre.Visible = True
        TxtAnombreD.Visible = False
      Case 2
        lblClientePor.Text = "RUC:"
        txtRucDni.MaxLength = 15
        txtRucDni.Text = ""
        txtRucDni.ReadOnly = False
        TxtAnombreD.ReadOnly = True
        txtApe_Pat.Visible = False
        txtApe_Mat.Visible = False
        txtNombre.Visible = False
        TxtAnombreD.Visible = True
    End Select

  End Sub

  Private Sub Consultar_Reniec()

    If IsNumeric(txtRucDni.Text) Then
      If txtRucDni.Text.Trim.Length = 8 Then
        Dim ObjPe As New persona
        ObjPe = personaManager.Datos_Persona_Basic("N", txtRucDni.Text.Trim, 0)
        If Not ObjPe Is Nothing Then
          pCodigo_Per = Long.Parse(ObjPe.personaid)
          Me.txtApe_Pat.Text = ObjPe.ape_pat
          Me.txtApe_Mat.Text = ObjPe.ape_mat
          Me.txtNombre.Text = ObjPe.nombre
          pTipoPer = "N"
          vOkR = True
        Else
          Dim testDialog As New FrmReniec()
          testDialog.pNumero = txtRucDni.Text.Trim
          If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Me.txtApe_Pat.Text = CStr(testDialog.txtApe_Pat.Text)
            Me.txtApe_Mat.Text = CStr(testDialog.txtApe_Mat.Text)
            Me.txtNombre.Text = CStr(testDialog.txtNombre.Text)
            pTipoPer = "N"
            txtBuscar.Focus()
          Else
            Me.txtApe_Pat.Text = ""
            Me.txtApe_Mat.Text = ""
            Me.txtNombre.Text = ""
            txtRucDni.Focus()
          End If
          vOkR = testDialog.vOkR
          testDialog.Dispose()
        End If
      Else
        MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
        txtRucDni.Focus()
      End If
    Else
      MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
      txtRucDni.Focus()
    End If



  End Sub

  Private Sub txtRucDni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRucDni.KeyDown
    If e.KeyCode = Keys.Enter Then
      If lblClientePor.Tag = 1 Then
        Call Consultar_Reniec()
      ElseIf lblClientePor.Tag = 2 Then
        Call Consulta_DNI_SUNAT()
      End If
    Else
      If e.KeyCode <> Keys.Down And e.KeyCode <> Keys.Up Then Exit Sub
      If e.KeyCode <> Keys.Down Then lblClientePor.Tag = Val(lblClientePor.Tag) + 1
      If e.KeyCode <> Keys.Up Then lblClientePor.Tag = Val(lblClientePor.Tag) - 1
      If Val(lblClientePor.Tag) = 0 Then lblClientePor.Tag = 3
      If Val(lblClientePor.Tag) = 4 Then lblClientePor.Tag = 1
      Select Case lblClientePor.Tag
        Case Is = 1
          Call Habilitar_RUC_DNI(1)
        Case Is = 2
          Call Habilitar_RUC_DNI(2)
        Case Is = 3
          Call Habilitar_RUC_DNI(3)
      End Select
    End If
    If vOkR Then
      txtBuscar.Focus()
    End If
  End Sub

  Private Sub Consulta_DNI_SUNAT()
    Dim vProv As String = ""
    TxtAnombreD.Text = ""

    If Not Trim(txtRucDni.Text) = "" Then
      If txtRucDni.TextLength >= 11 Then
        If Not IsNumeric(txtRucDni.Text) Then Exit Sub
        If Funciones.Verificar_ruc(txtRucDni.Text) Then
          Dim ObjPe As New persona
          ObjPe = personaManager.Datos_Persona_Basic("J", txtRucDni.Text.Trim, 0)
          If Not ObjPe Is Nothing Then
            pCodigo_Per = Long.Parse(ObjPe.personaid)
            Me.TxtAnombreD.Text = ObjPe.raz_soc
            pTipoPer = "J"
            vOkR = True
          Else
            Dim ObjDR As New persona
            ObjDR = LibreriasFormularios.Datos_Persona("RUC", txtRucDni.Text)
            If Not ObjDR Is Nothing Then
              If ObjDR.raz_soc = "" Then
                'vDireccion = ""
                txtRucDni.Focus()
                vOkR = False
              Else
                TxtAnombreD.Text = ObjDR.raz_soc
                pPersona = ObjDR.raz_soc
                pDireccion = ObjDR.direccion
                pTipoPer = ObjDR.tipo

                vOkR = True
              End If
            End If
            ObjDR = Nothing
          End If
        Else
          MessageBox.Show("Número de RUC no válido", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          txtRucDni.Focus()
        End If
      Else
        MsgBox("Debe tener 11 dígitos el RUC", MsgBoxStyle.Exclamation, "AVISO")
        txtRucDni.Focus()
      End If

    End If
  End Sub

  Private Sub cboCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCondicion.InitializeLayout
    cboCondicion.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboCondicion.DisplayLayout.Bands(0).Columns(1).Width = cboCondicion.Width
  End Sub

  Private Sub FrmVender_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    FrmSalida_traslado.Actualizar()
  End Sub

  Private Sub FrmVender_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.F9 Then
      If ValidarDatos() Then
        If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
          If GrabarRegistroDoc() Then
            Call Nueva_Venta()
            txtBuscar.Focus()
          End If
        End If
      End If
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

  Private Sub FrmVender_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Call Nueva_Venta()
  End Sub

  Private Sub Nueva_Venta()
    Call Llenar_Combos()
    Call LibreriasFormularios.formatear_grid(dgvListado)
    lblClientePor.Tag = 1
    lblBuscarpor.Tag = 1
    lblBuscarpor.Text = "Nombre:"
    Call Habilitar_RUC_DNI(1)
    'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small
    txtFecha.Value = Now.Date

    picAjax.Visible = True

    lblAlmacen.Tag = pCodigo_Almacen
    lblAlmacen.Text = pAlmacen

    If pTipo_Mov = Tipo_Mov_Mercaderia.tAJUSTE Then
      lblDestino.Visible = False
      cboAlmacen.Visible = False
    Else
      lblDestino.Visible = True
      cboAlmacen.Visible = True
    End If

    GestionTablas.dtTemp = ClsGridDetallePagos.Crear_Grid_Venta("venta")
    dgvDetalle_venta.DataSource = GestionTablas.dtTemp
    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If
    Call CalcularTotales()
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

    If Trim(txtSerie.Text) = "" Or vCodigo_Serie = 0 Then
      valido = False
      ErrorProvider1.SetError(txtSerie, "Falta Ingresar Serie")
      camposConError.Add("SERIE")
    Else
      ErrorProvider1.SetError(txtSerie, Nothing)
    End If

    If pTipo_Mov = Tipo_Mov_Mercaderia.tTraslado Then
      If pCodigo_Almacen = cboAlmacen.Value Then
        valido = False
        ErrorProvider1.SetError(cboAlmacen, "El Almacén Destino no debe ser igual al Origen")
        camposConError.Add("ALMACEN DESTINO")
      Else
        ErrorProvider1.SetError(cboAlmacen, Nothing)
      End If

      If cboAlmacen.Value = 0 Then
        valido = False
        ErrorProvider1.SetError(cboAlmacen, "Debe seleccionar un almacen destino")
        camposConError.Add("ALMACEN DESTINO")
      Else
        ErrorProvider1.SetError(cboAlmacen, Nothing)
      End If
    End If

    If Trim(txtNumero.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtNumero, "Falta Ingresar Nro Documento")
      camposConError.Add("NUMERO")
    Else
      ErrorProvider1.SetError(txtNumero, Nothing)
    End If

    If Not IsDate(txtFecha.Value) Then
      valido = False
      ErrorProvider1.SetError(txtFecha, "Falta Ingresar fecha")
      camposConError.Add("FECHA")
    Else
      ErrorProvider1.SetError(txtFecha, Nothing)
    End If
    If cboDocumento.Value = 1 Then
      If Not lblClientePor.Tag = 2 Or Not txtRucDni.TextLength >= 11 Or vOkR = False Then
        valido = False
        ErrorProvider1.SetError(txtRucDni, "En una factura debe ingresar RUC")
        camposConError.Add("RUC")
      Else
        ErrorProvider1.SetError(txtRucDni, Nothing)
      End If
    End If
    If cboCondicion.Text = "CREDITO" And Not IsDate(txtvencimiento.Value) Then
      valido = False
      ErrorProvider1.SetError(txtvencimiento, "Falta Ingresar fecha Vencimiento")
      camposConError.Add("VENCIMIENTO")
    Else
      ErrorProvider1.SetError(txtvencimiento, Nothing)
    End If

    If cboCondicion.Text = "CREDITO" Then
      If txtFecha.Value > txtvencimiento.Value Then

        valido = False
        ErrorProvider1.SetError(txtvencimiento, "El Vencimiento no debe menor a la fecha de emisión")
        camposConError.Add("VENCIMIENTO")
      Else
        ErrorProvider1.SetError(txtvencimiento, Nothing)
      End If
    End If
    If Not vOkR And cboCondicion.Text = "CREDITO" Then
      valido = False
      ErrorProvider1.SetError(txtRucDni, "Falta Ingresar RUC y/o Nombre Cliente por ser una venta al CRÉDITO")
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
    If vOkR = False And (lblClientePor.Tag = 1 Or lblClientePor.Tag = 2) Then
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

    Dim objV As New salida_mercaderia
    Dim dgvRw As UltraGridRow
    Dim FEmi, FVence As String, vArray As String = "", vArrFP As String = "", ok, xIdProv As Long
    Dim xMISC, xMIGV As Single, vTiene As Boolean
    Dim vNow As String = "", vComision As Single = 0, vLote As Long = 0
    Dim vPaga As Single = 0, vVuelto As Single = 0, vAlm_Des As Integer = 0
    FEmi = ""
    FVence = ""

    Try

      FEmi = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
      If txtvencimiento.Visible = True Then
        FVence = LibreriasFormularios.Formato_Fecha(txtvencimiento.Text)
      End If
      If pTipo_Mov = Tipo_Mov_Mercaderia.tTraslado Then
        vAlm_Des = cboAlmacen.Value
      Else
        vAlm_Des = 0
      End If

      vNow = LibreriasFormularios.Formato_Fecha(Now.Date)

      xIdProv = 0
      xMISC = 0
      xMIGV = Configuracion.pIGV

      With objV

        If pCodigo > 0 Then
          .Codigo = pCodigo
        Else
          .Codigo = -1
        End If
        .Codigo_tipo = pTipo_Mov
        .Numero = (txtSerie.Text.Trim & "-" & txtNumero.Text.Trim) & ""
        .Codigo_Documento = cboDocumento.Value
        .Codigo_Almacen = pCodigo_Almacen
        .Referencia = ""
        .Codigo_Ref1 = 0
        .Codigo_Ref2 = vAlm_Des 'cboAlmacen.Value
        .codigo_persona = pCodigo_Per

        .fecha = FEmi.Trim
        .Moneda = cboMoneda.Value
        .condicion = cboCondicion.Text.Trim
        .vta_Bruta = Single.Parse(lblSubTotal.Text)
        .Descuento = 0
        .IGV = Single.Parse(lblIGV.Text)
        .Vta_Total = Single.Parse(lblTotalDoc2.Text)
        If cboMoneda.Value = "NS" Then
          .Cambio = "0.000"
        Else
          .Cambio = Single.Parse(txtCambio.Text)
        End If

        .Usuarioid = GestionSeguridadManager.idUsuario
        .caja = My.Computer.Name
        .Estado = True
        .Observacion = ""
        .Cerrado = True
        .Incluye_IGV = True
        .Descontar_Stock = True

        .Valor_igv = xMIGV

        vArray = ""
        Dim vCero As Integer = 0
        'Almacenamos el centro de costo
        For Each dgvRw In Me.dgvDetalle_venta.Rows
          If dgvRw.Band.Index = 0 Then
            vTiene = True
            vArray = vArray & "['" & Str(dgvRw.Cells("id").Value).Trim & "', '" &
                                     Str(dgvRw.Cells("cantidad").Value).Trim & "','" &
                                     Str(dgvRw.Cells("precio").Value).Trim & "','" &
                                     Str((vCero)) & "','" &
                                     Str((vCero)) & "','" &
                                     Str((vCero)) & "','" &
                                     Trim(FEmi.Trim) & "'],"

          End If
        Next
        If vTiene Then
          vArray = Mid(vArray, 1, Len(vArray) - 1)
          vArray = "array[" & vArray & "]"
        Else
          vArray = "null"
        End If
        vArrFP = "null"

      End With

      ok = salida_mercaderiaManager.Agregar(0, objV, vArray, vCodigo_Serie)

      If Not ok > 0 Then
        GrabarRegistroDoc = False
        Exit Function
      Else
        GrabarRegistroDoc = True
        '    Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Almacen, cboDocumento.Value)
      End If

      Return GrabarRegistroDoc
      objV = Nothing
    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub tsGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsGrabar.Click
    If ValidarDatos() Then
      If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        If GrabarRegistroDoc() Then
          Me.Close()
          MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
      End If
    End If
  End Sub

  Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
    If Not cboDocumento.DataSource Is Nothing Then
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


        Dim frmIV As New FrmActualizar_Item_Salida
        With frmIV
          .gQue_Form_Llama = "TRANSFERENCIA"
          .vStock = Str(dgvListado.ActiveRow.Cells(7).Value)
          .pVer_Descuento = False '(dgvListado.ActiveRow.Cells(6).Visible)
          .pVer_Precio = True
          .pVer_Comision = False
          .pPrecio = Val(dgvListado.ActiveRow.Cells(3).Value)
          .pCodigo_Producto = vCodigo
          .pNombre_Producto = Trim(dgvListado.ActiveRow.Cells(1).Value)
          .pAfecto_IGV = CBool(dgvListado.ActiveRow.Cells(6).Value)
          .pAfecto_Dzmo = CBool(dgvListado.ActiveRow.Cells(10).Value)
          .pCodigo_Almacen = lblAlmacen.Tag
          .pNuevo = True
          .pCantidad_Adicional = 0
          .pDevolucion = False
          gpProductos.Visible = False
          txtBuscar.Focus()
          frmIV.ShowDialog()
          'txtBuscar.Focus()
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

  Private Sub Editar_Registro()
    If dgvDetalle_venta.Rows.Count > 0 Then
      If dgvDetalle_venta.Selected.Rows.Count > 0 Then
        Dim vCodigo As Long, vStock As Long
        vCodigo = (dgvDetalle_venta.ActiveRow.Cells(0).Value)
        vStock = inventariosManager.Mi_Stock(vCodigo, pCodigo_Almacen, 0)
        Dim frmIV As New FrmActualizar_Item_Salida
        With frmIV
          .gQue_Form_Llama = "TRANSFERENCIA"
          .vStock = vStock
          .pCantidad = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("cantidad").Value)
          .pVer_Descuento = False '(dgvListado.ActiveRow.Cells(6).Visible)
          .pVer_Precio = True
          .pVer_Comision = False
          .pPrecio = Single.Parse(dgvDetalle_venta.ActiveRow.Cells("precio").Value)
          .pCodigo_Producto = vCodigo
          .pNombre_Producto = Trim(dgvDetalle_venta.ActiveRow.Cells("producto").Value)
          .pAfecto_IGV = CBool(dgvDetalle_venta.ActiveRow.Cells("afecto_igv").Value)
          .pAfecto_Dzmo = CBool(dgvDetalle_venta.ActiveRow.Cells("afecto_dzmo").Value)
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

  Public Function Agregar_Producto(ByVal vCodigo As Long, ByVal vNombre_Producto As String, ByVal vCantidad As Single,
                                          ByVal vPrecio As Single, ByVal vDescuento As Single, ByVal vComision As Single,
                                          ByVal vAfecto_IGV As Boolean, ByVal vAfecto_Dzmo As Boolean, xNuevo As Boolean) As Boolean
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
        NwRow.Item("subtotal") = vCantidad * vPrecio - vDescuento
        NwRow.Item("dcto") = vDescuento
        NwRow.Item("item") = 0
        GestionTablas.dtTemp.Rows.Add(NwRow)
      Else
        'NwRow = GestionTablas.dtTemp.NewRow
        NwRow = GestionTablas.dtTemp.Rows.Find(vCodigo)
        NwRow.Item("id") = vCodigo
        NwRow.Item("cantidad") = vCantidad
        NwRow.Item("producto") = vNombre_Producto
        NwRow.Item("afecto_igv") = vAfecto_IGV
        NwRow.Item("afecto_dzmo") = vAfecto_Dzmo
        NwRow.Item("precio") = vPrecio
        NwRow.Item("subtotal") = vCantidad * vPrecio - vDescuento
        NwRow.Item("dcto") = vDescuento
        NwRow.Item("item") = 0
        'GestionTablas.dtTemp.Rows.Add(NwRow)
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

  Private Sub dgvDetalle_venta_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle_venta.AfterRowsDeleted
    Call CalcularTotales()
  End Sub

  Private Sub dgvDetalle_venta_DoubleClick(sender As Object, e As EventArgs) Handles dgvDetalle_venta.DoubleClick
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


  Private Sub cboMoneda_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboMoneda.InitializeLayout
    cboMoneda.DisplayLayout.Bands(0).Columns(0).Hidden = True
    cboMoneda.DisplayLayout.Bands(0).Columns(0).Width = cboMoneda.Width
  End Sub

  Private Sub cboCondicion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCondicion.ValueChanged
    Dim vF As Date = Now.Date
    If IsDate(txtFecha.Value) Then
      vF = txtFecha.Value
    End If


    If cboCondicion.Text = "CREDITO" Then
      txtvencimiento.Text = vF.AddDays(15)
      txtvencimiento.Visible = True
    Else
      txtvencimiento.Visible = False
    End If
  End Sub

  Private Sub txtRucDni_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRucDni.ValueChanged
    vOkR = False
  End Sub



  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns("almacenid").Hidden = True
      .Columns("nombre").Width = cboAlmacen.Width

    End With
  End Sub

  Private Sub cboAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacen.KeyDown
    If e.KeyCode = Keys.Enter Then
      txtRucDni.Focus()
    End If
  End Sub


  Private Sub txtBuscar_ValueChanged(sender As Object, e As EventArgs) Handles txtBuscar.ValueChanged

  End Sub

  Private Sub dgvDetalle_venta_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDetalle_venta.KeyDown
    If e.KeyCode = Keys.Enter Then
      If dgvListado.Rows.Count > 0 Then
        Call Editar_Registro()
      End If
    End If
  End Sub
End Class