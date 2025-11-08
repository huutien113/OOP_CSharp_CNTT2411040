using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_CSharp
{
    internal class DiemXY
    {
        int x, y;
        public DiemXY(int ox = 0, int oy = 0)
        {
            x = ox;
            y = oy;
        }
        public void nhap()
        {
            x = int.Parse(Console.ReadLine());
            y = int.Parse(Console.ReadLine());
        }
        public void move(int dx,  int dy)
        {
            x = x + dx;
            y = y + dy;
        }
        public void hien()
        {
            Console.WriteLine($"Tọa độ: ({x},{y})");
        }
        public void chuyen()
        {
            x = -x;
            y = -y;
        }
    }
}
