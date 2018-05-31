Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmActualizar_Colportor

  Public pCodigo As Long, pCodigo_Asis As Long, pAsistente As String, pDniAsis As String
  Public pCodigo_Alm As Integer, pAlmacen As String
  Public pSaldo As Single, pNroCuenta As String, pCampaniaId As Integer, pCampania As String
  Public pCodigo_Colp As Long, pColportor As String, pDNIColp As String, pCCOSTO As String

  Private Sub btnHistorial_C_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistorial_C.Click
    If pCodigo_Colp > 0 And Single.Parse(lblSaldo_Colp.Text) > 0 Then
      FrmHistorial_Persona.pPersona = lblNombre_Colp.Text
      FrmHistorial_Persona.pCodigo_Per = pCodigo_Colp
      FrmHistorial_Persona.ShowDialog()
    End If

  End Sub

  Private Sub txtdniColp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdniColp.KeyDown
    If e.KeyCode = Keys.Enter Then
      Dim ObjPe As New persona
      Dim vApe_Pat As String = "", vApe_Mat As String = "", vNombre As String = ""

      ObjPe = personaManager.Datos_Persona_Basic("N", txtdniColp.Text.Trim, 0)
      If Not ObjPe Is Nothing Then
        pCodigo_Colp = Long.Parse(ObjPe.personaid)
        vApe_Pat = ObjPe.ape_pat
        vApe_Mat = ObjPe.ape_mat
        vNombre = ObjPe.nombre
        lblNombre_Colp.Text = vApe_Pat & " " & vApe_Mat & ", " & vNombre
        lblNombre_Colp.Tag = pCodigo_Colp
        lblSaldo_Colp.Text = ObjPe.saldo
        txtObservacion.Focus()
      Else
        lblNombre_Colp.Text = ""
        lblNombre_Colp.Tag = 0
        txtdniColp.Focus()
      End If
    End If
  End Sub

  Private Sub FrmActualizar_Colportor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    'If e.KeyChar = Chr(Keys.Enter) Then
    '    SendKeys.Send("{tab}")
    'End If
  End Sub

  Private Sub txtdniColp_ValueChanged(sender As Object, e As EventArgs) Handles txtdniColp.ValueChanged

  End Sub

  Private Sub Llenar_Combos()

    Dim dtC As DataTable

    dtC = centro_costoManager.GetListcbo(pCodigo_Alm, 1)

    With cboCentroCosto
      .DataSource = dtC
      .ValueMember = "centro_costo"
      .DisplayMember = "nombre"
      If .Rows.Count > 0 Then
        If pCodigo > 0 Then
          '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
          cboCentroCosto.Value = pCCOSTO
        End If
      End If
    End With

  End Sub

  Private Sub FrmActualizar_Colportor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    lblAlmacen.Text = pAlmacen
    lblDNIAsis.Text = pDniAsis
    lblAsistente.Text = pAsistente
    lblCtaMaestra.Text = pNroCuenta
    lblCampania.Text = pCampania
    If pCodigo > 0 Then
      txtdniColp.Enabled = False
      txtdniColp.Text = pDNIColp
      lblNombre_Colp.Text = pColportor

    Else
      txtdniColp.Enabled = True
    End If
    Call Llenar_Combos()
  End Sub

  Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
    Me.Close()
  End Sub

  Public Function Actualizar() As Boolean
    Dim Objeto As New personas_campania, xNew As Boolean = True
    Try
      With Objeto
        .codigo_cam = pCampaniaId
        .codigo_alm = pCodigo_Alm
        .codigo_asi = pCodigo_Asis
        .codigo_colp = pCodigo_Colp
        .nrocuenta = ""
        .c_costo = cboCentroCosto.Value
        .observacion = "" 'txtObservacion.Text
        .usuario = GestionSeguridadManager.sUsuario
        .caja = My.Computer.Name

      End With
      If pCodigo > 0 Then
        xNew = False
      End If
      If Control_AsistenteManager.Grabar(xNew, Objeto) > 0 Then
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

    If pCodigo_Asis = 0 Or pCodigo_Alm = 0 Then
      valido = False
      ErrorProvider1.SetError(lblDNIAsis, "Falta Seleccinar y/o ingresar Asistente y/o Almacen")
      camposConError.Add("Codigo Per / Codigo Alm")
    Else
      ErrorProvider1.SetError(lblDNIAsis, Nothing)
    End If

    If Trim(txtdniColp.Text) = "" Then
      valido = False
      ErrorProvider1.SetError(txtdniColp, "Falta Ingresar Nro Documento del Colportor")
      camposConError.Add("DNICOLP")
    Else
      ErrorProvider1.SetError(txtdniColp, Nothing)
    End If

    If cboCentroCosto.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(cboCentroCosto, "Debe Seleccionar un centro de costo")
      camposConError.Add("CCOSTO")
    Else
      ErrorProvider1.SetError(cboCentroCosto, Nothing)
    End If

    If lblAsistente.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblAsistente, "Debe Seleccionar Asistente")
      camposConError.Add("Asistente")
    Else
      ErrorProvider1.SetError(lblAsistente, Nothing)
    End If

    If Not GestionSeguridadManager.sUsuario = "admin" Then
      If CSng(lblSaldo_Colp.Text) > 0 And pCodigo = 0 Then
        valido = False
        ErrorProvider1.SetError(lblSaldo_Colp, "El Colportor tiene deuda por lo cual no puede agregarlo en su sucursal")
        camposConError.Add("Deuda")
      Else
        ErrorProvider1.SetError(lblSaldo_Colp, Nothing)
      End If
    End If

    If lblCtaMaestra.Text.Trim = "" Then
      valido = False
      ErrorProvider1.SetError(lblCtaMaestra, "El Asistente debe tener un Nro de Cuentas")
      camposConError.Add("CUENTA")
    Else
      ErrorProvider1.SetError(lblCtaMaestra, Nothing)
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

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
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

  Private Sub txtObservacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtObservacion.KeyDown
    If e.KeyCode = Keys.Enter Then
      BtnGrabar.Focus()
    End If
  End Sub

  Private Sub cboCentroCosto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboCentroCosto.InitializeLayout
    With cboCentroCosto.DisplayLayout.Bands(0)
      '.Columns (0).Width 
      .Columns(1).Width = cboCentroCosto.Width - .Columns(0).Width
      '.Columns(2).Hidden = True
    End With
  End Sub

End Class