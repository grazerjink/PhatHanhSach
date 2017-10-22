ALTER TRIGGER trgTaoPhieuXuatCapNhatCongNoDL
ON PhieuXuat
AFTER UPDATE
AS
BEGIN
	DECLARE @maDaiLy int = (SELECT IdDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoDL (IdDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @tongTienConNo)
END