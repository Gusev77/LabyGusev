using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseMatrix3
{
    abstract class Figure : IComparable //Интерфейс предназначен для корректной работы сортировки коллекции из объектов класса. 
    {
        //Переменные и свойства:
        public string Type { get; set; } // Создаем Свойство автоматически (private _Type)

        //Методы:
        public abstract double Area(); // Абстрактый метод для фиг знает какой фигуры. Абстрактно же.
                                       // В классе наследнике будет реализация.

        public override string ToString() //Виртуальный метод презаписи в строку.
        {
            return this.Type + ", S = " + this.Area().ToString(); //Это не рекурсия. У Double свой ToString.
        }

        public int CompareTo(object obj) //Для корректной работы метода сортировки коллекции
        {
            //1. Привести параметр к типу "ФИГУРА"
            Figure F = (Figure)obj;

            //2. Сравнение.
            if (this.Area() < F.Area()) return -1;
            else if (this.Area() == F.Area()) return 0;
            else return 1; // This.Area > F.Area
        }
    }

    class Прямоугольник : Figure, IPrint //Название на Кирилице, ибо кирилица входит в Юникод, который используем C#
    {
        //Переменные и свойства:
        public double Высота { get; set; }
        public double Ширина { get; set; }

        //Конструкторы:
        public Прямоугольник(double высота, double ширина)
        {
            this.Высота = высота;
            this.Ширина = ширина;
            this.Type = "Прямоугольник";
        }

        //Методы:
        public override double Area()
        {
            // throw new NotImplementedException(); //Это называется Заглушка.
            return this.Высота * this.Ширина;
        }

        //Интерфейсы:
        public void Print()
        {
            //throw new NotImplementedException(); //Заглушка
            Console.WriteLine(this.ToString());
        }
    }

    class Квадрат : Прямоугольник, IPrint //Название на Кирилице, ибо кирилица входит в Юникод, который используем C#
    {
        //Конструкторы:
        public Квадрат(double сторона) : base(сторона, сторона)
        {
            this.Type = "Квадрат";
        }
    }

    class Круг : Figure, IPrint //Название на Кирилице, ибо кирилица входит в Юникод, который используем C#
    {
        //Переменные и свойства:
        public double Радиус { get; set; }

        //Конструкторы:
        public Круг(double радиус)
        {
            this.Радиус = радиус;
            this.Type = "Круг";
        }

        //Методы:
        public override double Area()
        {
            return Math.PI * this.Радиус * this.Радиус;
        }

        //Интерфейсы:
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
