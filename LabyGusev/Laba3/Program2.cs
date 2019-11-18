using System;
using System.Collections; // Эта библиотека различных обобщённых коллекций
using System.Collections.Generic; // Эта библиотека различных НЕобобщенных коллекций
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix3
{
    class Program
    {
        static void Main(string[] args)
        {//Драйвер 

            Прямоугольник Пуник = new Прямоугольник(1, 2);
            Квадрат Квадрик = new Квадрат(10);
            Круг Кружок = new Круг(10);

            CSparseMatrix<Figure> Matr = new CSparseMatrix<Figure>(3, 3, 2, new CFigureMatrixCheckEmpty());

            Matr[0, 0, 0] = Квадрик;
            Matr[0, 1, 0] = Пуник;
            Matr[2, 2, 0] = Кружок;

            Matr[0, 0, 1] = Квадрик;
            Matr[1, 0, 1] = Пуник;
            Matr[1, 1, 1] = Кружок;

            Console.WriteLine(Matr.ToString());

            Console.ReadKey();
        }
    }
}
