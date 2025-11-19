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
            bool KT = false;
            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                if (hd.MaKH == DanhSachHD[i].MaKH)
                {
                    KT = true;
                }
            }

            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                for (int j = 0; j < DanhSachSP.Count; j++)
                {
                    if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP && hd.ChiTiet[i].SoLuongBan >= DanhSachSP[j].SoLuongTon && hd.ChiTiet[i].DonGiaBan >= DanhSachSP[j].GiaNhap * 1.1)
                    {
                        KT = true;
                        break;
                    }
                }
                if (KT == true)
                {
                    break;
                }
            }

            if (KT == true)
            {
                KT = false;
                for (int i = 0; i < hd.ChiTiet.Count; i++)
                {
                    for (int j = 0; j < DanhSachSP.Count; j++)
                    {
                        if (hd.ChiTiet[i].MaSP == DanhSachSP[j].MaSP)
                        {
                            DanhSachSP[j].SoLuongTon -= hd.ChiTiet[i].SoLuongBan;
                            KT = true;
                            break;
                        }
                    }
                    if (KT == true)
                    {
                        break;
                    }
                }
            }

            DanhSachHD.Add(hd);
            return KT;
        }

        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            List<KhachHang> Lst_KhachHang = new List<KhachHang>();
            List<double> Lst_Tong = new List<double>();
            double Tong = 0;
            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachHD[i].NgayLap.Month == thang && DanhSachHD[i].NgayLap.Year == nam)
                {
                    Lst_KhachHang.Add(DanhSachKH[i]);
                }
            }
            if (Lst_KhachHang.Count <= 0)
            {
                return null;
            }
            double ChietKhau = 0;
            for (int i = 0; i <= Lst_KhachHang.Count; i++)
            {
                for (int j = 0; i < DanhSachHD.Count; i++)
                {
                    if (Lst_KhachHang[i].MaKH == DanhSachHD[j].MaKH)
                    {
                        for (int k = 0; k < DanhSachHD[j].ChiTiet.Count; k++)
                        {
                            Tong = DanhSachHD[j].ChiTiet[k].DonGiaBan * DanhSachHD[j].ChiTiet[k].SoLuongBan;
                        }
                        if (ChietKhauTheoLoai.ContainsKey((Lst_KhachHang[i].LoaiKH)))
                        {
                            ChietKhau = 1- chietKhauTheoLoai[(Lst_KhachHang[i].LoaiKH)];
                        }
                        Lst_Tong.Add(Tong * ChietKhau);
                    }
                }
            }
            for (int i = 0; i < Lst_Tong.Count; i++)
            {
                for (int j = 0; j < Lst_Tong.Count - i - 1; j++)
                {
                    if (Lst_Tong[j] < Lst_Tong[j + 1])
                    {
                        double temp = Lst_Tong[j];
                        Lst_Tong[j] = Lst_Tong[j + 1];
                        Lst_Tong[j + 1] = temp;

                        KhachHang tempKH = Lst_KhachHang[j];
                        Lst_KhachHang[j] = Lst_KhachHang[j + 1];
                        Lst_KhachHang[j + 1] = tempKH;
                    }
                }
            }
            return Lst_KhachHang[0];
        }
    }
}
