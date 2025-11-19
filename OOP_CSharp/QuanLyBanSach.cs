using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using KTGK_CSharp;

namespace thi_thu_csharp
{
    internal class QuanLyBanSach
    {
        List<Sach> danhSachSach;
        List<DocGia> danhSachDocGia;
        List<HoaDonMuaSach> danhSachHoaDon;
        Dictionary<string, double> chietkhautheoloai;
        //       
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
      
        public bool ThemHoaDonMuaSach(HoaDonMuaSach hd)
        {

            foreach (var dg in danhSachDocGia)
            {
                if (dg.MaDG== hd.MaDG)
                { 
                    return true;
                    
                }
                
                   
            }
            

            foreach (var chiTiet in hd.ChiTiet)
            {
                foreach(var sach in danhSachSach)
                {
                    if (sach.MaSach == chiTiet.MaSach)
                    {
                       
                        if (chiTiet.SoLuong <= 0)
                            return false;

                        
                        if (sach.SoLuongTon < chiTiet.SoLuong)
                            return false;

                        
                        if (chiTiet.DonGia < (sach.GiaNhap * 1.1))
                            return false;
                    }
                }
            }
           
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
        }

        public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
        {
            double maxThanhToan = 0;
            DocGia docGiaMuaNhieuNhat = null;

            // Duyệt qua từng độc giả để tính tổng tiền của tất cả hóa đơn
            foreach (var docGia in danhSachDocGia)
            {
                double tongTienDocGia = 0;

                // Tìm tất cả hóa đơn của độc giả này trong tháng/năm
                foreach (var hd in danhSachHoaDon)
                {
                    if (hd.MaDG == docGia.MaDG && hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
                    {
                        // Tính tổng tiền chi tiết của hóa đơn
                        double tongTienChiTiet = 0;
                        foreach (var chiTiet in hd.ChiTiet)
                        {
                            tongTienChiTiet += chiTiet.DonGia * chiTiet.SoLuong;
                        }

                        // Áp dụng chiết khấu theo loại độc giả
                        double chietKhau = 0;
                        if (chietkhautheoloai.ContainsKey(docGia.LoaiDG))
                        {
                            chietKhau = chietkhautheoloai[docGia.LoaiDG];
                        }

                        double tienThanhToanThucTe = tongTienChiTiet * (1 - chietKhau);
                        
                        // Cộng dồn vào tổng tiền của độc giả
                        tongTienDocGia += tienThanhToanThucTe;
                    }
                }

                // So sánh tổng tiền của độc giả với max
                if (tongTienDocGia > maxThanhToan)
                {
                    maxThanhToan = tongTienDocGia;
                    docGiaMuaNhieuNhat = docGia;
                }
            }

            return docGiaMuaNhieuNhat; 
        }


    }
}
