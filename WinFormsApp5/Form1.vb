Imports System.Data.OleDb
Imports System.Data
Public Class Form1
    Sub view()
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\College.mdb")
        con.Open()
        Dim adp As New OleDbDataAdapter("select * from Student", con)
        Dim ds As New DataSet
        adp.Fill(ds, "Student")
        DataGridView1.DataSource = ds.Tables("Student")
        con.Close()
    End Sub

    Public Sub ShowData(ByVal CurrentRow)
        Try
            TextBox1.Text = ds.Tables("Student").Rows(CurrentRow)("ID")
            TextBox2.Text = ds.Tables("Student").Rows(CurrentRow)("Name")
            TextBox3.Text = ds.Tables("Student").Rows(CurrentRow)("Address")
            TextBox4.Text = ds.Tables("Student").Rows(CurrentRow)("Course")
        Catch ex As Exception
            MsgBox(ex.Message, "error")

        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\College.mdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Student values ( " & TextBox1.Text & ",' " & TextBox2.Text & " ', ' " & TextBox3.Text & " ', ' " & TextBox4.Text & " ')  "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Data Save Successfully")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
        view()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        view()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\College.mdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update Student set name=  ' " & TextBox2.Text & " ',  address= ' " & TextBox3.Text & " ', course= ' " & TextBox4.Text & " ' where id = " & TextBox1.Text & " "
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record update successfully")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
        view()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\College.mdb")
        con.Open()
        Dim cmd As New OleDbCommand()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Student where id =" & TextBox1.Text & ""
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Delete data successfully")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
        view()

    End Sub


End Class
