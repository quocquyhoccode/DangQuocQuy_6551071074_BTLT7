namespace AnKhangClinic;

partial class FormBacSi
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblMaBS;
    private System.Windows.Forms.TextBox txtMaBS;
    private System.Windows.Forms.Label lblHoTen;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.Label lblChuyenKhoa;
    private System.Windows.Forms.TextBox txtChuyenKhoa;
    private System.Windows.Forms.Label lblSDT;
    private System.Windows.Forms.TextBox txtSDT;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnDong;

    private System.Windows.Forms.DataGridView dgvBacSi;

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
        lblMaBS = new System.Windows.Forms.Label();
        txtMaBS = new System.Windows.Forms.TextBox();
        lblHoTen = new System.Windows.Forms.Label();
        txtHoTen = new System.Windows.Forms.TextBox();
        lblChuyenKhoa = new System.Windows.Forms.Label();
        txtChuyenKhoa = new System.Windows.Forms.TextBox();
        lblSDT = new System.Windows.Forms.Label();
        txtSDT = new System.Windows.Forms.TextBox();

        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();
        btnDong = new System.Windows.Forms.Button();

        dgvBacSi = new System.Windows.Forms.DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
        SuspendLayout();

        // 
        // lblMaBS
        // 
        lblMaBS.AutoSize = true;
        lblMaBS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblMaBS.Location = new System.Drawing.Point(30, 25);
        lblMaBS.Name = "lblMaBS";
        lblMaBS.Size = new System.Drawing.Size(59, 21);
        lblMaBS.TabIndex = 0;
        lblMaBS.Text = "Mã BS:";

        // 
        // txtMaBS
        // 
        txtMaBS.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtMaBS.Location = new System.Drawing.Point(140, 22);
        txtMaBS.Name = "txtMaBS";
        txtMaBS.ReadOnly = true;
        txtMaBS.PlaceholderText = "Tự động tăng";
        txtMaBS.Size = new System.Drawing.Size(230, 29);
        txtMaBS.TabIndex = 1;
        txtMaBS.TabStop = false;

        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblHoTen.Location = new System.Drawing.Point(30, 68);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new System.Drawing.Size(59, 21);
        lblHoTen.TabIndex = 2;
        lblHoTen.Text = "Họ tên:";

        // 
        // txtHoTen
        // 
        txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtHoTen.Location = new System.Drawing.Point(140, 65);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.PlaceholderText = "Ví dụ: BS. Nguyễn Văn A";
        txtHoTen.Size = new System.Drawing.Size(230, 29);
        txtHoTen.TabIndex = 3;

        // 
        // lblChuyenKhoa
        // 
        lblChuyenKhoa.AutoSize = true;
        lblChuyenKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblChuyenKhoa.Location = new System.Drawing.Point(30, 111);
        lblChuyenKhoa.Name = "lblChuyenKhoa";
        lblChuyenKhoa.Size = new System.Drawing.Size(104, 21);
        lblChuyenKhoa.TabIndex = 4;
        lblChuyenKhoa.Text = "Chuyên khoa:";

        // 
        // txtChuyenKhoa
        // 
        txtChuyenKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtChuyenKhoa.Location = new System.Drawing.Point(140, 108);
        txtChuyenKhoa.Name = "txtChuyenKhoa";
        txtChuyenKhoa.PlaceholderText = "Ví dụ: Nội tổng quát";
        txtChuyenKhoa.Size = new System.Drawing.Size(230, 29);
        txtChuyenKhoa.TabIndex = 5;

        // 
        // lblSDT
        // 
        lblSDT.AutoSize = true;
        lblSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblSDT.Location = new System.Drawing.Point(30, 154);
        lblSDT.Name = "lblSDT";
        lblSDT.Size = new System.Drawing.Size(104, 21);
        lblSDT.TabIndex = 6;
        lblSDT.Text = "Số điện thoại:";

        // 
        // txtSDT
        // 
        txtSDT.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtSDT.Location = new System.Drawing.Point(140, 151);
        txtSDT.Name = "txtSDT";
        txtSDT.PlaceholderText = "Số điện thoại bác sĩ...";
        txtSDT.Size = new System.Drawing.Size(230, 29);
        txtSDT.TabIndex = 7;

        // 
        // btnThem
        // 
        btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(400, 22);
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
        btnSua.Location = new System.Drawing.Point(400, 65);
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
        btnXoa.Location = new System.Drawing.Point(400, 108);
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
        btnLamMoi.Location = new System.Drawing.Point(400, 151);
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
        btnDong.Location = new System.Drawing.Point(400, 192);
        btnDong.Name = "btnDong";
        btnDong.Size = new System.Drawing.Size(95, 34);
        btnDong.TabIndex = 12;
        btnDong.Text = "Đóng";
        btnDong.UseVisualStyleBackColor = true;
        btnDong.Click += (s, e) => Close();

        // 
        // dgvBacSi
        // 
        dgvBacSi.AllowUserToAddRows = false;
        dgvBacSi.AllowUserToDeleteRows = false;
        dgvBacSi.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvBacSi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvBacSi.BackgroundColor = System.Drawing.Color.White;
        dgvBacSi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        dgvBacSi.Location = new System.Drawing.Point(30, 245);
        dgvBacSi.MultiSelect = false;
        dgvBacSi.Name = "dgvBacSi";
        dgvBacSi.ReadOnly = true;
        dgvBacSi.RowHeadersWidth = 35;
        dgvBacSi.RowTemplate.Height = 28;
        dgvBacSi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvBacSi.Size = new System.Drawing.Size(465, 200);
        dgvBacSi.TabIndex = 13;
        dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;

        // 
        // FormBacSi
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(530, 470);
        Controls.Add(lblMaBS);
        Controls.Add(txtMaBS);
        Controls.Add(lblHoTen);
        Controls.Add(txtHoTen);
        Controls.Add(lblChuyenKhoa);
        Controls.Add(txtChuyenKhoa);
        Controls.Add(lblSDT);
        Controls.Add(txtSDT);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(btnDong);
        Controls.Add(dgvBacSi);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormBacSi";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Quản Lý Bác Sĩ";
        Load += FormBacSi_Load;
        ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
