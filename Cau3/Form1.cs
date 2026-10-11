using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

namespace SunriseHomestay;

public partial class Form1 : Form
{
    private readonly AppDbContext _context;
    private int _selectedMaPhong = 0;
    private string? _currentImageFileName = null;
    private readonly string _imagesFolder;

    public Form1()
    {
        InitializeComponent();
        _context = new AppDbContext();
        _imagesFolder = Path.Combine(Application.StartupPath, "Images");
        if (!Directory.Exists(_imagesFolder))
        {
            Directory.CreateDirectory(_imagesFolder);
        }
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await SeedSampleDataIfEmptyAsync();
        await LoadLoaiPhongComboBoxesAsync();
        cboTinhTrang.SelectedIndex = 0;
        cboLocTinhTrang.SelectedIndex = 0;

        await LoadDataAsync();
        SetupDataGridView();
        ResetInputs();
    }

    /// <summary>
    /// Nạp danh sách Loại phòng từ CSDL vào ComboBox nhập liệu và ComboBox tìm kiếm
    /// </summary>
    private async Task LoadLoaiPhongComboBoxesAsync()
    {
        try
        {
            var loaiList = await _context.LoaiPhongs
                .AsNoTracking()
                .OrderBy(l => l.MaLoai)
                .ToListAsync();

            // ComboBox nhập liệu
            cboLoaiPhong.DataSource = null;
            cboLoaiPhong.DisplayMember = "TenLoai";
            cboLoaiPhong.ValueMember = "MaLoai";
            cboLoaiPhong.DataSource = loaiList.ToList();

            // ComboBox tìm kiếm lọc
            var filterList = new List<LoaiPhongFilterItem>
            {
                new LoaiPhongFilterItem { MaLoai = 0, TenLoai = "lọc theo loại phòng" }
            };
            filterList.AddRange(loaiList.Select(l => new LoaiPhongFilterItem { MaLoai = l.MaLoai, TenLoai = l.TenLoai }));

            cboLocLoaiPhong.DataSource = null;
            cboLocLoaiPhong.DisplayMember = "TenLoai";
            cboLocLoaiPhong.ValueMember = "MaLoai";
            cboLocLoaiPhong.DataSource = filterList;
            cboLocLoaiPhong.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi nạp danh sách loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private class LoaiPhongFilterItem
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; } = null!;
    }

    /// <summary>
    /// ViewModel dùng để hiển thị danh sách phòng kèm ảnh thumbnail trên DataGridView
    /// </summary>
    public class PhongViewModel
    {
        public int MaPhong { get; set; }
        public Image? Anh { get; set; } // Hiển thị trên DataGridViewImageColumn
        public string SoPhong { get; set; } = null!;
        public int TangSo { get; set; }
        public string TenLoaiPhong { get; set; } = null!;
        public decimal GiaMoiDem { get; set; }
        public string GiaMoiDemHienThi => GiaMoiDem.ToString("N0");
        public string TinhTrang { get; set; } = null!;
        public string? HinhAnh { get; set; }
        public int MaLoai { get; set; }
    }

    /// <summary>
    /// Tải danh sách phòng qua Include Eager Loading (LINQ Include)
    /// </summary>
    private async Task LoadDataAsync()
    {
        try
        {
            var phongs = await _context.Phongs
                .Include(p => p.MaLoaiNavigation)
                .AsNoTracking()
                .OrderBy(p => p.MaPhong)
                .ToListAsync();

            var viewModels = phongs.Select(p => new PhongViewModel
            {
                MaPhong = p.MaPhong,
                Anh = LoadThumbnailImage(p.HinhAnh),
                SoPhong = p.SoPhong,
                TangSo = p.TangSo,
                TenLoaiPhong = p.MaLoaiNavigation?.TenLoai ?? "",
                GiaMoiDem = p.MaLoaiNavigation?.GiaMoiDem ?? 0,
                TinhTrang = p.TinhTrang,
                HinhAnh = p.HinhAnh,
                MaLoai = p.MaLoai
            }).ToList();

            dgvPhong.DataSource = viewModels;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi nạp dữ liệu phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Đọc ảnh an toàn không bị khóa (lock) file trong ổ đĩa
    /// </summary>
    private Image? LoadThumbnailImage(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return null;

        string filePath = Path.Combine(_imagesFolder, fileName);
        if (!File.Exists(filePath)) return null;

        try
        {
            using var original = Image.FromFile(filePath);
            return new Bitmap(original);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Cấu hình DataGridView, đặt DataGridViewImageColumn cho cột ảnh
    /// </summary>
    private void SetupDataGridView()
    {
        if (dgvPhong.Columns.Count == 0) return;

        if (dgvPhong.Columns["MaPhong"] is DataGridViewColumn colMa)
        {
            colMa.HeaderText = "Mã phòng";
            colMa.FillWeight = 50;
        }

        if (dgvPhong.Columns["Anh"] is DataGridViewImageColumn colAnh)
        {
            colAnh.HeaderText = "Ảnh";
            colAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colAnh.FillWeight = 60;
        }

        if (dgvPhong.Columns["SoPhong"] is DataGridViewColumn colSo)
        {
            colSo.HeaderText = "Số phòng";
            colSo.FillWeight = 60;
        }

        if (dgvPhong.Columns["TangSo"] is DataGridViewColumn colTang)
        {
            colTang.HeaderText = "Tầng";
            colTang.FillWeight = 45;
        }

        if (dgvPhong.Columns["TenLoaiPhong"] is DataGridViewColumn colLoai)
        {
            colLoai.HeaderText = "Loại phòng";
            colLoai.FillWeight = 85;
        }

        if (dgvPhong.Columns["GiaMoiDemHienThi"] is DataGridViewColumn colGia)
        {
            colGia.HeaderText = "Giá/đêm";
            colGia.FillWeight = 70;
        }

        if (dgvPhong.Columns["TinhTrang"] is DataGridViewColumn colTt)
        {
            colTt.HeaderText = "Tình trạng";
            colTt.FillWeight = 75;
        }

        // Ẩn các cột nội bộ
        if (dgvPhong.Columns["GiaMoiDem"] is DataGridViewColumn colGiaDemRaw) colGiaDemRaw.Visible = false;
        if (dgvPhong.Columns["HinhAnh"] is DataGridViewColumn colHinhAnhRaw) colHinhAnhRaw.Visible = false;
        if (dgvPhong.Columns["MaLoai"] is DataGridViewColumn colMaLoaiRaw) colMaLoaiRaw.Visible = false;
    }

    /// <summary>
    /// Sự kiện tích chọn dòng: Đổ dữ liệu + hiển thị đúng ảnh lên PictureBox
    /// </summary>
    private void dgvPhong_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvPhong.CurrentRow != null && dgvPhong.CurrentRow.Index >= 0)
        {
            var row = dgvPhong.CurrentRow;

            if (row.Cells["MaPhong"].Value is int maPhong)
            {
                _selectedMaPhong = maPhong;
            }

            txtSoPhong.Text = row.Cells["SoPhong"].Value?.ToString() ?? "";

            if (row.Cells["TangSo"].Value is int tang)
            {
                nudTangSo.Value = Math.Max(nudTangSo.Minimum, Math.Min(nudTangSo.Maximum, tang));
            }

            if (row.Cells["MaLoai"].Value is int maLoai)
            {
                cboLoaiPhong.SelectedValue = maLoai;
            }

            string? tinhTrang = row.Cells["TinhTrang"].Value?.ToString();
            if (!string.IsNullOrEmpty(tinhTrang))
            {
                cboTinhTrang.SelectedItem = tinhTrang;
            }

            string? fileName = row.Cells["HinhAnh"].Value?.ToString();
            _currentImageFileName = fileName;
            DisplayImageInPictureBox(fileName);
        }
    }

    /// <summary>
    /// Hiển thị ảnh phòng lên PictureBox
    /// </summary>
    private void DisplayImageInPictureBox(string? fileName)
    {
        picHinhAnh.Image?.Dispose();
        picHinhAnh.Image = null;

        if (string.IsNullOrEmpty(fileName)) return;

        string filePath = Path.Combine(_imagesFolder, fileName);
        if (File.Exists(filePath))
        {
            try
            {
                using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                picHinhAnh.Image = Image.FromStream(fs);
            }
            catch
            {
                picHinhAnh.Image = null;
            }
        }
    }

    /// <summary>
    /// Chọn ảnh từ máy tính, sao chép vào thư mục Images của ứng dụng và chỉ lưu tên file
    /// </summary>
    private void btnChonAnh_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog
        {
            Title = "Chọn hình ảnh phòng",
            Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp;*.webp)|*.jpg;*.jpeg;*.png;*.bmp;*.webp|All files (*.*)|*.*"
        };

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                string ext = Path.GetExtension(ofd.FileName);
                string newFileName = $"phong_{DateTime.Now:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("N")[..4]}{ext}";
                string destPath = Path.Combine(_imagesFolder, newFileName);

                File.Copy(ofd.FileName, destPath, true);

                _currentImageFileName = newFileName;
                DisplayImageInPictureBox(newFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sao chép ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Làm mới các ô nhập
    /// </summary>
    private void ResetInputs()
    {
        _selectedMaPhong = 0;
        _currentImageFileName = null;
        txtSoPhong.Clear();
        nudTangSo.Value = 1;
        if (cboLoaiPhong.Items.Count > 0) cboLoaiPhong.SelectedIndex = 0;
        cboTinhTrang.SelectedIndex = 0;

        picHinhAnh.Image?.Dispose();
        picHinhAnh.Image = null;
        txtSoPhong.Focus();
    }

    private void SelectRowById(int maPhong)
    {
        foreach (DataGridViewRow row in dgvPhong.Rows)
        {
            if (row.Cells["MaPhong"].Value is int id && id == maPhong)
            {
                row.Selected = true;
                dgvPhong.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    /// <summary>
    /// Chức năng Thêm mới phòng
    /// </summary>
    private async void btnThem_Click(object sender, EventArgs e)
    {
        string soPhong = txtSoPhong.Text.Trim();
        if (string.IsNullOrWhiteSpace(soPhong))
        {
            MessageBox.Show("Vui lòng nhập Số phòng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoPhong.Focus();
            return;
        }

        if (cboLoaiPhong.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn Loại phòng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboLoaiPhong.Focus();
            return;
        }

        try
        {
            // Kiểm tra trùng số phòng
            bool isDuplicate = await _context.Phongs.AnyAsync(p => p.SoPhong.ToLower() == soPhong.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show($"Số phòng '{soPhong}' đã tồn tại! Vui lòng chọn số khác.", "Trùng số phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.SelectAll();
                txtSoPhong.Focus();
                return;
            }

            var newPhong = new Phong
            {
                SoPhong = soPhong,
                TangSo = (int)nudTangSo.Value,
                MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue),
                TinhTrang = cboTinhTrang.SelectedItem?.ToString() ?? "Trống",
                HinhAnh = _currentImageFileName
            };

            _context.Phongs.Add(newPhong);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm mới phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(newPhong.MaPhong);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thêm phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Cập nhật thông tin phòng
    /// </summary>
    private async void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaPhong <= 0)
        {
            MessageBox.Show("Vui lòng chọn một phòng từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string soPhong = txtSoPhong.Text.Trim();
        if (string.IsNullOrWhiteSpace(soPhong))
        {
            MessageBox.Show("Số phòng không được để trống!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoPhong.Focus();
            return;
        }

        if (cboLoaiPhong.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn Loại phòng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            bool isDuplicate = await _context.Phongs.AnyAsync(p => p.MaPhong != _selectedMaPhong && p.SoPhong.ToLower() == soPhong.ToLower());
            if (isDuplicate)
            {
                MessageBox.Show($"Số phòng '{soPhong}' đã được sử dụng bởi phòng khác!", "Trùng số phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.SelectAll();
                txtSoPhong.Focus();
                return;
            }

            var entity = await _context.Phongs.FindAsync(_selectedMaPhong);
            if (entity == null)
            {
                MessageBox.Show("Không tìm thấy thông tin phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entity.SoPhong = soPhong;
            entity.TangSo = (int)nudTangSo.Value;
            entity.MaLoai = Convert.ToInt32(cboLoaiPhong.SelectedValue);
            entity.TinhTrang = cboTinhTrang.SelectedItem?.ToString() ?? "Trống";
            entity.HinhAnh = _currentImageFileName;

            await _context.SaveChangesAsync();

            MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadDataAsync();
            SelectRowById(_selectedMaPhong);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Xóa phòng với hộp thoại xác nhận YesNo
    /// </summary>
    private async void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaPhong <= 0)
        {
            MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa phòng '{txtSoPhong.Text}' (Mã: {_selectedMaPhong})?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm != DialogResult.Yes) return;

        try
        {
            var entity = await _context.Phongs.FindAsync(_selectedMaPhong);
            if (entity != null)
            {
                _context.Phongs.Remove(entity);
                await _context.SaveChangesAsync();

                MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
                ResetInputs();
            }
        }
        catch (DbUpdateException)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show("Không thể xóa phòng này do đang có dữ liệu ràng buộc khác!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            _context.ChangeTracker.Clear();
            MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Chức năng Tìm kiếm kết hợp theo Loại phòng VÀ Tình trạng dùng LINQ Where + Include
    /// </summary>
    private async void btnTimKiem_Click(object sender, EventArgs e)
    {
        await PerformSearchAsync();
    }

    private async Task PerformSearchAsync()
    {
        int maLoaiLoc = 0;
        if (cboLocLoaiPhong.SelectedValue != null)
        {
            int.TryParse(cboLocLoaiPhong.SelectedValue.ToString(), out maLoaiLoc);
        }

        string tinhTrangLoc = cboLocTinhTrang.SelectedItem?.ToString() ?? "lọc theo tình trạng";

        try
        {
            var query = _context.Phongs
                .Include(p => p.MaLoaiNavigation)
                .AsNoTracking()
                .AsQueryable();

            // Lọc kết hợp 2 điều kiện bằng LINQ Where + &&
            if (maLoaiLoc > 0 && tinhTrangLoc != "lọc theo tình trạng")
            {
                query = query.Where(p => p.MaLoai == maLoaiLoc && p.TinhTrang == tinhTrangLoc);
            }
            else if (maLoaiLoc > 0)
            {
                query = query.Where(p => p.MaLoai == maLoaiLoc);
            }
            else if (tinhTrangLoc != "lọc theo tình trạng")
            {
                query = query.Where(p => p.TinhTrang == tinhTrangLoc);
            }

            var result = await query
                .OrderBy(p => p.MaPhong)
                .ToListAsync();

            var viewModels = result.Select(p => new PhongViewModel
            {
                MaPhong = p.MaPhong,
                Anh = LoadThumbnailImage(p.HinhAnh),
                SoPhong = p.SoPhong,
                TangSo = p.TangSo,
                TenLoaiPhong = p.MaLoaiNavigation?.TenLoai ?? "",
                GiaMoiDem = p.MaLoaiNavigation?.GiaMoiDem ?? 0,
                TinhTrang = p.TinhTrang,
                HinhAnh = p.HinhAnh,
                MaLoai = p.MaLoai
            }).ToList();

            dgvPhong.DataSource = viewModels;

            if (viewModels.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng nào phù hợp với bộ lọc!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Làm mới toàn bộ Form và DataGridView
    /// </summary>
    private async void btnLamMoi_Click(object sender, EventArgs e)
    {
        ResetInputs();
        cboLocLoaiPhong.SelectedIndex = 0;
        cboLocTinhTrang.SelectedIndex = 0;
        await LoadDataAsync();
    }

    /// <summary>
    /// Mở Form phụ Quản lý Loại phòng
    /// </summary>
    private async void btnQuanLyLoaiPhong_Click(object sender, EventArgs e)
    {
        using var f = new FormLoaiPhong();
        f.ShowDialog(this);

        // Sau khi đóng Form phụ, tự động nạp lại ComboBox Loại phòng
        await LoadLoaiPhongComboBoxesAsync();
        await LoadDataAsync();
    }

    /// <summary>
    /// Nạp dữ liệu mẫu ban đầu gồm các Loại phòng và Phòng kèm ảnh nếu CSDL đang rỗng
    /// </summary>
    private async Task SeedSampleDataIfEmptyAsync()
    {
        try
        {
            if (!await _context.LoaiPhongs.AnyAsync())
            {
                var lpDon = new LoaiPhong { TenLoai = "Phòng Đơn", GiaMoiDem = 25000, MoTa = "Phòng 1 giường đơn tiện nghi" };
                var lpDoi = new LoaiPhong { TenLoai = "Phòng Đôi", GiaMoiDem = 20000, MoTa = "Phòng 2 giường hoặc giường đôi" };
                var lpVip = new LoaiPhong { TenLoai = "Phòng VIP", GiaMoiDem = 30000, MoTa = "Phòng cao cấp view đẹp, ban công" };

                _context.LoaiPhongs.AddRange(lpDon, lpDoi, lpVip);
                await _context.SaveChangesAsync();

                // Tạo 1 file ảnh mẫu phong_sample.jpg trong thư mục Images
                string sampleImgPath = Path.Combine(_imagesFolder, "room_sample.jpg");
                if (!File.Exists(sampleImgPath))
                {
                    using var bmp = new Bitmap(160, 120);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        using var brush = new LinearGradientBrush(new Rectangle(0, 0, 160, 120), Color.DarkGoldenrod, Color.SaddleBrown, 45f);
                        g.FillRectangle(brush, 0, 0, 160, 120);
                        g.DrawString("Sunrise\nHomestay", new Font("Segoe UI", 12, FontStyle.Bold), Brushes.White, new PointF(30, 35));
                    }
                    bmp.Save(sampleImgPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                var p1 = new Phong { SoPhong = "1", TangSo = 1, MaLoai = lpDon.MaLoai, TinhTrang = "Trống", HinhAnh = "room_sample.jpg" };
                var p2 = new Phong { SoPhong = "2", TangSo = 1, MaLoai = lpDoi.MaLoai, TinhTrang = "Đang ở", HinhAnh = "room_sample.jpg" };
                var p3 = new Phong { SoPhong = "3", TangSo = 2, MaLoai = lpDon.MaLoai, TinhTrang = "Đang dọn", HinhAnh = "room_sample.jpg" };
                var p4 = new Phong { SoPhong = "4", TangSo = 4, MaLoai = lpDoi.MaLoai, TinhTrang = "Đang dọn", HinhAnh = "room_sample.jpg" };
                var p5 = new Phong { SoPhong = "5", TangSo = 5, MaLoai = lpVip.MaLoai, TinhTrang = "Đang dọn", HinhAnh = "room_sample.jpg" };

                _context.Phongs.AddRange(p1, p2, p3, p4, p5);
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
