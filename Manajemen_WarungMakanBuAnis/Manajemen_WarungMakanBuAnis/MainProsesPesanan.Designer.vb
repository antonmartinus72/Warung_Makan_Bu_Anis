<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainProsesPesanan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbCustomerNameValue = New System.Windows.Forms.Label()
        Me.LbCustomerIDValue = New System.Windows.Forms.Label()
        Me.LbCustomerName = New System.Windows.Forms.Label()
        Me.LbCustomerID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LbPesananTagihan = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LbPesananTagihanValue = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ListViewProsesPesanan = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnAddKeranjang = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LbCustomerNameValue)
        Me.Panel1.Controls.Add(Me.LbCustomerIDValue)
        Me.Panel1.Controls.Add(Me.LbCustomerName)
        Me.Panel1.Controls.Add(Me.LbCustomerID)
        Me.Panel1.Location = New System.Drawing.Point(-4, -5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1029, 119)
        Me.Panel1.TabIndex = 23
        '
        'LbCustomerNameValue
        '
        Me.LbCustomerNameValue.AutoSize = True
        Me.LbCustomerNameValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCustomerNameValue.ForeColor = System.Drawing.Color.White
        Me.LbCustomerNameValue.Location = New System.Drawing.Point(230, 67)
        Me.LbCustomerNameValue.Name = "LbCustomerNameValue"
        Me.LbCustomerNameValue.Size = New System.Drawing.Size(121, 29)
        Me.LbCustomerNameValue.TabIndex = 26
        Me.LbCustomerNameValue.Text = "xxxxxxxxx"
        '
        'LbCustomerIDValue
        '
        Me.LbCustomerIDValue.AutoSize = True
        Me.LbCustomerIDValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCustomerIDValue.ForeColor = System.Drawing.Color.White
        Me.LbCustomerIDValue.Location = New System.Drawing.Point(230, 27)
        Me.LbCustomerIDValue.Name = "LbCustomerIDValue"
        Me.LbCustomerIDValue.Size = New System.Drawing.Size(109, 29)
        Me.LbCustomerIDValue.TabIndex = 25
        Me.LbCustomerIDValue.Text = "xxxxxxxx"
        '
        'LbCustomerName
        '
        Me.LbCustomerName.AutoSize = True
        Me.LbCustomerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCustomerName.ForeColor = System.Drawing.Color.White
        Me.LbCustomerName.Location = New System.Drawing.Point(65, 67)
        Me.LbCustomerName.Name = "LbCustomerName"
        Me.LbCustomerName.Size = New System.Drawing.Size(152, 29)
        Me.LbCustomerName.TabIndex = 24
        Me.LbCustomerName.Text = "Atas Nama :"
        '
        'LbCustomerID
        '
        Me.LbCustomerID.AutoSize = True
        Me.LbCustomerID.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCustomerID.ForeColor = System.Drawing.Color.White
        Me.LbCustomerID.Location = New System.Drawing.Point(56, 27)
        Me.LbCustomerID.Name = "LbCustomerID"
        Me.LbCustomerID.Size = New System.Drawing.Size(160, 29)
        Me.LbCustomerID.TabIndex = 23
        Me.LbCustomerID.Text = "ID Pesanan :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 24)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Jumlah Produk :"
        '
        'LbPesananTagihan
        '
        Me.LbPesananTagihan.AutoSize = True
        Me.LbPesananTagihan.BackColor = System.Drawing.Color.Transparent
        Me.LbPesananTagihan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPesananTagihan.ForeColor = System.Drawing.Color.Black
        Me.LbPesananTagihan.Location = New System.Drawing.Point(75, 49)
        Me.LbPesananTagihan.Name = "LbPesananTagihan"
        Me.LbPesananTagihan.Size = New System.Drawing.Size(98, 24)
        Me.LbPesananTagihan.TabIndex = 28
        Me.LbPesananTagihan.Text = "Tagihan :"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Gold
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(-14, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1062, 45)
        Me.Panel2.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(269, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(525, 29)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Pesanan di simpan dengan status ""Pending"""
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(3, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(273, 18)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "*Cek pesanan pada tab ""Transaksi"""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(189, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 24)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "XXX"
        '
        'LbPesananTagihanValue
        '
        Me.LbPesananTagihanValue.AutoSize = True
        Me.LbPesananTagihanValue.BackColor = System.Drawing.Color.Transparent
        Me.LbPesananTagihanValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPesananTagihanValue.ForeColor = System.Drawing.Color.Black
        Me.LbPesananTagihanValue.Location = New System.Drawing.Point(189, 49)
        Me.LbPesananTagihanValue.Name = "LbPesananTagihanValue"
        Me.LbPesananTagihanValue.Size = New System.Drawing.Size(115, 24)
        Me.LbPesananTagihanValue.TabIndex = 33
        Me.LbPesananTagihanValue.Text = "XXXXXXX"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewProsesPesanan, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 193)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(997, 353)
        Me.TableLayoutPanel1.TabIndex = 34
        '
        'ListViewProsesPesanan
        '
        Me.ListViewProsesPesanan.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader1})
        Me.ListViewProsesPesanan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewProsesPesanan.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewProsesPesanan.FullRowSelect = True
        Me.ListViewProsesPesanan.Location = New System.Drawing.Point(0, 0)
        Me.ListViewProsesPesanan.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.ListViewProsesPesanan.MultiSelect = False
        Me.ListViewProsesPesanan.Name = "ListViewProsesPesanan"
        Me.ListViewProsesPesanan.Size = New System.Drawing.Size(498, 348)
        Me.ListViewProsesPesanan.TabIndex = 25
        Me.ListViewProsesPesanan.UseCompatibleStateImageBehavior = False
        Me.ListViewProsesPesanan.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Nama Produk"
        Me.ColumnHeader7.Width = 131
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Qty"
        Me.ColumnHeader8.Width = 58
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Harga"
        Me.ColumnHeader9.Width = 99
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Sub Total"
        Me.ColumnHeader1.Width = 119
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel3.Controls.Add(Me.LbPesananTagihanValue)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.LbPesananTagihan)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(498, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0, 0, 0, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(499, 350)
        Me.Panel3.TabIndex = 26
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.BtnAddKeranjang, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 257)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(499, 93)
        Me.TableLayoutPanel2.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(249, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 93)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Tutup"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BtnAddKeranjang
        '
        Me.BtnAddKeranjang.BackColor = System.Drawing.Color.MediumTurquoise
        Me.BtnAddKeranjang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BtnAddKeranjang.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddKeranjang.Location = New System.Drawing.Point(3, 0)
        Me.BtnAddKeranjang.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BtnAddKeranjang.Name = "BtnAddKeranjang"
        Me.BtnAddKeranjang.Size = New System.Drawing.Size(246, 93)
        Me.BtnAddKeranjang.TabIndex = 29
        Me.BtnAddKeranjang.Text = "Selesaikan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pembayaran"
        Me.BtnAddKeranjang.UseVisualStyleBackColor = False
        '
        'MainProsesPesanan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1021, 558)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainProsesPesanan"
        Me.Text = "MainProsesPesanan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbCustomerName As System.Windows.Forms.Label
    Friend WithEvents LbCustomerID As System.Windows.Forms.Label
    Friend WithEvents LbCustomerNameValue As System.Windows.Forms.Label
    Friend WithEvents LbCustomerIDValue As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LbPesananTagihan As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LbPesananTagihanValue As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ListViewProsesPesanan As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BtnAddKeranjang As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
