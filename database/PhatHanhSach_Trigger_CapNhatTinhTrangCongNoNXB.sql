ALTER TRIGGER trgCapNhatTinhTrangThanhToan ON ThanhToan
AFTER UPDATE
AS
BEGIN
	DECLARE @idNXB int = (SELECT IdNXB FROM inserted)
	DECLARE @ngayXacNhan datetime = (SELECT NgayXacNhan FROM inserted)
	DECLARE @tongThanhToan float = (SELECT TongTienThanhToan FROM inserted)
	DECLARE @tinhTrang int = (SELECT IdTinhTrang FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoNXB WHERE NgayCapNhat <= @ngayXacNhan AND IdNXB = @idNXB ORDER BY NgayCapNhat DESC, Id DESC)
	IF @tinhTrang = 2
	BEGIN
		UPDATE CongNoNXB SET TongTienConNo = TongTienConNo - @tongThanhToan WHERE NgayCapNhat > @ngayXacNhan
		INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienConNo, TongTienThanhToan) VALUES (@idNXB, @ngayXacNhan, @noCu-@tongThanhToan, @tongThanhToan)
	END
END