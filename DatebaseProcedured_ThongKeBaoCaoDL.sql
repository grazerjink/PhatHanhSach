ALTER PROC procThongKeBaoCaoDL
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

EXEC procThongKeBaoCaoDL 'HQ100','10/01/2017','10/31/2017'