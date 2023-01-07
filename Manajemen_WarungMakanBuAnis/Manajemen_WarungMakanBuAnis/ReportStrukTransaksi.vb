Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms

Public Class ReportStrukTransaksi
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Public Property OrderIDReport As String  ' the value is stored in there, it can be any type
    'Public Property OrderIDReportParam As String

    Sub ConnectDB()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=warungmkn_buanis;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
        
    End Sub

    Private Sub ReportStrukTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Disable Form after transaction complete

        MsgBox("OrderIDReport : " & OrderIDReport)
        
        'Load data to DataSet 2
        Me.DataTableTableAdapter.Fill(Me.DataSet2.DataTable)
        Me.ReportViewer1.RefreshReport()

        Call ReportStrukDefine()
    End Sub



    Public Sub ReportStrukDefine()
        Call ConnectDB()

        'Define RDLC Report file Path
        ReportViewer1.LocalReport.ReportPath = "C:\Users\Administrator\documents\visual studio 2010\Projects\Manajemen_WarungMakanBuAnis\Manajemen_WarungMakanBuAnis\ReportStrukTransaksi.rdlc"

        'Get Total Tagihan
        Cmd = New OdbcCommand("SELECT SUM(produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas) AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID =  " & OrderIDReport & "", Conn)
        Dim TotalTagihan As Integer = Cmd.ExecuteScalar

        Cmd = New OdbcCommand("SELECT Tunai FROM daftar_transaksi WHERE OrderID =  " & OrderIDReport & "", Conn)
        Dim Tunai As Integer = Cmd.ExecuteScalar
        Dim Kembali As Integer = Tunai - TotalTagihan
        Dim IDTransaksi As Integer = OrderIDReport
        Dim KodePembayaran As String = "-" 'Not Implemented Yet

        Cmd = New OdbcCommand("SELECT TransaksiDate FROM daftar_transaksi WHERE OrderID =  " & OrderIDReport & "", Conn)
        Dim TglTransaksi = Convert.ToString(Cmd.ExecuteScalar)


        'Filling TextBox in the report
        Dim Parm1 As New ReportParameter("TotalTagihanValue", "Total Harga : " & TotalTagihan)
        ReportViewer1.LocalReport.SetParameters(Parm1)
        Dim Parm2 As New ReportParameter("TunaiValue", "Tunai : " & TotalTagihan)
        ReportViewer1.LocalReport.SetParameters(Parm2)
        Dim Parm3 As New ReportParameter("KembalianValue", "Kembali : " & Kembali)
        ReportViewer1.LocalReport.SetParameters(Parm3)
        Dim Parm4 As New ReportParameter("IDTransaksiValue", IDTransaksi)
        ReportViewer1.LocalReport.SetParameters(Parm4)
        Dim Parm5 As New ReportParameter("KodePembayaranValue", KodePembayaran)
        ReportViewer1.LocalReport.SetParameters(Parm5)
        Dim Parm6 As New ReportParameter("TglTransaksiValue", TglTransaksi)
        ReportViewer1.LocalReport.SetParameters(Parm6)


        'Get ProdukList
        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk, daftar_pesanan_detail.Kuantitas, produk_daftar.HargaSatuan, produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & OrderIDReport & "", Conn)
        Dim dt As New DataTable

        'Filling the table 
        Dim DataAdapter As New OdbcDataAdapter(Cmd)
        DataAdapter.Fill(dt)
        With Me.ReportViewer1.LocalReport
            .DataSources.Clear()
            '.ReportPath = "C:\Users\Administrator\documents\visual studio 2010\Projects\Manajemen_WarungMakanBuAnis\Manajemen_WarungMakanBuAnis\ReportStrukTransaksi.rdlc"
            .DataSources.Add(New ReportDataSource("DataSet1", dt))
        End With

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class