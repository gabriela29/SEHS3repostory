Public Class FrmVisorGerencialCrystal
  Public pdtData As DataTable, pEmpresa As String, pLocal As String, pTitulo As String, pCondicion As String
  Public pRpt As String
  Private Sub FrmVisorGerencialCrystal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    If e.KeyCode = Keys.Escape Then
      Me.Close()
      MDIMenu.RadDock1.DocumentManager.ActiveDocument.Close()
    End If
  End Sub

  Private Sub FrmVisorGerencialCrystal_Load(sender As Object, e As EventArgs) Handles Me.Load
    If pRpt = "ER" Then
      Call RptEstado_Resultado(False)
    ElseIf pRpt = "PM" Then
      Call RptProducto_Movimiento(False)
    ElseIf pRpt = "NDIASPRODUCTO" Then
      Call RptProducto_FechUltimaComp(False)
    ElseIf pRpt = "listaPagosColportaje" Then
      Call RptListado_Pago_Colportaje(False)
    End If
  End Sub

  Public Function RptEstado_Resultado(ByVal vRes As Boolean) As Boolean
    Dim Report As New rptEstadoResultados

    Report.SetDataSource(pdtData)

    Report.SetParameterValue(0, pEmpresa)
    Report.SetParameterValue(1, pLocal)
    Report.SetParameterValue(2, pTitulo)
    Report.SetParameterValue(3, "")
    'If vRes Then
    '  Report.Section3.SectionFormat.EnableSuppress = True
    'End If

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crv1.ReportSource = Report
  End Function

  Public Function RptProducto_Movimiento(ByVal vRes As Boolean) As Boolean
    Dim Report As New rptProducto_Movimiento

    Report.SetDataSource(pdtData)

    Report.SetParameterValue(0, pEmpresa)
    Report.SetParameterValue(1, pLocal)
    Report.SetParameterValue(2, pTitulo)
    Report.SetParameterValue(3, pCondicion)
    'If vRes Then
    '  Report.Section3.SectionFormat.EnableSuppress = True
    'End If

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crv1.ReportSource = Report
  End Function

  Public Function RptProducto_FechUltimaComp(ByVal vRes As Boolean) As Boolean
    Dim Report As New rptNDiasCompraProd

    Report.SetDataSource(pdtData)

    Report.SetParameterValue(0, pEmpresa)
    Report.SetParameterValue(1, pLocal)
    Report.SetParameterValue(2, pTitulo)
    Report.SetParameterValue(3, pCondicion)
    'If vRes Then
    '  Report.Section3.SectionFormat.EnableSuppress = True
    'End If

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crv1.ReportSource = Report
  End Function

  Public Function RptListado_Pago_Colportaje(ByVal vRes As Boolean) As Boolean
    Dim Report As New rptPagosColportaje

    Report.SetDataSource(pdtData)

    Report.SetParameterValue(0, pEmpresa)
    Report.SetParameterValue(1, pLocal)
    Report.SetParameterValue(2, pTitulo)
    Report.SetParameterValue(3, pCondicion)
    'If vRes Then
    '  Report.Section3.SectionFormat.EnableSuppress = True
    'End If

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.crv1.ReportSource = Report
  End Function

End Class