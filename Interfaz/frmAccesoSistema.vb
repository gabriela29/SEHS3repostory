Option Explicit On
'Imports System.Configuration
Imports System
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class frmAccesoSistema
  Dim veces As Integer = 0, Termina As Boolean = False, pDato As String = ""

  Private Sub txtClave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    If e.KeyCode = Keys.Enter Then
    End If
  End Sub

  Private Sub CmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSalir.Click
    'MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
    'End
    Me.Close()
    'Global.System.Windows.Forms.Application.Exit()
  End Sub

  Public Function ValidarUs() As Boolean
    ValidarUs = True
    'Dim configurationAppSettings As New System.Configuration.AppSettingsReader
    If veces <= 3 Then
      Dim objPersonal As New clave
      'Dim objPersonal As Long = 0
      'Dim DtR As DataRow
      'objPersonal.Usuario = Trim(txtUsuario.Text.Trim)
      'objPersonal.Clave = Trim(txtClave.Text.Trim)
      'objPersonal = personaManager.GetItem(txtUsuario.Text.Trim, txtClave.Text.Trim)
      objPersonal = ClaveManager.GetItemUs(txtUsuario.Text.Trim, txtClave.Text.Trim)
      If objPersonal Is Nothing Then
        MsgBox("La clave de ingreso no es correcta", MsgBoxStyle.Exclamation, "EMANAGER")
        txtClave.Text = ""
        veces = veces + 1
      Else
        With objPersonal
          GestionSeguridadManager.idUsuario = objPersonal.codigo
          GestionSeguridadManager.sUsuario = Trim(txtUsuario.Text)
          GestionSeguridadManager.sNombeUS = objPersonal.nombre
          'GestionSeguridadManager.Serie = CType(configurationAppSettings.GetValue("SERIEDOC", GetType(System.Int32)), Integer) '.SerieDoc                    
          GestionSeguridadManager.NombrePC = My.Computer.Name
          GestionSeguridadManager.miIP = My.Computer.Name 'GestionSeguridad.getIp()
        End With

        objPersonal = Nothing
        'Call IniciaParam()
        Dim dtMenu As New DataTable, dtUnidad As New DataTable, dtAlmacen As New DataTable, dtPermisos As New DataTable
        Dim dtperdoc As New DataTable, dtplan As New DataTable, dtctacte As New DataTable, dtconf As New DataTable

        If GestionSeguridadManager.idUsuario > 0 Then
          If cursoresManager.Inicializa_Windows(GestionSeguridadManager.idUsuario,
                                                          dtMenu, dtUnidad,
                                                          dtAlmacen, dtPermisos,
                                                          dtperdoc, dtplan, dtctacte, dtconf) Then
            GestionTablas.dtMenu = dtMenu
            GestionTablas.dtUnidad = dtUnidad
            GestionTablas.dtAlmacen = dtAlmacen
            GestionTablas.dtPermisos = dtPermisos
            GestionTablas.dtperdoc = dtperdoc
            GestionTablas.dtplan = dtplan
            GestionTablas.dtctacte = dtctacte
            GestionTablas.dtconf = dtconf

            Call Asignar_Conf()

          End If

            Termina = True
          Me.Close()
          MDIMenu.Show()
        End If
        objPersonal = Nothing
      End If
      If veces = 3 Then

        Me.Close()
      End If
    End If

  End Function

  Private Sub Asignar_Conf()

    Call LibreriasFormularios.Asignar_Configuracion("GENERAL", 3, "valor_numeric", pDato)
    If Single.Parse(pDato) > 0 Then
      Configuracion.pIGV = Single.Parse(pDato)
    Else
      Configuracion.pIGV = 18
    End If

    Call LibreriasFormularios.Asignar_Configuracion("MOVIMIENTO_BANCARIO", 45, "valor_text", pDato)
    If Not pDato.Trim = "" Then
      Configuracion.pNom_Moneda = pDato.Trim
    Else
      Configuracion.pNom_Moneda = "SOLES"
    End If

    Call LibreriasFormularios.Asignar_Configuracion("GENERAL", 7, "valor_numeric", pDato)
    If Single.Parse(pDato) > 0 Then
      Configuracion.pLimiteRH = Single.Parse(pDato)
    Else
      Configuracion.pLimiteRH = 1700
    End If

  End Sub

  Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
    If Me.txtUsuario.Text.Trim = "" Then
      MessageBox.Show("Debe Ingresar un Usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If
    If Me.txtClave.Text.Trim = "" Then
      MessageBox.Show("Debe Ingresar una clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    Call ValidarUs()
  End Sub

  Private Sub frmAccesoSistema_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    If Not GestionSeguridadManager.idUsuario > 0 Then
      'Me.Close()
      MDIMenu.Close()
      'End
    End If
  End Sub

  Private Sub frmAccesoSistema_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If e.KeyChar = Chr(Keys.Enter) Then
      SendKeys.Send("{tab}")
    End If
  End Sub

  Private Sub txtClave_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtClave.KeyDown
    If e.KeyCode = Keys.Enter Then
      If Me.txtUsuario.Text.Trim = "" Then
        MessageBox.Show("Debe Ingresar un Usuario", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If
      If Me.txtClave.Text.Trim = "" Then
        MessageBox.Show("Debe Ingresar una clave", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      Call ValidarUs()
    End If
  End Sub


  Public Shared Function encode(ByVal str As String) As String
    'supply True as the construction parameter to indicate
    'that you wanted the class to emit BOM (Byte Order Mark)
    'NOTE: this BOM value is the indicator of a UTF-8 string
    Dim utf8Encoding As New System.Text.UTF8Encoding(True)
    Dim encodedString() As Byte

    encodedString = utf8Encoding.GetBytes(str)

    Return utf8Encoding.GetString(encodedString)
  End Function

  Public Sub Encodic()
    Dim utf_8 As System.Text.Encoding = System.Text.Encoding.UTF8


    Dim s_unicode As String = "abcéabc"


    Dim utf8Bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(s_unicode)





    Dim s_unicode2 As String = System.Text.Encoding.UTF8.GetString(utf8Bytes)



    MessageBox.Show(s_unicode2)
  End Sub

End Class