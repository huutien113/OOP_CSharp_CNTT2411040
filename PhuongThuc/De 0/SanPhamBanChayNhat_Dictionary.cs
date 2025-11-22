using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication3;
using KTGK_CSharp;

namespace OOP_CSharp
{
    partial class QuanLyCuaHang
    {
        public List<SanPham> SanPhamBanChayNhat_Dictionary(int topCount)
        {
            List<SanPham> Lst_Top = new List<SanPham>();
            if (DanhSachSP.Count == 0 || topCount <= 0)
            {
                return null;
            }

            Dictionary<int, int> Dict_SoLuongBan = new Dictionary<int, int>();

            for (int i = 0; i < DanhSachHD.Count; i++)
            {
                for (int j = 0; j < DanhSachHD[i].ChiTiet.Count; j++)
                {
                    int MaSP = DanhSachHD[i].ChiTiet[j].MaSP;
                    int SoLuongBan = DanhSachHD[i].ChiTiet[j].SoLuongBan;

                    if (Dict_SoLuongBan.ContainsKey(MaSP))
                    {
                        Dict_SoLuongBan[MaSP] += SoLuongBan;
                    }
                    else
                    {
                        Dict_SoLuongBan[MaSP] = SoLuongBan;
                    }
                }
            }

            if (Dict_SoLuongBan.Count == 0)
            {
                return null;
            }

            List<int> Lst_MaSP = new List<int>();
            List<int> Lst_SoLuongBan = new List<int>();

            foreach (int MaSP in Dict_SoLuongBan.Keys)
            {
                Lst_MaSP.Add(MaSP);
                Lst_SoLuongBan.Add(Dict_SoLuongBan[MaSP]);
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
