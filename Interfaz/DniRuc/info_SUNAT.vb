
Imports System
Imports System.Drawing
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports CapaLogicaNegocio.Bll
Imports CapaObjetosNegocio.BO

Namespace LibSunat
  Enum Resul
    ok = 0
    NoResul = 1
    ErrorCapcha = 2
    xError = 3
  End Enum

  Public Class info_SUNAT

    Private state As Resul
    Private pRaz_Social As String = ""
    Private pRUC As String = ""

    Private pEstado As String = ""
    Private pCondicion As String = ""
    Private pDireccion As String = ""
    Private pTelefono As String = ""
    Private myCookie As CookieContainer

    Public Function Persona()
      Try
        myCookie = Nothing
        myCookie = New CookieContainer()
        'Permitir SSL
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
        Return ReadCapcha()

      Catch ex As Exception
        MessageBox.Show(ex.Message)
        Return Nothing
      End Try
    End Function


    Private Function ReadCapcha() As Image
      Try
        Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image"), HttpWebRequest)
        myWebRequest.CookieContainer = myCookie
        myWebRequest.Proxy = Nothing
        myWebRequest.Credentials = CredentialCache.DefaultCredentials
        Dim myWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
        Dim myImgStream As Stream = myWebResponse.GetResponseStream()
        'myWebResponse.Close();
        Return Image.FromStream(myImgStream)

      Catch ex As Exception
        MessageBox.Show(ex.Message)
        Return Nothing
      End Try

    End Function


    Public Function GetInfo(ByVal numDni As String, ByVal ImgCapcha As String, ByRef xresul As String, ByRef vObj As datos_ruc) As Boolean
      Dim vOk As Boolean = False

      Try
        Dim myUrl As String = String.Format("http://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&razSoc=&nroRuc={0}&nrodoc=&contexto=rrrrrrr&tQuery=on&search1=10015569943&codigo={1}&tipdoc=1&search2=&coddpto=&codprov=&coddist=&search3= ", numDni, ImgCapcha)

        Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create(myUrl), HttpWebRequest)
        'myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";'esto creo que lo puse por gusto :/
        myWebRequest.CookieContainer = myCookie
        myWebRequest.Credentials = CredentialCache.DefaultCredentials
        myWebRequest.Proxy = Nothing
        Dim myHttpWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
        Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
        Dim myStreamReader As New StreamReader(myStream)
        Dim _WebSource As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())

        xresul = ""
        ''Dim aResul As String = Regex.Replace(_WebSource, "<.*?>", String.Empty)

        ''Dim _split As String() = _WebSource.Split(New Char(), ("< > \n \r"))


        ''Dim _resul As List(Of String) = New List(Of String)()
        ' ''quitamos todos los caracteres nulos

        ''For i As Integer = 0 To _split.Length - 1

        ''    If Not String.IsNullOrEmpty(_split(i).Trim()) Then
        ''        _resul.Add(_split(i).Trim())
        ''        xresul = xresul & (_split(i).Trim())
        ''    End If

        ''Next

        Dim separators() As String = {"td class=bg colspan=1>"}
        Dim vRuc As String


        Dim obj As New datos_ruc
        Dim vNewRuc As String = "", vStado As String, vSit As String, word As String = "", vDirec As String = ""
        Dim words() As String = _WebSource.Split(New Char(), ("< > \n \r")) '_WebSource.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        For Each word In words
          'If "<table border=0 cellpadding=2 cellspacing=3 width=100% class=form-table>" Then

          vRuc = Mid(words(27), 26, 150) 'Replace(words(27), "td class=", "")
          obj.ruc = Mid(vRuc.Trim, 1, 11).Trim
          obj.Razon_Social = Mid(vRuc.Trim, 15, 120).Trim
          obj.Tipo_Per = Mid(words(33), 25, 150).Trim
          obj.Dni = Mid(words(39), 29, 150).Trim

          vNewRuc = Mid(words(47), 27, 19).Trim

          If vNewRuc = "Afecto al Nuevo RUS" Then
            vStado = Mid(words(65), 25, 50).Trim

            If Not vStado = "ACTIVO" Then
              vStado = Mid(words(65), 25, 50).Trim
            End If
            obj.Estado = vStado
            vSit = Mid(words(73), 35, 50).Trim
            If Not vSit = "HABIDO" Then
              vSit = Mid(words(73), 35, 50).Trim
            End If
            obj.Condicion = vSit
            obj.Direccion = Mid(words(79), 25, 150).Trim
            obj.Telefonos = Mid(words(85), 25, 150).Trim
            'xresul = xresul & word
            vOk = True
            Exit For
            'End If
          Else
            vStado = Mid(words(61), 25, 50).Trim
            If Not vStado = "ACTIVO" Then
              vStado = Mid(words(55), 25, 50).Trim
            End If
            obj.Estado = vStado
            vSit = Mid(words(69), 35, 50).Trim
            If Not vSit = "HABIDO" Then
              vSit = Mid(words(63), 35, 50).Trim
            End If
            obj.Condicion = vSit

            vDirec = Mid(words(73), 26, 150).Trim
            If vDirec = "Dirección del Domicilio Fiscal:" Then
              obj.Direccion = Mid(words(75), 25, 150).Trim
            Else
              obj.Direccion = Mid(words(69), 25, 150).Trim
            End If

            obj.Telefonos = Mid(words(85), 25, 150).Trim
            'xresul = xresul & word
            vOk = True
            Exit For
            'End If
          End If
        Next
        vObj = obj
        obj = Nothing
        xresul = _WebSource

        If state = Resul.ok Then


        End If

        myHttpWebResponse.Close()


      Catch ex As Exception
        MessageBox.Show(ex.Message)

      End Try
      Return vOk
    End Function
  End Class
End Namespace


