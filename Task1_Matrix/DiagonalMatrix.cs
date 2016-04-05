using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
    {

        private readonly T[] diagonalArray;

        public DiagonalMatrix(int width) : base(width)
        {
            diagonalArray = new T[Width];
        }

        public DiagonalMatrix(T[] diagonal) : this(diagonal.Length)
        {
            if (diagonal == null)
                throw new NullReferenceException("");
            diagonalArray = new T[diagonal.Length];
            for (int i = 0; i < diagonal.Length; i++)
                diagonalArray[i] = diagonal[i];
        }

        public override Matrix<T> Transpose()
        {
            return new DiagonalMatrix<T>(diagonalArray);
        }

        protected override T GetElement(int indexX, int indexY)
        {
            if (indexX == indexY)
                return diagonalArray[indexX];
            else
                return default(T);
        }

        protected override void SetElement(T value, int indexX, int indexY)
        {
            if (indexX == indexY)
                diagonalArray[indexX] = value;
            else
                throw new InvalidOperationException("");
        }
    }
}
