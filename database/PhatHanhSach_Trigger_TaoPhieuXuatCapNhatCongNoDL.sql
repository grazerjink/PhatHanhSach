ALTER TRIGGER trgTaoPhieuXuatCapNhatCongNoDL
ON PhieuXuat
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @noMoi float = (SELECT TongTien FROM inserted)
	DECLARE @trangThai float = (SELECT TrangThai FROM inserted)
	DECLARE @noCu float = (SELECT TOP(1) TongTienConNo FROM CongNoDL WHERE NgayCapNhat <= @ngayCapNhat AND IdDaiLy = @maDaiLy ORDER BY NgayCapNhat DESC, Id DESC)
	IF (@trangThai = 0)
		UPDATE CongNoDL SET TongTienConNo = TongTienConNo - @noMoi WHERE NgayCapNhat >= @ngayCapNhat
	ELSE
	BEGIN
		IF @noCu IS NULL
			INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @noMoi)
		ELSE
		BEGIN
			UPDATE CongNoDL SET TongTienConNo = TongTienConNo + @noMoi WHERE NgayCapNhat > @ngayCapNhat
			INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @noMoi + @noCu)
		END
	END
END