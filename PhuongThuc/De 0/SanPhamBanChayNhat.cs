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
                return null;
            }

            List<int> Lst_MaSP = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            for (int i = 0; i < DanhSachHD.Count; i++)
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
