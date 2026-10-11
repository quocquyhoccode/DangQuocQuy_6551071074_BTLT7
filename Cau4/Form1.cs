using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using AnKhangClinic.Models;

namespace AnKhangClinic;

public partial class Form1 : Form
{
    private readonly AppDbContext _context;
    private int _selectedMaLich = 0;

    public Form1()
    {
        InitializeComponent();
        _context = new AppDbContext();
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await SeedSampleDataIfEmptyAsync();
        await LoadBacSiComboBoxesAsync();
        cboTrangThai.SelectedIndex = 0;

        // Thiết lập mặc định khoảng ngày tìm kiếm (từ ngày 01 đến cuối tháng hoặc từ quá khứ đến hiện tại/tương lai)
        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today.AddDays(60);

        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    public class BacSiComboItem
    {
        public int MaBs { get; set; }
        public string HienThi { get; set; } = null!;
    }

    /// <summary>
    /// Nạp danh sách Bác sĩ từ CSDL vào ComboBox chính và ComboBox lọc tìm kiếm
    /// </summary>
    private async Task LoadBacSiComboBoxesAsync()
    {
        try
        {
            var bacSiList = await _context.BacSis
                .AsNoTracking()
                .OrderBy(b => b.MaBs)
                .ToListAsync();

            var comboItems = bacSiList.Select(b => new BacSiComboItem
            {
                MaBs = b.MaBs,
                HienThi = string.IsNullOrWhiteSpace(b.ChuyenKhoa) ? b.HoTen : $"{b.HoTen} - {b.ChuyenKhoa}"
            }).ToList();

            // ComboBox nhập liệu chính
            cboBacSi.DataSource = null;
            cboBacSi.DisplayMember = "HienThi";
            cboBacSi.ValueMember = "MaBs";
            cboBacSi.DataSource = comboItems.ToList();

            // ComboBox tìm kiếm lọc
            var filterItems = new List<BacSiComboItem>
            {
                new BacSiComboItem { MaBs = 0, HienThi = "-- Tất cả bác sĩ --" }
            };
            filterItems.AddRange(comboItems);

            cboLocBacSi.DataSource = null;
            cboLocBacSi.DisplayMember = "HienThi";
            cboLocBacSi.ValueMember = "MaBs";
            cboLocBacSi.DataSource = filterItems;
            cboLocBacSi.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi nạp danh sách bác sĩ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// ViewModel hiển thị trên DataGridView
    /// </summary>
    public class LichKhamViewModel
    {
        public int MaLich { get; set; }
        public string TenBenhNhan { get; set; } = null!;
        public string? Sdt { get; set; }
        public DateOnly NgayKham { get; set; }
        public string NgayKhamHienThi => NgayKham.ToString("dd/MM/yyyy");
        public TimeOnly GioKham { get; set; }
        public string GioKhamHienThi => GioKham.ToString("HH:mm");
        public string TenBacSi { get; set; } = null!;
        public string? ChuyenKhoa { get; set; }
        public string TrangThai { get; set; } = null!;
        public int MaBs { get; set; }
    }

    /// <summary>
    /// Tải toàn bộ danh sách lịch khám qua LINQ Include Eager Loading
    /// </summary>
    private async Task LoadDataAsync()
    {
        try
        {
            var list = await _context.LichKhams
                .Include(l => l.MaBsNavigation)
                .AsNoTracking()
                .OrderBy(l => l.NgayKham)
                .ThenBy(l => l.GioKham)
                .Select(l => new LichKhamViewModel
                {
                    MaLich = l.MaLich,
                    TenBenhNhan = l.TenBenhNhan,
                    Sdt = l.Sdt,
                    NgayKham = l.NgayKham,
                    GioKham = l.GioKham,
                    TenBacSi = l.MaBsNavigation.HoTen,
                    ChuyenKhoa = l.MaBsNavigation.ChuyenKhoa ?? "",
                    TrangThai = l.TrangThai,
                    MaBs = l.MaBs
                })
                .ToListAsync();

            dgvLichKham.DataSource = list;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi nạp lịch khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Định dạng các cột hiển thị trên DataGridView
    /// </summary>
    private void SetupDataGridView()
    {
        if (dgvLichKham.Columns.Count == 0) return;

        if (dgvLichKham.Columns["MaLich"] is DataGridViewColumn colMa)
        {
            colMa.HeaderText = "Mã lịch";
            colMa.FillWeight = 50;
        }

        if (dgvLichKham.Columns["TenBenhNhan"] is DataGridViewColumn colTen)
        {
            colTen.HeaderText = "Tên bệnh nhân";
            colTen.FillWeight = 110;
        }

        if (dgvLichKham.Columns["Sdt"] is DataGridViewColumn colSdt)
        {
            colSdt.HeaderText = "SĐT";
            colSdt.FillWeight = 90;
        }

        if (dgvLichKham.Columns["NgayKhamHienThi"] is DataGridViewColumn colNgay)
        {
            colNgay.HeaderText = "Ngày khám";
            colNgay.FillWeight = 85;
        }

        if (dgvLichKham.Columns["GioKhamHienThi"] is DataGridViewColumn colGio)
        {
            colGio.HeaderText = "Giờ khám";
            colGio.FillWeight = 65;
        }

        if (dgvLichKham.Columns["TenBacSi"] is DataGridViewColumn colBs)
        {
            colBs.HeaderText = "Bác sĩ";
            colBs.FillWeight = 130;
        }

        if (dgvLichKham.Columns["ChuyenKhoa"] is DataGridViewColumn colKhoa)
        {
            colKhoa.HeaderText = "Chuyên khoa";
            colKhoa.FillWeight = 95;
        }

        if (dgvLichKham.Columns["TrangThai"] is DataGridViewColumn colTt)
        {
            colTt.HeaderText = "Trạng thái";
            colTt.FillWeight = 75;
        }

        // Ẩn các cột dữ liệu gốc
        if (dgvLichKham.Columns["NgayKham"] is DataGridViewColumn colNkRaw) colNkRaw.Visible = false;
        if (dgvLichKham.Columns["GioKham"] is DataGridViewColumn colGkRaw) colGkRaw.Visible = false;
        if (dgvLichKham.Columns["MaBs"] is DataGridViewColumn colBsRaw) colBsRaw.Visible = false;
    }

    /// <summary>
    /// Đổ dữ liệu dòng đang chọn lên các control nhập liệu
    /// </summary>
    private void dgvLichKham_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvLichKham.CurrentRow != null && dgvLichKham.CurrentRow.Index >= 0)
        {
            var row = dgvLichKham.CurrentRow;

            if (row.Cells["MaLich"].Value is int maLich)
            {
                _selectedMaLich = maLich;
            }

            txtTenBenhNhan.Text = row.Cells["TenBenhNhan"].Value?.ToString() ?? "";
            txtSDT.Text = row.Cells["Sdt"].Value?.ToString() ?? "";

            if (row.Cells["NgayKham"].Value is DateOnly ngayKham)
            {
                dtpNgayKham.Value = new DateTime(ngayKham.Year, ngayKham.Month, ngayKham.Day);
            }

            if (row.Cells["GioKham"].Value is TimeOnly gioKham)
            {
                dtpGioKham.Value = DateTime.Today.Add(gioKham.ToTimeSpan());
            }

            if (row.Cells["MaBs"].Value is int maBs)
            {
                cboBacSi.SelectedValue = maBs;
            }

            string? tt = row.Cells["TrangThai"].Value?.ToString();
            if (!string.IsNullOrEmpty(tt))
            {
                cboTrangThai.SelectedItem = tt;
            }
        }
    }

    /// <summary>
    /// Xóa trắng các control nhập liệu
    /// </summary>
    private void ResetInputs()
    {
        _selectedMaLich = 0;
        txtTenBenhNhan.Clear();
        txtSDT.Clear();
        dtpNgayKham.Value = DateTime.Today;
        dtpGioKham.Value = DateTime.Today.AddHours(8); // 08:00 AM
        if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
        cboTrangThai.SelectedIndex = 0;
        txtTenBenhNhan.Focus();
    }

    private void SelectRowById(int maLich)
    {
        foreach (DataGridViewRow row in dgvLichKham.Rows)
        {
            if (row.Cells["MaLich"].Value is int id && id == maLich)
            {
                row.Selected = true;
                dgvLichKham.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu đầu vào (Validate chi tiết)
    /// </summary>
    private bool ValidateInputs()
    {
        // 1. Không được bỏ trống Tên bệnh nhân
        if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
        {
            MessageBox.Show("Vui lòng nhập Tên bệnh nhân!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenBenhNhan.Focus();
            return false;
        }

        // 2. Chưa chọn Bác sĩ
        if (cboBacSi.SelectedValue == null || Convert.ToInt32(cboBacSi.SelectedValue) <= 0)
        {
            MessageBox.Show("Vui lòng chọn Bác sĩ khám bệnh!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboBacSi.Focus();
            return false;
        }

        // 3. Không cho đặt lịch khám vào ngày trong quá khứ
        if (dtpNgayKham.Value.Date < DateTime.Today)
        {
            MessageBox.Show("Không thể đặt lịch khám vào ngày trong quá khứ! Vui lòng chọn ngày từ hôm nay trở đi.", "Ngày khám không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgayKham.Focus();
            return false;
        }

        return true;
    }

    /// <summary>
    /// Chức năng Thêm mới lịch khám
    /// </summary>
    private async void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        try
        {
            var newLich = new LichKham
            {
                TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                GioKham = TimeOnly.FromDateTime(dtpGioKham.Value),
                MaBs = Convert.ToInt32(cboBacSi.SelectedValue),
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám"
            };

            _context.LichKhams.Add(newLich);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm mới lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(newLich.MaLich);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi thêm lịch khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Cập nhật lịch khám
    /// </summary>
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaLich <= 0)
        {
            MessageBox.Show("Vui lòng chọn một lịch khám từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
        {
            MessageBox.Show("Tên bệnh nhân không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenBenhNhan.Focus();
            return;
        }

        if (cboBacSi.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn Bác sĩ!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var entity = await _context.LichKhams.FindAsync(_selectedMaLich);
            if (entity == null)
            {
                MessageBox.Show("Không tìm thấy lịch khám cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entity.TenBenhNhan = txtTenBenhNhan.Text.Trim();
            entity.Sdt = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();
            entity.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);
            entity.GioKham = TimeOnly.FromDateTime(dtpGioKham.Value);
            entity.MaBs = Convert.ToInt32(cboBacSi.SelectedValue);
            entity.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Chờ khám";

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(_selectedMaLich);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi cập nhật lịch khám: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Xóa lịch khám có hộp thoại xác nhận YesNo
    /// </summary>
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaLich <= 0)
        {
            MessageBox.Show("Vui lòng chọn lịch khám cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa lịch khám của bệnh nhân '{txtTenBenhNhan.Text}' (Mã: {_selectedMaLich}) không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm != DialogResult.Yes) return;

        try
        {
            var entity = await _context.LichKhams.FindAsync(_selectedMaLich);
            if (entity != null)
            {
                _context.LichKhams.Remove(entity);
                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Không thể xóa lịch khám do có dữ liệu liên quan!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Tìm kiếm kết hợp: Theo khoảng Ngày khám (>=, <=) VÀ theo Bác sĩ (==) dùng LINQ Where + Include
    /// </summary>
    private async void btnTimKiem_Click(object sender, EventArgs e)
    {
        await PerformSearchAsync();
    }

    private async Task PerformSearchAsync()
    {
        var tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
        var denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

        if (tuNgay > denNgay)
        {
            MessageBox.Show("'Từ ngày' không thể lớn hơn 'Đến ngày'!", "Lỗi khoảng ngày", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int maBsLoc = 0;
        if (cboLocBacSi.SelectedValue != null)
        {
            int.TryParse(cboLocBacSi.SelectedValue.ToString(), out maBsLoc);
        }

        try
        {
            var query = _context.LichKhams
                .Include(l => l.MaBsNavigation)
                .AsNoTracking()
                .AsQueryable();

            // Minh họa LINQ Where với nhiều điều kiện so sánh ngày tháng (>=, <=) kết hợp điều kiện bằng (==)
            if (maBsLoc > 0)
            {
                query = query.Where(l => l.NgayKham >= tuNgay && l.NgayKham <= denNgay && l.MaBs == maBsLoc);
            }
            else
            {
                query = query.Where(l => l.NgayKham >= tuNgay && l.NgayKham <= denNgay);
            }

            var result = await query
                .OrderBy(l => l.NgayKham)
                .ThenBy(l => l.GioKham)
                .Select(l => new LichKhamViewModel
                {
                    MaLich = l.MaLich,
                    TenBenhNhan = l.TenBenhNhan,
                    Sdt = l.Sdt,
                    NgayKham = l.NgayKham,
                    GioKham = l.GioKham,
                    TenBacSi = l.MaBsNavigation.HoTen,
                    ChuyenKhoa = l.MaBsNavigation.ChuyenKhoa ?? "",
                    TrangThai = l.TrangThai,
                    MaBs = l.MaBs
                })
                .ToListAsync();

            dgvLichKham.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch khám nào trong khoảng thời gian đã chọn!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Làm mới toàn bộ Form
    /// </summary>
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();
        cboLocBacSi.SelectedIndex = 0;
        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today.AddDays(60);
        await LoadDataAsync();
    }

    /// <summary>
    /// Mở Form phụ Quản lý Bác sĩ
    /// </summary>
    private async void btnQuanLyBacSi_Click(object sender, EventArgs e)
    {
        using var f = new FormBacSi();
        f.ShowDialog(this);

        // Nạp lại danh sách bác sĩ sau khi Form phụ đóng
        await LoadBacSiComboBoxesAsync();
        await LoadDataAsync();
    }

    /// <summary>
    /// Nạp dữ liệu mẫu ban đầu nếu CSDL đang rỗng
    /// </summary>
    private async Task SeedSampleDataIfEmptyAsync()
    {
        try
        {
            if (!await _context.BacSis.AnyAsync())
            {
                var bsA = new BacSi { HoTen = "BS. Nguyễn Văn A", ChuyenKhoa = "Nội tổng quát", Sdt = "0901234567" };
                var bsB = new BacSi { HoTen = "BS. Nguyễn Văn B", ChuyenKhoa = "Nội tổng quát", Sdt = "0901234568" };
                var bsC = new BacSi { HoTen = "BS. Nguyễn Văn C", ChuyenKhoa = "Nội tổng quát", Sdt = "0901234569" };
                var bsD = new BacSi { HoTen = "BS. Nguyễn Văn D", ChuyenKhoa = "Nội tổng quát", Sdt = "0901234570" };

                _context.BacSis.AddRange(bsA, bsB, bsC, bsD);
                await _context.SaveChangesAsync();

                var l1 = new LichKham { TenBenhNhan = "Tên bệnh nhân", Sdt = "09725667894", NgayKham = new DateOnly(2022, 7, 13), GioKham = new TimeOnly(9, 0), MaBs = bsA.MaBs, TrangThai = "Chờ khám" };
                var l2 = new LichKham { TenBenhNhan = "Nguyễn Xinh", Sdt = "09725667897", NgayKham = new DateOnly(2022, 12, 29), GioKham = new TimeOnly(13, 0), MaBs = bsA.MaBs, TrangThai = "Đã khám" };
                var l3 = new LichKham { TenBenhNhan = "Nguyễn Hạm", Sdt = "09725667899", NgayKham = new DateOnly(2022, 12, 23), GioKham = new TimeOnly(16, 0), MaBs = bsA.MaBs, TrangThai = "Đã hủy" };
                var l4 = new LichKham { TenBenhNhan = "Nguyễn Tinh", Sdt = "09725667830", NgayKham = new DateOnly(2022, 12, 23), GioKham = new TimeOnly(16, 0), MaBs = bsA.MaBs, TrangThai = "Đã hủy" };
                var l5 = new LichKham { TenBenhNhan = "Nguyễn Hoan anh", Sdt = "09725667899", NgayKham = new DateOnly(2022, 12, 29), GioKham = new TimeOnly(18, 0), MaBs = bsA.MaBs, TrangThai = "Đã hủy" };

                _context.LichKhams.AddRange(l1, l2, l3, l4, l5);
                await _context.SaveChangesAsync();
            }
        }
        catch
        {
            // Bỏ qua nếu bảng đã có dữ liệu
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _context?.Dispose();
        base.OnFormClosed(e);
    }
}
