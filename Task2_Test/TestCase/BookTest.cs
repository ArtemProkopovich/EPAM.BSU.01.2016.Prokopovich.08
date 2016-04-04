using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Test.TestCase
{
    
    class BookTestCase : ITestCase<Book>
    {
        public Comparison<Book> Comparison()
        {
            return (x, y) => x.Author.CompareTo(y.Author);
        }

        private string RandomString(Random random)
        {
            string temp = "";
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < random.Next(20); j++)
                    temp += (char)random.Next(50, 100);

            }
            return temp;
        }

        public IEnumerable<Book> GetList(Random random)
        {
            for (int i = 0; i < 10; i++)

                yield return
                    new Book()
                    {
                        Name = RandomString(random),
                        Author = RandomString(random),
                        PageNumber = random.Next(100)
                    };
        }
    }
}
