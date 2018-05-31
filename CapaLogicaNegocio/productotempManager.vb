

Imports System
Imports System.ComponentModel
Imports CapaObjetosNegocio.BO
Imports CapaDatos.Dal


Namespace Bll
    Public Class productotempManager
        Public Shared Function Consultar_Registros(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, _
                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                           Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productotmpBD.Consultar_Registros(vAno, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                  vCodigo_Producto, vCodigo_Barras)

        End Function

        Public Shared Function Consultar_Registros_Venta(ByVal vCodigo_V As Long, ByVal vCodigo_Almacen As Integer, _
                                                           Optional ByVal vlimite As Integer = 20, Optional ByVal vNombre_Producto As String = "", _
                                                           Optional ByVal vNombre_Categoria As String = "", Optional ByVal vCodigo_Producto As Long = 0, _
                                                           Optional ByVal vCodigo_Barras As String = "") As DataTable

            Return productotmpBD.Consultar_Registros_Venta(vCodigo_V, vCodigo_Almacen, vlimite, vNombre_Producto, vNombre_Categoria, _
                                                        vCodigo_Producto, vCodigo_Barras)

        End Function

        Public Shared Function Leer(ByVal vAno As Integer, ByVal vCodigo_Almacen As Integer, Optional ByVal vlimite As Integer = 100, _
                                                   Optional ByVal vNombre_Presentacion As String = "", Optional ByVal vNombre_Categoria As String = "", _
                                                   Optional ByVal vCodigo_Producto As Long = 0, Optional ByVal vCodigo_SubCategoria As Integer = 0, _
                                                   Optional ByVal vCodigo_Categoria As Integer = 0, Optional ByVal vCodigo_Marca As Integer = 0, _
                                                   Optional ByVal vCodigo_Unidad As Integer = 0) As DataTable

            Return productotmpBD.Leer(vAno, vCodigo_Almacen, vlimite, vNombre_Presentacion, vNombre_Categoria, vCodigo_Producto, _
                                   vCodigo_SubCategoria, vCodigo_Categoria, vCodigo_Marca, vCodigo_Unidad)

        End Function

        Public Shared Function GetCombos_Cursor(ByRef dtFamilia As DataTable, _
                                                ByRef dtGrupo As DataTable, ByRef dtMedida As DataTable) As Boolean
            Return productotmpBD.GetCombos_Cursor(dtFamilia, dtGrupo, dtMedida)
        End Function

        Public Shared Function Grabar(ByVal xCodigo As Long, ByVal xNew As Boolean, ByVal objProd As productotmp) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = productotmpBD.Actualizar(xCodigo, xNew, objProd)

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

        Public Shared Function GetItem(ByVal vCodigo As Long) As productotmp
            Return productotmpBD.GetItem(vCodigo)
        End Function

        Public Shared Function Eliminar(ByVal vCodigo As Long) As Boolean
            Dim rs As DataTable
            Try
                rs = productotmpBD.Eliminar(vCodigo)
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



        Public Shared Function GetList_SUBCAT(ByVal vNombre As String, ByVal vCodigo_Cat As Integer) As DataTable

            Return productotmpBD.GetList_SUBCAT(vNombre, vCodigo_Cat)

        End Function

        Public Shared Function Actualizar_Proveedor(ByVal vCodigo_pro As Long, ByVal vCodigo_per As Long, ByVal vAnio As Integer, _
                                                    ByVal vCodigo_Pro_Prov As String, ByVal vPrecioS As Single, ByVal vPrecioD As Single) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = productotmpBD.Actualizar_Proveedor(vCodigo_pro, vCodigo_per, vAnio, vCodigo_Pro_Prov, vPrecioS, vPrecioD)

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

    Public Shared Function Actualizar_Ubicacion(ByVal vCodigo_pro As Long, ByVal vCodigo_Alm As Integer,
                                                ByVal vUbicacion As String, ByVal vUbicacionB As String) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = productotmpBD.Actualizar_Ubicacion(vCodigo_pro, vCodigo_Alm, vUbicacion, vUbicacionB)

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

    Public Shared Function Actualizar_Precio_Almacen(ByVal vProductoid As Long, ByVal vAlmacenid As Integer,
                                                      ByVal vPrecio As Single, ByVal vPrecioB As Single) As Long
      Dim rs As DataTable, vCodigo As Long
      vCodigo = 0
      Try
        rs = productotmpBD.Actualizar_Precio_Almacen(vProductoid, vAlmacenid, vPrecio, vPrecioB)

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

  End Class
End Namespace
