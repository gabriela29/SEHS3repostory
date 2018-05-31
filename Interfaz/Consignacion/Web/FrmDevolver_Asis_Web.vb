Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmDevolver_Asis_Web
  Public pCodigo As Long, pCodigo_Asis As Long, pDOI As String, pNom_Asistente As String, pCodigo_Alm As Integer, pNombre_Almacen As String, pTipo As Integer
  Public dtDocumento As DataTable, dtDetalle As DataTable
  Public vFormato As String = "", vImpresora As String = "", vSerieTk = "", vImprimir As Boolean, vCopias As Integer

  Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
    CheckForIllegalCrossThreadCalls = False
    Dim vCodigo_Usu As Long, vCaja As String = ""
    dtDocumento = New DataTable
    dtDetalle = New DataTable
    vCodigo_Usu = GestionSeguridadManager.idUsuario
    vCaja = "DEVOLVER" 'My.Computer.Name
    Try
      Call cursoresManager.Datos_Ventana_Web_NC_Colp(pCodigo_Alm, pCodigo_Asis, pCodigo, vCodigo_Usu,
                                                        vCaja, dtDocumento, dtDetalle)
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

    dgvDetalle_venta.DataSource = dtDetalle
    Call CalcularTotales()
    picAjax.Visible = False
    'BtnGrabar.Visible = True


  End Sub

  Private Sub FrmDevolver_Asis_Web_Load(sender As Object, e As EventArgs) Handles Me.Load

    'imgCabecera.Image = Global.SoftComNet.My.Resources.Resources.small
    txtFecha.Value = Now.Date
    picAjax.Visible = True
    lblAlmacen.Text = pNombre_Almacen

    If Not bwDatos.IsBusy Then
      bwDatos.RunWorkerAsync()
    End If

    'Objp = personaManager.Datos_Persona_Basic("N", "", pCodigo_Asis)
    'If Not Objp Is Nothing Then
    'txtRucDni.Text = pDOI 'Objp.dni
    txtAnombreD.Text = pNom_Asistente 'Objp.ape_pat & " " & Objp.ape_mat & " " & Objp.nombre
    'End If
    'Objp = Nothing
  End Sub

  Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
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

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    If pCodigo_Asis = 0 Or pCodigo_Alm = 0 Then
      valido = False
      ErrorProvider1.SetError(txtAnombreD, "Falta Seleccinar y/o ingresar Asistente y/o Almacen")
      camposConError.Add("Codigo Per / Codigo Alm")
    Else
      ErrorProvider1.SetError(txtAnombreD, Nothing)
    End If

    'If Trim(txtRucDni.Text) = "" Then
    '  valido = False
    '  ErrorProvider1.SetError(txtRucDni, "Falta Ingresar Nro Documento")
    '  camposConError.Add("txtDNI")
    'Else
    '  ErrorProvider1.SetError(txtRucDni, Nothing)
    'End If

    If txtAnombreD.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(txtAnombreD, "Debe Seleccionar Asistente")
      camposConError.Add("Asistente")
    Else
      ErrorProvider1.SetError(txtAnombreD, Nothing)
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
        .Codigo_Ref1 = pCodigo
      End With

      'Lo metemos en el array
      Dim vArray As String, vTiene As Boolean, VAfDzmo As Integer, vValor_Dzmo As Single = 0
      vArray = ""
      For Each dgvRw In Me.dgvDetalle_venta.Rows
        If dgvRw.Band.Index = 0 Then
          vTiene = True
          VAfDzmo = IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), 1, 0)
          vValor_Dzmo = IIf(CBool(dgvRw.Cells("afecto_dzmo").Value), Configuracion.pDZMO, 0)

          If Single.Parse(dgvRw.Cells("stock").Value) < Single.Parse(dgvRw.Cells("cantidad").Value) Then
            MessageBox.Show("Hay cantidades que superan al stock, VERIFICAR")
            Exit Function
          End If
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
        MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub cboDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumento.ValueChanged
    If Not cboDocumento.DataSource Is Nothing Then
      If Not cboDocumento.Text.Trim = "" Then
        txtSerie.Text = cboDocumento.ActiveRow.Cells("serie").Value
        txtNumero.Text = Format((cboDocumento.ActiveRow.Cells("correlativo").Value), "00000000")
        vFormato = cboDocumento.ActiveRow.Cells("formato").Value
        vImpresora = cboDocumento.ActiveRow.Cells("impresora").Value
        vSerieTk = cboDocumento.ActiveRow.Cells("serie_tk").Value
        vImprimir = CBool(cboDocumento.ActiveRow.Cells("imprimir").Value)
        vCopias = cboDocumento.ActiveRow.Cells("copias").Value
      End If
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

  Public Function CalcularTotales() As Boolean
    Dim DtTot As New DataTable
    Dim Drs As DataRow, vPorc_Dzmo As Single = 0
    Dim vImporte As Single = 0, vSubTotal As Single = 0, Total_Dzmo As Single = 0

    CalcularTotales = False
    vPorc_Dzmo = Configuracion.pDZMO
    Try
      DtTot = dtDetalle

      For Each Drs In DtTot.Rows
        vSubTotal = (CSng(Drs("cantidad").ToString) * CSng(Drs("precio").ToString))
        If CBool(Drs("afecto_dzmo")) Then
          Total_Dzmo = Total_Dzmo + (vSubTotal * vPorc_Dzmo / 100)
        End If

        vImporte = vImporte + CSng(Drs("subtotal").ToString)

      Next Drs
      lblSubTotal.Text = FormatNumber((vImporte), 2, TriState.False, TriState.False)
      lblDZMO.Text = FormatNumber(Total_Dzmo, 2, TriState.False, TriState.False)
      Me.lblTotalDoc2.Text = FormatNumber((vImporte + Total_Dzmo), 2, TriState.False, TriState.False)

      Me.lblEnLetras.Text = Numeros_Letras.EnLetras((vImporte + Total_Dzmo))
      CalcularTotales = True
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub dgvDetalle_venta_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvDetalle_venta.InitializeLayout
    With dgvDetalle_venta.DisplayLayout.Bands(0)
      .Columns("id").Width = 20
      .Columns("id").Hidden = True
      .Columns("stock").Width = 40
      .Columns("stock").CellAppearance.TextHAlign = HAlign.Center
      .Columns("cantidad").Width = 60
      .Columns("cantidad").Header.Caption = "Cant"
      .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Center
      .Columns("cantidad").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("producto").Width = 335
      .Columns("afecto_igv").Header.Caption = "IGV"
      .Columns("afecto_igv").Width = 40
      .Columns("afecto_igv").CellAppearance.TextHAlign = HAlign.Center
      .Columns("afecto_dzmo").Header.Caption = "DZMO"
      .Columns("afecto_dzmo").Width = 40
      .Columns("afecto_dzmo").CellAppearance.TextHAlign = HAlign.Center
      .Columns("precio").Header.Caption = "Precio"
      .Columns("precio").Width = 70
      .Columns("precio").CellAppearance.TextHAlign = HAlign.Right
      .Columns("subtotal").Header.Caption = "Sub Total"
      .Columns("subtotal").Width = 80
      .Columns("subtotal").CellAppearance.TextHAlign = HAlign.Right
      .Columns("subtotal").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("dcto").Hidden = True
      .Columns("item").Hidden = True
    End With
  End Sub

End Class