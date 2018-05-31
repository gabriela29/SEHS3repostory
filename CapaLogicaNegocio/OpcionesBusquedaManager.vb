Imports System
Imports System.ComponentModel

Namespace Bll    
    Public Class SignoManager
        Public Shared Function GetList(ByVal Opciones() As String) As DataTable
            Dim MisParametros(1) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

            MisParametros(0) = "Signo"
            MisTipos(0) = "System.String"
            objDt = DataTableDesvinculado.GenerarDataTable("signos", MisParametros, MisTipos)

            For x As Integer = 0 To Opciones.GetUpperBound(0) - 1
                NuevoRegistro = objDt.NewRow
                NuevoRegistro.Item("Signo") = Opciones(x)
                objDt.Rows.Add(NuevoRegistro)
            Next

            Return objDt
        End Function
    End Class

    Public Class OpcionesManager

        Public Shared Function GetList(ByVal Opciones() As String) As DataTable
            Dim MisParametros(1) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

            MisParametros(0) = "Opciones"
            MisTipos(0) = "System.String"
            objDt = DataTableDesvinculado.GenerarDataTable("opciones", MisParametros, MisTipos)

            For x As Integer = 0 To Opciones.GetUpperBound(0) - 1
                NuevoRegistro = objDt.NewRow
                NuevoRegistro.Item("Opciones") = Opciones(x).ToString
                objDt.Rows.Add(NuevoRegistro)
            Next

            Return objDt
        End Function

        Public Shared Function GetPrintes(ByVal Opciones() As String) As DataTable
            Dim MisParametros(1) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow            
            MisParametros(0) = "Impresoras"
            MisTipos(0) = "System.String"
            objDt = DataTableDesvinculado.GenerarDataTable("impresoras", MisParametros, MisTipos)

            For x As Integer = 0 To Opciones.GetUpperBound(0) - 1
                NuevoRegistro = objDt.NewRow
                NuevoRegistro.Item("Impresoras") = Opciones(x)
                objDt.Rows.Add(NuevoRegistro)
            Next

            Return objDt
        End Function
    End Class

    Public Class DosOpcionesManager
        Public Shared Function GetList(ByVal NomTable As String, ByVal Opciones() As String, ByVal Opcionesvisible() As String) As DataTable
            Dim MisParametros(2) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

            MisParametros(0) = "Opcionesv"
            MisParametros(1) = "Opciones"
            MisTipos(0) = "System.String"
            MisTipos(1) = "System.String"
            objDt = DataTableDesvinculado.GenerarDataTable(NomTable, MisParametros, MisTipos)

            For x As Integer = 0 To Opciones.GetUpperBound(0) - 1
                NuevoRegistro = objDt.NewRow
                NuevoRegistro.Item("Opcionesv") = Opciones(x)
                NuevoRegistro.Item("Opciones") = Opcionesvisible(x)
                objDt.Rows.Add(NuevoRegistro)
            Next

            Return objDt
        End Function

    Public Shared Function GetList(ByVal NomTable As String, ByVal Opciones() As String, ByVal Opcionesvisible() As String, ByVal xTop As Long) As DataTable
      Dim MisParametros(2) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

      MisParametros(0) = "Opcionesv"
      MisParametros(1) = "Opciones"
      MisTipos(0) = "System.String"
      MisTipos(1) = "System.String"
      objDt = DataTableDesvinculado.GenerarDataTable(NomTable, MisParametros, MisTipos)

      For x As Integer = 0 To xTop
        NuevoRegistro = objDt.NewRow
        NuevoRegistro.Item("Opcionesv") = Opciones(x)
        NuevoRegistro.Item("Opciones") = Opcionesvisible(x)
        objDt.Rows.Add(NuevoRegistro)
      Next

      Return objDt
    End Function

    Public Shared Function GetListDiasP(ByVal NomTable As String, ByVal xTop As Long) As DataTable
      Dim MisParametros(2) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

      MisParametros(0) = "Opcionesv"
      MisParametros(1) = "Opciones"
      MisTipos(0) = "System.String"
      MisTipos(1) = "System.String"
      objDt = DataTableDesvinculado.GenerarDataTable(NomTable, MisParametros, MisTipos)

      For x As Integer = 1 To xTop
        NuevoRegistro = objDt.NewRow
        NuevoRegistro.Item("Opcionesv") = x
        NuevoRegistro.Item("Opciones") = x
        objDt.Rows.Add(NuevoRegistro)
      Next

      Return objDt
    End Function

  End Class

    Public Class ImagenManager
        Public Shared Function GetList(ByVal Opciones() As String) As DataTable
            Dim MisParametros(1) As String, MisTipos(1) As String, objDt As DataTable, NuevoRegistro As DataRow

            MisParametros(0) = "imagen"
            MisTipos(0) = "System.Byte()"
            objDt = DataTableDesvinculado.GenerarDataTable("imagenes", MisParametros, MisTipos)

            For x As Integer = 0 To Opciones.GetUpperBound(0) - 1
                NuevoRegistro = objDt.NewRow
                NuevoRegistro.Item("imagen") = Opciones(x)
                objDt.Rows.Add(NuevoRegistro)
            Next

            Return objDt
        End Function
    End Class

End Namespace