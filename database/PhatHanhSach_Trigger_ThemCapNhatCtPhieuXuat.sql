ALTER TRIGGER trgThemCapNhatCtPhieuXuat
ON CtPhieuXuat
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayXuat datetime = (SELECT px.ThoiGianXuat FROM inserted ct JOIN PhieuXuat px ON px.Id = ct.IdPhieuXuat)
	DECLARE @IdSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongXuat int = (SELECT SoLuongXuat FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayXuat AND IdSach = @IdSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaXuat float = (SELECT DonGiaXuat FROM inserted)

	IF @soLuongTon IS NULL OR @soLuongTon < @soLuongXuat
		PRINT 'Lỗi do số lượng sách tồn đã hết hoặc không đáp ứng nên không thể lập phiếu được.'
	ELSE
		UPDATE TonKho SET SoLuong = SoLuong - @soLuongXuat WHERE ThoiGian > @ngayXuat
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian, TangGiam) VALUES (@IdSach,@soLuongTon-@soLuongXuat,@ngayXuat, @soLuongXuat)
END