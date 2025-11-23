using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTGK_CSharp;

namespace OOP_CSharp
{
    public class QuanLyCuaHang
    {
        //MSSV: CNTT2411040
        //Họ tên: Huỳnh Hữu Tiến
        //Đề: 0
        private List<SanPham> danhSachSP;
        private List<KhachHang> danhSachKH;
        private List<HoaDon> danhSachHD;
        private Dictionary<string, double> chietKhauTheoLoai;

        public List<SanPham> DanhSachSP { get => danhSachSP; set => danhSachSP = value; }
        public List<KhachHang> DanhSachKH { get => danhSachKH; set => danhSachKH = value; }
        public List<HoaDon> DanhSachHD { get => danhSachHD; set => danhSachHD = value; }
        public Dictionary<string, double> ChietKhauTheoLoai { get => chietKhauTheoLoai; set => chietKhauTheoLoai = value; }

    }
}
