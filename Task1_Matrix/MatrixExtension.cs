using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public static class MatrixExtension
    {
        public class MatrixOperationException : InvalidOperationException
        {
            public MatrixOperationException()
            {
            }

            public MatrixOperationException(string message) : base(message)
            {
            }

            public MatrixOperationException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected MatrixOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public static Matrix<T> Add<T>(Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs == null)
                throw new ArgumentNullException();
            if (rhs == null)
                throw new ArgumentNullException();
            if (lhs.Width != rhs.Width)
                throw new MatrixOperationException("");
            dynamic l = lhs;
            dynamic r = rhs;
            return AddMethod(l, r);
        }

        private static Matrix<T> AddMethod<T>(DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(lhs.Width);
            try
            {
                for (int i = 0; i < lhs.Width; i++)
                    result[i, i] = (dynamic) lhs[i, i] + (dynamic) rhs[i, i];
            }
            catch (Exception ex)
            {
                throw new MatrixOperationException("", ex);
            }
            return result;
        }

        private static Matrix<T> AddMethod<T>(SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Width);
            try
            {
                for (int i = 0; i < lhs.Width; i++)
                    for (int j = i; j < rhs.Width; j++)
                    {
                        result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
                    }
            }
            catch (Exception ex)
            {
                throw new MatrixOperationException("", ex);
            }
            return result;
        }

        private static Matrix<T> AddMethod<T>(DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            return AddMethod(rhs, lhs);
        }

        private static Matrix<T> AddMethod<T>(SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(lhs.Width);
            try
            {
                for (int i = 0; i < lhs.Width; i++)
                    for (int j = i; j < rhs.Width; j++)
                    {
                        result[i, j] = lhs[i, j];
                        if (i == j)
                            result[i, j] = (dynamic) lhs[i, j] + (dynamic) rhs[i, j];
                    }
            }
            catch (Exception ex)
            {
                throw new MatrixOperationException("", ex);
            }
            return result;
        }

        private static Matrix<T> AddMethod<T>(Matrix<T> lhs, Matrix<T> rhs)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Width);
            try
            {
                for (int i = 0; i < lhs.Width; i++)
                    for (int j = 0; j < rhs.Width; j++)
                        result[i, j] = (dynamic)lhs[i, j] + (dynamic)rhs[i, j];
            }
            catch (Exception ex)
            {
                throw new MatrixOperationException("", ex);
            }
            return result;
        }
    }
}
