ALTER PROC proThongKeDoanhThu @batDau date, @ketThuc date
AS
BEGIN
	SELECT DISTINCT CAST(date, C.ThoiGian), C.TongChi, T.TongThu
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
	) C,
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
END

EXEC proThongKeDoanhThu '10/1/2017','10/31/2017'