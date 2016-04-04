using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test.TestCase
{
    class PointTestCase : ITestCase<Point>
    {
        public Comparison<Point> Comparison()
        {
            return (x, y) => x.X.CompareTo(y.X);
        }

        public IEnumerable<Point> GetList(Random random)
        {
            for (int i = 0; i < 10; i++)
                yield return new Point(random.Next(100), random.Next(100));
        }
    }
}
