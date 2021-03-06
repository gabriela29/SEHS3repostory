﻿Imports System.Reflection
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Public Class FrmVisor_Suscrip_Cristal
  Public Function RptDetalle_Deposito(ByVal vDepositoId As Long,
                                  ByVal vEmpresa As String, ByVal vLocal As String,
                                  ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vImage As String) As Boolean
    Dim Report As New rptDetalle_Deposito
    Dim opciones(1) As String
    Dim DtOb As New DataTable
    Dim DtImg As New DataTable

    DtOb = reportes_suscripcionManager.Detalle_Deposito(vDepositoId)
    DtImg = TempImg(vDepositoId, vImage)
    DtOb.TableName = "dtDetalle_Depositos"
    DtImg.TableName = "dtImagen"

    Report.Database.Tables("dtDetalle_Depositos").SetDataSource(DtOb)
    Report.Database.Tables("dtImagen").SetDataSource(DtImg)
    'Report.SetDataSource(DtImg)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report
  End Function

  Private Function TempImg(ByVal DepositoId As Long, ByVal vImage As String) As DataTable

    Dim dt As New DataTable
    Dim dr As DataRow
    Dim vImg As Image
    vImg = ObtenerImg(vImage)
    Try

      dt.Columns.Add(New DataColumn("depositoid", GetType(Single)))
      dt.Columns.Add(New DataColumn("imagen", GetType(Byte())))

      dr = dt.NewRow()
      dr("depositoid") = DepositoId
      dr("imagen") = ImageToByte(vImg)
      dt.Rows.Add(dr)


      'ds.Tables.Add(DtDepo)
      'ds.Tables(0).TableName = "dtDetalle_Depositos"
      'ds.Tables.Add(dt)
      'ds.Tables(1).TableName = "dtImagen"


      'Dim iDS As New dtSuscripciones
      'iDS.Merge(ds, False, System.Data.MissingSchemaAction.Ignore)
      Return dt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "AVISO")
      Return Nothing
    End Try
  End Function

  Public Function Editar_Campo(ByVal RsCab As DataTable, ByVal vImage As Image) As DataTable
    Dim cRow As DataRow
    Dim vImg As Byte()
    If ClsImpresiones.Existe_Campo("voucher", RsCab) Then
      For Each cRow In RsCab.Rows

        'cRow.Item("voucher") = ImageHelper.ImageToByteArray(vImage)
        'cRow.Item("porcobrar") = ImageHelper.ByteArrayToImage(vImage)
        'vImg = ImageHelper.ImageToByteArray(vImage)
        'cRow.Item("voucher") = ImageHelper.ByteArrayToImage(vImg)
        cRow.Item("voucher") = ImageToByte(vImage)
        RsCab.AcceptChanges()
        Exit For
      Next
    End If

    Return RsCab

  End Function

  Private Function ObtenerImg(pFile As String) As Image
    Dim vFile As String
    Dim img As Image
    Try
      If Not pFile.Trim = "" Then
        vFile = "http://sehs.org.pe/cms/upload/deposito/voucher/" & pFile
        Dim req As Net.HttpWebRequest = Net.HttpWebRequest.Create(vFile)
        'req.Credentials = New Net.NetworkCredential("usernamehere", "passwordhere")
        Dim res As Net.HttpWebResponse = DirectCast(req.GetResponse, Net.HttpWebResponse)
        img = New System.Drawing.Bitmap(res.GetResponseStream)
        res.Close()
      Else
        img = Global.Phoenix.My.Resources.Resources.Imagen_no_disponible
      End If

      'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
      Return img
    Catch ex As Exception
      img = Global.Phoenix.My.Resources.Resources.Imagen_no_disponible
      Return img
    End Try

  End Function

  Public Function ImageToByte(ByVal pImagen As Image) As Byte()
    Dim mImage() As Byte
    Try
      If Not IsNothing(pImagen) Then
        Dim ms As New System.IO.MemoryStream
        pImagen.Save(ms, pImagen.RawFormat)
        mImage = ms.GetBuffer
        ms.Close()
        Return mImage
      End If
    Catch

    End Try
  End Function

  Public Function RptDetalle_Suscripcion(ByVal vsuscripcionid As Long, ByVal viglesiaid As Long, ByVal vperiodo As Integer,
                                         ByVal vDesde As String, vHasta As String, ByVal vPersonaid As Long,
                                          ByVal vEmpresa As String, ByVal vLocal As String,
                                          ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptDetalle_Suscripcion
    Dim dtOb As New DataTable

    dtOb = reportes_suscripcionManager.Detalle_Suscripcion(vsuscripcionid, viglesiaid, vperiodo, vDesde, vHasta, vPersonaid)

    Report.SetDataSource(dtOb)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    'Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptSuscripcion_Ciclo(ByVal vdtData As DataTable,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vRes As Boolean) As Boolean
    Dim Report As New rptCiclo

    Report.SetDataSource(vdtData)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)
    If vRes Then
      Report.Section3.SectionFormat.EnableSuppress = True
    End If

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptDetalle_Suscripcion_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer,
                                                ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vsuscripcionid As Long,
                                                ByVal vEmpresa As String, ByVal vLocal As String, ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptDetalle_SuscripcionII
    Dim dtOb As New DataTable

    dtOb = reportes_suscripcionManager.Detalle_Suscripcion_Fact(vAlmacenid, viglesiaid, vperiodo, vPersonaid, vDM, vsuscripcionid)

    Report.SetDataSource(dtOb)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptDetalle_Pedido_Fact(ByVal vAlmacenid As Integer, ByVal viglesiaid As Long, ByVal vperiodo As Integer,
                                          ByVal vPersonaid As Long, ByVal vDM As Long, ByVal vPedidoid As Long, ByVal vTipoID As Integer,
                                          ByVal vEmpresa As String, ByVal vLocal As String, ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptDetalle_SuscripcionII
    Dim dtOb As New DataTable

    dtOb = reportes_suscripcionManager.Detalle_Pedido_Fact(vAlmacenid, viglesiaid, vperiodo, vPersonaid, vDM, vPedidoid, vTipoID)

    Report.SetDataSource(dtOb)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptSuscripcionxVendedor(ByVal vUnidadid As Integer, ByVal vIglesia As Integer,
                                            ByVal vDesde As String, vHasta As String, ByVal vVendedorid As Long,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vMes As Date, ByVal vOpcion As String,
                                            ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As Boolean
    Dim Report As New rptSuscripcionPorVendedor
    Dim dtOb As New DataTable

    dtOb = reportes_suscripcionManager.rptSuscripcionxVendedor(vUnidadid, vIglesia, vDesde, vHasta, vVendedorid, vOpcion, vMorosos, vMixto)

    Report.SetDataSource(dtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptSuscripcionxVendedorDP(ByVal vUnidadid As Integer, ByVal vIglesia As Integer,
                                            ByVal vDesde As String, vHasta As String, ByVal vVendedorid As Long,
                                            ByVal vEmpresa As String, ByVal vLocal As String,
                                            ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vMes As Date, ByVal vOpcion As String,
                                            ByVal vMorosos As Boolean, ByVal vMixto As Boolean) As Boolean
    Dim Report As New rptSuscripcionPorVendedorDP
    Dim dtOb As New DataTable

    dtOb = reportes_suscripcionManager.rptSuscripcionxVendedor(vUnidadid, vIglesia, vDesde, vHasta, vVendedorid, vOpcion, vMorosos, vMixto)

    Report.SetDataSource(dtOb)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptMaterial_Pedido(ByVal vDt As DataTable,
                                        ByVal vEmpresa As String, ByVal vLocal As String,
                                        ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptPedido_Material_Detalle

    Report.SetDataSource(vDt)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(4, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function RptClasificacion(ByVal dtTmp As DataTable, ByVal vEmpresa As String,
                                       ByVal vLocal As String, ByVal vCondicion As String) As Boolean
    Try
      Dim rpt As New rptClasificacion

      rpt.SetDataSource(dtTmp)

      rpt.SetParameterValue(0, vEmpresa)
      rpt.SetParameterValue(1, vLocal)
      rpt.SetParameterValue(2, "Clasificación de Materiales a Facturar")
      rpt.SetParameterValue(3, vCondicion)

      CrystalReportViewer1.ReportSource = rpt
    Catch ex As Exception
      MessageBox.Show(ex.Message, "VERIFICAR")
    End Try

  End Function

  '====== Lo que fallo con el reporte local 
  Public Function Pedidos_Periodo_Grupo_Iglesia(ByVal pDtData As DataTable,
                                                  ByVal vEmpresa As String, ByVal vLocal As String,
                                                  ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptResponsable_Iglesia

    Report.SetDataSource(pDtData)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

  Public Function Coordinador_Periodo_Grupo(ByVal pDtData As DataTable,
                                                ByVal vEmpresa As String, ByVal vLocal As String,
                                                ByVal vSubtitulo As String, ByVal vComentario As String) As Boolean
    Dim Report As New rptResponsables_Grupo

    Report.SetDataSource(pDtData)

    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.CrystalReportViewer1.ReportSource = Report


  End Function

End Class