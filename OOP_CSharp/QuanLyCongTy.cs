using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace OOP_CSharp
{
    class QuanLyCongTy
    {
        List<NhanVien> NV = new List<NhanVien>();

        public void ThemNhanVien()
        {
            Console.Write("Nhập lựa chọn nhân viên cần thêm (1) Biên chế; (2) Hợp đồng: ");
            string LuaChon = Console.ReadLine();
            if (LuaChon == "1")
            {
                NhanVienBienChe a = new NhanVienBienChe();
                a.NhapThongTin();
                NV.Add(a);
            }
            else if (LuaChon=="2")
            {
                NhanVienHopDong a = new NhanVienHopDong();
                a.NhapThongTin();
                NV.Add(a);
            }
            else 
            {
                Console.WriteLine("Nhập sai");
            }

        }

        public void HienThiBangLuong()
        {
            for (int i = 0; i < NV.Count; i++)
            {
                NV[i].HienThiThongTin();
                Console.WriteLine($"Lương tổng: {NV[i].TinhLuong()}");
                Console.WriteLine("------------------------------------------------");
            }    
        }

        public double TinhTongQuyLuong()
        {
            double TongQuyLuong = 0;
            for (int i = 0;i < NV.Count;i++)
            {
                TongQuyLuong = TongQuyLuong + NV[i].TinhLuong();
            }    
            return TongQuyLuong;
        }

        public double TinhTongSoGio()
        {
            double TongSoGio = 0;
            for (int i = 0; i < NV.Count; i++)
            {
                if (NV[i] is NhanVienHopDong)
                {
                    NhanVienHopDong a = NV[i] as NhanVienHopDong;
                    TongSoGio = TongSoGio + a.SoGioLamViec;
                }    
            }
            return (TongSoGio);
            }

        public void LuongCaoNhat()
        {
            int max = 0;  
            for (int i = 0;i<NV.Count;i++)
            {
                if (NV[i].TinhLuong()  > NV[max].TinhLuong())
                {
                    max = i;
                }    
            }
            if (NV.Count == 0)
                Console.WriteLine("Ko có nhân viên");
            else
            {
                Console.WriteLine($"Nhân viên có lương cao nhất là: ");
                NV[max].HienThiThongTin();
                Console.WriteLine($"Lương tổng: {NV[max].TinhLuong()}");
            }
                
            
        }

    }
}
