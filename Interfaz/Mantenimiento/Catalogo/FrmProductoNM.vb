
Imports Infragistics.Win
Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmProductoNM
    Public pCodigo As Long, xNew As Boolean
    'Para los combos iniciales
    Public dtFamilia As DataTable, dtGrupo As DataTable, dtMedida As DataTable
    Private WithEvents popupFamilia As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupGrupo As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing
    Private WithEvents popupUM As ControlesPersonalizados.Components.Controls.GestorVentanaPopup = Nothing

    Private Sub llenar_Combos()
        Dim st As Boolean = False
        dtFamilia = New DataTable
        dtGrupo = New DataTable
        dtMedida = New DataTable


        Try
            st = productoManager.GetCombos_Cursor(dtFamilia, dtGrupo, dtMedida)

            With cboFamilia
                .DataSource = Nothing
                .DataSource = dtFamilia
                .DataBind()
                .ValueMember = "subcategoriaid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCOdigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

            With cboGrupo
                .DataSource = Nothing
                .DataSource = dtGrupo
                .DataBind()
                .ValueMember = "grupoid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCOdigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

            With cboUnidad_Medida
                .DataSource = Nothing
                .DataSource = dtMedida
                .DataBind()
                .ValueMember = "unidadmedidaid"
                .DisplayMember = "nombre"
                .MinDropDownItems = 2
                .MaxDropDownItems = 4
                If .Rows.Count > 0 Then
                    If pCOdigo = 0 Then
                        .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                    End If
                End If
            End With

        Catch ex As Exception
            st = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MostrarDatos(ByVal _id As Long)
        Dim objProd As New producto
        objProd = productoManager.GetItem(_id)
        If Not objProd Is Nothing Then
            With objProd
                Me.LblCodigo.Text = .ProductoId
                txtCodigo_Barras.Text = .Codigo_Barras
                txtNombre.Text = .Nombre_Producto
                txtPresentacion.Text = .Presentacion
                cboFamilia.Value = .SubCategoriaId
                cboGrupo.Value = .GrupoId
                cboUnidad_Medida.Value = .UnidadMedidaId
                txtPrecioVta.Text = Single.Parse(.Precio_VA)
                TxtPrecioVtaMin.Text = Single.Parse(.Precio_VB)
                ChkAfecto_IGV.Checked = CBool(.Afecto_Igv)
                chkExonerado.Checked = CBool(.Exonerado)

                txtEditorial.Text = .editorial
                txtEdicion.Text = .edicion
                txtPaginas.Text = Long.Parse(.paginas)
                txtAlto.Text = Long.Parse(.alto)
                txtAncho.Text = Long.Parse(.ancho)
                txtAutor.Text = .autor
            End With
        End If


        objProd = Nothing
    End Sub

    Private Sub FrmProductoNM_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call llenar_Combos()
        If pCOdigo > 0 Then
            Call MostrarDatos(pCOdigo)
        End If
    End Sub

    Private Sub FrmProductoNM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'If e.KeyChar = Chr(Keys.Enter) Then
        '    SendKeys.Send("{tab}")
        'End If
    End Sub

    Private Sub cboFamilia_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboFamilia.InitializeLayout
        With cboFamilia.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboFamilia.Width
        End With
    End Sub

    Private Sub cboGrupo_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboGrupo.InitializeLayout
        With cboGrupo.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboGrupo.Width
        End With
    End Sub

    Private Sub cboUnidad_Medida_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cboUnidad_Medida.InitializeLayout
        With cboUnidad_Medida.DisplayLayout.Bands(0)
            .Columns(0).Hidden = True
            .Columns(1).Width = cboUnidad_Medida.Width
        End With
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True
        Dim camposConError As New Specialized.StringCollection
        Dim campo As String

        If txtNombre.Text.Trim = "" Then
            valido = False
            ErrorProvider1.SetError(cboFamilia, "Debe Ingresar un nombre del producto")
            camposConError.Add("NOMBRE")
        Else
            ErrorProvider1.SetError(txtNombre, Nothing)
        End If

        If cboFamilia.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboFamilia, "Debe Seleccionar una familia Primero")
            camposConError.Add("FAMILIA")
        Else
            ErrorProvider1.SetError(cboFamilia, Nothing)
        End If


        If cboGrupo.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboGrupo, "Debe Seleccionar un Grupo Primero")
            camposConError.Add("GRUPO")
        Else
            ErrorProvider1.SetError(cboGrupo, Nothing)

        End If

        If cboUnidad_Medida.Text = "" Then
            valido = False
            ErrorProvider1.SetError(cboUnidad_Medida, "Falta Seleccionar unidad de medida")
            camposConError.Add("Unidad_Medida")
        Else
            ErrorProvider1.SetError(cboUnidad_Medida, Nothing)
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
        Dim vId As Long = 0
        If ValidarDatos() Then
            If MessageBox.Show("¿Está seguro de grabar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim objp As New producto
                Try
                    If pCOdigo = 0 Then
                        xNew = True
                    End If
                    With objp
                        If xNew = True Then
                            .ProductoId = -1
                        Else
                            .ProductoId = pCodigo
                        End If

                        objp.Nombre_Producto = txtNombre.Text.Trim
                        objp.Presentacion = txtPresentacion.Text.Trim & ""
                        objp.Precio_Compra = 0
                        objp.Precio_VA = Single.Parse(txtPrecioVta.Text)
                        objp.Precio_VB = Single.Parse(TxtPrecioVtaMin.Text)

                        objp.Stock_Minimo = 10
                        objp.Stock_Maximo = 50
                        objp.Codigo_Barras = txtCodigo_Barras.Text & ""
                        objp.Exonerado = chkExonerado.Checked
                        objp.Afecto_Igv = ChkAfecto_IGV.Checked
                        objp.SubCategoriaId = cboFamilia.Value
                        objp.GrupoId = cboGrupo.Value
                        objp.UnidadMedidaId = cboUnidad_Medida.Value

                    End With

                    Dim vArrLibro As String = "", vTienef As Boolean = False, vLibre As String = "", vEstado As Boolean = True
                    If Not txtEditorial.Text = "" Or Not txtAutor.Text = "" Or Not txtEdicion.Text = "" Or Not txtPaginas.Text = "" Then
                        vTienef = True
                        vArrLibro = vArrLibro & "['" & Trim(Str(0)) & "', '" & _
                                                    Trim(Me.txtEditorial.Text) & "','" & _
                                                    Trim(Str(0)) & "','" & _
                                                    Trim(txtAutor.Text) & "','" & _
                                                    Trim(txtEdicion.Text) & "','" & _
                                                    Trim(Str(txtPaginas.Text)) & "','" & _
                                                    Trim(Str(txtAncho.Text)) & "','" & _
                                                    Trim(Str(txtAlto.Text)) & "','" & _
                                                    Trim(vLibre) & "','" & _
                                                    Trim(vLibre) & "','" & _
                                                    Trim("true")  & "'],"
                    End If
                    If vTienef Then
                        vArrLibro = Mid(vArrLibro, 1, Len(vArrLibro) - 1)
                        vArrLibro = "array[" & vArrLibro & "]"
                    Else
                        vArrLibro = "null"
                    End If
                    'vEditorialid:=case when (myArr[vIndice][1] is null) or (myArr[vIndice][1]='') then 0 else myArr[vIndice][1]::integer end;
                    'vEditorial:=case when (myArr[vIndice][2] is null) or (myArr[vIndice][2]='') then '' else myArr[vIndice][2]::varchar end;
                    'vAutorid:=case when (myArr[vIndice][3] is null) or (myArr[vIndice][3]='') then 0 else myArr[vIndice][3]::integer end;
                    'vAutor:=case when (myArr[vIndice][4] is null) or (myArr[vIndice][4]='') then '' else myArr[vIndice][4]::varchar end;
                    'vEdicion:=case when (myArr[vIndice][5] is null) or (myArr[vIndice][5]='') then '' else myArr[vIndice][5]::varchar end;
                    'vPaginas:=case when (myArr[vIndice][6] is null) or (myArr[vIndice][6]='') then 0 else myArr[vIndice][6]::integer end;
                    'vAncho:=case when (myArr[vIndice][7] is null) or (myArr[vIndice][7]='') then 0 else myArr[vIndice][7]::integer end;
                    'vAlto:=case when (myArr[vIndice][8] is null) or (myArr[vIndice][8]='') then 0 else myArr[vIndice][8]::integer end;
                    'vImagen:=case when (myArr[vIndice][9] is null) or (myArr[vIndice][9]='') then 0 else myArr[vIndice][9]::integer end;
                    'vDescripcionL:=case when (myArr[vIndice][10] is null) or (myArr[vIndice][10]='') then '' else myArr[vIndice][10]::text end;
                    'vEstado:=case when (myArr[vIndice][11] is null) or (myArr[vIndice][11]='') then false else myArr[vIndice][11]::boolean end;	

                    If productoManager.Grabar(pCodigo, xNew, objp, vArrLibro) > 0 Then
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

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnAddFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFamilia.Click
        popupFamilia = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()



        Dim frm As FrmSubCategoriaNM = New FrmSubCategoriaNM()

        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = False
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
            .pCodigo = 0
            .pCodigo_Cat = 0
        End With
        Dim location As Point = Me.PointToScreen(New Point(Me.btnAddFamilia.Left, btnAddFamilia.Bottom))

        popupFamilia.ShowPopup(Me, frm, location)


    End Sub

    Private Sub popupFamilia_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupFamilia.PopupClosed
        Dim frm As FrmSubCategoriaNM = e.Popup

        With cboFamilia
            .DataSource = Nothing
            .DataSource = subcategoriaManager.GetList(0, "")
            .DataBind()
            .ValueMember = "subcategoriaid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                If frm.rCodigo > 0 Then
                    .Value = frm.rCodigo
                Else
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

        frm = Nothing
    End Sub

    Private Sub btnAddGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGrupo.Click
        popupGrupo = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()

        Dim frm As FrmGrupoNM = New FrmGrupoNM()

        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = False
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
            .pCodigo = 0
        End With

        Dim location As Point = Me.PointToScreen(New Point(Me.btnAddGrupo.Left, btnAddGrupo.Bottom))

        popupGrupo.ShowPopup(Me, frm, location)


    End Sub

    Private Sub popupGrupo_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupGrupo.PopupClosed
        Dim frm As FrmGrupoNM = e.Popup

        With cboGrupo
            .DataSource = Nothing
            .DataSource = grupoManager.GetList("")
            .DataBind()
            .ValueMember = "grupoid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                If frm.rCodigo > 0 Then
                    .Value = frm.rCodigo
                Else
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

        frm = Nothing
    End Sub

    Private Sub btnAddUM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUM.Click

        popupUM = New ControlesPersonalizados.Components.Controls.GestorVentanaPopup()



        Dim frm As FrmUnidad_MedidaNM = New FrmUnidad_MedidaNM()

        With frm
            .MaximizeBox = False
            .MinimizeBox = False
            .ControlBox = False
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .TopMost = True
            .Text = ""
            .ModoVentanaFlotante = True
            .pCodigo = 0
        End With

        Dim location As Point = Me.PointToScreen(New Point(Me.btnAddUM.Left, btnAddUM.Bottom))

        popupUM.ShowPopup(Me, frm, location)


    End Sub

    Private Sub popupUM_PopupClosed(ByVal sender As Object, ByVal e As ControlesPersonalizados.Components.Controls.PopupClosedEventArgs) Handles popupUM.PopupClosed
        Dim frm As FrmUnidad_MedidaNM = e.Popup

        With cboUnidad_Medida
            .DataSource = Nothing
            .DataSource = unidad_medidaManager.GetList("")
            .DataBind()
            .ValueMember = "unidadmedidaid"
            .DisplayMember = "nombre"
            .MinDropDownItems = 2
            .MaxDropDownItems = 4
            If .Rows.Count > 0 Then
                If frm.rCodigo > 0 Then
                    .Value = frm.rCodigo
                Else
                    .SelectedRow = .GetRow(UltraWinGrid.ChildRow.First)
                End If
            End If
        End With

        frm = Nothing
    End Sub

    Private Sub txtCodigo_Barras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo_Barras.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPresentacion.Focus()
        End If
    End Sub

    Private Sub txtPresentacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPresentacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboFamilia.Focus()
        End If
    End Sub

    Private Sub cboFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboGrupo.Focus()
        End If
    End Sub

    Private Sub cboGrupo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboGrupo.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboUnidad_Medida.Focus()
        End If
    End Sub

    Private Sub cboUnidad_Medida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUnidad_Medida.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPrecioVta.Focus()
        End If
    End Sub

    Private Sub txtPrecioVta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioVta.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtPrecioVtaMin.Focus()
        End If
    End Sub

    Private Sub TxtPrecioVtaMin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecioVtaMin.KeyDown
        If e.KeyCode = Keys.Enter Then
            ChkAfecto_IGV.Focus()
        End If
    End Sub

    Private Sub ChkAfecto_IGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkAfecto_IGV.KeyDown
        If e.KeyCode = Keys.Enter Then
            chkExonerado.Focus()
        End If
    End Sub

    Private Sub chkAfectoDzmo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkExonerado.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnGrabar.Focus()
        End If
    End Sub

   
End Class