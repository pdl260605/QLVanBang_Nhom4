-- ============================================================
-- DATABASE
-- ============================================================
IF DB_ID('QLVANBANG_NHOM4') IS NULL
BEGIN
    CREATE DATABASE QLVANBANG_NHOM4 COLLATE Vietnamese_CI_AS
END
GO

USE QLVANBANG_NHOM4
GO

-- ============================================================
-- TABLES
-- ============================================================

IF OBJECT_ID('NGUOIDUNG','U') IS NULL
CREATE TABLE NGUOIDUNG (
    TenDangNhap NVARCHAR(50) PRIMARY KEY,
    MatKhau NVARCHAR(255) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL DEFAULT N'NhanVien',
    Email NVARCHAR(100),
    NgayTao DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai BIT NOT NULL DEFAULT 1
)
GO

IF OBJECT_ID('SV','U') IS NULL
CREATE TABLE SV (
    MaSV CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(5) CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CCCD VARCHAR(12) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    SDT VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(200)
)
GO

IF OBJECT_ID('DONVICAP','U') IS NULL
CREATE TABLE DONVICAP (
    MaDV CHAR(10) PRIMARY KEY,
    TenDV NVARCHAR(150),
    DiaChi NVARCHAR(200),
    SDT VARCHAR(15),
    Email NVARCHAR(100),
    Website NVARCHAR(200)
)
GO

IF OBJECT_ID('NGANHHOC','U') IS NULL
CREATE TABLE NGANHHOC (
    MaNH CHAR(10) PRIMARY KEY,
    TenNH NVARCHAR(150),
    MaDV CHAR(10) REFERENCES DONVICAP(MaDV),
    TrinhDo NVARCHAR(50),
    HinhThucDaoTao NVARCHAR(100),
    ThoiGianDaoTao NVARCHAR(20)
)
GO

IF OBJECT_ID('VB','U') IS NULL
CREATE TABLE VB (
    SoHieuVB CHAR(15) PRIMARY KEY,
    MaSV CHAR(10) REFERENCES SV(MaSV),
    MaNH CHAR(10) REFERENCES NGANHHOC(MaNH),
    TenVB NVARCHAR(200),
    XepLoaiVB NVARCHAR(20),
    CapDo NVARCHAR(50),
    NgayCap DATE,
    MaDV CHAR(10) REFERENCES DONVICAP(MaDV),
    TrangThai NVARCHAR(50) DEFAULT N'Đang xử lý'
)
GO

IF OBJECT_ID('LICHSUHOCTAP','U') IS NULL
CREATE TABLE LICHSUHOCTAP (
    MaLSHT INT IDENTITY PRIMARY KEY,
    SoHieuVB CHAR(15) REFERENCES VB(SoHieuVB),
    MaNH CHAR(10) REFERENCES NGANHHOC(MaNH),
    NgayNhapHoc DATE,
    NgayKetThuc DATE,
    TrangThai NVARCHAR(50),
    DiemTichLuy DECIMAL(4,2),
    XepLoai NVARCHAR(50),
    GhiChu NVARCHAR(500)
)
GO

IF OBJECT_ID('YEUCAUCAPLAI','U') IS NULL
CREATE TABLE YEUCAUCAPLAI (
    MaYC CHAR(15) PRIMARY KEY,
    SoHieuVB CHAR(15) REFERENCES VB(SoHieuVB),
    LoaiYeuCau NVARCHAR(50),
    LiDo NVARCHAR(500),
    NgayYeuCau DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50),
    GhiChu NVARCHAR(500)
)
GO

IF OBJECT_ID('LICHSUCHINHSUA','U') IS NULL
CREATE TABLE LICHSUCHINHSUA (
    MaLS UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TenDangNhap NVARCHAR(50),
    ThoiGian DATETIME DEFAULT GETDATE(),
    BangBiTacDong NVARCHAR(50),
    ThaoTac NVARCHAR(20),
    ChiTiet NVARCHAR(500)
)
GO

-- ============================================================
-- INSERT DATA (ANTI-DUPLICATE)
-- ============================================================
INSERT INTO NGUOIDUNG (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin',   CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', N'Admin@123'), 2), N'Quản trị viên', 'Admin'),
('nhanvien1', CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', N'123456'), 2), N'Nhân viên 1',   'NhanVien');

INSERT INTO SV VALUES ('SV001', N'Nguyễn Duy Phương', '2000-03-01', N'Nam', '077555698760', N'nguyenduyphuong@gmail.com', '0789777555', N'Tổ 10, Xã Đông Xuân, Huyện Quốc Oai, Hà Nội');
INSERT INTO SV VALUES ('SV002', N'Trần Ngọc Mai',     '2001-04-02', N'Nữ', '077543669222', N'tranngocmai@gmail.com',     '0789777111', N'68 Đường Phạm Hùng, Quận Nam Từ Liêm, Hà Nội');
INSERT INTO SV VALUES ('SV003', N'Trần Ngọc Nhân',    '2001-10-02', N'Nam', '077543656776', N'tranngocnhan@gmail.com',    '0789222555', N'78 Đường Kim Mã, Quận Ba Đình, Hà Nội');
INSERT INTO SV VALUES ('SV004', N'Hoàng Mai Linh',    '2000-10-20', N'Nữ', '077543668886', N'hoangmailinh@gmail.com',    '0789666555', N'Số 22, Đường Lê Lai, Quận Hai Bà Trưng, Hà Nội');
INSERT INTO SV VALUES ('SV005', N'Cao Thành Sơn',     '2001-01-02', N'Nam', '077543667896', N'caothanhson@gmail.com',     '0789777999', N'Số 10, Đường Hoàng Cầu, Quận Đống Đa, Hà Nội');
INSERT INTO SV VALUES ('SV006', N'Nguyễn Minh Đức',   '2000-10-22', N'Nam', '077543334876', N'nguyenminhduc@gmail.com',   '0777777555', N'99 Đường Láng, Quận Đống Đa, Hà Nội');
INSERT INTO SV VALUES ('SV007', N'Đàm Quốc Tuấn',     '2000-10-12', N'Nam', '077543660086', N'damquoctuan@gmail.com',     '0666777555', N'Số 50, Đường Nguyễn Trãi, Quận Thanh Xuân, Hà Nội');
INSERT INTO SV VALUES ('SV008', N'Vũ Thị Thúy',       '2000-10-03', N'Nữ', '077543669888', N'vuthithuy@gmail.com',       '0789777444', N'15 Đường Tôn Thất Tùng, Quận Đống Đa, Hà Nội');
INSERT INTO SV VALUES ('SV009', N'Từ Hồng Sơn',       '2000-01-04', N'Nam', '077545559876', N'tuhongson@gmail.com',       '0789788855', N'Số 5, Đường Nguyễn Thị Minh Khai, Quận Hai Bà Trưng, Hà Nội');
INSERT INTO SV VALUES ('SV010', N'Ngô Thành Long',    '2000-09-02', N'Nam', '076663669876', N'ngothanhlong@gmail.com',    '0789333555', N'Số 123, Phố Mai Dịch, Quận Cầu Giấy, Hà Nội');

INSERT INTO DONVICAP (MaDV, TenDV, DiaChi, SDT) VALUES
    ('DV123', N'Đại học Kinh tế Quốc dân',   N'207 Giải Phóng, Phương Mai, Đống Đa, Hà Nội',               '0243 8696 769'),
    ('DV124', N'Đại học Luật Hà Nội',         N'87 Nguyễn Chí Thanh, Láng Thượng, Đống Đa, Hà Nội',        '0243 7738 311'),
    ('DV125', N'Đại học Bách khoa Hà Nội',    N'1 Đại Cồ Việt, Bách Khoa, Hai Bà Trưng, Hà Nội',           '0243 8692 100'),
    ('DV333', N'VTC Academy',                 N'Tòa nhà VTC Online, 18 Tạm Trinh, Hai Bà Trưng, Hà Nội',   '0243 9741 999'),
    ('DV222', N'Cao đẳng Y Dược Hà Nội',      N'1 Trường Chinh, Phương Mai, Đống Đa, Hà Nội',               '0243 5745 115');

INSERT INTO NGANHHOC VALUES ('A123', N'Quản trị Kinh doanh (MBA)', 'DV123', N'Cao học',  N'Chính quy', N'2 năm');
INSERT INTO NGANHHOC VALUES ('B123', N'Kinh tế học',               'DV123', N'Đại học',  N'Chính quy', N'4 năm');
INSERT INTO NGANHHOC VALUES ('C123', N'Công nghệ thông tin',       'DV123', N'Cao học',  N'Chính quy', N'2 năm');
INSERT INTO NGANHHOC VALUES ('D123', N'Quản lý dự án',             'DV123', N'Chứng chỉ', N'Chính quy', N'1 năm');
INSERT INTO NGANHHOC VALUES ('E123', N'Ngôn ngữ Anh',              'DV123', N'Đại học',  N'Chính quy', N'4 năm');
INSERT INTO NGANHHOC VALUES ('A124', N'Luật Kinh tế',              'DV124', N'Cao học',  N'Chính quy', N'2 năm');
INSERT INTO NGANHHOC VALUES ('V333', N'Khoa học Full-stack',       'DV333', N'Chứng chỉ', N'Chính quy', N'6 tháng');
INSERT INTO NGANHHOC VALUES ('A222', N'Dược',                      'DV222', N'Cao đẳng', N'Chính quy', N'3 năm');
INSERT INTO NGANHHOC VALUES ('A125', N'Kỹ thuật Xây dựng',        'DV125', N'Đại học',  N'Chính quy', N'4 năm');
INSERT INTO NGANHHOC VALUES ('B125', N'Kỹ thuật Môi trường',      'DV125', N'Cao học',  N'Chính quy', N'2 năm');

INSERT INTO VB VALUES ('VB001', 'SV001', 'A123', N'Thạc sĩ Quản trị Kinh doanh (MBA)',        NULL,        N'Cao học',  '2025-06-01', 'DV123', N'Đang xử lý');
INSERT INTO VB VALUES ('VB002', 'SV002', 'B123', N'Cử nhân Kinh tế',                          N'Xuất sắc', N'Đại học',  '2025-06-01', 'DV123', N'Đang xử lý');
INSERT INTO VB VALUES ('VB003', 'SV003', 'C123', N'Tiến sĩ Công nghệ Thông tin',              NULL,        N'Cao học',  '2025-06-01', 'DV123', N'Đang xử lý');
INSERT INTO VB VALUES ('VB004', 'SV004', 'A222', N'Cao đẳng Dược',                            N'Giỏi',     N'Cao đẳng', '2024-02-01', 'DV222', N'Đã cấp');
INSERT INTO VB VALUES ('VB005', 'SV005', 'D123', N'Chứng chỉ Quản lý Dự án',                  N'Xuất sắc', N'Chứng chỉ','2025-02-01', 'DV123', N'Thu hồi');
INSERT INTO VB VALUES ('VB006', 'SV006', 'E123', N'Cử nhân Ngôn ngữ Anh',                     N'Xuất sắc', N'Đại học',  '2020-02-01', 'DV123', N'Đã cấp');
INSERT INTO VB VALUES ('VB007', 'SV007', 'A124', N'Thạc sĩ Luật Kinh tế',                     NULL,        N'Cao học',  '2020-02-01', 'DV124', N'Đã cấp');
INSERT INTO VB VALUES ('VB008', 'SV008', 'V333', N'Chứng chỉ Lập trình viên Full-stack',      N'Xuất sắc', N'Chứng chỉ','2025-02-01', 'DV333', N'Đã cấp');
INSERT INTO VB VALUES ('VB009', 'SV009', 'A125', N'Cử nhân Kỹ thuật Xây dựng',               N'Khá',      N'Đại học',  '2020-02-01', 'DV125', N'Mất');
INSERT INTO VB VALUES ('VB010', 'SV010', 'B125', N'Tiến sĩ Kỹ thuật Môi trường',             NULL,        N'Cao học',  '2025-10-09', 'DV125', N'Đang xử lý');

IF NOT EXISTS (SELECT 1 FROM LICHSUHOCTAP)
BEGIN
    INSERT INTO LICHSUHOCTAP 
    (SoHieuVB, MaNH, NgayNhapHoc, NgayKetThuc, TrangThai, DiemTichLuy, XepLoai, GhiChu)
    VALUES
    ('VB001','A123','2018-09-01','2020-06-01', N'Đã tốt nghiệp', 3.50, N'Giỏi',        NULL),
    ('VB002','B123','2017-09-01','2021-06-01', N'Đã tốt nghiệp', 3.90, N'Xuất sắc',    NULL),
    ('VB003','C123','2016-09-01','2020-06-01', N'Đã tốt nghiệp', 3.20, N'Giỏi',        NULL),
    ('VB004','A222','2015-09-01','2019-06-01', N'Đã tốt nghiệp', 2.50, N'Khá',         NULL),
    ('VB005','D123','2018-09-01','2019-06-01', N'Đã hoàn thành', 2.60, N'Khá',         NULL),
    ('VB006','E123','2016-09-01','2020-06-01', N'Đã tốt nghiệp', 3.80, N'Xuất sắc',    NULL),
    ('VB007','A124','2015-09-01','2019-06-01', N'Đã tốt nghiệp', 3.00, N'Giỏi',        NULL),
    ('VB008','V333','2019-09-01','2020-03-01', N'Đã hoàn thành', 3.20, N'Giỏi',        NULL),
    ('VB009','A125','2015-09-01','2019-06-01', N'Đã tốt nghiệp', 2.50, N'Khá',         NULL),
    ('VB010','B125','2016-09-01','2020-06-01', N'Đã tốt nghiệp', 3.40, N'Giỏi',        NULL);
END
GO
-- ============================================================
-- VIEWS
-- ============================================================

IF OBJECT_ID('V_ThongTinVanBang','V') IS NOT NULL DROP VIEW V_ThongTinVanBang
GO
CREATE VIEW V_ThongTinVanBang AS
SELECT VB.SoHieuVB, SV.HoTen, NGANHHOC.TenNH, VB.TenVB, VB.TrangThai
FROM VB
JOIN SV ON VB.MaSV = SV.MaSV
JOIN NGANHHOC ON VB.MaNH = NGANHHOC.MaNH
GO

-- ============================================================
-- STORED PROCEDURES
-- ============================================================

IF OBJECT_ID('sp_DangNhap','P') IS NOT NULL DROP PROCEDURE sp_DangNhap
GO
CREATE PROCEDURE sp_DangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    DECLARE @hash NVARCHAR(255)
    SET @hash = CONVERT(NVARCHAR(255), HASHBYTES('SHA2_256', @MatKhau), 2)

    SELECT * FROM NGUOIDUNG
    WHERE TenDangNhap=@TenDangNhap AND MatKhau=@hash
END
GO

-- ============================================================
-- TRIGGERS
-- ============================================================

IF OBJECT_ID('TR_SV','TR') IS NOT NULL DROP TRIGGER TR_SV
GO
CREATE TRIGGER TR_SV
ON SV AFTER INSERT
AS
BEGIN
    INSERT INTO LICHSUCHINHSUA (TenDangNhap,BangBiTacDong,ThaoTac,ChiTiet)
    SELECT SUSER_SNAME(),'SV',N'Thêm',HoTen FROM inserted
END
GO

-- ============================================================
-- TEST
-- ============================================================

SELECT * FROM NGUOIDUNG
SELECT * FROM SV
SELECT * FROM VB
GO

