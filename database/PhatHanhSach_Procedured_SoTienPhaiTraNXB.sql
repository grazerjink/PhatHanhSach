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
		s.Id,
		s.TenSach, 
		ctpn.DonGiaNhap,
		SUM(ct.SoLuongXuat) SoLuongXuat,
		SUM(ct.SoLuongXuat)*ctpn.DonGiaNhap TongTienXuat
	FROM CtPhieuXuat ct
	JOIN PhieuXuat px ON px.Id = ct.IdPhieuXuat
	JOIN Sach s ON ct.IdSach = s.Id
	JOIN CtPhieuNhap ctpn ON ctpn.IdSach = s.Id
	WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc
		AND ct.IdSach IN (
			SELECT ct.IdSach
			FROM CtPhieuNhap ct
			JOIN PhieuNhap pn ON ct.IdPhieuNhap = pn.Id
			JOIN Sach s ON ct.IdSach = s.Id
			WHERE 
				pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc AND
				pn.IdNXB = @maNXB
		)
	GROUP BY s.Id, s.TenSach, ctpn.DonGiaNhap
END

EXEC proThongKeSachNhap 1002, '10/1/2017', '10/31/2017'
GO
EXEC proThongKeSachXuat 1002, '10/1/2017', '10/31/2017'