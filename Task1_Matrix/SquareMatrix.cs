using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        protected T[,] matrixArray;

        public SquareMatrix(int width) : base(width)
        {
            matrixArray = new T[Width, Width];
        }

        public SquareMatrix(T[,] matrix):this(matrix.GetLength(0))
        {
            if (matrix == null)
                throw new NullReferenceException("");
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("");
            matrixArray = new T[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i=0;i<matrix.GetLength(0);i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixArray[i, j] = matrix[i, j];
                }
        }


        public override Matrix<T> Transpose()
        {
            T[,] resultArray = new T[Width, Width];
            for (int i=0;i<Width;i++)
                for (int j = 0; j < Width; j++)
                    resultArray[i, j] = matrixArray[j, i];
            
            return new SquareMatrix<T>(resultArray);
        }

        protected override T GetElement(int indexX, int indexY)
        {
            return matrixArray[indexX, indexY];
        }

        protected override void SetElement(T value, int indexX, int indexY)
        {
            matrixArray[indexX, indexY] = value;
        }
    }
}
