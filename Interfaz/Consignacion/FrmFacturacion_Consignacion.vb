Imports CapaLogicaNegocio.Bll
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid


Public Class FrmFacturacion_Consignacion
    Public _codigo As Long, _Codigo_Doc As Long, _Codigo_Cli As Long, pRef As String = ""

    Private Sub llenar_combos()
        Try
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

            Dim dtL As DataTable
            Dim x As Integer = 5
            Dim opcionesv(x), opciones(x) As String
            opcionesv(0) = 0
            opcionesv(1) = 1
            opcionesv(2) = 2
            opcionesv(3) = 3
            opcionesv(4) = 4
            opcionesv(5) = 5

            opciones(0) = "Todos"
            opciones(1) = "Permanentes"
            opciones(2) = "Estudiantes"
            opciones(3) = "Nacionales"
            opciones(4) = "Asistente"
            opciones(5) = "Individual"

            dtL = DosOpcionesManager.GetList("cboTipo", opcionesv, opciones, x)

            'With cboTipo
            '    .DataSource = Nothing
            '    .DataSource = dtL
            '    .Refresh()
            '    .ValueMember = "opcionesv"
            '    .DisplayMember = "opciones"
            '    If .Rows.Count > 0 Then
            '        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            '    End If
            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwAlmacen_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwAlmacen.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim vCodigo_Unidad As Integer
        Dim st As New DataTable

        Try
            vCodigo_Unidad = 0
            vCodigo_Unidad = Integer.Parse(GestionSeguridadManager.gUnidadId)

            st = permisos_moduloManager.Leer_Almacenes_Unidad(GestionSeguridadManager.idUsuario, GestionModulos.modVentas, vCodigo_Unidad)

            e.Result = st

        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboAlmacen.InitializeLayout
        With cboAlmacen.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "Almacén"
            .Columns(1).Width = cboAlmacen.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub cboAlmacen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacen.Validated
        If cboAlmacen.ActiveRow Is Nothing Then
            If Not cboAlmacen.Text = "" Then
                cboAlmacen.Focus()
            End If
        End If

    End Sub

    Private Sub tsDNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDNuevo.Click
        With FrmBoleteo_Colportor
            .pCodigo_Alm = cboAlmacen.Value
            .pAlmacen = cboAlmacen.Text
            .MdiParent = MdiParent
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub FrmFacturacion_Consignacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        cboDesde.Text = Now.Date
        cboHasta.Text = Now.Date
        If pRef = "BCC" Then
            tsDNuevo.Enabled = True
        Else
            tsDNuevo.Enabled = False
        End If
    End Sub

    Private Sub tsDSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Actualizar()
    End Sub

    Public Sub Actualizar()
        picAjaxRes.Visible = True
        gpCriterios.Enabled = False
        gpBotones.Enabled = False
        dgvListado.DataSource = Nothing
        _codigo = 0
        If Not bwLlenar_Res.IsBusy Then
            bwLlenar_Res.RunWorkerAsync()
        End If
    End Sub

  Private Sub bwLlenar_Res_DoWork(ByVal sender As Object, ByVal e As ComponentModel.DoWorkEventArgs) Handles bwLlenar_Res.DoWork
    Dim DtRes As New DataTable
    Dim xCod_uni, xCod_Alm As Integer, vDesde, vHasta As String, vOpcion As Integer = 0, vPersona As Long = 0

    xCod_uni = Integer.Parse(GestionSeguridadManager.gUnidadId)

    If Not Trim(Me.cboAlmacen.Text) = "" Then
      xCod_Alm = CInt(cboAlmacen.Value)
    End If
    'vOpcion = cboDocumento.Value
    vDesde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
    vHasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)

    DtRes = ventaManager.Leer(xCod_Alm, 0, 0, 0, vDesde, vHasta, "", "", "", 0, "", "", pRef)

    e.Result = DtRes

  End Sub

  Private Sub bwLlenar_Res_RunWorkerCompleted(ByVal sender As Object, ByVal e As ComponentModel.RunWorkerCompletedEventArgs) Handles bwLlenar_Res.RunWorkerCompleted

    dgvListado.DataSource = CType(e.Result, DataTable)
    Call CalcularTotales_Res(CType(e.Result, DataTable))
    picAjaxRes.Visible = False
    gpCriterios.Enabled = True
    gpBotones.Enabled = True
    'dgvListado.Refresh()
    Me.lblRegistros_Res.Text = dgvListado.Rows.Count & " Registros"

  End Sub

  Public Function CalcularTotales_Res(ByVal DtTotales As DataTable) As Boolean
        Dim DtTot As New DataTable
        Dim Drs As DataRow
        Dim vDeudaVenc, vDeudaMora, vDeudaSM
        Dim vCod_a As Long = 0
        vDeudaVenc = 0
        vDeudaMora = 0
        vDeudaSM = 0
        CalcularTotales_Res = False
        'If Not Trim(TxtDNI_RUC.Text) = "" Then
        '    vCod_a = CInt(TxtDNI_RUC.Text)
        'End If
        Try
            DtTot = DtTotales 'obligacionManager.Obtener_Total_Deudas(vCod_a, 0, "")

            For Each Drs In DtTot.Rows

                'Select Case Trim(Drs("tipo").ToString)
                '    Case "M"
                '        vDeudaMora = CSng(Drs("monto").ToString)
                '    Case "V"
                '        vDeudaVenc = CSng(Drs("monto").ToString)
                '    Case "T"
                '        vDeudaSM = CSng(Drs("monto").ToString)

                'End Select
                'vTotal = vTotal + CSng(Drs("").ToString)
                'vTotal = CSng(vDeudaSM + vDeudaMora)

            Next Drs
            'Me.LblDeudares.Text = FormatNumber(vDeudaVenc, 2, TriState.False, TriState.False)
            'Me.LblDeudaMora.Text = FormatNumber(vDeudaMora, 2, TriState.False, TriState.False)
            'Me.LblDeudaSMora.Text = FormatNumber(vDeudaSM, 2, TriState.False, TriState.False)
            'Me.LblDeudaTotal.Text = FormatNumber(vTotal, 2, TriState.False, TriState.False)
            CalcularTotales_Res = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

  Private Sub dgvListado_BeforeSelectChange(ByVal sender As Object, ByVal e As BeforeSelectChangeEventArgs) Handles dgvListado.BeforeSelectChange
    _codigo = 0
    'Call Totales_Cero()
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        _Codigo_Doc = Integer.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_doc").Value))
        _Codigo_Cli = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_cli").Value))
        'Call Mostrar_Detalles()
      Else
        _codigo = 0
      End If
    End If
  End Sub


  Private Sub dgvListado_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
    With dgvListado.DisplayLayout.Bands(0)
      .Columns("codigo").Header.Caption = "ID"
      .Columns("codigo").Width = 20
      .Columns("fecha").Header.Caption = "FECHA"
      .Columns("fecha").Width = 100
      .Columns("codigo_doc").Hidden = True
      .Columns("documento").Width = 100
      .Columns("documento").Header.Caption = "DOCUMENTO"
      .Columns("numero").Width = 110
      .Columns("numero").Header.Caption = "NUMERO"
      .Columns("codigo_cli").Hidden = True
      .Columns("nombre_persona").Header.Caption = "PERSONA"
      .Columns("nombre_persona").Width = 200
      .Columns("moneda").Hidden = True
      .Columns("simbolo_moneda").Width = 40
      .Columns("vta_total").Width = 80
      .Columns("vta_total").Header.Caption = "TOTAL"
      .Columns("vta_total").CellAppearance.TextHAlign = HAlign.Right
      .Columns("vta_total").CellAppearance.BackColor = Color.LemonChiffon
      .Columns("aux_condicion").Width = 30
      .Columns("usuario").Width = 50
      .Columns("caja").Width = 50
      .Columns("impresiones").Hidden = True
      .Columns("codigo_ven").Hidden = True
      .Columns("estado").Hidden = True
      .Columns("cerrado").Hidden = True
      .Columns("condicion").Hidden = True
      .Columns("codigo_cat").Hidden = True
      .Columns("descontar_stock").Hidden = True
      .Columns("aux_descontar").Width = 30
      .Columns("aux_signo").Width = 30
      .Columns("signo").Hidden = True
      .Columns("codigo_alm").Hidden = True
      .Columns("almacen").Width = 50
    End With
  End Sub

  Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles dgvListado.InitializeRow
    If e.Row.Cells("estado").Value = False Then
      e.Row.Cells("numero").Appearance.Image = Global.Phoenix.My.Resources.Resources.img_anulado
      'Else
      '    e.Row.Cells("numero").Appearance.Image = Global.SoftComNet.My.Resources.Resources.edit_add
    End If
  End Sub

  Private Sub dgvListado_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgvListado.KeyDown
    If e.KeyCode = Keys.A Then
      If dgvListado.Rows.Count > 0 Then
        If dgvListado.Selected.Rows.Count > 0 Then
          _codigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
          If MessageBox.Show("¿Está seguro de Anular este documento?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            ventaManager.Cambiar_Estado(_codigo, GestionSeguridadManager.sUsuario, My.Computer.Name)

          End If

        End If
      End If
    End If
  End Sub

  Private Sub tsNotaCredito_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsNotaCredito.Click
    If dgvListado.Rows.Count > 0 Then
      If dgvListado.Selected.Rows.Count > 0 Then
        Dim dtTemp As New DataTable, tCodigo As Long = 0
        tCodigo = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells(0).Value))
        _Codigo_Cli = Long.Parse((dgvListado.DisplayLayout.ActiveRow.Cells("codigo_cli").Value))
        If pRef = "BCC" Then
          Dim frm As New FrmNota_Credito_Colportor
          frm.pCodigo = tCodigo
          frm.pCodigo_Per = _Codigo_Cli
          frm.pCodigo_Alm = cboAlmacen.Value
          frm.pAlmacen = cboAlmacen.Text

          Call LibreriasFormularios.Ver_Form(frm, "Nota Créd. Colp.")


        End If


      End If
    End If
  End Sub

  Private Sub tsdActualizar_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles tsdActualizar.Click
    Call Actualizar()
  End Sub
End Class