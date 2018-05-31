
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmEntidad

    Private Sub FrmEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmEntidad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With cboUnidad
            .DataSource = Nothing
            .DataSource = GestionTablas.dtUnidad
            .DataBind()
            .ValueMember = "unidadnegocioid"
            .DisplayMember = "unidad"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
            End If

        End With


    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cboUnidad_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnidad.InitializeLayout
        With cboUnidad.DisplayLayout.Bands(0)
            .Columns("empresaid").Hidden = True
            .Columns("empresa").Hidden = True
            .Columns("ruc").Hidden = True
            .Columns("direccion").Hidden = True
            .Columns("url").Hidden = True
            .Columns("unidadnegocioid").Hidden = True
            .Columns("unidad").Width = cboUnidad.Width
            .Columns("telefono").Hidden = True
            .Columns("entidad").Hidden = True
        End With
    End Sub

    Private Sub cboUnidad_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUnidad.ValueChanged
        If Not cboUnidad.DataSource Is Nothing Then            
            GestionSeguridadManager.gUnidadId = cboUnidad.ActiveRow.Cells("unidadnegocioid").Value
            GestionSeguridadManager.gUnidad = cboUnidad.ActiveRow.Cells("unidad").Value
            GestionSeguridadManager.gEntidad = cboUnidad.ActiveRow.Cells("entidad").Value
            GestionSeguridadManager.gEmpresaId = cboUnidad.ActiveRow.Cells("empresaid").Value
            GestionSeguridadManager.gEmpresa = cboUnidad.ActiveRow.Cells("empresa").Value
            GestionSeguridadManager.gRUCEmp = cboUnidad.ActiveRow.Cells("ruc").Value
            GestionSeguridadManager.Servidor = cboUnidad.ActiveRow.Cells("url").Value
            Call Permisos_Almacen()
        End If
    End Sub
    Private Sub Permisos_Almacen()
        Dim FilterP As String = "unidadnegocioid = " & GestionSeguridadManager.gUnidadId
        Dim dvP As DataView
        If Not GestionTablas.dtAlmacen Is Nothing Then
            dvP = New DataView(GestionTablas.dtAlmacen, FilterP, "", DataViewRowState.CurrentRows)
            GestionTablas.dtFAlmacen = dvP
        Else
            dvP = Nothing
        End If
    End Sub

End Class