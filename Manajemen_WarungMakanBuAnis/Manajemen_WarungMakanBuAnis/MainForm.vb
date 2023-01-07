Imports System.Data.Odbc
Public Class MainForm
    Dim Conn As OdbcConnection
    Dim Cmd As OdbcCommand
    Dim Ds As DataSet
    Dim Da As OdbcDataAdapter
    Dim Rd As OdbcDataReader
    Dim MyDB As String

    Public Property TempLoginID As String  ' the value is stored in there, it can be any type
    Public Property NewOrderName As String
    'Public Property OrderIDReportParam As String

    '#############################################################################################################################

    'To Fix
    '______________________________________________

    'ListViewPending not showing Order with the same name
    '
    '

    '#############################################################################################################################

    Sub ConnectDB()
        MyDB = "Driver={MySQL ODBC 8.0 ANSI Driver};Database=warungmkn_buanis;Server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoginForm.Close()
        'TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
        Me.DataTable1TableAdapter.Fill(Me.DataSet2.DataTable1)
        Call ResetProdukField()
        'Call SearchListViewItemID()
        Call ShowDaftarProduk()
        Call ShowDaftarPesananPending()
        Call TempLogin()
        Call ShowStokProduk()
        Call ResetStokUbahForm()
        Call RefreshMainCards()

        Panel8.Enabled = False

        DateTimePickerPending.Value = DateTime.Now
        DateTimePickerPending2.Value = DateTime.Now
    End Sub

    Public Function TempLogin()
        'Temporary Login With UserID 1
        Dim TempLoginUserID As Integer = TempLoginID
        'Dim TempLoginUserID As Integer = 1



        Return TempLoginUserID

    End Function

    Public Sub ResetMain()
        LbIdProduk.Text = "XX"
        TxBoxNama.Text = ""
        TxBoxHarga.Text = 0
        TxBoxSubTotal.Text = 0
        NumBoxQty.Value = 1

        ListView2.Items.Clear()

        If LbCustomerName.Text = "Customer XX" Then
            Me.GroupBox1.Enabled = False
        End If


    End Sub

    Public Sub ResetProdukField()
        LbIdProduk.Text = "XX"
        TxBoxNama.Text = ""
        TxBoxHarga.Text = 0
        TxBoxSubTotal.Text = 0
        NumBoxQty.Value = 1


    End Sub

    Public Sub ShowDaftarProduk()
        Call ConnectDB()
        Cmd = New OdbcCommand("SELECT * FROM produk_daftar WHERE UserID = " & TempLogin() & "", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListView1.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListView1.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("TipePaketID"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("StokProduk"))
            End While
        Else
            ListView1.Items.Clear()

        End If

        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    Private Function ShowDaftarPesananPendingCmd(Optional ByVal DateFilter As Boolean = False)
        Dim DateFilterEnable = DateFilter
        'If DateFilterEnable = True Then
        '    DateFilterEnable = True
        'Else
        '    DateFilterEnable = False
        'End If
        Return DateFilterEnable
    End Function

    Public Sub ResetShowDaftarPesananPending()
        Call ConnectDB()

        'Time Filter

        'Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.MetodePembayaranID,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID GROUP BY NamaCustomer ORDER BY OrderID DESC;", Conn)

        DateTimePickerPending.Value = DateTime.Now
        DateTimePickerPending2.Value = DateTime.Now

        Call ShowDaftarPesananPending()

    End Sub



    Public Sub ShowDaftarPesananPending()
        Call ConnectDB()

        'Time Filter

            'Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.MetodePembayaranID,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID GROUP BY NamaCustomer ORDER BY OrderID DESC;", Conn)


        Dim DateStart As String = DateTimePickerPending.Value.ToString("yyyy/MM/dd")
        Dim DateEnd As String = DateTimePickerPending2.Value.ToString("yyyy/MM/dd")

        Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID AND DATE(q1.OrderDate) BETWEEN '" & DateStart & "' AND '" & DateEnd & "' GROUP BY OrderID ORDER BY OrderID DESC;", Conn)

        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewPending.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewPending.Items.Add(Rd("OrderID"))
                data.SubItems.Add(Rd("NamaCustomer"))
                data.SubItems.Add(Rd("OrderDate"))
                data.SubItems.Add(Rd("Tagihan"))

            End While
        Else
            ListViewPending.Items.Clear()
        End If



        ListViewPending.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPending.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewPending.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPending.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

    Public Sub ShowDaftarPesananPendingDetail()
        Call ConnectDB()

        ListViewPendingDetail.Items.Clear()

        Dim ProdukIDFromListPending = ListViewPending.SelectedItems(0).Text


        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)
        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk, daftar_pesanan_detail.Kuantitas, produk_daftar.HargaSatuan, produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & ProdukIDFromListPending & " ", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewPendingDetail.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewPendingDetail.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("Kuantitas"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("SubTotal"))

            End While
        Else
            ListViewPendingDetail.Items.Clear()

        End If

        LbJumlahPendingDetail.Text = "(" & "ID : " & ProdukIDFromListPending & ", " & ListViewPendingDetail.Items.Count & " Produk)"



        ListViewPendingDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPendingDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewPendingDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewPendingDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    Public Sub ResetShowDaftarPesananSukses()
        Call ConnectDB()

        'Time Filter

        'Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.MetodePembayaranID,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID GROUP BY NamaCustomer ORDER BY OrderID DESC;", Conn)

        DateTimePickerSukses.Value = DateTime.Now
        DateTimePickerSukses2.Value = DateTime.Now

        Call ShowDaftarPesananSukses()

    End Sub
    Public Sub ShowDaftarPesananSukses()
        Call ConnectDB()

        'Time Filter

        'Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.MetodePembayaranID,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID GROUP BY NamaCustomer ORDER BY OrderID DESC;", Conn)

        Dim DateStart As String = DateTimePickerSukses.Value.ToString("yyyy/MM/dd")
        Dim DateEnd As String = DateTimePickerSukses2.Value.ToString("yyyy/MM/dd")

        Cmd = New OdbcCommand("SELECT q1.OrderID,q1.NamaCustomer,q1.OrderDate,q1.UserID,q1.OrderStatusID,q1.OrderID, SUM(SubTotal) as Tagihan FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 2) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as SubTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID AND DATE(q1.OrderDate) BETWEEN '" & DateStart & "' AND '" & DateEnd & "' GROUP BY NamaCustomer ORDER BY OrderID DESC;", Conn)

        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewSukses.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewSukses.Items.Add(Rd("OrderID"))
                data.SubItems.Add(Rd("NamaCustomer"))
                data.SubItems.Add(Rd("OrderDate"))
                data.SubItems.Add(Rd("Tagihan"))

            End While
        Else
            ListViewSukses.Items.Clear()
        End If



        ListViewSukses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewSukses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewSukses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewSukses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    Public Sub ShowDaftarPesananSuksesDetail()
        Call ConnectDB()

        ListViewSuksesDetail.Items.Clear()

        Dim ProdukIDFromListSukses = ListViewSukses.SelectedItems(0).Text


        'Cmd = New OdbcCommand("SELECT * FROM (SELECT * FROM daftar_pesanan WHERE daftar_pesanan.OrderStatusID = 1) as q1, (SELECT daftar_pesanan_detail.OrderID,daftar_pesanan_detail.Kuantitas*produk_daftar.HargaSatuan as HargaTotal FROM daftar_pesanan_detail, produk_daftar WHERE daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID) as q2 WHERE q1.OrderID = q2.OrderID;", Conn)
        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk, daftar_pesanan_detail.Kuantitas, produk_daftar.HargaSatuan, produk_daftar.HargaSatuan * daftar_pesanan_detail.Kuantitas AS SubTotal FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & ProdukIDFromListSukses & " ", Conn)

        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewSuksesDetail.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewSuksesDetail.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("Kuantitas"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("SubTotal"))

            End While
        Else
            ListViewSuksesDetail.Items.Clear()

        End If

        LbJumlahSuksesDetail.Text = "(" & "ID : " & ProdukIDFromListSukses & ", " & ListViewSuksesDetail.Items.Count & " Produk)"



        ListViewSuksesDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewSuksesDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewSuksesDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewSuksesDetail.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub


    Public Sub ShowDataTextbox()


        NumBoxQty.Enabled = True
        LbIdProduk.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(0).Text
        TxBoxNama.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(1).Text
        TxBoxHarga.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
        TxBoxSubTotal.Text = ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text

        NumBoxQty.Value = 1

        'Selected Value Test


        Dim FileFound As Boolean
        For Each item As ListViewItem In ListView2.Items
            'the correct way to use item
            If item.Text = LbIdProduk.Text Then
                'MsgBox("the file exists in the listview")
                BtnAddKeranjang.Enabled = False
                BtnUpdateKeranjang.Enabled = True
                BtnRemoveKeranjang.Enabled = True

                'If the file is found then no need to continue with the loop
                'Set file found to true and drop out of the for loop
                FileFound = True

                For i = 0 To ListView2.Items.Count - 1
                    If ListView2.Items(i).SubItems(0).Text = LbIdProduk.Text Then
                        ListView2.Items(i).Selected = True

                    End If
                Next
                ListView2.Focus()
                'ListView2.Items(CInt(LbIdProduk.Text) - 1).Selected = True
                'ListView2.Select()

                Exit For
                'notice that we have no else statement here.
                'That's because we want to keep iterating through the listview
                'until we get to the end of the listview
            End If
        Next
        'this bit is new to test for the file not being found
        'As you can see above if the file is found then FileFound will
        'be set to true but if it was NOT set to true in the for loop
        'above then when you get here FileFound will be false and so
        'you can test for the file not being found here and deal
        'with it.
        If Not FileFound Then
            'MsgBox("the file DOESN'T exists in the listview")
            BtnAddKeranjang.Enabled = True
            BtnUpdateKeranjang.Enabled = False
            BtnRemoveKeranjang.Enabled = False
        End If

    End Sub

    Private Sub ShowDataTextboxKeranjang()
        NumBoxQty.Enabled = True
        LbIdProduk.Text = ListView2.Items(ListView2.FocusedItem.Index).SubItems(0).Text
        TxBoxNama.Text = ListView2.Items(ListView2.FocusedItem.Index).SubItems(1).Text
        TxBoxHarga.Text = ListView2.Items(ListView2.FocusedItem.Index).SubItems(3).Text
        TxBoxSubTotal.Text = ListView2.Items(ListView2.FocusedItem.Index).SubItems(3).Text
        NumBoxQty.Value = ListView2.Items(ListView2.FocusedItem.Index).SubItems(2).Text

        BtnAddKeranjang.Enabled = False
        BtnUpdateKeranjang.Enabled = True
        BtnRemoveKeranjang.Enabled = True

        'test
        'Label15.Text = ListView2.Items(ListView2.FocusedItem.Index).SubItems(0).Text

    End Sub

   

   

    

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Call ShowDataTextbox()

    End Sub

    Private Sub ListView1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListView1.KeyPress
        Call ShowDataTextbox()
        ' Call SearchListViewItemID()
    End Sub

    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Call ShowDataTextboxKeranjang()
        ' Call SearchListViewItemID()

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumBoxQty.ValueChanged
        Dim Harga As Integer = 0

        If NumBoxQty.Enabled = True Then
            'Harga = ListView1.Items(ListView1.FocusedItem.Index).SubItems(3).Text
            Harga = Convert.ToDecimal(TxBoxHarga.Text)
        End If

        TxBoxSubTotal.Text = NumBoxQty.Value * Harga
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddKeranjang.Click
        Dim arr(4) As String
        Dim itm As ListViewItem

        If LbIdProduk.Text = "" Or TxBoxNama.Text = "" Or TxBoxHarga.Text = 0 Or CInt(TxBoxSubTotal.Text) = 0 Or NumBoxQty.Value = 0 Then
            MsgBox("Field Tidak Boleh Kosong")
        Else
            arr(0) = LbIdProduk.Text
            arr(1) = TxBoxNama.Text
            arr(2) = NumBoxQty.Value
            arr(3) = TxBoxHarga.Text
            arr(4) = TxBoxSubTotal.Text
            itm = New ListViewItem(arr)
            ListView2.Items.Add(itm)

        End If

        Call ResetProdukField()

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateKeranjang.Click

        If ListView2.SelectedItems.Count > 0 Then
            ListView2.SelectedItems(0).SubItems(0).Text = LbIdProduk.Text
            ListView2.SelectedItems(0).SubItems(1).Text = TxBoxNama.Text
            ListView2.SelectedItems(0).SubItems(2).Text = NumBoxQty.Value
            ListView2.SelectedItems(0).SubItems(3).Text = TxBoxHarga.Text
            ListView2.SelectedItems(0).SubItems(4).Text = TxBoxSubTotal.Text

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Call ResetProdukField()

    End Sub


    'Private Sub BtnAddOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MainCustomerAdd.Show()

    '    'LbCustomerName.Text = NewOrderName
    '    'MainCustomerAdd.Close()
    '    'Dim CustomerName As String = MainCustomerAdd.TextBox1.Text
    'End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResetMain()
    End Sub

    Private Sub BtnRemoveKeranjang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemoveKeranjang.Click
        For Each i As ListViewItem In ListView2.SelectedItems
            ListView2.Items.Remove(i)
        Next

        If ListView2.Items.Count > 0 Then
            ButtonSimpanPesanan.Enabled = True
        Else
            ButtonSimpanPesanan.Enabled = False

        End If

    End Sub


    Private Sub TabPage3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage3.GotFocus
        Call ShowDaftarPesananPending()
    End Sub

    Private Sub ListView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ListView2.Items.Count > 0 Then
            ButtonSimpanPesanan.Enabled = True
        Else
            ButtonSimpanPesanan.Enabled = False
        End If
        ButtonSimpanPesanan.Enabled = True
    End Sub

    Public Function GetOrderId(ByVal getCmd)
        Cmd = getCmd
        Dim GetIdFromRow As Object = Cmd.ExecuteScalar() 'get single row

        Return GetIdFromRow

    End Function

    Private Sub ButtonSimpanPesanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPesanan.Click
        Call ConnectDB()
        Call TempLogin()
        Dim TimeNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")

        'Bikin ID pesanan
        Cmd = New OdbcCommand("INSERT INTO daftar_pesanan (NamaCustomer, OrderDate, UserID, OrderStatusID) VALUES ('" & LbCustomerName.Text & "', '" & TimeNow & "','" & TempLogin() & "','1')", Conn)
        Cmd.ExecuteNonQuery()


        ''Ambil ID pesanan
        Cmd = New OdbcCommand("SELECT OrderID FROM daftar_pesanan WHERE NamaCustomer = '" & LbCustomerName.Text & "' AND OrderDate = '" & TimeNow & "'", Conn)
        Dim OrderIDValue = GetOrderId(Cmd)
        MainProsesPesanan.LbCustomerIDValue.Text = OrderIDValue


        ''Rd = Cmd.ExecuteReader()
        'Dim OrderIDValue As Object = Cmd.ExecuteScalar()


        For Each LVKeranjangItem As ListViewItem In ListView2.Items
            Cmd = New OdbcCommand("INSERT INTO daftar_pesanan_detail (OrderID, ProdukID, Kuantitas) VALUES ('" & OrderIDValue & "', '" & CInt(LVKeranjangItem.SubItems(0).Text) & "', '" & CInt(LVKeranjangItem.SubItems(2).Text) & "')", Conn)
            Cmd.ExecuteNonQuery()
        Next

        MsgBox("Executed, " & OrderIDValue & "")


        Call MainProsesPesanan.ShowDialog()


    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call MainProsesPesanan.Show()

    End Sub


    Private Sub BtnDatePending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDatePending.Click
        'ShowDaftarPesananPendingCmd(True)
        ListViewPending.Items.Clear()
        ShowDaftarPesananPending()


        Dim DateStart As Date = Format(DateTimePickerPending.Value, "yyyy/MM/dd")
        Dim DateEnd As Date = Format(DateTimePickerPending2.Value, "yyyy/MM/dd")
        MsgBox("Mulai : " & DateStart.ToString("yyyy/MM/dd") & " End : " & DateEnd.ToString("yyyy/MM/dd"))

    End Sub

    Private Sub BtnDateSukses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDateSukses.Click


        'ShowDaftarPesananPendingCmd(True)
        ListViewSukses.Items.Clear()
        ShowDaftarPesananSukses()


        Dim DateStart As Date = Format(DateTimePickerPending.Value, "yyyy/MM/dd")
        Dim DateEnd As Date = Format(DateTimePickerPending2.Value, "yyyy/MM/dd")
        MsgBox("Mulai : " & DateStart.ToString("yyyy/MM/dd") & " End : " & DateEnd.ToString("yyyy/MM/dd"))

    End Sub

    Private Sub ListViewPendingDetailLoad()
        Call ConnectDB()


        Dim OrID = ListViewPending.Items(ListViewPending.FocusedItem.Index).SubItems(0).Text
        Dim PrID = ListViewPendingDetail.Items(ListViewPendingDetail.FocusedItem.Index).SubItems(0).Text

        Cmd = New OdbcCommand("SELECT daftar_pesanan_detail.OrderID, daftar_pesanan_detail.ProdukID, produk_daftar.NamaProduk , daftar_pesanan_detail.Kuantitas FROM daftar_pesanan_detail JOIN produk_daftar ON daftar_pesanan_detail.ProdukID = produk_daftar.ProdukID WHERE daftar_pesanan_detail.OrderID = " & OrID & " AND produk_daftar.ProdukID = " & PrID & "", Conn)
        Rd = Cmd.ExecuteReader()

        If Rd.HasRows Then
            ListView1.Items.Clear()
            While Rd.Read
                LbPendingUbahIDValue.Text = Rd("ProdukID")
                LbPendingUbahNama.Text = Rd("NamaProduk")
                'NumericUpDownPendingUbahQty.Value = Rd("Kuantitas")
            End While
        Else
            LbPendingUbahID.ResetText()
            LbPendingUbahID.ResetText()
            'NumericUpDownPendingUbahQty.ResetText()

        End If

        Panel8.Enabled = True
        'NumericUpDownPendingUbahQty.Enabled = True


    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'For Each LVPendingDetail As ListViewItem In ListViewPendingDetail.Items
        '    Cmd = New OdbcCommand("INSERT INTO daftar_pesanan_detail (OrderID, ProdukID, Kuantitas) VALUES ('" & OrderIDValue & "', '" & CInt(LVKeranjangItem.SubItems(0).Text) & "', '" & CInt(LVKeranjangItem.SubItems(2).Text) & "')", Conn)
        '    Cmd.ExecuteNonQuery()
        'Next
    End Sub

    Private Sub DeletePendingDetailProduct()

        Dim getOrderPendingID = ListViewPending.Items(ListViewPending.FocusedItem.Index).SubItems(0).Text
        Dim getOrderPendingDetailProdukID = ListViewPendingDetail.Items(ListViewPendingDetail.FocusedItem.Index).SubItems(0).Text

        Call ConnectDB()
        Cmd = New OdbcCommand("DELETE FROM daftar_pesanan_detail WHERE OrderID='" & getOrderPendingID & "' AND ProdukID = '" & getOrderPendingDetailProdukID & "';", Conn)
        Cmd.ExecuteNonQuery()

        MsgBox("Produk ID :" & getOrderPendingDetailProdukID & ", with OrderID : " & getOrderPendingID & "is DELETED")


    End Sub

    Private Sub DeletePending()


        Dim getOrderPendingID = ListViewPending.Items(ListViewPending.FocusedItem.Index).SubItems(0).Text

        Dim result As DialogResult = MessageBox.Show("Hapus Pesanan " & getOrderPendingID & " ?", "Konfirmasi", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            Call ConnectDB()
            Cmd = New OdbcCommand("DELETE FROM daftar_pesanan WHERE OrderID='" & getOrderPendingID & "'", Conn)
            Cmd.ExecuteNonQuery()

            MsgBox("OrderID :" & getOrderPendingID & " is DELETED")
        End If

        ListViewPendingDetail.Items.Clear()
        ListViewPending.Items.Clear()

        Call ShowDaftarPesananPending()


    End Sub

    Private Sub BtnDatePendingReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDatePendingReset.Click
        ListViewPendingDetail.Items.Clear()
        ListViewPending.Items.Clear()
        'Call ShowDaftarPesananPending()
        Call ResetShowDaftarPesananPending()
    End Sub


    

    Private Sub BtnDateSuksesReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDateSuksesReset.Click
        ListViewSuksesDetail.Items.Clear()
        ListViewSukses.Items.Clear()
        'Call ShowDaftarPesananPending()
        Call ResetShowDaftarPesananSukses()
    End Sub

    Private Sub ListViewPending_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPending.DoubleClick
        ListViewPendingDetail.Items.Clear()
        Call ShowDaftarPesananPendingDetail()

        Panel8.Enabled = False
        'NumericUpDownPendingUbahQty.Enabled = False
    End Sub

    Private Sub ListViewSukses_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewSukses.DoubleClick
        ListViewSuksesDetail.Items.Clear()
        Call ShowDaftarPesananSuksesDetail()

        'Panel13.Enabled = False
    End Sub

    Private Sub ListViewPendingDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewPendingDetail.DoubleClick
        Call ListViewPendingDetailLoad()
    End Sub


    Private Sub BtnPendingDetailProdukDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPendingDetailProdukDelete.Click
        Dim result As DialogResult = MessageBox.Show("Hapus Produk dari Keranjang?", "Konfirmasi", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            Call DeletePendingDetailProduct()
        End If

        ListViewPendingDetail.Items.Clear()
        Call ShowDaftarPesananPendingDetail()

    End Sub
  
    Private Sub BtnDeletePending_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeletePending.Click
        Call DeletePending()
        ListViewPending.Items.Clear()
        ListViewPendingDetail.Items.Clear()
        Call ShowDaftarPesananPending()
    End Sub

    Public Function GenerateReportStruk(ByVal FormName)


        If FormName = "PembayaranStruk" Then
            Dim OBJ As New MainTransaksi
            If ListViewPending.SelectedItems.Count < 1 Then
                Dim result As DialogResult = MessageBox.Show("Pesanan belum dipilih?", "Peringatan!", MessageBoxButtons.OK)
                'MsgBox("Pilih pesanan terlebih dahulu!")
            Else
                OBJ.OrderIDFromMain = ListViewPending.Items(ListViewPending.FocusedItem.Index).SubItems(0).Text
                MainTransaksi.Enabled = True
                OBJ.ShowDialog()

            End If
        ElseIf FormName = "SuksesStruk" Then
            Dim OBJ As New ReportStrukTransaksi
            If ListViewSukses.SelectedItems.Count < 1 Then
                Dim result As DialogResult = MessageBox.Show("Pesanan belum dipilih?", "Peringatan!", MessageBoxButtons.OK)
                'MsgBox("Pilih pesanan terlebih dahulu!")
            Else
                OBJ.OrderIDReport = ListViewSukses.Items(ListViewSukses.FocusedItem.Index).SubItems(0).Text
                'OBJ.OrderIDReportParam = "SuksesStruk"
                MainTransaksi.Enabled = True
                OBJ.ShowDialog()

            End If
        End If

        Return Nothing
    End Function

    'Public Sub GenerateReportStruks()

    '    Dim OBJ As New MainTransaksi

    '    If ListViewPending.SelectedItems.Count < 1 Then
    '        Dim result As DialogResult = MessageBox.Show("Pesanan belum dipilih?", "Peringatan!", MessageBoxButtons.OK)
    '        'MsgBox("Pilih pesanan terlebih dahulu!")
    '    Else
    '        OBJ.OrderIDFromMain = ListViewPending.Items(ListViewPending.FocusedItem.Index).SubItems(0).Text
    '        MainTransaksi.Enabled = True
    '        OBJ.ShowDialog()

    '    End If
    '    'OBJ.StringPass = ListViewPending.SelectedItems(0).Text
    '    'Me.Hide()
    'End Sub

    Private Sub BtnPembayaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPembayaran.Click
        GenerateReportStruk("PembayaranStruk")
    End Sub
    Private Sub BtnSuksesCetakStruk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuksesCetakStruk.Click
        GenerateReportStruk("SuksesStruk")
    End Sub


    'Public Sub RefreshStokProduk()
    '    Call ShowStokProduk()
    '    NumericUpDownUbahQty.Value = 1
    'End Sub

    Public Sub ShowStokProduk()
        Cmd = New OdbcCommand("SELECT ProdukID, NamaProduk, HargaSatuan, StokProduk FROM produk_daftar WHERE UserID = " & TempLogin() & "", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ListViewUbahProduk.Items.Clear()
            ListViewTambahProduk.Items.Clear()
            While Rd.Read
                Dim data As ListViewItem = ListViewUbahProduk.Items.Add(Rd("ProdukID"))
                data.SubItems.Add(Rd("NamaProduk"))
                data.SubItems.Add(Rd("HargaSatuan"))
                data.SubItems.Add(Rd("StokProduk"))

                Dim data2 As ListViewItem = ListViewTambahProduk.Items.Add(Rd("ProdukID"))
                data2.SubItems.Add(Rd("NamaProduk"))
                data2.SubItems.Add(Rd("HargaSatuan"))
                data2.SubItems.Add(Rd("StokProduk"))

            End While
        Else
            ListViewUbahProduk.Items.Clear()
            ListViewTambahProduk.Items.Clear()

        End If


        ListViewUbahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewUbahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewUbahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewUbahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        ListViewTambahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewTambahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        ListViewTambahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListViewTambahProduk.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

    End Sub

    Private Sub GetProdukTipe()

        Cmd = New OdbcCommand("SELECT NamaTipePaket FROM produk_tipe_paket", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ComboBoxUbahTipeProduk.Items.Clear()
            ComboBoxTambahTipeProduk.Items.Clear()

            While Rd.Read
                ComboBoxUbahTipeProduk.Items.Add(Rd("NamaTipePaket"))
                ComboBoxTambahTipeProduk.Items.Add(Rd("NamaTipePaket"))
            End While
        End If


        'Call ResetStokUbahForm()
    End Sub


    Private Sub GetSupplierList()

        Cmd = New OdbcCommand("SELECT SupplierName FROM produk_stock_supplier", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            ComboBoxUbahSupplier.Items.Clear()

            While Rd.Read
                ComboBoxUbahSupplier.Items.Add(Rd("SupplierName"))
            End While
        End If


        'Call ResetStokUbahForm()
    End Sub

    Private Sub ResetStokUbahForm()
        Call ShowStokProduk()
        Call GetProdukTipe()
        Call GetSupplierList()
        NumericUpDownUbahQty.Value = 0
        NumericUpDownUbahQty.Enabled = False
        BtnSimpanUbahStock.Enabled = False
        LbSelectedUbahProduk.Text = "(ID : - , Nama Produk)"
        PanelUbahProduk.Enabled = False
        GroupBox4.Enabled = False

        ComboBoxUbahTipeProduk.Enabled = False


        TextBoxTambahNamaProduk.Text = ""
        NumericUpDownTambahHarga.Value = 1
        NumericUpDownTambahQty.Value = 0
        ComboBoxTambahTipeProduk.Text = ""
        ComboBoxUbahSupplier.Text = ""

    End Sub


    Private Sub BtnUbahProdukReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbahProdukReset.Click
        ShowStokProduk()
        ResetStokUbahForm()

    End Sub


    Private Sub ListViewUbahProduk_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewUbahProduk.DoubleClick

        'Qty Section
        RadioButtonAddProduk.Checked = True

        LbSelectedUbahProduk.Text = "(ID : " & ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(0).Text & ", " & ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(1).Text & ")"
        NumericUpDownUbahBefore.Value = ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(3).Text

        NumericUpDownUbahQty.Value = 0
        NumericUpDownUbahQty.Enabled = True
        BtnSimpanUbahStock.Enabled = True

        'Product Info Section

      


        TextBoxUbahNama.Text = ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(1).Text
        NumericUpDownUbahHarga.Value = ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(2).Text
        'Get Produk Tipe
        Call GetProdukTipe()

        '------
        PanelUbahProduk.Enabled = True
        CheckBoxKonfirmUbahTipeProduk.Checked = False
        

    End Sub

    Private Sub RadioButtonAddProduk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAddProduk.CheckedChanged
        NumericUpDownUbahQty.Value = 0
        LbUbahQtyAfter.Text = "Qty setelah di tambah :"
        'NumericUpDownUbahAfter.Value = 0
        NumericUpDownUbahQty.Enabled = True


    End Sub

    Private Sub RadioButtoneDecrProduk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtoneDecrProduk.CheckedChanged

        If NumericUpDownUbahBefore.Value = 0 And RadioButtoneDecrProduk.Checked = True Then
            NumericUpDownUbahQty.Enabled = False
            BtnSimpanUbahStock.Enabled = False
            MsgBox("Kuantitas tidak dapat dikurangi lagi")

        Else
            NumericUpDownUbahQty.Enabled = True
            BtnSimpanUbahStock.Enabled = True
            NumericUpDownUbahQty.Value = 0
            LbUbahQtyAfter.Text = "Qty setelah di kurangi :"

        End If
        



    End Sub

    Private Sub SaveStockProduk()

        If ListViewUbahProduk.SelectedItems.Count < 1 Then
            MsgBox("Silahkan klik ulang produk")
            Call ShowStokProduk()
        Else
            Dim SelectedID As Integer = ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(0).Text
            Dim QtyCurrent As Integer = Convert.ToInt32(ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(3).Text)
            Dim QtyChange As Integer = NumericUpDownUbahQty.Value
            Dim QtyAfterCal As Integer = 0

            If RadioButtonAddProduk.Checked = True Then
                'Add Qty
                QtyAfterCal = QtyCurrent + NumericUpDownUbahQty.Value
            ElseIf RadioButtoneDecrProduk.Checked = True Then
                'Decrease Qty
                QtyAfterCal = QtyCurrent - NumericUpDownUbahQty.Value
            Else
                MsgBox("No Query")
            End If

            Dim result As DialogResult = MessageBox.Show("Perbarui stok produk?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                Cmd = New OdbcCommand("UPDATE `produk_daftar` SET `StokProduk`='" & QtyAfterCal & "' WHERE ProdukID = " & SelectedID & "", Conn)
                Cmd.ExecuteNonQuery()
            End If

            Call ResetStokUbahForm()
            'Call RefreshStokProduk()
        End If


    End Sub

    Private Sub SaveInfoProduk()
        Dim SelectedID As Integer = ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(0).Text
        Dim NameChange As String = TextBoxUbahNama.Text
        Dim HargaSatuan As Integer = NumericUpDownUbahHarga.Value

        If CheckBoxKonfirmUbahTipeProduk.Checked = True And ComboBoxUbahTipeProduk.Text <> "" Then
            Dim TipeProduk = ComboBoxUbahTipeProduk.Text.ToString

            Cmd = New OdbcCommand("UPDATE `produk_daftar` SET `NamaProduk`='" & NameChange & "', `HargaSatuan`='" & HargaSatuan & "' , `TipePaketID`= (SELECT produk_tipe_paket.TipePaketID FROM produk_tipe_paket WHERE produk_tipe_paket.NamaTipePaket = '" & TipeProduk & "')  WHERE ProdukID = " & SelectedID & ";", Conn)
        Else
            Cmd = New OdbcCommand("UPDATE `produk_daftar` SET `NamaProduk`='" & NameChange & "', `HargaSatuan`='" & HargaSatuan & "' WHERE ProdukID = '" & SelectedID & "';", Conn)
        End If


        Cmd.ExecuteNonQuery()

        Call ResetStokUbahForm()
    End Sub



    Private Sub BtnSimpanUbahStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpanUbahStock.Click
        Call SaveStockProduk()
        BtnSimpanUbahStock.Enabled = False
    End Sub

    Private Sub NumericUpDownUbahQty_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownUbahQty.ValueChanged
        If RadioButtonAddProduk.Checked Then
            NumericUpDownUabahAfter.Value = NumericUpDownUbahQty.Value + NumericUpDownUbahBefore.Value

            NumericUpDownUbahQty.Maximum = 1000 - NumericUpDownUbahBefore.Value

            If NumericUpDownUabahAfter.Value > 1000 Then
                MsgBox("Batas kuantitas setelah ditambah adalah 1000")
            End If
            'If NumericUpDownUabahAfter.Value > 1000 Then
            '    MsgBox("Batas kuantitas setelah ditambah adalah 1000")
            '    NumericUpDownUabahAfter.Value = 1000
            '    NumericUpDownUabahAfter.Value = NumericUpDownUabahAfter.Value - NumericUpDownUbahBefore.Value
            'End If

        ElseIf RadioButtoneDecrProduk.Checked Then
            NumericUpDownUabahAfter.Value = NumericUpDownUbahBefore.Value - NumericUpDownUbahQty.Value
            NumericUpDownUbahQty.Maximum = NumericUpDownUbahBefore.Value

            If NumericUpDownUabahAfter.Value = 0 Then
                MsgBox("Kuantitas tidak dapat dikurangi lagi")
            End If
        End If


    End Sub


    'IN PROGREES
    Public Sub SaveTambahProduk()
        Dim NameAdd = TextBoxTambahNamaProduk.Text
        Dim PriceAdd As Integer = NumericUpDownTambahHarga.Value
        Dim QtyAdd As Integer = NumericUpDownTambahQty.Value
        Dim TipeProduk As String = ComboBoxTambahTipeProduk.Text
        Dim Supplier As String = ComboBoxUbahSupplier.Text


        If TextBoxTambahNamaProduk.Text = "" Or ComboBoxTambahTipeProduk.Text = "" Or ComboBoxUbahSupplier.Text = "" Then
            MsgBox("Filed harus di isi.")
        Else
            Cmd = New OdbcCommand("INSERT INTO `produk_daftar`(`NamaProduk`, `TipePaketID`, `HargaSatuan`, `StokProduk`, `UserID`) VALUES ('" & NameAdd & "',(SELECT produk_tipe_paket.TipePaketID FROM produk_tipe_paket WHERE produk_tipe_paket.NamaTipePaket = '" & TipeProduk & "'),'" & PriceAdd & "','" & QtyAdd & "','" & TempLogin() & "');", Conn)
            Cmd.ExecuteNonQuery()

            MsgBox("Produk di Tambah")
            'Call ShowDaftarProduk()
            'Call ShowStokProduk()
            Call ResetStokUbahForm()
        End If

        
    End Sub


    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(Convert.ToInt32(ListViewUbahProduk.Items(ListViewUbahProduk.FocusedItem.Index).SubItems(3).Text) + NumericUpDownUbahQty.Value)
    End Sub



    'Private Sub RadioButtoneDecrProduk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtoneDecrProduk.Click
    '    If NumericUpDownUabahAfter.Value = 0 Then
    '        MsgBox("Kuantitas tidak dapat dikurangi lagi")
    '        'RadioButtoneDecrProduk.Checked = False
    '        RadioButtonAddProduk.Checked = True
    '    End If

    'End Sub

    Private Sub BtnUbahProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbahProduk.Click
        Dim result As DialogResult = MessageBox.Show("Ubah Informasi Produk ?", "Konfirmasi", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            Call SaveInfoProduk()
            Call ShowDaftarProduk()
        End If



    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxKonfirmUbahTipeProduk.CheckedChanged
        If CheckBoxKonfirmUbahTipeProduk.Checked = True Then
            ComboBoxUbahTipeProduk.Enabled = True
        Else
            ComboBoxUbahTipeProduk.Enabled = False
        End If
    End Sub


    Private Sub BtnTambahProdukReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambahProdukReset.Click
        Call ResetStokUbahForm()
    End Sub


    Private Sub BtnTambahProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambahProduk.Click
        SaveTambahProduk()
    End Sub

    Public Sub HapusTambahProduk()
        Dim result As DialogResult = MessageBox.Show("Hapus Produk ?", "Konfirmasi", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            Dim ProdukID = ListViewTambahProduk.Items(ListViewTambahProduk.FocusedItem.Index).SubItems(0).Text
            Cmd = New OdbcCommand("DELETE FROM `produk_daftar` WHERE ProdukID = " & ProdukID & ";", Conn)
            Cmd.ExecuteNonQuery()
        End If

    End Sub

    Private Sub ListViewTambahProduk_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListViewTambahProduk.DoubleClick
        'Qty Section
        LbSelectedTambahProduk.Text = "(ID : " & ListViewTambahProduk.Items(ListViewTambahProduk.FocusedItem.Index).SubItems(0).Text & ", " & ListViewTambahProduk.Items(ListViewTambahProduk.FocusedItem.Index).SubItems(1).Text & ")"
        LbSelectedTambahProduk2.Text = "(ID : " & ListViewTambahProduk.Items(ListViewTambahProduk.FocusedItem.Index).SubItems(0).Text & ", " & ListViewTambahProduk.Items(ListViewTambahProduk.FocusedItem.Index).SubItems(1).Text & ")"

        GroupBox4.Enabled = True

    End Sub



    Private Sub BtnTambahHapusProduk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTambahHapusProduk.Click
        Call HapusTambahProduk()
        Call ResetStokUbahForm()
    End Sub

    Private Sub Button1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoginForm.Close()
    End Sub

    Private Sub RefreshMainCards()
        Cmd = New OdbcCommand("SELECT Username FROM user_login WHERE UserID = '" & TempLogin() & "';", Conn)
        LbBreadUserName.Text = Cmd.ExecuteScalar


        Cmd = New OdbcCommand("SELECT COUNT(OrderID) FROM daftar_pesanan WHERE UserID = " & TempLogin() & ";", Conn)
        LbBreadTotalOrder.Text = Cmd.ExecuteScalar


        Cmd = New OdbcCommand("SELECT COUNT(OrderID) FROM daftar_pesanan WHERE OrderStatusID = 1 AND UserID = " & TempLogin() & ";", Conn)
        LbBreadTotalPending.Text = Cmd.ExecuteScalar


        Cmd = New OdbcCommand("SELECT COUNT(OrderID) FROM daftar_pesanan WHERE OrderStatusID = 2 AND UserID = " & TempLogin() & ";", Conn)
        LbBreadTotalSukses.Text = Cmd.ExecuteScalar



    End Sub

 
    Private Sub BtnAddOrder_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddOrder.Click
        TextBoxTempAddCustomer.Enabled = True
        BtnTempAddCustomer.Enabled = True
    End Sub

    Private Sub BtnTempAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTempAddCustomer.Click
        LbCustomerName.Text = TextBoxTempAddCustomer.Text
        TextBoxTempAddCustomer.Enabled = False
        BtnTempAddCustomer.Enabled = False

        GroupBox1.Enabled = True
        ButtonSimpanPesanan.Enabled = False
    End Sub

    'Private Sub d(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick

    'End Sub

    Private Sub ListView2_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
        ButtonSimpanPesanan.Enabled = True
    End Sub
End Class
