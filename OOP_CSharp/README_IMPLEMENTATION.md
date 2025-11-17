# Tài liệu Triển khai - OOP C# Kiểm tra Thực hành

## Tổng quan
Dự án này triển khai 3 đề kiểm tra thực hành OOP (Đề 0, 1, 2) với các lớp quản lý:
- **Đề 0**: QuanLyCuaHang - Quản lý cửa hàng
- **Đề 1**: QuanLyNhaThuoc - Quản lý nhà thuốc
- **Đề 2**: QuanLyNhaSach - Quản lý nhà sách

## Các file đã triển khai

### 1. QuanLyCuaHang.cs (Đề 0)
Quản lý hệ thống bán hàng với các chức năng:
- `CapNhatSoLuongTon(int maSP, int soLuongNhapThem)`: Cập nhật tồn kho sản phẩm
- `TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)`: Tìm kiếm sản phẩm theo nhà cung cấp
- `ThemHoaDon(HoaDon hd)`: Thêm hóa đơn với kiểm tra đầy đủ
- `ThongKeKhachHangMuaNhieuNhat(int thang, int nam)`: Thống kê khách hàng mua nhiều nhất

### 2. QuanLyNhaThuoc.cs (Đề 1)
Quản lý hệ thống bán thuốc với các chức năng:
- `CapNhatSoLuongTon(int maThuoc, int soLuongNhapThem)`: Cập nhật tồn kho thuốc
- `TimKiemThuocTheoNhaSanXuat(string nhaSanXuat)`: Tìm kiếm thuốc theo nhà sản xuất
- `ThemDonThuoc(DonThuoc dt)`: Thêm đơn thuốc với kiểm tra đầy đủ
- `ThongKeBenhNhanChiTieuNhieuNhat(int thang, int nam)`: Thống kê bệnh nhân chi tiêu nhiều nhất

### 3. QuanLyNhaSach.cs (Đề 2)
Quản lý hệ thống bán sách với các chức năng:
- `CapNhatSoLuongTon(int maSach, int soLuongNhapThem)`: Cập nhật tồn kho sách
- `TimKiemSachTheoNhaXuatBan(string nhaXuatBan)`: Tìm kiếm sách theo nhà xuất bản
- `ThemHoaDonMuaSach(HoaDonMuaSach hd)`: Thêm hóa đơn mua sách với kiểm tra đầy đủ
- `ThongKeDocGiaMuaNhieuNhat(int thang, int nam)`: Thống kê độc giả mua nhiều nhất

### 4. TestKiemTra.cs
File kiểm tra với dữ liệu từ tài liệu Word, bao gồm các test case cho cả 3 đề.

## Các tính năng chính

### 1. Kiểm tra ràng buộc khi thêm hóa đơn/đơn thuốc
- Kiểm tra khách hàng/bệnh nhân/độc giả có tồn tại
- Kiểm tra sản phẩm/thuốc/sách có tồn tại
- Kiểm tra số lượng > 0 và không vượt quá tồn kho
- Kiểm tra đơn giá >= giá nhập * 1.1 (lợi nhuận tối thiểu 10%)
- Transaction atomic: nếu có lỗi thì hủy toàn bộ, không thay đổi gì

### 2. Tính toán chiết khấu
- VIP: 10% chiết khấu
- Thuong: 5% chiết khấu
- Moi: 0% chiết khấu

### 3. Thống kê
Công thức tính tiền thanh toán thực tế:
```
Tổng tiền chi tiết = Σ (Đơn giá × Số lượng)
Tiền thanh toán thực tế = Tổng tiền chi tiết × (1 - chiết khấu loại khách)
```

## Quy tắc đặt tên biến

### Biến thông thường
- Sử dụng tên viết tắt hoặc nguyên văn tiếng Việt
- Viết hoa chữ cái đầu của mỗi từ
- Ví dụ: `KT` (kiểm tra), `SanPham`, `TongTien`

### Biến List
- Prefix: `Lst_`
- Ví dụ: `Lst_KetQua`, `Lst_MaKH`, `Lst_TongTien`

### Biến Dictionary
- Prefix: `Dict_`
- Ví dụ: `Dict_TongTienKH` (hoặc tên mô tả như `chietKhauTheoLoai`)

### Tên phương thức từ đề bài
- Giữ nguyên tên trong đề bài
- Ví dụ: `ThongKeKhachHangMuaNhieuNhat(int thang, int nam)`

## Kỹ thuật lập trình

### 1. Chỉ sử dụng vòng lặp for
```csharp
// ✓ Đúng
for (int i = 0; i < list.Count; i++)
{
    // code
}

// ✗ Không dùng
foreach (var item in list)
{
    // code
}
```

### 2. Không dùng LINQ
```csharp
// ✓ Đúng - tự viết vòng lặp để tìm max
for (int i = 0; i < Lst_TongTien.Count; i++)
{
    if (DauTien || Lst_TongTien[i] > TienMax)
    {
        TienMax = Lst_TongTien[i];
        MaKHMax = Lst_MaKH[i];
        DauTien = false;
    }
}

// ✗ Không dùng
var max = list.Max();
var result = list.Where(x => x > 0).OrderBy(x => x).First();
```

### 3. Xử lý floating-point precision
Do đặc thù của số thực, so sánh cần thêm epsilon:
```csharp
double GiaToiThieu = sp.GiaNhap * 1.1;
if (ct.DonGiaBan < GiaToiThieu - 0.01)  // Thêm tolerance 0.01
{
    KT_TatCaHopLe = false;
    break;
}
```

## Kết quả kiểm tra

### Đề 0: QuanLyCuaHang
```
KH001 (VIP): 2,925,000 VND
KH002 (Thuong): 6,840,000 VND ← Cao nhất
KH003 (Moi): Hóa đơn bị từ chối (vượt tồn kho)

Kết quả: Trần Thị Thanh
```

### Đề 1: QuanLyNhaThuoc
```
BN001 (VIP): 544,500 VND ← Cao nhất
BN002 (Thuong): 313,500 VND
BN003 (Moi): Đơn thuốc bị từ chối (vượt tồn kho)

Kết quả: Nguyễn Văn An
```

### Đề 2: QuanLyNhaSach
```
DG001 (VIP): 643,500 VND ← Cao nhất
DG002 (Thuong): 522,500 VND
DG003 (Moi): Hóa đơn bị từ chối (vượt tồn kho)

Kết quả: Nguyễn Văn An
```

## Biên dịch và chạy

### Với Mono (Linux/Mac)
```bash
# Biên dịch
mcs -out:TestKiemTra.exe classesLib.cs QuanLyCuaHang.cs QuanLyNhaThuoc.cs QuanLyNhaSach.cs TestKiemTra.cs

# Chạy
mono TestKiemTra.exe
```

### Với .NET Framework (Windows)
```bash
# Biên dịch
csc /out:TestKiemTra.exe classesLib.cs QuanLyCuaHang.cs QuanLyNhaThuoc.cs QuanLyNhaSach.cs TestKiemTra.cs

# Chạy
TestKiemTra.exe
```

## Lưu ý quan trọng

1. **Không sửa đổi classesLib.cs** - File này chứa các lớp được định nghĩa sẵn
2. **Sử dụng namespace KTGK_CSharp** - Tất cả các lớp trong classesLib.cs thuộc namespace này
3. **Transaction atomic** - Nếu có lỗi trong bất kỳ chi tiết nào, toàn bộ hóa đơn sẽ bị từ chối
4. **Chiết khấu** - Được áp dụng trên tổng tiền, không áp dụng trên từng sản phẩm
5. **Lợi nhuận tối thiểu** - Đơn giá phải >= giá nhập × 1.1 (10%)

## Các vấn đề đã giải quyết

### 1. Floating-point precision issue
**Vấn đề**: `50000 * 1.1` trả về `55000.00000000073` thay vì `55000.0`, khiến cho `55000 < 55000.00000000073` trả về `true`.

**Giải pháp**: Thêm epsilon (0.01) vào so sánh:
```csharp
if (ct.DonGiaBan < GiaToiThieu - 0.01)
```

### 2. Dictionary iteration without foreach
**Vấn đề**: Không được dùng foreach để duyệt Dictionary.

**Giải pháp**: Sử dụng hai List song song để lưu key và value:
```csharp
List<string> Lst_MaKH = new List<string>();
List<double> Lst_TongTien = new List<double>();
```

### 3. Tìm maximum không dùng Max()
**Vấn đề**: Không được dùng hàm Max() có sẵn.

**Giải pháp**: Tự viết vòng lặp để tìm giá trị lớn nhất:
```csharp
for (int i = 0; i < Lst_TongTien.Count; i++)
{
    if (DauTien || Lst_TongTien[i] > TienMax)
    {
        TienMax = Lst_TongTien[i];
        MaKHMax = Lst_MaKH[i];
        DauTien = false;
    }
}
```
