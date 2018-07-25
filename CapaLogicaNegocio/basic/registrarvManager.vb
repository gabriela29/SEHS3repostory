﻿Imports System
Imports System.ComponentModel
Imports CapaDatos.Dal
Imports CapaObjetosNegocio

Namespace BLL

    Public Class registrarvManager

        Public Shared Function GetList(ByVal numerov As String) As DataTable
            Return registrarVBD.GetList(numerov)
        End Function

        Public Shared Function GetItem(ByVal codigo_registrarv As Long) As registrarv
            Return registrarVBD.GetItem(codigo_registrarv)
        End Function

        Public Shared Function Grabar(ByVal objR As registrarv) As Long
            Dim rs As DataTable, vCodigo As Long
            vCodigo = 0
            Try
                rs = registrarVBD.Grabar(objR)

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

        Public Shared Function Eliminar_Registrar(ByVal numero As String) As Boolean

            Dim rs As DataTable
            Try
                rs = registrarVBD.Eliminar(numero)
                If Not rs Is Nothing Then
                    If rs.DataSet.Tables(0).Rows.Count > 0 Then
                        If rs.DataSet.Tables(0).Rows(0).Item("outstate") Then
                            Eliminar_Registrar = True
                        Else
                            Eliminar_Registrar = False
                            MsgBox(rs.DataSet.Tables(0).Rows(0).Item("outdescription"), MsgBoxStyle.Information, "Información")
                        End If
                    End If
                    rs = Nothing
                End If
            Catch ex As Exception
                Eliminar_Registrar = False
            End Try
            Return Eliminar_Registrar
        End Function
    End Class
End Namespace

