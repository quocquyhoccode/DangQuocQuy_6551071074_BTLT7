CREATE DATABASE LTTQ_QuanLyLichKhamBenh;
GO

USE LTTQ_QuanLyLichKhamBenh;
GO

CREATE TABLE BacSi
(
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NULL,
    SDT VARCHAR(15) NULL
);
GO

CREATE TABLE LichKham
(
    MaLich INT IDENTITY(1,1) PRIMARY KEY,
    TenBenhNhan NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NULL,
    NgayKham DATE NOT NULL,
    GioKham TIME NOT NULL,
    MaBS INT NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Chờ khám',

    CONSTRAINT FK_LichKham_BacSi
        FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),

    CONSTRAINT CK_LichKham_TrangThai
        CHECK (TrangThai IN (N'Chờ khám', N'Đã khám', N'Đã hủy'))
);
GO