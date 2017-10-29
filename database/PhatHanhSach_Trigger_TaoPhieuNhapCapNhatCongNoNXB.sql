ALTER TRIGGER trgTaoPhieuNhapCapNhatCongNoNXB
ON PhieuNhap
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maNXB int = (SELECT IdNXB FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianNhap FROM inserted)
	DECLARE @noMoi float = (SELECT TongTien FROM inserted)
	DECLARE @trangThai bit = (SELECT TrangThai FROM inserted)
	DECLARE @noCu int = (SELECT TOP(1) TongTienConNo FROM CongNoNXB WHERE NgayCapNhat <= @ngayCapNhat AND IdNXB = @maNXB ORDER BY NgayCapNhat DESC, Id DESC)
	IF (@trangThai = 0)
		UPDATE CongNoNXB SET TongTienConNo = TongTienConNo - @noMoi WHERE NgayCapNhat >= @ngayCapNhat
	ELSE
	BEGIN
		IF @noCu IS NULL
			INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @noMoi)
		ELSE
		BEGIN
			UPDATE CongNoNXB SET TongTienConNo = TongTienConNo + @noMoi WHERE NgayCapNhat > @ngayCapNhat
			INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @noCu + @noMoi)
		END
	END
END