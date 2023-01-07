Public Class MainCustomerAdd

    Private Sub SendCustomerName()
        If TextBox1.Text = "" Then
            Dim dialog As DialogResult = MessageBox.Show("'Nama Pelanggan' harus di isi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            MainForm.LbCustomerName.Text = "123123123123123"
            MainForm.GroupBox1.Enabled = True
            Me.Close()
            'MainForm.Enabled = True
            'MainForm.Focus()
            MainForm.ButtonSimpanPesanan.Enabled = False
        End If

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
            SendCustomerName()

        End If
        'SendCustomerName()
    End Sub

    Private Sub BtnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOrder.Click
        SendCustomerName()
    End Sub

    Private Sub CustomerAdd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub CustomerAdd_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            MainForm.GroupBox1.Enabled = True
            MainForm.Enabled = True
            MainForm.ResetMain()
        End If
    End Sub

    Private Sub CheckCustomerInput()
        If TextBox1.Text = "" Then
            BtnAddOrder.Enabled = False
        Else
            BtnAddOrder.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Call CheckCustomerInput()
    End Sub

    Private Sub CustomerAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CheckCustomerInput()
    End Sub

    'Public Sub BtnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOrder.Click
    '    MainForm.LbCustomerName.Text = TextBox1.Text
    '    Me.Close()
    '    'MainForm.Focus()

    '    'Dim OBJ As New MainForm
    '    'OBJ.NewOrderName = TextBox1.Text
    '    'Me.Hide()
    '    'OBJ.Show()

    'End Sub

    'Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
    '    MainForm.LbCustomerName.Text = TextBox1.Text
    'End Sub
End Class