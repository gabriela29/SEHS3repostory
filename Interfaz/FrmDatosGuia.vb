
Imports System
Imports System.IO
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.VisualBasic.DateAndTime

Public Class FrmDatosGuia
    Public pCodigo_Ven As Long
    Public vCodigo_Emp As Long = 0, vCodigo_Cho As Long = 0

    Public swNuevo As Boolean, zReniec As Boolean


    Private Sub FrmDatosGuia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Public Function LimpiarControles() As Boolean

        'pCodigo = 0
        'pCodigo_Per = 0
        txtPartida.Text = ""
        txtLlegada.Text = 0
        txtRUC_Trans.Text = ""
        txtTransportista.Text = ""
        txtDirecTransportista.Text = ""
        txtDNI.Text = ""
        txtApe_Pat.Text = ""
        txtApe_Mat.Text = ""
        txtNombre.Text = ""
        txtNroLicencia.Text = ""

    End Function

    Public Sub MostrarDatos(ByVal _id As Long)
        Dim objT As New datos_guia
        objT = datos_guiaManager.GetItem(_id)
        If Not objT Is Nothing Then
            With objT

                pCodigo_Ven = .codigo_ven
                vCodigo_Emp = .codigo_emp
                vCodigo_Cho = .codigo_cho
                txtFecha.Value = .fecha_trans
                txtPartida.Text = .desde
                txtLlegada.Text = .hasta
                txtRUC_Trans.Text = .ruc_trans
                txtTransportista.Text = .nombre_trans
                txtDirecTransportista.Text = .direccion_trans
                txtMarca.Text = .marca & ""
                txtPlaca.Text = .placa & ""

                txtDNI.Text = .dni_cho & ""
                txtApe_Pat.Text = .ape_pat & ""
                txtApe_Mat.Text = .ape_mat & ""
                txtNombre.Text = .nombre
                txtNroLicencia.Text = .nrolicencia

            End With
        End If
        objT = Nothing
    End Sub

    Private Sub FrmDatosGuia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call LimpiarControles()

        If pCodigo_Ven > 0 Then
            Call MostrarDatos(pCodigo_Ven)
        End If

        txtPartida.Focus()
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        If Not IsDate(txtFecha.Text) Then
            valido = False
            ErrorProvider1.SetError(txtFecha, "Debe Ingresar una fecha de Traslado")
            camposConError.Add("FECHA")
        Else
            ErrorProvider1.SetError(txtFecha, Nothing)
        End If

        If txtPartida.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(txtPartida, "Debe Ingresar un lugar de partida")
            camposConError.Add("PARTIDA")
        Else
            ErrorProvider1.SetError(txtPartida, Nothing)
        End If

        If txtLlegada.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtLlegada, "Debe ingresar un punto de LLegada")
            camposConError.Add("LLEGADA")
        Else
            ErrorProvider1.SetError(txtLlegada, Nothing)
        End If

        If Not txtRUC_Trans.Text.Length = 11 Then
            valido = False
            ErrorProvider1.SetError(txtRUC_Trans, "RUC no válido")
            camposConError.Add("RUC")
        Else
            ErrorProvider1.SetError(txtRUC_Trans, Nothing)
        End If

        If txtTransportista.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtTransportista, "Falta nombre Empresa transporte")
            camposConError.Add("TRANSPORTISTA")
        Else
            ErrorProvider1.SetError(txtTransportista, Nothing)
        End If

        If Not txtDNI.Text.Length = 8 Then
            valido = False
            ErrorProvider1.SetError(txtDNI, "DNI incorrecto")
            camposConError.Add("DNI")
        Else
            ErrorProvider1.SetError(txtDNI, Nothing)
        End If

        If txtApe_Pat.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtApe_Pat, "Falta Apellido Paterno del Chofer")
            camposConError.Add("APEPAT")
        Else
            ErrorProvider1.SetError(txtApe_Pat, Nothing)
        End If
        If txtApe_Mat.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtApe_Mat, "Falta Apellido Materno del Chofer")
            camposConError.Add("APEMAT")
        Else
            ErrorProvider1.SetError(txtApe_Mat, Nothing)
        End If

        If txtNombre.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtNombre, "Falta Nombre del Chofer")
            camposConError.Add("NOMBRE")
        Else
            ErrorProvider1.SetError(txtNombre, Nothing)
        End If

        If txtNroLicencia.Text = "" Then
            valido = False
            ErrorProvider1.SetError(txtNroLicencia, "Falta Nro Licencia del Chofer")
            camposConError.Add("LICENCIA")
        Else
            ErrorProvider1.SetError(txtNroLicencia, Nothing)
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

    Private Sub Btnayx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnayx.Click
        Dim vId As Long = 0
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim objp As New datos_guia
                Dim vFecha As String = ""
                Try
                    vFecha = LibreriasFormularios.Formato_Fecha(txtFecha.Text)
                    With objp
                        .codigo_ven = pCodigo_Ven
                        .fecha_trans = vFecha
                        .desde = txtPartida.Text.Trim
                        .hasta = txtLlegada.Text.Trim & ""
                        .codigo_emp = vCodigo_Emp
                        .marca = txtMarca.Text
                        .placa = txtPlaca.Text
                        .codigo_cho = vCodigo_Cho


                    End With

                    If datos_guiaManager.Grabar(objp) > 0 Then
                        FrmCatalogo.ListarCondicion()
                        Me.Close()
                    End If
                    'MessageBox.Show(Objeto.idtipodocid)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub txtRUC_Trans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRUC_Trans.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Consulta_DNI_SUNAT()
        End If

    End Sub

    Private Sub Consultar_Reniec()
        If IsNumeric(txtDNI.Text) Then
            If txtDNI.Text.Trim.Length = 8 Then
                Dim ObjPe As New persona
                ObjPe = personaManager.Datos_Persona_Basic("N", txtDNI.Text, 0)
                vCodigo_Cho = 0

                Me.txtApe_Pat.Text = ""
                Me.txtApe_Mat.Text = ""
                Me.txtNombre.Text = ""

                If Not ObjPe Is Nothing Then
                    vCodigo_Cho = ObjPe.personaid
                    Me.txtApe_Pat.Text = ObjPe.ape_pat
                    Me.txtApe_Mat.Text = ObjPe.ape_mat
                    Me.txtNombre.Text = ObjPe.nombre
                    Me.txtNroLicencia.Text = ObjPe.nrolicencia
                End If
            Else
                MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
                txtDNI.Focus()
            End If
        Else
            MessageBox.Show("El dato debe ser numérico", "AVISO", MessageBoxButtons.OK)
            txtDNI.Focus()
        End If
    End Sub

    Private Sub Consulta_DNI_SUNAT()
        Dim vProv As String = ""
        txtTransportista.Text = ""

        If Not Trim(txtRUC_Trans.Text) = "" Then
            If txtRUC_Trans.TextLength = 11 Then
                vCodigo_Emp = 0
                txtTransportista.Text = ""

                Dim ObjPJ As New persona
                ObjPJ = personaManager.Datos_Persona_Basic("J", txtRUC_Trans.Text, 0)
                If Not ObjPJ Is Nothing Then
                    vCodigo_Emp = ObjPJ.personaid
                    txtTransportista.Text = ObjPJ.raz_soc
                    txtDirecTransportista.Text = ObjPJ.direccion
                    'vRucOK = True
                End If
            Else
                MsgBox("Debe tener 11 dígitos el RUC", MsgBoxStyle.Exclamation, "AVISO")
                txtRUC_Trans.Focus()
            End If
        End If



    End Sub

    Private Sub txtDNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Consultar_Reniec()
        End If

    End Sub

    Private Sub txtDNI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.ValueChanged

    End Sub

    Private Sub txtRUC_Trans_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRUC_Trans.ValueChanged

    End Sub
End Class