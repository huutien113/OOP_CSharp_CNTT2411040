using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class CB: CBVC
    {
        string phong;
        public string Phong
        {
            get
            {
                return phong;
            }
            set
            {
                phong = value;
            }
        }

        public CB()
        { 
        }

        public CB(string Phong):this()
        {
            phong = Phong;
        }

        public CB(string Phong, string HoTen):base(HoTen)
        {
            phong = Phong;
        }

        public CB(string Phong, string HoTen, int NamSinh):base(HoTen, NamSinh)
        {
            phong = Phong;
        }

        public void GioiThieu()
        {
            base.GioiThieu();
            Console.WriteLine($"{Phong}");
        }
    }
}
