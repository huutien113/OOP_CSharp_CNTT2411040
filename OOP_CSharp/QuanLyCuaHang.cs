using System;
using System.Collections.Generic;
using KTGK_CSharp;

namespace OOP_CSharp
{
    public class QuanLyCuaHang
    {
        private List<SanPham> danhSachSP;
        private List<KhachHang> danhSachKH;
        private List<HoaDon> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public QuanLyCuaHang()
        {
            danhSachSP = new List<SanPham>();
            danhSachKH = new List<KhachHang>();
            danhSachHD = new List<HoaDon>();
            chietKhauTheoLoai = new Dictionary<string, double>();
            chietKhauTheoLoai["VIP"] = 0.10;
            chietKhauTheoLoai["Thuong"] = 0.05;
            chietKhauTheoLoai["Moi"] = 0.00;
        }

        public void ThemSanPham(SanPham sp)
        {
            danhSachSP.Add(sp);
        }

        public void ThemKhachHang(KhachHang kh)
        {
            danhSachKH.Add(kh);
        }

        public void CapNhatSoLuongTon(int maSP, int soLuongNhapThem)
        {
            for (int i = 0; i < danhSachSP.Count; i++)
            {
                if (danhSachSP[i].MaSP == maSP)
                {
                    danhSachSP[i].SoLuongTon = danhSachSP[i].SoLuongTon + soLuongNhapThem;
                    return;
                }
            }
        }

        public List<SanPham> TimKiemSanPhamTheoNhaCungCap(string nhaCungCap)
        {
            List<SanPham> Lst_KetQua = new List<SanPham>();
            for (int i = 0; i < danhSachSP.Count; i++)
            {
                if (danhSachSP[i].NhaCungCap.ToLower() == nhaCungCap.ToLower())
                {
                    Lst_KetQua.Add(danhSachSP[i]);
                }
            }
            return Lst_KetQua;
        }

        public void ThemHoaDon(HoaDon hd)
        {
            // Kiểm tra mã khách hàng tồn tại
            bool KT_KhachHangTonTai = false;
            for (int i = 0; i < danhSachKH.Count; i++)
            {
                if (danhSachKH[i].MaKH == hd.MaKH)
                {
                    KT_KhachHangTonTai = true;
                    break;
                }
            }

            if (!KT_KhachHangTonTai)
            {
                return;
            }

            // Kiểm tra tất cả chi tiết hóa đơn
            bool KT_TatCaHopLe = true;
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDon ct = hd.ChiTiet[i];
                
                // Tìm sản phẩm
                SanPham sp = null;
                for (int j = 0; j < danhSachSP.Count; j++)
                {
                    if (danhSachSP[j].MaSP == ct.MaSP)
                    {
                        sp = danhSachSP[j];
                        break;
                    }
                }

                // Kiểm tra sản phẩm tồn tại
                if (sp == null)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra số lượng bán
                if (ct.SoLuongBan <= 0 || ct.SoLuongBan > sp.SoLuongTon)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra đơn giá bán (tối thiểu 10% lợi nhuận)
                double GiaToiThieu = sp.GiaNhap * 1.1;
                if (ct.DonGiaBan < GiaToiThieu - 0.01)
                {
                    KT_TatCaHopLe = false;
                    break;
                }
            }

            // Nếu tất cả hợp lệ, cập nhật tồn kho và thêm hóa đơn
            if (KT_TatCaHopLe)
            {
                for (int i = 0; i < hd.ChiTiet.Count; i++)
                {
                    ChiTietHoaDon ct = hd.ChiTiet[i];
                    for (int j = 0; j < danhSachSP.Count; j++)
                    {
                        if (danhSachSP[j].MaSP == ct.MaSP)
                        {
                            danhSachSP[j].SoLuongTon = danhSachSP[j].SoLuongTon - ct.SoLuongBan;
                            break;
                        }
                    }
                }
                danhSachHD.Add(hd);
            }
        }

        public KhachHang ThongKeKhachHangMuaNhieuNhat(int thang, int nam)
        {
            // Tạo các danh sách để lưu mã khách hàng và tổng tiền tương ứng
            List<string> Lst_MaKH = new List<string>();
            List<double> Lst_TongTien = new List<double>();

            // Tính tổng tiền cho mỗi khách hàng
            for (int i = 0; i < danhSachHD.Count; i++)
            {
                HoaDon hd = danhSachHD[i];
                
                // Kiểm tra tháng và năm
                if (hd.NgayLap.Month == thang && hd.NgayLap.Year == nam)
                {
                    // Tính tổng tiền chi tiết
                    double TongTienChiTiet = 0;
                    for (int j = 0; j < hd.ChiTiet.Count; j++)
                    {
                        ChiTietHoaDon ct = hd.ChiTiet[j];
                        TongTienChiTiet = TongTienChiTiet + (ct.DonGiaBan * ct.SoLuongBan);
                    }

                    // Tìm loại khách hàng để lấy chiết khấu
                    string LoaiKH = "";
                    for (int k = 0; k < danhSachKH.Count; k++)
                    {
                        if (danhSachKH[k].MaKH == hd.MaKH)
                        {
                            LoaiKH = danhSachKH[k].LoaiKH;
                            break;
                        }
                    }

                    // Tính tiền thanh toán thực tế
                    double ChietKhau = 0;
                    if (chietKhauTheoLoai.ContainsKey(LoaiKH))
                    {
                        ChietKhau = chietKhauTheoLoai[LoaiKH];
                    }
                    double TienThanhToanThucTe = TongTienChiTiet * (1 - ChietKhau);

                    // Cộng vào tổng của khách hàng
                    int ViTri = -1;
                    for (int k = 0; k < Lst_MaKH.Count; k++)
                    {
                        if (Lst_MaKH[k] == hd.MaKH)
                        {
                            ViTri = k;
                            break;
                        }
                    }

                    if (ViTri >= 0)
                    {
                        Lst_TongTien[ViTri] = Lst_TongTien[ViTri] + TienThanhToanThucTe;
                    }
                    else
                    {
                        Lst_MaKH.Add(hd.MaKH);
                        Lst_TongTien.Add(TienThanhToanThucTe);
                    }
                }
            }

            // Nếu không có hóa đơn nào
            if (Lst_MaKH.Count == 0)
            {
                return null;
            }

            // Tìm khách hàng có tổng tiền cao nhất
            string MaKHMax = "";
            double TienMax = 0;
            bool DauTien = true;

            for (int i = 0; i < Lst_MaKH.Count; i++)
            {
                if (DauTien || Lst_TongTien[i] > TienMax)
                {
                    TienMax = Lst_TongTien[i];
                    MaKHMax = Lst_MaKH[i];
                    DauTien = false;
                }
            }

            // Trả về đối tượng khách hàng
            for (int i = 0; i < danhSachKH.Count; i++)
            {
                if (danhSachKH[i].MaKH == MaKHMax)
                {
                    return danhSachKH[i];
                }
            }

            return null;
        }
    }
}
