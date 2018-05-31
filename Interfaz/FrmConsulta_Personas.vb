Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmConsulta_Personas
    Public Cod_Cat, Op_Sel As Integer
    Public ListadoRegistros As DataTable

    Private Sub FrmListadoClientes_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TxtApe_Pat.Focus()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        If Not bwListado.IsBusy Then
            picAjax.Visible = True
            bwListado.RunWorkerAsync()
        End If
    End Sub

    Private Sub TxtBusca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApe_Pat.KeyPress, TxtApe_Mat.KeyPress, TxtNombre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Not bwListado.IsBusy Then
                picAjax.Visible = True
                bwListado.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub dgvListado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvListado.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub dgvListado_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dgvListado.InitializeLayout
        With dgvListado.DisplayLayout.Bands(0)
            .Columns("personaid").Width = 20
            .Columns("personaid").Header.Caption = "ID"
            .Columns("tipo").Hidden = True
            .Columns("dni").Width = 70
            .Columns("ruc").Width = 80

            .Columns("nombre_persona").Header.Caption = "Razón Social / Nombres"
            .Columns("nombre_persona").Width = 250
            .Columns("telefono").Width = 80
            .Columns("rol").Width = 90
            .Columns("usuario").Width = 120
            .Columns("sexo").Hidden = True
            .Columns("foto").Hidden = True
            .Columns("direccion").Hidden = True
        End With
        
    End Sub

    Private Sub dgvListado_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dgvListado.InitializeRow
        If e.Row.Cells("sexo").Value = "M" Then
            e.Row.Cells("nombre_persona").Appearance.Image = ImageList1.Images(4)
        Else
            e.Row.Cells("nombre_persona").Appearance.Image = ImageList1.Images(5)
        End If
        'If e.Row.Cells("codigo_cat").Value = 3 Then 'Alumnos
        '    e.Row.Cells(6).Appearance.Image = ImageList1.Images(0)
        'ElseIf e.Row.Cells("codigo_cat").Value = 4 Then 'Empleado
        '    e.Row.Cells(6).Appearance.Image = ImageList1.Images(1)
        'ElseIf e.Row.Cells("codigo_cat").Value = 5 Then 'Padre
        '    e.Row.Cells(6).Appearance.Image = ImageList1.Images(2)
        'Else 'Otros
        '    e.Row.Cells(6).Appearance.Image = ImageList1.Images(3)
        'End If


    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim Frmt As New FrmPersonaEdit
        Frmt.ShowDialog()
    End Sub

    Private Sub bwListado_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwListado.DoWork
        CheckForIllegalCrossThreadCalls = False
        Dim xLimit As Integer
        xLimit = 0

        If IsNumeric(txtLimite.Text) Then
            xLimit = CInt(txtLimite.Text)
        End If

        Try
            ListadoRegistros = personaManager.GetList(Trim(Me.TxtApe_Pat.Text), Trim(TxtApe_Mat.Text), Trim(TxtNombre.Text), Op_Sel, _
                                                      "null", Integer.Parse(xLimit), 0)
            e.Result = ListadoRegistros
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bwListado_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwListado.RunWorkerCompleted
        dgvListado.DataSource = CType(e.Result, DataTable)
        If dgvListado.Rows.Count() > 0 Then
            dgvListado.Rows(0).Selected = True
            dgvListado.Focus()
        End If
        Me.lblRegistros.Text = ListadoRegistros.Rows.Count & " Registros"
        picAjax.Visible = False
    End Sub

    Private Sub FrmConsulta_Personas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LibreriasFormularios.formatear_grid(dgvListado)

    End Sub

    Private Sub TxtApe_Pat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApe_Pat.ValueChanged

    End Sub
End Class