using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test.TestCase
{
    class StringTestCase : ITestCase<string>
    {
        public Comparison<string> Comparison()
        {
            return (x, y) => x.Length.CompareTo(y.Length);
        }

        public IEnumerable<string> GetList(Random random)
        {
            for (int i = 0; i < 10; i++)
            {
                string temp = "";
                for (int j = 0; j < random.Next(20); j++)
                    temp += (char)random.Next(50, 100);
                yield return temp;
            }
        }
    }
}
