# Kết quả Kiểm tra - OOP C# Test Results

## Tóm tắt
✅ **Tất cả 3 đề đã được triển khai và kiểm tra thành công**

## Chi tiết Kết quả

### ĐỀ 0: Quản lý Cửa Hàng (QuanLyCuaHang)

#### Dữ liệu đầu vào:
**Sản phẩm:**
- SP1 (Mã: 1): Bàn phím cơ RK - Giá nhập: 850,000 - Tồn: 10 - NCC: Royal Kludge
- SP2 (Mã: 2): Chuột G Pro - Giá nhập: 1,200,000 - Tồn: 8 - NCC: Logitech
- SP3 (Mã: 3): Tai nghe WH-1000 - Giá nhập: 6,500,000 - Tồn: 3 - NCC: Sony

**Khách hàng:**
- KH001: Nguyễn Văn Út Mới (VIP) - Hà Nội
- KH002: Trần Thị Thanh (Thuong) - Đà Nẵng
- KH003: Lê Văn Tường (Moi) - TP.HCM

**Hóa đơn:**
1. HD1001 (KH001 - 10/11/2025):
   - 2 × Bàn phím @ 950,000 = 1,900,000
   - 1 × Chuột @ 1,350,000 = 1,350,000
   - **Tổng:** 3,250,000
   - **Chiết khấu VIP (10%):** -325,000
   - **Thanh toán:** 2,925,000 ✅

2. HD1002 (KH002 - 12/11/2025):
   - 1 × Tai nghe @ 7,200,000 = 7,200,000
   - **Tổng:** 7,200,000
   - **Chiết khấu Thuong (5%):** -360,000
   - **Thanh toán:** 6,840,000 ✅

3. HD1003 (KH003 - 15/11/2025):
   - 15 × Bàn phím @ 900,000 (yêu cầu)
   - ❌ **BỊ TỪ CHỐI** - Vượt tồn kho (chỉ còn 8, đã bán 2 cho HD1001)

#### ✅ Kết quả: **Trần Thị Thanh** (6,840,000 VND)

---

### ĐỀ 1: Quản lý Nhà Thuốc (QuanLyNhaThuoc)

#### Dữ liệu đầu vào:
**Thuốc:**
- T1 (Mã: 1): Paracetamol - Giá nhập: 50,000 - Tồn: 100 - NSX: Sanofi
- T2 (Mã: 2): Amoxicillin - Giá nhập: 150,000 - Tồn: 50 - NSX: Pfizer
- T3 (Mã: 3): Vitamin C - Giá nhập: 30,000 - Tồn: 200 - NSX: Bayer

**Bệnh nhân:**
- BN001: Nguyễn Văn An (VIP) - Hà Nội
- BN002: Trần Thị Bích (Thuong) - Đà Nẵng
- BN003: Lê Văn Cung (Moi) - TP.HCM

**Đơn thuốc:**
1. DT1001 (BN001 - 10/11/2025):
   - 5 × Paracetamol @ 55,000 = 275,000
   - 2 × Amoxicillin @ 165,000 = 330,000
   - **Tổng:** 605,000
   - **Chiết khấu VIP (10%):** -60,500
   - **Thanh toán:** 544,500 ✅

2. DT1002 (BN002 - 12/11/2025):
   - 10 × Vitamin C @ 33,000 = 330,000
   - **Tổng:** 330,000
   - **Chiết khấu Thuong (5%):** -16,500
   - **Thanh toán:** 313,500 ✅

3. DT1003 (BN003 - 15/11/2025):
   - 150 × Paracetamol @ 50,000 (yêu cầu)
   - ❌ **BỊ TỪ CHỐI** - Vượt tồn kho (chỉ còn 95, đã bán 5 cho DT1001)

#### ✅ Kết quả: **Nguyễn Văn An** (544,500 VND)

---

### ĐỀ 2: Quản lý Nhà Sách (QuanLyNhaSach)

#### Dữ liệu đầu vào:
**Sách:**
- S1 (Mã: 1): Harry Potter - Giá nhập: 150,000 - Tồn: 20 - NXB: Bloomsbury
- S2 (Mã: 2): The Hobbit - Giá nhập: 200,000 - Tồn: 15 - NXB: HarperCollins
- S3 (Mã: 3): 1984 - Giá nhập: 100,000 - Tồn: 30 - NXB: Penguin

**Độc giả:**
- DG001: Nguyễn Văn An (VIP) - Hà Nội
- DG002: Trần Thị Bích (Thuong) - Đà Nẵng
- DG003: Lê Văn Cung (Moi) - TP.HCM

**Hóa đơn mua sách:**
1. HD1001 (DG001 - 10/11/2025):
   - 3 × Harry Potter @ 165,000 = 495,000
   - 1 × The Hobbit @ 220,000 = 220,000
   - **Tổng:** 715,000
   - **Chiết khấu VIP (10%):** -71,500
   - **Thanh toán:** 643,500 ✅

2. HD1002 (DG002 - 12/11/2025):
   - 5 × 1984 @ 110,000 = 550,000
   - **Tổng:** 550,000
   - **Chiết khấu Thuong (5%):** -27,500
   - **Thanh toán:** 522,500 ✅

3. HD1003 (DG003 - 15/11/2025):
   - 25 × Harry Potter @ 150,000 (yêu cầu)
   - ❌ **BỊ TỪ CHỐI** - Vượt tồn kho (chỉ còn 17, đã bán 3 cho HD1001)

#### ✅ Kết quả: **Nguyễn Văn An** (643,500 VND)

---

## Bảng Tổng hợp

| Đề | Lớp quản lý | Phương thức thống kê | Tháng/Năm | Kết quả | Số tiền |
|---|---|---|---|---|---|
| 0 | QuanLyCuaHang | ThongKeKhachHangMuaNhieuNhat | 11/2025 | Trần Thị Thanh | 6,840,000 |
| 1 | QuanLyNhaThuoc | ThongKeBenhNhanChiTieuNhieuNhat | 11/2025 | Nguyễn Văn An | 544,500 |
| 2 | QuanLyNhaSach | ThongKeDocGiaMuaNhieuNhat | 11/2025 | Nguyễn Văn An | 643,500 |

## Kiểm tra Validation

### ✅ Các trường hợp được chấp nhận:
- Khách hàng/Bệnh nhân/Độc giả tồn tại
- Sản phẩm/Thuốc/Sách tồn tại
- Số lượng > 0 và <= tồn kho
- Đơn giá >= giá nhập × 1.1 (lợi nhuận 10%)

### ❌ Các trường hợp bị từ chối:
- HD1003, DT1003, HD1003: Tất cả đều vượt tồn kho
- Khi bị từ chối, tồn kho không thay đổi (transaction atomic)

## Công thức Tính toán

### Tính tiền thanh toán:
```
Tổng tiền chi tiết = Σ (Đơn giá × Số lượng)
Chiết khấu = Tổng tiền chi tiết × % chiết khấu theo loại
Tiền thanh toán = Tổng tiền chi tiết - Chiết khấu
```

### Bảng chiết khấu:
- **VIP**: 10% (0.10)
- **Thuong**: 5% (0.05)
- **Moi**: 0% (0.00)

### Kiểm tra lợi nhuận:
```
Đơn giá tối thiểu = Giá nhập × 1.1
Điều kiện: Đơn giá bán >= Đơn giá tối thiểu
```

## Kỹ thuật Đặc biệt

### 1. Xử lý Floating-Point Precision
Do đặc thù của số thực trong máy tính:
- `50,000 × 1.1 = 55,000.00000000073` (không phải đúng 55,000)
- Giải pháp: So sánh với epsilon = 0.01
- `if (donGia < giaToiThieu - 0.01)` thay vì `if (donGia < giaToiThieu)`

### 2. Tìm Maximum không dùng hàm có sẵn
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

### 3. Dictionary thành List song song
Thay vì:
```csharp
Dictionary<string, double> dict;
foreach (var kvp in dict) // ✗ Không được dùng foreach
```

Sử dụng:
```csharp
List<string> Lst_MaKH = new List<string>();
List<double> Lst_TongTien = new List<double>();
for (int i = 0; i < Lst_MaKH.Count; i++) // ✓ Dùng for
```

---

## Xác nhận Tuân thủ Yêu cầu

✅ **Đã tuân thủ TẤT CẢ các yêu cầu:**
1. ✓ Không sửa đổi classesLib.cs
2. ✓ Dùng chỉ C# cơ bản (không LINQ)
3. ✓ Không dùng Sort(), Max(), Min()
4. ✓ Chỉ dùng vòng lặp for (không foreach)
5. ✓ Đặt tên biến theo tiếng Việt
6. ✓ List dùng prefix Lst_
7. ✓ Dictionary dùng prefix Dict_ (khi cần)
8. ✓ Giữ nguyên tên phương thức theo đề
9. ✓ Triển khai đầy đủ cả 3 đề (0, 1, 2)
10. ✓ Kiểm tra với dữ liệu đã cho

---

**Ngày kiểm tra:** 17/11/2025  
**Trạng thái:** ✅ HOÀN THÀNH VÀ KIỂM TRA THÀNH CÔNG
