Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Drawing.Imaging
Imports System.Runtime.Remoting.Contexts
Imports System.Windows.Forms
Imports Antlr.Runtime.Misc
Imports Microsoft.Ajax.Utilities

Public Class _Default
    Inherits Page

    Dim connect As New SqlConnection("Data Source=DESKTOP-ARHUSLN;Initial Catalog=employeeDB;Integrated Security=True;")
    'Dim PageReload As Int32 = 0



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        txtId.Enabled = True
        txtFirstName.Enabled = False
        txtSecondName.Enabled = False
        txtPhoneNumber.Enabled = False
        ddlEmplType.Enabled = False
        Button2.Enabled = True
        Button1.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False
        'If (PageReload = 0) Then
        '       FillComboEmpType()
        'End If
    End Sub

    'Private Sub FillComboEmpType()
    '    Dim query As String = "Select * from EmployeeType"
    '    Using command As New SqlCommand(query, connect)
    '        connect.Open()

    '        Dim reader As SqlDataReader = command.ExecuteReader()

    '        ddlEmplType.Items.Clear()

    '        While reader.Read()
    '            ddlEmplType.Items.Add(reader("Definition").ToString())
    '        End While

    '        reader.Close()

    '    End Using
    '    connect.Close()
    '    PageReload = 1
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'PageReload = 1
        connect.Open()
        'Dim id As Integer = txtId.Text
        Dim firstName As String = txtFirstName.Text
        Dim secondName As String = txtSecondName.Text
        Dim phoneNumber As String = txtPhoneNumber.Text
        Dim empType As String = ""

        Dim queryEmpType As String = "select * from EmployeeType where Definition ='" & ddlEmplType.SelectedValue & "'"
        Using comm As New SqlCommand(queryEmpType, connect)
            Dim reader As SqlDataReader = comm.ExecuteReader()
            reader.Read()

            empType = reader("Code").ToString()
            reader.Close()

        End Using

        'ValidationFields()
        If txtFirstName.Text = "" Then
            MsgBox("Ingrese el primer nombre, porfavor.", MsgBoxStyle.Critical, "Message")
            Return
        End If
        If txtSecondName.Text = "" Then
            MsgBox("Ingrese el segundo nombre, porfavor.", MsgBoxStyle.Critical, "Message")
            Return
        End If

        Dim command As New SqlCommand("Insert into Employee values ('" & firstName & "','" & secondName & "','" & phoneNumber & "','" & empType & "')", connect)
        command.ExecuteNonQuery()
        MsgBox("Registros grabados exitosamente!!", MsgBoxStyle.Information, "Message")
        connect.Close()
        ListEmp()
        BlockFields()
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False

    End Sub

    Private Sub ValidationFields()
        'Dim firstName As String = txtFirstName.Text
        'Dim secondName As String = txtSecondName.Text

        If txtFirstName.Text = "" Then
            MsgBox("Ingrese el primer nombre, porfavor.", MsgBoxStyle.Critical, "Message")
            Return
        End If
        If txtSecondName.Text = "" Then
            MsgBox("Ingrese el segundo nombre, porfavor.", MsgBoxStyle.Critical, "Message")
            Return
        End If

    End Sub

    Private Sub ListEmp()
        Dim command As New SqlCommand("select * from Employee", connect)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sd.Fill(dt)
        'GridView1.DataSource = dt
        GridView1.DataBind()
        txtId.Text = dt.Rows(dt.Rows.Count() - 1)("ID")

    End Sub

    Private Sub BlockFields()
        txtFirstName.Enabled = False
        txtSecondName.Enabled = False
        txtPhoneNumber.Enabled = False
        ddlEmplType.Enabled = False

    End Sub

    Private Sub EnableFields()
        txtId.Enabled = False
        txtFirstName.Enabled = True
        txtSecondName.Enabled = True
        txtPhoneNumber.Enabled = True
        ddlEmplType.Enabled = True

    End Sub

    Private Sub CleanFields()
        txtId.Text = ""
        txtFirstName.Text = ""
        txtSecondName.Text = ""
        txtPhoneNumber.Text = ""
        'ddlEmplType.Items.Clear()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect.Open()
        'Dim id As Integer = txtId.Text
        Dim firstName As String = txtFirstName.Text
        Dim secondName As String = txtSecondName.Text
        Dim phoneNumber As String = txtPhoneNumber.Text
        Dim empType As String = ""

        Dim queryEmpType As String = "select * from EmployeeType where Definition ='" & ddlEmplType.SelectedValue & "'"
        Using comm As New SqlCommand(queryEmpType, connect)
            Dim reader As SqlDataReader = comm.ExecuteReader()
            reader.Read()

            empType = reader("Code").ToString()
            reader.Close()

        End Using

        'Dim command As New SqlCommand("Insert into Employee values ('" & firstName & "','" & secondName & "','" & phoneNumber & "','" & empType & "')", connect)
        Dim command As New SqlCommand("update Employee set FirstName='" & firstName & "', SecondName='" & secondName & "', PhoneNumber='" & phoneNumber & "', EmployeeType=" & empType & " where ID = " & txtId.Text & "", connect)
        command.ExecuteNonQuery()
        MsgBox("Registros actualizados exitosamente!!", MsgBoxStyle.Information, "Message")
        connect.Close()
        ListEmp()
        Button2.Enabled = False
        Button4.Enabled = True
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connect.Open()
        If txtId.Text <> "" Then
            Dim queryEmp As String = "select * from Employee where ID ='" & txtId.Text & "'"
            Using comm As New SqlCommand(queryEmp, connect)
                Dim reader As SqlDataReader = comm.ExecuteReader()
                reader.Read()
                Dim empTypeDef As String

                'empType = reader("Code").ToString()
                If reader.FieldCount() > 0 Then
                    txtFirstName.Text = reader("FirstName").ToString()
                    txtSecondName.Text = reader("SecondName").ToString()
                    txtPhoneNumber.Text = reader("PhoneNumber").ToString()

                    Dim queryEmpType As String = "select * from EmployeeType where Code ='" & reader("EmployeeType").ToString() & "'"
                    Using comm2 As New SqlCommand(queryEmpType, connect)
                        reader.Close()
                        Dim reader2 As SqlDataReader = comm2.ExecuteReader()
                        reader2.Read()
                        empTypeDef = reader2("Definition").ToString()
                        reader2.Close()

                    End Using

                    ddlEmplType.SelectedValue = empTypeDef.ToString()
                End If
                'reader.Close()
                EnableFields()
            End Using
        Else
            MsgBox("Ingrese el ID, porfavor.", MsgBoxStyle.Critical, "Message")
        End If
        Button5.Enabled = True
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EnableFields()
        CleanFields()
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button5.Enabled = False
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        connect.Open()

        'Dim command As New SqlCommand("Insert into Employee values ('" & firstName & "','" & secondName & "','" & phoneNumber & "','" & empType & "')", connect)
        Dim command As New SqlCommand("DELETE FROM Employee  where ID = " & txtId.Text & "", connect)
        command.ExecuteNonQuery()
        MsgBox("Registro eliminado exitosamente!!", MsgBoxStyle.Information, "Message")
        connect.Close()
        ListEmp()
        CleanFields()
        Button2.Enabled = False
        Button4.Enabled = True
    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
    'txtFirstName.Enabled = False
    'If GridView1.SelectedRows.Count Then
    'DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    'Dim selectedRow As DataGridViewRow = GridView1.SelectedValue

    'Dim firstName As String = Convert.ToString(selectedRow.Cells("FirstName").Value)

    'txtFirstName.Text = firstName
    'End If
    'End Sub



    'Private Sub gridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridView1.CellDoubleClick


    'End Sub
End Class