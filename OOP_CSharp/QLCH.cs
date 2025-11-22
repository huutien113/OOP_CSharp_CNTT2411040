using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    class QLCH
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

        public QLCH()
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
            if (Lst_HD.Count == 0)
                return null;

            List<string> Lst_MaKH = new List<string>();
            List<double> Lst_TongTien = new List<double>();

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
                

                double ChietKhau = 0;
                if (ChietKhauTheoLoai.ContainsKey(KH.LoaiKH))
                {
                    ChietKhau = ChietKhauTheoLoai[KH.LoaiKH];
                }

                Tong = Tong * (1 - ChietKhau);

                int ViTri = -1;
                for (int k = 0; k < Lst_MaKH.Count; k++)
                {
                    if (Lst_MaKH[k] == KH.MaKH)
                    {
                        ViTri = k;
                        break;
                    }
                }

                if (ViTri == -1)
                {
                    Lst_MaKH.Add(KH.MaKH);
                    Lst_TongTien.Add(Tong);
                }
                else
                {
                    Lst_TongTien[ViTri] += Tong;
                }
            }

            if (Lst_MaKH.Count == 0)
            {
                return null;
            }
            int ViTriMax = 0;
            for (int i = 1; i < Lst_TongTien.Count; i++)
            {
                if (Lst_TongTien[i] > Lst_TongTien[ViTriMax])
                {
                    ViTriMax = i;
                }
            }

            for (int i = 0; i < DanhSachKH.Count; i++)
            {
                if (DanhSachKH[i].MaKH == Lst_MaKH[ViTriMax])
                {
                    return DanhSachKH[i];
                }
            }

            return null;
        }


        public List<SanPham> SanPhamBanChayNhat(int topCount)
        {
            List<SanPham> Lst_Top = new List<SanPham>();
            if (DanhSachSP.Count == 0 || topCount <= 0)
            {
                return null;
            }

            List<int> Lst_MaSP = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i< DanhSachHD.Count; i++)
            {
                for (int j = 0; j < DanhSachHD[i].ChiTiet.Count; j++)
                {
                    int MaSP = DanhSachHD[i].ChiTiet[j].MaSP;
                    int SoLuongBan = DanhSachHD[i].ChiTiet[j].SoLuongBan;
                    
                    int ViTri = -1;
                    for (int k = 0; k < Lst_MaSP.Count; k++)
                    {
                        if (Lst_MaSP[k] == MaSP)
                        {
                            ViTri = k;
                            break;
                        }
                    }

                    if (ViTri == -1)
                    {
                        Lst_MaSP.Add(MaSP);
                        Lst_SoLuongBan.Add(SoLuongBan);
                    }
                    else
                    {
                        Lst_SoLuongBan[ViTri] += SoLuongBan;
                    }
                }
            }
            if (Lst_MaSP.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < Lst_MaSP.Count - 1; i++)
            {
                for (int j = 0; j < Lst_MaSP.Count - i - 1; j++)
                {
                    if (Lst_SoLuongBan[j] < Lst_SoLuongBan[j+1])
                    { 
                        int TSLB = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = Lst_SoLuongBan[j+1];
                        Lst_SoLuongBan[j+1] = TSLB;

                        int TMSP = Lst_MaSP[j];
                        Lst_MaSP[j] = Lst_MaSP[j+1];
                        Lst_MaSP[j+1] = TMSP;
                    }
                }
            }

            List<int> Lst_SoLuongTop = new List<int>();
            for (int i = 0; i < Lst_SoLuongBan.Count; i++)
            {
                bool Kt = true;

                for (int j = 0; j < Lst_SoLuongTop.Count; j++)
                {
                    if (Lst_SoLuongBan[i] == Lst_SoLuongTop[j])
                    {
                        Kt = false;
                        break;
                    }
                }

                if (Kt == true)
                {
                    Lst_SoLuongTop.Add(Lst_SoLuongBan[i]);
                }

                if (Lst_SoLuongTop.Count >= topCount)
                {
                    break;
                }
            }

            int soLuongMin = Lst_SoLuongTop[Lst_SoLuongTop.Count - 1];
            for (int i = 0; i < Lst_SoLuongBan.Count; i++)
            {
                if (Lst_SoLuongBan[i] >= soLuongMin)
                {
                    for (int j = 0; j < DanhSachSP.Count; j++)
                    {
                        if (DanhSachSP[j].MaSP == Lst_MaSP[i])
                        {
                            Lst_Top.Add(DanhSachSP[j]);
                            break;
                        }
                    }
                }
            }

            return Lst_Top;
        }
    }  
}