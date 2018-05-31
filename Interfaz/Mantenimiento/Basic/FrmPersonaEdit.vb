
Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmPersonaEdit

    Public vPersonaId As Long, vDNIok As Boolean = False, vRUCok As Boolean = False
    Public pTipoPer As String = "", pTipoN_RUC As Boolean, pTipoJ_RUC As Boolean, vFila As Long = 0
    Public vDpto As Integer = 0, vProv As Long = 0, vNJ As Boolean = False, vSelRol As Boolean = False
    Public dtRol As DataTable, dtEstCivil As DataTable, dtOtroDoc As DataTable, dtUbigeo As DataTable
    Public dtTpTelefono As DataTable, dtTelefono As DataTable, dtTipoEmail As DataTable, dtEmail As DataTable
    Public DtLDireccion As DataTable, dtLTelfono As DataTable, dtLEmail As DataTable, dtLRedes As DataTable
    Public dtTipoRedes As DataTable, dtRedes As DataTable, dtDireccion As DataTable, dtDatos As DataTable

    Private Sub bwDatos_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwDatos.DoWork
        CheckForIllegalCrossThreadCalls = False
        dtRol = New DataTable
        dtEstCivil = New DataTable
        dtOtroDoc = New DataTable
        dtUbigeo = New DataTable
        dtTpTelefono = New DataTable
        dtTelefono = New DataTable
        dtTipoEmail = New DataTable
        dtEmail = New DataTable
        dtTipoRedes = New DataTable
        dtRedes = New DataTable
        dtDireccion = New DataTable
        dtDatos = New DataTable
        Try
            Call cursoresManager.Datos_Ventana_Persona(vPersonaId, dtRol, dtEstCivil, dtOtroDoc, dtUbigeo, dtDireccion,
                                                       dtTpTelefono, dtTelefono, dtTipoEmail, dtEmail, dtTipoRedes, dtRedes, dtDatos)

            e.Result = dtRol

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwDatos_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwDatos.RunWorkerCompleted
        dgvCondicion.DataSource = dtRol

        With cboEstadoCivil
            .DataSource = Nothing
            .DataSource = dtEstCivil
            .ValueMember = "codigo"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then

                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With cboTipo_Telefono
            .DataSource = Nothing
            .DataSource = dtTpTelefono
            .ValueMember = "tipotelefonoid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 6
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With DTpTipoTelefono
            .DataSource = Nothing
            .DataSource = dtTpTelefono
            .DataBind()
            .ValueMember = "tipotelefonoid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
        End With

        With cboTipo_Mail
            .DataSource = Nothing
            .DataSource = dtTipoEmail
            .ValueMember = "tipoemailid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 6
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With uddTipoMail
            .DataSource = Nothing
            .DataSource = dtTipoEmail
            .DataBind()
            .ValueMember = "tipoemailid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
        End With

        With cboTipo_Redes
            .DataSource = Nothing
            .DataSource = dtTipoRedes
            .ValueMember = "tiposocialmediaid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 6
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If
        End With

        With uddTipoRedSS
            .DataSource = Nothing
            .DataSource = dtTipoRedes
            .DataBind()
            .ValueMember = "tiposocialmediaid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
        End With

        DtLDireccion = New DataTable
        DtLDireccion = ClsTablitas.Get_Direccion("direccion")
        dgvDireccion.DataSource = DtLDireccion

        dtLTelfono = New DataTable
        dtLTelfono = ClsTablitas.Get_Telefono("telefono")
        dgvTelefono.DataSource = dtLTelfono

        dtLEmail = New DataTable
        dtLEmail = ClsTablitas.Get_EMail("email")
        dgvEmail.DataSource = dtLEmail

        dtLRedes = New DataTable
        dtLRedes = ClsTablitas.Get_Sociales("redes")
        dgvRedes.DataSource = dtLRedes

        'dgvDireccion.DataSource = dtDireccion
        'dgvTelefono.DataSource = dtTelefono
        'dgvEmail.DataSource = dtEmail
        'dgvRedes.DataSource = dtRedes

        Call ObtenerDepartamento()

        If vPersonaId > 0 Then
            Call Mostrar_Registro()
        End If

        picAjax.Visible = False
        'BtnGrabar.Visible = True
    End Sub

    Public Sub ObtenerDepartamento()
        'dptoid, departamento, provid, provincia, disid, distrito 
        cboDpto.DataSource = Nothing
        cboProvincia.DataSource = Nothing
        cboDistrito.DataSource = Nothing

        Dim Filter As String = "dptoid > 0 "
        Dim dv As DataView
        If Not dtUbigeo Is Nothing Then
            dv = New DataView(dtUbigeo, Filter, "", DataViewRowState.CurrentRows)
            If dv.Count > 0 Then 'Sino hay datos

                With cboDptoJ
                    .DataSource = Nothing
                    .DataSource = dv
                    .DataBind()
                    .ValueMember = "dptoid"
                    .DisplayMember = "departamento"
                    .MinDropDownItems = 2
                    .MaxDropDownItems = 4
                    If .Rows.Count > 0 Then
                        '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End With

                With cboDpto
                    .DataSource = Nothing
                    .DataSource = dv
                    .DataBind()
                    .ValueMember = "dptoid"
                    .DisplayMember = "departamento"
                    .MinDropDownItems = 2
                    .MaxDropDownItems = 4
                    If .Rows.Count > 0 Then
                        '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End With


            End If
        Else

        End If
    End Sub

    Public Sub ObtenerProvincia(ByVal vDptoId As Long, ByVal vTipo As String)
        'dptoid, departamento, provid, provincia, disid, distrito, dptopid, provdid         

        If vDptoId > 0 Then
            Dim Filter As String = "dptopid = " & vDptoId
            Dim dv As DataView
            If Not dtUbigeo Is Nothing Then
                dv = New DataView(dtUbigeo, Filter, "", DataViewRowState.CurrentRows)
                If dv.Count > 0 Then 'Sino hay datos
                    If vTipo = "J" Then
                        With cboProvJ
                            .DataSource = dv
                            .DataBind()
                            .ValueMember = "provid"
                            .DisplayMember = "provincia"
                            .MinDropDownItems = 2
                            .MaxDropDownItems = 6
                            If .Rows.Count > 0 Then
                                '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                            End If
                        End With
                    Else
                        With cboProvincia
                            .DataSource = Nothing
                            .DataSource = dv
                            .DataBind()
                            .ValueMember = "provid"
                            .DisplayMember = "provincia"
                            .MinDropDownItems = 2
                            .MaxDropDownItems = 6
                            If .Rows.Count > 0 Then
                                '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                            End If
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub ObtenerDistrito(ByVal vProvId As Long, ByVal vTipo As String)
        'dptoid, departamento, provid, provincia, disid, distrito 
        'cboDistrito.DataSource = Nothing
        If vProvId > 0 Then
            Dim Filter As String = "provdid = " & vProvId
            Dim dv As DataView
            If Not dtUbigeo Is Nothing Then
                dv = New DataView(dtUbigeo, Filter, "", DataViewRowState.CurrentRows)
                If dv.Count > 0 Then 'Sino hay datos
                    If vTipo = "J" Then
                        With cboDistritoJ
                            .DataSource = Nothing
                            .DataSource = dv
                            .DataBind()
                            .ValueMember = "disid"
                            .DisplayMember = "distrito"
                            .MinDropDownItems = 2
                            .MaxDropDownItems = 6
                            If .Rows.Count > 0 Then
                                '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                            End If
                        End With
                    Else
                        With cboDistrito
                            .DataSource = Nothing
                            .DataSource = dv
                            .DataBind()
                            .ValueMember = "disid"
                            .DisplayMember = "distrito"
                            .MinDropDownItems = 2
                            .MaxDropDownItems = 6
                            If .Rows.Count > 0 Then
                                '.SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                            End If
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub llenar_combos()
        Try

            Dim opcionsxv(2) As String, _sexo(2) As String
            opcionsxv(0) = "M"
            opcionsxv(1) = "F"
            _sexo(0) = "Masculino"
            _sexo(1) = "Femenino"
            cboSexo.DataSource = Nothing
            cboSexo.DataSource = DosOpcionesManager.GetList("Sexo", opcionsxv, _sexo)
            'Me.cboSexo.DataBind()
            cboSexo.ValueMember = "Opcionesv"
            cboSexo.DisplayMember = "Opciones"
            cboSexo.Value = "M"
            'cboSexo.SelectedRow = cboSexo.GetRow(UltraWinGrid.ChildRow.First)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Mostrar_Registro()
        Dim dtRow As DataRow

        For Each dtRow In dtDatos.Rows
            pTipoPer = dtRow("tipo")
            If dtRow("tipo") = "N" Then
                chkPN.Checked = True
            Else
                chkPJ.Checked = True
            End If

            txtDNI.Text = dtRow("dni")
            txtRUC_PN.Text = dtRow("ruc")
            txtRuc_PJ.Text = dtRow("rucj") '
            txtTitulo.Text = dtRow("titulo")
            txtApe_Pat.Text = dtRow("paterno")
            txtApe_Mat.Text = dtRow("materno")
            TxtNombre.Text = dtRow("nombre")
            txtRazon_Social.Text = dtRow("razon_social")
            cboNacimiento.Value = dtRow("nacimiento")
            cboSexo.Value = dtRow("sexo")
            cboEstadoCivil.Value = dtRow("estado_civil")
            cboOtro_Doc.Value = dtRow("otrodocid")
            txtOtro_Numero.Text = dtRow("otronumdoc")
            txtNombre_Com.Text = dtRow("nombre_comercial")
            txtNombre_Com_PJ.Text = dtRow("nombre_comercial")
            txtDireccion.Text = dtRow("direccion")
            txtDireccion_PJ.Text = dtRow("direccion")

            cboDpto.Value = dtRow("departamentoid")
            cboDpto_Validated(cboDpto, System.EventArgs.Empty)
            cboDptoJ.Value = dtRow("departamentoid")
            cboDptoJ_Validated(cboDptoJ, System.EventArgs.Empty)

            cboProvJ.Value = dtRow("provinciaid")
            cboProvJ_Validated(cboProvJ, System.EventArgs.Empty)
            cboProvincia.Value = dtRow("provinciaid")
            cboProvincia_Validated(cboProvincia, System.EventArgs.Empty)

            cboDistrito.Value = dtRow("distritoid")
            cboDistritoJ.Value = dtRow("distritoid")
        Next

        If Agregar_Items_Direccion(dtDireccion) Then

        End If
        If Agregar_Items_Telefono(dtTelefono) Then

        End If
        If Agregar_Items_EMail(dtEmail) Then

        End If
        If Agregar_Items_RedeS(dtRedes) Then

        End If

        Call TipoPersona()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkPJ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPJ.CheckedChanged
        If chkPJ.Checked Then
            chkPJ.Checked = True
            chkPN.BackColor = Color.White
            chkPJ.BackColor = Color.LightBlue
            utcPN_PJ.Tabs(1).Selected = True

        End If
    End Sub

    Private Sub TipoPersona()
        Dim lsel As UltraGridRow
        Dim vTipo As String = ""
        Dim vTipoX As Boolean = False, vTipoN As Boolean = False, vTipoJ As Boolean = False
        vNJ = False
        vSelRol = False
        If dgvCondicion.Rows.Count > 0 Then

            For Each lsel In dgvCondicion.Rows
                If lsel.Band.Index = 0 Then
                    If CBool(lsel.Cells("sel").Text) Then
                        vTipo = lsel.Cells("tipo").Value
                        Select Case vTipo
                            Case "X"
                                vTipoX = True
                                vNJ = True
                                vSelRol = True
                                Exit For
                            Case "N"
                                vTipoN = True
                                vSelRol = True
                            Case "J"
                                vTipoJ = True
                                vSelRol = True
                        End Select
                    End If
                End If
            Next
        End If

        If vTipoX = True Then
            chkPN.Visible = True
            chkPJ.Visible = True
            chkPJ.BackColor = Color.White
            chkPN.BackColor = Color.LightBlue
            utcPN_PJ.Tabs(0).Selected = True
            'utcPN_PJ.Location = New Point(2, 37)
        ElseIf vTipoN And vTipoJ Then
            chkPN.Visible = True
            chkPJ.Visible = True
            chkPJ.BackColor = Color.White
            chkPN.BackColor = Color.LightBlue
            utcPN_PJ.Tabs(0).Selected = True
            'utcPN_PJ.Location = New Point(2, 37)
        ElseIf vTipoN And Not vTipoJ Then
            utcPN_PJ.Tabs(0).Selected = True
            'utcPN_PJ.Location = New Point(2, 5)
        ElseIf Not vTipoN And vTipoJ Then
            utcPN_PJ.Tabs(1).Selected = True
            'utcPN_PJ.Location = New Point(2, 5)
        Else
            utcPN_PJ.Tabs(0).Selected = True
            'utcPN_PJ.Location = New Point(2, 5)
        End If

    End Sub

    Private Sub dgvCondicion_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dgvCondicion.CellChange
        'Dim vTipo As String = "N"
        If e.Cell.IsActiveCell = True Then
            'vTipo = dgvCondicion.DisplayLayout.ActiveRow.Cells("tipo").Value
            Call TipoPersona()
        End If
    End Sub

    Private Sub dgvCondicion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvCondicion.InitializeLayout
        With dgvCondicion.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Header.Caption = "SEL"
            .Columns(1).Width = 40
            .Columns("nombre").Width = 160
            .Columns("nombre").CellActivation = Activation.NoEdit
            .Columns("imagen").Hidden = True
            .Columns("estructura").Hidden = True
            .Columns("tipo").Hidden = True
        End With
        'rolid,false as sel, nombre, imagen,estructura,tipo
        Me.dgvCondicion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Default
        'Me.dgvCondicion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub FrmPersonaEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Inicializa() 'Valida si es para rellenar en el formulario de persona juridica o natural
        If vPersonaId > 0 Then
            txtDNI.Enabled = False
            txtRUC_PN.Enabled = False
            txtRuc_PJ.Enabled = False

        End If
        Dim vTienePermiso As Boolean = False
        Call LibreriasFormularios.TienePermiso(GestionSeguridadManager.idUsuario, "persona-edit-name", vTienePermiso)
        If GestionSeguridadManager.sUsuario = "admin" Or vTienePermiso Then
            txtRazon_Social.ReadOnly = False
            txtApe_Pat.ReadOnly = False
            txtApe_Mat.ReadOnly = False
            TxtNombre.ReadOnly = False
        Else
            txtRazon_Social.ReadOnly = True
            txtApe_Pat.ReadOnly = True
            txtApe_Mat.ReadOnly = True
            TxtNombre.ReadOnly = True
        End If

    End Sub

    Private Sub FrmPersonaEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
        Call Inicializa()
        If Not bwDatos.IsBusy Then
            picAjax.Visible = True
            bwDatos.RunWorkerAsync()
        End If
    End Sub

    Private Sub cboDpto_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDpto.InitializeLayout
        'dptoid, departamento, provid, provincia, disid, distrito, dptopid, provdid
        With cboDpto.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Width = cboDpto.Width
            .Columns("provid").Hidden = True
            .Columns("provincia").Hidden = True
            .Columns("disid").Hidden = True
            .Columns("distrito").Hidden = True
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboDpto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDpto.Validated

        If cboDpto.ActiveRow Is Nothing Then
            If Not cboDpto.Text = "" Then
                cboDpto.Focus()
                cboProvincia.Text = ""
            End If
        Else
            Call ObtenerProvincia(cboDpto.Value, "")
        End If
    End Sub

    Private Sub cboDptoJ_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboDptoJ.InitializeLayout
        'dptoid, departamento, provid, provincia, disid, distrito, dptopid, provdid
        With cboDptoJ.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Width = cboDptoJ.Width
            .Columns("provid").Hidden = True
            .Columns("provincia").Hidden = True
            .Columns("disid").Hidden = True
            .Columns("distrito").Hidden = True
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboDptoJ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDptoJ.Validated
        If cboDptoJ.ActiveRow Is Nothing Then
            If Not cboDptoJ.Text = "" Then
                cboDptoJ.Focus()
                cboProvJ.Text = ""
            End If
        Else
            Call ObtenerProvincia(cboDptoJ.Value, "J")
        End If
    End Sub

    Private Sub cboDist_PJ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            chkPJ.Focus()
        End If
    End Sub


    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String
        If vSelRol Then
            If vNJ Then
                If chkPN.Checked = True Then
                    If Trim(txtDNI.Text) = "" Or Not txtDNI.Text.Length >= 8 Then
                        valido = False
                        ErrorProvider1.SetError(txtDNI, "DNI no válido")
                        camposConError.Add("DNI")
                    Else
                        ErrorProvider1.SetError(txtDNI, Nothing)
                    End If

                    If Trim(txtApe_Pat.Text) = "" Or txtApe_Mat.Text.Trim = "" Or TxtNombre.Text.Trim = "" Then
                        valido = False
                        ErrorProvider1.SetError(txtApe_Pat, "Debe tener datos personales")
                        camposConError.Add("DATOS")
                    Else
                        ErrorProvider1.SetError(txtApe_Pat, Nothing)
                    End If



                    If Not IsDate(cboNacimiento.Value) Then
                        valido = False
                        ErrorProvider1.SetError(cboNacimiento, "Fecha de nacimiento no válido")
                        camposConError.Add("FECHA")
                    Else
                        ErrorProvider1.SetError(cboNacimiento, Nothing)

                    End If
                    If txtDNI.Text.Length = 8 Then
                        If Not vDNIok And vPersonaId = 0 Then
                            valido = False
                            ErrorProvider1.SetError(txtDNI, "Falta Ingresar DNI ")
                            camposConError.Add("DNI")
                        Else
                            ErrorProvider1.SetError(txtDNI, Nothing)
                        End If
                    End If

                    If cboSexo.Text = "" Then
                        valido = False
                        ErrorProvider1.SetError(cboSexo, "Falta seleccionar sexo ")
                        camposConError.Add("SEXO")
                    Else
                        ErrorProvider1.SetError(cboSexo, Nothing)
                    End If

                    If cboEstadoCivil.Text = "" Then
                        valido = False
                        ErrorProvider1.SetError(cboEstadoCivil, "Falta seleccionar Estado Civil ")
                        camposConError.Add("EstadoCivil")
                    Else
                        ErrorProvider1.SetError(cboEstadoCivil, Nothing)
                    End If

                    If cboDistrito.Text = "" Then
                        valido = False
                        ErrorProvider1.SetError(cboDistrito, "Falta seleccionar Distrito ")
                        camposConError.Add("Distrito")
                    Else
                        ErrorProvider1.SetError(cboDistrito, Nothing)
                    End If

                Else 'Si no es persona natural
                    If Not txtRuc_PJ.TextLength >= 11 Then
                        valido = False
                        ErrorProvider1.SetError(txtRuc_PJ, "La cantidad de Dígitos del RUC debe ser mínimo 11")
                        camposConError.Add("RUC")
                    Else
                        ErrorProvider1.SetError(txtRuc_PJ, Nothing)
                    End If

                    If Not vRUCok And vPersonaId = 0 Then
                        valido = False
                        ErrorProvider1.SetError(txtRuc_PJ, "Falta Ingresar RUC ")
                        camposConError.Add("RUC")
                    Else
                        ErrorProvider1.SetError(txtRuc_PJ, Nothing)
                    End If

                    If Trim(txtRazon_Social.Text) = "" Then
                        valido = False
                        ErrorProvider1.SetError(txtRazon_Social, "Debe tener una Razón Social")
                        camposConError.Add("RAZONSSOCIAL")
                    Else
                        ErrorProvider1.SetError(txtRazon_Social, Nothing)
                    End If
                    If cboDistritoJ.Text = "" Then
                        valido = False
                        ErrorProvider1.SetError(cboDistritoJ, "Falta seleccionar Distrito ")
                        camposConError.Add("Distrito")
                    Else
                        ErrorProvider1.SetError(cboDistritoJ, Nothing)
                    End If
                End If
            Else

            End If
        Else
            valido = False
            ErrorProvider1.SetError(dgvCondicion, "Debe seleccionar un ROL")
            camposConError.Add("ROL")
        End If


        If Not valido Then
            lblError.Text = "Falta un valor en: "

            For Each campo In camposConError
                lblError.Text &= campo & ", "
            Next
            lblError.Text = lblError.Text.Substring(0, lblError.Text.Length - 2)
        End If
        Return valido
    End Function

    Private Function GrabarRegistroDoc() As Boolean

    Dim objP As New persona
    Dim dgvRw As UltraGridRow
    Dim fNac As String = "", ok As Long
    Dim varrphone As String = "null", varremail As String = "null", varrsocialmedia As String = "null"
    Dim varrrol As String = "null", varrdireccion As String = "null"
    Dim vTiene As Boolean

    Try

      fNac = LibreriasFormularios.Formato_Fecha(cboNacimiento.Value)

      With objP
        If vPersonaId > 0 Then
          .personaid = vPersonaId
        Else
          .personaid = 0
        End If

        .tipo = pTipoPer
        .nacimiento = fNac
        If chkPN.Checked Then
          .tipo = "N"

                    .titulo = txtTitulo.Text.Trim & ""
                    .ape_pat = txtApe_Pat.Text.Trim & ""
                    .ape_mat = txtApe_Mat.Text.Trim & ""
          .nombre = TxtNombre.Text.Trim
          .dni = txtDNI.Text.Trim & ""
          .pernat_ruc = txtRUC_PN.Text & ""
          .sexo = cboSexo.Value
          .est_civil = cboEstadoCivil.Value

          .direccion = txtDireccion.Text
          .nombre_comercial = txtNombre_Com.Text
          .distritoid = cboDistrito.Value
        Else
          .tipo = "J"
          .ruc = txtRuc_PJ.Text
          .raz_soc = txtRazon_Social.Text
          .direccion = txtDireccion_PJ.Text
          .nombre_comercial = txtNombre_Com_PJ.Text
          .distritoid = cboDistritoJ.Value
        End If
        .foto = ""

        .usuarioid = GestionSeguridadManager.idUsuario
        .ip = GestionSeguridadManager.miIP

        varrrol = ""
        'Almacenamos Los Roles
        vTiene = False
        For Each dgvRw In Me.dgvCondicion.Rows
          If dgvRw.Band.Index = 0 Then
            If dgvRw.Cells("sel").Value Then
              vTiene = True
              varrrol = varrrol & Str(dgvRw.Cells("rolid").Value).Trim & ","
            End If
          End If
        Next
        If vTiene Then
          varrrol = Mid(varrrol, 1, Len(varrrol) - 1)
          varrrol = "array[" & varrrol & "]"
        Else
          varrrol = "null"
        End If

        'Almacenamos Las Direcciones
        vTiene = False
        varrdireccion = ""
        For Each dgvRw In Me.dgvDireccion.Rows
          If dgvRw.Band.Index = 0 Then
            If Not dgvRw.Cells("sucursal").Value = "" And Not dgvRw.Cells("direccion").Value = "" Then
              vTiene = True
              varrdireccion = varrdireccion & "['" & Str(0) & "', '" &
                                       (dgvRw.Cells("sucursal").Value).Trim & "', '" &
                                       (dgvRw.Cells("direccion").Value).Trim & "'],"
            End If
          End If
        Next
        If vTiene Then
          varrdireccion = Mid(varrdireccion, 1, Len(varrdireccion) - 1)
          varrdireccion = "array[" & varrdireccion & "]"
        Else
          varrdireccion = "null"
        End If

        'Almacenamos los numeros de telefono
        vTiene = False
        varrphone = ""
        For Each dgvRw In Me.dgvTelefono.Rows
          If dgvRw.Band.Index = 0 Then
            If Not dgvRw.Cells("tipo").Text = "" Then
              If dgvRw.Cells("tipo").Value > 0 And Not dgvRw.Cells("numero").Value = "" Then
                vTiene = True
                varrphone = varrphone & "['" & Str(0) & "', '" &
                                         Str(dgvRw.Cells("tipo").Value).Trim & "', '" &
                                         (dgvRw.Cells("numero").Value).Trim & "','" &
                                         (dgvRw.Cells("detalle").Value).Trim & "','" &
                                         IIf(CBool(dgvRw.Cells("principal").Value), "1", "0") & "','" &
                                         IIf(CBool(dgvRw.Cells("publico").Value), "1", "0") & "'],"
              End If
            End If
          End If
        Next
        If vTiene Then
          varrphone = Mid(varrphone, 1, Len(varrphone) - 1)
          varrphone = "array[" & varrphone & "]"
        Else
          varrphone = "null"
        End If

        'Almacenamos los Correos 
        vTiene = False
        varremail = ""
        For Each dgvRw In Me.dgvEmail.Rows
          If dgvRw.Band.Index = 0 Then
            If Not dgvRw.Cells("tipo").Text = "" Then
              If dgvRw.Cells("tipo").Value > 0 And Not dgvRw.Cells("email").Value = "" Then
                vTiene = True
                varremail = varremail & "['" & Str(0) & "', '" &
                                            Str(dgvRw.Cells("tipo").Value).Trim & "', '" &
                                         (dgvRw.Cells("email").Value).Trim & "', '" &
                                         "0" & "','" &
                                         "0" & "'],"
              End If
            End If
          End If
        Next
        If vTiene Then
          varremail = Mid(varremail, 1, Len(varremail) - 1)
          varremail = "array[" & varremail & "]"
        Else
          varremail = "null"
        End If

        'Almacenamos las redes sociales
        vTiene = False
        varrsocialmedia = ""
        For Each dgvRw In Me.dgvRedes.Rows
          If dgvRw.Band.Index = 0 Then
            If Not dgvRw.Cells("tipo").Text = "" Then
              If dgvRw.Cells("tipo").Value > 0 And Not dgvRw.Cells("url").Value = "" Then
                vTiene = True
                varrsocialmedia = varrsocialmedia & "['" & Str(dgvRw.Cells("tipo").Value).Trim & "', '" &
                                            (dgvRw.Cells("url").Value).Trim & "'],"
              End If
            End If
          End If
        Next
        If vTiene Then
          varrsocialmedia = Mid(varrsocialmedia, 1, Len(varrsocialmedia) - 1)
          varrsocialmedia = "array[" & varrsocialmedia & "]"
        Else
          varrsocialmedia = "null"
        End If


      End With

      ok = personaManager.Actualizar(objP, varrphone, varremail, varrsocialmedia, varrrol, varrdireccion)

      If ok > 0 Then
        GrabarRegistroDoc = True
      End If
      objP = Nothing
    Catch ex As Exception
      GrabarRegistroDoc = False
      MsgBox(ex.Message)
    End Try
  End Function

  Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If GrabarRegistroDoc() Then
                    Me.Close()
                End If
            End If
        End If
    End Sub


    Public Sub Buscar_Persona(ByVal vTipo As String, ByVal vNumero As String)
        Dim objP As New persona
        objP = LibreriasFormularios.Datos_Persona(vTipo, vNumero)
        If Not objP Is Nothing Then
            If objP.personaid > 0 Then
                MessageBox.Show("Documento ya existe en la base datos", "AVISO", MessageBoxButtons.OK)
            Else

                If pTipoN_RUC And objP.tipo = "J" Then
                    MessageBox.Show("Es una persona Jurídica, debe ingresarlo en el tipo de persona juridica", "AVISO", MessageBoxButtons.OK)
                    txtRUC_PN.Text = ""
                    Exit Sub
                End If
                If objP.tipo = "N" And pTipoJ_RUC Then
                    MessageBox.Show("Es una persona Natural, debe ingresarlo en el tipo de persona Natrual con RUC", "AVISO", MessageBoxButtons.OK)
                    txtRuc_PJ.Text = ""
                    Exit Sub
                End If

                If objP.tipo = "N" Then

                    pTipoPer = objP.tipo
                    txtApe_Pat.Text = objP.ape_pat
                    txtApe_Mat.Text = objP.ape_mat
                    TxtNombre.Text = objP.nombre
                    If pTipoN_RUC Then
                        txtDNI.Text = objP.dni
                        txtRUC_PN.Text = objP.ruc
                        txtDireccion.Text = objP.direccion
                    End If


                    vDNIok = True
                Else

                    pTipoPer = objP.tipo
                    txtRazon_Social.Text = objP.raz_soc
                    txtDireccion_PJ.Text = objP.direccion
                    vRUCok = True
                End If
            End If
        Else
            'txtDNI.Focus()
        End If
        objP = Nothing
    End Sub

    Private Sub txtDNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
    'LibreriasFormularios.SoloNumeros(sender, e, txtDNI, False, False)

  End Sub

    Private Sub txtDNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDNI.Validated

        If vPersonaId = 0 Then
            txtApe_Pat.Text = ""
            txtApe_Mat.Text = ""
            TxtNombre.Text = ""
            vDNIok = False
            If txtDNI.Text.Length = 8 Then
                Call Buscar_Persona("DNI", txtDNI.Text)
            End If
        End If
    End Sub

    Private Sub txtRuc_PJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuc_PJ.KeyPress
        LibreriasFormularios.SoloNumeros(sender, e, txtRuc_PJ, False, False)
    End Sub

    Private Sub txtRuc_PJ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuc_PJ.Validated

        If vPersonaId = 0 Then
            vRUCok = False
            If txtRuc_PJ.Text.Length = 11 Then
                pTipoN_RUC = False
                pTipoJ_RUC = True
                Call Buscar_Persona("RUC", txtRuc_PJ.Text)
            End If
        End If
    End Sub

    Private Sub cboSexo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboSexo.InitializeLayout
        cboSexo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboSexo.DisplayLayout.Bands(0).Columns(1).Width = cboSexo.Width
    End Sub

    Private Sub cboEstadoCivil_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboEstadoCivil.InitializeLayout
        cboEstadoCivil.DisplayLayout.Bands(0).Columns(0).Hidden = True
        cboEstadoCivil.DisplayLayout.Bands(0).Columns(1).Width = cboEstadoCivil.Width
    End Sub

    Private Sub txtRUC_PN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRUC_PN.KeyPress
        LibreriasFormularios.SoloNumeros(sender, e, txtRUC_PN, False, False)
    End Sub

    Private Sub txtRUC_PN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUC_PN.Validated

        If vPersonaId = 0 Then
            vRUCok = False
            pTipoN_RUC = False
            If txtRUC_PN.Text.Length = 11 Then
                pTipoN_RUC = True
                Call Buscar_Persona("RUC", txtRUC_PN.Text)
                pTipoN_RUC = False
            End If

        End If
    End Sub

    Private Sub chkPN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPN.Click
        If chkPN.Checked = True Then

            chkPJ.BackColor = Color.White
            chkPN.BackColor = Color.LightBlue
            utcPN_PJ.Tabs(0).Selected = True

        End If
    End Sub

    Private Sub txtTelefono_Validated(sender As Object, e As EventArgs) Handles txtTelefono.Validated
        If txtTelefono.Text.Trim = "" Then
            txtTelefono.NullText = "Teléfono.."
        End If
    End Sub

    Private Sub txtComentarioTel_Validated(sender As Object, e As EventArgs) Handles txtComentarioTel.Validated
        txtComentarioTel.NullText = "Comentario"
    End Sub

    Private Sub dgvDireccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvDireccion.InitializeLayout
        With dgvDireccion.DisplayLayout.Bands(0)
            .Columns(0).Width = 100
            .Columns(1).Width = dgvDireccion.Width - 120
            .Columns(2).Hidden = True
        End With
    End Sub

    Public Function Agregar_Direccion() As Boolean
        Try
            Dim NwRow As DataRow
            If txtSucursal.Text = "" Then
                MessageBox.Show("Debe ingresar Sucursal", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            If txtDirecciones.Text = "" Then
                MessageBox.Show("Debe ingresar una dirección", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            'If vIDdir = 0 Then
            NwRow = DtLDireccion.NewRow
            vFila = vFila + 1
            NwRow.Item("personadireccionid") = vFila
            NwRow.Item("sucursal") = txtSucursal.Text.Trim
            NwRow.Item("direccion") = txtDirecciones.Text.Trim

            DtLDireccion.Rows.Add(NwRow)
            'vIDdir = 0
            'Else
            '    NwRow = DtLDireccion.Rows.Find(vFila)
            '    NwRow.Item("personadireccionid") = vFila
            '    NwRow.Item("sucursal") = txtSucursal.Text.Trim
            '    NwRow.Item("direccion") = txtDirecciones.Text.Trim
            '    DtLDireccion.AcceptChanges()
            '    DtLDireccion.Select()
            '    vIDdir = 0
            'End If
            txtSucursal.Text = ""
            txtDirecciones.Text = ""
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO")
            Return False
        End Try

    End Function

    Private Function Agregar_Items_Direccion(ByVal dtDireccion As DataTable) As Boolean
        Dim NwRow As DataRow, dtRow As DataRow
        Dim xAdd As Boolean = False

        For Each dtRow In dtDireccion.Rows
            vFila = vFila + 1
            If CSng(dtRow("personadireccionid").ToString) > 0 Then
                NwRow = DtLDireccion.NewRow
                NwRow.Item("sucursal") = dtRow("sucursal").ToString
                NwRow.Item("direccion") = dtRow("direccion").ToString
                NwRow.Item("personadireccionid") = dtRow("personadireccionid").ToString
                DtLDireccion.Rows.Add(NwRow)
                xAdd = True
            End If
        Next

        Return xAdd
    End Function

    Private Sub UltraButton3_Click(sender As Object, e As EventArgs) Handles btnAddDireccion.Click
        If Agregar_Direccion() Then

        End If
    End Sub

    Private Sub cboProvincia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboProvincia.InitializeLayout
        'dptoid, departamento, provid, provincia, disid, distrito, dptopid, provdid
        With cboProvincia.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Hidden = True
            .Columns("provid").Hidden = True
            .Columns("provincia").Width = cboProvincia.Width
            .Columns("disid").Hidden = True
            .Columns("distrito").Hidden = True
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboProvJ_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboProvJ.InitializeLayout
        'dptoid, departamento, provid, provincia, disid, distrito, dptopid, provdid
        With cboProvJ.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Hidden = True
            .Columns("provid").Hidden = True
            .Columns("provincia").Width = cboProvJ.Width
            .Columns("disid").Hidden = True
            .Columns("distrito").Hidden = True
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboDistrito_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles cboDistrito.InitializeLayout
        With cboDistrito.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Hidden = True
            .Columns("provid").Hidden = True
            .Columns("provincia").Hidden = True
            .Columns("disid").Hidden = True
            .Columns("distrito").Width = cboDistrito.Width
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboDistritoJ_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles cboDistritoJ.InitializeLayout
        With cboDistritoJ.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Hidden = True
            .Columns("provid").Hidden = True
            .Columns("provincia").Hidden = True
            .Columns("disid").Hidden = True
            .Columns("distrito").Width = cboDistritoJ.Width
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboProvincia_Validated(sender As Object, e As EventArgs) Handles cboProvincia.Validated
        If cboProvincia.ActiveRow Is Nothing Then
            If Not cboProvincia.Text = "" Then
                cboProvincia.Focus()
                cboDistrito.Text = ""
            End If
        Else
            Call ObtenerDistrito(cboProvincia.Value, "")
        End If
    End Sub

    Private Sub cboProvJ_Validated(sender As Object, e As EventArgs) Handles cboProvJ.Validated
        If cboProvJ.ActiveRow Is Nothing Then
            If Not cboProvJ.Text = "" Then
                cboProvJ.Focus()
                cboDistritoJ.Text = ""
            End If
        Else
            Call ObtenerDistrito(cboProvJ.Value, "J")
        End If
    End Sub

    Private Sub cboDistrito_KeyDown(sender As Object, e As KeyEventArgs) Handles cboDistrito.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGrabar.Focus()
        End If
    End Sub

    Private Sub cboDistritoJ_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboDistritoJ.InitializeLayout
        With cboDistritoJ.DisplayLayout.Bands(0)
            .Columns("dptoid").Hidden = True
            .Columns("departamento").Hidden = True
            .Columns("provid").Hidden = True
            .Columns("provincia").Hidden = True
            .Columns("disid").Hidden = True
            .Columns("distrito").Width = cboDistritoJ.Width
            .Columns("dptopid").Hidden = True
            .Columns("provdid").Hidden = True
        End With
    End Sub

    Private Sub cboDistritoJ_KeyDown(sender As Object, e As KeyEventArgs) Handles cboDistritoJ.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGrabar.Focus()
        End If
    End Sub

    Private Sub txtDirecciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirecciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Agregar_Direccion() Then

            End If
        End If
    End Sub



    Public Function Agregar_Telefono() As Boolean
        Try
            Dim NwRow As DataRow
            If txtTelefono.Text = "" Then
                MessageBox.Show("Debe ingresar Número de Teléfono", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            If cboTipo_Telefono.Text = "" Then
                MessageBox.Show("Debe ingresar un tipo de teléfono", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            'If vIDdir = 0 Then
            NwRow = dtLTelfono.NewRow
            vFila = vFila + 1
            NwRow.Item("codigo") = vFila
            NwRow.Item("tipotelefonoid") = cboTipo_Telefono.Value
            NwRow.Item("tipo") = cboTipo_Telefono.Value
            NwRow.Item("numero") = txtTelefono.Text
            NwRow.Item("detalle") = txtComentarioTel.Text & ""
            NwRow.Item("principal") = chkMain.Checked
            NwRow.Item("publico") = chkPublico.Checked

            dtLTelfono.Rows.Add(NwRow)
            'vIDdir = 0
            'Else
            '    NwRow = dtLTelfono.Rows.Find(vFila)
            '    NwRow.Item("tipotelefonoid") = cboTipo_Telefono.Value
            '    NwRow.Item("tipo") = cboTipo_Telefono.Text
            '    NwRow.Item("numero") = txtTelefono.Text
            '    NwRow.Item("detalle") = txtComentarioTel.Text & ""
            '    NwRow.Item("principal") = chkMain.Checked
            '    NwRow.Item("publico") = chkPublico.Checked
            '    NwRow.Item("requerido") = chkRequerido.Checked
            '    dtLTelfono.AcceptChanges()
            '    dtLTelfono.Select()
            '    vIDdir = 0
            'End If
            txtTelefono.Text = ""
            txtComentarioTel.Text = ""
            chkMain.Checked = False
            chkPublico.Checked = False
            chkRequerido.Checked = False
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO")
            Return False
        End Try

    End Function

    Private Function Agregar_Items_Telefono(ByVal vdtTelefono As DataTable) As Boolean
        Dim NwRow As DataRow, dtRow As DataRow
        Dim xAdd As Boolean = False

        For Each dtRow In vdtTelefono.Rows
            vFila = vFila + 1
            If CSng(dtRow("codigo").ToString) > 0 Then
                NwRow = dtLTelfono.NewRow
                NwRow.Item("codigo") = dtRow("codigo").ToString
                NwRow.Item("tipotelefonoid") = dtRow("tipotelefonoid").ToString
                NwRow.Item("tipo") = dtRow("tipotelefonoid").ToString
                NwRow.Item("numero") = dtRow("numero").ToString
                NwRow.Item("detalle") = dtRow("detalle").ToString & ""
                NwRow.Item("principal") = dtRow("main").ToString
                NwRow.Item("publico") = dtRow("publico").ToString
                dtLTelfono.Rows.Add(NwRow)
                xAdd = True
            End If
        Next

        Return xAdd
    End Function

    Private Sub btnAddTelefono_Click(sender As Object, e As EventArgs) Handles btnAddTelefono.Click
        If Agregar_Telefono() Then

        End If
    End Sub

    Private Sub dgvTelefono_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvTelefono.InitializeLayout
        With dgvTelefono.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Hidden = True
            .Columns(2).Width = 60
            .Columns(3).Width = 100
            .Columns(4).Width = 90
            .Columns(5).Width = 65
            .Columns(6).Width = 55
            .Columns("tipo").ValueList = DTpTipoTelefono
            .Columns("tipo").Style = ColumnStyle.DropDownList

        End With
    End Sub

    Private Sub cboTipo_Telefono_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboTipo_Telefono.InitializeLayout
        With cboTipo_Telefono.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboTipo_Telefono.Width
        End With

    End Sub

    Private Sub cboTipo_Mail_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboTipo_Mail.InitializeLayout
        With cboTipo_Mail.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboTipo_Mail.Width
        End With
    End Sub

    Private Sub cboTipo_Redes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles cboTipo_Redes.InitializeLayout
        With cboTipo_Redes.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboTipo_Redes.Width
        End With
    End Sub

    Private Sub DTpTipoTelefono_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles DTpTipoTelefono.InitializeLayout
        DTpTipoTelefono.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub uddTipoMail_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles uddTipoMail.InitializeLayout
        uddTipoMail.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub uddTipoRedSS_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles uddTipoRedSS.InitializeLayout
        uddTipoRedSS.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub dgvEmail_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvEmail.InitializeLayout
        With dgvEmail.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns("tipo").Width = 100
            .Columns("tipo").ValueList = uddTipoMail
            .Columns("tipo").Style = ColumnStyle.DropDownList
            .Columns("email").Width = dgvEmail.Width - 120
        End With
    End Sub

    Public Function Agregar_EMail() As Boolean
        Try
            Dim NwRow As DataRow
            If txtEMail.Text = "" Then
                MessageBox.Show("Debe ingresar una dirección de Correo", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            If cboTipo_Mail.Text = "" Then
                MessageBox.Show("Debe ingresar un tipo de Correo", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            'If vIDdir = 0 Then
            NwRow = dtLEmail.NewRow
            vFila = vFila + 1
            NwRow.Item("codigo") = vFila
            NwRow.Item("tipo") = cboTipo_Mail.Value
            NwRow.Item("email") = txtEMail.Text

            dtLEmail.Rows.Add(NwRow)
            'vIDdir = 0
            'Else
            '    NwRow = dtLTelfono.Rows.Find(vFila)
            'NwRow.Item("tipo") = cboTipo_Mail.Text
            'NwRow.Item("email") = txtEMail.Text
            '    dtLTelfono.AcceptChanges()
            '    dtLTelfono.Select()
            '    vIDdir = 0
            'End If
            txtEMail.Text = ""
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO")
            Return False
        End Try

    End Function

    Private Function Agregar_Items_EMail(ByVal vdtEMail As DataTable) As Boolean
        Dim NwRow As DataRow, dtRow As DataRow
        Dim xAdd As Boolean = False

        For Each dtRow In vdtEMail.Rows
            vFila = vFila + 1
            If CSng(dtRow("codigo").ToString) > 0 Then
                NwRow = dtLEmail.NewRow
                NwRow.Item("codigo") = dtRow("codigo").ToString
                NwRow.Item("tipo") = dtRow("tipoemailid").ToString
                NwRow.Item("email") = dtRow("email").ToString
                dtLEmail.Rows.Add(NwRow)
                xAdd = True
            End If
        Next

        Return xAdd
    End Function

    Private Sub btnEMail_Click(sender As Object, e As EventArgs) Handles btnEMail.Click
        If Agregar_EMail() Then

        End If
    End Sub

    Public Function Agregar_RedeS() As Boolean
        Try
            Dim NwRow As DataRow
            If txtLink.Text = "" Then
                MessageBox.Show("Debe ingresar una dirección de: " + cboTipo_Redes.Text, "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            If cboTipo_Redes.Text = "" Then
                MessageBox.Show("Debe ingresar un tipo de Tipo Redes", "VERIFICAR", MessageBoxButtons.OK)
                Exit Function
            End If
            'If vIDdir = 0 Then
            NwRow = dtLRedes.NewRow
            vFila = vFila + 1
            NwRow.Item("tiposocialmediaid") = vFila
            NwRow.Item("tipo") = cboTipo_Redes.Value
            NwRow.Item("url") = txtLink.Text

            dtLRedes.Rows.Add(NwRow)
            'vIDdir = 0
            'Else
            '    NwRow = dtLTelfono.Rows.Find(vFila)
            'NwRow.Item("tipo") = cboTipo_Mail.Text
            'NwRow.Item("email") = txtEMail.Text
            '    dtLTelfono.AcceptChanges()
            '    dtLTelfono.Select()
            '    vIDdir = 0
            'End If
            txtLink.Text = ""
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "AVISO")
            Return False
        End Try

    End Function

    Private Function Agregar_Items_RedeS(ByVal vdtRedeS As DataTable) As Boolean
        Dim NwRow As DataRow, dtRow As DataRow
        Dim xAdd As Boolean = False

        For Each dtRow In vdtRedeS.Rows
            vFila = vFila + 1
            If CSng(dtRow("tiposocialmediaid").ToString) > 0 Then
                NwRow = dtLRedes.NewRow
                NwRow.Item("tiposocialmediaid") = dtRow("tiposocialmediaid").ToString
                NwRow.Item("tipo") = dtRow("tiposocialmediaid").ToString
                NwRow.Item("url") = dtRow("url").ToString
                dtLRedes.Rows.Add(NwRow)
                xAdd = True
            End If
        Next

        Return xAdd
    End Function

    Private Sub btnRedes_Click(sender As Object, e As EventArgs) Handles btnRedes.Click
        If Agregar_RedeS() Then

        End If
    End Sub

    Private Sub dgvRedes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dgvRedes.InitializeLayout
        With dgvRedes.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns("tipo").Width = 100
            .Columns("tipo").ValueList = uddTipoRedSS
            .Columns("tipo").Style = ColumnStyle.DropDownList
            .Columns("url").Width = dgvRedes.Width - 120
        End With
    End Sub

    Private Sub txtDNI_ValueChanged(sender As Object, e As EventArgs) Handles txtDNI.ValueChanged

    End Sub

  Private Sub txtDNI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDNI.KeyDown
    ' ¿Se ha pulsado la combinación Ctrl+V?
    '
    Dim pegar As Boolean = (e.KeyData = (Keys.Control Or Keys.V))
    If (pegar) Then Return

    ' ¿Se ha pulsado Shift+Inicio?
    '
    Dim shiftInicio As Boolean = (e.KeyData = (Keys.Shift Or Keys.Home))
    If (shiftInicio) Then Return

    ' ¿Se ha pulsado Shift+Fin?
    '
    Dim shiftFin As Boolean = (e.KeyData = (Keys.Shift Or Keys.End))
    If (shiftFin) Then Return

    ' ¿Se ha pulsado Delete?
    '
    If (e.KeyData = Keys.Delete) Then Return

    ' ¿Se ha pulsado Retroceso?
    '
    If (e.KeyData = Keys.Back) Then Return

    ' Teclas de números permitidas.
    '
    Dim keyValue() As Integer = {48, 49, 50, 51, 52, 53, 54, 55, 56, 57,
                                     96, 97, 98, 99, 100, 101, 102, 103, 104, 105}

    Dim teclasPermitidas As Boolean = (keyValue.Contains(e.KeyValue))

    ' Si no es una tecla permitida, evitamos que se desencadene
    ' el evento KeyPress.
    '
    e.SuppressKeyPress = Not (teclasPermitidas)


  End Sub

End Class