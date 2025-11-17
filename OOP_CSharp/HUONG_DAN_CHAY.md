# Hướng dẫn Biên dịch và Chạy

## Yêu cầu
- Mono (Linux/Mac) hoặc .NET Framework/Core (Windows)
- C# Compiler (mcs hoặc csc)

## Cách 1: Sử dụng Mono (Linux/Mac)

### Biên dịch
```bash
mcs -out:TestKiemTra.exe classesLib.cs QuanLyCuaHang.cs QuanLyNhaThuoc.cs QuanLyNhaSach.cs TestKiemTra.cs
```

### Chạy
```bash
mono TestKiemTra.exe
```

### Kết quả mong đợi
```
=== TEST ĐỀ 0: QuanLyCuaHang ===
Khách mua nhiều nhất: Trần Thị Thanh


=== TEST ĐỀ 1: QuanLyNhaThuoc ===
Bệnh nhân chi tiêu nhiều nhất: Nguyễn Văn An


=== TEST ĐỀ 2: QuanLyNhaSach ===
Độc giả mua nhiều nhất: Nguyễn Văn An
```

## Cách 2: Sử dụng .NET Framework (Windows)

### Biên dịch
```cmd
csc /out:TestKiemTra.exe classesLib.cs QuanLyCuaHang.cs QuanLyNhaThuoc.cs QuanLyNhaSach.cs TestKiemTra.cs
```

### Chạy
```cmd
TestKiemTra.exe
```

## Cách 3: Sử dụng Visual Studio

1. Mở file .sln trong Visual Studio
2. Thêm các file .cs vào project (nếu chưa có)
3. Build project (F6)
4. Chạy (F5 hoặc Ctrl+F5)

## Kiểm tra từng đề riêng lẻ

### Chỉ test Đề 0
Sửa file `TestKiemTra.cs`, comment các dòng:
```csharp
// Console.WriteLine("\n\n=== TEST ĐỀ 1: QuanLyNhaThuoc ===");
// TestDe1();

// Console.WriteLine("\n\n=== TEST ĐỀ 2: QuanLyNhaSach ===");
// TestDe2();
```

### Chỉ test Đề 1
Sửa file `TestKiemTra.cs`, comment các dòng:
```csharp
// Console.WriteLine("=== TEST ĐỀ 0: QuanLyCuaHang ===");
// TestDe0();

// Console.WriteLine("\n\n=== TEST ĐỀ 2: QuanLyNhaSach ===");
// TestDe2();
```

### Chỉ test Đề 2
Sửa file `TestKiemTra.cs`, comment các dòng:
```csharp
// Console.WriteLine("=== TEST ĐỀ 0: QuanLyCuaHang ===");
// TestDe0();

// Console.WriteLine("\n\n=== TEST ĐỀ 1: QuanLyNhaThuoc ===");
// TestDe1();
```

## Xử lý Lỗi

### Lỗi: "namespace KTGK_CSharp could not be found"
**Nguyên nhân**: Chưa biên dịch file classesLib.cs

**Giải pháp**: Đảm bảo file classesLib.cs được include trong lệnh biên dịch

### Lỗi: "The type or namespace name 'List' could not be found"
**Nguyên nhân**: Thiếu using System.Collections.Generic

**Giải pháp**: Đã có sẵn trong tất cả các file, không cần thêm

### Lỗi compilation khác
**Giải pháp**: Kiểm tra lại các file có đúng trong cùng thư mục không:
```bash
ls -la classesLib.cs QuanLyCuaHang.cs QuanLyNhaThuoc.cs QuanLyNhaSach.cs TestKiemTra.cs
```

## Tài liệu Tham khảo

- **README_IMPLEMENTATION.md**: Hướng dẫn chi tiết về implementation
- **TEST_RESULTS.md**: Kết quả kiểm tra với dữ liệu đầy đủ
- **ĐỀ KIỂM TRA THỰC HÀNH OOP.pdf**: Đề bài gốc
- **DỮ LIỆU VÀ KỊCH BẢN KIỂM THỬ.docx**: Dữ liệu test

## Liên hệ

Nếu có vấn đề, vui lòng tham khảo:
1. README_IMPLEMENTATION.md - Giải thích chi tiết
2. TEST_RESULTS.md - Kết quả và công thức tính toán
3. Source code - Comments trong code

---
**Lưu ý**: Tất cả các test đều phải pass như kết quả mong đợi ở trên.
