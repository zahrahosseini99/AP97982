using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(int rowCount) : base(rowCount, rowCount)
        {
        }
        public SquareMatrix(IEnumerable<Vector<_Type>> rows) : base(rows)
        {
        }
    }
}