using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Matrix
{
    public abstract class Matrix<T>
    {
        public int Width { get; }

        public event EventHandler<CellEventArgs<T>> CellChanged = delegate {};

        protected Matrix(int width)
        {
            if (width < 0)
                throw new ArgumentException("", nameof(width));
            Width = width;
        }

        protected Matrix()
        {
        }

        public abstract IEnumerable<T> GetRow(int index);
        public abstract IEnumerable<T> GetColumn(int index);

        public T this[int indexX, int indexY]
        {
            get
            {
                if (indexX < 0 || indexX > Width - 1)
                    throw new IndexOutOfRangeException("");
                if (indexY < 0 || indexY > Width - 1)
                    throw new IndexOutOfRangeException("");
                return GetElement(indexX, indexY);
            }
            set
            {
                if (indexX < 0 || indexX > Width - 1)
                    throw new IndexOutOfRangeException("");
                if (indexY < 0 || indexY > Width - 1)
                    throw new IndexOutOfRangeException("");
                T temp = GetElement(indexX, indexY);
                SetElement(value, indexX, indexY);
                OnCellChanged(new CellEventArgs<T>() { i = indexX, j = indexY, prevValue = temp, currentValue = value });
            }
        }

        public abstract Matrix<T> Transpose();

        protected virtual void OnCellChanged(CellEventArgs<T> e)
        {
            if (CellChanged != null)
                CellChanged(this, e);
        }

        protected abstract T GetElement(int indexX, int indexY);
        protected abstract void SetElement(T value, int indexX, int indexY);
    }
}
