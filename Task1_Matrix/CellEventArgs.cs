using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public class CellEventArgs<T>
    {
        public int i { get; set; }
        public int j { get; set; }
        public T prevValue { get; set; }
        public T currentValue { get; set; }
    }
}
