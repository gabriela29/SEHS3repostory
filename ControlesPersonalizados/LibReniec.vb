Imports System
Imports System.Drawing
Imports System.Net
Imports System.IO

Namespace LibReniec
  Public Class Info

    Public Enum Resul
      Ok = 0
      NoResul = 1
      ErrorCapcha = 2
      xError = 3
    End Enum

    Private myResul As Resul
    Private _Nombres As String
    Private _ApePaterno As String
    Private _ApeMaterno As String
    Private myCookie As CookieContainer

    '#region Propiedades
    ''' <summary>
    ''' Devuelve la imagen para el reto capcha
    ''' </summary>
    Public ReadOnly Property GetCapcha() As Image
      Get
        Return ReadCapcha()
      End Get

    End Property

    ''' <summary>
    ''' Si no Hubo error en la lectura de datos devuelve los nombres
    ''' de la persona caso contrario devuelve ""
    ''' </summary>
    Public ReadOnly Property Nombres() As String
      Get
        Return _Nombres
      End Get

    End Property


    ''' Si no Hubo error en la lectura de datos devuelve el Apellido Paterno
    ''' de la persona caso contrario devuelve ""
    Public ReadOnly Property ApePaterno() As String
      Get
        Return _ApePaterno
      End Get

    End Property


    ''' Si no Hubo error en la lectura de datos devuelve el Apellido Materno
    ''' de la persona caso contrario devuelve ""
    Public ReadOnly Property ApeMaterno() As String
      Get
        Return _ApeMaterno
      End Get

    End Property

    ''' <summary>
    ''' Devuelve el resultado de la busqueda de DNI
    ''' </summary>
    Public ReadOnly Property GetResul() As Resul
      Get
        Return myResul
      End Get

    End Property

    '#End Region

    '#region Constructor

    Public Function Info()

      Try
        myCookie = Nothing
        myCookie = New CookieContainer()
        Return ReadCapcha()

      Catch ex As Exception
        Throw ex
      End Try
    End Function

    '#endregion

    ''' <summary>
    ''' Carga la imagen Capcha
    ''' </summary>
    Private Function ReadCapcha() As Image
      Try
        Dim myWenRequest As HttpWebRequest = CType(WebRequest.Create("https://cel.reniec.gob.pe/valreg/valreg.do?accion=ini"), HttpWebRequest)
        myWenRequest.CookieContainer = myCookie
        myWenRequest.Credentials = CredentialCache.DefaultCredentials
        Dim myWebResponse As HttpWebResponse = CType(myWenRequest.GetResponse(), HttpWebResponse)
        Dim myImgStream As Stream = myWebResponse.GetResponseStream()
        'myWebResponse.Close();
        Return Image.FromStream(myImgStream)

      Catch ex As Exception
        Throw ex
      End Try
    End Function

    ''' <summary>
    ''' Inicia la carga de los datos de la persona
    ''' </summary>
    ''' <param name="numDni"></param>
    ''' <param name="ImgCapcha"></param>
    Public Sub GetInfo(ByVal numDni As String, ByVal ImgCapcha As String)
      Try
        Dim line As String = ""
        Dim count As Integer = -1
        Dim myUrl As String = String.Format("http://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}", numDni, ImgCapcha)
        Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create(myUrl), HttpWebRequest)
        myWebRequest.CookieContainer = myCookie
        myWebRequest.Credentials = CredentialCache.DefaultCredentials
        Dim myHttpWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
        Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
        Dim myStreamReader As New StreamReader(myStream)


        If myStreamReader.ReadLine IsNot Nothing Then
          'Comenzar a leer el html devuelvto por el servidor desde la linea 150
          While (line = myStreamReader.ReadLine())
            count += 1
            If count >= 150 Then

              Dim tmp As String = line.Trim()
              If tmp <> "" Then
                tmp = tmp.Substring(0, 4).Trim()
              End If
              Select Case tmp
                Case ""
                  myResul = Resul.Ok
                                    ' break;
                Case "<tr>"
                  myResul = Resul.NoResul
                                    ' break;
                Case "<td"
                  myResul = Resul.ErrorCapcha
                  ' break;
                Case Else
                  myResul = Resul.xError
                  ' break;

              End Select

              If myResul = Resul.Ok Then

                line = myStreamReader.ReadLine() 'linea 151
                line = myStreamReader.ReadLine() 'linea 152
                Me._Nombres = myStreamReader.ReadLine().Trim() 'linea 153
                Me._ApePaterno = myStreamReader.ReadLine().Trim() 'linea 154
                Me._ApeMaterno = myStreamReader.ReadLine().Trim() 'linea 155
                'para borrar el <br>
                Me._ApeMaterno = Me._ApeMaterno.Substring(0, Me._ApeMaterno.Length - 4)
              End If

            End If

            myHttpWebResponse.Close()

          End While
        End If
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Class
End Namespace