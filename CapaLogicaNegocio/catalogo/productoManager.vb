Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal

Namespace Bll
    Public Class productoManager

        Public Shared Function Consultar_Registros(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                                   Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                                   Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                                   Optional ByVal vCodigo_Barras As String = "", Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Return productoBD.Consultar_Registros(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                  vCodigo_Producto, vCodigo_Barras, vCon_Saldo)

        End Function

        Public Shared Function Consultar_Registros_Colp(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                                           Optional ByVal vCodigo_Barras As String = "", Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Return productoBD.Consultar_Registros_Colp(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                        vCodigo_Producto, vCodigo_Barras, vCon_Saldo)

        End Function

        Public Shared Function Consultar_Registros_cosig(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                           Optional ByVal vCodigo_Barras As String = "", Optional ByVal vCon_Saldo As Boolean = True) As DataTable

            Return productoBD.Consultar_Registros_Consig(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                            vCodigo_Producto, vCodigo_Barras, vCon_Saldo)

        End Function

        Public Shared Function Consultar_Registros_Salida(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                           Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productoBD.Consultar_Registros_Salida(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                            vCodigo_Producto, vCodigo_Barras)

        End Function

        Public Shared Function Consultar_Registros_Compra(ByVal vCodigo_C As Long, ByVal vCodigo_Almacen As Integer, _
                                                            Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                                            Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                                            Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productoBD.Consultar_Registros_Compra(vCodigo_C, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                        vCodigo_Producto, vCodigo_Barras)

        End Function

        Public Shared Function Consultar_Registros_Venta(ByVal vCodigo_V As Long, ByVal vCodigo_Almacen As Integer, _
                                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                                           Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productoBD.Consultar_Registros_Venta(vCodigo_V, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                        vCodigo_Producto, vCodigo_Barras)

        End Function

    Public Shared Function Consultar_Registros_Asistente(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vCampaniaid As Integer, ByVal vCodigo_Asis As Long,
                                                              ByVal vTipo As Integer, Optional ByVal vlimite As Integer = 50,
                                                              Optional ByVal vNombre As String = "", Optional ByVal vProducto As Long = 0,
                                                              Optional ByVal vCodigo_Barras As String = "") As DataTable
      Dim dtT As New DataTable
      If vTipo = 2 Then
        dtT = productoBD.Consultar_Registros_Bloque(vAno, vCodigo_Almacen, vCodigo_Asis, vTipo, vlimite, vNombre, vProducto, vCodigo_Barras)
      Else
        dtT = productoBD.Consultar_Registros_Asistente(vAno, vCodigo_Almacen, vCampaniaid, vCodigo_Asis, vTipo, vlimite, vNombre, vProducto, vCodigo_Barras)
      End If


      Return dtT

    End Function

    Public Shared Function Consultar_Registros_Bloque(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, ByVal vCodigo_Asis As Long, _
                                                      ByVal vTipo As Integer, Optional ByVal vlimite As Integer = 50, _
                                                      Optional ByVal vNombre As String = "", Optional ByVal vProducto As Long = 0, _
                                                      Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productoBD.Consultar_Registros_Bloque(vAno, vCodigo_Almacen, vCodigo_Asis, vTipo, vlimite, vNombre, vProducto, vCodigo_Barras)

        End Function

        Public Shared Function Consultar_Registros_Plan_Venco(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                           Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productoBD.Consultar_Registros_Plan_Venco(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                  vCodigo_Producto, vCodigo_Barras)

        End Function

        Public Shared Function Leer(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 100, _
                                                   Optional ByVal vNombre_Presentacion As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                   Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_SubCategoria As Integer = 0, _
                                                   Optional ByVal vCodigo_Categoria As Integer = 0, Optional ByVal vCodigo_Marca As Integer = 0, _
                                                   Optional ByVal vCodigo_Unidad As Integer = 0) As DataTable

            Return productoBD.Leer(vAno, vCodigo_Almacen, vlimite, vNombre_Presentacion, vNombre_Categoria, vCodigo_Producto, _
                                   vCodigo_SubCategoria, vCodigo_Categoria, vCodigo_Marca, vCodigo_Unidad)

        End Function

        Public Shared Function GetCombos_Cursor(ByRef dtFamilia As DataTable, _
                                                ByRef dtGrupo As DataTable, ByRef dtMedida As DataTable) As Boolean
            Return productoBD.GetCombos_Cursor(dtFamilia, dtGrupo, dtMedida)
        End Function

        Public Shared Function Grabar(ByVal xCodigo As Long, ByVal xNew As Boolean, ByVal objProd As producto, vArrLibro As String) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = productoBD.Actualizar(xCodigo, xNew, objProd, vArrLibro)

                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            vCodigo = rs.DataSet.Tables(0).Rows(0).Item("outid")
                        Else
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, " Información ")
                        End If
                    End If
                End If
            Finally
                rs = Nothing
            End Try
            Return vCodigo
        End Function

        Public Shared Function GetItem(ByVal vCodigo As Long) As producto
            Return productoBD.GetItem(vCodigo)
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = productoBD.Eliminar(vCodigo)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar = True
                        Else
                            Eliminar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar = False
            End Try
            Return Eliminar
        End Function

        Public Shared Function Consultar_Kardex(ByVal vProductoID As Long, ByVal vCodigo_Almacen As Integer, ByVal vAnio As Integer) As DataTable

            Return productoBD.Consultar_Kardex(vProductoID, vCodigo_Almacen, vAnio)

        End Function



    End Class
End Namespace
