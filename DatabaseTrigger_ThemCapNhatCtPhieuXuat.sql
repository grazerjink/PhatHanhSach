CREATE TRIGGER trgThemCapNhatCtPhieuXuat
ON CtPhieuXuat
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayXuat datetime = (SELECT px.ThoiGianXuat FROM inserted ct JOIN PhieuXuat px ON px.MaPhieuXuat = ct.MaPhieuXuat)
	DECLARE @maSach nchar(5) = (SELECT MaSach FROM inserted)
	DECLARE @soLuongXuat int = (SELECT SoLuongXuat FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayXuat AND MaSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaXuat float = (SELECT GiaXuat FROM inserted)
	IF @soLuongTon IS NULL OR @soLuongTon < @soLuongXuat
		PRINT 'Lỗi do số lượng sách tồn đã hết hoặc không đáp ứng nên không thể lập phiếu được.'
	ELSE
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongTon-@soLuongXuat,@ngayXuat)
END