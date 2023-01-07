Imports System.Data.Odbc

Public Class MainProsesPesanan

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


    Public Sub ShowDaftarPesananPending()
        Call ConnectDB()


        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)
        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk, daftar_pesanan_detail.Kuantitas, produk_daftar.HargaSatuan, produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & CInt(LbCustomerIDValue.Text) & " ", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewProsesPesanan.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewProsesPesanan.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("Kuantitas"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("SubTotal"))

            End While
        Else
            ListViewProsesPesanan.Items.Clear()

        End If



        ListViewProsesPesanan.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewProsesPesanan.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewProsesPesanan.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewProsesPesanan.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

    

    Private Sub GetOrderIDInfo()
        Call ConnectDB()
        Cmd = New OdbcCommand("SELECT NamaCustomer FROM daftar_pesanan WHERE OrderID = " & LbCustomerIDValue.Text & "", Conn)
        LbCustomerNameValue.Text = Cmd.ExecuteScalar()

        Cmd = New OdbcCommand("SELECT SUM(produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas) AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & LbCustomerIDValue.Text & "", Conn)
        LbPesananTagihanValue.Text = "Rp. " & Cmd.ExecuteScalar()
    End Sub

    Private Sub MainProsesPesanan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainForm.Enabled = False
        'Me.BringToFront()

        Call ConnectDB()
        Cmd = New OdbcCommand("SELECT OrderID FROM daftar_pesanan WHERE UserID = 1 ORDER BY OrderID DESC LIMIT 1;", Conn)


        'Temp Value
        LbCustomerIDValue.Text = Cmd.ExecuteScalar
        Call ShowDaftarPesananPending()
        Call GetOrderIDInfo()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Call MainForm.ResetMain()
        MainForm.Enabled = True
        MainForm.Focus()

    End Sub

    Private Sub ListViewProsesPesanan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewProsesPesanan.SelectedIndexChanged

    End Sub


End Class