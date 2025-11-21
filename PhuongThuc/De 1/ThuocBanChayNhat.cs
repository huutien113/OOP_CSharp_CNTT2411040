using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyNhaThuoc
    {
        public List<Thuoc> ThuocBanChayNhat(int topCount)
        {
            List<Thuoc> Lst_Top = new List<Thuoc>();
            if (DanhSachThuoc.Count == 0 || topCount <= 0)
            {
                return Lst_Top;
            }

            // Tính tổng số lượng bán cho từng thuốc
            List<int> Lst_MaThuoc = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachDT.Count; i++)
            {
                for (int j = 0; j < DanhSachDT[i].ChiTiet.Count; j++)
                {
                    int maThuoc = DanhSachDT[i].ChiTiet[j].MaThuoc;
                    int soLuong = DanhSachDT[i].ChiTiet[j].SoLuong;

                    int viTri = -1;
                    for (int k = 0; k < Lst_MaThuoc.Count; k++)
                    {
                        if (Lst_MaThuoc[k] == maThuoc)
                        {
                            viTri = k;
                            break;
                        }
                    }

                    if (viTri != -1)
                    {
                        Lst_SoLuongBan[viTri] += soLuong;
                    }
                    else
                    {
                        Lst_MaThuoc.Add(maThuoc);
                        Lst_SoLuongBan.Add(soLuong);
                    }
                }
            }

            if (Lst_MaThuoc.Count == 0)
            {
                return Lst_Top;
            }

            // Sắp xếp theo số lượng bán giảm dần (bubble sort)
            for (int i = 0; i < Lst_MaThuoc.Count - 1; i++)
            {
                for (int j = i + 1; j < Lst_MaThuoc.Count; j++)
                {
                    if (Lst_SoLuongBan[i] < Lst_SoLuongBan[j])
                    {
                        // Swap số lượng bán
                        int tempSL = Lst_SoLuongBan[i];
                        Lst_SoLuongBan[i] = Lst_SoLuongBan[j];
                        Lst_SoLuongBan[j] = tempSL;

                        // Swap mã thuốc
                        int tempMa = Lst_MaThuoc[i];
                        Lst_MaThuoc[i] = Lst_MaThuoc[j];
                        Lst_MaThuoc[j] = tempMa;
                    }
                }
            }

            // Lấy top N số lượng bán cao nhất (tương tự Lst_Luong trong GetTopHighestPaid)
            List<int> Lst_SoLuong = new List<int>();
            for (int i = 0; i < Lst_MaThuoc.Count; i++)
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

            // Trả về tất cả thuốc có số lượng bán >= soLuongMin
            for (int i = 0; i < Lst_MaThuoc.Count; i++)
            {
                if (Lst_SoLuongBan[i] >= soLuongMin)
                {
                    for (int j = 0; j < DanhSachThuoc.Count; j++)
                    {
                        if (DanhSachThuoc[j].MaThuoc == Lst_MaThuoc[i])
                        {
                            Lst_Top.Add(DanhSachThuoc[j]);
                            break;
                        }
                    }
                }
            }

            return Lst_Top;
        }
    }
}
