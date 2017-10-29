ALTER PROC proThongKeDoanhThu @batDau date, @ketThuc date
AS
BEGIN
SELECT PN.TongChi, PX.TongThu
FROM 
(	
	SELECT SUM(pn.TongTien) TongChi
	FROM PhieuNhap pn
	JOIN CtPhieuNhap ct ON ct.IdPhieuNhap = pn.Id
	WHERE pn.ThoiGianNhap BETWEEN @batDau AND @ketThuc
) PN,
(
	SELECT SUM(px.TongTien) TongThu 
	FROM PhieuXuat px
	JOIN CtPhieuXuat ct ON ct.IdPhieuXuat = px.Id
	WHERE px.ThoiGianXuat BETWEEN @batDau AND @ketThuc
) PX
END

EXEC proThongKeDoanhThu '10/1/2017','10/31/2017'