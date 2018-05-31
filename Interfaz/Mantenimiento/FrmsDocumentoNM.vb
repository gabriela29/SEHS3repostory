
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmsDocumentoNM
    Dim codigo As Integer, vNombre, vSigno, vAbrev, vCod_Conta As String
    Public id_tipoDoc As Integer

    Public ModoVentanaFlotante As Boolean


    Public Function Agregar() As Boolean
        Dim Objeto As New documento
        Try
            With Objeto
                .codigo = -1
                .nombre = vnombre
                .signo = vsigno
                .nombre_corto = vabrev
                .codigo_contable = vcod_conta
            End With

            documentoManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Modificar() As Boolean
        Dim Objeto As New documento
        Try
            With Objeto
                .codigo = codigo
                .nombre = vnombre
                .signo = vsigno
                .nombre_corto = vabrev
                .codigo_contable = vcod_conta
            End With
            documentoManager.Grabar(Objeto)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If MessageBox.Show("¿Desea grabar los datos?", "D'SIAM", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If EnVariables() Then
                    If Trim(Me.LblCodigo.Text) = "" Then
                        Call Agregar()
                    Else
                        Call Modificar()
                    End If
                End If
                'Call FrmSeriesDocumento.ListarCondicion("")
                Me.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function EnVariables() As Boolean
        Try
            If Not Trim(LblCodigo.Text) = "" Then
                codigo = CInt(LblCodigo.Text)
            End If
            vnombre = Me.TxtNombre.Text
            vsigno = Me.cboSigno.Value
            vabrev = Me.txtAbrev.Text
            vcod_conta = Me.txtCod_Conta.Text.Trim
            EnVariables = True
        Catch ex As Exception
            MsgBox(ex.Message)
            EnVariables = False
        End Try
    End Function

    Public Function LimpiarControles() As Boolean
        Me.LblCodigo.Text = ""
        Me.txtAbrev.Text = ""        
        id_tipoDoc = 0
        Me.TxtNombre.Text = ""
        Me.cboSigno.Text = ""
        Me.txtAbrev.Text = ""
        Me.txtCod_Conta.Text = ""

    End Function

    Private Sub llenar_combos()
        Try
            Dim opcionesv(2) As String, opciones(2) As String
            opcionesv(0) = "+"
            opcionesv(1) = "-"
            opciones(0) = "Positivo"
            opciones(1) = "Negativo"
            cboSigno.DataSource = Nothing
            cboSigno.DataSource = DosOpcionesManager.GetList("Opciones", opcionesv, opciones)
            Me.cboSigno.DataBind()
            cboSigno.ValueMember = "Opcionesv"
            cboSigno.DisplayMember = "Opciones"
            If Not vSigno = "" Then
                cboSigno.Value = vSigno
            Else
                cboSigno.SelectedRow = cboSigno.GetRow(UltraWinGrid.ChildRow.First)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSeriesDocumentoNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub FrmSeriesDocumentoNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_combos()
    End Sub

    Private Sub cboSigno_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboSigno.InitializeLayout
        With cboSigno.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboSigno.Width
        End With
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
End Class