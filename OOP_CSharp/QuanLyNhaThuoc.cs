using System;
using System.Collections.Generic;
using KTGK_CSharp;

namespace OOP_CSharp
{
    public class QuanLyNhaThuoc
    {
        private List<Thuoc> danhSachThuoc;
        private List<BenhNhan> danhSachBN;
        private List<DonThuoc> danhSachDT;
        private Dictionary<string, double> chietKhauTheoLoai;

        public QuanLyNhaThuoc()
        {
            danhSachThuoc = new List<Thuoc>();
            danhSachBN = new List<BenhNhan>();
            danhSachDT = new List<DonThuoc>();
            chietKhauTheoLoai = new Dictionary<string, double>();
            chietKhauTheoLoai["VIP"] = 0.10;
            chietKhauTheoLoai["Thuong"] = 0.05;
            chietKhauTheoLoai["Moi"] = 0.00;
        }

        public void ThemThuoc(Thuoc t)
        {
            danhSachThuoc.Add(t);
        }

        public void ThemBenhNhan(BenhNhan bn)
        {
            danhSachBN.Add(bn);
        }

        public void CapNhatSoLuongTon(int maThuoc, int soLuongNhapThem)
        {
            for (int i = 0; i < danhSachThuoc.Count; i++)
            {
                if (danhSachThuoc[i].MaThuoc == maThuoc)
                {
                    danhSachThuoc[i].SoLuongTon = danhSachThuoc[i].SoLuongTon + soLuongNhapThem;
                    return;
                }
            }
        }

        public List<Thuoc> TimKiemThuocTheoNhaSanXuat(string nhaSanXuat)
        {
            List<Thuoc> Lst_KetQua = new List<Thuoc>();
            for (int i = 0; i < danhSachThuoc.Count; i++)
            {
                if (danhSachThuoc[i].NhaSanXuat.ToLower() == nhaSanXuat.ToLower())
                {
                    Lst_KetQua.Add(danhSachThuoc[i]);
                }
            }
            return Lst_KetQua;
        }

        public void ThemDonThuoc(DonThuoc dt)
        {
            // Kiểm tra mã bệnh nhân tồn tại
            bool KT_BenhNhanTonTai = false;
            for (int i = 0; i < danhSachBN.Count; i++)
            {
                if (danhSachBN[i].MaBN == dt.MaBN)
                {
                    KT_BenhNhanTonTai = true;
                    break;
                }
            }

            if (!KT_BenhNhanTonTai)
            {
                return;
            }

            // Kiểm tra tất cả chi tiết đơn thuốc
            bool KT_TatCaHopLe = true;
            for (int i = 0; i < dt.ChiTiet.Count; i++)
            {
                ChiTietDonThuoc ct = dt.ChiTiet[i];
                
                // Tìm thuốc
                Thuoc thuoc = null;
                for (int j = 0; j < danhSachThuoc.Count; j++)
                {
                    if (danhSachThuoc[j].MaThuoc == ct.MaThuoc)
                    {
                        thuoc = danhSachThuoc[j];
                        break;
                    }
                }

                // Kiểm tra thuốc tồn tại
                if (thuoc == null)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra số lượng
                if (ct.SoLuong <= 0 || ct.SoLuong > thuoc.SoLuongTon)
                {
                    KT_TatCaHopLe = false;
                    break;
                }

                // Kiểm tra đơn giá (tối thiểu 10% lợi nhuận)
                double GiaToiThieu = thuoc.GiaNhap * 1.1;
                if (ct.DonGia < GiaToiThieu - 0.01)
                {
                    KT_TatCaHopLe = false;
                    break;
                }
            }

            // Nếu tất cả hợp lệ, cập nhật tồn kho và thêm đơn thuốc
            if (KT_TatCaHopLe)
            {
                for (int i = 0; i < dt.ChiTiet.Count; i++)
                {
                    ChiTietDonThuoc ct = dt.ChiTiet[i];
                    for (int j = 0; j < danhSachThuoc.Count; j++)
                    {
                        if (danhSachThuoc[j].MaThuoc == ct.MaThuoc)
                        {
                            danhSachThuoc[j].SoLuongTon = danhSachThuoc[j].SoLuongTon - ct.SoLuong;
                            break;
                        }
                    }
                }
                danhSachDT.Add(dt);
            }
        }

        public BenhNhan ThongKeBenhNhanChiTieuNhieuNhat(int thang, int nam)
        {
            // Tạo các danh sách để lưu mã bệnh nhân và tổng tiền tương ứng
            List<string> Lst_MaBN = new List<string>();
            List<double> Lst_TongTien = new List<double>();

            // Tính tổng tiền cho mỗi bệnh nhân
            for (int i = 0; i < danhSachDT.Count; i++)
            {
                DonThuoc dt = danhSachDT[i];
                
                // Kiểm tra tháng và năm
                if (dt.NgayKe.Month == thang && dt.NgayKe.Year == nam)
                {
                    // Tính tổng tiền chi tiết
                    double TongTienChiTiet = 0;
                    for (int j = 0; j < dt.ChiTiet.Count; j++)
                    {
                        ChiTietDonThuoc ct = dt.ChiTiet[j];
                        TongTienChiTiet = TongTienChiTiet + (ct.DonGia * ct.SoLuong);
                    }

                    // Tìm loại bệnh nhân để lấy chiết khấu
                    string LoaiBN = "";
                    for (int k = 0; k < danhSachBN.Count; k++)
                    {
                        if (danhSachBN[k].MaBN == dt.MaBN)
                        {
                            LoaiBN = danhSachBN[k].LoaiBN;
                            break;
                        }
                    }

                    // Tính tiền thanh toán thực tế
                    double ChietKhau = 0;
                    if (chietKhauTheoLoai.ContainsKey(LoaiBN))
                    {
                        ChietKhau = chietKhauTheoLoai[LoaiBN];
                    }
                    double TienThanhToanThucTe = TongTienChiTiet * (1 - ChietKhau);

                    // Cộng vào tổng của bệnh nhân
                    int ViTri = -1;
                    for (int k = 0; k < Lst_MaBN.Count; k++)
                    {
                        if (Lst_MaBN[k] == dt.MaBN)
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
                        Lst_MaBN.Add(dt.MaBN);
                        Lst_TongTien.Add(TienThanhToanThucTe);
                    }
                }
            }

            // Nếu không có đơn thuốc nào
            if (Lst_MaBN.Count == 0)
            {
                return null;
            }

            // Tìm bệnh nhân có tổng tiền cao nhất
            string MaBNMax = "";
            double TienMax = 0;
            bool DauTien = true;

            for (int i = 0; i < Lst_MaBN.Count; i++)
            {
                if (DauTien || Lst_TongTien[i] > TienMax)
                {
                    TienMax = Lst_TongTien[i];
                    MaBNMax = Lst_MaBN[i];
                    DauTien = false;
                }
            }

            // Trả về đối tượng bệnh nhân
            for (int i = 0; i < danhSachBN.Count; i++)
            {
                if (danhSachBN[i].MaBN == MaBNMax)
                {
                    return danhSachBN[i];
                }
            }

            return null;
        }
    }
}
