using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyCuaHang
    {
        public List<SanPham> SanPhamBanChayNhat(int topCount)
        {
            List<SanPham> Lst_Top = new List<SanPham>();
            if (DanhSachSP.Count == 0 || topCount <= 0)
            {
                return Lst_Top;
            }

            // Tính tổng số lượng bán cho từng sản phẩm
            List<int> Lst_MaSP = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                for (int j = 0; j < DanhSachHD[i].ChiTiet.Count; j++)
                {
                    int maSP = DanhSachHD[i].ChiTiet[j].MaSP;
                    int soLuongBan = DanhSachHD[i].ChiTiet[j].SoLuongBan;

                    int viTri = -1;
                    for (int k = 0; k < Lst_MaSP.Count; k++)
                    {
                        if (Lst_MaSP[k] == maSP)
                        {
                            viTri = k;
                            break;
                        }
                    }

                    if (viTri != -1)
                    {
                        Lst_SoLuongBan[viTri] += soLuongBan;
                    }
                    else
                    {
                        Lst_MaSP.Add(maSP);
                        Lst_SoLuongBan.Add(soLuongBan);
                    }
                }
            }

            if (Lst_MaSP.Count == 0)
            {
                return Lst_Top;
            }

            // Sắp xếp theo số lượng bán giảm dần (bubble sort)
            for (int i = 0; i < Lst_MaSP.Count - 1; i++)
            {
                for (int j = i + 1; j < Lst_MaSP.Count; j++)
                {
                    if (Lst_SoLuongBan[i] < Lst_SoLuongBan[j])
                    {
                        // Swap số lượng bán
                        int tempSL = Lst_SoLuongBan[i];
                        Lst_SoLuongBan[i] = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = tempSL;

                        // Swap mã sản phẩm
                        int tempMa = Lst_MaSP[i];
                        Lst_MaSP[i] = Lst_MaSP[j];
                        Lst_MaSP[j] = tempMa;
                    }
                }
            }

            // Lấy top N số lượng bán cao nhất (tương tự Lst_Luong trong GetTopHighestPaid)
            List<int> Lst_SoLuong = new List<int>();
            for (int i = 0; i < Lst_MaSP.Count; i++)
            {
                bool Kt = true;
                
                for (int j = 0; j < Lst_SoLuong.Count; j++)
                {
                    if (Lst_SoLuongBan[i] == Lst_SoLuong[j])
                    {
                        Kt = false;
                        break;
                    }
                }
                
                if (Kt == true)
                {
                    Lst_SoLuong.Add(Lst_SoLuongBan[i]);
                }

                if (Lst_SoLuong.Count >= topCount)
                {
                    break;
                }
            }

            int soLuongMin = Lst_SoLuong[Lst_SoLuong.Count - 1];

            // Trả về tất cả sản phẩm có số lượng bán >= soLuongMin
            for (int i = 0; i < Lst_MaSP.Count; i++)
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
