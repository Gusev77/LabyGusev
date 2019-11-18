using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    abstract class Figure
    {
        //Переменные и свойства:
        public string Type { get; set; } // Создаем Свойство автоматически (private _Type)

        //Методы:
        public abstract double Area(); // Абстрактый метод для фиг знает какой фигуры. Абстрактно же.
                                       // В классе наследнике будет реализация.

        public override string ToString() //Виртуальный метод презаписи в строку.
        {
            return this.Type + ", площадью " + this.Area().ToString(); //Это не рекурсия. У Double свой ToString.
        }
    }

    interface IPrint // Интерфейс предназначен для вывода информации о геометрической фигуры
    {
        void Print(); // Абстрактный метод. Интерфейс состоит ТОЛЬКО из абстрактных методов.
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

    class Program
    {
        static void Main(string[] args)
        {
            Прямоугольник Пуник = new Прямоугольник(1, 2);
            Пуник.Print();
            Console.ReadKey();

            Квадрат Квадрик = new Квадрат(10);
            Квадрик.Print();
            Console.ReadKey();

            Круг Кружок = new Круг(10);
            Кружок.Print();
            Console.ReadKey();
        }
    }
}
