
Imports System.Data.OleDb

'---***** Esto debe ir al Formulario*******

''Dim archivo As String 'Declaramos una variable de tipo String para definir la ruta al archivo
''archivo = Server.MapPath("agenda.xlsx") 'Asignamos la ruta
''GridView1.DataSource = LeerArchivoExcel(archivo) ' Invocamos a la funcion LeerArchivoExcel, la cual devolverá un Dataset y sera el origen de los datos para el GridView
''GridView1.DataBind()

'----***** Fin Esto debe ir al formulario*******


Public Class Excel_Functions
  Public Shared Function LeerArchivoExcel(ByVal file As String, ByRef vError As String) As DataSet
    vError = ""
    'La cadena de conexion para leer un archivo de Excel 2007 es Microsoft.ACE.OLEDB.12.0, tal como se muestra a continuación
    Dim m_sConn1 As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source=" & file & ";" & "Extended Properties=""Excel 12.0;HDR=YES"""

    'Generamos objeto de conexion
    Dim conn2 As New OleDbConnection(m_sConn1)

    'Definimos la consulta SQL para leer la informacion del archivo de Excel, noten que hacemos referencia a las Hojas, se puede leer cualquier hoja, siempre y cuando indiquemos el nombre con un signo $ y encerrado entre []
    Dim consulta As String
    consulta = "Select * From [Hoja1$]"

    'Lo siguiente ejecutar la conexion y la consulta y llenar el DataSet que devolvera la función
    Dim da As New OleDbDataAdapter(consulta, conn2)

    Dim ds As New DataSet()

    Try
      da.Fill(ds)
      Return ds
    Catch ex As Exception
      vError = ex.Message & file
    Finally
      conn2.Close()
    End Try

    Return ds

  End Function
End Class
