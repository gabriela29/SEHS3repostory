

Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmSeriesDocumentoNM
    Dim codigo As Integer, cod_Emp As Integer, cod_tipo_doc As Integer, serie As String, NroDoc As Integer, estado As Boolean
    Public id_almacen, id_tipoDoc As Integer

    Public ModoVentanaFlotante As Boolean


    Public Function Agregar() As Boolean
        Dim Objeto As New serie
        Try
            With Objeto
                .codigo = -1
                .codigo_emp = cod_Emp
                .codigo_doc = cod_tipo_doc
                .serie = serie
                .correlativo = NroDoc
                .estado = estado
            End With

            serieManager.Grabar(Objeto)
            'MessageBox.Show(Objeto.idtipodocid)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function Modificar() As Boolean
        Dim Objeto As New serie
        Try
            With Objeto
                .codigo = codigo
                .codigo_emp = cod_Emp
                .codigo_doc = cod_tipo_doc
                .serie = serie
                .correlativo = NroDoc
                .estado = estado
            End With
            serieManager.Grabar(Objeto)
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
                Call FrmSeriesDocumento.ListarCondicion("")
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
            cod_Emp = cboEmpresa.Value
            cod_tipo_doc = Me.cboTipoDoc.Value
            serie = Me.txtSerie.Text
            NroDoc = Me.txtNroDoc.Text.Trim
            estado = CBool(Me.ChkEstado.CheckState)
            EnVariables = True
        Catch ex As Exception
            MsgBox(ex.Message)
            EnVariables = False
        End Try
    End Function

    Public Function LimpiarControles() As Boolean
        Me.LblCodigo.Text = ""
        Me.txtSerie.Text = ""
        id_almacen = 0
        id_tipoDoc = 0
        Me.cboEmpresa.Text = ""
        Me.cboTipoDoc.Text = ""
        Me.txtNroDoc.Text = ""
        Me.ChkEstado.Checked = True
    End Function

    Private Sub llenar_combos()
        Try
            Me.cboTipoDoc.DataSource = documentoManager.GetList("%%")
            Me.cboTipoDoc.DataBind()
            Me.cboTipoDoc.ValueMember = "documentoid"
            Me.cboTipoDoc.DisplayMember = "nombre"
            Me.cboTipoDoc.MinDropDownItems = 2
            Me.cboTipoDoc.MaxDropDownItems = 4
            If id_tipoDoc > 0 Then
                cboTipoDoc.Value = id_tipoDoc
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

    Private Sub cboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboEmpresa.InitializeLayout
        With cboEmpresa.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 260
            .Columns(2).Width = 160
            '.Columns(3).Hidden = True
            '.Columns(4).Hidden = True
            '.Columns(5).Hidden = True
        End With
    End Sub

    Private Sub cboAlmacen_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpresa.Validated
        If cboEmpresa.ActiveRow Is Nothing Then
            If Not cboEmpresa.Text = "" Then
                cboEmpresa.Focus()
            End If
        End If
    End Sub

    Private Sub cboTipoDoc_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboTipoDoc.InitializeLayout
        With cboTipoDoc.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = 260
            .Columns(2).Hidden = True
            .Columns(3).Hidden = True
            .Columns(4).Hidden = True
        End With
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Me.Close()
    End Sub
End Class