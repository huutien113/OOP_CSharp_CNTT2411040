using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTGK_CSharp
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaCungCap { get; set; }

        public SanPham(int maSP, string tenSP, double giaNhap, int soLuongTon, string nhaCungCap)
        {
            MaSP = maSP; TenSP = tenSP; GiaNhap = giaNhap; SoLuongTon = soLuongTon; NhaCungCap = nhaCungCap;
        }

        public override string ToString()
        {
            return $"{MaSP} - {TenSP} - NCC: {NhaCungCap} - Tồn: {SoLuongTon}";
        }
    }

    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string LoaiKH { get; set; } // "VIP", "Thuong", "Moi"

        public KhachHang(string maKH, string hoTen, string diaChi, string loaiKH)
        {
            MaKH = maKH; HoTen = hoTen; DiaChi = diaChi; LoaiKH = loaiKH;
        }

        public override string ToString()
        {
            return $"{MaKH} - {HoTen} ({LoaiKH}) - {DiaChi}";
        }
    }

    public class HoaDon
    {
        public int SoHD { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayLap { get; set; }
        public List<ChiTietHoaDon> ChiTiet { get; set; }

        public HoaDon(int soHD, string maKH, DateTime ngayLap)
        {
            SoHD = soHD; MaKH = maKH; NgayLap = ngayLap;
            ChiTiet = new List<ChiTietHoaDon>();
        }
    }

    public class ChiTietHoaDon
    {
        public int MaSP { get; set; }
        public int SoLuongBan { get; set; }
        public double DonGiaBan { get; set; }

        public ChiTietHoaDon(int maSP, int soLuongBan, double donGiaBan)
        {
            MaSP = maSP; SoLuongBan = soLuongBan; DonGiaBan = donGiaBan;
        }
    }

    public class Thuoc
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaSanXuat { get; set; }

        public Thuoc(int maThuoc, string tenThuoc, double giaNhap, int soLuongTon, string nhaSanXuat)
        {
            MaThuoc = maThuoc; TenThuoc = tenThuoc; GiaNhap = giaNhap; SoLuongTon = soLuongTon; NhaSanXuat = nhaSanXuat;
        }

        public override string ToString()
        {
            return $"{MaThuoc} - {TenThuoc} - NSX: {NhaSanXuat} - Tồn: {SoLuongTon}";
        }
    }

    public class BenhNhan
    {
        public string MaBN { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string LoaiBN { get; set; } // "VIP", "Thuong", "Moi"

        public BenhNhan(string maBN, string hoTen, string diaChi, string loaiBN)
        {
            MaBN = maBN; HoTen = hoTen; DiaChi = diaChi; LoaiBN = loaiBN;
        }

        public override string ToString()
        {
            return $"{MaBN} - {HoTen} ({LoaiBN}) - {DiaChi}";
        }
    }

    public class DonThuoc
    {
        public int SoDT { get; set; }
        public string MaBN { get; set; }
        public DateTime NgayKe { get; set; }
        public List<ChiTietDonThuoc> ChiTiet { get; set; }

        public DonThuoc(int soDT, string maBN, DateTime ngayKe)
        {
            SoDT = soDT; MaBN = maBN; NgayKe = ngayKe;
            ChiTiet = new List<ChiTietDonThuoc>();
        }
    }

    public class ChiTietDonThuoc
    {
        public int MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public ChiTietDonThuoc(int maThuoc, int soLuong, double donGia)
        {
            MaThuoc = maThuoc; SoLuong = soLuong; DonGia = donGia;
        }
    }

    public class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public double GiaNhap { get; set; }
        public int SoLuongTon { get; set; }
        public string NhaXuatBan { get; set; }

        public Sach(int maSach, string tenSach, double giaNhap, int soLuongTon, string nhaXuatBan)
        {
            MaSach = maSach; TenSach = tenSach; GiaNhap = giaNhap; SoLuongTon = soLuongTon; NhaXuatBan = nhaXuatBan;
        }

        public override string ToString()
        {
            return $"{MaSach} - {TenSach} - NXB: {NhaXuatBan} - Tồn: {SoLuongTon}";
        }
    }

    public class DocGia
    {
        public string MaDG { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string LoaiDG { get; set; } // "VIP", "Thuong", "Moi"

        public DocGia(string maDG, string hoTen, string diaChi, string loaiDG)
        {
            MaDG = maDG; HoTen = hoTen; DiaChi = diaChi; LoaiDG = loaiDG;
        }

        public override string ToString()
        {
            return $"{MaDG} - {HoTen} ({LoaiDG}) - {DiaChi}";
        }
    }

    public class HoaDonMuaSach
    {
        public int SoHD { get; set; }
        public string MaDG { get; set; }
        public DateTime NgayMua { get; set; }
        public List<ChiTietHoaDonMuaSach> ChiTiet { get; set; }

        public HoaDonMuaSach(int soHD, string maDG, DateTime ngayMua)
        {
            SoHD = soHD; MaDG = maDG; NgayMua = ngayMua;
            ChiTiet = new List<ChiTietHoaDonMuaSach>();
        }
    }

    public class ChiTietHoaDonMuaSach
    {
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public ChiTietHoaDonMuaSach(int maSach, int soLuong, double donGia)
        {
            MaSach = maSach; SoLuong = soLuong; DonGia = donGia;
        }
    }
    
}
