using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    class QuanLyCuaHang
    {
        private List<SanPham> danhSachSP;
        private List<KhachHang> danhSachKH;
        private List<HoaDon> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public List<SanPham> DanhSachSP { get => danhSachSP; set => danhSachSP = value; }
        public List<KhachHang> DanhSachKH { get => danhSachKH; set => danhSachKH = value; }
        public List<HoaDon> DanhSachHD { get => danhSachHD; set => danhSachHD = value; }
        public Dictionary<string, double> ChietKhauTheoLoai
        {
            get => chietKhauTheoLoai;
            set
            {
                chietKhauTheoLoai = value;
            }
        }

        public void ThemSanPham(SanPham sp)
        {
            DanhSachSP.Add(sp);
        }

        public void ThemKhachHang(KhachHang kh)
        {
            DanhSachKH.Add(kh);
        }
        // Loại Khách hàng -> % chiết khấu(0 đến 10%) 

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

        public bool ThemHoaDon(HoaDon hd)
        {
            bool KTKH = false;

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachKH[i].MaKH == hd.MaKH)
                {
                    KTKH = true;
                    break;
                }
            }

            if (KTKH == false)
            {
                return false;
            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                if (hd.ChiTiet[i].SoLuongBan <= 0)
                {
                    return false;
                }

                SanPham SP = null;

                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP)
                    {
                        SP = DanhSachSP[j];
                        break;
                    }
                }

                if (SP == null || SP.SoLuongTon < hd.ChiTiet[i].SoLuongBan || SP.GiaNhap * 1.1 > hd.ChiTiet[i].DonGiaBan)
                {
                    return false;
                }

            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP)
                    {
                        DanhSachSP[j].SoLuongTon -= hd.ChiTiet[i].SoLuongBan;
                        break;
                    }
                }
            }

            DanhSachHD.Add(hd);
            return true;
        }

        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            List<HoaDon> Lst_HD = new List<HoaDon>();
            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
                {
                    Lst_HD.Add(DanhSachHD[i]);
                }
            }
            if (Lst_HD.Count <= 0)
            {
                return null;
            }

            Dictionary<string, double> Dict_Tong = new Dictionary<string, double>();
            
            for (int i = 0; i < Lst_HD.Count; i++)
            {
                double Tong = 0;
                for (int j = 0; j < Lst_HD[i].ChiTiet.Count; j++)
                {
                    Tong += Lst_HD[i].ChiTiet[j].SoLuongBan * Lst_HD[i].ChiTiet[j].DonGiaBan;
                }

                KhachHang KH = null;
                for (int j = 0; j < DanhSachKH.Count; j++)
                {
                    if (DanhSachKH[j].MaKH == Lst_HD[i].MaKH)
                    {
                        KH = DanhSachKH[j];
                        break;
                    }
                }

                if (KH != null)
                {
                    double ChietKhau = 0;
                    if (ChietKhauTheoLoai.ContainsKey(KH.LoaiKH))
                    {
                        ChietKhau = ChietKhauTheoLoai[KH.LoaiKH];
                    }

                    Tong = Tong * (1- ChietKhau);

                    if (Dict_Tong.ContainsKey(Lst_HD[i].MaKH))
                    {
                        Dict_Tong[Lst_HD[i].MaKH] += Tong;
                    }

                    else
                    {
                        Dict_Tong[Lst_HD[i].MaKH] = Tong;
                    }
                }
            }


            string MaKHMAX = null;
            double MaxTong = 0;
            List<string> Key = Dict_Tong.Keys.ToList();
            for (int i = 0; i < Dict_Tong.Count; i++)
            {
                if (MaKHMAX == null || Dict_Tong[Key[i]] > MaxTong)
                {
                    MaKHMAX = Key[i];
                    MaxTong = Dict_Tong[Key[i]];
                }
            }

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (MaKHMAX == DanhSachKH[i].MaKH)
                {
                    return DanhSachKH[i];
                }
            }
            return null;
        }
    }
}