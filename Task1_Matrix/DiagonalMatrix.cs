using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public class DiagonalMatrix<T> : Matrix<T>
    {

        private T[] diagonalArray;

        public DiagonalMatrix(int width) : base(width)
        {
            diagonalArray = new T[Width];
        }

        public DiagonalMatrix(T[] diagonal)
        {
            if (diagonal == null)
                throw new NullReferenceException("");
            diagonalArray = new T[diagonal.Length];
            for (int i = 0; i < diagonal.Length; i++)
                diagonalArray[i] = diagonal[i];
        }

        public override IEnumerable<T> GetColumn(int index)
        {
            if (index < 0 || index > Width - 1)
                throw new ArgumentOutOfRangeException("");
            for (int i = 0; i < Width; i++)
            {
                if (i == index)
                    yield return diagonalArray[index];
                else
                    yield return default(T);
            }
        }

        public override IEnumerable<T> GetRow(int index)
        {
            return GetColumn(index);
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
