using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using FitZoneGym.Models;

namespace FitZoneGym;

public partial class Form1 : Form
{
    private readonly AppDbContext _context;
    private int _selectedMaHv = 0;

    public Form1()
    {
        InitializeComponent();
        _context = new AppDbContext();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        InitComboBoxData();
        await SeedSampleDataIfEmptyAsync();
        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    /// <summary>
    /// Nạp dữ liệu mẫu giống hình đề bài nếu bảng HoiVien đang rỗng
    /// </summary>
    private async Task SeedSampleDataIfEmptyAsync()
    {
        try
        {
            if (!await _context.HoiViens.AnyAsync())
            {
                var sampleList = new List<HoiVien>
                {
                    new HoiVien { HoTen = "Hồ Văn Vôn", GioiTinh = true, NgaySinh = new DateOnly(1999, 11, 7), Sdt = "07382735879", Email = "vonhv@gmail.com", HangThanhVien = "Basic", TrangThai = true, NgayDangKy = DateTime.Now },
                    new HoiVien { HoTen = "Nguyễn Anh", GioiTinh = true, NgaySinh = new DateOnly(1999, 11, 10), Sdt = "07382731034", Email = "anhnguyen@gmail.com", HangThanhVien = "Premium", TrangThai = true, NgayDangKy = DateTime.Now },
                    new HoiVien { HoTen = "Nguyễn Bá Đán", GioiTinh = true, NgaySinh = new DateOnly(1999, 12, 29), Sdt = "07882773727", Email = "dannguyen@gmail.com", HangThanhVien = "Basic", TrangThai = true, NgayDangKy = DateTime.Now },
                    new HoiVien { HoTen = "Nguyễn Kim", GioiTinh = true, NgaySinh = new DateOnly(1999, 11, 17), Sdt = "07375856597", Email = "kimnguyen@gmail.com", HangThanhVien = "VIP", TrangThai = true, NgayDangKy = DateTime.Now },
                    new HoiVien { HoTen = "Nguyễn Tương", GioiTinh = false, NgaySinh = new DateOnly(1999, 1, 22), Sdt = "07887775931", Email = "tuongnguyen@gmail.com", HangThanhVien = "Premium", TrangThai = true, NgayDangKy = DateTime.Now }
                };

                _context.HoiViens.AddRange(sampleList);
                await _context.SaveChangesAsync();
            }
        }
        catch
        {
            // Bỏ qua nếu bảng đã có dữ liệu hoặc CSDL không cho phép nạp tự động
        }
    }

    /// <summary>
    /// Khởi tạo dữ liệu nạp cứng cho các ComboBox
    /// </summary>
    private void InitComboBoxData()
    {
        // Nạp cứng 3 hạng thành viên cho ComboBox nhập liệu
        cboHangThanhVien.Items.Clear();
        cboHangThanhVien.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
        cboHangThanhVien.SelectedIndex = 0;

        // ComboBox lọc kết hợp điều kiện tìm kiếm
        cboLocHangThanhVien.Items.Clear();
        cboLocHangThanhVien.Items.AddRange(new object[] { "-- Tất cả hạng --", "Basic", "VIP", "Premium" });
        cboLocHangThanhVien.SelectedIndex = 0;
    }

    /// <summary>
    /// ViewModel giúp hiển thị các trường dữ liệu thân thiện trên DataGridView
    /// </summary>
    public class HoiVienViewModel
    {
        public int MaHv { get; set; }
        public string HoTen { get; set; } = null!;
        public string GioiTinhHienThi => GioiTinh ? "Nam" : "Nữ";
        public bool GioiTinh { get; set; }
        public DateOnly NgaySinh { get; set; }
        public string NgaySinhHienThi => NgaySinh.ToString("dd/MM/yyyy");
        public string Sdt { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HangThanhVien { get; set; } = null!;
        public string TrangThaiHienThi => TrangThai ? "Đang hoạt động" : "Tạm ngưng";
        public bool TrangThai { get; set; }
        public DateTime NgayDangKy { get; set; }
    }

    /// <summary>
    /// Tải toàn bộ danh sách hội viên lên DataGridView
    /// </summary>
    private async Task LoadDataAsync()
    {
        try
        {
            var list = await _context.HoiViens
                .AsNoTracking()
                .OrderBy(h => h.MaHv)
                .Select(h => new HoiVienViewModel
                {
                    MaHv = h.MaHv,
                    HoTen = h.HoTen,
                    GioiTinh = h.GioiTinh,
                    NgaySinh = h.NgaySinh,
                    Sdt = h.Sdt,
                    Email = h.Email,
                    HangThanhVien = h.HangThanhVien,
                    TrangThai = h.TrangThai,
                    NgayDangKy = h.NgayDangKy
                })
                .ToListAsync();

            dgvHoiVien.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Định dạng hiển thị các cột trên DataGridView bám sát đề bài
    /// </summary>
    private void SetupDataGridView()
    {
        if (dgvHoiVien.Columns.Count == 0) return;

        if (dgvHoiVien.Columns["MaHv"] is DataGridViewColumn colMaHv)
        {
            colMaHv.HeaderText = "Mã HV";
            colMaHv.FillWeight = 50;
        }

        if (dgvHoiVien.Columns["HoTen"] is DataGridViewColumn colHoTen)
        {
            colHoTen.HeaderText = "Họ tên";
            colHoTen.FillWeight = 120;
        }

        if (dgvHoiVien.Columns["GioiTinhHienThi"] is DataGridViewColumn colGioiTinh)
        {
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.FillWeight = 65;
        }

        if (dgvHoiVien.Columns["NgaySinhHienThi"] is DataGridViewColumn colNgaySinh)
        {
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.FillWeight = 85;
        }

        if (dgvHoiVien.Columns["Sdt"] is DataGridViewColumn colSdt)
        {
            colSdt.HeaderText = "SĐT";
            colSdt.FillWeight = 95;
        }

        if (dgvHoiVien.Columns["Email"] is DataGridViewColumn colEmail)
        {
            colEmail.HeaderText = "Email";
            colEmail.FillWeight = 110;
        }

        if (dgvHoiVien.Columns["HangThanhVien"] is DataGridViewColumn colHang)
        {
            colHang.HeaderText = "Hạng thành viên";
            colHang.FillWeight = 95;
        }

        if (dgvHoiVien.Columns["TrangThaiHienThi"] is DataGridViewColumn colTrangThai)
        {
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.FillWeight = 100;
        }

        // Ẩn các cột dữ liệu gốc dùng để gán ngược lại Form
        if (dgvHoiVien.Columns["GioiTinh"] is DataGridViewColumn colGtRaw) colGtRaw.Visible = false;
        if (dgvHoiVien.Columns["NgaySinh"] is DataGridViewColumn colNsRaw) colNsRaw.Visible = false;
        if (dgvHoiVien.Columns["TrangThai"] is DataGridViewColumn colTtRaw) colTtRaw.Visible = false;
        if (dgvHoiVien.Columns["NgayDangKy"] is DataGridViewColumn colNdkRaw) colNdkRaw.Visible = false;
    }

    /// <summary>
    /// Sự kiện SelectionChanged: Đổ ngược đầy đủ dữ liệu lên toàn bộ control
    /// </summary>
    private void dgvHoiVien_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvHoiVien.CurrentRow != null && dgvHoiVien.CurrentRow.Index >= 0)
        {
            var row = dgvHoiVien.CurrentRow;

            if (row.Cells["MaHv"].Value is int maHv)
            {
                _selectedMaHv = maHv;
            }

            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";

            // Gán đúng RadioButton giới tính
            if (row.Cells["GioiTinh"].Value is bool gioiTinh)
            {
                if (gioiTinh)
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }

            // Gán đúng DateTimePicker ngày sinh
            if (row.Cells["NgaySinh"].Value is DateOnly ngaySinh)
            {
                dtpNgaySinh.Value = new DateTime(ngaySinh.Year, ngaySinh.Month, ngaySinh.Day);
            }

            // Gán đúng vị trí ComboBox hạng thành viên
            string? hang = row.Cells["HangThanhVien"].Value?.ToString();
            if (!string.IsNullOrEmpty(hang))
            {
                cboHangThanhVien.SelectedItem = hang;
            }

            // Gán đúng trạng thái CheckBox
            if (row.Cells["TrangThai"].Value is bool trangThai)
            {
                chkTrangThai.Checked = trangThai;
            }
        }
    }

    /// <summary>
    /// Xóa trắng và đưa các control về trạng thái mặc định
    /// </summary>
    private void ResetInputs()
    {
        _selectedMaHv = 0;
        txtHoTen.Clear();
        txtSDT.Clear();
        txtEmail.Clear();
        rdoNam.Checked = true;
        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        cboHangThanhVien.SelectedIndex = 0;
        chkTrangThai.Checked = true;
        txtHoTen.Focus();
    }

    /// <summary>
    /// Chọn dòng tương ứng trên DataGridView sau khi thêm/sửa
    /// </summary>
    private void SelectRowById(int maHv)
    {
        foreach (DataGridViewRow row in dgvHoiVien.Rows)
        {
            if (row.Cells["MaHv"].Value is int id && id == maHv)
            {
                row.Selected = true;
                dgvHoiVien.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu đầu vào (Validate chi tiết từng trường)
    /// </summary>
    private bool ValidateInputs()
    {
        // 1. Kiểm tra Họ tên
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập Họ tên hội viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        // 2. Validate SĐT: Chỉ chứa chữ số và độ dài 9 - 11 ký tự
        string sdt = txtSDT.Text.Trim();
        if (string.IsNullOrWhiteSpace(sdt))
        {
            MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSDT.Focus();
            return false;
        }
        if (!Regex.IsMatch(sdt, @"^\d{9,11}$"))
        {
            MessageBox.Show("Số điện thoại không hợp lệ! SĐT chỉ được chứa chữ số và phải có từ 9 đến 11 chữ số.", "Lỗi định dạng SĐT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSDT.SelectAll();
            txtSDT.Focus();
            return false;
        }

        // 3. Validate Email: Phải chứa ký tự '@'
        string email = txtEmail.Text.Trim();
        if (string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show("Vui lòng nhập Email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return false;
        }
        if (!email.Contains("@"))
        {
            MessageBox.Show("Email không hợp lệ! Email phải chứa ký tự '@'.", "Lỗi định dạng Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.SelectAll();
            txtEmail.Focus();
            return false;
        }

        // 4. Validate Tuổi: Phải từ 15 tuổi trở lên tính từ Ngày sinh đến hiện tại
        DateTime birthDate = dtpNgaySinh.Value.Date;
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
        {
            age--;
        }

        if (age < 15)
        {
            MessageBox.Show($"Hội viên phải từ 15 tuổi trở lên mới được đăng ký! (Tuổi hiện tại: {age} tuổi)", "Chưa đủ điều kiện độ tuổi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgaySinh.Focus();
            return false;
        }

        // 5. Validate Hạng thành viên
        if (cboHangThanhVien.SelectedIndex < 0)
        {
            MessageBox.Show("Vui lòng chọn Hạng thành viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboHangThanhVien.Focus();
            return false;
        }

        return true;
    }

    /// <summary>
    /// Chức năng Thêm mới hội viên
    /// </summary>
    private async void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        try
        {
            var newHoiVien = new HoiVien
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = rdoNam.Checked,
                NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value),
                Sdt = txtSDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                HangThanhVien = cboHangThanhVien.SelectedItem!.ToString()!,
                NgayDangKy = DateTime.Now,
                TrangThai = chkTrangThai.Checked
            };

            _context.HoiViens.Add(newHoiVien);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm mới hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(newHoiVien.MaHv);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thêm hội viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Sửa thông tin hội viên
    /// </summary>
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaHv <= 0)
        {
            MessageBox.Show("Vui lòng chọn một hội viên từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInputs()) return;

        try
        {
            var entity = await _context.HoiViens.FindAsync(_selectedMaHv);
            if (entity == null)
            {
                MessageBox.Show("Không tìm thấy hội viên cần cập nhật trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entity.HoTen = txtHoTen.Text.Trim();
            entity.GioiTinh = rdoNam.Checked;
            entity.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            entity.Sdt = txtSDT.Text.Trim();
            entity.Email = txtEmail.Text.Trim();
            entity.HangThanhVien = cboHangThanhVien.SelectedItem!.ToString()!;
            entity.TrangThai = chkTrangThai.Checked;

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật thông tin hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(_selectedMaHv);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật hội viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Xóa hội viên với xác nhận YesNo
    /// </summary>
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaHv <= 0)
        {
            MessageBox.Show("Vui lòng chọn một hội viên từ danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string hoTen = txtHoTen.Text.Trim();
        var confirmResult = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa hội viên '{hoTen}' (Mã: {_selectedMaHv}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirmResult != DialogResult.Yes) return;

        try
        {
            var entity = await _context.HoiViens.FindAsync(_selectedMaHv);
            if (entity != null)
            {
                _context.HoiViens.Remove(entity);
                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa hội viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Không thể xóa hội viên này do đang có dữ liệu ràng buộc khác tham chiếu!", "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show($"Lỗi khi xóa hội viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Tìm kiếm kết hợp 2 điều kiện: Họ tên VÀ Hạng thành viên dùng LINQ (Where với &&)
    /// </summary>
    private async void btnTimKiem_Click(object sender, EventArgs e)
    {
        await PerformSearchAsync();
    }

    private async void txtTimKiemHoTen_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            await PerformSearchAsync();
        }
    }

    private async Task PerformSearchAsync()
    {
        string keywordTen = txtTimKiemHoTen.Text.Trim().ToLower();
        string selectedHang = cboLocHangThanhVien.SelectedItem?.ToString() ?? "-- Tất cả hạng --";

        try
        {
            var query = _context.HoiViens.AsNoTracking().AsQueryable();

            // Minh họa LINQ Where kết hợp nhiều điều kiện dùng toán tử &&
            if (!string.IsNullOrEmpty(keywordTen) && selectedHang != "-- Tất cả hạng --")
            {
                query = query.Where(h => h.HoTen.ToLower().Contains(keywordTen) && h.HangThanhVien == selectedHang);
            }
            else if (!string.IsNullOrEmpty(keywordTen))
            {
                query = query.Where(h => h.HoTen.ToLower().Contains(keywordTen));
            }
            else if (selectedHang != "-- Tất cả hạng --")
            {
                query = query.Where(h => h.HangThanhVien == selectedHang);
            }

            var result = await query
                .OrderBy(h => h.MaHv)
                .Select(h => new HoiVienViewModel
                {
                    MaHv = h.MaHv,
                    HoTen = h.HoTen,
                    GioiTinh = h.GioiTinh,
                    NgaySinh = h.NgaySinh,
                    Sdt = h.Sdt,
                    Email = h.Email,
                    HangThanhVien = h.HangThanhVien,
                    TrangThai = h.TrangThai,
                    NgayDangKy = h.NgayDangKy
                })
                .ToListAsync();

            dgvHoiVien.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hội viên nào phù hợp với điều kiện tìm kiếm!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Làm mới Form và nạp lại dữ liệu
    /// </summary>
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();
        txtTimKiemHoTen.Clear();
        cboLocHangThanhVien.SelectedIndex = 0;
        await LoadDataAsync();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context?.Dispose();
        base.OnFormClosed(e);
    }
}
