namespace AnKhangClinic;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblTenBenhNhan;
    private System.Windows.Forms.TextBox txtTenBenhNhan;
    private System.Windows.Forms.Label lblSDT;
    private System.Windows.Forms.TextBox txtSDT;
    private System.Windows.Forms.Label lblNgayKham;
    private System.Windows.Forms.DateTimePicker dtpNgayKham;
    private System.Windows.Forms.Label lblGioKham;
    private System.Windows.Forms.DateTimePicker dtpGioKham;
    private System.Windows.Forms.Label lblBacSi;
    private System.Windows.Forms.ComboBox cboBacSi;
    private System.Windows.Forms.Label lblTrangThai;
    private System.Windows.Forms.ComboBox cboTrangThai;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.ComboBox cboLocBacSi;
    private System.Windows.Forms.Button btnTimKiem;
    private System.Windows.Forms.Button btnQuanLyBacSi;

    private System.Windows.Forms.DataGridView dgvLichKham;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dgvCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

        lblTenBenhNhan = new System.Windows.Forms.Label();
        txtTenBenhNhan = new System.Windows.Forms.TextBox();
        lblSDT = new System.Windows.Forms.Label();
        txtSDT = new System.Windows.Forms.TextBox();
        lblNgayKham = new System.Windows.Forms.Label();
        dtpNgayKham = new System.Windows.Forms.DateTimePicker();
        lblGioKham = new System.Windows.Forms.Label();
        dtpGioKham = new System.Windows.Forms.DateTimePicker();
        lblBacSi = new System.Windows.Forms.Label();
        cboBacSi = new System.Windows.Forms.ComboBox();
        lblTrangThai = new System.Windows.Forms.Label();
        cboTrangThai = new System.Windows.Forms.ComboBox();

        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();

        lblTuNgay = new System.Windows.Forms.Label();
        dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        lblDenNgay = new System.Windows.Forms.Label();
        dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        cboLocBacSi = new System.Windows.Forms.ComboBox();
        btnTimKiem = new System.Windows.Forms.Button();
        btnQuanLyBacSi = new System.Windows.Forms.Button();

        dgvLichKham = new System.Windows.Forms.DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
        SuspendLayout();

        // 
        // lblTenBenhNhan
        // 
        lblTenBenhNhan.AutoSize = true;
        lblTenBenhNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTenBenhNhan.Location = new System.Drawing.Point(30, 25);
        lblTenBenhNhan.Name = "lblTenBenhNhan";
        lblTenBenhNhan.Size = new System.Drawing.Size(111, 21);
        lblTenBenhNhan.TabIndex = 0;
        lblTenBenhNhan.Text = "Tên bệnh nhân";

        // 
        // txtTenBenhNhan
        // 
        txtTenBenhNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtTenBenhNhan.Location = new System.Drawing.Point(145, 22);
        txtTenBenhNhan.Name = "txtTenBenhNhan";
        txtTenBenhNhan.PlaceholderText = "Nhập tên bệnh nhân...";
        txtTenBenhNhan.Size = new System.Drawing.Size(240, 29);
        txtTenBenhNhan.TabIndex = 1;

        // 
        // lblSDT
        // 
        lblSDT.AutoSize = true;
        lblSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblSDT.Location = new System.Drawing.Point(30, 68);
        lblSDT.Name = "lblSDT";
        lblSDT.Size = new System.Drawing.Size(101, 21);
        lblSDT.TabIndex = 2;
        lblSDT.Text = "Số điện thoại";

        // 
        // txtSDT
        // 
        txtSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtSDT.Location = new System.Drawing.Point(145, 65);
        txtSDT.Name = "txtSDT";
        txtSDT.PlaceholderText = "Nhập số điện thoại...";
        txtSDT.Size = new System.Drawing.Size(185, 29);
        txtSDT.TabIndex = 3;

        // 
        // lblNgayKham
        // 
        lblNgayKham.AutoSize = true;
        lblNgayKham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblNgayKham.Location = new System.Drawing.Point(30, 111);
        lblNgayKham.Name = "lblNgayKham";
        lblNgayKham.Size = new System.Drawing.Size(89, 21);
        lblNgayKham.TabIndex = 4;
        lblNgayKham.Text = "Ngày khám";

        // 
        // dtpNgayKham
        // 
        dtpNgayKham.CustomFormat = "dd/MM/yyyy";
        dtpNgayKham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpNgayKham.Location = new System.Drawing.Point(145, 108);
        dtpNgayKham.Name = "dtpNgayKham";
        dtpNgayKham.Size = new System.Drawing.Size(185, 29);
        dtpNgayKham.TabIndex = 5;

        // 
        // lblGioKham
        // 
        lblGioKham.AutoSize = true;
        lblGioKham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblGioKham.Location = new System.Drawing.Point(345, 68);
        lblGioKham.Name = "lblGioKham";
        lblGioKham.Size = new System.Drawing.Size(76, 21);
        lblGioKham.TabIndex = 6;
        lblGioKham.Text = "Giờ khám";

        // 
        // dtpGioKham
        // 
        dtpGioKham.CustomFormat = "HH:mm";
        dtpGioKham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpGioKham.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpGioKham.Location = new System.Drawing.Point(345, 108);
        dtpGioKham.Name = "dtpGioKham";
        dtpGioKham.ShowUpDown = true;
        dtpGioKham.Size = new System.Drawing.Size(120, 29);
        dtpGioKham.TabIndex = 7;

        // 
        // lblBacSi
        // 
        lblBacSi.AutoSize = true;
        lblBacSi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblBacSi.Location = new System.Drawing.Point(490, 68);
        lblBacSi.Name = "lblBacSi";
        lblBacSi.Size = new System.Drawing.Size(51, 21);
        lblBacSi.TabIndex = 8;
        lblBacSi.Text = "Bác sĩ";

        // 
        // cboBacSi
        // 
        cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboBacSi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboBacSi.FormattingEnabled = true;
        cboBacSi.Location = new System.Drawing.Point(490, 108);
        cboBacSi.Name = "cboBacSi";
        cboBacSi.Size = new System.Drawing.Size(260, 29);
        cboBacSi.TabIndex = 9;

        // 
        // lblTrangThai
        // 
        lblTrangThai.AutoSize = true;
        lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTrangThai.Location = new System.Drawing.Point(770, 68);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new System.Drawing.Size(79, 21);
        lblTrangThai.TabIndex = 10;
        lblTrangThai.Text = "Trạng thái";

        // 
        // cboTrangThai
        // 
        cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboTrangThai.FormattingEnabled = true;
        cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
        cboTrangThai.Location = new System.Drawing.Point(770, 108);
        cboTrangThai.Name = "cboTrangThai";
        cboTrangThai.Size = new System.Drawing.Size(160, 29);
        cboTrangThai.TabIndex = 11;

        // 
        // btnThem
        // 
        btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(670, 22);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(75, 34);
        btnThem.TabIndex = 12;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
        btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnSua.Location = new System.Drawing.Point(755, 22);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(75, 34);
        btnSua.TabIndex = 13;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXoa.Location = new System.Drawing.Point(840, 22);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(75, 34);
        btnXoa.TabIndex = 14;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnLamMoi.Location = new System.Drawing.Point(925, 22);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(85, 34);
        btnLamMoi.TabIndex = 15;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // lblTuNgay
        // 
        lblTuNgay.AutoSize = true;
        lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTuNgay.Location = new System.Drawing.Point(30, 168);
        lblTuNgay.Name = "lblTuNgay";
        lblTuNgay.Size = new System.Drawing.Size(65, 21);
        lblTuNgay.TabIndex = 16;
        lblTuNgay.Text = "Từ ngày";

        // 
        // dtpTuNgay
        // 
        dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpTuNgay.Location = new System.Drawing.Point(105, 164);
        dtpTuNgay.Name = "dtpTuNgay";
        dtpTuNgay.Size = new System.Drawing.Size(130, 29);
        dtpTuNgay.TabIndex = 17;

        // 
        // lblDenNgay
        // 
        lblDenNgay.AutoSize = true;
        lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblDenNgay.Location = new System.Drawing.Point(245, 168);
        lblDenNgay.Name = "lblDenNgay";
        lblDenNgay.Size = new System.Drawing.Size(76, 21);
        lblDenNgay.TabIndex = 18;
        lblDenNgay.Text = "Đến ngày";

        // 
        // dtpDenNgay
        // 
        dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        dtpDenNgay.Location = new System.Drawing.Point(330, 164);
        dtpDenNgay.Name = "dtpDenNgay";
        dtpDenNgay.Size = new System.Drawing.Size(130, 29);
        dtpDenNgay.TabIndex = 19;

        // 
        // cboLocBacSi
        // 
        cboLocBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLocBacSi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboLocBacSi.FormattingEnabled = true;
        cboLocBacSi.Location = new System.Drawing.Point(475, 164);
        cboLocBacSi.Name = "cboLocBacSi";
        cboLocBacSi.Size = new System.Drawing.Size(240, 29);
        cboLocBacSi.TabIndex = 20;

        // 
        // btnTimKiem
        // 
        btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnTimKiem.Location = new System.Drawing.Point(725, 161);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new System.Drawing.Size(105, 35);
        btnTimKiem.TabIndex = 21;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;

        // 
        // btnQuanLyBacSi
        // 
        btnQuanLyBacSi.Cursor = System.Windows.Forms.Cursors.Hand;
        btnQuanLyBacSi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnQuanLyBacSi.Location = new System.Drawing.Point(845, 161);
        btnQuanLyBacSi.Name = "btnQuanLyBacSi";
        btnQuanLyBacSi.Size = new System.Drawing.Size(165, 35);
        btnQuanLyBacSi.TabIndex = 22;
        btnQuanLyBacSi.Text = "👨‍⚕️ Quản lý Bác sĩ...";
        btnQuanLyBacSi.UseVisualStyleBackColor = true;
        btnQuanLyBacSi.Click += btnQuanLyBacSi_Click;

        // 
        // dgvLichKham
        // 
        dgvLichKham.AllowUserToAddRows = false;
        dgvLichKham.AllowUserToDeleteRows = false;
        dgvLichKham.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvLichKham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvLichKham.BackgroundColor = System.Drawing.Color.White;
        dgvLichKham.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        dgvHeaderStyle.ForeColor = System.Drawing.SystemColors.WindowText;
        dgvHeaderStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvHeaderStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvLichKham.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        dgvLichKham.ColumnHeadersHeight = 32;

        dgvCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvCellStyle.BackColor = System.Drawing.SystemColors.Window;
        dgvCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dgvCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
        dgvCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvLichKham.DefaultCellStyle = dgvCellStyle;

        dgvLichKham.Location = new System.Drawing.Point(30, 210);
        dgvLichKham.MultiSelect = false;
        dgvLichKham.Name = "dgvLichKham";
        dgvLichKham.ReadOnly = true;
        dgvLichKham.RowHeadersWidth = 35;
        dgvLichKham.RowTemplate.Height = 28;
        dgvLichKham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvLichKham.Size = new System.Drawing.Size(980, 360);
        dgvLichKham.TabIndex = 23;
        dgvLichKham.SelectionChanged += dgvLichKham_SelectionChanged;

        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1040, 590);
        Controls.Add(lblTenBenhNhan);
        Controls.Add(txtTenBenhNhan);
        Controls.Add(lblSDT);
        Controls.Add(txtSDT);
        Controls.Add(lblNgayKham);
        Controls.Add(dtpNgayKham);
        Controls.Add(lblGioKham);
        Controls.Add(dtpGioKham);
        Controls.Add(lblBacSi);
        Controls.Add(cboBacSi);
        Controls.Add(lblTrangThai);
        Controls.Add(cboTrangThai);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(lblTuNgay);
        Controls.Add(dtpTuNgay);
        Controls.Add(lblDenNgay);
        Controls.Add(dtpDenNgay);
        Controls.Add(cboLocBacSi);
        Controls.Add(btnTimKiem);
        Controls.Add(btnQuanLyBacSi);
        Controls.Add(dgvLichKham);
        MinimumSize = new System.Drawing.Size(980, 540);
        Name = "Form1";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản Lý Lịch Khám Bệnh - An Khang Clinic";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
