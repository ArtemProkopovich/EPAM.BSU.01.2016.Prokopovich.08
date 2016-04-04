using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public static class MatrixExtension
    {
        public static Matrix<T> Add<T>(Matrix<T> lhs, Matrix<T> rhs, Func<T, T, T> addFunction)
        {
            if (lhs == null)
                throw new ArgumentNullException();
            if (rhs == null)
                throw new ArgumentNullException();
            if (addFunction == null)
                throw new ArgumentNullException();
            if (lhs.Width != rhs.Width)
                throw new ArgumentException("");
            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Width);
            for (int i = 0; i < lhs.Width; i++)
                for (int j = 0; j < rhs.Width; j++)
                    result[i, j] = addFunction(lhs[i, j], rhs[i, j]);

            return result;
        }
    }
}
