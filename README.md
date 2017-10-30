## Bài tập đồ án nhỏ: Xây dựng phần mềm phát hành sách

### Hướng dẫn cấu hình và build để chạy được project
+ **B1**: Open file .sql bằng SQL Server -> Select all(hoặc Ctrl+A) rồi chọn Execute(hoặc F5) để hệ thống tạo ra Database tên là **PhatHanhSachV2**.
+ **B2**: Mở project ra (double click vào file đuôi là .sln) chạy build project trước cái đã để cập nhật các Libs liên quan cần sử dụng.
+ **B3**: Trong mỗi mục module có file tên **ConnectionString.config** vào sửa lại cái tên **localhost** (tên server trong sql) (vd. **DESKTOP/SQLServerExpress**) để connect database. Sau đó save lại.
+ **B4**: Build project lần nữa.
+ **B5**: Nhấn Ctrl+F5 để chạy chương trình hoặc click nút Run trong Visual Studio nhưng sẽ build lâu vđ :)))
+ **Lưu ý:** Database mình đã sửa đổi nhiều thứ và chuyển thành PhatHanhSachV2, mình có reUP những file SQL về Database mới rồi.

### Chức năng đã xây dựng
+ Chức năng thêm, xóa, sửa danh sách **đại lý**.
+ Chức năng xem, thêm **phiếu nhập sách từ NXB** và trigger cập nhật bảng Tồn Kho trong CSDL.
+ Chức năng xem, thêm **phiếu xuất sách cho đại lý** và trigger cập nhật bảng Tồn Kho trong CSDL.
+ Chức năng tạo, xác nhận thanh toán các **báo cáo cho Đại lý** và trigger cập nhật Tồn nợ cho đại lý trong CSDL
+ Chức năng tạo, xác nhận thanh toán các **báo cáo cho NXB** và trigger cập nhật Tồn nợ cho NXB trong CSDL
+ Chức năng thống kê **sách tồn kho** tại một thời điểm.
+ Chức năng thống kê **công nợ đại lý** tại một thời điểm.
+ Chức năng thống kê **công nợ nhà xuất bản** tại một thời điểm.
+ Chức năng thống kê **doanh thu** theo khoảng thời gian.
___
> **KJAPPS**
