using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    class PS
    {
        public int tu;
        public int mau;

        public int Tu { get => tu; set => tu = value; }
        public int Mau
        {
            get => mau;
            set
            {
                if (value > 0)
                    mau = value;
            }
        }

        public PS(int tu = 1, int mau = 1)
        {
            this.tu = tu;
            this.mau = mau;
            RutGon();
        }


        public void RutGon()
        {
            int a = Math.Abs(Tu);
            int b = Math.Abs(Mau);

            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }

            Tu = Tu / a;
            Mau = Mau / a;

            if (mau < 0)
            {
                Tu = -Tu;
                Mau = -Mau;
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"{Tu}/{Mau}");
        }

        public static PS operator +(PS a, PS b)
        {
            int t = (a.Tu * b.Mau) + (a.Mau * b.Tu);
            int m = a.Mau * b.Mau;
            return new PS(t, m);
        }

        public static PS operator -(PS a, PS b)
        {
            int t = (a.Tu * b.Mau) - (a.Mau * b.Tu);
            int m = a.Mau * b.Mau;
            return new PS(t, m);
        }

        public static PS operator *(PS a, PS b)
        {
            int t = (a.Tu * b.Tu);
            int m = (a.Mau * b.Mau);
            return new PS(t, m);
        }

        public static PS operator /(PS a, PS b)
        {
            if (b.Tu == 0)
            {
                Console.WriteLine("Phân số ko hợp lệ");
                return null;
            }
            else
            {

                int t = (a.Tu * b.Mau);
                int m = (a.Mau * b.Tu);
                return new PS(t, m);
            }
        }

        public static bool operator == (PS a, PS b)
        {
            return a.Tu == b.Tu && a.Mau == b.Mau;
        }

        public static bool operator != (PS a, PS b)
        {
            return !(a == b);
        }

        public static bool operator > (PS a, PS b)
        {
            return (a.Tu * b.Mau > a.Mau * b.Tu); 
        }

        public static bool operator < (PS a, PS b)
        {
            return (a.Tu * b.Mau < a.Mau * b.Tu);
        }

        public static bool operator >= (PS a, PS b)
        {
            return (a.Tu * b.Mau >= a.Mau * b.Tu);
        }

        public static bool operator <= (PS a, PS b)
        {
            return (a.Tu * b.Mau <= a.Mau * b.Tu);
        }

        public static implicit operator PS(int a)
        {
            return new PS(a);
        }

        public static explicit operator double(PS a)
        {
            return (double)a.Tu / a.Mau;
        }

    }
}
