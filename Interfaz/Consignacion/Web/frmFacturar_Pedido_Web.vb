
Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win

Public Class frmFacturar_Pedido_Web
  Public pPedidoid As Long
  Public pCodigo_Alm As Integer, pAlmacen As String
  Public dtDocumento As DataTable, dtDoc_Dzmo As DataTable, dtFP As DataTable
  Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer, vCodigo_Serie As Long = 0
  Public vCodigo_Doc As Integer, vFormatoD As String = "", vImpresoraD As String = "", vSerieTkD = "", vImprimirD As Boolean, vCopiasD As Integer
  Public vCodigo_DocD As Integer = 0, vCodigo_SerieD As Long = 0, vSerieD As String = "", vNumeroD As Long = 0

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

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtDoc_Dzmo = New DataTable
    dtFP = New DataTable
    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = My.Computer.Name
    Try
      Call cursoresManager.Datos_Ventana_venta(pCodigo_Alm, vCodigo_Usu,
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

      .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
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

  Private Sub Nueva_Venta()
    Dim vF As Date = Now.Date
    If IsDate(txtFecha.Value) Then
      vF = txtFecha.Value
    End If

    txtFecha.Value = Now.Date
    txtvencimiento.Text = vF.AddDays(15)


    picAjax.Visible = True

    lblAlmacen.Tag = pCodigo_Alm
    lblAlmacen.Text = pAlmacen

    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If

  End Sub

  Private Sub frmFacturar_Pedido_Web_Load(sender As Object, e As EventArgs) Handles Me.Load

    txtRecibo_Dzmo.Text = ""

    Call Nueva_Venta()
  End Sub

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True

    If cboDocumento.Text = "" Then
      MessageBox.Show("Debe seleccionar un Tipo de documento")
      valido = False
    End If

    If Trim(txtSerie.Text) = "" Or vCodigo_Serie = 0 Then
      MessageBox.Show("Falta Serie")
      valido = False
    End If

    If Trim(txtNumero.Text) = "" Then
      MessageBox.Show("Falta Ingresar Número")
      valido = False
    End If

    If txtRecibo_Dzmo.Text = "" Or vCodigo_SerieD = 0 Then
      MessageBox.Show("Falta Ingresar número de recibo de Diezmo")
      valido = False
    End If

    If Not IsDate(txtFecha.Value) Then
      MessageBox.Show("Debe ingresar una fecha válida")
      valido = False
    End If

    If Not IsDate(txtvencimiento.Value) Then
      MessageBox.Show("Debe ingresar fecha de vencimiento")
      valido = False
    End If

    Return valido
  End Function

  Private Function GrabarRegistroDoc() As Boolean
    Dim FEmi, FVence As String, vUs As Long = GestionSeguridadManager.idUsuario
    Dim dtR As New DataTable, vCaja As String = My.Computer.Name
    FEmi = ""
    FVence = ""

    Try

      FEmi = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
      If txtvencimiento.Visible = True Then
        FVence = LibreriasFormularios.Formato_Fecha(txtvencimiento.Text)
      End If

      dtR = pedidocolpwebManager.Facturar_Pedido_Web(pPedidoid, pCodigo_Alm, txtSerie.Text, txtNumero.Text, vCodigo_Doc,
                                                 FEmi, vUs, vCaja, vCodigo_Serie, vCodigo_DocD,
                                                 vSerieD, vNumeroD, vCodigo_SerieD, "..-..")

      If Not dtR.Rows.Count > 0 Then
        GrabarRegistroDoc = False
        Exit Function
      Else
        GrabarRegistroDoc = True
        If pPedidoid > 0 Then
          Dim vDtCabecera As New DataTable, vDtDetalle As New DataTable, vDtDzmo As New DataTable
          If ventaManager.Datos_Impresion_PWC(Long.Parse(pPedidoid), pCodigo_Alm, vDtCabecera, vDtDetalle) Then
            If Impresion_WSpool.Print_Ticket(vCodigo_Doc, pCodigo_Alm, pAlmacen, GestionSeguridadManager.NombrePC, vDtCabecera, vDtDetalle) Then
              'Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, vCodigo_Doc)
            End If
          End If
          vDtDzmo = reportes_consignacionManager.Datos_Impresion_Dzmo_PWC(pPedidoid)
          If Impresion_WSpool.Print_Recibo_Dzmo(vCodigo_DocD, pCodigo_Alm, pAlmacen, GestionSeguridadManager.NombrePC, vDtDzmo) Then
            'Call ClsImpresiones.Imprimir_Rpt_DZMO(Long.Parse(ok), pCodigo_Alm, vCodigo_DocD, vFormatoD, vSerieTkD, vCopiasD, vImpresoraD)
          End If
        End If

        'Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, cboDocumento.Value, vFormato, vSerieTk, vCopias, vImpresora)
        'Call ClsImpresiones.Imprimir_Rpt(Long.Parse(ok), pCodigo_Alm, vCodigo_Doc)
        'Call ClsImpresiones.Imprimir_Rpt_DZMO(Long.Parse(ok), pCodigo_Alm, vCodigo_DocD, vFormatoD, vSerieTkD, vCopiasD, vImpresoraD)

      End If

      GrabarRegistroDoc = True
    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub Imprimir()
    'Dim rsCabecera As New DataTable, rsDetalle As New DataTable
    'Dim vFecha As String = LibreriasFormularios.Formato_Fecha(txtFecha.Value)
    'Dim vNumDesde As String = txtSerie.Text & "-" & txtNumero.Text
    'If movimiento_bancarioManager.Datos_Imprimir_Suscripcion_Fact(pCodigo_Almacen, pIglesiaID, pPeriodoId, 0, vCodigo_Doc, vFecha,
    '                                                                    vFecha, vNumDesde, "", pDMId, rsCabecera, rsDetalle) Then
    '  If Impresion_WSpool.Print_Ticket(vCodigo_Doc, pCodigo_Almacen, pAlmacen, GestionSeguridadManager.NombrePC, rsCabecera, rsDetalle) Then

    '  End If
    'End If
  End Sub

  Private Sub btnEmitir_Click(sender As Object, e As EventArgs) Handles btnEmitir.Click
    If ValidarDatos() Then
      If MessageBox.Show("¿Está seguro de Grabar el documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        btnEmitir.Enabled = False
        If GrabarRegistroDoc() Then
          FrmPedido_Web.pFicha = "P"
          FrmPedido_Web.Actualizar()
          Me.Close()
          MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
        End If
      End If
    End If
  End Sub

End Class