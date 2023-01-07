Imports System.Data.Odbc


Public Class LoginForm


    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Sub ConnectDB()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=warungmkn_buanis;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Templogin()
        Call ConnectDB()
        Dim username = TextBoxUsername.Text
        Dim password = TextBoxPassword.Text

        'MsgBox(username & ", " & password)

        Cmd = New OdbcCommand("SELECT * FROM `user_login` WHERE Username = '" & username & "' LIMIT 1 ;", Conn)

        Dim result As OdbcDataReader = Cmd.ExecuteReader
        If Not IsDBNull(result) Then
            If result.HasRows Then
                While result.Read
                    Dim LoginID = result("UserID")
                    If username = result("Username") And password = result("UserPassword") Then
                        MsgBox("Berhasil Login")
                        'TempLoginForm(result("UserID"))

                        Dim OBJ As New MainForm
                        OBJ.TempLoginID = result("UserID")
                        OBJ.Show()
                        Me.Hide()

                        'MainForm.Show()

                    'Me.Close()
                    Else
                    MsgBox("Nama atau Password salah")
                    End If
                End While
            End If
        Else
            MsgBox("2Nama atau Password salah")
        End If


       

    End Sub

    Public Function TempLoginForm(ByVal LoginID)
        Return LoginID
    End Function



    Private Sub BtnSuksesCetakStruk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuksesCetakStruk.Click
        If TextBoxUsername.Text = "" Or TextBoxPassword.Text = "" Then
            Dim warning = MessageBox.Show("Field harus di isi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Call Templogin()
        End If


    End Sub
End Class