using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test.TestCase
{
    public interface ITestCase<T>
    {
        IEnumerable<T> GetList(Random random);
        Comparison<T> Comparison();
    }
}
