using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class Matrix<_Type> :
        IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;

        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;

        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>

        public Matrix(IEnumerable<Vector<_Type>> rows)
        {
            int i = 0;
            Vector<_Type>[] R = new Vector<_Type>[rows.Count()];
            foreach (var d in rows)
            {
                R[i] = d;
                i++;
            }
            Rows = R;
        }

        public void Add(Vector<_Type> row)
        {


            Rows[RowAddIndex++] = row;


        }


        public Vector<_Type> this[int index]
        {
            get
            {
                return this.Rows[index];
            }
            set
            {
                Vector<_Type>[] v = this.Rows;
                v[index] = value;

            }
        }


        public _Type this[int row, int col]
        {

            get
            {
                return Rows[row][col];
            }
            set
            {
                Rows[row][col] = value;

            }
        }
        public override string ToString()
        {
            string res = "[";
            foreach (Vector<_Type> v in Rows)
            {
                res += "\n" + "[";
                foreach (_Type m in v)
                {
                    res += m + ",";
                }
                res = res.TrimEnd(',') + "]";
            }
            res += "\n" + "]";
            return res;
        }
        ///// <summary>
        ///// overloading + operator for the class Matrix customly
        ///// </summary>
        ///// <param name="m1">right hand side operand (type : matrix)</param>
        ///// <param name="m2">left hand side operand (type : matrix)</param>
        ///// <returns>a matrix as result of the sum</returns>
        //public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        //{

        //}

        ///// <summary>
        ///// overloading * operator for matrix class
        ///// </summary>
        ///// <param name="m1">RHS of the operator</param>
        ///// <param name="m2">LHS of the operator</param>
        ///// <returns></returns>
        //public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        //{

        //}

        ///// <summary>
        ///// Get an enumerator that enumerates over elements in a column
        ///// </summary>
        ///// <param name="col"></param>
        ///// <returns>IEnumerable</returns>
        //protected IEnumerable<_Type> GetColumnEnumerator(int col)
        //{
        //}

        //protected Vector<_Type> GetColumn(int col) =>
        //    new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            if (other == null)
                return false;

            if (this.Rows == other.Rows)
                return true;
            else
                return false;
        }

        //public override bool Equals(object obj)
        //{
        //}

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            foreach (Vector<_Type> d in Rows)
            {
                yield return d;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}