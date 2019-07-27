using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix 
    {
        private double[,] M;
        private int n, m;

        public int lengthN
        {
            get { return n; }            
        }
        public int lengthM
        {
            get { return m; }
        }

        public Matrix()
        {
            M = new double[1, 1];

            M[0, 0] = 0;
            n = 0;
            m = 0;
        }

        public Matrix(int _n, int _m)
        {            
            n = _n;
            m = _m;
            M = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    M[i, j] = 0;
                }
            }
        }

        public Matrix(int _n)
        {
            n = m = _n;
            new Matrix(n, n);
        }

        public Matrix(double[,] Matr)
        {
            n = Matr.GetLength(0);
            m = Matr.GetLength(1);
            M = new double[n, m];

            M = Matr;
        }

        public double this[int i, int j]
        {
            get
            {
                return M[i, j];
            }
            set
            {
                M[i, j] = value;
            }
        }

        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(String.Format("{0, 3:G4}", M[i, j]));
                }
                Console.WriteLine();
            }
        }

        public bool IsEqualSize(Matrix B)
        {
            return (n == B.n) && (m == B.m);
        }

        public bool isQuadratic()
        {
            return (n == m);
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.IsEqualSize(B))
            {
                Matrix C = new Matrix(A.n, A.m);

                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }
                }

                return C;
            }
            return new Matrix();
        }

        public static Matrix operator +(Matrix A, double b)
        {
            Matrix C = new Matrix(A.n, A.m);

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    C[i, j] = A[i, j] + b;
                }
            }

            return C;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.IsEqualSize(B))
            {            
                Matrix C = new Matrix(A.n, A.m);

                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    { 
                        C[i, j] = A[i, j] - B[i, j];
                    }
                }

                return C;
            }
            return new Matrix();
        }

        public static Matrix operator *(double a, Matrix A)
        {
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    A[i, j] = a * A[i, j];
                }
            }

            return A;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            int l = A.n;
            int m = A.m;
            int n = B.m;

            if ((A.m == B.n))
            {
                Matrix C = new Matrix(l, n);

                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            C[i, j] += A[i, k] * B[k, j];
                        }
                    }
                } 

                return C;
            }
            return new Matrix();
        }

        public static Matrix Transpose(Matrix A)
        {
            int n = A.n;
            int m = A.m;
            Matrix B = new Matrix(m, n);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    B[j, i] = A[i, j];
                }
            }

            return B;
        }

        public static Matrix operator ^(Matrix A, int degree)
        {
            Matrix C = new Matrix(A.n, A.m);
            if (degree == 0)
            {

            }
            C = A;
            for (int i = 1; i < degree; i++)
            {
                C *= A;
            }
            return C;
        }

        public bool Equals(Matrix other)
        {
            if (IsEqualSize(other))
            {
                bool isEqual = true; 
                for (int i = 0; i < lengthN; i++)
                {
                    for (int j = 0; j < lengthM; i++)
                    {
                        if (this[i, j] != other[i, j])
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }
                if (isEqual)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        //?
        private void SetZero()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    this[i, j] = 0;
                }
            }
        }

        public static Matrix IdentityMatrix(int n)
        {
            Matrix E = new Matrix(n);
            
            E.SetZero();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    E[i, j] = 1;
                }
            }

            return E;
        }     
        
        public bool IsIdentity()
        {
            Matrix test = new Matrix(n);

            test = IdentityMatrix(n);

            if (Equals(test))
                return true;
            else
                return false;
        }

        public bool IsDiagonal()
        {
            if (isQuadratic())
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if ((this[i, j] != 0) && (i != j))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            else
                return false;
        }
        public bool IsStepped()
        {
            if (this[0, 0] != 0 && n > 1 && m > 1)
            {
                double upZeroCount = 0;
                double downZeroCount = 0;

                for (int i = 1, j = 0; i < n; i++)
                {   
                    while(this[i, j] == 0 || j > m)
                    {
                        downZeroCount++;
                        j++;
                    }
                    if (upZeroCount >= downZeroCount)
                    {
                        return false;
                    }
                    else
                    {
                        upZeroCount = downZeroCount;
                        downZeroCount = 0;
                        j = 0;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
