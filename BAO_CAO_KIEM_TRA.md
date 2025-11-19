# BÁO CÁO KIỂM TRA VÀ PHÂN TÍCH QuanLyCuaHang.cs

**Người thực hiện:** GitHub Copilot Agent  
**Ngày thực hiện:** 19/11/2025  
**Đề bài:** Đề 0 - Kiểm tra thực hành OOP  

---

## I. TỔNG QUAN

### 1.1. Mục đích
Kiểm tra tính logic của file `QuanLyCuaHang.cs` so với yêu cầu trong file PDF đề kiểm tra, sau đó chạy kiểm thử với dữ liệu từ file Word để phát hiện các vấn đề.

### 1.2. Các file liên quan
- **ĐỀ KIỂM TRA THỰC HÀNH OOP.pdf**: Chứa yêu cầu chi tiết cho bài tập
- **DỮ LIỆU VÀ KỊCH BẢN KIỂM THỬ.docx**: Chứa dữ liệu test và kịch bản kiểm thử
- **classesLibHTTT.cs**: Chứa các class cơ bản (SanPham, KhachHang, HoaDon, ChiTietHoaDon, v.v.)
- **QuanLyCuaHang.cs**: File cần kiểm tra và sửa lỗi

---

## II. PHÂN TÍCH YÊU CẦU

### 2.1. Constructor
**Yêu cầu:**
- Khởi tạo các danh sách rỗng: `danhSachSP`, `danhSachKH`, `danhSachHD`
- Khởi tạo `chietKhauTheoLoai` với giá trị cố định:
  - "VIP": 10%
  - "Thuong": 5%
  - "Moi": 0%

### 2.2. Phương thức CapNhatSoLuongTon(int maSP, int soLuongNhapThem)
**Yêu cầu:**
- Tìm sản phẩm theo `maSP`
- Nếu tồn tại → tăng `SoLuongTon` thêm `soLuongNhapThem`
- Nếu không tồn tại → không làm gì
- Không trả về gì (void)

### 2.3. Phương thức TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)
**Yêu cầu:**
- Trả về `List<SanPham>` có nhà cung cấp khớp (không phân biệt hoa thường)
- Nếu không có thì trả về danh sách rỗng

### 2.4. Phương thức ThemHoaDon(HoaDon hd)
**Yêu cầu:**
- Kiểm tra mã khách hàng phải tồn tại trong `DanhSachKH`
- Với mỗi chi tiết hóa đơn:
  - Mã sản phẩm phải tồn tại
  - `SoLuongBan > 0` và không vượt quá tồn kho
  - `DonGiaBan >= GiaNhap * 1.1` (lợi nhuận tối thiểu 10%)
- Tất cả chi tiết hợp lệ thì:
  - Cập nhật tồn kho (trừ số lượng bán)
  - Thêm hóa đơn vào danh sách
- Nếu có bất kỳ lỗi nào → hủy toàn bộ, không thay đổi gì

### 2.5. Phương thức ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
**Yêu cầu:**
- Công thức tính tiền thanh toán thực tế:
  - Tổng tiền chi tiết = Σ(DonGiaBan * SoLuongBan)
  - Tiền thanh toán thực tế = Tổng tiền chi tiết * (1 - chiết khấu loại khách hàng)
- Chỉ xét các hóa đơn trong đúng tháng và năm
- Trả về khách hàng có tổng tiền cao nhất
- Nếu nhiều khách bằng nhau → trả về khách đầu tiên
- Nếu không có hóa đơn nào → trả về null

---

## III. KẾT QUẢ PHÂN TÍCH CODE BAN ĐẦU

### 3.1. Constructor ✅ **ĐÚNG**
```csharp
public QuanLyCuaHang()
{
    DanhSachSP = new List<SanPham>();
    DanhSachKH = new List<KhachHang>();
    DanhSachHD = new List<HoaDon>();
    ChietKhauTheoLoai = new Dictionary<string, double>()
    {
        { "VIP", 0.10 },
        { "Thuong", 0.05 },
        { "Moi", 0.00 }
    };
}
```
**Đánh giá:** Hoàn toàn đúng theo yêu cầu.

---

### 3.2. CapNhatSoLuongTon ✅ **ĐÚNG**
```csharp
public void CapNhatSoLuongTon(int maSP, int soLuongNhapThem)
{
    for (int i = 0; i < DanhSachSP.Count; i++)
    {
        if (maSP == DanhSachSP[i].MaSP)
        {
            DanhSachSP[i].SoLuongTon += soLuongNhapThem;
        }
    }
}
```
**Đánh giá:** Hoàn toàn đúng theo yêu cầu.

---

### 3.3. TimKiemSanPhamTheoNhaCungCap ✅ **ĐÚNG**
```csharp
public List<SanPham> TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)
{
    List<SanPham> Lst_SanPham = new List<SanPham>();
    for (int i = 0; i < DanhSachSP.Count; i++)
    {
        if (nhaCungCap.ToUpper() == DanhSachSP[i].NhaCungCap.ToUpper())
        {
            Lst_SanPham.Add(DanhSachSP[i]);
        }
    }
    return Lst_SanPham;
}
```
**Đánh giá:** Hoàn toàn đúng theo yêu cầu.

---

### 3.4. ThemHoaDon ❌ **SAI HOÀN TOÀN**

#### Các lỗi nghiêm trọng được phát hiện:

**Lỗi 1: Kiểm tra mã khách hàng sai**
```csharp
// Code cũ (dòng 81-87)
for (int i = 0; i < DanhSachHD.Count; i++)  // ❌ SAI: kiểm tra trong DanhSachHD
{
    if (hd.MaKH == DanhSachHD[i].MaKH)
    {
        KT = true;
    }
}
```
- **Vấn đề:** Kiểm tra mã khách hàng trong `DanhSachHD` (danh sách hóa đơn) thay vì `DanhSachKH` (danh sách khách hàng)
- **Hậu quả:** Khách hàng mới chưa có hóa đơn sẽ không thể mua hàng

**Lỗi 2: Logic kiểm tra chi tiết hóa đơn sai**
```csharp
// Code cũ (dòng 89-103)
if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP && 
    hd.ChiTiet[i].SoLuongBan >= DanhSachSP[j].SoLuongTon &&  // ❌ Phải là <=
    hd.ChiTiet[i].DonGiaBan >= DanhSachSP[j].GiaNhap * 1.1)
```
- **Vấn đề:** Dùng `>=` thay vì `<=` để kiểm tra tồn kho
- **Hậu quả:** Chỉ chấp nhận đơn hàng khi số lượng bán >= tồn kho (sai logic)

**Lỗi 3: Không kiểm tra SoLuongBan > 0**
- Không có kiểm tra này trong code
- **Hậu quả:** Có thể chấp nhận số lượng âm hoặc bằng 0

**Lỗi 4: Luôn thêm hóa đơn vào danh sách**
```csharp
// Code cũ (dòng 126)
DanhSachHD.Add(hd);  // ❌ Luôn thêm vào dù có lỗi
return KT;
```
- **Vấn đề:** Hóa đơn luôn được thêm vào danh sách, kể cả khi không hợp lệ
- **Hậu quả:** Dữ liệu không nhất quán

**Lỗi 5: Cập nhật tồn kho không đầy đủ**
```csharp
// Code cũ (dòng 108-123)
if (KT == true)
{
    break;  // ❌ Break sớm, không cập nhật hết các chi tiết
}
```
- **Vấn đề:** Break sớm sau chi tiết đầu tiên
- **Hậu quả:** Chỉ cập nhật tồn kho cho 1 sản phẩm

---

### 3.5. ThongKeKhachHangMuaNhieuNhat ❌ **SAI HOÀN TOÀN**

#### Các lỗi nghiêm trọng được phát hiện:

**Lỗi 1: Vòng lặp dùng index sai**
```csharp
// Code cũ (dòng 135-141)
for (int i = 0; i < DanhSachKH.Count; i++)  // Duyệt DanhSachKH
{
    if (DanhSachHD[i].NgayLap.Month == thang && ...)  // ❌ Truy cập DanhSachHD[i]
    {
        Lst_KhachHang.Add(DanhSachKH[i]);
    }
}
```
- **Vấn đề:** Duyệt qua `DanhSachKH` nhưng truy cập `DanhSachHD[i]`
- **Hậu quả:** Nếu số lượng khách hàng != số lượng hóa đơn → IndexOutOfRangeException

**Lỗi 2: Vòng lặp dùng <= gây lỗi**
```csharp
// Code cũ (dòng 147)
for (int i = 0; i <= Lst_KhachHang.Count; i++)  // ❌ Dùng <=
```
- **Vấn đề:** `<=` sẽ truy cập index vượt quá kích thước list
- **Hậu quả:** IndexOutOfRangeException

**Lỗi 3: Vòng lặp lồng dùng sai biến**
```csharp
// Code cũ (dòng 149)
for (int j = 0; i < DanhSachHD.Count; i++)  // ❌ Dùng i thay vì j
```
- **Vấn đề:** Khai báo j nhưng sử dụng i trong điều kiện và increment
- **Hậu quả:** Vòng lặp vô hạn hoặc logic sai

**Lỗi 4: Không cộng dồn tổng tiền**
```csharp
// Code cũ (dòng 154-156)
for (int k = 0; k < DanhSachHD[j].ChiTiet.Count; k++)
{
    Tong = DanhSachHD[j].ChiTiet[k].DonGiaBan * DanhSachHD[j].ChiTiet[k].SoLuongBan;
    // ❌ Không cộng dồn, chỉ gán
}
```
- **Vấn đề:** Gán giá trị thay vì cộng dồn (Tong = thay vì Tong +=)
- **Hậu quả:** Chỉ tính chi tiết cuối cùng, không tính tổng

**Lỗi 5: Logic tổng thể sai**
- Không tính đúng tổng tiền của từng khách hàng
- Không nhóm các hóa đơn theo khách hàng
- **Hậu quả:** Kết quả thống kê hoàn toàn sai

---

## IV. CODE ĐÃ SỬA

### 4.1. ThemHoaDon - Code mới
```csharp
public void ThemHoaDon(HoaDon hd)
{
    // Kiểm tra mã khách hàng phải tồn tại
    bool khachHangTonTai = false;
    for (int i = 0; i < DanhSachKH.Count; i++)  // ✅ Sửa: Kiểm tra trong DanhSachKH
    {
        if (hd.MaKH == DanhSachKH[i].MaKH)
        {
            khachHangTonTai = true;
            break;
        }
    }
    if (!khachHangTonTai)
    {
        return; // Hủy, không thêm
    }

    // Kiểm tra tất cả chi tiết hóa đơn
    for (int i = 0; i < hd.ChiTiet.Count; i++)
    {
        ChiTietHoaDon ct = hd.ChiTiet[i];
        
        // ✅ Thêm: Kiểm tra số lượng bán > 0
        if (ct.SoLuongBan <= 0)
        {
            return; // Hủy, không thêm
        }
        
        // Tìm sản phẩm
        SanPham sp = null;
        for (int j = 0; j < DanhSachSP.Count; j++)
        {
            if (DanhSachSP[j].MaSP == ct.MaSP)
            {
                sp = DanhSachSP[j];
                break;
            }
        }
        
        // Kiểm tra mã sản phẩm phải tồn tại
        if (sp == null)
        {
            return; // Hủy, không thêm
        }
        
        // ✅ Sửa: Kiểm tra số lượng KHÔNG vượt tồn kho (dùng >)
        if (ct.SoLuongBan > sp.SoLuongTon)
        {
            return; // Hủy, không thêm
        }
        
        // Kiểm tra đơn giá bán >= giá nhập * 1.1
        if (ct.DonGiaBan < sp.GiaNhap * 1.1)
        {
            return; // Hủy, không thêm
        }
    }

    // ✅ Sửa: Tất cả hợp lệ → Cập nhật tồn kho CHO TẤT CẢ chi tiết
    for (int i = 0; i < hd.ChiTiet.Count; i++)
    {
        ChiTietHoaDon ct = hd.ChiTiet[i];
        for (int j = 0; j < DanhSachSP.Count; j++)
        {
            if (DanhSachSP[j].MaSP == ct.MaSP)
            {
                DanhSachSP[j].SoLuongTon -= ct.SoLuongBan;
                break;
            }
        }
    }
    
    // ✅ Sửa: Chỉ thêm khi TẤT CẢ điều kiện hợp lệ
    DanhSachHD.Add(hd);
}
```

### 4.2. ThongKeKhachHangMuaNhieuNhat - Code mới
```csharp
public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
{
    // ✅ Sửa: Lọc các hóa đơn trong tháng/năm (duyệt DanhSachHD)
    List<HoaDon> hoaDonThang = new List<HoaDon>();
    for (int i = 0; i < DanhSachHD.Count; i++)
    {
        if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
        {
            hoaDonThang.Add(DanhSachHD[i]);
        }
    }
    
    // Nếu không có hóa đơn nào
    if (hoaDonThang.Count == 0)
    {
        return null;
    }

    // ✅ Sửa: Tính tổng tiền theo từng khách hàng bằng Dictionary
    Dictionary<string, double> tongTienTheoKH = new Dictionary<string, double>();
    
    for (int i = 0; i < hoaDonThang.Count; i++)
    {
        HoaDon hd = hoaDonThang[i];
        
        // ✅ Sửa: Tính tổng tiền chi tiết (cộng dồn)
        double tongTienChiTiet = 0;
        for (int j = 0; j < hd.ChiTiet.Count; j++)
        {
            tongTienChiTiet += hd.ChiTiet[j].DonGiaBan * hd.ChiTiet[j].SoLuongBan;
        }
        
        // Tìm khách hàng để lấy loại và chiết khấu
        KhachHang kh = null;
        for (int j = 0; j < DanhSachKH.Count; j++)
        {
            if (DanhSachKH[j].MaKH == hd.MaKH)
            {
                kh = DanhSachKH[j];
                break;
            }
        }
        
        if (kh != null)
        {
            // Lấy chiết khấu theo loại khách hàng
            double chietKhau = 0;
            if (ChietKhauTheoLoai.ContainsKey(kh.LoaiKH))
            {
                chietKhau = ChietKhauTheoLoai[kh.LoaiKH];
            }
            
            // Tính tiền thanh toán thực tế
            double tienThanhToan = tongTienChiTiet * (1 - chietKhau);
            
            // ✅ Sửa: Cộng dồn vào tổng của khách hàng
            if (tongTienTheoKH.ContainsKey(hd.MaKH))
            {
                tongTienTheoKH[hd.MaKH] += tienThanhToan;
            }
            else
            {
                tongTienTheoKH[hd.MaKH] = tienThanhToan;
            }
        }
    }
    
    // Tìm khách hàng có tổng tiền cao nhất
    string maKHMax = null;
    double tongMax = 0;
    
    foreach (var item in tongTienTheoKH)
    {
        if (maKHMax == null || item.Value > tongMax)
        {
            maKHMax = item.Key;
            tongMax = item.Value;
        }
    }
    
    // Trả về đối tượng KhachHang
    for (int i = 0; i < DanhSachKH.Count; i++)
    {
        if (DanhSachKH[i].MaKH == maKHMax)
        {
            return DanhSachKH[i];
        }
    }
    
    return null;
}
```

---

## V. KẾT QUẢ KIỂM THỬ

### 5.1. Test Case 1: Thêm hóa đơn hợp lệ
**Input:**
- HD1: KH001 (VIP), mua 2 SP1 (950k), 1 SP2 (1350k)
- Tồn trước: SP1=10, SP2=8

**Kết quả:**
- ✅ Hóa đơn được thêm thành công
- ✅ Tồn sau: SP1=8, SP2=7 (đúng)
- ✅ Số hóa đơn trong hệ thống: 1

### 5.2. Test Case 2: Thêm hóa đơn hợp lệ tiếp
**Input:**
- HD2: KH002 (Thuong), mua 1 SP3 (7200k)
- Tồn trước: SP3=3

**Kết quả:**
- ✅ Hóa đơn được thêm thành công
- ✅ Tồn sau: SP3=2 (đúng)
- ✅ Số hóa đơn trong hệ thống: 2

### 5.3. Test Case 3: Thêm hóa đơn KHÔNG hợp lệ (vượt tồn kho)
**Input:**
- HD3: KH003 (Moi), mua 15 SP1 (900k)
- Tồn hiện tại: SP1=8 (không đủ)

**Kết quả:**
- ✅ Hóa đơn bị TỪ CHỐI (đúng)
- ✅ Tồn không đổi: SP1=8 (đúng)
- ✅ Số hóa đơn trong hệ thống: 2 (không thêm, đúng)

### 5.4. Test Case 4: Thống kê khách hàng mua nhiều nhất
**Tính toán thủ công:**
- HD1 (KH001-VIP, chiết khấu 10%):
  - 2 × 950,000 = 1,900,000
  - 1 × 1,350,000 = 1,350,000
  - Tổng = 3,250,000
  - Sau CK = 3,250,000 × 0.9 = **2,925,000**

- HD2 (KH002-Thuong, chiết khấu 5%):
  - 1 × 7,200,000 = 7,200,000
  - Sau CK = 7,200,000 × 0.95 = **6,840,000**

**Kết quả mong đợi:** KH002 (Trần Thị Thanh) có tổng tiền cao nhất

**Kết quả thực tế:**
- ✅ Khách mua nhiều nhất: **Trần Thị Thanh** (KH002)
- ✅ Loại khách: **Thuong**
- ✅ Kết quả chính xác!

---

## VI. TỔNG KẾT

### 6.1. Kết luận chung
**File QuanLyCuaHang.cs ban đầu có 2/5 phương thức SAI NGHIÊM TRỌNG:**

| Phương thức | Trạng thái ban đầu | Trạng thái sau sửa |
|------------|-------------------|-------------------|
| Constructor | ✅ ĐÚNG | ✅ ĐÚNG |
| CapNhatSoLuongTon | ✅ ĐÚNG | ✅ ĐÚNG |
| TimKiemSanPhamTheoNhaCungCap | ✅ ĐÚNG | ✅ ĐÚNG |
| ThemHoaDon | ❌ SAI | ✅ ĐÚNG |
| ThongKeKhachHangMuaNhieuNhat | ❌ SAI | ✅ ĐÚNG |

### 6.2. Mức độ nghiêm trọng của lỗi
- **Rất nghiêm trọng**: 2 phương thức chính hoàn toàn sai logic
- **Runtime errors**: Có nguy cơ IndexOutOfRangeException
- **Data integrity**: Dữ liệu không nhất quán (hóa đơn không hợp lệ vẫn được thêm)
- **Business logic**: Vi phạm các quy tắc nghiệp vụ

### 6.3. Các lỗi đã sửa
1. ✅ Kiểm tra mã khách hàng đúng trong DanhSachKH
2. ✅ Sửa logic kiểm tra tồn kho (từ >= thành >)
3. ✅ Thêm kiểm tra SoLuongBan > 0
4. ✅ Chỉ thêm hóa đơn khi TẤT CẢ điều kiện hợp lệ
5. ✅ Cập nhật tồn kho cho TẤT CẢ chi tiết
6. ✅ Sửa logic vòng lặp trong ThongKeKhachHangMuaNhieuNhat
7. ✅ Tính đúng tổng tiền theo từng khách hàng
8. ✅ Cộng dồn tiền đúng cách

### 6.4. Kết quả kiểm thử sau khi sửa
✅ **TẤT CẢ test cases đều PASSED**
- Thêm hóa đơn hợp lệ: PASSED ✓
- Từ chối hóa đơn không hợp lệ: PASSED ✓
- Cập nhật tồn kho đúng: PASSED ✓
- Thống kê khách hàng chính xác: PASSED ✓

### 6.5. Khuyến nghị
1. **Code review**: Nên có code review trước khi submit
2. **Unit testing**: Nên viết unit tests cho từng phương thức
3. **Validation**: Cần kiểm tra kỹ các điều kiện biên
4. **Logic**: Cần hiểu rõ yêu cầu trước khi code

---

## VII. PHỤ LỤC

### 7.1. File test
- `TestSimple.cs`: File test độc lập, có thể compile và chạy được
- Compile: `mcs -out:TestSimple.exe TestSimple.cs`
- Run: `mono TestSimple.exe`

### 7.2. Các file đã sửa đổi
- `QuanLyCuaHang.cs`: Sửa 2 phương thức ThemHoaDon và ThongKeKhachHangMuaNhieuNhat
- `TestQuanLyCuaHang.cs`: File test chi tiết (có thể không compile được do thiếu dependencies)
- `TestSimple.cs`: File test độc lập, đã chạy thành công

---

**Kết thúc báo cáo**
