using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using AnKhangClinic.Models;

namespace AnKhangClinic;

public partial class FormBacSi : Form
{
    private readonly AppDbContext _context;

    public FormBacSi()
    {
        InitializeComponent();
        _context = new AppDbContext();
    }

    private async void FormBacSi_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var list = await _context.BacSis
                .AsNoTracking()
                .OrderBy(b => b.MaBs)
                .ToListAsync();

            dgvBacSi.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tải danh sách bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetupDataGridView()
    {
        if (dgvBacSi.Columns.Count == 0) return;

        if (dgvBacSi.Columns["MaBs"] is DataGridViewColumn colMa)
        {
            colMa.HeaderText = "Mã BS";
            colMa.FillWeight = 50;
        }

        if (dgvBacSi.Columns["HoTen"] is DataGridViewColumn colTen)
        {
            colTen.HeaderText = "Họ tên";
            colTen.FillWeight = 110;
        }

        if (dgvBacSi.Columns["ChuyenKhoa"] is DataGridViewColumn colKhoa)
        {
            colKhoa.HeaderText = "Chuyên khoa";
            colKhoa.FillWeight = 110;
        }

        if (dgvBacSi.Columns["Sdt"] is DataGridViewColumn colSdt)
        {
            colSdt.HeaderText = "SĐT";
            colSdt.FillWeight = 80;
        }

        if (dgvBacSi.Columns["LichKhams"] is DataGridViewColumn colLk)
        {
            colLk.Visible = false;
        }
    }

    private void dgvBacSi_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvBacSi.CurrentRow != null && dgvBacSi.CurrentRow.Index >= 0)
        {
            var row = dgvBacSi.CurrentRow;
            txtMaBS.Text = row.Cells["MaBs"].Value?.ToString() ?? "";
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";
        }
    }

    private void ResetInputs()
    {
        txtMaBS.Clear();
        txtHoTen.Clear();
        txtChuyenKhoa.Clear();
        txtSDT.Clear();
        txtHoTen.Focus();
    }

    private async void btnThem_Click(object sender, EventArgs e)
    {
        string hoTen = txtHoTen.Text.Trim();
        if (string.IsNullOrWhiteSpace(hoTen))
        {
            MessageBox.Show("Vui lòng nhập Họ tên bác sĩ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        try
        {
            var bs = new BacSi
            {
                HoTen = hoTen,
                ChuyenKhoa = string.IsNullOrWhiteSpace(txtChuyenKhoa.Text) ? null : txtChuyenKhoa.Text.Trim(),
                Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim()
            };

            _context.BacSis.Add(bs);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadDataAsync();
            ResetInputs();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thêm bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaBS.Text, out int maBs))
        {
            MessageBox.Show("Vui lòng chọn một bác sĩ để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string hoTen = txtHoTen.Text.Trim();
        if (string.IsNullOrWhiteSpace(hoTen))
        {
            MessageBox.Show("Họ tên bác sĩ không được để trống!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return;
        }

        try
        {
            var entity = await _context.BacSis.FindAsync(maBs);
            if (entity != null)
            {
                entity.HoTen = hoTen;
                entity.ChuyenKhoa = string.IsNullOrWhiteSpace(txtChuyenKhoa.Text) ? null : txtChuyenKhoa.Text.Trim();
                entity.Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();

                await _context.SaveChangesAsync();
                MessageBox.Show("Cập nhật thông tin bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi cập nhật bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtMaBS.Text, out int maBs))
        {
            MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa bác sĩ '{txtHoTen.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            var entity = await _context.BacSis.FindAsync(maBs);
            if (entity != null)
            {
                _context.BacSis.Remove(entity);
                await _context.SaveChangesAsync();
                MessageBox.Show("Xóa bác sĩ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Không thể xóa bác sĩ này do đã có lịch khám liên kết!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
