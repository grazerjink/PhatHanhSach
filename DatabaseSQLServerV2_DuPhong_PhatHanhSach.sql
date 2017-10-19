USE [master]
GO
/****** Object:  Database [PhatHanhSach]    Script Date: 10/19/2017 4:54:58 PM ******/
CREATE DATABASE [PhatHanhSach]
GO
USE [PhatHanhSach]
GO
/****** Object:  Table [dbo].[BaoCaoDL]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoDL](
	[MaBaoCao] [nchar](5) NOT NULL,
	[MaDaiLy] [nchar](5) NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[TinhTrang] [int] NULL,
	[NgayXacNhan] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoDL]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNoDL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaDaiLy] [nchar](5) NOT NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[NgayCapNhat] [datetime] NULL,
 CONSTRAINT [PK_CongNoDL_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoNXB]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNoNXB](
	[Id] [nchar](10) NOT NULL,
	[MaNXB] [nchar](5) NULL,
	[MaPhieuThanhToan] [nchar](5) NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
 CONSTRAINT [PK_CongNoNXB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtBaoCaoDL]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtBaoCaoDL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaBaoCao] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
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
/****** Object:  Table [dbo].[CtDoanhThu]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtDoanhThu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuDoanhThu] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[TienLai] [float] NULL,
 CONSTRAINT [PK_CtDoanhThu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtPhieuNhap]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtPhieuNhap](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhap] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuongNhap] [int] NULL,
	[GiaNhap] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtPhieuXuat]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtPhieuXuat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuXuat] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuongXuat] [int] NULL,
	[GiaXuat] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtPhieuXuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtThanhToan]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtThanhToan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThanhToan] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
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
/****** Object:  Table [dbo].[DaiLy]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaiLy](
	[MaDaiLy] [nchar](5) NOT NULL,
	[TenDaiLy] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](11) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DaiLy] PRIMARY KEY CLUSTERED 
(
	[MaDaiLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaPhieuDoanhThu] [nchar](5) NOT NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[TongLai] [float] NULL,
 CONSTRAINT [PK_DoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaPhieuDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[MaNXB] [nchar](5) NOT NULL,
	[TenNXB] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](10) NULL,
	[SoTaiKhoan] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [nchar](5) NOT NULL,
	[MaNXB] [nchar](5) NULL,
	[NguoiGiao] [nvarchar](250) NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[ThoiGianNhap] [datetime] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[MaPhieuXuat] [nchar](5) NOT NULL,
	[MaDaiLy] [nchar](5) NULL,
	[NguoiNhan] [nvarchar](250) NULL,
	[TongSoLuong] [int] NULL,
	[TongTien] [float] NULL,
	[ThoiGianXuat] [datetime] NOT NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_PhieuXuat_1] PRIMARY KEY CLUSTERED 
(
	[MaPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](5) NOT NULL,
	[TenSach] [nvarchar](250) NULL,
	[TacGia] [nvarchar](250) NULL,
	[LinhVuc] [nvarchar](250) NULL,
	[GiaBan] [float] NULL,
	[GiaNhap] [float] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[MaPhieuThanhToan] [nchar](5) NOT NULL,
	[MaNXB] [nchar](5) NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[ThoiGianLapPhieu] [datetime] NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[TinhTrang] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[Id] [int] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TonKho]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonKho](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuong] [int] NULL,
	[ThoiGian] [datetime] NULL,
 CONSTRAINT [PK_TonKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BaoCaoDL] ([MaBaoCao], [MaDaiLy], [ThoiGianBatDau], [ThoiGianKetThuc], [ThoiGianLapPhieu], [TongTienThanhToan], [TongTienConNo], [TinhTrang], [NgayXacNhan], [TrangThai]) VALUES (N'BC100', N'DK100', CAST(N'2017-10-01' AS Date), CAST(N'2017-10-31' AS Date), CAST(N'2017-10-16T00:00:00.000' AS DateTime), 400000, 0, NULL, NULL, 1)
INSERT [dbo].[BaoCaoDL] ([MaBaoCao], [MaDaiLy], [ThoiGianBatDau], [ThoiGianKetThuc], [ThoiGianLapPhieu], [TongTienThanhToan], [TongTienConNo], [TinhTrang], [NgayXacNhan], [TrangThai]) VALUES (N'BC101', N'HQ100', CAST(N'2017-10-01' AS Date), CAST(N'2017-10-31' AS Date), CAST(N'2017-10-19T00:00:00.000' AS DateTime), 0, 0, NULL, NULL, 1)
INSERT [dbo].[BaoCaoDL] ([MaBaoCao], [MaDaiLy], [ThoiGianBatDau], [ThoiGianKetThuc], [ThoiGianLapPhieu], [TongTienThanhToan], [TongTienConNo], [TinhTrang], [NgayXacNhan], [TrangThai]) VALUES (N'BC102', N'HQ100', CAST(N'2017-10-01' AS Date), CAST(N'2017-10-31' AS Date), CAST(N'2017-10-19T00:00:00.000' AS DateTime), 0, 0, NULL, NULL, 1)
INSERT [dbo].[BaoCaoDL] ([MaBaoCao], [MaDaiLy], [ThoiGianBatDau], [ThoiGianKetThuc], [ThoiGianLapPhieu], [TongTienThanhToan], [TongTienConNo], [TinhTrang], [NgayXacNhan], [TrangThai]) VALUES (N'BC103', N'HQ100', CAST(N'2017-10-01' AS Date), CAST(N'2017-10-31' AS Date), CAST(N'2017-10-19T00:00:00.000' AS DateTime), 0, 0, NULL, NULL, 1)
INSERT [dbo].[BaoCaoDL] ([MaBaoCao], [MaDaiLy], [ThoiGianBatDau], [ThoiGianKetThuc], [ThoiGianLapPhieu], [TongTienThanhToan], [TongTienConNo], [TinhTrang], [NgayXacNhan], [TrangThai]) VALUES (N'BC104', N'HQ100', CAST(N'2017-10-01' AS Date), CAST(N'2017-10-31' AS Date), CAST(N'2017-10-19T00:00:00.000' AS DateTime), 1200000, 1850000, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[CongNoDL] ON 

INSERT [dbo].[CongNoDL] ([Id], [MaDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (1, N'TL100', 0, 550000, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[CongNoDL] ([Id], [MaDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (3, N'LN100', 0, 0, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[CongNoDL] ([Id], [MaDaiLy], [TongTienThanhToan], [TongTienConNo], [NgayCapNhat]) VALUES (4, N'LN100', 0, 900000, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[CongNoDL] OFF
SET IDENTITY_INSERT [dbo].[CtBaoCaoDL] ON 

INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (1, N'BC100', N'AF100', 20000, 20, 400000, 0, 0)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (2, N'BC104', N'EH100', 30000, 20, 600000, 0, 0)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (3, N'BC104', N'HP100', 30000, 20, 600000, 10, 300000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (4, N'BC104', N'EL101', 15000, 0, 0, 20, 300000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (5, N'BC104', N'HP101', 20000, 0, 0, 20, 400000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (6, N'BC104', N'LC100', 25000, 0, 0, 20, 500000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (7, N'BC104', N'SC100', 15000, 0, 0, 10, 150000)
INSERT [dbo].[CtBaoCaoDL] ([Id], [MaBaoCao], [MaSach], [DonGiaXuat], [SoLuongBan], [ThanhTien], [SoLuongCon], [TienNo]) VALUES (8, N'BC104', N'TW100', 20000, 0, 0, 10, 200000)
SET IDENTITY_INSERT [dbo].[CtBaoCaoDL] OFF
SET IDENTITY_INSERT [dbo].[CtPhieuNhap] ON 

INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (1, N'PN101', N'AF100', 100, 15000, 1500000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (2, N'PN101', N'BK100', 100, 22000, 2200000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (3, N'PN101', N'DE100', 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (4, N'PN101', N'DS100', 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (5, N'PN101', N'EC100', 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (6, N'PN102', N'ED100', 100, 15000, 1500000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (7, N'PN102', N'EH100', 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (8, N'PN102', N'EL100', 50, 20000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (9, N'PN102', N'EL101', 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (10, N'PN102', N'ES101', 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (11, N'PN103', N'FM100', 60, 15000, 900000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (12, N'PN103', N'Hl100', 80, 10000, 800000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (13, N'PN103', N'HP100', 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (14, N'PN103', N'HP101', 60, 15000, 900000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (15, N'PN103', N'JD100', 30, 20000, 600000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (16, N'PN103', N'JR100', 50, 25000, 1250000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (17, N'PN104', N'KA100', 80, 15000, 1200000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (18, N'PN104', N'LC100', 50, 20000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (19, N'PN104', N'LH100', 100, 10000, 1000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (20, N'PN104', N'LO100', 80, 10000, 800000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (21, N'PN104', N'SC100', 80, 10000, 800000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (22, N'PN105', N'SK100', 60, 15000, 900000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (23, N'PN105', N'TC100', 80, 25000, 2000000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (24, N'PN105', N'TO100', 80, 20000, 1600000)
INSERT [dbo].[CtPhieuNhap] ([Id], [MaPhieuNhap], [MaSach], [SoLuongNhap], [GiaNhap], [ThanhTien]) VALUES (25, N'PN105', N'TW100', 100, 15000, 1500000)
SET IDENTITY_INSERT [dbo].[CtPhieuNhap] OFF
SET IDENTITY_INSERT [dbo].[CtPhieuXuat] ON 

INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (1, N'PX101', N'BK100', 20, 25000, 500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (2, N'PX101', N'DE100', 10, 30000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (3, N'PX101', N'EC100', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (4, N'PX102', N'EH100', 20, 30000, 600000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (5, N'PX102', N'EL101', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (6, N'PX102', N'HP100', 20, 30000, 600000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (7, N'PX103', N'HL100', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (8, N'PX103', N'ED100', 10, 20000, 200000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (9, N'PX103', N'DS100', 10, 30000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (10, N'PX104', N'SC100', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (11, N'PX104', N'KA100', 20, 20000, 400000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (12, N'PX104', N'HL100', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (13, N'PX104', N'EC100', 10, 15000, 150000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (14, N'PX105', N'LH100', 25, 15000, 375000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (15, N'PX105', N'BK100', 20, 25000, 500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (16, N'PX105', N'AF100', 20, 20000, 400000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (17, N'PX105', N'HP100', 20, 30000, 600000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (18, N'PX106', N'SC100', 10, 15000, 150000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (19, N'PX106', N'TW100', 10, 20000, 200000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (20, N'PX106', N'HP101', 20, 20000, 400000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (21, N'PX106', N'HP100', 10, 30000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (22, N'PX106', N'LC100', 20, 25000, 500000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (23, N'PX107', N'EH100', 30, 30000, 900000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (24, N'PX107', N'JD100', 25, 25000, 625000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (25, N'PX107', N'ES101', 20, 15000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (26, N'PX108', N'AF100', 20, 20000, 400000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (27, N'PX108', N'JR100', 10, 30000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (28, N'PX108', N'TW100', 10, 20000, 200000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (29, N'PX109', N'KA100', 20, 20000, 400000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (30, N'PX109', N'ES101', 10, 15000, 150000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (31, N'PX110', N'TW100', 10, 20000, 200000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (32, N'PX110', N'AF100', 10, 20000, 200000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (33, N'PX110', N'DE100', 10, 30000, 300000)
INSERT [dbo].[CtPhieuXuat] ([Id], [MaPhieuXuat], [MaSach], [SoLuongXuat], [GiaXuat], [ThanhTien]) VALUES (34, N'PX110', N'FM100', 10, 20000, 200000)
SET IDENTITY_INSERT [dbo].[CtPhieuXuat] OFF
INSERT [dbo].[DaiLy] ([MaDaiLy], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (N'DK100', N'Đại Lý Sách Diễm Khánh', N'0903922602', N'176 Phan Văn Hùm, 14, Hồ Chí Minh', 1)
INSERT [dbo].[DaiLy] ([MaDaiLy], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (N'HQ100', N'Đại lý Hoàng Oanh', N'0902998695', N'51/4 Đường CMT8 (Cũ), KP. Đông Tư, P. Lái Thiêu, Thuận An, Bình Dương', 1)
INSERT [dbo].[DaiLy] ([MaDaiLy], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (N'KS100', N'Đại Lý Sách Giáo Khoa Số 8', N'0838351637', N'367, Đường Trần Bình Trọng, Phường 1, Quận 10, TP Hồ Chí Minh', 1)
INSERT [dbo].[DaiLy] ([MaDaiLy], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (N'LN100', N'Đại lý Liên Nguyễn', N'0986452664', N'57 Ngõ 67, Phố Thái Thịnh, Quận Đống Đa, Tp. Hà Nội', 1)
INSERT [dbo].[DaiLy] ([MaDaiLy], [TenDaiLy], [SoDienThoai], [DiaChi], [TrangThai]) VALUES (N'TL100', N'Đại lý Tường Linh', N'0968697268', N'Số 11, Đường số 657, ấp Bàu Điều, Xã Phước Thạnh, Huyện Củ Chi, Tp.Hồ Chí Minh', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'BP100', N'Công Ty TNHH Bình Phúc', N'0262717476', N'0120561862', N'I5 Châu Thới, P. 15, Q. 10, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'FA100', N'Công Ty Cổ Phần Phát Hành Sách Tp. HCM', N'0138225798', N'1234567890', N'60-62 Lê Lợi, P. Bến Nghé, Q. 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'KD100', N'NXB Kim Đồng', N'0239303832', N'1147531611', N'268 Nguyễn Đình Chiểu, P. 6, Q. 3, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'NG100', N'Công Ty Cổ Phần Sách-Niên Giám Việt Nam', N'0238420899', N'5418621218', N'304/87-89-91 Đào Duy Anh, P. 9, Q. Phú Nhuận, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'NN100', N'Công Ty TNHH MTV Nhà Xuất Bản Nông Nghiệp', N'0238297157', N'6548965120', N'58 Nguyễn Bỉnh Khiêm, Quận 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'PN100', N'Công Ty Cổ Phần Đầu Tư & Phát Triển Giáo Dục Phương Nam', N'0238305002', N'1532121805', N'231 Nguyễn Văn Cừ, P. 4, Q. 5, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'QG100', N'NXB Chính Trị Quốc Gia', N'0238296476', N'0251836218', N'103 Hàm Nghi, P. Nguyễn Thái Bình, Q. 1, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'QV100', N'Công Ty Cổ Phần Sách Báo Quốc Văn', N'0918009103', N'9876543210', N'295/11A Nơ Trang Long, P. 13, Q. Bình Thạnh, Tp. Hồ Chí Minh ', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'TX100', N'Công Ty CP Truyền Thông Thương Mại Dịch Vụ Bầu Trời Xanh', N'0286256512', N'1234865218', N'73 Đông Hưng Thuận 5, P. Tân Hưng Thuận, Q. 12, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[NhaXuatBan] ([MaNXB], [TenNXB], [SoDienThoai], [SoTaiKhoan], [DiaChi], [TrangThai]) VALUES (N'VT100', N'Công Ty Cổ Phần Dịch Vụ Vững Tiến', N'0283822965', N'5210534188', N'135A Pasteur, P. 6, Q. 3, Tp. Hồ Chí Minh (TPHCM)', 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (N'PN101', N'BP100', N'Lê Thanh Phương', 400, 7200000, CAST(N'2017-10-01T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (N'PN102', N'NG100', N'Trần Tuấn Hùng', 400, 5750000, CAST(N'2017-10-03T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (N'PN103', N'VT100', N'Nguyễn Thành Trung', 330, 5700000, CAST(N'2017-10-05T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (N'PN104', N'TX100', N'Lý Minh Thi', 390, 4800000, CAST(N'2017-10-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [MaNXB], [NguoiGiao], [TongSoLuong], [TongTien], [ThoiGianNhap], [TrangThai]) VALUES (N'PN105', N'PN100', N'Hồ Hùng Mậu', 320, 6000000, CAST(N'2017-10-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX101', N'DK100', N'Trần Khải Toàn', 50, 1100000, CAST(N'2017-10-02T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX102', N'HQ100', N'Lý Xuân Mai', 60, 1500000, CAST(N'2017-10-05T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX103', N'KS100', N'Lý Diệu Uyên', 40, 800000, CAST(N'2017-10-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX104', N'LN100', N'Nguyễn Thanh Thương', 70, 1150000, CAST(N'2017-10-09T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX105', N'TL100', N'Trần Thanh', 85, 1875000, CAST(N'2017-10-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX106', N'HQ100', N'Nguyễn Triều Mai', 70, 1550000, CAST(N'2017-10-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX107', N'DK100', N'Trịnh Tú Thành', 75, 1825000, CAST(N'2017-10-06T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX108', N'DK100', N'Lư Hào Vĩ', 40, 900000, CAST(N'2017-10-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX109', N'TL100', N'Từ Thế Thành', 30, 550000, CAST(N'2017-10-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[PhieuXuat] ([MaPhieuXuat], [MaDaiLy], [NguoiNhan], [TongSoLuong], [TongTien], [ThoiGianXuat], [TrangThai]) VALUES (N'PX110', N'LN100', N'Trần Diệu Linh', 40, 900000, CAST(N'2017-10-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'AF100', N'The Diary of a Young Girl', N'Anne Frank', N'Ngôn tình, tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'BK100', N'The Poisonwood Bible: A Novel', N'Barbara Kingsolver', N'Triết lý, đời sống', 25000, 22000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'DE100', N'A Heartbreaking Work of Staggering Genius', N'Dave Eggers', N'Đời sống, nhân văn', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'DS100', N'The Grand Design', N'Stephen Hawking', N'Thiết kế', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'EC100', N'The Very Hungry Caterpillar', N'Eric Carle', N'Triết học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'ED100', N'Breath, Eyes, Memory (Oprah''s Book Club)', N'Edwidge Danticat', N'Đời sống, xã hội', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'EH100', N'The Sun Also Rises', N'Ernest Hemingway', N'Ngôn tình, tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'EL100', N'In the Garden of Beasts: Love, Terror, and an American Family in Hitler''s Berlin', N'Erik Larson', N'Ngôn tình', 25000, 20000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'EL101', N'Dead Wake: The Last Crossing of the Lusitania', N'Erik Larson', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'ES101', N'Dr. Potter''s Medicine Show', N'Eric Scott Fischl', N'Khoa học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'FM100', N'Angela''s Ashes: A Memoir', N'Frank McCourt', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'HL100', N'To Kill a Mockingbird', N'Harper Lee', N'Đời sống, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'HP100', N'Harry Potter and the Sorcerer''s Stone', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'HP101', N'Harry Potter And The Prisoner Of Azkaban: Illustrated Edition', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'JD100', N'Guns, Germs, and Steel: The Fates of Human...', N'Jared Diamond', N'Tiểu thuyết', 25000, 20000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'JR100', N'The Lord of the Rings', N'J.R.R. Tolkien', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'KA100', N'Life After Life: A Novel', N'Kate Atkinson', N'Đời sống, nhân văn', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'LC100', N'Alice''s Adventures in Wonderland & Through the Looking', N'Lewis Carroll', N'Cổ tích, truyện tranh', 25000, 20000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'LH100', N'Little House on the Prairie (Full Color)', N'Laura Ingalls Wilder, Garth Williams', N'Cổ tích', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'LO100', N'Lolita', N'Vladimir Nabokov, Friederike Poziemski', N'Khoa học', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'SC100', N'1984 (Signet Classics)', N'George Orwell, Erich Fromm', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'SK100', N'A Brief History of Time', N'Stephen Hawking', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'TC100', N'In Cold Blood', N'Truman Capote', N'Ngôn tình, tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'TO100', N'The Things They Carried', N'Tim O''Brien', N'Đời sống, xã hội', 25000, 20000, 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (N'TW100', N'The Right Stuff', N'Tom Wolfe', N'Khoa học, công nghệ', 20000, 15000, 1)
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (1, N'Đã báo cáo')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (2, N'Đã thanh toán')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (3, N'Đã hủy')
SET IDENTITY_INSERT [dbo].[TonKho] ON 

INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (1, N'AF100', 100, CAST(N'2017-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (2, N'BK100', 100, CAST(N'2017-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (3, N'DE100', 50, CAST(N'2017-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (4, N'DS100', 50, CAST(N'2017-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (5, N'EC100', 100, CAST(N'2017-10-01T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (6, N'ED100', 100, CAST(N'2017-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (7, N'EH100', 50, CAST(N'2017-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (8, N'EL100', 50, CAST(N'2017-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (9, N'EL101', 100, CAST(N'2017-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (10, N'ES101', 100, CAST(N'2017-10-03T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (11, N'FM100', 60, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (12, N'Hl100', 80, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (13, N'HP100', 50, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (14, N'HP101', 60, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (15, N'JD100', 30, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (16, N'JR100', 50, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (17, N'KA100', 80, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (18, N'LC100', 50, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (19, N'LH100', 100, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (20, N'LO100', 80, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (21, N'SC100', 80, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (22, N'SK100', 60, CAST(N'2017-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (23, N'TC100', 80, CAST(N'2017-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (24, N'TO100', 80, CAST(N'2017-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (25, N'TW100', 100, CAST(N'2017-10-12T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (26, N'BK100', 80, CAST(N'2017-10-02T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (27, N'DE100', 40, CAST(N'2017-10-02T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (28, N'EC100', 80, CAST(N'2017-10-02T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (29, N'EH100', 30, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (30, N'EL101', 80, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (31, N'HP100', 30, CAST(N'2017-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (32, N'HL100', 60, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (33, N'ED100', 90, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (34, N'DS100', 40, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (35, N'SC100', 60, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (36, N'KA100', 60, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (37, N'HL100', 40, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (38, N'EC100', 70, CAST(N'2017-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (39, N'LH100', 75, CAST(N'2017-10-11T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (40, N'BK100', 60, CAST(N'2017-10-11T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (41, N'AF100', 80, CAST(N'2017-10-11T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (42, N'HP100', 10, CAST(N'2017-10-11T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (43, N'SC100', 50, CAST(N'2017-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (44, N'TW100', 90, CAST(N'2017-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (45, N'HP101', 40, CAST(N'2017-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (46, N'HP100', 0, CAST(N'2017-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (47, N'LC100', 30, CAST(N'2017-10-13T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (48, N'EH100', 0, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (49, N'JD100', 5, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (50, N'ES101', 80, CAST(N'2017-10-06T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (51, N'AF100', 60, CAST(N'2017-10-16T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (52, N'JR100', 40, CAST(N'2017-10-16T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (53, N'TW100', 80, CAST(N'2017-10-16T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (54, N'KA100', 40, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (55, N'ES101', 70, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (56, N'TW100', 70, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (57, N'AF100', 50, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (58, N'DE100', 30, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TonKho] ([Id], [MaSach], [SoLuong], [ThoiGian]) VALUES (59, N'FM100', 50, CAST(N'2017-10-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TonKho] OFF
ALTER TABLE [dbo].[BaoCaoDL] ADD  CONSTRAINT [DF_BaoCaoDL_TinhTrang]  DEFAULT ((1)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[BaoCaoDL] ADD  CONSTRAINT [DF_BaoCaoDL_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[CongNoDL] ADD  CONSTRAINT [DF_CongNoDL_TongTienThanhToan]  DEFAULT ((0)) FOR [TongTienThanhToan]
GO
ALTER TABLE [dbo].[CongNoDL] ADD  CONSTRAINT [DF_CongNoDL_TongTienConNo]  DEFAULT ((0)) FOR [TongTienConNo]
GO
ALTER TABLE [dbo].[CtPhieuNhap] ADD  CONSTRAINT [DF_CtPhieuNhap_SoLuongNhap]  DEFAULT ((0)) FOR [SoLuongNhap]
GO
ALTER TABLE [dbo].[CtPhieuNhap] ADD  CONSTRAINT [DF_CtPhieuNhap_GiaNhap]  DEFAULT ((0)) FOR [GiaNhap]
GO
ALTER TABLE [dbo].[CtPhieuNhap] ADD  CONSTRAINT [DF_CtPhieuNhap_ThanhTien]  DEFAULT ((0)) FOR [ThanhTien]
GO
ALTER TABLE [dbo].[DaiLy] ADD  CONSTRAINT [DF_DaiLy_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhaXuatBan] ADD  CONSTRAINT [DF_NhaXuatBan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  CONSTRAINT [DF_PhieuNhap_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuXuat] ADD  CONSTRAINT [DF_PhieuXuat_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_GiaBan]  DEFAULT ((0)) FOR [GiaBan]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_GiaNhap]  DEFAULT ((0)) FOR [GiaNhap]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  CONSTRAINT [DF_ThanhToan_TinhTrang]  DEFAULT ((1)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  CONSTRAINT [DF_ThanhToan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[TonKho] ADD  CONSTRAINT [DF_TonKho_SoLuong]  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[BaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_BaoCaoDL_DaiLy] FOREIGN KEY([MaDaiLy])
REFERENCES [dbo].[DaiLy] ([MaDaiLy])
GO
ALTER TABLE [dbo].[BaoCaoDL] CHECK CONSTRAINT [FK_BaoCaoDL_DaiLy]
GO
ALTER TABLE [dbo].[BaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_BaoCaoDL_TinhTrang] FOREIGN KEY([TinhTrang])
REFERENCES [dbo].[TinhTrang] ([Id])
GO
ALTER TABLE [dbo].[BaoCaoDL] CHECK CONSTRAINT [FK_BaoCaoDL_TinhTrang]
GO
ALTER TABLE [dbo].[CongNoDL]  WITH CHECK ADD  CONSTRAINT [FK_CongNoDL_DaiLy] FOREIGN KEY([MaDaiLy])
REFERENCES [dbo].[DaiLy] ([MaDaiLy])
GO
ALTER TABLE [dbo].[CongNoDL] CHECK CONSTRAINT [FK_CongNoDL_DaiLy]
GO
ALTER TABLE [dbo].[CongNoNXB]  WITH CHECK ADD  CONSTRAINT [FK_CongNoNXB_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[CongNoNXB] CHECK CONSTRAINT [FK_CongNoNXB_NhaXuatBan]
GO
ALTER TABLE [dbo].[CongNoNXB]  WITH CHECK ADD  CONSTRAINT [FK_CongNoNXB_ThanhToan] FOREIGN KEY([MaPhieuThanhToan])
REFERENCES [dbo].[ThanhToan] ([MaPhieuThanhToan])
GO
ALTER TABLE [dbo].[CongNoNXB] CHECK CONSTRAINT [FK_CongNoNXB_ThanhToan]
GO
ALTER TABLE [dbo].[CtBaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_CtBaoCaoDL_BaoCaoDL] FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BaoCaoDL] ([MaBaoCao])
GO
ALTER TABLE [dbo].[CtBaoCaoDL] CHECK CONSTRAINT [FK_CtBaoCaoDL_BaoCaoDL]
GO
ALTER TABLE [dbo].[CtBaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_CtBaoCaoDL_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtBaoCaoDL] CHECK CONSTRAINT [FK_CtBaoCaoDL_Sach]
GO
ALTER TABLE [dbo].[CtDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_CtDoanhThu_DoanhThu] FOREIGN KEY([MaPhieuDoanhThu])
REFERENCES [dbo].[DoanhThu] ([MaPhieuDoanhThu])
GO
ALTER TABLE [dbo].[CtDoanhThu] CHECK CONSTRAINT [FK_CtDoanhThu_DoanhThu]
GO
ALTER TABLE [dbo].[CtDoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_CtDoanhThu_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtDoanhThu] CHECK CONSTRAINT [FK_CtDoanhThu_Sach]
GO
ALTER TABLE [dbo].[CtPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuNhap_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[CtPhieuNhap] CHECK CONSTRAINT [FK_CtPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[CtPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuNhap_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtPhieuNhap] CHECK CONSTRAINT [FK_CtPhieuNhap_Sach]
GO
ALTER TABLE [dbo].[CtPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuXuat_PhieuXuat] FOREIGN KEY([MaPhieuXuat])
REFERENCES [dbo].[PhieuXuat] ([MaPhieuXuat])
GO
ALTER TABLE [dbo].[CtPhieuXuat] CHECK CONSTRAINT [FK_CtPhieuXuat_PhieuXuat]
GO
ALTER TABLE [dbo].[CtPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_CtPhieuXuat_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtPhieuXuat] CHECK CONSTRAINT [FK_CtPhieuXuat_Sach]
GO
ALTER TABLE [dbo].[CtThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CtThanhToan_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[CtThanhToan] CHECK CONSTRAINT [FK_CtThanhToan_Sach]
GO
ALTER TABLE [dbo].[CtThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_CtThanhToan_ThanhToan] FOREIGN KEY([MaPhieuThanhToan])
REFERENCES [dbo].[ThanhToan] ([MaPhieuThanhToan])
GO
ALTER TABLE [dbo].[CtThanhToan] CHECK CONSTRAINT [FK_CtThanhToan_ThanhToan]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaXuatBan]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuXuat_DaiLy] FOREIGN KEY([MaDaiLy])
REFERENCES [dbo].[DaiLy] ([MaDaiLy])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK_PhieuXuat_DaiLy]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NhaXuatBan] ([MaNXB])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_NhaXuatBan]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_TinhTrang] FOREIGN KEY([TinhTrang])
REFERENCES [dbo].[TinhTrang] ([Id])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_TinhTrang]
GO
ALTER TABLE [dbo].[TonKho]  WITH CHECK ADD  CONSTRAINT [FK_TonKho_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[TonKho] CHECK CONSTRAINT [FK_TonKho_Sach]
GO
/****** Object:  StoredProcedure [dbo].[procThongKeBaoCaoDL]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[procThongKeBaoCaoDL]
	@maDaiLy nchar(5), @batDau date, @ketThuc date
AS
BEGIN
	SELECT 
		s.MaSach,
		SUM(ct.SoLuongXuat) SoLuongMua,
		SUM(ct.ThanhTien) ThanhTien
	FROM CtPhieuXuat ct
	JOIN PhieuXuat px ON ct.MaPhieuXuat = px.MaPhieuXuat
	JOIN Sach s ON s.MaSach = ct.MaSach
	WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc AND px.MaDaiLy = @maDaiLy
	GROUP BY s.MaSach
END
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuNhap]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuNhap]
ON [dbo].[CtPhieuNhap]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.MaPhieuNhap = ct.MaPhieuNhap)
	DECLARE @maSach nchar(5) = (SELECT MaSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND MaSach = @maSach ORDER BY ThoiGian DESC)
	DECLARE @giaNhap float = (SELECT GiaNhap FROM inserted)
	IF @soLuongTon IS NULL
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongNhap,@ngayNhap)
	ELSE
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap)
END
GO
ALTER TABLE [dbo].[CtPhieuNhap] ENABLE TRIGGER [trgThemCapNhatCtPhieuNhap]
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuXuat]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuXuat]
ON [dbo].[CtPhieuXuat]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayXuat datetime = (SELECT px.ThoiGianXuat FROM inserted ct JOIN PhieuXuat px ON px.MaPhieuXuat = ct.MaPhieuXuat)
	DECLARE @maSach nchar(5) = (SELECT MaSach FROM inserted)
	DECLARE @soLuongXuat int = (SELECT SoLuongXuat FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayXuat AND MaSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaXuat float = (SELECT GiaXuat FROM inserted)
	IF @soLuongTon IS NULL OR @soLuongTon < @soLuongXuat
		PRINT 'Lỗi do số lượng sách tồn đã hết hoặc không đáp ứng nên không thể lập phiếu được.'
	ELSE
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongTon-@soLuongXuat,@ngayXuat)
END
GO
ALTER TABLE [dbo].[CtPhieuXuat] ENABLE TRIGGER [trgThemCapNhatCtPhieuXuat]
GO
/****** Object:  Trigger [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]    Script Date: 10/19/2017 4:54:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]
ON [dbo].[PhieuXuat]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maDaiLy nchar(5) = (SELECT MaDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoDL (MaDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @tongTienConNo)
END
GO
ALTER TABLE [dbo].[PhieuXuat] ENABLE TRIGGER [trgTaoPhieuXuatCapNhatCongNoDL]
GO
USE [master]
GO
ALTER DATABASE [PhatHanhSach] SET  READ_WRITE 
GO
