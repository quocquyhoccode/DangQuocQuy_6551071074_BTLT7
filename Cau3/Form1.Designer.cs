namespace SunriseHomestay;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblSoPhong;
    private System.Windows.Forms.TextBox txtSoPhong;
    private System.Windows.Forms.Label lblTangSo;
    private System.Windows.Forms.NumericUpDown nudTangSo;
    private System.Windows.Forms.Label lblLoaiPhong;
    private System.Windows.Forms.ComboBox cboLoaiPhong;
    private System.Windows.Forms.Label lblTinhTrang;
    private System.Windows.Forms.ComboBox cboTinhTrang;

    private System.Windows.Forms.PictureBox picHinhAnh;
    private System.Windows.Forms.Button btnChonAnh;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnQuanLyLoaiPhong;

    private System.Windows.Forms.ComboBox cboLocLoaiPhong;
    private System.Windows.Forms.ComboBox cboLocTinhTrang;
    private System.Windows.Forms.Button btnTimKiem;

    private System.Windows.Forms.DataGridView dgvPhong;

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

        lblSoPhong = new System.Windows.Forms.Label();
        txtSoPhong = new System.Windows.Forms.TextBox();
        lblTangSo = new System.Windows.Forms.Label();
        nudTangSo = new System.Windows.Forms.NumericUpDown();
        lblLoaiPhong = new System.Windows.Forms.Label();
        cboLoaiPhong = new System.Windows.Forms.ComboBox();
        lblTinhTrang = new System.Windows.Forms.Label();
        cboTinhTrang = new System.Windows.Forms.ComboBox();

        picHinhAnh = new System.Windows.Forms.PictureBox();
        btnChonAnh = new System.Windows.Forms.Button();

        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();
        btnQuanLyLoaiPhong = new System.Windows.Forms.Button();

        cboLocLoaiPhong = new System.Windows.Forms.ComboBox();
        cboLocTinhTrang = new System.Windows.Forms.ComboBox();
        btnTimKiem = new System.Windows.Forms.Button();
        dgvPhong = new System.Windows.Forms.DataGridView();

        ((System.ComponentModel.ISupportInitialize)nudTangSo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
        SuspendLayout();

        // 
        // lblSoPhong
        // 
        lblSoPhong.AutoSize = true;
        lblSoPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblSoPhong.Location = new System.Drawing.Point(30, 20);
        lblSoPhong.Name = "lblSoPhong";
        lblSoPhong.Size = new System.Drawing.Size(77, 21);
        lblSoPhong.TabIndex = 0;
        lblSoPhong.Text = "Số phòng";

        // 
        // txtSoPhong
        // 
        txtSoPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtSoPhong.Location = new System.Drawing.Point(30, 48);
        txtSoPhong.Name = "txtSoPhong";
        txtSoPhong.PlaceholderText = "Số phòng...";
        txtSoPhong.Size = new System.Drawing.Size(110, 29);
        txtSoPhong.TabIndex = 1;

        // 
        // lblTangSo
        // 
        lblTangSo.AutoSize = true;
        lblTangSo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTangSo.Location = new System.Drawing.Point(160, 20);
        lblTangSo.Name = "lblTangSo";
        lblTangSo.Size = new System.Drawing.Size(61, 21);
        lblTangSo.TabIndex = 2;
        lblTangSo.Text = "Tầng số";

        // 
        // nudTangSo
        // 
        nudTangSo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        nudTangSo.Location = new System.Drawing.Point(160, 48);
        nudTangSo.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
        nudTangSo.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        nudTangSo.Name = "nudTangSo";
        nudTangSo.Size = new System.Drawing.Size(85, 29);
        nudTangSo.TabIndex = 3;
        nudTangSo.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // 
        // lblLoaiPhong
        // 
        lblLoaiPhong.AutoSize = true;
        lblLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblLoaiPhong.Location = new System.Drawing.Point(265, 20);
        lblLoaiPhong.Name = "lblLoaiPhong";
        lblLoaiPhong.Size = new System.Drawing.Size(88, 21);
        lblLoaiPhong.TabIndex = 4;
        lblLoaiPhong.Text = "Loại phòng";

        // 
        // cboLoaiPhong
        // 
        cboLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboLoaiPhong.FormattingEnabled = true;
        cboLoaiPhong.Location = new System.Drawing.Point(265, 48);
        cboLoaiPhong.Name = "cboLoaiPhong";
        cboLoaiPhong.Size = new System.Drawing.Size(125, 29);
        cboLoaiPhong.TabIndex = 5;

        // 
        // lblTinhTrang
        // 
        lblTinhTrang.AutoSize = true;
        lblTinhTrang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTinhTrang.Location = new System.Drawing.Point(410, 20);
        lblTinhTrang.Name = "lblTinhTrang";
        lblTinhTrang.Size = new System.Drawing.Size(82, 21);
        lblTinhTrang.TabIndex = 6;
        lblTinhTrang.Text = "Tình trạng";

        // 
        // cboTinhTrang
        // 
        cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboTinhTrang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboTinhTrang.FormattingEnabled = true;
        cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
        cboTinhTrang.Location = new System.Drawing.Point(410, 48);
        cboTinhTrang.Name = "cboTinhTrang";
        cboTinhTrang.Size = new System.Drawing.Size(120, 29);
        cboTinhTrang.TabIndex = 7;

        // 
        // picHinhAnh
        // 
        picHinhAnh.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
        picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        picHinhAnh.Location = new System.Drawing.Point(550, 18);
        picHinhAnh.Name = "picHinhAnh";
        picHinhAnh.Size = new System.Drawing.Size(100, 75);
        picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        picHinhAnh.TabIndex = 8;
        picHinhAnh.TabStop = false;

        // 
        // btnChonAnh
        // 
        btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
        btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnChonAnh.Location = new System.Drawing.Point(550, 96);
        btnChonAnh.Name = "btnChonAnh";
        btnChonAnh.Size = new System.Drawing.Size(100, 28);
        btnChonAnh.TabIndex = 9;
        btnChonAnh.Text = "Chọn ảnh...";
        btnChonAnh.UseVisualStyleBackColor = true;
        btnChonAnh.Click += btnChonAnh_Click;

        // 
        // btnThem
        // 
        btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(670, 30);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(75, 36);
        btnThem.TabIndex = 10;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
        btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnSua.Location = new System.Drawing.Point(755, 30);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(75, 36);
        btnSua.TabIndex = 11;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXoa.Location = new System.Drawing.Point(840, 30);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(75, 36);
        btnXoa.TabIndex = 12;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnLamMoi.Location = new System.Drawing.Point(925, 30);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(85, 36);
        btnLamMoi.TabIndex = 13;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // btnQuanLyLoaiPhong
        // 
        btnQuanLyLoaiPhong.Cursor = System.Windows.Forms.Cursors.Hand;
        btnQuanLyLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnQuanLyLoaiPhong.Location = new System.Drawing.Point(670, 75);
        btnQuanLyLoaiPhong.Name = "btnQuanLyLoaiPhong";
        btnQuanLyLoaiPhong.Size = new System.Drawing.Size(340, 28);
        btnQuanLyLoaiPhong.TabIndex = 14;
        btnQuanLyLoaiPhong.Text = "📋 Quản lý Loại phòng (Form phụ)...";
        btnQuanLyLoaiPhong.UseVisualStyleBackColor = true;
        btnQuanLyLoaiPhong.Click += btnQuanLyLoaiPhong_Click;

        // 
        // cboLocLoaiPhong
        // 
        cboLocLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLocLoaiPhong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboLocLoaiPhong.FormattingEnabled = true;
        cboLocLoaiPhong.Location = new System.Drawing.Point(30, 142);
        cboLocLoaiPhong.Name = "cboLocLoaiPhong";
        cboLocLoaiPhong.Size = new System.Drawing.Size(200, 29);
        cboLocLoaiPhong.TabIndex = 15;

        // 
        // cboLocTinhTrang
        // 
        cboLocTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboLocTinhTrang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        cboLocTinhTrang.FormattingEnabled = true;
        cboLocTinhTrang.Items.AddRange(new object[] { "lọc theo tình trạng", "Trống", "Đang ở", "Đang dọn" });
        cboLocTinhTrang.Location = new System.Drawing.Point(245, 142);
        cboLocTinhTrang.Name = "cboLocTinhTrang";
        cboLocTinhTrang.Size = new System.Drawing.Size(195, 29);
        cboLocTinhTrang.TabIndex = 16;

        // 
        // btnTimKiem
        // 
        btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnTimKiem.Location = new System.Drawing.Point(455, 138);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new System.Drawing.Size(110, 36);
        btnTimKiem.TabIndex = 17;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;

        // 
        // dgvPhong
        // 
        dgvPhong.AllowUserToAddRows = false;
        dgvPhong.AllowUserToDeleteRows = false;
        dgvPhong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvPhong.BackgroundColor = System.Drawing.Color.White;
        dgvPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        dgvHeaderStyle.ForeColor = System.Drawing.SystemColors.WindowText;
        dgvHeaderStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvHeaderStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvPhong.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        dgvPhong.ColumnHeadersHeight = 32;

        dgvCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvCellStyle.BackColor = System.Drawing.SystemColors.Window;
        dgvCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dgvCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
        dgvCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvPhong.DefaultCellStyle = dgvCellStyle;

        dgvPhong.Location = new System.Drawing.Point(30, 185);
        dgvPhong.MultiSelect = false;
        dgvPhong.Name = "dgvPhong";
        dgvPhong.ReadOnly = true;
        dgvPhong.RowHeadersWidth = 35;
        dgvPhong.RowTemplate.Height = 55;
        dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvPhong.Size = new System.Drawing.Size(980, 360);
        dgvPhong.TabIndex = 18;
        dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;

        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1040, 570);
        Controls.Add(lblSoPhong);
        Controls.Add(txtSoPhong);
        Controls.Add(lblTangSo);
        Controls.Add(nudTangSo);
        Controls.Add(lblLoaiPhong);
        Controls.Add(cboLoaiPhong);
        Controls.Add(lblTinhTrang);
        Controls.Add(cboTinhTrang);
        Controls.Add(picHinhAnh);
        Controls.Add(btnChonAnh);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(btnQuanLyLoaiPhong);
        Controls.Add(cboLocLoaiPhong);
        Controls.Add(cboLocTinhTrang);
        Controls.Add(btnTimKiem);
        Controls.Add(dgvPhong);
        MinimumSize = new System.Drawing.Size(980, 520);
        Name = "Form1";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản Lý Phòng - Sunrise Homestay";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)nudTangSo).EndInit();
        ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
