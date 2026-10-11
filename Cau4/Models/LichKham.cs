using System;
using System.Collections.Generic;

namespace AnKhangClinic.Models;

public partial class LichKham
{
    public int MaLich { get; set; }

    public string TenBenhNhan { get; set; } = null!;

    public string? Sdt { get; set; }

    public DateOnly NgayKham { get; set; }

    public TimeOnly GioKham { get; set; }

    public int MaBs { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual BacSi MaBsNavigation { get; set; } = null!;
}
