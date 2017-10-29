CREATE PROC proThongKeSLConThangTruoc @maDaiLy int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM BaoCaoDL bc
JOIN CtBaoCaoDL ct ON bc.Id = ct.IdBaoCao
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdDaiLy = @maDaiLy AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC

ALTER PROC proThongKeSLTonThangTruoc @maNXB int, @ngayTaoMoi date
AS
SELECT TOP(1) s.Id, s.TenSach, ct.SoLuongCon SoLuongMua, ct.ThanhTien
FROM ThanhToan tt
JOIN CtThanhToan ct ON tt.Id = ct.IdThanhToan
JOIN Sach s ON ct.IdSach = s.Id
WHERE IdThanhToan = @maNXB AND ThoiGianLapPhieu < @ngayTaoMoi
ORDER BY ThoiGianLapPhieu DESC

EXEC proThongKeSLTonThangTruoc 1000, '11/21/2017'