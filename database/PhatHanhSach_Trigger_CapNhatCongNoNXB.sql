ALTER TRIGGER trgTaoPhieuNhapCapNhatCongNoNXB
ON PhieuNhap
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @maNXB int = (SELECT IdNXB FROM inserted)
	DECLARE @ngayCapNhat date = (SELECT ThoiGianNhap FROM inserted)
	DECLARE @tongTienConNo float = (SELECT TongTien FROM inserted)
	INSERT INTO CongNoNXB (IdNXB, NgayCapNhat, TongTienThanhToan, TongTienConNo) VALUES (@maNXB, @ngayCapNhat, 0, @tongTienConNo)
END