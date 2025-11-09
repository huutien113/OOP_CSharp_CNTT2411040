using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ZeroException:Exception
    {
        public ZeroException() : base("Input value must be not zero") 
        { }
    }

    internal class OverValueException : Exception
    {
        public OverValueException() : base("Input value must be in 0..10")
        { }
    }

}
