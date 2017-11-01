-- CẬP NHẬT SỐ NỢ KHI THANH TOÁN TIỀN CỦA PHIẾU BÁO CÁO ĐẠI LÝ --
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

-- CẬP NHẬT SỐ NỢ KHI THANH TOÁN TIỀN CỦA PHIẾU BÁO CÁO CỦA MÌNH CHO NXB --
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

-- CẬP NHẬT SỐ TIỀN MÌNH NỢ NXB KHI PHIẾU NHẬP ĐƯỢC THÊM --
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

-- CẬP NHẬT SỐ TIỀN ĐẠI LÝ NỢ KHI PHIẾU XUẤT ĐƯỢC THÊM --
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

-- CẬP NHẬT CỘNG THÊM SỐ LƯỢNG TỒN CỦA SÁCH KHI PHIẾU NHẬP ĐƯỢC THÊM --
ALTER TRIGGER trgThemCapNhatCtPhieuNhap
ON CtPhieuNhap
AFTER INSERT
AS
BEGIN
	DECLARE @ngayNhap datetime = (SELECT pn.ThoiGianNhap FROM inserted ct JOIN PhieuNhap pn ON pn.ID = ct.IdPhieuNhap)
	DECLARE @maSach int = (SELECT IdSach FROM inserted)
	DECLARE @soLuongNhap int = (SELECT SoLuongNhap FROM inserted)
	DECLARE @soLuongTon int = (SELECT TOP(1) SoLuong FROM TonKho WHERE ThoiGian <= @ngayNhap AND IdSach = @maSach ORDER BY ThoiGian DESC, Id DESC)
	DECLARE @giaNhap float = (SELECT DonGiaNhap FROM inserted)

	IF @soLuongTon IS NULL	
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongNhap,@ngayNhap, @soLuongNhap)
	ELSE
	BEGIN		
		UPDATE TonKho SET SoLuong = SoLuong + @soLuongNhap WHERE ThoiGian > @ngayNhap AND IdSach = @maSach
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian,TangGiam) VALUES (@maSach,@soLuongTon+@soLuongNhap,@ngayNhap, @soLuongNhap)
	END
END

-- CẬP NHẬT TRỪ ĐI SỐ LƯỢNG TỒN CỦA SÁCH KHI PHIẾU XUẤT ĐƯỢC THÊM --
ALTER TRIGGER trgThemCapNhatCtPhieuXuat
ON CtPhieuXuat
AFTER INSERT
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
	BEGIN
		UPDATE TonKho SET SoLuong = SoLuong - @soLuongXuat WHERE ThoiGian > @ngayXuat AND IdSach = @IdSach
		INSERT INTO TonKho (IdSach,SoLuong,ThoiGian, TangGiam) VALUES (@IdSach,@soLuongTon-@soLuongXuat,@ngayXuat, -@soLuongXuat)
	END
END