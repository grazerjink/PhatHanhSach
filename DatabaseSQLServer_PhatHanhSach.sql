/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [PhatHanhSach]    Script Date: 10/11/2017 10:01:15 PM ******/
CREATE DATABASE [PhatHanhSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhatHanhSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PhatHanhSach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhatHanhSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\PhatHanhSach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PhatHanhSach] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhatHanhSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhatHanhSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhatHanhSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhatHanhSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhatHanhSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhatHanhSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhatHanhSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhatHanhSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhatHanhSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhatHanhSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhatHanhSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhatHanhSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhatHanhSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhatHanhSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhatHanhSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhatHanhSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhatHanhSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhatHanhSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhatHanhSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhatHanhSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhatHanhSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhatHanhSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhatHanhSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhatHanhSach] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PhatHanhSach] SET  MULTI_USER 
GO
ALTER DATABASE [PhatHanhSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhatHanhSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhatHanhSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhatHanhSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhatHanhSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PhatHanhSach] SET QUERY_STORE = OFF
GO
USE [PhatHanhSach]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PhatHanhSach]
GO
/****** Object:  Table [dbo].[BaoCaoDL]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoDL](
	[MaBaoCao] [nchar](5) NOT NULL,
	[MaDaiLy] [nchar](5) NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[ThoiGianLap] [datetime] NULL,
	[TongTien] [float] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoDL]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongNoDL](
	[MaDaiLy] [nchar](5) NOT NULL,
	[MaBaoCao] [nchar](5) NULL,
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
 CONSTRAINT [PK_CongNoDL] PRIMARY KEY CLUSTERED 
(
	[MaDaiLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoNXB]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[CtBaoCaoDL]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtBaoCaoDL](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaBaoCao] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuongBan] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtBaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CtDoanhThu]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[CtPhieuNhap]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[CtPhieuXuat]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[CtThanhToan]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CtThanhToan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuThanhToan] [nchar](5) NULL,
	[MaSach] [nchar](5) NULL,
	[SoLuongXuat] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_CtThanhToan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DaiLy]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaiLy](
	[MaDaiLy] [nchar](5) NOT NULL,
	[TenDaiLy] [nvarchar](250) NULL,
	[SoDienThoai] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_DaiLy] PRIMARY KEY CLUSTERED 
(
	[MaDaiLy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaPhieuDoanhThu] [nchar](5) NOT NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[ThoIGianLap] [datetime] NULL,
	[TongLai] [float] NULL,
 CONSTRAINT [PK_DoanhThu] PRIMARY KEY CLUSTERED 
(
	[MaPhieuDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 10/11/2017 10:01:16 PM ******/
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
/****** Object:  Table [dbo].[Sach]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](5) NOT NULL,
	[TenSach] [nvarchar](250) NULL,
	[TacGia] [nvarchar](250) NULL,
	[LinhVuc] [nvarchar](250) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[MaPhieuThanhToan] [nchar](5) NOT NULL,
	[MaNXB] [nchar](5) NULL,
	[ThoiGianBatDau] [date] NULL,
	[ThoiGianKetThuc] [date] NULL,
	[ThoiGianLap] [datetime] NULL,
	[TongTien] [float] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[MaPhieuThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TonKho]    Script Date: 10/11/2017 10:01:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonKho](
	[Id] [int] NOT NULL,
	[MaSach] [nchar](5) NULL,
	[GiaNhap] [float] NULL,
	[GiaXuat] [float] NULL,
	[SoLuong] [int] NULL,
	[ThoiGian] [datetime] NULL,
 CONSTRAINT [PK_TonKho] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
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
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'AF100', N'The Diary of a Young Girl', N'Anne Frank', N'Ngôn tình, tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'BK100', N'The Poisonwood Bible: A Novel', N'Barbara Kingsolver', N'Triết lý, đời sống', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'DE100', N'A Heartbreaking Work of Staggering Genius', N'Dave Eggers', N'Đời sống, nhân văn', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'DS100', N'The Grand Design', N'Stephen Hawking', N'Thiết kế', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'EC100', N'The Very Hungry Caterpillar', N'Eric Carle', N'Triết học, xã hội', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'ED100', N'Breath, Eyes, Memory (Oprah''s Book Club)', N'Edwidge Danticat', N'Đời sống, xã hội', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'EH100', N'The Sun Also Rises', N'Ernest Hemingway', N'Ngôn tình, tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'EL100', N'In the Garden of Beasts: Love, Terror, and an American Family in Hitler''s Berlin', N'Erik Larson', N'Ngôn tình', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'EL101', N'Dead Wake: The Last Crossing of the Lusitania', N'Erik Larson', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'ES101', N'Dr. Potter''s Medicine Show', N'Eric Scott Fischl', N'Khoa học, xã hội', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'FM100', N'Angela''s Ashes: A Memoir', N'Frank McCourt', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'HL100', N'To Kill a Mockingbird', N'Harper Lee', N'Đời sống, xã hội', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'HP100', N'Harry Potter and the Sorcerer''s Stone', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'HP101', N'Harry Potter And The Prisoner Of Azkaban: Illustrated Edition', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'JD100', N'Guns, Germs, and Steel: The Fates of Human...', N'Jared Diamond', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'JR100', N'The Lord of the Rings', N'J.R.R. Tolkien', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'KA100', N'Life After Life: A Novel', N'Kate Atkinson', N'Đời sống, nhân văn', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'LC100', N'Alice''s Adventures in Wonderland & Through the Looking', N'Lewis Carroll', N'Cổ tích, truyện tranh', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'LH100', N'Little House on the Prairie (Full Color)', N'Laura Ingalls Wilder, Garth Williams', N'Cổ tích', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'LO100', N'Lolita', N'Vladimir Nabokov, Friederike Poziemski', N'Khoa học', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'SC100', N'1984 (Signet Classics)', N'George Orwell, Erich Fromm', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'SK100', N'A Brief History of Time', N'Stephen Hawking', N'Tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'TC100', N'In Cold Blood', N'Truman Capote', N'Ngôn tình, tiểu thuyết', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'TO100', N'The Things They Carried', N'Tim O''Brien', N'Đời sống, xã hội', 1)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [TacGia], [LinhVuc], [TrangThai]) VALUES (N'TW100', N'The Right Stuff', N'Tom Wolfe', N'Khoa học, công nghệ', 1)
ALTER TABLE [dbo].[BaoCaoDL] ADD  CONSTRAINT [DF_BaoCaoDL_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DaiLy] ADD  CONSTRAINT [DF_DaiLy_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhaXuatBan] ADD  CONSTRAINT [DF_NhaXuatBan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuNhap] ADD  CONSTRAINT [DF_PhieuNhap_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuXuat] ADD  CONSTRAINT [DF_PhieuXuat_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  CONSTRAINT [DF_ThanhToan_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BaoCaoDL]  WITH CHECK ADD  CONSTRAINT [FK_BaoCaoDL_DaiLy] FOREIGN KEY([MaDaiLy])
REFERENCES [dbo].[DaiLy] ([MaDaiLy])
GO
ALTER TABLE [dbo].[BaoCaoDL] CHECK CONSTRAINT [FK_BaoCaoDL_DaiLy]
GO
ALTER TABLE [dbo].[CongNoDL]  WITH CHECK ADD  CONSTRAINT [FK_CongNoDL_BaoCaoDL] FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BaoCaoDL] ([MaBaoCao])
GO
ALTER TABLE [dbo].[CongNoDL] CHECK CONSTRAINT [FK_CongNoDL_BaoCaoDL]
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
ALTER TABLE [dbo].[TonKho]  WITH CHECK ADD  CONSTRAINT [FK_TonKho_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[TonKho] CHECK CONSTRAINT [FK_TonKho_Sach]
GO
USE [master]
GO
ALTER DATABASE [PhatHanhSach] SET  READ_WRITE 
GO
