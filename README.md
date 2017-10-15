## Bài tập đồ án nhỏ: Xây dựng phần mềm phát hành sách

### Hướng dẫn cấu hình và build để chạy được project
+ **B1**: Open file .sql bằng SQL Server -> Select all(hoặc Ctrl+A) rồi chọn Execute(hoặc F5) để hệ thống tạo ra Database tên là PhatHanhSach.
+ **B2**: Mở project ra (double click vào file đuôi là .sln) chạy build project trước cái đã để cập nhật các Libs liên quan cần sử dụng.
+ **B3**: Trong mỗi mục module có file tên **ConnectionString.config** vào sửa lại cái localhost name (tên server trong sql) (vd. DESKTOP/SQLServerExpress), sửa lại tên **username** và **password** dùng để connect database. Sau đó save lại.
+ **B4**: Build project lần nữa.
+ **B5**: Nhấn Ctrl+F5 để chạy chương trình hoặc click nút Run trong Visual Studio nhưng sẽ build lâu vđ :)))

### Chức năng đã xây dựng
+ Chức năng thêm, xóa, sửa danh sách **đại lý**.
+ Chức năng xem, thêm **phiếu nhập sách từ NXB** và trigger cập nhật bảng Tồn Kho trong CSDL.
+ Chức năng xem, thêm **phiếu xuất sách cho đại lý** và trigger cập nhật bảng Tồn Kho trong CSDL.
+ Phần còn lại đang tiếp tục xây dựng.

___
> **KJAPPS**
