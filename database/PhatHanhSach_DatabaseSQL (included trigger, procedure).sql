USE [master]
GO
/****** Object:  Database [PhatHanhSachV2]    Script Date: 10/22/2017 8:33:13 PM ******/
CREATE DATABASE [PhatHanhSachV2]
GO
USE [PhatHanhSachV2]
GO
/****** Object:  Table [dbo].[BaoCaoDL]    Script Date: 10/22/2017 8:33:14 PM ******/
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
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[IdTinhTrang] [int] NULL,
	[NgayXacNhan] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_BaoCaoDL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongNoDL]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CongNoNXB]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CtBaoCaoDL]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CtDoanhThu]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CtPhieuNhap]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CtPhieuXuat]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[CtThanhToan]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[DaiLy]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[Sach]    Script Date: 10/22/2017 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[Id] [int] IDENTITY(100001,1) NOT NULL,
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
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 10/22/2017 8:33:14 PM ******/
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
	[TongTienThanhToan] [float] NULL,
	[TongTienConNo] [float] NULL,
	[IdTinhTrang] [int] NULL,
	[NgayXacNhan] [date] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ThanhToan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 10/22/2017 8:33:14 PM ******/
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
/****** Object:  Table [dbo].[TonKho]    Script Date: 10/22/2017 8:33:14 PM ******/
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
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100000, N'The Diary of a Young Girl', N'Anne Frank', N'Ngôn tình, tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100001, N'The Poisonwood Bible: A Novel', N'Barbara Kingsolver', N'Triết lý, đời sống', 25000, 22000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100002, N'A Heartbreaking Work of Staggering Genius', N'Dave Eggers', N'Đời sống, nhân văn', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100003, N'The Grand Design', N'Stephen Hawking', N'Thiết kế', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100004, N'The Very Hungry Caterpillar', N'Eric Carle', N'Triết học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100005, N'Breath, Eyes, Memory (Oprah''s Book Club)', N'Edwidge Danticat', N'Đời sống, xã hội', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100006, N'The Sun Also Rises', N'Ernest Hemingway', N'Ngôn tình, tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100007, N'In the Garden of Beasts: Love, Terror, and an American Family in Hitler''s Berlin', N'Erik Larson', N'Ngôn tình', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100008, N'Dead Wake: The Last Crossing of the Lusitania', N'Erik Larson', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100009, N'Dr. Potter''s Medicine Show', N'Eric Scott Fischl', N'Khoa học, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100010, N'Angela''s Ashes: A Memoir', N'Frank McCourt', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100011, N'To Kill a Mockingbird', N'Harper Lee', N'Đời sống, xã hội', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100012, N'Harry Potter and the Sorcerer''s Stone', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100013, N'Harry Potter And The Prisoner Of Azkaban: Illustrated Edition', N'J.K. Rowling, Mary GrandPré', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100014, N'Guns, Germs, and Steel: The Fates of Human...', N'Jared Diamond', N'Tiểu thuyết', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100015, N'The Lord of the Rings', N'J.R.R. Tolkien', N'Tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100016, N'Life After Life: A Novel', N'Kate Atkinson', N'Đời sống, nhân văn', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100017, N'Alice''s Adventures in Wonderland & Through the Looking', N'Lewis Carroll', N'Cổ tích, truyện tranh', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100018, N'Little House on the Prairie (Full Color)', N'Laura Ingalls Wilder, Garth Williams', N'Cổ tích', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100019, N'Lolita', N'Vladimir Nabokov, Friederike Poziemski', N'Khoa học', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100020, N'1984 (Signet Classics)', N'George Orwell, Erich Fromm', N'Tiểu thuyết', 15000, 10000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100021, N'A Brief History of Time', N'Stephen Hawking', N'Tiểu thuyết', 20000, 15000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100022, N'In Cold Blood', N'Truman Capote', N'Ngôn tình, tiểu thuyết', 30000, 25000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100023, N'The Things They Carried', N'Tim O''Brien', N'Đời sống, xã hội', 25000, 20000, 1)
INSERT [dbo].[Sach] ([Id], [TenSach], [TacGia], [LinhVuc], [GiaBan], [GiaNhap], [TrangThai]) VALUES (100024, N'The Right Stuff', N'Tom Wolfe', N'Khoa học, công nghệ', 20000, 15000, 1)
SET IDENTITY_INSERT [dbo].[Sach] OFF
SET IDENTITY_INSERT [dbo].[TinhTrang] ON 

INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (1, N'Đã báo cáo')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (2, N'Đã thanh toán')
INSERT [dbo].[TinhTrang] ([Id], [MoTa]) VALUES (3, N'Đã hủy')
SET IDENTITY_INSERT [dbo].[TinhTrang] OFF
ALTER TABLE [dbo].[BaoCaoDL] ADD  CONSTRAINT [DF_BaoCaoDL_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DaiLy] ADD  CONSTRAINT [DF_DaiLy_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[PhieuXuat] ADD  CONSTRAINT [DF_PhieuXuat_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Sach] ADD  CONSTRAINT [DF_Sach_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
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
/****** Object:  StoredProcedure [dbo].[procThongKeBaoCaoDL]    Script Date: 10/22/2017 8:33:14 PM ******/
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
		SUM(ct.SoLuongXuat) SoLuongMua,
		SUM(ct.ThanhTien) ThanhTien
	FROM CtPhieuXuat ct
	JOIN PhieuXuat px ON ct.IdPhieuXuat = px.Id
	JOIN Sach s ON s.Id = ct.IdSach
	WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc AND px.IdDaiLy = @maDaiLy
	GROUP BY s.Id
END
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuNhap]    Script Date: 10/22/2017 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuNhap]
ON [dbo].[CtPhieuNhap]
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.ID = ct.IdPhieuNhap)
	DECLARE @maSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND IdSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaNhap float = (SELECT DonGiaNhap FROM inserted)

	IF @soLuongTon IS NULL
	BEGIN		
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
	ELSE
	BEGIN		
		UPDATE TonKho SET SoLuong = @soLuongTon + @soLuongNhap WHERE ThoiGian > @ngayNhap
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
END
GO
ALTER TABLE [dbo].[CtPhieuNhap] ENABLE TRIGGER [trgThemCapNhatCtPhieuNhap]
GO
/****** Object:  Trigger [dbo].[trgThemCapNhatCtPhieuXuat]    Script Date: 10/22/2017 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgThemCapNhatCtPhieuXuat]
ON [dbo].[CtPhieuXuat]
AFTER INSERT, UPDATE
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
		UPDATE TonKho SET SoLuong = SoLuong - @soLuongXuat WHERE ThoiGian > @ngayXuat
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian, TangGiam) VALUES (@IdSach,@soLuongTon-@soLuongXuat,@ngayXuat, @soLuongXuat)
END
GO
ALTER TABLE [dbo].[CtPhieuXuat] ENABLE TRIGGER [trgThemCapNhatCtPhieuXuat]
GO
/****** Object:  Trigger [dbo].[trgTaoPhieuNhapCapNhatCongNoNXB]    Script Date: 10/22/2017 8:33:14 PM ******/
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
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @tongTienConNo)
END
GO
ALTER TABLE [dbo].[PhieuNhap] ENABLE TRIGGER [trgTaoPhieuNhapCapNhatCongNoNXB]
GO
/****** Object:  Trigger [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]    Script Date: 10/22/2017 8:33:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trgTaoPhieuXuatCapNhatCongNoDL]
ON [dbo].[PhieuXuat]
AFTER UPDATE
AS
BEGIN
	DECLARE @maDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @tongTienConNo)
END
GO
ALTER TABLE [dbo].[PhieuXuat] ENABLE TRIGGER [trgTaoPhieuXuatCapNhatCongNoDL]
GO
USE [master]
GO
ALTER DATABASE [PhatHanhSachV2] SET  READ_WRITE 
GO
