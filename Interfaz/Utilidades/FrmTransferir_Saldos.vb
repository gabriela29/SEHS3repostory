

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmTransferir_Saldos
    Public pCodigo_Per As Long = 0, pTipoPer As String = "", pDireccion As String = "", pPersona As String = "", vOkR As Boolean

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
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With

            With cboDocumento
                .DataSource = Nothing
                .DataSource = GestionTablas.dtperdoc
                .Refresh()
                .ValueMember = "documentoid"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End With

            Dim lMeses As New ClsCrearMeses

            With cboAnio_Origen
                .DataSource = Nothing
                .DataSource = lMeses.GetList_anios()
                .Refresh()
                .ValueMember = "nombre"
                .DisplayMember = "nombre"
                If .Rows.Count > 0 Then
                    '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If

            End With
        Catch ex As Exception
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

 
    Private Sub FrmTransferir_Saldos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        vOkR = False
        cboAnio_Origen.Text = Year(Date.Now) - 1

    End Sub

    Private Sub cboDocumento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDocumento.InitializeLayout
        With cboDocumento.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboDocumento.Width
            .Columns(2).Hidden = True

        End With
    End Sub

    Private Sub btnTransferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferir.Click
        If Val(cboDocumento.Value) = 0 Then
            MsgBox("Falta seleccionar el tipo de documento.", vbInformation, "Información")
            cboDocumento.Focus()
            Exit Sub
        End If

        'Dim oTransferencia As New Logica_SEHS.clsTransferencia_Stock
        'If oTransferencia.Existe(Val(cboAlmacen.BoundText), Val(cboOrigen.Text), IIf(optPositivo.Value, "I", "S")) Then
        '    MsgBox("El proceso que intenta ejecutar ya existe.", vbInformation, "Información")
        '    Exit Sub
        'End If

        Dim vTip_Mov As Integer = 3
        If GestionSeguridadManager.sUsuario = "admin" Then
            If MsgBox("¿Esta seguro de transferir el stock del año " & cboAnio_Origen.Text & " al ano " & lblAnio_Destino.Text & "?", vbYesNo + vbQuestion, "Responda") = vbYes Then
                If transferis_stockManager.Transferir(Val(cboAnio_Origen.Text), Val(lblAnio_Destino.Text), _
                                                                    Val(cboAlmacen.Value), Val(vTip_Mov), Val(cboDocumento.Value), _
                                                                    Val(pCodigo_Per), GestionSeguridadManager.idUsuario, My.Computer.Name) Then
                    MsgBox("Transferencia de stock realizada correctamente.", vbInformation, "Información")
                    Call Obtener_Importes()
                Else
                    MsgBox("Problemas al transferir el stock.", vbInformation, "Información")
                End If

                'Call cboOrigen_Click()
            End If
        Else
            MsgBox("No tiene el permiso necesario para transferir el stock.", vbInformation, "Información")
        End If
    End Sub

    Private Sub cboAnio_Origen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboAnio_Origen.InitializeLayout
        cboAnio_Origen.DisplayLayout.Bands(0).Columns(0).Width = cboAnio_Origen.Width
    End Sub

    Private Sub cboAnio_Origen_ValueChanged(sender As Object, e As EventArgs) Handles cboAnio_Origen.ValueChanged
        If Not cboAnio_Origen.Text = "" Then
            lblAnio_Destino.Text = Integer.Parse(cboAnio_Origen.Text) + 1
            btnTransferir.Visible = True
            Call Obtener_Importes()
        Else
            lblAnio_Destino.Text = ""
            btnTransferir.Visible = False
        End If
    End Sub

    Private Sub Obtener_Importes()
        btnT_Origen.Text = "0.00"
        btnT_Destino.Text = "0.00"
        upgConfiguracion.Visible = False
        btnTransferir.Visible = False

        If Not cboAlmacen.Text = "" Then
            If Not cboAnio_Origen.Text = "" Then
                If Not lblAnio_Destino.Text = "" Then
                    Dim DtImp As New DataTable, tOrigen As Single = 0, tDestino As Single = 0
                    If transferis_stockManager.GetList(Integer.Parse(cboAnio_Origen.Text), Integer.Parse(lblAnio_Destino.Text), Integer.Parse(cboAlmacen.Value), tOrigen, tDestino) Then
                        btnT_Origen.Text = tOrigen
                        btnT_Destino.Text = tDestino
                        If tOrigen > 0 And tDestino = 0 Then
                            upgConfiguracion.Visible = True
                            btnTransferir.Visible = True
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub Listado_clientes()
        Dim testDialog As New FrmConsulta_Personas()
        'testDialog.Cod_Cat = 4
        TxtAnombreD.Text = "..."
        lblPersonaId.Text = "-2"
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim objP As New persona
            lblPersonaId.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(0).Value)
            TxtAnombreD.Text = CStr(testDialog.dgvListado.DisplayLayout.ActiveRow.Cells(4).Value)

        End If
        testDialog.Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Call Listado_clientes()
    End Sub

    Private Sub btnT_Origen_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboAlmacen_ValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.ValueChanged
        Call Obtener_Importes()
    End Sub
End Class