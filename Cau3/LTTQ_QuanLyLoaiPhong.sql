CREATE DATABASE LTTQ_QuanLyLoaiPhong;
GO

USE LTTQ_QuanLyLoaiPhong;
GO

CREATE TABLE LoaiPhong
(
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    GiaMoiDem DECIMAL(18,2) NOT NULL,
    MoTa NVARCHAR(255) NULL
);
GO

CREATE TABLE Phong
(
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong VARCHAR(10) NOT NULL UNIQUE,
    TangSo INT NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống',
    HinhAnh NVARCHAR(255) NULL,
    MaLoai INT NOT NULL,

    CONSTRAINT FK_Phong_LoaiPhong
        FOREIGN KEY (MaLoai) REFERENCES LoaiPhong(MaLoai),

    CONSTRAINT CK_Phong_TinhTrang
        CHECK (TinhTrang IN (N'Trống', N'Đang ở', N'Đang dọn'))
);
GO