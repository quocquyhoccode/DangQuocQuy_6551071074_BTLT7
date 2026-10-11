namespace SunriseHomestay;

partial class FormLoaiPhong
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblMaLoai;
    private System.Windows.Forms.TextBox txtMaLoai;
    private System.Windows.Forms.Label lblTenLoai;
    private System.Windows.Forms.TextBox txtTenLoai;
    private System.Windows.Forms.Label lblGiaMoiDem;
    private System.Windows.Forms.TextBox txtGiaMoiDem;
    private System.Windows.Forms.Label lblMoTa;
    private System.Windows.Forms.TextBox txtMoTa;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnDong;

    private System.Windows.Forms.DataGridView dgvLoaiPhong;

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
        lblMaLoai = new System.Windows.Forms.Label();
        txtMaLoai = new System.Windows.Forms.TextBox();
        lblTenLoai = new System.Windows.Forms.Label();
        txtTenLoai = new System.Windows.Forms.TextBox();
        lblGiaMoiDem = new System.Windows.Forms.Label();
        txtGiaMoiDem = new System.Windows.Forms.TextBox();
        lblMoTa = new System.Windows.Forms.Label();
        txtMoTa = new System.Windows.Forms.TextBox();

        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();
        btnDong = new System.Windows.Forms.Button();

        dgvLoaiPhong = new System.Windows.Forms.DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();
        SuspendLayout();

        // 
        // lblMaLoai
        // 
        lblMaLoai.AutoSize = true;
        lblMaLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblMaLoai.Location = new System.Drawing.Point(30, 25);
        lblMaLoai.Name = "lblMaLoai";
        lblMaLoai.Size = new System.Drawing.Size(65, 21);
        lblMaLoai.TabIndex = 0;
        lblMaLoai.Text = "Mã loại:";

        // 
        // txtMaLoai
        // 
        txtMaLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtMaLoai.Location = new System.Drawing.Point(140, 22);
        txtMaLoai.Name = "txtMaLoai";
        txtMaLoai.ReadOnly = true;
        txtMaLoai.PlaceholderText = "Tự động tăng";
        txtMaLoai.Size = new System.Drawing.Size(220, 29);
        txtMaLoai.TabIndex = 1;
        txtMaLoai.TabStop = false;

        // 
        // lblTenLoai
        // 
        lblTenLoai.AutoSize = true;
        lblTenLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTenLoai.Location = new System.Drawing.Point(30, 68);
        lblTenLoai.Name = "lblTenLoai";
        lblTenLoai.Size = new System.Drawing.Size(66, 21);
        lblTenLoai.TabIndex = 2;
        lblTenLoai.Text = "Tên loại:";

        // 
        // txtTenLoai
        // 
        txtTenLoai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtTenLoai.Location = new System.Drawing.Point(140, 65);
        txtTenLoai.Name = "txtTenLoai";
        txtTenLoai.PlaceholderText = "Nhập tên loại phòng...";
        txtTenLoai.Size = new System.Drawing.Size(220, 29);
        txtTenLoai.TabIndex = 3;

        // 
        // lblGiaMoiDem
        // 
        lblGiaMoiDem.AutoSize = true;
        lblGiaMoiDem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblGiaMoiDem.Location = new System.Drawing.Point(30, 111);
        lblGiaMoiDem.Name = "lblGiaMoiDem";
        lblGiaMoiDem.Size = new System.Drawing.Size(102, 21);
        lblGiaMoiDem.TabIndex = 4;
        lblGiaMoiDem.Text = "Giá mỗi đêm:";

        // 
        // txtGiaMoiDem
        // 
        txtGiaMoiDem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtGiaMoiDem.Location = new System.Drawing.Point(140, 108);
        txtGiaMoiDem.Name = "txtGiaMoiDem";
        txtGiaMoiDem.PlaceholderText = "Ví dụ: 350000";
        txtGiaMoiDem.Size = new System.Drawing.Size(220, 29);
        txtGiaMoiDem.TabIndex = 5;

        // 
        // lblMoTa
        // 
        lblMoTa.AutoSize = true;
        lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblMoTa.Location = new System.Drawing.Point(30, 154);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new System.Drawing.Size(53, 21);
        lblMoTa.TabIndex = 6;
        lblMoTa.Text = "Mô tả:";

        // 
        // txtMoTa
        // 
        txtMoTa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtMoTa.Location = new System.Drawing.Point(140, 151);
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Nhập mô tả loại phòng...";
        txtMoTa.Size = new System.Drawing.Size(220, 75);
        txtMoTa.TabIndex = 7;

        // 
        // btnThem
        // 
        btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(390, 22);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(95, 34);
        btnThem.TabIndex = 8;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
        btnSua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnSua.Location = new System.Drawing.Point(390, 65);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(95, 34);
        btnSua.TabIndex = 9;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXoa.Location = new System.Drawing.Point(390, 108);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(95, 34);
        btnXoa.TabIndex = 10;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnLamMoi.Location = new System.Drawing.Point(390, 151);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(95, 34);
        btnLamMoi.TabIndex = 11;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // btnDong
        // 
        btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
        btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnDong.Location = new System.Drawing.Point(390, 192);
        btnDong.Name = "btnDong";
        btnDong.Size = new System.Drawing.Size(95, 34);
        btnDong.TabIndex = 12;
        btnDong.Text = "Đóng";
        btnDong.UseVisualStyleBackColor = true;
        btnDong.Click += (s, e) => Close();

        // 
        // dgvLoaiPhong
        // 
        dgvLoaiPhong.AllowUserToAddRows = false;
        dgvLoaiPhong.AllowUserToDeleteRows = false;
        dgvLoaiPhong.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvLoaiPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvLoaiPhong.BackgroundColor = System.Drawing.Color.White;
        dgvLoaiPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dgvLoaiPhong.Location = new System.Drawing.Point(30, 245);
        dgvLoaiPhong.MultiSelect = false;
        dgvLoaiPhong.Name = "dgvLoaiPhong";
        dgvLoaiPhong.ReadOnly = true;
        dgvLoaiPhong.RowHeadersWidth = 35;
        dgvLoaiPhong.RowTemplate.Height = 28;
        dgvLoaiPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvLoaiPhong.Size = new System.Drawing.Size(460, 200);
        dgvLoaiPhong.TabIndex = 13;
        dgvLoaiPhong.SelectionChanged += dgvLoaiPhong_SelectionChanged;

        // 
        // FormLoaiPhong
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(520, 470);
        Controls.Add(lblMaLoai);
        Controls.Add(txtMaLoai);
        Controls.Add(lblTenLoai);
        Controls.Add(txtTenLoai);
        Controls.Add(lblGiaMoiDem);
        Controls.Add(txtGiaMoiDem);
        Controls.Add(lblMoTa);
        Controls.Add(txtMoTa);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(btnDong);
        Controls.Add(dgvLoaiPhong);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormLoaiPhong";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Quản Lý Loại Phòng";
        Load += FormLoaiPhong_Load;
        ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
