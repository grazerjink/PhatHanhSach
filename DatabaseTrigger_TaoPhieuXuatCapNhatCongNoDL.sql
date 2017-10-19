CREATE TRIGGER trgTaoPhieuXuatCapNhatCongNoDL
ON PhieuXuat
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maDaiLy nchar(5) = (SELECT MaDaiLy FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianXuat FROM inserted)
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoDL (MaDaiLy,NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maDaiLy, @ngayCapNhat, 0, @tongTienConNo)
END