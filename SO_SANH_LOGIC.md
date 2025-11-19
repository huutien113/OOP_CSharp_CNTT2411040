# So Sánh Logic: QuanLyNhaSach (solution.cs) vs QuanLyBanSach.cs

## Ngày so sánh
19/11/2024

## Tổng quan
Báo cáo này so sánh chi tiết logic giữa:
- **Class QuanLyNhaSach** trong file `solution.cs` (dòng 352-504) - Implementation chuẩn
- **Class QuanLyBanSach** trong file `QuanLyBanSach.cs` - Implementation có lỗi

Cả hai class đều quản lý cùng domain (bán sách) nhưng có sự khác biệt về:
- Quy ước đặt tên biến
- Cách sử dụng vòng lặp (for vs foreach)
- **Logic xử lý (có lỗi nghiêm trọng trong QuanLyBanSach.cs)**

---

## 1. Constructor - Khởi tạo

### QuanLyNhaSach (solution.cs - dòng 359-368)
```csharp
public QuanLyNhaSach()
{
    Lst_Sach = new List<Sach>();
    Lst_DocGia = new List<DocGia>();
    Lst_HoaDon = new List<HoaDonMuaSach>();
    Dict_chietKhauTheoLoai = new Dictionary<string, double>();
    Dict_chietKhauTheoLoai["VIP"] = 0.10;
    Dict_chietKhauTheoLoai["Thuong"] = 0.05;
    Dict_chietKhauTheoLoai["Moi"] = 0.0;
}
```

### QuanLyBanSach (dòng 18-29)
```csharp
public QuanLyBanSach()
{
    danhSachSach = new List<Sach>();
    danhSachDocGia = new List<DocGia>();
    danhSachHoaDon = new List<HoaDonMuaSach>();
    chietkhautheoloai = new Dictionary<string, double>()
    {
        {"VIP", 0.2 },
        {"Thuong", 0.1 },
        {"Moi", 0.0 }
    };
}
```

### So sánh:
| Khía cạnh | QuanLyNhaSach | QuanLyBanSach | Giống nhau? |
|-----------|---------------|---------------|-------------|
| Khởi tạo danh sách | ✅ Giống nhau | ✅ Giống nhau | ✅ CÓ |
| Quy ước tên biến | `Lst_`, `Dict_` prefix | camelCase | ❌ KHÁC |
| Chiết khấu VIP | 0.10 (10%) | 0.2 (20%) | ❌ KHÁC |
| Chiết khấu Thuong | 0.05 (5%) | 0.1 (10%) | ❌ KHÁC |
| Chiết khấu Moi | 0.0 | 0.0 | ✅ GIỐNG |

**Kết luận:** Logic khởi tạo giống nhau, nhưng **tỷ lệ chiết khấu khác nhau** (QuanLyBanSach cao gấp đôi)

---

## 2. ThemSach / ThemDocGia - Thêm dữ liệu

### QuanLyNhaSach (dòng 370-380)
```csharp
public void ThemSach(Sach Sach)
{
    Lst_Sach.Add(Sach);
}

public void ThemDocGia(DocGia DocGia)
{
    Lst_DocGia.Add(DocGia);
}
```

### QuanLyBanSach (không có trong file)
```csharp
// Không có phương thức ThemSach và ThemDocGia
// Phải thêm trực tiếp vào danh sách từ bên ngoài
```

**Kết luận:** QuanLyBanSach **THIẾU** các phương thức thêm dữ liệu cơ bản

---

## 3. CapNhatSoLuongTon - Cập nhật tồn kho

### QuanLyNhaSach (dòng 382-393)
```csharp
public void CapNhatSoLuongTon(int maSach, int soLuongNhapThem)
{
    for (int i = 0; i < Lst_Sach.Count; i++)
    {
        if (Lst_Sach[i].MaSach == maSach)
        {
            Lst_Sach[i].SoLuongTon += soLuongNhapThem;
            break;
        }
    }
}
```

### QuanLyBanSach (dòng 30-43)
```csharp
public void CapNhatSoLuongTon(int maSach, int soLuongNhapThem)
{
    foreach (var sach in danhSachSach)
    {
        if (sach.MaSach == maSach)
        {
            sach.SoLuongTon += soLuongNhapThem;
            break;
        }
    }
    return;
}
```

### So sánh:
| Khía cạnh | QuanLyNhaSach | QuanLyBanSach | Giống nhau? |
|-----------|---------------|---------------|-------------|
| Logic cập nhật | Tìm và cập nhật | Tìm và cập nhật | ✅ GIỐNG |
| Dùng vòng lặp | `for` | `foreach` | ❌ KHÁC (cú pháp) |
| Break khi tìm thấy | ✅ Có | ✅ Có | ✅ GIỐNG |
| Return thừa | Không | Có `return;` | ❌ KHÁC (không ảnh hưởng) |

**Kết luận:** Logic **GIỐNG NHAU**, chỉ khác cú pháp vòng lặp

---

## 4. TimKiem - Tìm kiếm theo nhà xuất bản

### QuanLyNhaSach (dòng 395-407)
```csharp
public List<Sach> TimKiemSachTheoNhaXuatBan(string nhaXuatBan)
{
    List<Sach> Lst_KetQua = new List<Sach>();
    for (int i = 0; i < Lst_Sach.Count; i++)
    {
        if (string.Equals(Lst_Sach[i].NhaXuatBan, nhaXuatBan, 
            StringComparison.OrdinalIgnoreCase))
        {
            Lst_KetQua.Add(Lst_Sach[i]);
        }
    }
    return Lst_KetQua;
}
```

### QuanLyBanSach (dòng 44-56)
```csharp
public List<Sach> TimSachTheoNhaXuatBan(string nhaXuatBan)
{
    List<Sach> ketqua = new List<Sach>();
    foreach (var sach in danhSachSach)
    {
        if (sach.NhaXuatBan == nhaXuatBan)
        {
            ketqua.Add(sach);
        }
    }
    return ketqua;
}
```

### So sánh:
| Khía cạnh | QuanLyNhaSach | QuanLyBanSach | Giống nhau? |
|-----------|---------------|---------------|-------------|
| Logic tìm kiếm | Duyệt và lọc | Duyệt và lọc | ✅ GIỐNG |
| Vòng lặp | `for` | `foreach` | ❌ KHÁC (cú pháp) |
| So sánh chuỗi | `StringComparison.OrdinalIgnoreCase` | `==` | ❌ **KHÁC QUAN TRỌNG** |
| Case-sensitive | Không phân biệt hoa/thường | Phân biệt hoa/thường | ❌ **KHÁC** |

**Kết luận:** Logic tương tự nhưng **QuanLyBanSach thiếu xử lý không phân biệt hoa/thường**, có thể bỏ sót kết quả

---

## 5. ThemHoaDonMuaSach - Thêm hóa đơn (PHẦN QUAN TRỌNG NHẤT)

### 5.1. Kiểm tra độc giả tồn tại

#### QuanLyNhaSach (dòng 410-422) - ĐÚNG ✅
```csharp
// Kiểm tra mã độc giả tồn tại
bool KT_DocGiaTonTai = false;
for (int i = 0; i < Lst_DocGia.Count; i++)
{
    if (Lst_DocGia[i].MaDG == hd.MaDG)
    {
        KT_DocGiaTonTai = true;
        break;
    }
}
if (!KT_DocGiaTonTai) return false;
```

#### QuanLyBanSach (dòng 61-67) - SAI ❌
```csharp
foreach (var dg in danhSachDocGia)
{
    if (dg.MaDG != hd.MaDG)
    { return false; }
}
```

#### Phân tích lỗi:

**QuanLyNhaSach (ĐÚNG):**
1. Duyệt toàn bộ danh sách
2. Nếu tìm thấy MaDG trùng khớp → đánh dấu `KT_DocGiaTonTai = true` và break
3. Sau vòng lặp, kiểm tra biến cờ
4. Nếu không tìm thấy → return false

**QuanLyBanSach (SAI):**
1. Duyệt danh sách
2. **Nếu gặp MaDG KHÁC → return false ngay lập tức**
3. ❌ **Lỗi logic nghiêm trọng:** Chỉ độc giả đầu tiên mới có thể mua hàng!

**Ví dụ minh họa:**
```
Danh sách độc giả: [DG001, DG002, DG003]
Hóa đơn có MaDG = DG002

QuanLyNhaSach:
- Lần 1: DG001 != DG002 → tiếp tục
- Lần 2: DG002 == DG002 → KT_DocGiaTonTai = true, break
- Kết quả: Hợp lệ ✅

QuanLyBanSach:
- Lần 1: DG001 != DG002 → return false ngay lập tức ❌
- Không bao giờ kiểm tra DG002
- Kết quả: Từ chối sai!
```

**Kết luận:** Logic **HOÀN TOÀN KHÁC NHAU** và QuanLyBanSach có **LỖI NGHIÊM TRỌNG**

---

### 5.2. Kiểm tra chi tiết hóa đơn

#### QuanLyNhaSach (dòng 424-442) - ĐÚNG ✅
```csharp
for (int i = 0; i < hd.ChiTiet.Count; i++)
{
    ChiTietHoaDonMuaSach ChiTiet = hd.ChiTiet[i];
    // Tìm sách theo mã
    Sach Sach = null;
    for (int j = 0; j < Lst_Sach.Count; j++)
    {
        if (Lst_Sach[j].MaSach == ChiTiet.MaSach)
        {
            Sach = Lst_Sach[j];
            break;
        }
    }
    if (Sach == null) return false;                      // Kiểm tra 1
    if (ChiTiet.SoLuong <= 0) return false;              // Kiểm tra 2
    if (ChiTiet.SoLuong > Sach.SoLuongTon) return false; // Kiểm tra 3
    double GiaBanToiThieu = Sach.GiaNhap * 1.1;
    if (ChiTiet.DonGia < GiaBanToiThieu) return false;   // Kiểm tra 4
}
```

#### QuanLyBanSach (dòng 69-87) - SAI ❌
```csharp
foreach (var chiTiet in hd.ChiTiet)
{
    foreach(var sach in danhSachSach)
    {
        if (sach.MaSach == chiTiet.MaSach)
        {
            if (sach.SoLuongTon < chiTiet.SoLuong || chiTiet.SoLuong <= 0)
            {
                if (chiTiet.DonGia < (sach.GiaNhap * 1.1))
                {
                    return false;
                }
            }
        }
    }
}
```

#### Phân tích chi tiết:

**QuanLyNhaSach - Cấu trúc kiểm tra (ĐÚNG):**
```
BƯỚC 1: Tìm sách trong danh sách
BƯỚC 2: Kiểm tra sách có tồn tại không? → Không → return false
BƯỚC 3: Kiểm tra số lượng > 0? → Không → return false
BƯỚC 4: Kiểm tra đủ tồn kho? → Không → return false
BƯỚC 5: Kiểm tra giá bán đủ cao? → Không → return false
BƯỚC 6: Nếu tất cả OK → tiếp tục chi tiết tiếp theo
```

**QuanLyBanSach - Cấu trúc kiểm tra (SAI):**
```
BƯỚC 1: Tìm sách trong danh sách
BƯỚC 2: NẾU (không đủ hàng HOẶC số lượng <= 0)
        THÌ {
            NẾU (giá thấp)
            THÌ return false
        }
❌ Vấn đề: Chỉ kiểm tra giá KHI không đủ hàng!
```

#### Bảng so sánh các trường hợp:

| Tình huống | Đủ hàng | Số lượng | Giá | QuanLyNhaSach | QuanLyBanSach | Đúng? |
|------------|---------|----------|-----|---------------|---------------|-------|
| 1 | ✅ Đủ | ✅ > 0 | ✅ Cao | Chấp nhận | Chấp nhận | ✅ Cả 2 đúng |
| 2 | ✅ Đủ | ✅ > 0 | ❌ Thấp | **Từ chối** | **Chấp nhận** | ❌ QuanLyBanSach sai! |
| 3 | ❌ Không đủ | ✅ > 0 | ✅ Cao | **Từ chối** | **Chấp nhận** | ❌ QuanLyBanSach sai! |
| 4 | ❌ Không đủ | ✅ > 0 | ❌ Thấp | Từ chối | Từ chối | ✅ Cả 2 đúng |
| 5 | ✅ Đủ | ❌ <= 0 | Bất kỳ | Từ chối | Từ chối | ✅ Cả 2 đúng |

**Các lỗi cụ thể:**

**Lỗi 1 - Bán lỗ (Tình huống 2):**
```
Sách giá nhập: 100,000 VNĐ
Giá bán tối thiểu: 110,000 VNĐ
Tồn kho: 50 cuốn
Đơn hàng: 10 cuốn, giá 105,000 VNĐ

QuanLyNhaSach: Từ chối (giá thấp hơn 110,000) ✅
QuanLyBanSach: Chấp nhận (có đủ hàng nên không kiểm tra giá) ❌
→ Kết quả: Bán lỗ 50,000 VNĐ!
```

**Lỗi 2 - Bán khi không đủ hàng (Tình huống 3):**
```
Sách giá nhập: 100,000 VNĐ
Tồn kho: 5 cuốn
Đơn hàng: 10 cuốn, giá 150,000 VNĐ (giá cao)

QuanLyNhaSach: Từ chối (không đủ tồn kho) ✅
QuanLyBanSach: Vào if đầu (không đủ hàng)
                Nhưng giá cao (150k > 110k) 
                Không return false
                Chấp nhận đơn hàng ❌
→ Kết quả: Bán 10 cuốn khi chỉ có 5!
```

**Lỗi 3 - Không kiểm tra sách có tồn tại:**
```
QuanLyNhaSach: Kiểm tra if (Sach == null) return false; ✅
QuanLyBanSach: Không có kiểm tra này ❌
→ Nếu mã sách không tồn tại, vòng lặp kết thúc mà không return false
```

**Kết luận:** Logic **HOÀN TOÀN SAI** trong QuanLyBanSach với 3 lỗi nghiêm trọng:
1. ❌ Cho phép bán lỗ (không kiểm tra giá khi đủ hàng)
2. ❌ Cho phép bán vượt tồn kho (không return false khi không đủ hàng nhưng giá cao)
3. ❌ Không kiểm tra sách có tồn tại trong danh sách

---

### 5.3. Cập nhật tồn kho sau khi kiểm tra

#### QuanLyNhaSach (dòng 444-455) - ĐÚNG ✅
```csharp
// Nếu hợp lệ → cập nhật tồn kho và thêm hóa đơn
for (int i = 0; i < hd.ChiTiet.Count; i++)
{
    ChiTietHoaDonMuaSach ChiTiet = hd.ChiTiet[i];
    for (int j = 0; j < Lst_Sach.Count; j++)
    {
        if (Lst_Sach[j].MaSach == ChiTiet.MaSach)
        {
            Lst_Sach[j].SoLuongTon -= ChiTiet.SoLuong;
            break;
        }
    }
}
Lst_HoaDon.Add(hd);
return true;
```

#### QuanLyBanSach (dòng 89-100)
```csharp
foreach (var chiTiet in hd.ChiTiet)
{
    foreach(var sach in danhSachSach)
    {
        if (sach.MaSach == chiTiet.MaSach)
        {
            sach.SoLuongTon -= chiTiet.SoLuong;
        }
    }
}
danhSachHoaDon.Add(hd);
return true;
```

**Kết luận:** Logic cập nhật tồn kho **GIỐNG NHAU**, chỉ khác cú pháp vòng lặp. Tuy nhiên do logic kiểm tra ở trên sai nên phần này cũng thực thi sai.

---

## 6. ThongKeDocGiaMuaNhieuNhat - Thống kê

### QuanLyNhaSach (dòng 461-503) - ĐÚNG ✅
```csharp
public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
{
    double TongTienMax = 0;
    DocGia DocGiaMax = null;
    for (int i = 0; i < Lst_DocGia.Count; i++)
    {
        DocGia DG = Lst_DocGia[i];
        double TongTienDocGia = 0;
        for (int j = 0; j < Lst_HoaDon.Count; j++)
        {
            HoaDonMuaSach HD = Lst_HoaDon[j];
            if (HD.MaDG == DG.MaDG && HD.NgayMua.Month == thang && HD.NgayMua.Year == nam)
            {
                double TongChiTiet = 0;
                for (int k = 0; k < HD.ChiTiet.Count; k++)
                {
                    TongChiTiet += HD.ChiTiet[k].DonGia * HD.ChiTiet[k].SoLuong;
                }
                // Xác định loại độc giả và chiết khấu
                string loaiDG = DG.LoaiDG;
                double chietKhau = 0;
                List<string> Lst_Key = new List<string>(Dict_chietKhauTheoLoai.Keys);
                for (int x = 0; x < Lst_Key.Count; x++)
                {
                    string key = Lst_Key[x];
                    if (key == loaiDG)
                    {
                        chietKhau = Dict_chietKhauTheoLoai[key];
                        break;
                    }
                }
                double TienThucTe = TongChiTiet * (1 - chietKhau);
                TongTienDocGia += TienThucTe;
            }
        }
        if (TongTienDocGia > TongTienMax)
        {
            TongTienMax = TongTienDocGia;
            DocGiaMax = DG;
        }
    }
    return DocGiaMax;
}
```

### QuanLyBanSach (dòng 103-156)
```csharp
public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
{
    double maxThanhToan = 0;
    DocGia docGiaMuaNhieuNhat = null;

    foreach (var hd in danhSachHoaDon)
    {
        if (hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
        {
            double tongTienChiTiet = 0;
            foreach (var chiTiet in hd.ChiTiet)
            {
                tongTienChiTiet += chiTiet.DonGia * chiTiet.SoLuong;
            }

            DocGia docGia = null;
            foreach (var dg in danhSachDocGia)
            {
                if (dg.MaDG == hd.MaDG)
                {
                    docGia = dg;
                    break;
                }
            }

            if (docGia == null)
                continue;

            double chietKhau = 0;
            if (chietkhautheoloai.ContainsKey(docGia.LoaiDG))
            {
                chietKhau = chietkhautheoloai[docGia.LoaiDG];
            }

            double tienThanhToanThucTe = tongTienChiTiet * (1 - chietKhau);

            if (tienThanhToanThucTe > maxThanhToan)
            {
                maxThanhToan = tienThanhToanThucTe;
                docGiaMuaNhieuNhat = docGia;
            }
        }
    }

    return docGiaMuaNhieuNhat;
}
```

### So sánh:

| Khía cạnh | QuanLyNhaSach | QuanLyBanSach | Giống nhau? |
|-----------|---------------|---------------|-------------|
| Thuật toán tổng thể | Duyệt độc giả → tìm hóa đơn | Duyệt hóa đơn → tìm độc giả | ❌ **NGƯỢC CHIỀU** |
| Lọc theo tháng/năm | ✅ Có | ✅ Có | ✅ GIỐNG |
| Tính tổng chi tiết | ✅ Đúng | ✅ Đúng | ✅ GIỐNG |
| Áp dụng chiết khấu | ✅ Đúng | ✅ Đúng | ✅ GIỐNG |
| Vòng lặp | `for` | `foreach` | ❌ KHÁC (cú pháp) |
| Tỷ lệ chiết khấu | VIP:10%, Thuong:5% | VIP:20%, Thuong:10% | ❌ **KHÁC GIÁ TRỊ** |

**Phân tích khác biệt về thuật toán:**

**QuanLyNhaSach - Duyệt theo độc giả:**
```
FOR mỗi độc giả
    FOR mỗi hóa đơn
        IF hóa đơn của độc giả này AND đúng tháng/năm
            Tính tiền
    So sánh tổng với max
```

**QuanLyBanSach - Duyệt theo hóa đơn:**
```
FOR mỗi hóa đơn
    IF đúng tháng/năm
        Tìm độc giả tương ứng
        Tính tiền
        So sánh với max (CHỈ CẬP NHẬT LẦN CUỐI)
```

**Vấn đề tiềm ẩn trong QuanLyBanSach:**
- Nếu một độc giả có nhiều hóa đơn trong tháng, mỗi hóa đơn sẽ được xử lý riêng
- Biến `docGiaMuaNhieuNhat` sẽ bị ghi đè nhiều lần cho cùng một độc giả
- **Kết quả cuối cùng vẫn đúng** vì logic cộng dồn, nhưng **không tối ưu về hiệu năng**

**Ví dụ minh họa:**
```
Độc giả DG001 có 3 hóa đơn trong tháng 11:
- HD001: 100,000 VNĐ
- HD002: 200,000 VNĐ  
- HD003: 150,000 VNĐ

QuanLyNhaSach:
- Duyệt DG001 → tìm 3 hóa đơn → tổng = 450,000 → so sánh 1 lần

QuanLyBanSach:
- Duyệt HD001 → tìm DG001 → tổng = 100,000 → so sánh
- Duyệt HD002 → tìm DG001 → tổng = 200,000 → so sánh
- Duyệt HD003 → tìm DG001 → tổng = 150,000 → so sánh
❌ Vấn đề: Tổng KHÔNG được cộng dồn! Chỉ lấy hóa đơn có giá trị cao nhất!
```

**⚠️ LỖI NGHIÊM TRỌNG PHÁ HIỆN MỚI:**
QuanLyBanSach **KHÔNG cộng dồn** tổng tiền của cùng một độc giả! 
- Nó chỉ so sánh từng hóa đơn riêng lẻ
- Kết quả: Trả về độc giả có **HÓA ĐƠN LỚN NHẤT** chứ không phải **TỔNG TIỀN LỚN NHẤT**

**Kết luận:** Logic **SAI CƠ BẢN** - QuanLyBanSach không tính đúng yêu cầu "độc giả mua nhiều nhất"

---

## TỔNG KẾT SO SÁNH

### Bảng tổng hợp sự khác biệt:

| Phương thức | Logic giống nhau? | Lỗi trong QuanLyBanSach |
|-------------|-------------------|-------------------------|
| **Constructor** | ❌ Khác tỷ lệ chiết khấu | Tỷ lệ cao gấp đôi (20% vs 10%) |
| **ThemSach/ThemDocGia** | - | ❌ Thiếu hoàn toàn |
| **CapNhatSoLuongTon** | ✅ Giống | Không có lỗi |
| **TimKiem** | ⚠️ Gần giống | ❌ Không xử lý case-insensitive |
| **ThemHoaDonMuaSach** | ❌ Hoàn toàn khác | ❌❌❌ 3 lỗi nghiêm trọng |
| **ThongKe** | ⚠️ Gần giống | ❌ Không cộng dồn đúng |

### Các lỗi nghiêm trọng trong QuanLyBanSach:

#### 🔴 Lỗi cấp độ CRITICAL:

1. **Lỗi kiểm tra độc giả tồn tại** (ThemHoaDonMuaSach)
   - Chỉ độc giả đầu tiên có thể mua hàng
   - Tất cả độc giả khác bị từ chối

2. **Lỗi logic kiểm tra hóa đơn** (ThemHoaDonMuaSach)
   - Cho phép bán lỗ (không kiểm tra giá khi đủ hàng)
   - Cho phép bán vượt tồn kho (không return false đúng cách)
   - Không kiểm tra sách có tồn tại

3. **Lỗi thống kê sai** (ThongKe)
   - Không cộng dồn tổng tiền của cùng độc giả
   - Trả về độc giả có hóa đơn lớn nhất thay vì tổng lớn nhất

#### 🟡 Lỗi cấp độ WARNING:

4. **Tỷ lệ chiết khấu khác** (Constructor)
   - Cao gấp đôi so với chuẩn (20% vs 10% cho VIP)

5. **Tìm kiếm case-sensitive** (TimKiem)
   - Có thể bỏ sót kết quả khi nhập khác hoa/thường

6. **Thiếu phương thức thêm dữ liệu**
   - Không có ThemSach() và ThemDocGia()

### So sánh về coding style:

| Khía cạnh | QuanLyNhaSach | QuanLyBanSach |
|-----------|---------------|---------------|
| Vòng lặp | `for` với index | `foreach` |
| Quy ước tên | `Lst_`, `Dict_` prefix | camelCase |
| Comment | Có comment chi tiết | Không có comment |
| Tuân thủ yêu cầu | ✅ Đúng quy định (không dùng foreach) | ❌ Vi phạm (dùng foreach) |

### Kết luận cuối cùng:

**❌ KHÔNG GIỐNG NHAU**

Hai class **KHÔNG giống nhau về logic**. Cụ thể:

✅ **Giống nhau (1/6 phương thức):**
- CapNhatSoLuongTon: Logic hoàn toàn giống nhau

⚠️ **Gần giống (2/6 phương thức):**
- TimKiem: Giống ý tưởng nhưng thiếu xử lý case-insensitive
- ThongKe: Giống ý tưởng nhưng logic tính toán sai

❌ **Hoàn toàn khác (3/6 phương thức):**
- Constructor: Tỷ lệ chiết khấu khác
- ThemSach/ThemDocGia: QuanLyBanSach thiếu hoàn toàn
- ThemHoaDonMuaSach: Logic sai hoàn toàn với 3 lỗi nghiêm trọng

**QuanLyBanSach.cs có quá nhiều lỗi logic nghiêm trọng, không thể sử dụng được trong thực tế.**

### Khuyến nghị:

1. ✅ Sử dụng **QuanLyNhaSach** trong solution.cs làm tham chiếu chuẩn
2. ❌ **KHÔNG sử dụng** QuanLyBanSach.cs - cần viết lại hoàn toàn
3. 🔧 Nếu muốn sửa QuanLyBanSach, cần sửa tối thiểu 6 vấn đề đã nêu trên
4. 📚 Học từ solution.cs về cách kiểm tra điều kiện đúng đắn và xử lý logic phức tạp

---

## Phụ lục: Code sửa lỗi cho QuanLyBanSach

Nếu muốn sửa QuanLyBanSach để có logic giống QuanLyNhaSach, cần sửa như sau:

### 1. Sửa kiểm tra độc giả tồn tại:
```csharp
// SAI - Phiên bản hiện tại
foreach (var dg in danhSachDocGia)
{
    if (dg.MaDG != hd.MaDG)
    { return false; }
}

// ĐÚNG - Phiên bản sửa
bool docGiaTonTai = false;
foreach (var dg in danhSachDocGia)
{
    if (dg.MaDG == hd.MaDG)
    {
        docGiaTonTai = true;
        break;
    }
}
if (!docGiaTonTai) return false;
```

### 2. Sửa kiểm tra chi tiết hóa đơn:
```csharp
// SAI - Phiên bản hiện tại
foreach (var chiTiet in hd.ChiTiet)
{
    foreach(var sach in danhSachSach)
    {
        if (sach.MaSach == chiTiet.MaSach)
        {
            if (sach.SoLuongTon < chiTiet.SoLuong || chiTiet.SoLuong <= 0)
            {
                if (chiTiet.DonGia < (sach.GiaNhap * 1.1))
                {
                    return false;
                }
            }
        }
    }
}

// ĐÚNG - Phiên bản sửa
foreach (var chiTiet in hd.ChiTiet)
{
    // Tìm sách
    Sach sach = null;
    foreach(var s in danhSachSach)
    {
        if (s.MaSach == chiTiet.MaSach)
        {
            sach = s;
            break;
        }
    }
    
    // Kiểm tra sách tồn tại
    if (sach == null) return false;
    
    // Kiểm tra số lượng hợp lệ
    if (chiTiet.SoLuong <= 0) return false;
    
    // Kiểm tra đủ tồn kho
    if (chiTiet.SoLuong > sach.SoLuongTon) return false;
    
    // Kiểm tra giá bán
    double giaBanToiThieu = sach.GiaNhap * 1.1;
    if (chiTiet.DonGia < giaBanToiThieu) return false;
}
```

### 3. Sửa thuật toán thống kê:
```csharp
// SAI - Duyệt theo hóa đơn
foreach (var hd in danhSachHoaDon)
{
    if (hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
    {
        // Tính tiền cho từng hóa đơn riêng lẻ
        // Không cộng dồn cho cùng độc giả
    }
}

// ĐÚNG - Duyệt theo độc giả
foreach (var dg in danhSachDocGia)
{
    double tongTienDocGia = 0;
    foreach (var hd in danhSachHoaDon)
    {
        if (hd.MaDG == dg.MaDG && hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
        {
            // Cộng dồn tất cả hóa đơn của độc giả này
            tongTienDocGia += /* tính tiền hóa đơn */;
        }
    }
    // So sánh tổng với max
}
```

---

**Người thực hiện:** GitHub Copilot Agent  
**Ngày:** 19/11/2024  
**Kết luận:** QuanLyNhaSach (solution.cs) và QuanLyBanSach.cs **KHÔNG giống nhau về logic**, có nhiều lỗi nghiêm trọng trong QuanLyBanSach.cs
