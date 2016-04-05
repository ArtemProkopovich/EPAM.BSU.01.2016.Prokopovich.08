using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1_Matrix;

namespace Task1_Test
{
    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public void AddTwoSquareMatrixTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(new int[,] {{2, 2}, {2, 2}});
            SquareMatrix<int> sm2 = new SquareMatrix<int>(new int[,] { { 3, 3 }, { 3, 3 } });
            SquareMatrix<int> result = new SquareMatrix<int>(new int[,] { { 5, 5 }, { 5, 5 } });
            Matrix<int> r = MatrixExtension.Add(sm1, sm2);
            Assert.AreEqual(r[0, 0], result[0, 0]);
        }

        [Test]
        public void AddDiagonalAndSymmetricMatrixTest()
        {
            SymmetricMatrix<int> sm1 = new SymmetricMatrix<int>(new int[,] { { 2, 2 }, { 2, 2 } });
            DiagonalMatrix<int> sm2 = new DiagonalMatrix<int>(new int[] {3, 3});
            SymmetricMatrix<int> result = new SymmetricMatrix<int>(new int[,] { { 5, 3 }, { 3, 5 } });
            Matrix<int> r = MatrixExtension.Add(sm1, sm2);
            Assert.IsInstanceOf<SymmetricMatrix<int>>(r);
            Assert.AreEqual(r[0, 0], result[0, 0]);
            r = MatrixExtension.Add(sm2, sm1);
            Assert.IsInstanceOf<SymmetricMatrix<int>>(r);
            Assert.AreEqual(r[0, 0], result[0, 0]);
        }

        [Test]
        public void AddDiagonalAndDiagonalMatrixTest()
        {
            DiagonalMatrix<int> sm1 = new DiagonalMatrix<int>(new int[] {2, 2});
            DiagonalMatrix<int> sm2 = new DiagonalMatrix<int>(new int[] { 3, 3 });
            DiagonalMatrix<int> result = new DiagonalMatrix<int>(new int[] {5, 5});
            Matrix<int> r = MatrixExtension.Add(sm1, sm2);
            Assert.IsInstanceOf<DiagonalMatrix<int>>(r);
            Assert.AreEqual(r[0, 0], result[0, 0]);
        }
    }
}
