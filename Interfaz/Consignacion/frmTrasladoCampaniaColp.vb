Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class frmTrasladoCampaniaColp
  Private Sub llenar_combos()

    Try
      Dim dtCamp As New DataTable

      dtCamp = campaniaManager.Campania_leer("")
      With cboCampania
        .DataSource = dtCamp
        .ValueMember = "campaniaid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          'If pCodigo > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
          '  cboTipo.Value = pCCOSTO
          'End If
        End If
      End With

      With cboCampaniaDest
        .DataSource = dtCamp
        .ValueMember = "campaniaid"
        .DisplayMember = "nombre"
        If .Rows.Count > 0 Then
          'If pCodigo > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
          '  cboTipo.Value = pCCOSTO
          'End If
        End If
      End With

      With Me.cboAlmacen
        .DataSource = GestionTablas.dtFAlmacen
        '.DataBind()
        .ValueMember = "almacenid"
        .DisplayMember = "nombre"
        .MinDropDownItems = 2
        .MaxDropDownItems = 4
        If .Rows.Count > 0 Then
          .SelectedRow = .GetRow(ChildRow.First)
        End If

      End With

    Catch ex As Exception
      MsgBox(ex.Message)
    End Try
  End Sub

  Private Sub Llenar_CbosxAlmacen(ByVal vAlmacenId As Integer)

    With cboCentroCosto
      .DataSource = centro_costoManager.GetListcbo(vAlmacenId, 1)
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then

        .SelectedRow = .GetRow(ChildRow.First)
        'cboCentroCosto.Value = pCCOSTO

      End If
    End With

  End Sub
  Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged
    Call Llenar_CbosxAlmacen(cboAlmacen.Value)
  End Sub

  Private Sub frmTrasladoCampaniaColp_Load(sender As Object, e As EventArgs) Handles Me.Load
    Call llenar_combos()
  End Sub

  Private Sub bwLlenar_Detalle_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwLlenar_Detalle.DoWork
    Dim DtColp As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vHasta As String, xAsis As Long = 0

    xCod_uni = GestionSeguridadManager.gUnidadId
    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    If Not Trim(Me.cboAsistente.Text) = "" Then
      xAsis = CInt(cboAsistente.Value)
    End If

    vHasta = LibreriasFormularios.Formato_Fecha(Now.Date)

    ''obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")
    ' create and bind sample DataSet
    DtColp = Control_AsistenteManager.Leer_Colportores_Tras(xCod_uni, xCod_Alm, cboCampania.Value, xAsis)

    e.Result = DtColp
    'Ctas = 0
  End Sub

  Private Sub bwLlenar_Detalle_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Detalle.RunWorkerCompleted

    dgvResumen.DataSource = CType(e.Result, DataTable)
    'Call CalcularTotales_Det()

    picAjaxBig.Visible = False
    picAjaxRes.Visible = False
    'gpBotones.Enabled = True
    dgvResumen.Enabled = True

    Me.lblRegistros_Res.Text = dgvResumen.Rows.Count & " Registros"

  End Sub

  Private Sub tsAsActualizar_Click(sender As Object, e As EventArgs) Handles tsAsActualizar.Click
    picAjaxRes.Visible = True

    'gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    dgvResumen.DataSource = Nothing
    LblDeudaTotal.Text = "0.00"
    If Not bwLlenar_Detalle.IsBusy Then
      bwLlenar_Detalle.RunWorkerAsync()
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

  Private Sub Llenar_Asis(ByVal vCamp As Integer)
    With Me.cboAsistente
      .DataSource = Control_AsistenteManager.Leer_Asistentes(GestionSeguridadManager.gUnidadId, cboAlmacen.Value, vCamp)
      '.DataBind()
      .ValueMember = "codigo_per"
      .DisplayMember = "persona"
      .MinDropDownItems = 2
      .MaxDropDownItems = 10
      If .Rows.Count > 0 Then
        .SelectedRow = .GetRow(ChildRow.First)
      End If
    End With
  End Sub
  Private Sub cboCampania_ValueChanged(sender As Object, e As EventArgs) Handles cboCampania.ValueChanged
    Call Llenar_Asis(cboCampania.Value)
  End Sub

  Private Sub dgvResumen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvResumen.InitializeLayout
    With dgvResumen.DisplayLayout.Bands(0)
      .Columns(0).Hidden = True
      .Columns(1).Width = 50
      .Columns(2).CellActivation = Activation.NoEdit
      .Columns(3).CellActivation = Activation.NoEdit
      .Columns(4).CellActivation = Activation.NoEdit
      .Columns(5).Hidden = True
      .Columns(6).Hidden = True
      .Columns(7).Hidden = True
      .Columns(8).Hidden = True
      .Columns(9).Hidden = True
      .Columns(10).Hidden = True
    End With
  End Sub

  Private Sub chkActivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkActivar.CheckedChanged
    Dim dgvRw As UltraGridRow

    For Each dgvRw In dgvResumen.Rows
      If dgvRw.Band.Index = 0 Then
        'If dgvRw.Cells("sel").Text = "True" Then
        dgvRw.Cells("sel").Value = chkActivar.Checked
        'Else
        'dgvRw.Cells("sel").Value = 1
        'End If
      End If
    Next
  End Sub

  Private Function Actiualizar_Grid_Temp(ByVal sender As Object) As DataTable
    Dim DtTemp As New DataTable, NwRow As DataRow
    Dim dtGrid As UltraGrid, dgvTemp As UltraGridRow
    DtTemp = ClsTablitas.Get_Pasar_Colp("pasarColp")
    dtGrid = sender
    For Each dgvTemp In dtGrid.Rows
      If dgvTemp.Band.Index = 0 Then

        If dgvTemp.Cells("sel").Text = "True" Then
          'If dgvTemp.Cells("importe").Value > 0 Then
          NwRow = DtTemp.NewRow
          NwRow.Item("colportorid") = dgvTemp.Cells("codigo_per").Value
          NwRow.Item("dni") = dgvTemp.Cells("nrodocumento").Value
          NwRow.Item("colportor") = dgvTemp.Cells("persona").Value
          NwRow.Item("importe") = CSng(dgvTemp.Cells("importe").Value)
          DtTemp.Rows.Add(NwRow)
          'End If
        End If
      End If
    Next
    Return DtTemp
  End Function

  Private Sub btnPasar_Click(sender As Object, e As EventArgs) Handles btnPasar.Click
    dgvListado.DataSource = Actiualizar_Grid_Temp(dgvResumen)
    dgvListado.Visible = True
    'Call Calcular_Totales_Grid(dgvTemp, False)
  End Sub

  Private Sub tsGrabarTraslado_Click(sender As Object, e As EventArgs) Handles tsGrabarTraslado.Click
    If cboCampania.Value = cboCampaniaDest.Value Then
      MessageBox.Show("Debe seleccionar una campaña de destino distinta", "AVISO")
    Else
      If Trasladar() Then
        Me.Close()
      End If
    End If

  End Sub

  Public Function Trasladar() As Boolean

    Dim dgvRw As UltraGridRow, xok As Boolean = False
    Try

      'Lo metemos en el array
      Dim vArray As String, vTiene As Boolean
      vArray = ""
      For Each dgvRw In Me.dgvListado.Rows
        If dgvRw.Band.Index = 0 Then
          vTiene = True
          vArray = vArray & "['" & Str(dgvRw.Cells("colportorid").Value).Trim & "','" &
                                   Str("0") & "'],"
        End If
      Next
      If vTiene Then
        vArray = Mid(vArray, 1, Len(vArray) - 1)
        vArray = "array[" & vArray & "]"
      Else
        vArray = "null"
      End If

      If Control_AsistenteManager.Trasladar_Colportor_Bloque(cboCampania.Value, cboAlmacen.Value, cboAsistente.Value, cboCampaniaDest.Value, cboCentroCosto.Value, vArray, GestionSeguridadManager.idUsuario, GestionSeguridadManager.NombrePC) > 0 Then
        FrmControl_Asistentes.Mostrar_Detalles()
        Me.Close()
      End If
      'MessageBox.Show(Objeto.idtipodocid)
      xok = True
    Catch ex As Exception
      MsgBox(ex.Message)
      xok = False
    End Try
    Return xok
  End Function

  Private Sub cboAsistente_ValueChanged(sender As Object, e As EventArgs) Handles cboAsistente.ValueChanged
    picAjaxRes.Visible = True

    'gpBotones.Enabled = False
    dgvListado.DataSource = Nothing
    dgvResumen.DataSource = Nothing
    LblDeudaTotal.Text = "0.00"
    If Not bwLlenar_Detalle.IsBusy Then
      bwLlenar_Detalle.RunWorkerAsync()
    End If
  End Sub
End Class