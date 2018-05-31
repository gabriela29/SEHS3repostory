

Public Class frmVisor_PedidoWeb
  Public Function RptDetalle_Pedido(ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Dim rpt As New rptDetalle_Pedido_Web
    rpt.SetDataSource(dt)

    rpt.SetParameterValue(0, vDetalle)
    rpt.SetParameterValue(1, vLocal)
    rpt.SetParameterValue(2, vEmpresa)

    cv.ReportSource = rpt
  End Function

  Public Function RptResumen_Producto_Pedido(ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String, ByVal vDetalle As String) As Boolean
    Dim rpt As New rptResumen_Colp_Web
    rpt.SetDataSource(dt)

    rpt.SetParameterValue(0, vDetalle)
    rpt.SetParameterValue(1, vLocal)
    rpt.SetParameterValue(2, vEmpresa)

    cv.ReportSource = rpt
  End Function

  Public Function RptDetalle_Deposito(ByVal vDepositoId As Long, ByVal dt As DataTable, ByVal vEmpresa As String, ByVal vLocal As String,
                                      ByVal vSubtitulo As String, ByVal vComentario As String, ByVal vImage As String) As Boolean
    Dim Report As New rptDetalle_Deposito_Web
    Dim opciones(1) As String
    Dim DtOb As New DataTable
    Dim DtImg As New DataTable

    DtOb = dt
    DtImg = TempImg(vDepositoId, vImage)
    DtOb.TableName = "dtDetalle_DepositoW"
    DtImg.TableName = "dtImagen"

    Report.Database.Tables("dtDetalle_DepositoW").SetDataSource(DtOb)
    Report.Database.Tables("dtImagen").SetDataSource(DtImg)
    'Report.SetDataSource(DtImg)
    Report.SetParameterValue(0, vEmpresa)
    Report.SetParameterValue(1, vLocal)
    Report.SetParameterValue(2, vSubtitulo)
    Report.SetParameterValue(3, vComentario)

    'Report.SetParameterValue(4, My.Computer.Name)
    'Report.SetParameterValue(3, GestionSeguridadManager.sUsuario)
    Me.cv.ReportSource = Report
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
        vFile = "http://sehs.org.pe/cms/upload/colp-deposito/voucher/" & pFile
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

End Class