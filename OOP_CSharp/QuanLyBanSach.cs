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

            // Kiểm tra từng chi tiết hóa đơn
            foreach (var chiTiet in hd.ChiTiet)
            {
                bool sachTonTai = false;
                foreach(var sach in danhSachSach)
                {
                    if (sach.MaSach == chiTiet.MaSach)
                    {
                        sachTonTai = true;
                        
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
                        
                        break;
                    }
                }
                
                // Nếu sách không tồn tại trong danh sách
                if (!sachTonTai)
                {
                    return false;
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


    }
}
