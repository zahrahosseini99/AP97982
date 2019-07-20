using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P1
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


        public static void MiniDeterminant(SquareMatrix<double> mat,
                            SquareMatrix<double> temp,
                            int p,
                            int q,
                            int n)
        {
            int i = 0, j = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {

                    if (row != p && col != q)
                    {
                        temp[i, j++] = mat[row, col];


                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }
        public static double determinantOfMatrix(SquareMatrix<double> mat,
                                   int n)
        {
            double D = 0;
            if (n == 1)
                return mat[0, 0];


            SquareMatrix<double> temp = new SquareMatrix<double>(mat.ColumnCount);


            double sign = 1;


            for (int f = 0; f < n; f++)
            {
                MiniDeterminant(mat, temp, 0, f, n);
                D += sign * mat[0, f]
                * determinantOfMatrix(temp, n - 1);

                sign = -sign;
            }

            return D;
        }
        public static void Adjugate(SquareMatrix<double> mat, SquareMatrix<double> adj)
        {
            if (mat.RowCount == 1)
            {
                adj[0][0] = 1;

            }
            double sign = 1;
            SquareMatrix<double> temp = new SquareMatrix<double>(mat.RowCount);

            for (int i = 0; i < mat.RowCount; i++)
            {
                for (int j = 0; j < mat.RowCount; j++)
                {

                    MiniDeterminant(mat, temp, i, j, mat.RowCount);

                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    adj[j][i] = (sign) * (determinantOfMatrix(temp, mat.RowCount - 1));
                }
            }
        }
        public  Matrix<double> inverse(SquareMatrix<double> mat, Matrix<double> inverse)
        {
           
            double det = determinantOfMatrix(mat, mat.RowCount);
            if(determinantOfMatrix( mat, mat.RowCount) == 0)
            {
                throw new Exception("No solution");
            }
          
            SquareMatrix<double> adj = new SquareMatrix<double>(mat.RowCount);
            Adjugate(mat, adj);
        inverse = new SquareMatrix<double>(mat.RowCount);
            //inverse(A) = adj(A)/det(A)" 
            for (int i = 0; i < mat.RowCount; i++)
                for (int j = 0; j < mat.RowCount; j++)
                    inverse[i][j] = adj[i][j] * (1 / (det));

            return inverse;
        }
    }
}