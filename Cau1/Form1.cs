using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TriThucBooks.Models;

namespace TriThucBooks;

public partial class Form1 : Form
{
    private readonly AppDbContext _context;

    public Form1()
    {
        InitializeComponent();
        _context = new AppDbContext();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    /// <summary>
    /// Tải dữ liệu toàn bộ bảng TheLoaiSach lên DataGridView
    /// </summary>
    private async Task LoadDataAsync()
    {
        try
        {
            var list = await _context.TheLoaiSaches
                .AsNoTracking()
                .OrderBy(t => t.MaTl)
                .ToListAsync();

            dgvTheLoai.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Định dạng tiêu đề và độ rộng các cột trên DataGridView
    /// </summary>
    private void SetupDataGridView()
    {
        if (dgvTheLoai.Columns.Count == 0) return;

        if (dgvTheLoai.Columns["MaTl"] is DataGridViewColumn colMaTl)
        {
            colMaTl.HeaderText = "Mã TL";
            colMaTl.FillWeight = 50;
        }

        if (dgvTheLoai.Columns["TenTheLoai"] is DataGridViewColumn colTenTL)
        {
            colTenTL.HeaderText = "Tên thể loại";
            colTenTL.FillWeight = 120;
        }

        if (dgvTheLoai.Columns["MoTa"] is DataGridViewColumn colMoTa)
        {
            colMoTa.HeaderText = "Mô tả";
            colMoTa.FillWeight = 160;
        }

        if (dgvTheLoai.Columns["SoLuongSach"] is DataGridViewColumn colSoLuong)
        {
            colSoLuong.HeaderText = "Số lượng sách";
            colSoLuong.FillWeight = 70;
        }

        if (dgvTheLoai.Columns["CreateAt"] is DataGridViewColumn colCreateAt)
        {
            colCreateAt.HeaderText = "Ngày tạo";
            colCreateAt.DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
            colCreateAt.FillWeight = 100;
        }

        if (dgvTheLoai.Columns["UpdateAt"] is DataGridViewColumn colUpdateAt)
        {
            colUpdateAt.Visible = false; // Ẩn cột cập nhật để bám sát giao diện mẫu
        }
    }

    /// <summary>
    /// Tự động đổ dữ liệu dòng đang chọn lên các ô nhập liệu
    /// </summary>
    private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTheLoai.CurrentRow != null && dgvTheLoai.CurrentRow.Index >= 0)
        {
            var row = dgvTheLoai.CurrentRow;
            txtMaTL.Text = row.Cells["MaTl"].Value?.ToString() ?? "";
            txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

            if (row.Cells["CreateAt"].Value is DateTime dt)
            {
                lblNgayTao.Text = dt.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                lblNgayTao.Text = "---";
            }
        }
    }

    /// <summary>
    /// Xóa trắng các control nhập liệu
    /// </summary>
    private void ResetInputs()
    {
        txtMaTL.Clear();
        txtTenTheLoai.Clear();
        txtMoTa.Clear();
        lblNgayTao.Text = "---";
        txtTenTheLoai.Focus();
    }

    /// <summary>
    /// Chọn dòng theo Mã TL trên DataGridView
    /// </summary>
    private void SelectRowById(int maTl)
    {
        foreach (DataGridViewRow row in dgvTheLoai.Rows)
        {
            if (row.Cells["MaTl"].Value is int id && id == maTl)
            {
                row.Selected = true;
                dgvTheLoai.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    /// <summary>
    /// Chức năng Thêm mới
    /// </summary>
    private async void btnThem_Click(object sender, EventArgs e)
    {
        string tenTL = txtTenTheLoai.Text.Trim();

        // Kiểm tra validate: Tên thể loại không được bỏ trống
        if (string.IsNullOrWhiteSpace(tenTL))
        {
            MessageBox.Show("Vui lòng nhập Tên thể loại!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return;
        }

        try
        {
            // Kiểm tra trùng tên thể loại khi thêm mới (Case-Insensitive)
            bool isDuplicate = await _context.TheLoaiSaches.AnyAsync(t => t.TenTheLoai.ToLower() == tenTL.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show($"Thể loại '{tenTL}' đã tồn tại! Vui lòng nhập tên khác.", "Trùng tên thể loại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.SelectAll();
                txtTenTheLoai.Focus();
                return;
            }

            var newTheLoai = new TheLoaiSach
            {
                TenTheLoai = tenTL,
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
                SoLuongSach = 0,
                CreateAt = DateTime.Now
            };

            _context.TheLoaiSaches.Add(newTheLoai);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm mới thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại DataGridView ngay sau khi lưu
            await LoadDataAsync();
            SelectRowById(newTheLoai.MaTl);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thêm thể loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Sửa / Cập nhật
    /// </summary>
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int maTL))
        {
            MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string tenTL = txtTenTheLoai.Text.Trim();

        // Kiểm tra validate: Tên thể loại không được bỏ trống
        if (string.IsNullOrWhiteSpace(tenTL))
        {
            MessageBox.Show("Tên thể loại không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenTheLoai.Focus();
            return;
        }

        try
        {
            // Kiểm tra trùng tên thể loại với các bản ghi khác
            bool isDuplicate = await _context.TheLoaiSaches.AnyAsync(t => t.MaTl != maTL && t.TenTheLoai.ToLower() == tenTL.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show($"Tên thể loại '{tenTL}' đã được sử dụng bởi mã thể loại khác!", "Trùng tên thể loại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.SelectAll();
                txtTenTheLoai.Focus();
                return;
            }

            var entity = await _context.TheLoaiSaches.FindAsync(maTL);
            if (entity == null)
            {
                MessageBox.Show("Không tìm thấy thể loại cần cập nhật trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entity.TenTheLoai = tenTL;
            entity.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
            entity.UpdateAt = DateTime.Now;

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại DataGridView
            await LoadDataAsync();
            SelectRowById(maTL);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật thể loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Xóa với hộp thoại xác nhận và bắt lỗi DbUpdateException
    /// </summary>
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaTL.Text, out int maTL))
        {
            MessageBox.Show("Vui lòng chọn một thể loại từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string tenTL = txtTenTheLoai.Text.Trim();

        // Hộp thoại xác nhận Yes/No
        var confirmResult = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa thể loại '{tenTL}' (Mã: {maTL}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirmResult != DialogResult.Yes)
        {
            return;
        }

        try
        {
            var entity = await _context.TheLoaiSaches.FindAsync(maTL);
            if (entity != null)
            {
                _context.TheLoaiSaches.Remove(entity);
                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView ngay sau khi xóa
                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            // Bắt lỗi ràng buộc khóa ngoại (foreign key constraint) khi thể loại đang được bảng khác tham chiếu
            _context.ChangeTracker.Clear();
            MessageBox.Show(
                "Không thể xóa thể loại này vì đang được sách khác tham chiếu!",
                "Lỗi ràng buộc dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show($"Lỗi khi xóa thể loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Tìm kiếm theo Tên thể loại dùng LINQ (Where + Contains)
    /// </summary>
    private async void btnTimKiem_Click(object sender, EventArgs e)
    {
        await PerformSearchAsync();
    }

    private async void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true; // Ngăn tiếng 'beep' khi ấn Enter
            await PerformSearchAsync();
        }
    }

    private async Task PerformSearchAsync()
    {
        string keyword = txtTimKiem.Text.Trim().ToLower();

        try
        {
            var result = await _context.TheLoaiSaches
                .AsNoTracking()
                .Where(t => t.TenTheLoai.ToLower().Contains(keyword))
                .OrderBy(t => t.MaTl)
                .ToListAsync();

            dgvTheLoai.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy thể loại nào phù hợp với từ khóa '{txtTimKiem.Text.Trim()}'!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Làm mới
    /// </summary>
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();
        txtTimKiem.Clear();
        await LoadDataAsync();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context?.Dispose();
        base.OnFormClosed(e);
    }
}
