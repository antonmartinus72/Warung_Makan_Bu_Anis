Imports System.Data.Odbc
Public Class MainTransaksi
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Public Property OrderIDFromMain As Integer ' the value is stored in there, it can be any type

    Private Sub ConnectDB()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=warungmkn_buanis;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    '---------------------------------------------------
    Public Sub LoadDataFromID()
        Cmd = New OdbcCommand("SELECT daftar_pesanan.OrderID, daftar_pesanan.NamaCustomer, (SELECT SUM(produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas)) AS TotalTagihan FROM daftar_pesanan_detail JOIN daftar_pesanan ON daftar_pesanan_detail.OrderID = daftar_pesanan.OrderID JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & OrderIDFromMain & "", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            While Rd.Read
                LbPaymentOrderIDValue.Text = Rd("OrderID")
                LbPaymentNameValue.Text = Rd("NamaCustomer")
                LbPaymentName2Value.Text = Rd("NamaCustomer")
                LbPaymentBillValue.Text = Rd("TotalTagihan")

            End While
        End If

        'LbPaymentNameValue.Text = OrderIDFromMain
    End Sub

    

    Public Sub ProcessPayment()

        Dim Tunai = NumericUpDownPaymentTunai.Value
        Cmd = New OdbcCommand("SELECT SUM(produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas) AS TotalTagihan FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & OrderIDFromMain & "", Conn)
        Dim TotalTagihan = Convert.ToInt32(Cmd.ExecuteScalar)

        'Dim result As Object = Cmd.ExecuteScalar
        'result = 

        'Dim HargaTotal
        'HargaTotal = Rd.ToString
        'Dim TanggalTransaksi As DateTime = Date.Now



        If NumericUpDownPaymentTunai.Value > TotalTagihan Then
            'MsgBox("OK")


            Dim PaymentKembalian As Decimal = Tunai - TotalTagihan
            'Dim PaymentDate = DateTime.Now

            'MsgBox(PaymentKembalian)

            Cmd = New OdbcCommand("INSERT INTO `daftar_transaksi`(`KodeTransaksi`, `OrderID`, `MetodePembayaran`, `TotalHarga`, `Tunai`) VALUES (NULL,'" & Convert.ToString(OrderIDFromMain) & "','1','" & TotalTagihan & "', '" & Tunai & "')", Conn)
            Cmd.ExecuteNonQuery()

            Cmd = New OdbcCommand("UPDATE `daftar_pesanan` SET `OrderStatusID`='2' WHERE OrderID = " & OrderIDFromMain & "", Conn)
            Cmd.ExecuteNonQuery()

            'MsgBox("Transaksi Sukses")

            'If Cmd.ExecuteNonQuery > 0 And Cmd.ExecuteNonQuery > 0 Then
            '    MsgBox("Transaksi Sukses")
            'Else
            '    MsgBox("Transaksi Gagal.")
            'End If

            'Passing data to ReportStrukTransaksi From
            Dim OBJ As New ReportStrukTransaksi 'Instances ReportStrukTransaksi Form
            OBJ.OrderIDReport = OrderIDFromMain


            'Disable this form
            TableLayoutPanel1.Enabled = False

            OBJ.ShowDialog()

        Else
            MsgBox("Tunai tidak mencukupi")
        End If



        MainForm.ListViewPending.Refresh()

    End Sub

    Public Sub SendDataToReportStruk()
        
    End Sub

    Public Sub ShowDaftarPesananPendingDetail()
        Call ConnectDB()

        ListViewPaymentProdukDetail.Items.Clear()

        Dim ProdukIDFromListPending = OrderIDFromMain


        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)
        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk, daftar_pesanan_detail.Kuantitas, produk_daftar.HargaSatuan, produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & ProdukIDFromListPending & " ", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewPaymentProdukDetail.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewPaymentProdukDetail.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("Kuantitas"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("SubTotal"))

            End While
        Else
            ListViewPaymentProdukDetail.Items.Clear()

        End If



        ListViewPaymentProdukDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPaymentProdukDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewPaymentProdukDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPaymentProdukDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    '---------------------------------------------------

    Private Sub MainTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ShowDaftarPesananPendingDetail()
        Call LoadDataFromID()
    End Sub



    Private Sub BtnPaymentProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPaymentProcess.Click
        Call ProcessPayment()
    End Sub
End Class