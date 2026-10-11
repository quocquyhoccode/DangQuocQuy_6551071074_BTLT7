using System;
using System.Collections.Generic;

namespace SunriseHomestay.Models;

public partial class Phong
{
    public int MaPhong { get; set; }

    public string SoPhong { get; set; } = null!;

    public int TangSo { get; set; }

    public string TinhTrang { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public int MaLoai { get; set; }

    public virtual LoaiPhong MaLoaiNavigation { get; set; } = null!;
}
