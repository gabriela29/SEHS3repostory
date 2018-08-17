

Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Devart.Data.PostgreSql
Imports CapaObjetosNegocio
Imports CapaDatos
Imports Npgsql

Public Class importar
    Public swNuevoimport As Boolean
    Dim dadapter As New NpgsqlDataAdapter
    Dim dtable As New DataTable
    Dim conn As OleDbConnection
    Dim dta As OleDbDataAdapter
    Dim dts As DataSet
    Dim excel As String
    Dim OpenFileDialog As New OpenFileDialog
    Dim posg As New NpgsqlCommand
    ' Dim oConexion As New clsConexion

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnimportar.Click
        Try
            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel Files (*.xlsx)|*.xlsx|Xls Files (*.xls)|*.xls"
            If OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName
                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("select * from [Sheet1$]", conn)
                dts = New DataSet
                dta.Fill(dts, "[Sheet1$]")
                DGV1.DataSource = dts
                DGV1.DataMember = "[Sheet1$]"
                conn.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try
    End Sub


    Dim connection As New NpgsqlConnection("Server=localhost;Port=5432;Database=prueba12;Uid=postgres;Pwd=postgres;CommandTimeout=0; pooling=false;")


    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        'Dim TempList As New DataTable
        ' Dim oConexion As New clsConexion

        Try
            Dim osp As New NpgsqlCommand
            connection.Open()
            For i As Integer = 0 To DGV1.Rows.Count - 2 Step +1
                osp = New NpgsqlCommand("insert into basic.persona_prueba  values (@persona_pid, @dni, @ruc, @ape_paterno, @ape_materno, @nombre, @direccion) ", connection)
                osp.Parameters.Add("@persona_pid", NpgsqlTypes.NpgsqlDbType.Integer).Value = DGV1.Rows(i).Cells(0).Value
                osp.Parameters.Add("@dni", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(1).Value.ToString()
                osp.Parameters.Add("@ruc", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(2).Value.ToString()
                osp.Parameters.Add("@ape_paterno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(3).Value.ToString()
                osp.Parameters.Add("@ape_materno", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(4).Value.ToString()
                osp.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(5).Value.ToString()
                osp.Parameters.Add("@direccion", NpgsqlTypes.NpgsqlDbType.Varchar).Value = DGV1.Rows(i).Cells(6).Value.ToString()
                '  TempList = oConexion.Ejecutar_Consulta("")
                osp.ExecuteNonQuery()
            Next
            connection.Close()
            MsgBox("Los Datos han sido Importados exitosamente!")
            viewDGV1()
        Catch ex As Exception

        End Try


    End Sub

    Sub viewDGV1()
        posg.Connection = connection
        connection.Open()
        posg.CommandText = "select persona_pid, dni, ruc, ape_paterno, ape_materno, nombre, direccion from basic.persona_prueba"
        dadapter = New NpgsqlDataAdapter(posg)
        dtable.Rows.Clear()
        dadapter.Fill(dtable)
        DGV1.DataSource = dtable
        connection.Close()
    End Sub



End Class