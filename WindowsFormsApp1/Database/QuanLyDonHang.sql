CREATE DATABASE QuanLyDonHang
GO
USE QuanLyDonHang
GO
/****** Object:  Table [dbo].[Tbl_ChiTietHoaDon]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ChiTietHoaDon](
	[MaDonHang] [nvarchar](50) NOT NULL,
	[MaSanPham] [nvarchar](50) NOT NULL,
	[SoLuong] [float] NULL,
	[DonGia] [float] NULL,
	[ThanhTien] [float] NULL,
 CONSTRAINT [PK_Tbl_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC,
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_HoaDon]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_HoaDon](
	[MaDonHang] [nvarchar](50) NOT NULL,
	[NgayDatHang] [date] NULL,
	[NgayGiaoHang] [date] NULL,
	[TinhTrangThanhToan] [nvarchar](50) NULL,
	[TinhTrangGiaoHang] [nvarchar](50) NULL,
	[MaKhachHang] [nvarchar](50) NULL,
	[TongTien] [float] NULL,
 CONSTRAINT [PK_Tbl_HoaDon_1] PRIMARY KEY CLUSTERED 
(
	[MaDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_KhachHang]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_KhachHang](
	[MaKhachHang] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_LoaiSanPham]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_LoaiSanPham](
	[MaLoaiSanPham] [nvarchar](50) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_SanPham]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_SanPham](
	[MaSanPham] [nvarchar](50) NOT NULL,
	[TenSanPham] [nvarchar](50) NULL,
	[GiaBan] [nvarchar](50) NULL,
	[MoTa] [nvarchar](1000) NULL,
	[NgayCapNhat] [date] NULL,
	[SoLuongTon] [nvarchar](50) NULL,
	[MaLoaiSanPham] [nvarchar](50) NULL,
	[MaThuongHieu] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_TaiKhoan]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_TaiKhoan](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[HoTen] [nvarchar](50) NULL,
	[Quyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_ThuongHieu]    Script Date: 12/20/2022 2:29:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_ThuongHieu](
	[MaThuongHieu] [nvarchar](50) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tbl_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213243', N'SP001', 1, 500000000, 500000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213243', N'SP002', 3, 100000000, 300000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213243', N'SP003', 5, 250000000, 1250000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213243', N'SP004', 8, 300000000, 2400000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213243', N'SP005', 10, 200000000, 2000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213354', N'SP001', 10, 500000000, 5000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213354', N'SP002', 6, 100000000, 600000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213354', N'SP003', 12, 250000000, 3000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213354', N'SP004', 50, 300000000, 15000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213354', N'SP005', 70, 200000000, 14000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213539', N'SP001', 50, 500000000, 25000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213539', N'SP002', 45, 100000000, 4500000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213539', N'SP004', 12, 300000000, 3600000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_213539', N'SP005', 12, 200000000, 3600000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_214950', N'SP001', 10, 500000000, 1000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_214950', N'SP002', 10, 100000000, 1000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_214950', N'SP003', 10, 250000000, 1000000000)
INSERT [dbo].[Tbl_ChiTietHoaDon] ([MaDonHang], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'MDH_12192022_214950', N'SP004', 10, 300000000, 1000000000)
GO
INSERT [dbo].[Tbl_HoaDon] ([MaDonHang], [NgayDatHang], [NgayGiaoHang], [TinhTrangThanhToan], [TinhTrangGiaoHang], [MaKhachHang], [TongTien]) VALUES (N'MDH_12192022_213243', CAST(N'2022-12-19' AS Date), CAST(N'2022-12-24' AS Date), N'Chưa thanh toán', N'Chưa giao hàng', N'KH001', 6450000000)
INSERT [dbo].[Tbl_HoaDon] ([MaDonHang], [NgayDatHang], [NgayGiaoHang], [TinhTrangThanhToan], [TinhTrangGiaoHang], [MaKhachHang], [TongTien]) VALUES (N'MDH_12192022_213354', CAST(N'2022-12-19' AS Date), CAST(N'2022-12-25' AS Date), N'Đã thanh toán', N'Đã giao hàng', N'KH002', 37600000000)
INSERT [dbo].[Tbl_HoaDon] ([MaDonHang], [NgayDatHang], [NgayGiaoHang], [TinhTrangThanhToan], [TinhTrangGiaoHang], [MaKhachHang], [TongTien]) VALUES (N'MDH_12192022_213539', CAST(N'2022-12-19' AS Date), CAST(N'2022-12-31' AS Date), N'Chưa thanh toán', N'Chưa giao hàng', N'KH003', 36700000000)
INSERT [dbo].[Tbl_HoaDon] ([MaDonHang], [NgayDatHang], [NgayGiaoHang], [TinhTrangThanhToan], [TinhTrangGiaoHang], [MaKhachHang], [TongTien]) VALUES (N'MDH_12192022_214950', CAST(N'2022-12-20' AS Date), CAST(N'2022-12-23' AS Date), N'Đã thanh toán', N'Đã giao hàng', N'KH003', 4000000000)
GO
INSERT [dbo].[Tbl_KhachHang] ([MaKhachHang], [HoTen], [Email], [SoDienThoai], [DiaChi]) VALUES (N'KH001', N'Hoàng Văn Long', N'long@gmai.com', N'0976973772', N'Hà Nội')
INSERT [dbo].[Tbl_KhachHang] ([MaKhachHang], [HoTen], [Email], [SoDienThoai], [DiaChi]) VALUES (N'KH002', N'Nguyễn Huy Hoàng', N'dfg@gmail.com', N'0977687733', N'Hàng Mã Hà Nội')
INSERT [dbo].[Tbl_KhachHang] ([MaKhachHang], [HoTen], [Email], [SoDienThoai], [DiaChi]) VALUES (N'KH003', N'Nguyễn Anh Huy', N'ghg@gmail.com', N'0976973771', N'Hải Phòng')
INSERT [dbo].[Tbl_KhachHang] ([MaKhachHang], [HoTen], [Email], [SoDienThoai], [DiaChi]) VALUES (N'KH004', N'Nguyễn Duy Hùng', N'asd@gmail.com', N'0976987773', N'Hải Dương')
INSERT [dbo].[Tbl_KhachHang] ([MaKhachHang], [HoTen], [Email], [SoDienThoai], [DiaChi]) VALUES (N'KH005', N'Hoàng Việt Yên', N'asc@gmail.com', N'0976972771', N'Ninh Bình')
GO
INSERT [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'MLSP001', N'Nội Thất Phòng Khách')
INSERT [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'MLSP002', N'Nội Thất Phòng Ngủ')
INSERT [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'MLSP003', N'Nội Thất Phòng Bếp')
INSERT [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'MLSP004', N'Nội Thất Phòng Game')
INSERT [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'MLSP005', N'Nội Thất Phòng Sinh Hoạt')
GO
INSERT [dbo].[Tbl_SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [MoTa], [NgayCapNhat], [SoLuongTon], [MaLoaiSanPham], [MaThuongHieu]) VALUES (N'SP001', N'Nội Thất Phòng Khách', N'500000000', N'Nội Thất Phòng Khách Theo Phong Cách Hiện Đại Sang Trong Thời Thượng', CAST(N'2022-12-10' AS Date), N'29', N'MLSP001', N'TH001')
INSERT [dbo].[Tbl_SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [MoTa], [NgayCapNhat], [SoLuongTon], [MaLoaiSanPham], [MaThuongHieu]) VALUES (N'SP002', N'Nội Thất Phòng Ngủ', N'100000000', N'Nội Thất Phòng Ngủ Theo Phong Cách Hiện Đại Sang Trong Thời Thượng', CAST(N'2022-12-10' AS Date), N'36', N'MLSP002', N'TH002')
INSERT [dbo].[Tbl_SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [MoTa], [NgayCapNhat], [SoLuongTon], [MaLoaiSanPham], [MaThuongHieu]) VALUES (N'SP003', N'Nội Thất Phòng Bếp', N'250000000', N'Nội Thất Phòng Bếp Theo Phong Cách Hiện Đại Sang Trong Thời Thượng', CAST(N'2022-12-10' AS Date), N'73', N'MLSP003', N'TH003')
INSERT [dbo].[Tbl_SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [MoTa], [NgayCapNhat], [SoLuongTon], [MaLoaiSanPham], [MaThuongHieu]) VALUES (N'SP004', N'Nội Thất Phòng Game', N'300000000', N'Phòng game là không gian riêng tư quan trọng không thể thiếu trong ngôi nhà của bạn', CAST(N'2018-12-17' AS Date), N'20', N'MLSP004', N'TH004')
INSERT [dbo].[Tbl_SanPham] ([MaSanPham], [TenSanPham], [GiaBan], [MoTa], [NgayCapNhat], [SoLuongTon], [MaLoaiSanPham], [MaThuongHieu]) VALUES (N'SP005', N'Nội Thất Phòng Sinh Hoạt', N'200000000', N'Phòng sinh hoạt là không gian riêng tư quan trọng không thể thiếu trong ngôi nhà của bạn', CAST(N'2019-12-17' AS Date), N'8', N'MLSP005', N'TH005')
GO
SET IDENTITY_INSERT [dbo].[Tbl_TaiKhoan] ON 

INSERT [dbo].[Tbl_TaiKhoan] ([STT], [TenDangNhap], [MatKhau], [HoTen], [Quyen]) VALUES (1, N'Admin', N'111', N'Dương Tiến Hiểu', N'Admin')
INSERT [dbo].[Tbl_TaiKhoan] ([STT], [TenDangNhap], [MatKhau], [HoTen], [Quyen]) VALUES (2, N'hieudz', N'123', N'Trần Tiến Hiểu', N'NhanVien')
SET IDENTITY_INSERT [dbo].[Tbl_TaiKhoan] OFF
GO
INSERT [dbo].[Tbl_ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [DiaChi], [SoDienThoai]) VALUES (N'TH001', N'Ashley', N'Hà Nội', N'0976973771')
INSERT [dbo].[Tbl_ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [DiaChi], [SoDienThoai]) VALUES (N'TH002', N'Aaron', N'Thái Bình', N'0975778886')
INSERT [dbo].[Tbl_ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [DiaChi], [SoDienThoai]) VALUES (N'TH003', N'Dunelm Group', N'Đà Nẵng', N'0983473743')
INSERT [dbo].[Tbl_ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [DiaChi], [SoDienThoai]) VALUES (N'TH004', N'Row', N'Tp HCM', N'0976673775')
INSERT [dbo].[Tbl_ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [DiaChi], [SoDienThoai]) VALUES (N'TH005', N'French Heritage', N'Hải Phòng', N'0946624873')
GO
ALTER TABLE [dbo].[Tbl_ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_ChiTietHoaDon_Tbl_HoaDon] FOREIGN KEY([MaDonHang])
REFERENCES [dbo].[Tbl_HoaDon] ([MaDonHang])
GO
ALTER TABLE [dbo].[Tbl_ChiTietHoaDon] CHECK CONSTRAINT [FK_Tbl_ChiTietHoaDon_Tbl_HoaDon]
GO
ALTER TABLE [dbo].[Tbl_ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_ChiTietHoaDon_Tbl_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[Tbl_SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[Tbl_ChiTietHoaDon] CHECK CONSTRAINT [FK_Tbl_ChiTietHoaDon_Tbl_SanPham]
GO
ALTER TABLE [dbo].[Tbl_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_HoaDon_Tbl_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[Tbl_KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[Tbl_HoaDon] CHECK CONSTRAINT [FK_Tbl_HoaDon_Tbl_KhachHang]
GO
ALTER TABLE [dbo].[Tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_SanPham_Tbl_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[Tbl_LoaiSanPham] ([MaLoaiSanPham])
GO
ALTER TABLE [dbo].[Tbl_SanPham] CHECK CONSTRAINT [FK_Tbl_SanPham_Tbl_LoaiSanPham]
GO
ALTER TABLE [dbo].[Tbl_SanPham]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_SanPham_Tbl_ThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[Tbl_ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[Tbl_SanPham] CHECK CONSTRAINT [FK_Tbl_SanPham_Tbl_ThuongHieu]
GO
