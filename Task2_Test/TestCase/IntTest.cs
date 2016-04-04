using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test.TestCase
{
    internal class IntTestCase : ITestCase<int>
    {
        public Comparison<int> Comparison()
        {
            return (x, y) => -x.CompareTo(y); ;
        }

        public IEnumerable<int> GetList(Random random)
        {
            for (int i = 0; i < 10; i++)
                yield return random.Next(100);
        }
    }
}
