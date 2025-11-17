using System;
using System.Collections.Generic;
using KTGK_CSharp;

namespace OOP_CSharp
{
    public class QuanLyNhaSach
    {
        private List<Sach> danhSachSach;
        private List<DocGia> danhSachDG;
        private List<HoaDonMuaSach> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public QuanLyNhaSach()
        {
            danhSachSach = new List<Sach>();
            danhSachDG = new List<DocGia>();
            danhSachHD = new List<HoaDonMuaSach>();
            chietKhauTheoLoai = new Dictionary<string, double>();
            chietKhauTheoLoai["VIP"] = 0.10;
            chietKhauTheoLoai["Thuong"] = 0.05;
            chietKhauTheoLoai["Moi"] = 0.00;
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
            for (int i = 0; i < danhSachSach.Count; i++)
            {
                if (danhSachSach[i].MaSach == maSach)
                {
                    danhSachSach[i].SoLuongTon = danhSachSach[i].SoLuongTon + soLuongNhapThem;
                    return;
                }
            }
        }

        public List<Sach> TimKiemSachTheoNhaXuatBan(string nhaXuatBan)
        {
            List<Sach> Lst_KetQua = new List<Sach>();
            for (int i = 0; i < danhSachSach.Count; i++)
            {
                if (danhSachSach[i].NhaXuatBan.ToLower() == nhaXuatBan.ToLower())
                {
                    Lst_KetQua.Add(danhSachSach[i]);
                }
            }
            return Lst_KetQua;
        }

        public void ThemHoaDonMuaSach(HoaDonMuaSach hd)
        {
            // Kiểm tra mã độc giả tồn tại
            bool KT_DocGiaTonTai = false;
            for (int i = 0; i < danhSachDG.Count; i++)
            {
                if (danhSachDG[i].MaDG == hd.MaDG)
                {
                    KT_DocGiaTonTai = true;
                    break;
                }
            }

            if (!KT_DocGiaTonTai)
            {
                return;
            }

            // Kiểm tra tất cả chi tiết hóa đơn
            bool KT_TatCaHopLe = true;
            for (int i = 0; i < hd.ChiTiet.Count; i++)
            {
                ChiTietHoaDonMuaSach ct = hd.ChiTiet[i];
                
                // Tìm sách
                Sach sach = null;
                for (int j = 0; j < danhSachSach.Count; j++)
                {
                    if (danhSachSach[j].MaSach == ct.MaSach)
                    {
                        sach = danhSachSach[j];
                        break;
                    }
                }

                // Kiểm tra sách tồn tại
                if (sach == null)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra số lượng
                if (ct.SoLuong <= 0 || ct.SoLuong > sach.SoLuongTon)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra đơn giá (tối thiểu 10% lợi nhuận)
                double GiaToiThieu = sach.GiaNhap * 1.1;
                if (ct.DonGia < GiaToiThieu - 0.01)
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
                    ChiTietHoaDonMuaSach ct = hd.ChiTiet[i];
                    for (int j = 0; j < danhSachSach.Count; j++)
                    {
                        if (danhSachSach[j].MaSach == ct.MaSach)
                        {
                            danhSachSach[j].SoLuongTon = danhSachSach[j].SoLuongTon - ct.SoLuong;
                            break;
                        }
                    }
                }
                danhSachHD.Add(hd);
            }
        }

        public DocGia ThongKeDocGiaMuaNhieuNhat(int thang, int nam)
        {
            // Tạo các danh sách để lưu mã độc giả và tổng tiền tương ứng
            List<string> Lst_MaDG = new List<string>();
            List<double> Lst_TongTien = new List<double>();

            // Tính tổng tiền cho mỗi độc giả
            for (int i = 0; i < danhSachHD.Count; i++)
            {
                HoaDonMuaSach hd = danhSachHD[i];
                
                // Kiểm tra tháng và năm
                if (hd.NgayMua.Month == thang && hd.NgayMua.Year == nam)
                {
                    // Tính tổng tiền chi tiết
                    double TongTienChiTiet = 0;
                    for (int j = 0; j < hd.ChiTiet.Count; j++)
                    {
                        ChiTietHoaDonMuaSach ct = hd.ChiTiet[j];
                        TongTienChiTiet = TongTienChiTiet + (ct.DonGia * ct.SoLuong);
                    }

                    // Tìm loại độc giả để lấy chiết khấu
                    string LoaiDG = "";
                    for (int k = 0; k < danhSachDG.Count; k++)
                    {
                        if (danhSachDG[k].MaDG == hd.MaDG)
                        {
                            LoaiDG = danhSachDG[k].LoaiDG;
                            break;
                        }
                    }

                    // Tính tiền thanh toán thực tế
                    double ChietKhau = 0;
                    if (chietKhauTheoLoai.ContainsKey(LoaiDG))
                    {
                        ChietKhau = chietKhauTheoLoai[LoaiDG];
                    }
                    double TienThanhToanThucTe = TongTienChiTiet * (1 - ChietKhau);

                    // Cộng vào tổng của độc giả
                    int ViTri = -1;
                    for (int k = 0; k < Lst_MaDG.Count; k++)
                    {
                        if (Lst_MaDG[k] == hd.MaDG)
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
                        Lst_MaDG.Add(hd.MaDG);
                        Lst_TongTien.Add(TienThanhToanThucTe);
                    }
                }
            }

            // Nếu không có hóa đơn nào
            if (Lst_MaDG.Count == 0)
            {
                return null;
            }

            // Tìm độc giả có tổng tiền cao nhất
            string MaDGMax = "";
            double TienMax = 0;
            bool DauTien = true;

            for (int i = 0; i < Lst_MaDG.Count; i++)
            {
                if (DauTien || Lst_TongTien[i] > TienMax)
                {
                    TienMax = Lst_TongTien[i];
                    MaDGMax = Lst_MaDG[i];
                    DauTien = false;
                }
            }

            // Trả về đối tượng độc giả
            for (int i = 0; i < danhSachDG.Count; i++)
            {
                if (danhSachDG[i].MaDG == MaDGMax)
                {
                    return danhSachDG[i];
                }
            }

            return null;
        }
    }
}
