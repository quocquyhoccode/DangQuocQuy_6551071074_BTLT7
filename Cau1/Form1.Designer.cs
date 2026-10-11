namespace TriThucBooks;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.Label lblMaTL;
    private System.Windows.Forms.TextBox txtMaTL;
    private System.Windows.Forms.Label lblTenTheLoai;
    private System.Windows.Forms.TextBox txtTenTheLoai;
    private System.Windows.Forms.Label lblMoTa;
    private System.Windows.Forms.TextBox txtMoTa;
    private System.Windows.Forms.Label lblNgayTaoTieuDe;
    private System.Windows.Forms.Label lblNgayTao;

    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.TextBox txtTimKiem;
    private System.Windows.Forms.Button btnTimKiem;

    private System.Windows.Forms.DataGridView dgvTheLoai;

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

        lblMaTL = new System.Windows.Forms.Label();
        txtMaTL = new System.Windows.Forms.TextBox();
        lblTenTheLoai = new System.Windows.Forms.Label();
        txtTenTheLoai = new System.Windows.Forms.TextBox();
        lblMoTa = new System.Windows.Forms.Label();
        txtMoTa = new System.Windows.Forms.TextBox();
        lblNgayTaoTieuDe = new System.Windows.Forms.Label();
        lblNgayTao = new System.Windows.Forms.Label();

        btnThem = new System.Windows.Forms.Button();
        btnSua = new System.Windows.Forms.Button();
        btnXoa = new System.Windows.Forms.Button();
        btnLamMoi = new System.Windows.Forms.Button();

        txtTimKiem = new System.Windows.Forms.TextBox();
        btnTimKiem = new System.Windows.Forms.Button();
        dgvTheLoai = new System.Windows.Forms.DataGridView();

        ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
        SuspendLayout();

        // 
        // lblMaTL
        // 
        lblMaTL.AutoSize = true;
        lblMaTL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblMaTL.Location = new System.Drawing.Point(30, 28);
        lblMaTL.Name = "lblMaTL";
        lblMaTL.Size = new System.Drawing.Size(89, 23);
        lblMaTL.TabIndex = 0;
        lblMaTL.Text = "Mã thể loại";

        // 
        // txtMaTL
        // 
        txtMaTL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtMaTL.Location = new System.Drawing.Point(145, 25);
        txtMaTL.Name = "txtMaTL";
        txtMaTL.ReadOnly = true;
        txtMaTL.PlaceholderText = "ReadOnly";
        txtMaTL.Size = new System.Drawing.Size(290, 30);
        txtMaTL.TabIndex = 1;
        txtMaTL.TabStop = false;

        // 
        // lblTenTheLoai
        // 
        lblTenTheLoai.AutoSize = true;
        lblTenTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblTenTheLoai.Location = new System.Drawing.Point(30, 72);
        lblTenTheLoai.Name = "lblTenTheLoai";
        lblTenTheLoai.Size = new System.Drawing.Size(98, 23);
        lblTenTheLoai.TabIndex = 2;
        lblTenTheLoai.Text = "Tên thể loại";

        // 
        // txtTenTheLoai
        // 
        txtTenTheLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtTenTheLoai.Location = new System.Drawing.Point(145, 69);
        txtTenTheLoai.Name = "txtTenTheLoai";
        txtTenTheLoai.PlaceholderText = "Nhập tên thể loại...";
        txtTenTheLoai.Size = new System.Drawing.Size(290, 30);
        txtTenTheLoai.TabIndex = 3;

        // 
        // lblMoTa
        // 
        lblMoTa.AutoSize = true;
        lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblMoTa.Location = new System.Drawing.Point(30, 116);
        lblMoTa.Name = "lblMoTa";
        lblMoTa.Size = new System.Drawing.Size(55, 23);
        lblMoTa.TabIndex = 4;
        lblMoTa.Text = "Mô tả";

        // 
        // txtMoTa
        // 
        txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtMoTa.Location = new System.Drawing.Point(145, 113);
        txtMoTa.Multiline = true;
        txtMoTa.Name = "txtMoTa";
        txtMoTa.PlaceholderText = "Nhập mô tả thể loại...";
        txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtMoTa.Size = new System.Drawing.Size(290, 85);
        txtMoTa.TabIndex = 5;

        // 
        // lblNgayTaoTieuDe
        // 
        lblNgayTaoTieuDe.AutoSize = true;
        lblNgayTaoTieuDe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        lblNgayTaoTieuDe.Location = new System.Drawing.Point(520, 72);
        lblNgayTaoTieuDe.Name = "lblNgayTaoTieuDe";
        lblNgayTaoTieuDe.Size = new System.Drawing.Size(83, 23);
        lblNgayTaoTieuDe.TabIndex = 6;
        lblNgayTaoTieuDe.Text = "Ngày tạo:";

        // 
        // lblNgayTao
        // 
        lblNgayTao.AutoSize = true;
        lblNgayTao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        lblNgayTao.ForeColor = System.Drawing.Color.MidnightBlue;
        lblNgayTao.Location = new System.Drawing.Point(615, 72);
        lblNgayTao.Name = "lblNgayTao";
        lblNgayTao.Size = new System.Drawing.Size(35, 23);
        lblNgayTao.TabIndex = 7;
        lblNgayTao.Text = "---";

        // 
        // btnThem
        // 
        btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnThem.Location = new System.Drawing.Point(510, 22);
        btnThem.Name = "btnThem";
        btnThem.Size = new System.Drawing.Size(95, 36);
        btnThem.TabIndex = 8;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // 
        // btnSua
        // 
        btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
        btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnSua.Location = new System.Drawing.Point(620, 22);
        btnSua.Name = "btnSua";
        btnSua.Size = new System.Drawing.Size(95, 36);
        btnSua.TabIndex = 9;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // 
        // btnXoa
        // 
        btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnXoa.Location = new System.Drawing.Point(730, 22);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new System.Drawing.Size(95, 36);
        btnXoa.TabIndex = 10;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // 
        // btnLamMoi
        // 
        btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnLamMoi.Location = new System.Drawing.Point(840, 22);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(100, 36);
        btnLamMoi.TabIndex = 11;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // 
        // txtTimKiem
        // 
        txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        txtTimKiem.Location = new System.Drawing.Point(30, 218);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Nhập tên thể loại cần tìm kiếm...";
        txtTimKiem.Size = new System.Drawing.Size(405, 30);
        txtTimKiem.TabIndex = 12;
        txtTimKiem.KeyDown += txtTimKiem_KeyDown;

        // 
        // btnTimKiem
        // 
        btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
        btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        btnTimKiem.Location = new System.Drawing.Point(448, 215);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new System.Drawing.Size(125, 36);
        btnTimKiem.TabIndex = 13;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;

        // 
        // dgvTheLoai
        // 
        dgvTheLoai.AllowUserToAddRows = false;
        dgvTheLoai.AllowUserToDeleteRows = false;
        dgvTheLoai.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvTheLoai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvTheLoai.BackgroundColor = System.Drawing.Color.White;
        dgvTheLoai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        
        dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        dgvHeaderStyle.ForeColor = System.Drawing.SystemColors.WindowText;
        dgvHeaderStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvHeaderStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        dgvTheLoai.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
        dgvTheLoai.ColumnHeadersHeight = 32;

        dgvCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dgvCellStyle.BackColor = System.Drawing.SystemColors.Window;
        dgvCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        dgvCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
        dgvCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dgvCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dgvCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        dgvTheLoai.DefaultCellStyle = dgvCellStyle;

        dgvTheLoai.Location = new System.Drawing.Point(30, 265);
        dgvTheLoai.MultiSelect = false;
        dgvTheLoai.Name = "dgvTheLoai";
        dgvTheLoai.ReadOnly = true;
        dgvTheLoai.RowHeadersWidth = 35;
        dgvTheLoai.RowTemplate.Height = 28;
        dgvTheLoai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvTheLoai.Size = new System.Drawing.Size(910, 310);
        dgvTheLoai.TabIndex = 14;
        dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;

        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(970, 600);
        Controls.Add(lblMaTL);
        Controls.Add(txtMaTL);
        Controls.Add(lblTenTheLoai);
        Controls.Add(txtTenTheLoai);
        Controls.Add(lblMoTa);
        Controls.Add(txtMoTa);
        Controls.Add(lblNgayTaoTieuDe);
        Controls.Add(lblNgayTao);
        Controls.Add(btnThem);
        Controls.Add(btnSua);
        Controls.Add(btnXoa);
        Controls.Add(btnLamMoi);
        Controls.Add(txtTimKiem);
        Controls.Add(btnTimKiem);
        Controls.Add(dgvTheLoai);
        MinimumSize = new System.Drawing.Size(850, 500);
        Name = "Form1";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
        Load += Form1_Load;
        ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
