
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmTipo_BonificionEdit

    Public pCodigo As Integer, pAlmacenid As Integer, pAlmacen As String


    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String


        If Trim(txtNombre.Text) = "" Then
            valido = False
            ErrorProvider1.SetError(txtNombre, "Falta Ingresar Destino")
            camposConError.Add("txtDestino")
        Else
            ErrorProvider1.SetError(txtNombre, Nothing)
        End If

        If IsDate(cboDesde.Value) Then
            If Date.Parse(cboDesde.Value) > Date.Parse(cboHasta.Value) Then
                valido = False
                ErrorProvider1.SetError(cboDesde, "El rango de fecha no es válido")
                camposConError.Add("FECHAS")
            Else
                ErrorProvider1.SetError(cboDesde, Nothing)
            End If
        Else
            valido = False
            ErrorProvider1.SetError(cboDesde, "No es una fecha válida")
            camposConError.Add("DESDE")
        End If

        If IsDate(cboHasta.Value) Then
            If Date.Parse(cboDesde.Value) > Date.Parse(cboHasta.Value) Then
                valido = False
                ErrorProvider1.SetError(cboDesde, "El rango de fecha no es válido")
                camposConError.Add("FECHAS")
            Else
                ErrorProvider1.SetError(cboDesde, Nothing)
            End If
        Else
            valido = False
            ErrorProvider1.SetError(cboDesde, "No es una fecha válida")
            camposConError.Add("HASTA")
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
        Dim Objeto As New bonificacion_tipo
        Try
            With Objeto
                .boniftipoid = pCodigo
                .almacenid = pAlmacenid
                .nombre = txtNombre.Text.Trim
                .desde = LibreriasFormularios.Formato_Fecha(cboDesde.Value)
                .hasta = LibreriasFormularios.Formato_Fecha(cboHasta.Value)
                .estado = ChkEstado.Checked

            End With

            If bonificacion_tipoManager.Grabar(Objeto) > 0 Then
                Me.Close()
            End If
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub Mostrar_Registro()
        Dim ojbDB As New bonificacion_tipo
        ojbDB = bonificacion_tipoManager.GetItem(pCodigo)
        If Not ojbDB Is Nothing Then

            txtNombre.Text = ojbDB.nombre
            cboDesde.Value = ojbDB.desde
            cboHasta.Value = ojbDB.hasta
            ChkEstado.Checked = Boolean.Parse(ojbDB.estado)
        End If
        ojbDB = Nothing

    End Sub

    Private Sub FrmTipo_BonificionEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub FrmTipo_BonificionEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub


    Private Sub FrmTipo_BonificionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAlmacen.Text = pAlmacen

        If pCodigo > 0 Then
            Call Mostrar_Registro()
        Else
            txtNombre.Text = ""
            cboDesde.Value = Now.Date
            cboHasta.Value = Now.Date
            ChkEstado.Checked = True
        End If
    End Sub
End Class