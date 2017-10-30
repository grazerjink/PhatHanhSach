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