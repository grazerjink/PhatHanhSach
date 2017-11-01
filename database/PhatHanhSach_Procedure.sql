-- CHỨC NĂNG THỐNG KÊ CÁC SÁCH ĐÃ NHẬP VÀ ĐÃ XUẤT ĐỂ LẬP BÁO CÁO CHO NXB --
ALTER PROC proThongKeSachNhap @maNXB int, @batDau date, @ketThuc date AS
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
ALTER PROC proThongKeSachXuat @maNXB int, @batDau date, @ketThuc date AS
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

EXEC proThongKeSachNhap 1000, '9/1/2017', '9/30/2017'
GO
EXEC proThongKeSachXuat 1000, '9/1/2017', '9/30/2017'

-- CHỨC NĂNG THỐNG KÊ DANH SÁCH CÁC SÁCH ĐẠI LÝ ĐÃ MUA TRONG KHOẢNG THỜI GIAN --
ALTER PROC procThongKeBaoCaoDL
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

EXEC procThongKeBaoCaoDL 1000,'10/01/2017','10/31/2017'

-- CHỨC NĂNG THỐNG KÊ DOANH THU TRONG KHOẢNG THỜI GIAN --
ALTER PROC proThongKeDoanhThu @batDau date, @ketThuc date
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

EXEC proThongKeDoanhThu '9/1/2017','12/30/2017'

-- CHỨC NĂNG THỐNG KÊ SỐ LƯỢNG SÁCH CHƯA BÁO CÁO CỦA ĐẠI LÝ ĐỂ CỘNG DỒN VÀO DANH SÁCH BÁO CÁO MỚI --
ALTER PROC proThongKeSLConThangTruoc @maDaiLy int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM BaoCaoDL bc
JOIN CtBaoCaoDL ct ON bc.Id = ct.IdBaoCao
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdDaiLy = @maDaiLy AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC

ALTER PROC proThongKeSLTonThangTruoc @maNXB int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM ThanhToan tt
JOIN CtThanhToan ct ON tt.Id = ct.IdThanhToan
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdThanhToan = @maNXB AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC

EXEC proThongKeSLTonThangTruoc 1000, '11/21/2017'