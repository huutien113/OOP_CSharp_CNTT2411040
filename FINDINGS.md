# Báo Cáo Kiểm Tra QuanLyBanSach.cs

## Ngày kiểm tra
18/11/2024

## Tổng quan
Đã kiểm tra logic của file `QuanLyBanSach.cs` theo yêu cầu trong đề kiểm tra và phát hiện 2 lỗi logic nghiêm trọng trong phương thức `ThemHoaDonMuaSach`.

## Lỗi phát hiện

### Lỗi 1: Logic kiểm tra độc giả tồn tại (Dòng 61-67)

**Mã nguồn lỗi:**
```csharp
foreach (var dg in danhSachDocGia)
{
    if (dg.MaDG != hd.MaDG)
    { return false; }
}
```

**Vấn đề:**
- Điều kiện `if (dg.MaDG != hd.MaDG)` sai logic
- Hàm sẽ return false ngay khi gặp độc giả KHÁC với mã cần tìm
- Ví dụ: Nếu có 3 độc giả [DG001, DG002, DG003] và cần tìm DG002:
  - Vòng lặp đầu tiên: DG001 != DG002 → return false (SAI!)
  - Không bao giờ kiểm tra được DG002 và DG003

**Hậu quả:**
- Chỉ có độc giả đầu tiên trong danh sách mới có thể mua hàng
- Các độc giả khác đều bị từ chối

**Sửa chữa:**
```csharp
// Kiểm tra xem độc giả có tồn tại trong danh sách không
bool docGiaTonTai = false;
foreach (var dg in danhSachDocGia)
{
    if (dg.MaDG == hd.MaDG)
    {
        docGiaTonTai = true;
        break;
    }
}

if (!docGiaTonTai)
{
    return false;
}
```

### Lỗi 2: Logic kiểm tra tồn kho và giá bán (Dòng 75-84)

**Mã nguồn lỗi:**
```csharp
if (sach.SoLuongTon < chiTiet.SoLuong || chiTiet.SoLuong <= 0)
{
    if (chiTiet.DonGia < (sach.GiaNhap * 1.1))
    {
        return false;
    }
}
```

**Vấn đề:**
- Điều kiện lồng nhau sai logic
- Chỉ kiểm tra giá bán KHI không đủ hàng hoặc số lượng <= 0
- Nếu đủ hàng thì không kiểm tra giá → Có thể bán lỗ
- Nếu không đủ hàng nhưng giá cao thì vẫn cho phép (không return false)

**Kịch bản lỗi:**
1. Có đủ hàng + giá bán thấp → Không kiểm tra giá → Bán lỗ (SAI!)
2. Không đủ hàng + giá bán cao → Không return false → Vẫn bán (SAI!)

**Sửa chữa:**
```csharp
// Kiểm tra số lượng hợp lệ
if (chiTiet.SoLuong <= 0)
{
    return false;
}

// Kiểm tra tồn kho
if (sach.SoLuongTon < chiTiet.SoLuong)
{
    return false;
}

// Kiểm tra đơn giá bán phải >= giá nhập * 1.1
if (chiTiet.DonGia < (sach.GiaNhap * 1.1))
{
    return false;
}
```

## Kết quả kiểm thử

Sau khi sửa lỗi, đã tạo chương trình test với 8 test cases:

1. ✅ **PASS** - Cập nhật số lượng tồn
2. ✅ **PASS** - Tìm sách theo nhà xuất bản
3. ✅ **PASS** - Thêm hóa đơn thành công (có độc giả, đủ hàng, giá hợp lệ)
4. ✅ **PASS** - Từ chối hóa đơn với độc giả không tồn tại
5. ✅ **PASS** - Từ chối hóa đơn với giá bán thấp hơn yêu cầu
6. ✅ **PASS** - Từ chối hóa đơn không đủ số lượng tồn
7. ✅ **PASS** - Từ chối sách không tồn tại trong danh sách
8. ✅ **PASS** - Thống kê độc giả mua nhiều nhất

Tất cả các test cases đều PASS sau khi sửa lỗi.

## Các phương thức khác

### CapNhatSoLuongTon
✅ Hoạt động đúng - Cập nhật số lượng tồn kho cho sách

### TimSachTheoNhaXuatBan
✅ Hoạt động đúng - Tìm và trả về danh sách sách theo nhà xuất bản

### ThongKeDocGiaMuaNhieuNhat
✅ Hoạt động đúng - Tính toán chính xác:
- Lọc hóa đơn theo tháng/năm
- Tính tổng tiền từ chi tiết hóa đơn
- Áp dụng chiết khấu theo loại độc giả (VIP: 20%, Thuong: 10%, Moi: 0%)
- Tìm độc giả có tổng thanh toán cao nhất

## Các thay đổi khác

Đã cập nhật file `OOP_CSharp.csproj` để bao gồm:
- `classesLib.cs` - Các lớp định nghĩa (Sach, DocGia, HoaDonMuaSach, etc.)
- `QuanLyBanSach.cs` - Lớp quản lý

## Kết luận

Các lỗi logic đã được sửa chữa hoàn toàn. Code hiện đã hoạt động đúng theo yêu cầu:
1. Kiểm tra độc giả tồn tại trước khi tạo hóa đơn
2. Kiểm tra số lượng hợp lệ (> 0)
3. Kiểm tra đủ số lượng tồn kho
4. Kiểm tra giá bán >= giá nhập * 1.1
5. Chỉ trừ tồn kho khi tất cả điều kiện đều hợp lệ
