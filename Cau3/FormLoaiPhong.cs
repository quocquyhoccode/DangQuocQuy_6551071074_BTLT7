using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

namespace SunriseHomestay;

public partial class FormLoaiPhong : Form
{
    private readonly AppDbContext _context;

    public FormLoaiPhong()
    {
        InitializeComponent();
        _context = new AppDbContext();
    }

    private async void FormLoaiPhong_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var list = await _context.LoaiPhongs
                .AsNoTracking()
                .OrderBy(l => l.MaLoai)
                .ToListAsync();

            dgvLoaiPhong.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tải loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetupDataGridView()
    {
        if (dgvLoaiPhong.Columns.Count == 0) return;

        if (dgvLoaiPhong.Columns["MaLoai"] is DataGridViewColumn colMa)
        {
            colMa.HeaderText = "Mã loại";
            colMa.FillWeight = 50;
        }

        if (dgvLoaiPhong.Columns["TenLoai"] is DataGridViewColumn colTen)
        {
            colTen.HeaderText = "Tên loại";
            colTen.FillWeight = 100;
        }

        if (dgvLoaiPhong.Columns["GiaMoiDem"] is DataGridViewColumn colGia)
        {
            colGia.HeaderText = "Giá/đêm";
            colGia.DefaultCellStyle.Format = "N0";
            colGia.FillWeight = 70;
        }

        if (dgvLoaiPhong.Columns["MoTa"] is DataGridViewColumn colMoTa)
        {
            colMoTa.HeaderText = "Mô tả";
            colMoTa.FillWeight = 120;
        }

        if (dgvLoaiPhong.Columns["Phongs"] is DataGridViewColumn colPhongs)
        {
            colPhongs.Visible = false;
        }
    }

    private void dgvLoaiPhong_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvLoaiPhong.CurrentRow != null && dgvLoaiPhong.CurrentRow.Index >= 0)
        {
            var row = dgvLoaiPhong.CurrentRow;
            txtMaLoai.Text = row.Cells["MaLoai"].Value?.ToString() ?? "";
            txtTenLoai.Text = row.Cells["TenLoai"].Value?.ToString() ?? "";
            txtGiaMoiDem.Text = row.Cells["GiaMoiDem"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
        }
    }

    private void ResetInputs()
    {
        txtMaLoai.Clear();
        txtTenLoai.Clear();
        txtGiaMoiDem.Clear();
        txtMoTa.Clear();
        txtTenLoai.Focus();
    }

    private async void btnThem_Click(object sender, EventArgs e)
    {
        string ten = txtTenLoai.Text.Trim();
        if (string.IsNullOrWhiteSpace(ten))
        {
            MessageBox.Show("Vui lòng nhập Tên loại phòng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLoai.Focus();
            return;
        }

        if (!decimal.TryParse(txtGiaMoiDem.Text.Trim(), out decimal gia) || gia < 0)
        {
            MessageBox.Show("Giá mỗi đêm phải là số hợp lệ >= 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtGiaMoiDem.Focus();
            return;
        }

        try
        {
            var loai = new LoaiPhong
            {
                TenLoai = ten,
                GiaMoiDem = gia,
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
            };

            _context.LoaiPhongs.Add(loai);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            ResetInputs();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thêm loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaLoai.Text, out int maLoai))
        {
            MessageBox.Show("Vui lòng chọn một loại phòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string ten = txtTenLoai.Text.Trim();
        if (string.IsNullOrWhiteSpace(ten))
        {
            MessageBox.Show("Tên loại phòng không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenLoai.Focus();
            return;
        }

        if (!decimal.TryParse(txtGiaMoiDem.Text.Trim(), out decimal gia) || gia < 0)
        {
            MessageBox.Show("Giá mỗi đêm phải là số hợp lệ >= 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtGiaMoiDem.Focus();
            return;
        }

        try
        {
            var entity = await _context.LoaiPhongs.FindAsync(maLoai);
            if (entity != null)
            {
                entity.TenLoai = ten;
                entity.GiaMoiDem = gia;
                entity.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

                await _context.SaveChangesAsync();
                MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaLoai.Text, out int maLoai))
        {
            MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa loại phòng '{txtTenLoai.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            var entity = await _context.LoaiPhongs.FindAsync(maLoai);
            if (entity != null)
            {
                _context.LoaiPhongs.Remove(entity);
                await _context.SaveChangesAsync();
                MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Không thể xóa loại phòng này vì đang có phòng thuộc loại này!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();
        await LoadDataAsync();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context?.Dispose();
        base.OnFormClosed(e);
    }
}
