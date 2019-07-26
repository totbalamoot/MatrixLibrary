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

            Console.WriteLine(matrix.lengthN);
            Console.WriteLine(matrix.lengthM);          
            Console.WriteLine();

            Console.WriteLine(matrix1.lengthN);
            Console.WriteLine(matrix1.lengthM);
            Console.WriteLine();

            double[,] matr1 = new double[2, 2];
            double[,] matr2 = new double[2, 2];
            matr1 = new double[,] { { 1, 2 }, { 3, 4 } };
            matr2 = new double[,] { { 4, 3 }, { 2, 1 } };
            Matrix matrixA = new Matrix(matr1);
            Matrix matrixB = new Matrix(matr2);
            Matrix matrixC = matrixA - matrixB;

            matrixC.Show();
            /*
            Console.WriteLine();
            matrixA.Show();
            Console.WriteLine();

            if (!matrixA.Equals(matrixB))
            {
                Console.WriteLine("Матрицы не равны!");
            }
            */
            matrixA = matrixA ^ 2;
            matrixA.Show();
        }
    }
}
