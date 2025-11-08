using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class GV:CBVC
    {
        string khoa;

        public string Khoa
        {
            get 
            {
                return khoa;
            }
            set
            {
                khoa = value;
            }
        }

        public GV()
        { }
        public GV(string Khoa):this()
        {
            khoa=Khoa;
        }

        public GV(string Khoa, string HoTen):base(HoTen)
        {
            khoa=Khoa;
        }

        public GV(string Khoa, string HoTen, int NamSinh):base(HoTen, NamSinh)
        {
            khoa = Khoa;
        }

        public override void GioiThieu()
        {
            base.GioiThieu();
            Console.WriteLine($"{Khoa}");
        }
    }
}
