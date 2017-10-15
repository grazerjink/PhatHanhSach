CREATE TRIGGER trgThemCapNhatCtPhieuNhap
ON CtPhieuNhap
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.MaPhieuNhap = ct.MaPhieuNhap)
	DECLARE @maSach nchar(5) = (SELECT MaSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND MaSach = @maSach ORDER BY ThoiGian DESC)
	DECLARE @giaNhap float = (SELECT GiaNhap FROM inserted)
	IF @soLuongTon IS NULL
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongNhap,@ngayNhap)
	ELSE
		INSERT INTO TonKho (MaSach,SoLuong,ThoiGian) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap)
END