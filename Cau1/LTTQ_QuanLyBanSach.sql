CREATE DATABASE LTTQ_QuanLySach;
GO

USE LTTQ_QuanLySach;
GO

CREATE TABLE TheLoaiSach
(
    MaTL INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255) NULL,
    SoLuongSach INT NOT NULL DEFAULT 0,
    CreateAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdateAt DATETIME NULL
);
GO

INSERT INTO TheLoaiSach
    (TenTheLoai, MoTa, SoLuongSach)
VALUES
    (N'Tiểu thuyết', N'Thể loại tiểu thuyết', 1),
    (N'Kỹ năng sống', N'Kỹ năng sống nâng cao', 15),
    (N'Thiếu nhi', N'Thiếu nhi cú cỏ', 2),
    (N'Sách giáo khoa', N'Sách giáo khoa cho học sinh', 2),
    (N'Truyện tranh', N'Truyện tranh', 1);
GO

SELECT *
FROM TheLoaiSach;
GO