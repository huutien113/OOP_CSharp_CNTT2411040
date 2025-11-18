# Kết Quả Kiểm Thử QuanLyBanSach

## Môi trường kiểm thử
- **Ngày:** 18/11/2024
- **Nền tảng:** .NET 8.0
- **Trình biên dịch:** dotnet CLI

## Dữ liệu kiểm thử

### Danh sách Sách
| Mã Sách | Tên Sách | Giá Nhập | Số Lượng Tồn | Nhà Xuất Bản |
|---------|----------|----------|--------------|--------------|
| 1 | Lập trình C# | 100,000đ | 50 | Kim Đồng |
| 2 | Toán cao cấp | 80,000đ | 30 | Giáo dục |
| 3 | Tiếng Anh giao tiếp | 60,000đ | 20 | Tre |
| 4 | Văn học Việt Nam | 90,000đ | 10 | Kim Đồng |

### Danh sách Độc Giả
| Mã Độc Giả | Họ Tên | Địa Chỉ | Loại | Chiết Khấu |
|------------|---------|---------|------|------------|
| DG001 | Nguyễn Văn A | Hà Nội | VIP | 20% |
| DG002 | Trần Thị B | TP.HCM | Thuong | 10% |
| DG003 | Lê Văn C | Đà Nẵng | Moi | 0% |

## Các Test Cases

### Test 1: Cập nhật số lượng tồn ✅ PASS
**Mục đích:** Kiểm tra phương thức `CapNhatSoLuongTon(int maSach, int soLuongNhapThem)`

**Input:**
- Mã sách: 1
- Số lượng nhập thêm: 10
- Số lượng tồn trước: 50

**Kết quả:**
- Số lượng tồn sau: 60 ✓
- **PASS** - Cập nhật đúng (50 + 10 = 60)

---

### Test 2: Tìm sách theo nhà xuất bản ✅ PASS
**Mục đích:** Kiểm tra phương thức `TimSachTheoNhaXuatBan(string nhaXuatBan)`

**Input:**
- Nhà xuất bản: "Kim Đồng"

**Kết quả:**
```
1 - Lập trình C# - NXB: Kim Đồng - Tồn: 60
4 - Văn học Việt Nam - NXB: Kim Đồng - Tồn: 10
```
- Tìm được 2 sách ✓
- **PASS** - Tìm kiếm chính xác

---

### Test 3: Thêm hóa đơn thành công ✅ PASS
**Mục đích:** Kiểm tra `ThemHoaDonMuaSach` với dữ liệu hợp lệ

**Input:**
- Độc giả: DG001 (tồn tại)
- Chi tiết:
  - Sách 1: 5 cuốn x 120,000đ (> 100,000 x 1.1 = 110,000đ) ✓
  - Sách 2: 3 cuốn x 95,000đ (> 80,000 x 1.1 = 88,000đ) ✓

**Kết quả:**
- Thêm hóa đơn: Thành công ✓
- Sách 1: Tồn 60 → 55 ✓
- Sách 2: Tồn 30 → 27 ✓
- **PASS** - Hóa đơn được thêm và trừ tồn kho đúng

---

### Test 4: Độc giả không tồn tại ✅ PASS
**Mục đích:** Kiểm tra validation độc giả

**Input:**
- Độc giả: DG999 (KHÔNG tồn tại)
- Chi tiết: Sách 1: 2 cuốn x 120,000đ

**Kết quả:**
- Thêm hóa đơn: Thất bại ✓
- **PASS** - Đã chặn độc giả không tồn tại

**Lỗi đã sửa:**
- Trước: Logic sai khiến chỉ độc giả đầu tiên mới được mua
- Sau: Kiểm tra đúng xem độc giả có tồn tại trong danh sách

---

### Test 5: Giá bán thấp hơn yêu cầu ✅ PASS
**Mục đích:** Kiểm tra validation giá bán >= giá nhập x 1.1

**Input:**
- Độc giả: DG002 (tồn tại)
- Chi tiết: Sách 1: 2 cuốn x 100,000đ
- Giá yêu cầu tối thiểu: 100,000 x 1.1 = 110,000đ
- Giá đưa ra: 100,000đ < 110,000đ ✗

**Kết quả:**
- Thêm hóa đơn: Thất bại ✓
- **PASS** - Đã chặn giá bán thấp (bán lỗ)

**Lỗi đã sửa:**
- Trước: Chỉ kiểm tra giá khi không đủ hàng → Có thể bán lỗ khi đủ hàng
- Sau: Luôn kiểm tra giá bán bất kể tồn kho

---

### Test 6: Không đủ số lượng tồn ✅ PASS
**Mục đích:** Kiểm tra validation tồn kho

**Input:**
- Độc giả: DG003 (tồn tại)
- Chi tiết: Sách 4: 20 cuốn x 100,000đ
- Số lượng tồn: 10 cuốn
- Số lượng đặt: 20 cuốn > 10 cuốn ✗

**Kết quả:**
- Thêm hóa đơn: Thất bại ✓
- **PASS** - Đã chặn số lượng vượt tồn kho

---

### Test 7: Sách không tồn tại ✅ PASS
**Mục đích:** Kiểm tra validation sách tồn tại

**Input:**
- Độc giả: DG001 (tồn tại)
- Chi tiết: Sách 999: 2 cuốn x 100,000đ (sách không tồn tại)

**Kết quả:**
- Thêm hóa đơn: Thất bại ✓
- **PASS** - Đã chặn sách không tồn tại

**Cải tiến:**
- Thêm kiểm tra `sachTonTai` để đảm bảo sách có trong danh sách

---

### Test 8: Thống kê độc giả mua nhiều nhất ✅ PASS
**Mục đích:** Kiểm tra `ThongKeDocGiaMuaNhieuNhat(int thang, int nam)`

**Dữ liệu:**
Tạo 3 hóa đơn trong tháng hiện tại:
1. DG001 (VIP, 20% chiết khấu):
   - 5 cuốn x 120,000 = 600,000đ
   - 3 cuốn x 95,000 = 285,000đ
   - Tổng: 885,000đ
   - Sau CK: 885,000 x 0.8 = **708,000đ**

2. DG002 (Thuong, 10% chiết khấu):
   - 5 cuốn x 70,000 = 350,000đ
   - Sau CK: 350,000 x 0.9 = **315,000đ**

3. DG003 (Moi, 0% chiết khấu):
   - 2 cuốn x 120,000 = 240,000đ
   - Sau CK: 240,000 x 1.0 = **240,000đ**

**Kết quả:**
- Độc giả mua nhiều nhất: DG001 - Nguyễn Văn A (VIP) - Hà Nội ✓
- Số tiền: 708,000đ (cao nhất) ✓
- **PASS** - Tính toán chính xác với chiết khấu

---

## Tổng kết

### Kết quả tổng thể
- **Tổng số test cases:** 8
- **Số test PASS:** 8 ✅
- **Số test FAIL:** 0
- **Tỷ lệ thành công:** 100%

### Các lỗi đã được sửa

#### 1. Lỗi validation độc giả (Critical)
- **Vị trí:** `ThemHoaDonMuaSach` dòng 61-67
- **Mức độ:** Nghiêm trọng
- **Ảnh hưởng:** Chỉ độc giả đầu tiên có thể mua hàng
- **Trạng thái:** ✅ Đã sửa

#### 2. Lỗi validation tồn kho và giá (Critical)
- **Vị trí:** `ThemHoaDonMuaSach` dòng 75-84
- **Mức độ:** Nghiêm trọng
- **Ảnh hưởng:** 
  - Có thể bán lỗ khi đủ hàng
  - Không chặn đơn hàng khi hết hàng
- **Trạng thái:** ✅ Đã sửa

### Các phương thức hoạt động tốt

1. ✅ `CapNhatSoLuongTon` - Cập nhật tồn kho chính xác
2. ✅ `TimSachTheoNhaXuatBan` - Tìm kiếm chính xác
3. ✅ `ThongKeDocGiaMuaNhieuNhat` - Tính toán đúng với chiết khấu

### Khuyến nghị

1. **Đã thực hiện:**
   - ✅ Sửa logic validation trong `ThemHoaDonMuaSach`
   - ✅ Thêm comment giải thích logic
   - ✅ Thêm file vào project (.csproj)

2. **Có thể cải tiến thêm:**
   - Thêm logging để trace các thao tác
   - Thêm exception handling cho các trường hợp edge case
   - Thêm unit tests tự động
   - Validate input null/empty

## Kết luận

Tất cả các lỗi logic trong `QuanLyBanSach.cs` đã được phát hiện và sửa chữa thành công. Code hiện hoạt động đúng theo yêu cầu và đã được kiểm thử kỹ lưỡng với nhiều test cases khác nhau.
