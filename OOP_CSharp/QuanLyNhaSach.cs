using KTGK_CSharp;
using System;
using System.Collections.Generic;

namespace BT
{
    internal class QuanLyNhaSach
    {
        private List<Sach> danhSachSach;
        private List<DocGia> danhSachDG;
        private List<HoaDonMuaSach> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;
        public void DSDT()
        {
            Console.WriteLine("==== DANH SÁCH HÓA ĐƠN ĐÃ THÊM ====");
            foreach (var hd in danhSachHD)
            {
                Console.WriteLine("HD: " + hd.SoHD + " ngày " + hd.NgayMua);
            }
        }
        public QuanLyNhaSach()
        {
            danhSachSach = new List<Sach>();
            danhSachDG = new List<DocGia>();
            danhSachHD = new List<HoaDonMuaSach>();
            chietKhauTheoLoai = new Dictionary<string, double>
            {
                { "VIP", 0.10 },
                { "Thuong", 0.05 },
                { "Moi", 0.00 }
            };
         }


        public void ThemSach(Sach s)
        {
            danhSachSach.Add(s);
        }

        public void ThemDocGia(DocGia dg)
        {
            danhSachDG.Add(dg);
        }

        public void CapNhatSoLuongTon(int maSach, int soLuongNhapThem)
        {
            foreach (var sach in danhSachSach)
            {
                if (sach.MaSach == maSach)
                {
                    sach.SoLuongTon += soLuongNhapThem;
                    return;
                }
            }
        }
        public List<Sach> TimKiemSachTheoNhaXuatBan(string nhaXuatBan)
        {
            List<Sach> Lst_KetQua = new List<Sach>();

            foreach (var sach in danhSachSach)
            {
                if (sach.NhaXuatBan.ToLower() == nhaXuatBan.ToLower())
                {
                    Lst_KetQua.Add(sach);
                }
            }

            return Lst_KetQua;
        }
        public bool ThemHoaDonMuaSach(HoaDonMuaSach hd)
        {
            bool KiemTraDocGia = false;
            foreach (var dg in danhSachDG)
            {
                if (dg.MaDG == hd.MaDG)
                {
                    KiemTraDocGia = true;
                    break;
                }
            }
            if (!KiemTraDocGia)
            {
                return false;
            }
            bool KiemTraHopLe = true;
            foreach (var ct in hd.ChiTiet)
            {
                Sach sach = null;
                foreach (var s in danhSachSach)
                {
                    if (s.MaSach == ct.MaSach)
                    {
                        sach = s;
                        break;
                    }
                }
                if (sach == null)
                {
                    KiemTraHopLe = false;
                    break;
                }
                if (ct.SoLuong <= 0 || ct.SoLuong > sach.SoLuongTon)
                {
                    KiemTraHopLe = false;
                    break;
                }
                double GiaToiThieu = sach.GiaNhap * 1.1;
                if (ct.DonGia < GiaToiThieu - 0.01)
                {
                    KiemTraHopLe = false;
                    break;
                }
            }
            if (!KiemTraHopLe)
            {
                return false;
            }
            foreach (var ct in hd.ChiTiet)
            {
                foreach (var sach in danhSachSach)
                {
                    if (sach.MaSach == ct.MaSach)
                    {
                        sach.SoLuongTon -= ct.SoLuong;
                        break;
                    }
                }
            }
            danhSachHD.Add(hd);
            return true;
        }

        public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
        {

            Dictionary<string, double> TongTienTheoDG = new Dictionary<string, double>();

            foreach (var hd in danhSachHD)
            {
                if (hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
                {
                    double TongTienChiTiet = 0;
                    foreach (var ct in hd.ChiTiet)
                    {
                        TongTienChiTiet += ct.DonGia * ct.SoLuong;
                    }
                    string loai = "";
                    foreach (var dg in danhSachDG)
                    {
                        if (dg.MaDG == hd.MaDG)
                        {
                            loai = dg.LoaiDG;
                            break;
                        }
                    }
                    double chietKhau = 0;

                    if (chietKhauTheoLoai.ContainsKey(loai))
                    {
                        chietKhau = chietKhauTheoLoai[loai];
                    }
                    double TienThucTe = TongTienChiTiet * (1 - chietKhau);

                    if (TongTienTheoDG.ContainsKey(hd.MaDG))
                        TongTienTheoDG[hd.MaDG] += TienThucTe;
                    else
                        TongTienTheoDG.Add(hd.MaDG, TienThucTe);
                }
            }
            if (TongTienTheoDG.Count == 0)
                return null;

            string MaMax = "";
            double TienMax = double.MinValue;

            foreach (var item in TongTienTheoDG)
            {
                if (item.Value > TienMax)
                {
                    TienMax = item.Value;
                    MaMax = item.Key;
                }
            }
            foreach (var dg in danhSachDG)
            {
                if (dg.MaDG == MaMax)
                    return dg;
            }
            return null;
        }
    }
}
