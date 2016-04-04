using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {

        public SymmetricMatrix(int width) : base(width)
        {
        }

        public SymmetricMatrix(T[,] matrix):base(matrix)
        {
            for (int i = 0; i < Width; i++)
                for (int j = i; j < Width; j++)
                {
                    if (!matrixArray[i, j].Equals(matrixArray[j, i]))
                        throw new ArgumentException("");
                }
        }

        public override Matrix<T> Transpose()
        {
            return new SquareMatrix<T>(matrixArray);
        }

        protected override T GetElement(int indexX, int indexY)
        {
            return matrixArray[indexX, indexY];
        }

        protected override void SetElement(T value, int indexX, int indexY)
        {
            matrixArray[indexX, indexY] = value;
            matrixArray[indexY, indexX] = value;
        }
    }
}
