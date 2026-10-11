namespace FitZoneGym;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblHoTen;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.Label lblSDT;
    private System.Windows.Forms.TextBox txtSDT;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Label lblNgaySinh;
    private System.Windows.Forms.DateTimePicker dtpNgaySinh;
    private System.Windows.Forms.Label lblHangThanhVien;
    private System.Windows.Forms.ComboBox cboHangThanhVien;
    private System.Windows.Forms.CheckBox chkTrangThai;

    private System.Windows.Forms.GroupBox grpGioiTinh;
    private System.Windows.Forms.RadioButton rdoNam;
    private System.Windows.Forms.RadioButton rdoNu;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.TextBox txtTimKiemHoTen;
    private System.Windows.Forms.Label lblLocHang;
    private System.Windows.Forms.ComboBox cboLocHangThanhVien;
    private System.Windows.Forms.Button btnTimKiem;

    private System.Windows.Forms.DataGridView dgvHoiVien;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblSDT = new Label();
        txtSDT = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblNgaySinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        lblHangThanhVien = new Label();
        cboHangThanhVien = new ComboBox();
        chkTrangThai = new CheckBox();
        grpGioiTinh = new GroupBox();
        rdoNam = new RadioButton();
        rdoNu = new RadioButton();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        txtTimKiemHoTen = new TextBox();
        lblLocHang = new Label();
        cboLocHangThanhVien = new ComboBox();
        btnTimKiem = new Button();
        dgvHoiVien = new DataGridView();
        grpGioiTinh.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
        SuspendLayout();
        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.Font = new Font("Segoe UI", 9.5F);
        lblHoTen.Location = new Point(30, 25);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(56, 21);
        lblHoTen.TabIndex = 0;
        lblHoTen.Text = "Họ tên";
        // 
        // txtHoTen
        // 
        txtHoTen.Font = new Font("Segoe UI", 9.5F);
        txtHoTen.Location = new Point(155, 22);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.PlaceholderText = "Nhập họ và tên...";
        txtHoTen.Size = new Size(220, 29);
        txtHoTen.TabIndex = 1;
        // 
        // lblSDT
        // 
        lblSDT.AutoSize = true;
        lblSDT.Font = new Font("Segoe UI", 9.5F);
        lblSDT.Location = new Point(30, 68);
        lblSDT.Name = "lblSDT";
        lblSDT.Size = new Size(101, 21);
        lblSDT.TabIndex = 2;
        lblSDT.Text = "Số điện thoại";
        // 
        // txtSDT
        // 
        txtSDT.Font = new Font("Segoe UI", 9.5F);
        txtSDT.Location = new Point(155, 65);
        txtSDT.Name = "txtSDT";
        txtSDT.PlaceholderText = "Nhập số điện thoại...";
        txtSDT.Size = new Size(220, 29);
        txtSDT.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9.5F);
        lblEmail.Location = new Point(30, 111);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(48, 21);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "Email";
        // 
        // txtEmail
        // 
        txtEmail.Font = new Font("Segoe UI", 9.5F);
        txtEmail.Location = new Point(155, 108);
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "Nhập email...";
        txtEmail.Size = new Size(220, 29);
        txtEmail.TabIndex = 5;
        // 
        // lblNgaySinh
        // 
        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Font = new Font("Segoe UI", 9.5F);
        lblNgaySinh.Location = new Point(30, 154);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Size = new Size(80, 21);
        lblNgaySinh.TabIndex = 6;
        lblNgaySinh.Text = "Ngày sinh";
        // 
        // dtpNgaySinh
        // 
        dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        dtpNgaySinh.Font = new Font("Segoe UI", 9.5F);
        dtpNgaySinh.Format = DateTimePickerFormat.Custom;
        dtpNgaySinh.Location = new Point(155, 151);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.Size = new Size(220, 29);
        dtpNgaySinh.TabIndex = 7;
        // 
        // lblHangThanhVien
        // 
        lblHangThanhVien.AutoSize = true;
        lblHangThanhVien.Font = new Font("Segoe UI", 9.5F);
        lblHangThanhVien.Location = new Point(30, 197);
        lblHangThanhVien.Name = "lblHangThanhVien";
        lblHangThanhVien.Size = new Size(124, 21);
        lblHangThanhVien.TabIndex = 8;
        lblHangThanhVien.Text = "Hạng thành viên";
        // 
        // cboHangThanhVien
        // 
        cboHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
        cboHangThanhVien.Font = new Font("Segoe UI", 9.5F);
        cboHangThanhVien.FormattingEnabled = true;
        cboHangThanhVien.Location = new Point(155, 194);
        cboHangThanhVien.Name = "cboHangThanhVien";
        cboHangThanhVien.Size = new Size(220, 29);
        cboHangThanhVien.TabIndex = 9;
        // 
        // chkTrangThai
        // 
        chkTrangThai.AutoSize = true;
        chkTrangThai.Checked = true;
        chkTrangThai.CheckState = CheckState.Checked;
        chkTrangThai.Font = new Font("Segoe UI", 9.5F);
        chkTrangThai.Location = new Point(30, 237);
        chkTrangThai.Name = "chkTrangThai";
        chkTrangThai.Size = new Size(144, 25);
        chkTrangThai.TabIndex = 10;
        chkTrangThai.Text = "Đang hoạt động";
        chkTrangThai.UseVisualStyleBackColor = true;
        // 
        // grpGioiTinh
        // 
        grpGioiTinh.Controls.Add(rdoNam);
        grpGioiTinh.Controls.Add(rdoNu);
        grpGioiTinh.Font = new Font("Segoe UI", 9.5F);
        grpGioiTinh.Location = new Point(400, 20);
        grpGioiTinh.Name = "grpGioiTinh";
        grpGioiTinh.Size = new Size(240, 80);
        grpGioiTinh.TabIndex = 11;
        grpGioiTinh.TabStop = false;
        grpGioiTinh.Text = "Giới tính";
        // 
        // rdoNam
        // 
        rdoNam.AutoSize = true;
        rdoNam.Checked = true;
        rdoNam.Cursor = Cursors.Hand;
        rdoNam.Location = new Point(25, 35);
        rdoNam.Name = "rdoNam";
        rdoNam.Size = new Size(65, 25);
        rdoNam.TabIndex = 0;
        rdoNam.TabStop = true;
        rdoNam.Text = "Nam";
        rdoNam.UseVisualStyleBackColor = true;
        // 
        // rdoNu
        // 
        rdoNu.AutoSize = true;
        rdoNu.Cursor = Cursors.Hand;
        rdoNu.Location = new Point(135, 35);
        rdoNu.Name = "rdoNu";
        rdoNu.Size = new Size(52, 25);
        rdoNu.TabIndex = 1;
        rdoNu.Text = "Nữ";
        rdoNu.UseVisualStyleBackColor = true;
        // 
        // btnThem
        // 
        btnThem.Cursor = Cursors.Hand;
        btnThem.Font = new Font("Segoe UI", 9.5F);
        btnThem.Location = new Point(670, 22);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(140, 36);
        btnThem.TabIndex = 12;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;
        // 
        // btnSua
        // 
        btnSua.Cursor = Cursors.Hand;
        btnSua.Font = new Font("Segoe UI", 9.5F);
        btnSua.Location = new Point(670, 72);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(140, 36);
        btnSua.TabIndex = 13;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;
        // 
        // btnXoa
        // 
        btnXoa.Cursor = Cursors.Hand;
        btnXoa.Font = new Font("Segoe UI", 9.5F);
        btnXoa.Location = new Point(670, 122);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(140, 36);
        btnXoa.TabIndex = 14;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;
        // 
        // btnLamMoi
        // 
        btnLamMoi.Cursor = Cursors.Hand;
        btnLamMoi.Font = new Font("Segoe UI", 9.5F);
        btnLamMoi.Location = new Point(670, 172);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(140, 36);
        btnLamMoi.TabIndex = 15;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;
        // 
        // txtTimKiemHoTen
        // 
        txtTimKiemHoTen.Font = new Font("Segoe UI", 9.5F);
        txtTimKiemHoTen.Location = new Point(30, 280);
        txtTimKiemHoTen.Name = "txtTimKiemHoTen";
        txtTimKiemHoTen.PlaceholderText = "Nhập họ tên cần tìm...";
        txtTimKiemHoTen.Size = new Size(260, 29);
        txtTimKiemHoTen.TabIndex = 16;
        txtTimKiemHoTen.KeyDown += txtTimKiemHoTen_KeyDown;
        // 
        // lblLocHang
        // 
        lblLocHang.AutoSize = true;
        lblLocHang.Font = new Font("Segoe UI", 9.5F);
        lblLocHang.Location = new Point(305, 284);
        lblLocHang.Name = "lblLocHang";
        lblLocHang.Size = new Size(127, 21);
        lblLocHang.TabIndex = 17;
        lblLocHang.Text = "Hạng thành viên:";
        // 
        // cboLocHangThanhVien
        // 
        cboLocHangThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocHangThanhVien.Font = new Font("Segoe UI", 9.5F);
        cboLocHangThanhVien.FormattingEnabled = true;
        cboLocHangThanhVien.Location = new Point(435, 280);
        cboLocHangThanhVien.Name = "cboLocHangThanhVien";
        cboLocHangThanhVien.Size = new Size(205, 29);
        cboLocHangThanhVien.TabIndex = 18;
        // 
        // btnTimKiem
        // 
        btnTimKiem.Cursor = Cursors.Hand;
        btnTimKiem.Font = new Font("Segoe UI", 9.5F);
        btnTimKiem.Location = new Point(670, 276);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new Size(140, 36);
        btnTimKiem.TabIndex = 19;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;
        // 
        // dgvHoiVien
        // 
        dgvHoiVien.AllowUserToAddRows = false;
        dgvHoiVien.AllowUserToDeleteRows = false;
        dgvHoiVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHoiVien.BackgroundColor = Color.White;
        dgvHoiVien.BorderStyle = BorderStyle.Fixed3D;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvHoiVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvHoiVien.ColumnHeadersHeight = 32;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvHoiVien.DefaultCellStyle = dataGridViewCellStyle2;
        dgvHoiVien.Location = new Point(30, 318);
        dgvHoiVien.MultiSelect = false;
        dgvHoiVien.Name = "dgvHoiVien";
        dgvHoiVien.ReadOnly = true;
        dgvHoiVien.RowHeadersWidth = 35;
        dgvHoiVien.RowTemplate.Height = 28;
        dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHoiVien.Size = new Size(940, 207);
        dgvHoiVien.TabIndex = 20;
        dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 581);
        Controls.Add(lblHoTen);
        Controls.Add(txtHoTen);
        Controls.Add(lblSDT);
        Controls.Add(txtSDT);
        Controls.Add(lblEmail);
        Controls.Add(txtEmail);
        Controls.Add(lblNgaySinh);
        Controls.Add(dtpNgaySinh);
        Controls.Add(lblHangThanhVien);
        Controls.Add(cboHangThanhVien);
        Controls.Add(chkTrangThai);
        Controls.Add(grpGioiTinh);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(txtTimKiemHoTen);
        Controls.Add(lblLocHang);
        Controls.Add(cboLocHangThanhVien);
        Controls.Add(btnTimKiem);
        Controls.Add(dgvHoiVien);
        MinimumSize = new Size(950, 550);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản Lý Hội Viên Phòng Gym FitZone";
        Load += Form1_Load;
        grpGioiTinh.ResumeLayout(false);
        grpGioiTinh.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
