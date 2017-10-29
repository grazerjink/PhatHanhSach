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