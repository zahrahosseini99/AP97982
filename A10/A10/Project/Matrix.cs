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
            this.Rows = new Vector<_Type>[RowCount];
            for (int i = 0; i < rowCount; i++)
            {
                this.Rows[i] = new Vector<_Type>(ColumnCount);
            }

        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>

        public Matrix(IEnumerable<Vector<_Type>> rows) : this(rows.Count(), rows.First().Count())
        {
            int i = 0;
            this.Rows = new Vector<_Type>[rows.Count()];
            this.Rows[i++] = new Vector<_Type>(rows.First().Count());
            foreach (Vector<_Type> d in rows)
            {
                if(d.Count()==rows.First().Count())
                Add(d);
            }

        }

        public void Add(Vector<_Type> row)
        {


            Rows[RowAddIndex++] = row;


        }


        public Vector<_Type> this[int index]
        {
            get
            {
                return Rows[index];
            }
            set
            {
                Rows[index] = value;
            }
        }


        public _Type this[int row, int col]
        {

            get
            {
                return this.Rows[row][col];
            }
            set
            {
                this.Rows[row][col] = value;

            }
        }
        public override string ToString()
        {
            string res = "[";
            foreach (Vector<_Type> v in Rows)
            {

                res += "\n" + v.ToString() + ",";

            }
            res = res.TrimEnd(',');
            res += "\n" + "]";
            return res;
        }
        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            Matrix<_Type> m3 = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);


            if ((m1.RowCount == m2.RowCount) && (m2.ColumnCount == m1.ColumnCount))
            {
                for (int i = 0; i < m1.RowCount; i++)
                {
                    m3.Rows[i] = m1.Rows[i] + m2.Rows[i];
                }
                return m3;
            }

            else
                throw new InvalidOperationException();

        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {

            Matrix<_Type> m3 = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
           
                if (m1.ColumnCount == m2.RowCount)
                {


                    for (int i = 0; i < m1.RowCount; i++)
                    {
                        for (int j = 0; j < m2.ColumnCount; j++)
                        {
                            dynamic res = 0;
                            for (int k = 0; k < m1.ColumnCount; k++)
                            {
                                dynamic n1 = m1[i][k];
                                dynamic n2 = m2[k][j];
                                res = res + n1 * n2;
                                m3[i][j] = res;
                            }
                        }
                    }

                }
            else
            {
                throw new InvalidOperationException();
                throw new IndexOutOfRangeException();
            }
                   
           


            return m3;


        }

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            for (int i = 0; i < RowCount; i++)
            {
                foreach (_Type d in Rows[i])
                {

                    yield return Rows[i][col];
                }
            }

        }

        protected Vector<_Type> GetColumn(int col) =>
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {

            int count = 0;
            if (other == null)
                return false;
            for (int i = 0; i < Rows.Length; i++)
            {
                foreach (_Type v in Rows[i])
                    if (this.Rows[i] == other.Rows[i])
                        count++;
            }
            return count == Rows.Length;
        }

        public override bool Equals(object obj)
        {
            int count = 0;
            Matrix<_Type> m = obj as Matrix<_Type>;
            if (m.Rows == null)
                return false;
            else
            {
                for (int i = 0; i < Rows.Length; i++)
                {
                    if (m.Rows[i].ToString() == this.Rows[i].ToString())
                    {
                        count++;
                    }
                }
            }

            return count == m.Rows.Length;
        }

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
        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            int count = 0;
            if (m1.RowCount == m2.RowCount && m2.Rows.Length==m1.Rows.Length)
            {
                for (int i = 0; i < m1.Rows.Length; i++)
                {
                    if (m1.Rows[i].ToString() == m2.Rows[i].ToString())
                        count++;
                }
                return (count == m1.Rows.Length);
            }
            else
                return false;

        }
        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            return !(m1 == m2);

        }

    }
}