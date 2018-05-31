Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmTrasladarColp
  Public pAlmacenId As Integer, pAsistenteId As Long
  Public pAlmacen As String, pAsistente As String
  Public pCamapaniaId As Integer, pCampania As String
  Public pColoportoId As Long, pDniColp As String, pColportor As String, pTipo As String, pSaldo As Single

  Private Sub Llenar_Combos()
    With Me.cboAlmacen
      .DataSource = almacenManager.GetCombo_Resto_Almacen(pAlmacenId, GestionSeguridadManager.gUnidadId)
      '.DataBind()
      .ValueMember = "almacenid"
      .DisplayMember = "nombre"
      .MinDropDownItems = 2
      .MaxDropDownItems = 4
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With

    With cboCentro_Costo
      .DataSource = centro_costoManager.GetListcbo(pAlmacenId, 1)
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        'If pCodigo > 0 Then
        '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        cboCentro_Costo.Value = pTipo
        'End If
      End If
    End With

    With cboCampania
      .DataSource = campaniaManager.Campania_leer("")
      .ValueMember = "campaniaid"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        'If pCodigo > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
        'cboCentro_Costo.Value = pTipo
        'End If
      End If
    End With

  End Sub

  Private Sub btnGrabar2_Click(sender As Object, e As EventArgs) Handles btnGrabar2.Click
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

  Private Sub FrmTrasladarColp_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call Llenar_Combos()

    lblAlmacen.Text = pAlmacen
    lblAsistente.Text = pAsistente

    lblColportor.Text = pColportor
    lblDniColp.Text = pDniColp
    lblTipo.Text = pTipo
    lblSaldo.Text = pSaldo

  End Sub

  Private Sub cboCentro_Costo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboCentro_Costo.InitializeLayout
    With cboCentro_Costo.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Centro Costo"
      .Columns(1).Width = cboCentro_Costo.Width
      '.Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
    With cboAlmacen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Header.Caption = "Almacén"
      .Columns(1).Width = cboAlmacen.Width
      .Columns(2).Hidden = True

    End With
  End Sub

  Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged

    If Not cboAlmacen.Text = "" Then
      With Me.cboAsistente
        .DataSource = Control_AsistenteManager.Leer_Asistentes(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, 0)
        '.DataBind()
        .ValueMember = "codigo_per"
        .DisplayMember = "persona"
        .MinDropDownItems = 2
        .MaxDropDownItems = 10
        If .Rows.Count > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
        End If
      End With
    End If
  End Sub

  Private Sub cboAsistente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboAsistente.InitializeLayout
    With cboAsistente.DisplayLayout.Bands(0)
      .Columns("codigo_per").Hidden = True
      .Columns("nrodocumento").Width = 80
      .Columns("nrodocumento").Header.Caption = "DNI-RUC"
      .Columns("persona").Width = cboAsistente.Width
      .Columns("sexo").Hidden = True
      .Columns("nrocuenta").Hidden = True
      .Columns("importe").Hidden = True
      .Columns("observacion").Hidden = True
      .Columns("usuario").Hidden = True
      .Columns("caja").Hidden = True
      .Columns("almacen").Hidden = True
      .Columns("codigo_alm").Hidden = True
      .Columns("fecha").Hidden = True
    End With

  End Sub


  Public Function Actualizar() As Boolean
    Dim Objeto As New personas_campania, xNew As Boolean = True
    Try
      With Objeto
        .codigo_cam = cboCampania.Value
        .codigo_alm = cboAlmacen.Value
        .codigo_asi = cboAsistente.Value
        .codigo_colp = pColoportoId
        .nrocuenta = ""
        .c_costo = cboCentro_Costo.Value
        .observacion = "" 'txtObservacion.Text
        .usuario = GestionSeguridadManager.sUsuario
        .caja = My.Computer.Name

      End With
      If Control_AsistenteManager.Trasladar_Colportor(Objeto, pAlmacenId, pAsistenteId, pSaldo) > 0 Then
        FrmControl_Asistentes.Mostrar_Detalles()
        Me.Close()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Function

  Private Function ValidarDatos() As Boolean
    Dim valido As Boolean = True
    Dim camposConError As New Specialized.StringCollection
    Dim campo As String

    If pAsistenteId = 0 Or pAlmacenId = 0 Then
      valido = False
      ErrorProvider1.SetError(lblAsistente, "Falta Seleccinar y/o ingresar Asistente y/o Almacen")
      camposConError.Add("Codigo Per / Codigo Alm")
    Else
      ErrorProvider1.SetError(lblAsistente, Nothing)
    End If

    If Trim(cboAlmacen.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(cboAlmacen, "Falta seleccionar Almacen Destino")
      camposConError.Add("ALMDEST")
    Else
      ErrorProvider1.SetError(cboAlmacen, Nothing)
    End If

    If cboCentro_Costo.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(cboCentro_Costo, "Debe Seleccionar un centro de costo")
      camposConError.Add("CCOSTO")
    Else
      ErrorProvider1.SetError(cboCentro_Costo, Nothing)
    End If

    If cboAsistente.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(cboAsistente, "Debe Seleccionar Asistente Destino")
      camposConError.Add("AsistenteD")
    Else
      ErrorProvider1.SetError(cboAsistente, Nothing)
    End If

    'If Not GestionSeguridadManager.sUsuario = "admin" Then
    '  If CSng(lblSaldo_Colp.Text) > 0 And pCodigo = 0 Then
    '    valido = False
    '    ErrorProvider1.SetError(lblSaldo_Colp, "El Colportor tiene deuda por lo cual no puede agregarlo en su sucursal")
    '    camposConError.Add("Deuda")
    '  Else
    '    ErrorProvider1.SetError(lblSaldo_Colp, Nothing)
    '  End If
    'End If
    If valido Then
      If pAsistenteId = cboAsistente.Value And pAlmacenId = cboAlmacen.Value Then
        valido = False
        ErrorProvider1.SetError(cboAsistente, "El asistente y el Almacén de destino deben ser distintos")
        camposConError.Add("Asistente_almacén_NO_IGUALES")
      Else
        ErrorProvider1.SetError(cboAsistente, Nothing)
      End If
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

End Class