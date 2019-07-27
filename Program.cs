using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(2);
            double[,] matr = new double[2, 5];
            Matrix matrix1 = new Matrix(matr);
            double[,] matr1 = new double[4, 4];
            double[,] matr2 = new double[2, 2];

            matr1 = new double[,] { { 1, 2, 4, 5 }, { 0, 4, 3, 4 }, { 0,2,2, 5 }, { 0, 0, 0, 4 } };
            matr2 = new double[,] { { 4, 3 }, { 2, 1 } };
            Matrix matrixA = new Matrix(matr1);
            Matrix matrixB = new Matrix(matr2);

            /*
            Console.WriteLine();
            matrixA.Show();
            Console.WriteLine();

            if (!matrixA.Equals(matrixB))
            {
                Console.WriteLine("Матрицы не равны!");
            }
            */
            matrixA.Show();

            if (matrixA.IsStepped())    
            {
                Console.WriteLine("Матрица ступенчатая");
            }
            else
            {
                Console.WriteLine("Матрица НЕ ступенчатая");
            }
                 
        }
    }
}
