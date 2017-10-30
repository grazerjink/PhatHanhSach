/****** Object:  Database [PhatHanhSachV2]    Script Date: 10/30/2017 10:30:00 PM ******/
CREATE DATABASE [PhatHanhSachV2]
GO
USE [PhatHanhSachV2]
GO
/****** Object:  Table [dbo].[BaoCaoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoDL](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[IdDaiLy] [int] NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[TongTienSachBan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[IdTinhTrang] [int] NULL,
	[NgayXacNhan] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNoDL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDaiLy] [int] NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[NgayCapNhat] [date] NULL,
 CONSTRAINT [PK_CongNoDL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoNXB]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNoNXB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdNXB] [int] NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[NgayCapNhat] [date] NULL,
 CONSTRAINT [PK_CongNoNXb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtBaoCaoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtBaoCaoDL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBaoCao] [int] NULL,
	[IdSach] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[SoLuongBan] [int] NULL,
	[ThanhTien] [float] NULL,
	[SoLuongCon] [int] NULL,
	[TienNo] [float] NULL,
 CONSTRAINT [PK_CtBaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtDoanhThu]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtDoanhThu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDoanhThu] [int] NULL,
	[IdSach] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[LoiNhuan] [float] NULL,
 CONSTRAINT [PK_CtDoanhThu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtPhieuNhap]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtPhieuNhap](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPhieuNhap] [int] NULL,
	[IdSach] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtPhieuXuat]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtPhieuXuat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPhieuXuat] [int] NULL,
	[IdSach] [int] NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtThanhToan]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtThanhToan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdThanhToan] [int] NULL,
	[IdSach] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[SoLuongXuat] [int] NULL,
	[ThanhTien] [float] NULL,
	[SoLuongCon] [int] NULL,
	[TienNo] [float] NULL,
 CONSTRAINT [PK_CtThanhToan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaiLy]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaiLy](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[TenDaiLy] [nvarchar](250) NULL,
	[SoDienThoai] [varchar](11) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DaiLy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[TongThu] [float] NULL,
	[TongChi] [float] NULL,
	[TongLoiNhuan] [float] NULL,
 CONSTRAINT [PK_DoanhThu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[Id] [int] IDENTITY(1001,1) NOT NULL,
	[TenNXB] [nvarchar](250) NULL,
	[SoDienThoai] [varchar](11) NULL,
	[SoTaiKhoan] [varchar](13) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[IdNXB] [int] NULL,
	[NguoiGiao] [nvarchar](250) NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[ThoiGianNhap] [datetime] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[IdDaiLy] [int] NULL,
	[NguoiNhan] [nvarchar](250) NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[ThoiGianXuat] [datetime] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_PhieuXuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[IdNXB] [int] NULL,
	[TenSach] [nvarchar](250) NULL,
	[TacGia] [nvarchar](250) NULL,
	[LinhVuc] [nvarchar](250) NULL,
	[GiaBan] [float] NULL,
	[GiaNhap] [float] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
	[IdNXB] [int] NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[TongTienSachBan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[TongTienThanhToan] [float] NULL,
	[IdTinhTrang] [int] NULL,
	[NgayXacNhan] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MoTa] [nvarchar](250) NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TonKho]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSach] [int] NULL,
	[SoLuong] [int] NULL,
	[ThoiGian] [date] NULL,
	[TangGiam] [int] NULL,
 CONSTRAINT [PK_TonKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaoCaoDL] ON 

INSERT [dbo].[BaoCaoDL] ([Id], [IdDaiLy], [NgayBatDau], [NgayKetThuc], [ThoiGianLapPhieu], [TongTienSachBan], [TongTienConNo], [TongTienThanhToan], [IdTinhTrang], [NgayXacNhan], [TrangThai]) VALUES (100014, 1000, CAST(N'2017-10-02' AS Date), CAST(N'2017-10-30' AS Date), CAST(N'2017-10-30T00:00:00.000' AS DateTime), 2225000, 1525000, 2225000, 2, CAST(N'2017-10-31' AS Date), 1)
INSERT [dbo].[BaoCaoDL] ([Id], [IdDaiLy], [NgayBatDau], [NgayKetThuc], [ThoiGianLapPhieu], [TongTienSachBan], [TongTienConNo], [TongTienThanhToan], [IdTinhTrang], [NgayXacNhan], [TrangThai]) VALUES (100015, 1001, CAST(N'2017-10-02' AS Date), CAST(N'2017-10-30' AS Date), CAST(N'2017-10-30T00:00:00.000' AS DateTime), 1470000, 780000, 1470000, 2, CAST(N'2017-10-30' AS Date), 1)
INSERT [dbo].[BaoCaoDL] ([Id], [IdDaiLy], [NgayBatDau], [NgayKetThuc], [ThoiGianLapPhieu], [TongTienSachBan], [TongTienConNo], [TongTienThanhToan], [IdTinhTrang], [NgayXacNhan], [TrangThai]) VALUES (100016, 1002, CAST(N'2017-10-02' AS Date), CAST(N'2017-10-30' AS Date), CAST(N'2017-10-30T00:00:00.000' AS DateTime), 1625000, 1125000, 0, 1, CAST(N'2017-10-30' AS Date), 1)
SET IDENTITY_INSERT [dbo].[BaoCaoDL] OFF
SET IDENTITY_INSERT [dbo].[CongNoDL] ON 

INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (1, 1000, 0, 1000000, CAST(N'2017-10-03' AS Date))
INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (2, 1000, 0, 3750000, CAST(N'2017-10-04' AS Date))
INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (3, 1001, 0, 2250000, CAST(N'2017-10-04' AS Date))
INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (4, 1002, 0, 2750000, CAST(N'2017-10-05' AS Date))
INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (5, 1000, 2225000, 55000, CAST(N'2017-10-31' AS Date))
INSERT [dbo].[CongNoDL] ([Id], [IdDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (6, 1001, 1470000, 780000, CAST(N'2017-10-30' AS Date))
SET IDENTITY_INSERT [dbo].[CongNoDL] OFF
SET IDENTITY_INSERT [dbo].[CongNoNXB] ON 

INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (1, 1000, 0, 3500000, CAST(N'2017-10-01' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (2, 1001, 0, 3500000, CAST(N'2017-10-01' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (3, 1002, 0, 2000000, CAST(N'2017-10-02' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (4, 1003, 0, 2200000, CAST(N'2017-10-02' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (5, 1004, 0, 2500000, CAST(N'2017-10-03' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (6, 1006, 0, 3000000, CAST(N'2017-10-03' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (7, 1000, 0, 5500000, CAST(N'2017-10-04' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (8, 1005, 0, 4000000, CAST(N'2017-10-10' AS Date))
INSERT [dbo].[CongNoNXB] ([Id], [IdNXB], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (9, 1006, 0, 5000000, CAST(N'2017-11-01' AS Date))
SET IDENTITY_INSERT [dbo].[CongNoNXB] OFF
SET IDENTITY_INSERT [dbo].[CtBaoCaoDL] ON 

INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (1, 100014, 100000, 20000, 35, 700000, 15, 300000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (2, 100014, 100001, 25000, 25, 625000, 25, 625000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (3, 100014, 100003, 30000, 30, 900000, 20, 600000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (4, 100015, 100003, 30000, 35, 1050000, 15, 450000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (5, 100015, 100004, 15000, 28, 420000, 22, 330000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (6, 100016, 100001, 25000, 35, 875000, 15, 375000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [IdBaoCao], [IdSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (7, 100016, 100002, 30000, 25, 750000, 25, 750000)
SET IDENTITY_INSERT [dbo].[CtBaoCaoDL] OFF
SET IDENTITY_INSERT [dbo].[CtPhieuNhap] ON 

INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (1, 100030, 100000, 100, 15000, 1500000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (2, 100030, 100001, 100, 20000, 2000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (3, 100031, 100003, 100, 25000, 2500000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (4, 100031, 100004, 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (5, 100032, 100007, 50, 20000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (6, 100032, 100008, 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (7, 100033, 100009, 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (8, 100033, 100010, 80, 15000, 1200000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (9, 100034, 100011, 50, 10000, 500000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (10, 100034, 100012, 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (11, 100034, 100013, 50, 15000, 750000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (12, 100035, 100017, 100, 20000, 2000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (13, 100035, 100018, 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (14, 100036, 100000, 50, 15000, 750000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (15, 100036, 100002, 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (16, 100037, 100014, 100, 20000, 2000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (17, 100037, 100015, 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (18, 100037, 100016, 50, 15000, 750000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (19, 100038, 100017, 50, 20000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [IdPhieuNhap], [IdSach], [SoLuongNhap], [DonGiaNhap], [ThanhTien]) VALUES (20, 100038, 100018, 100, 10000, 1000000)
SET IDENTITY_INSERT [dbo].[CtPhieuNhap] OFF
SET IDENTITY_INSERT [dbo].[CtPhieuXuat] ON 

INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (1, 100022, 100000, 50, 20000, 1000000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (2, 100023, 100001, 50, 25000, 1250000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (3, 100023, 100003, 50, 30000, 1500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (4, 100024, 100004, 50, 15000, 750000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (5, 100024, 100003, 50, 30000, 1500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (6, 100025, 100002, 50, 30000, 1500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [IdPhieuXuat], [IdSach], [SoLuongXuat], [DonGiaXuat], [ThanhTien]) VALUES (7, 100025, 100001, 50, 25000, 1250000)
SET IDENTITY_INSERT [dbo].[CtPhieuXuat] OFF
SET IDENTITY_INSERT [dbo].[CtThanhToan] ON 

INSERT [dbo].[CtThanhToan] ([Id], [IdThanhToan], [IdSach], [DonGiaNhap], [SoLuongXuat], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (1, 100007, 100000, 15000, 50, 750000, 0, 0)
INSERT [dbo].[CtThanhToan] ([Id], [IdThanhToan], [IdSach], [DonGiaNhap], [SoLuongXuat], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (2, 100007, 100002, 25000, 50, 1250000, 0, 0)
SET IDENTITY_INSERT [dbo].[CtThanhToan] OFF
SET IDENTITY_INSERT [dbo].[DaiLy] ON 

INSERT [dbo].[DaiLy] ([Id], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (1000, N'Đại Lý Sách Diễm Khánh', N'0903922602', N'176 Phan Văn Hùm, 14, Hồ Chí Minh', 1)
INSERT [dbo].[DaiLy] ([Id], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (1001, N'Đại lý Hoàng Oanh', N'0902998695', N'51/4 Đường CMT8 (Cũ), KP. Đông Tư, P. Lái Thiêu, Thuận An, Bình Dương', 1)
INSERT [dbo].[DaiLy] ([Id], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (1002, N'Đại Lý Sách Giáo Khoa Số 8', N'0838351637', N'367, Đường Trần Bình Trọng, Phường 1, Quận 10, TP Hồ Chí Minh', 1)
INSERT [dbo].[DaiLy] ([Id], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (1003, N'Đại lý Liên Nguyễn', N'0986452664', N'57 Ngõ 67, Phố Thái Thịnh, Quận Đống Đa, Tp. Hà Nội', 1)
INSERT [dbo].[DaiLy] ([Id], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (1004, N'Đại lý Tường Linh', N'0968697268', N'Số 11, Đường số 657, ấp Bàu Điều, Xã Phước Thạnh, Huyện Củ Chi, Tp.Hồ Chí Minh', 1)
SET IDENTITY_INSERT [dbo].[DaiLy] OFF
SET IDENTITY_INSERT [dbo].[NhaXuatBan] ON 

INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1000, N'Công Ty TNHH Bình Phúc', N'0262717476', N'0120561862', N'I5 Châu Thới, P. 15, Q. 10, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1001, N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', N'0138225798', N'1234567890', N'60-62 Lê Lợi, P. Bến Nghé, Q. 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1002, N'NXB Kim Đồng', N'0239303832', N'1147531611', N'268 Nguyễn Đình Chiểu, P. 6, Q. 3, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1003, N'Công Ty Cổ Phần Sách-Niên Giám Việt Nam', N'0238420899', N'5418621218', N'304/87-89-91 Đào Duy Anh, P. 9, Q. Phú Nhuận, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1004, N'Công Ty TNHH MTV Nhà Xuất Bản Nông Nghiệp', N'0238297157', N'6548965120', N'58 Nguyễn Bỉnh Khiêm, Quận 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1005, N'Công Ty Cổ Phần Đầu Tư & Phát Triển Giáo Dục Phương Nam', N'0238305002', N'1532121805', N'231 Nguyễn Văn Cừ, P. 4, Q. 5, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1006, N'NXB Chính Trị Quốc Gia', N'0238296476', N'0251836218', N'103 Hàm Nghi, P. Nguyễn Thái Bình, Q. 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1007, N'Công Ty Cổ Phần Sách Báo Quốc Văn', N'0918009103', N'9876543210', N'295/11A Nơ Trang Long, P. 13, Q. Bình Thạnh, Tp. Hồ Chí Minh ', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1008, N'Công Ty CP Truyền Thông Thương Mại Dịch Vụ Bầu Trời Xanh', N'0286256512', N'1234865218', N'73 Đông Hưng Thuận 5, P. Tân Hưng Thuận, Q. 12, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([Id], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (1009, N'Công Ty Cổ Phần Dịch Vụ Vững Tiến', N'0283822965', N'5210534188', N'135A Pasteur, P. 6, Q. 3, Tp. Hồ Chí Minh (TPHCM)', 1)
SET IDENTITY_INSERT [dbo].[NhaXuatBan] OFF
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100030, 1000, N'ABC', 200, 3500000, CAST(N'2017-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100031, 1001, N'ABCDE', 200, 3500000, CAST(N'2017-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100032, 1002, N'ABCDE', 150, 2000000, CAST(N'2017-10-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100033, 1003, N'Từ Huy Phát', 180, 2200000, CAST(N'2017-10-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100034, 1004, N'Nguyễn Đình Khương', 150, 2500000, CAST(N'2017-10-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100035, 1006, N'WXYZ', 200, 3000000, CAST(N'2017-10-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100036, 1000, N'ABC', 100, 2000000, CAST(N'2017-10-04T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100037, 1005, N'XYZHJK', 200, 4000000, CAST(N'2017-10-10T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([Id], [IdNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (100038, 1006, N'BCC', 150, 2000000, CAST(N'2017-11-01T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
SET IDENTITY_INSERT [dbo].[PhieuXuat] ON 

INSERT [dbo].[PhieuXuat] ([Id], [IdDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (100022, 1000, N'XYZ', 50, 1000000, CAST(N'2017-10-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([Id], [IdDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (100023, 1000, N'XYZ', 100, 2750000, CAST(N'2017-10-04T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([Id], [IdDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (100024, 1001, N'Trần Vũ Khanh', 100, 2250000, CAST(N'2017-10-04T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([Id], [IdDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (100025, 1002, N'Vũ Xuân Tiến', 100, 2750000, CAST(N'2017-10-05T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[PhieuXuat] OFF
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100000, 1000, N'The Diary of a Young Girl', N'Anne Frank', N'Ngôn tình, tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100001, 1000, N'The Poisonwood Bible: A Novel', N'Barbara Kingsolver', N'Triết lý, đời sống', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100002, 1000, N'A Heartbreaking Work of Staggering Genius', N'Dave Eggers', N'Đời sống, nhân văn', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100003, 1001, N'The Grand Design', N'Stephen Hawking', N'Thiết kế', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100004, 1001, N'The Very Hungry Caterpillar', N'Eric Carle', N'Triết học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100005, 1001, N'Breath, Eyes, Memory (Oprah''s Book Club)', N'Edwidge Danticat', N'Đời sống, xã hội', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100006, 1001, N'The Sun Also Rises', N'Ernest Hemingway', N'Ngôn tình, tiểu thuyết', 30000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100007, 1002, N'In the Garden of Beasts: Love, Terror, and an American Family in Hitler''s Berlin', N'Erik Larson', N'Ngôn tình', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100008, 1002, N'Dead Wake: The Last Crossing of the Lusitania', N'Erik Larson', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100009, 1003, N'Dr. Potter''s Medicine Show', N'Eric Scott Fischl', N'Khoa học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100010, 1003, N'Angela''s Ashes: A Memoir', N'Frank McCourt', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100011, 1004, N'To Kill a Mockingbird', N'Harper Lee', N'Đời sống, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100012, 1004, N'Harry Potter and the Sorcerer''s Stone', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100013, 1004, N'Harry Potter And The Prisoner Of Azkaban: Illustrated Edition', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100014, 1005, N'Guns, Germs, and Steel: The Fates of Human...', N'Jared Diamond', N'Tiểu thuyết', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100015, 1005, N'The Lord of the Rings', N'J.R.R. Tolkien', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100016, 1005, N'Life After Life: A Novel', N'Kate Atkinson', N'Đời sống, nhân văn', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100017, 1006, N'Alice''s Adventures in Wonderland & Through the Looking', N'Lewis Carroll', N'Cổ tích, truyện tranh', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100018, 1006, N'Little House on the Prairie (Full Color)', N'Laura Ingalls Wilder, Garth Williams', N'Cổ tích', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100019, 1007, N'Lolita', N'Vladimir Nabokov, Friederike Poziemski', N'Khoa học', 15000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100020, 1007, N'1984 (Signet Classics)', N'George Orwell, Erich Fromm', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100021, 1008, N'A Brief History of Time', N'Stephen Hawking', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100022, 1008, N'In Cold Blood', N'Truman Capote', N'Ngôn tình, tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100023, 1009, N'The Things They Carried', N'Tim O''Brien', N'Đời sống, xã hội', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [IdNXB], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100024, 1009, N'The Right Stuff', N'Tom Wolfe', N'Khoa học, công nghệ', 20000, 15000, 1)
SET IDENTITY_INSERT [dbo].[Sach] OFF
SET IDENTITY_INSERT [dbo].[ThanhToan] ON 

INSERT [dbo].[ThanhToan] ([Id], [IdNXB], [NgayBatDau], [NgayKetThuc], [ThoiGianLapPhieu], [TongTienSachBan], [TongTienConNo], [TongTienThanhToan], [IdTinhTrang], [NgayXacNhan], [TrangThai]) VALUES (100007, 1000, CAST(N'2017-10-02' AS Date), CAST(N'2017-10-30' AS Date), CAST(N'2017-10-30T00:00:00.000' AS DateTime), 2000000, 0, 0, 1, CAST(N'2017-10-30' AS Date), 1)
SET IDENTITY_INSERT [dbo].[ThanhToan] OFF
SET IDENTITY_INSERT [dbo].[TinhTrang] ON 

INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (1, N'Đã báo cáo')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (2, N'Đã thanh toán')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (3, N'Đã hủy')
SET IDENTITY_INSERT [dbo].[TinhTrang] OFF
SET IDENTITY_INSERT [dbo].[TonKho] ON 

INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (1, 100000, 100, CAST(N'2017-10-01' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (3, 100001, 100, CAST(N'2017-10-01' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (5, 100003, 100, CAST(N'2017-10-01' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (6, 100004, 100, CAST(N'2017-10-01' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (7, 100007, 50, CAST(N'2017-10-02' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (8, 100008, 100, CAST(N'2017-10-02' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (9, 100009, 100, CAST(N'2017-10-02' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (10, 100010, 80, CAST(N'2017-10-02' AS Date), 80)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (11, 100011, 50, CAST(N'2017-10-03' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (12, 100012, 50, CAST(N'2017-10-03' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (13, 100013, 50, CAST(N'2017-10-03' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (14, 100017, 100, CAST(N'2017-10-03' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (15, 100018, 100, CAST(N'2017-10-03' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (16, 100000, 100, CAST(N'2017-10-04' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (17, 100002, 50, CAST(N'2017-10-04' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (18, 100000, 50, CAST(N'2017-10-03' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (19, 100001, 50, CAST(N'2017-10-04' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (20, 100003, 50, CAST(N'2017-10-04' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (21, 100004, 50, CAST(N'2017-10-04' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (22, 100003, 0, CAST(N'2017-10-04' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (23, 100002, 0, CAST(N'2017-10-05' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (24, 100001, 0, CAST(N'2017-10-05' AS Date), -50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (25, 100014, 100, CAST(N'2017-10-10' AS Date), 100)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (26, 100015, 50, CAST(N'2017-10-10' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (27, 100016, 50, CAST(N'2017-10-10' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (28, 100017, 150, CAST(N'2017-11-01' AS Date), 50)
INSERT [dbo].[TonKho] ([Id], [IdSach], [SoLuong], [ThoiGian], [TangGiam]) VALUES (29, 100018, 200, CAST(N'2017-11-01' AS Date), 100)
SET IDENTITY_INSERT [dbo].[TonKho] OFF
ALTER TABLE [dbo].[BaoCaoDL] ADD  CONSTRAINT [DF_BaoCaoDL_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DaiLy] ADD  CONSTRAINT [DF_DaiLy_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuXuat] ADD  CONSTRAINT [DF_PhieuXuat_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  CONSTRAINT [DF_ThanhToan_IdTinhTrang]  DEFAULT ((1)) FOR [IdTinhTrang]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  CONSTRAINT [DF_ThanhToan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_BaoCaoDL_DaiLy] FOREIGN KEY([IdDaiLy])
REFERENCES [dbo].[DaiLy] ([Id])
GO
ALTER TABLE [dbo].[BaoCaoDL] CHECK CONSTRAINT [FK_BaoCaoDL_DaiLy]
GO
ALTER TABLE [dbo].[BaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_BaoCaoDL_TinhTrang] FOREIGN KEY([IdTinhTrang])
REFERENCES [dbo].[TinhTrang] ([Id])
GO
ALTER TABLE [dbo].[BaoCaoDL] CHECK CONSTRAINT [FK_BaoCaoDL_TinhTrang]
GO
ALTER TABLE [dbo].[CongNoDL]  WITH CHECK ADD  CONSTRAINT [FK_CongNoDL_DaiLy] FOREIGN KEY([IdDaiLy])
REFERENCES [dbo].[DaiLy] ([Id])
GO
ALTER TABLE [dbo].[CongNoDL] CHECK CONSTRAINT [FK_CongNoDL_DaiLy]
GO
ALTER TABLE [dbo].[CongNoNXB]  WITH CHECK ADD  CONSTRAINT [FK_CongNoNXb_NhaXuatBan] FOREIGN KEY([IdNXB])
REFERENCES [dbo].[NhaXuatBan] ([Id])
GO
ALTER TABLE [dbo].[CongNoNXB] CHECK CONSTRAINT [FK_CongNoNXb_NhaXuatBan]
GO
ALTER TABLE [dbo].[CtBaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_CtBaoCaoDL_BaoCaoDL] FOREIGN KEY([IdBaoCao])
REFERENCES [dbo].[BaoCaoDL] ([Id])
GO
ALTER TABLE [dbo].[CtBaoCaoDL] CHECK CONSTRAINT [FK_CtBaoCaoDL_BaoCaoDL]
GO
ALTER TABLE [dbo].[CtBaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_CtBaoCaoDL_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[CtBaoCaoDL] CHECK CONSTRAINT [FK_CtBaoCaoDL_Sach]
GO
ALTER TABLE [dbo].[CtDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_CtDoanhThu_DoanhThu] FOREIGN KEY([IdDoanhThu])
REFERENCES [dbo].[DoanhThu] ([Id])
GO
ALTER TABLE [dbo].[CtDoanhThu] CHECK CONSTRAINT [FK_CtDoanhThu_DoanhThu]
GO
ALTER TABLE [dbo].[CtDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_CtDoanhThu_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[CtDoanhThu] CHECK CONSTRAINT [FK_CtDoanhThu_Sach]
GO
ALTER TABLE [dbo].[CtPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuNhap_PhieuNhap] FOREIGN KEY([IdPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([Id])
GO
ALTER TABLE [dbo].[CtPhieuNhap] CHECK CONSTRAINT [FK_CtPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[CtPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuNhap_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[CtPhieuNhap] CHECK CONSTRAINT [FK_CtPhieuNhap_Sach]
GO
ALTER TABLE [dbo].[CtPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuXuat_PhieuXuat] FOREIGN KEY([IdPhieuXuat])
REFERENCES [dbo].[PhieuXuat] ([Id])
GO
ALTER TABLE [dbo].[CtPhieuXuat] CHECK CONSTRAINT [FK_CtPhieuXuat_PhieuXuat]
GO
ALTER TABLE [dbo].[CtPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuXuat_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[CtPhieuXuat] CHECK CONSTRAINT [FK_CtPhieuXuat_Sach]
GO
ALTER TABLE [dbo].[CtThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CtThanhToan_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[CtThanhToan] CHECK CONSTRAINT [FK_CtThanhToan_Sach]
GO
ALTER TABLE [dbo].[CtThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CtThanhToan_ThanhToan] FOREIGN KEY([IdThanhToan])
REFERENCES [dbo].[ThanhToan] ([Id])
GO
ALTER TABLE [dbo].[CtThanhToan] CHECK CONSTRAINT [FK_CtThanhToan_ThanhToan]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaXuatBan] FOREIGN KEY([IdNXB])
REFERENCES [dbo].[NhaXuatBan] ([Id])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaXuatBan]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_DaiLy] FOREIGN KEY([IdDaiLy])
REFERENCES [dbo].[DaiLy] ([Id])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_DaiLy]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([IdNXB])
REFERENCES [dbo].[NhaXuatBan] ([Id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_NhaXuatBan] FOREIGN KEY([IdNXB])
REFERENCES [dbo].[NhaXuatBan] ([Id])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_NhaXuatBan]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_TinhTrang] FOREIGN KEY([IdTinhTrang])
REFERENCES [dbo].[TinhTrang] ([Id])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_TinhTrang]
GO
ALTER TABLE [dbo].[TonKho]  WITH CHECK ADD  CONSTRAINT [FK_TonKho_Sach] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[TonKho] CHECK CONSTRAINT [FK_TonKho_Sach]
GO
/****** Object:  StoredProcedure [dbo].[procThongKeBaoCaoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[procThongKeBaoCaoDL]
	@maDaiLy int, @batDau date, @ketThuc date
AS
BEGIN
	SELECT 
		s.Id,
		s.TenSach,
		SUM(ct.SoLuongXuat) SoLuongMua,
		SUM(ct.ThanhTien) ThanhTien
	FROM CtPhieuXuat ct
	JOIN PhieuXuat px ON ct.IdPhieuXuat = px.Id
	JOIN Sach s ON s.Id = ct.IdSach
	WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc AND px.IdDaiLy = @maDaiLy
	GROUP BY s.Id, s.TenSach
END
GO
/****** Object:  StoredProcedure [dbo].[proThongKeDoanhThu]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proThongKeDoanhThu] @batDau date, @ketThuc date
AS
BEGIN
	SELECT C.ThoiGian, C.TongChi, T.TongThu
	FROM
	(
		SELECT TC.ThoiGian, SUM(TC.TongChi) TongChi
		FROM 
		(
			SELECT FORMAT(pn.ThoiGianNhap, 'MM/yyyy') ThoiGian, SUM(pn.TongTien) TongChi
			FROM PhieuNhap pn
			JOIN CtPhieuNhap ct ON ct.IdPhieuNhap = pn.Id
			WHERE pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc
			GROUP BY pn.ThoiGianNhap 
		) TC
		GROUP BY TC.ThoiGian
	) C
	FULL OUTER JOIN
	(
		SELECT TT.ThoiGian, SUM(TT.TongThu) TongThu
		FROM 
		(
			SELECT FORMAT(px.ThoiGianXuat, 'MM/yyyy') ThoiGian, SUM(px.TongTien) TongThu
			FROM PhieuXuat px
			JOIN CtPhieuXuat ct ON ct.IdPhieuXuat = px.Id
			WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc
			GROUP BY px.ThoiGianXuat
		) TT
		GROUP BY TT.ThoiGian
	) T
	ON C.ThoiGian = T.ThoiGian
END
GO
/****** Object:  StoredProcedure [dbo].[proThongKeSachNhap]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proThongKeSachNhap] @maNXB int, @batDau date, @ketThuc date AS
BEGIN
	SELECT 
		s.Id, 
		s.TenSach, 
		ct.DonGiaNhap, 
		SUM(ct.SoLuongNhap) SoLuongNhap,
		SUM(ct.SoLuongNhap)*ct.DonGiaNhap TongTienNhap
	FROM CtPhieuNhap ct
	JOIN PhieuNhap pn ON ct.IdPhieuNhap = pn.Id
	JOIN Sach s ON ct.IdSach = s.Id
	WHERE 
		pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc AND
		pn.IdNXB = @maNXB
	GROUP BY s.Id, s.TenSach, ct.DonGiaNhap
END
GO
/****** Object:  StoredProcedure [dbo].[proThongKeSachXuat]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proThongKeSachXuat] @maNXB int, @batDau date, @ketThuc date AS
BEGIN
	SELECT 
		DISTINCT s.Id,
		s.TenSach,
		s.GiaNhap DonGiaNhap,
		SUM(ct.SoLuongXuat) SoLuongXuat,
		SUM(ct.SoLuongXuat)*s.GiaNhap TongTienXuat
	FROM CtPhieuXuat ct
	JOIN PhieuXuat px ON px.Id = ct.IdPhieuXuat
	JOIN Sach s ON s.Id = ct.IdSach
	WHERE ct.IdSach IN ( 
			SELECT 
				s.Id
			FROM CtPhieuNhap ct
			JOIN PhieuNhap pn ON ct.IdPhieuNhap = pn.Id
			JOIN Sach s ON ct.IdSach = s.Id
			WHERE 
				pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc AND
				pn.IdNXB = @maNXB
			GROUP BY s.Id
	)
	GROUP BY s.Id, s.TenSach, s.GiaNhap
END
GO
/****** Object:  StoredProcedure [dbo].[proThongKeSLConThangTruoc]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proThongKeSLConThangTruoc] @maDaiLy int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM BaoCaoDL bc
JOIN CtBaoCaoDL ct ON bc.Id = ct.IdBaoCao
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdDaiLy = @maDaiLy AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC
GO
/****** Object:  StoredProcedure [dbo].[proThongKeSLTonThangTruoc]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proThongKeSLTonThangTruoc] @maNXB int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM ThanhToan tt
JOIN CtThanhToan ct ON tt.Id = ct.IdThanhToan
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdThanhToan = @maNXB AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC
GO
/****** Object:  Trigger [dbo].[trgCapNhatTinhTrangBaoCaoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgCapNhatTinhTrangBaoCaoDL] ON [dbo].[BaoCaoDL]
AFTER UPDATE
AS
BEGIN
	DECLARE @idDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayXacNhan datetime = (SELECT NgayXacNhan FROM inserted)
	DECLARE @tongThanhToan float = (SELECT TongTienThanhToan FROM inserted)
	DECLARE @tinhTrang int = (SELECT IdTinhTrang FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoDL WHERE NgayCapNhat <= @ngayXacNhan AND IdDaiLy = @idDaiLy ORDER BY NgayCapNhat DESC, Id DESC)
	IF @tinhTrang = 2
	BEGIN
		UPDATE CongNoDL SET TongTienConNo = TongTienConNo - @tongThanhToan WHERE NgayCapNhat > @ngayXacNhan
		INSERT INTO CongNoDL (IdDaiLy, NgayCapNhat, TongTienConNo, TongTienThanhToan) VALUES (@idDaiLy, @ngayXacNhan, @noCu - @tongThanhToan, @tongThanhToan)
	END
END
GO
ALTER TABLE [dbo].[BaoCaoDL] ENABLE TRIGGER [trgCapNhatTinhTrangBaoCaoDL]
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuNhap]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuNhap]
ON [dbo].[CtPhieuNhap]
AFTER INSERT
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.ID = ct.IdPhieuNhap)
	DECLARE @maSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND IdSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaNhap float = (SELECT DonGiaNhap FROM inserted)

	IF @soLuongTon IS NULL	
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongNhap,@ngayNhap, @soLuongNhap)
	ELSE
	BEGIN		
		UPDATE TonKho SET SoLuong = SoLuong + @soLuongNhap WHERE ThoiGian > @ngayNhap AND IdSach = @maSach
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
END
GO
ALTER TABLE [dbo].[CtPhieuNhap] ENABLE TRIGGER [trgThemCapNhatCtPhieuNhap]
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuXuat]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuXuat]
ON [dbo].[CtPhieuXuat]
AFTER INSERT
AS
BEGIN
	DECLARE @ngayXuat datetime = (SELECT px.ThoiGianXuat FROM inserted ct JOIN PhieuXuat px ON px.Id = ct.IdPhieuXuat)
	DECLARE @IdSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongXuat int = (SELECT SoLuongXuat FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayXuat AND IdSach = @IdSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaXuat float = (SELECT DonGiaXuat FROM inserted)

	IF @soLuongTon IS NULL OR @soLuongTon < @soLuongXuat
		PRINT 'Lỗi do số lượng sách tồn đã hết hoặc không đáp ứng nên không thể lập phiếu được.'
	ELSE
	BEGIN
		UPDATE TonKho SET SoLuong = SoLuong - @soLuongXuat WHERE ThoiGian > @ngayXuat AND IdSach = @IdSach
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian, TangGiam) VALUES (@IdSach,@soLuongTon-@soLuongXuat,@ngayXuat, -@soLuongXuat)
	END
END
GO
ALTER TABLE [dbo].[CtPhieuXuat] ENABLE TRIGGER [trgThemCapNhatCtPhieuXuat]
GO
/****** Object:  Trigger [dbo].[trgTaoPhieuNhapCapNhatCongNoNXB]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgTaoPhieuNhapCapNhatCongNoNXB]
ON [dbo].[PhieuNhap]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maNXB int = (SELECT IdNXB FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianNhap FROM inserted)
	DECLARE @noMoi float = (SELECT TongTien FROM inserted)
	DECLARE @trangThai bit = (SELECT TrangThai FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoNXB WHERE NgayCapNhat <= @ngayCapNhat AND IdNXB = @maNXB ORDER BY NgayCapNhat DESC, Id DESC)
	IF (@trangThai = 0)
		UPDATE CongNoNXB SET TongTienConNo = TongTienConNo - @noMoi WHERE NgayCapNhat >= @ngayCapNhat
	ELSE
	BEGIN
		IF @noCu IS NULL
			INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @noMoi)
		ELSE
		BEGIN
			UPDATE CongNoNXB SET TongTienConNo = TongTienConNo + @noMoi WHERE NgayCapNhat > @ngayCapNhat
			INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @noCu + @noMoi)
		END
	END
END
GO
ALTER TABLE [dbo].[PhieuNhap] ENABLE TRIGGER [trgTaoPhieuNhapCapNhatCongNoNXB]
GO
/****** Object:  Trigger [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]
ON [dbo].[PhieuXuat]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @noMoi float = (SELECT TongTien FROM inserted)
	DECLARE @trangThai float = (SELECT TrangThai FROM inserted)
	DECLARE @noCu float = (SELECT TOP(1) TongTienConNo FROM CongNoDL WHERE NgayCapNhat <= @ngayCapNhat AND IdDaiLy = @maDaiLy ORDER BY NgayCapNhat DESC, Id DESC)
	IF (@trangThai = 0)
		UPDATE CongNoDL SET TongTienConNo = TongTienConNo - @noMoi WHERE NgayCapNhat >= @ngayCapNhat
	ELSE
	BEGIN
		IF @noCu IS NULL
			INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @noMoi)
		ELSE
		BEGIN
			UPDATE CongNoDL SET TongTienConNo = TongTienConNo + @noMoi WHERE NgayCapNhat > @ngayCapNhat
			INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @noMoi + @noCu)
		END
	END
END
GO
ALTER TABLE [dbo].[PhieuXuat] ENABLE TRIGGER [trgTaoPhieuXuatCapNhatCongNoDL]
GO
/****** Object:  Trigger [dbo].[trgCapNhatTinhTrangThanhToan]    Script Date: 10/30/2017 10:30:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgCapNhatTinhTrangThanhToan] ON [dbo].[ThanhToan]
AFTER UPDATE
AS
BEGIN
	DECLARE @idNXB int = (SELECT IdNXB FROM inserted)
	DECLARE @ngayXacNhan datetime = (SELECT NgayXacNhan FROM inserted)
	DECLARE @tongThanhToan float = (SELECT TongTienThanhToan FROM inserted)
	DECLARE @tinhTrang int = (SELECT IdTinhTrang FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoNXB WHERE NgayCapNhat <= @ngayXacNhan AND IdNXB = @idNXB ORDER BY NgayCapNhat DESC, Id DESC)
	IF @tinhTrang = 2
	BEGIN
		UPDATE CongNoNXB SET TongTienConNo = TongTienConNo - @tongThanhToan WHERE NgayCapNhat > @ngayXacNhan
		INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienConNo, TongTienThanhToan) VALUES (@idNXB, @ngayXacNhan, @noCu-@tongThanhToan, @tongThanhToan)
	END
END
GO
ALTER TABLE [dbo].[ThanhToan] ENABLE TRIGGER [trgCapNhatTinhTrangThanhToan]
GO
USE [master]
GO
ALTER DATABASE [PhatHanhSachV2] SET  READ_WRITE 
GO
