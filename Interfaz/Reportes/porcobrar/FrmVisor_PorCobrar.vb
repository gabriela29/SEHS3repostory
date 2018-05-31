Imports System
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmVisor_PorCobrar
  Public pdtData As DataTable, pEmpresa As String, pLocal As String, pTitulo As String, pCondicion As String
  Public pRpt As String

  Public Function RptPorCobrar_Res(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                               ByVal vLocal As String, ByVal vDetalle As String, ByVal vAsistente As String) As Boolean
    Try
      Dim rpt As New rptPorCobrar_Res

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vDetalle)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vEmpresa)

      rpt.SetParameterValue(3, vAsistente)

      rpt.SetParameterValue(4, "")

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptPorCobrar_Res_Colp(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                        ByVal vLocal As String, ByVal vDetalle As String, ByVal vAsistente As String) As Boolean
    Try
      Dim rpt As New rptPorCobrar_Res_Colp

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vDetalle)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vEmpresa)

      rpt.SetParameterValue(3, vAsistente)

      rpt.SetParameterValue(4, "")

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptPorCobrar_Ndias(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                             ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptPorCobrar_Ndias

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vDetalle)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vEmpresa)

      rpt.SetParameterValue(3, GestionSeguridadManager.sNombeUS)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptPorCobrar_Res_GP(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                           ByVal vLocal As String, ByVal vDetalle As String, ByVal vCondi As String) As Boolean
    Try
      Dim rpt As New rptPorCobrar_Res_Gp

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vDetalle)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vEmpresa)

      rpt.SetParameterValue(3, vCondi)

      'rpt.SetParameterValue(4, "")

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptEstado_Cuenta(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                           ByVal vLocal As String, ByVal vDetalle As String, ByVal vAsistente As String) As Boolean
    Try
      Dim rpt As New rptEstadoCuenta

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptEstado_Cuenta2(ByVal dtTemp As DataTable,
                                    ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String, ByVal vCondi As String) As Boolean
    Try
      Dim rsCabecera As New DataTable
      Dim rsDetalle As New DataTable
      Dim rsPagos As New DataTable
      Dim rpt As New rptDetallePorcobrar, vUsuario As String = GestionSeguridadManager.sUsuario

      rpt.SetDataSource(dtTemp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      rpt.SetParameterValue(3, vCondi)
      rpt.SetParameterValue(4, vUsuario)



      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptResumen_CxC(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                       ByVal vLocal As String, ByVal vDetalle As String, ByVal vAsistente As String, ByVal vTotales As Boolean) As Boolean
    Try
      Dim rpt As New rptResumen_cxc

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      rpt.GroupHeaderSection1.SectionFormat.EnableSuppress = vTotales
      rpt.Section3.SectionFormat.EnableSuppress = vTotales
      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptSaldo_Prod_Fact(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                            ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptSaldoProductoFacturados

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      'rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptImp_Prod_Fact(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                        ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptProductoFacturadosImportes

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      'rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptPorCobrarN(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                    ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Try
      Dim rpt As New rptPorCobrarN

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vDetalle)
      'rpt.SetParameterValue(3, GestionSeguridadManager.sUsuario)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptProvision_PorCobrar(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                         ByVal vLocal As String, ByVal vSubTitulo As String, ByVal vCondicion As String) As Boolean
    Try
      Dim rpt As New rptCastigo_PorCobrar

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, vSubTitulo)
      rpt.SetParameterValue(3, vCondicion)

      'rpt.SetParameterValue(3, GestionSeguridadManager.sNombeUS)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptProvision_PorCobrar_Saldo() As Boolean
    Try
      Dim rpt As New rptSaldo_Porcobrar

      rpt.SetDataSource(pdtData)

      rpt.SetParameterValue(0, pEmpresa)
      rpt.SetParameterValue(1, pLocal)
      rpt.SetParameterValue(2, pTitulo)
      rpt.SetParameterValue(3, pCondicion)

      'rpt.SetParameterValue(3, GestionSeguridadManager.sNombeUS)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Public Function RptPorcobrar_Provision_Cast() As Boolean
    Try
      Dim rpt As New rptPorcobrarPorvCast

      rpt.SetDataSource(pdtData)

      rpt.SetParameterValue(2, pEmpresa)
      rpt.SetParameterValue(1, pLocal)
      rpt.SetParameterValue(0, pTitulo)
      'rpt.SetParameterValue(3, pCondicion)

      'rpt.SetParameterValue(3, GestionSeguridadManager.sNombeUS)

      cvCompras.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  Private Sub FrmVisor_PorCobrar_Load(sender As Object, e As EventArgs) Handles Me.Load
    If pRpt = "PSP" Then
      Call RptProvision_PorCobrar_Saldo()
    ElseIf pRpt = "DPC" Then
      Call RptPorcobrar_Provision_Cast()
    End If
  End Sub
End Class