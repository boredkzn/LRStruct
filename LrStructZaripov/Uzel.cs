using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LrStructZaripov
{
    public class Uzel
    {
        public int Data { get; set; }

        public Uzel Next { get; set; }

        public Uzel Prev { get; set; } 

        public Uzel(int data)
        {
            Data = data;
            Next = this;
            Prev = this;
        }
    }
}
