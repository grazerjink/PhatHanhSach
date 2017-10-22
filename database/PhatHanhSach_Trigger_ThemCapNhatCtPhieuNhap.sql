ALTER TRIGGER trgThemCapNhatCtPhieuNhap
ON CtPhieuNhap
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.ID = ct.IdPhieuNhap)
	DECLARE @maSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND IdSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaNhap float = (SELECT DonGiaNhap FROM inserted)

	IF @soLuongTon IS NULL
	BEGIN		
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
	ELSE
	BEGIN		
		UPDATE TonKho SET SoLuong = @soLuongTon + @soLuongNhap WHERE ThoiGian > @ngayNhap
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
END