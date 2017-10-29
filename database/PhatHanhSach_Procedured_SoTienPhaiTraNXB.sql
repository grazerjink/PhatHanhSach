ALTER PROC proThongKeBaoCaoNXB @maNXB int, @batDau date, @ketThuc date AS
BEGIN
SELECT 
	s.Id, 
	s.TenSach, 
	ct.DonGiaNhap, 
	SUM(DISTINCT ct.SoLuongNhap) SoLuongNhap,
	SUM(DISTINCT ct.SoLuongNhap)*ct.DonGiaNhap TongTienNhap,
	SUM(DISTINCT ctpx.SoLuongXuat) SoLuongXuat,
	SUM(DISTINCT ctpx.SoLuongXuat)*ct.DonGiaNhap TongTienThanhToan,
	SUM(DISTINCT ct.SoLuongNhap)*ct.DonGiaNhap - SUM(DISTINCT ctpx.SoLuongXuat)*ct.DonGiaNhap TongTienNo
FROM Sach s
JOIN CtPhieuNhap ct ON ct.IdSach = s.Id
JOIN PhieuNhap pn ON ct.IdPhieuNhap = pn.Id
JOIN CtPhieuXuat ctpx ON ct.IdSach = s.Id
JOIN PhieuXuat px ON ctpx.IdPhieuXuat = px.Id
WHERE 
	pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc AND
	px.ThoiGianXuat BETWEEN @batDau AND @ketThuc AND
	pn.IdNXB = @maNXB
GROUP BY s.Id, s.TenSach, ct.DonGiaNhap
END

EXEC proThongKeBaoCaoNXB 1000, '10/1/2017', '10/31/2017'