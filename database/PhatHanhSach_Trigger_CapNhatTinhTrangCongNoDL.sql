ALTER TRIGGER trgCapNhatTinhTrangBaoCaoDL ON BaoCaoDL
AFTER UPDATE
AS
BEGIN
	DECLARE @idDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayXacNhan datetime = (SELECT NgayXacNhan FROM inserted)
	DECLARE @tongThanhToan float = (SELECT TongTienThanhToan FROM inserted)
	DECLARE @tinhTrang int = (SELECT IdTinhTrang FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoDL WHERE NgayCapNhat <= @ngayXacNhan AND IdDaiLy = @idDaiLy ORDER BY NgayCapNhat DESC, Id DESC)
	IF @tinhTrang = 2
	BEGIN
		UPDATE CongNoDL SET TongTienConNo = TongTienConNo - @tongThanhToan WHERE NgayCapNhat > @ngayXacNhan
		INSERT INTO CongNoDL (IdDaiLy, NgayCapNhat, TongTienConNo, TongTienThanhToan) VALUES (@idDaiLy, @ngayXacNhan, @noCu - @tongThanhToan, @tongThanhToan)
	END
END
