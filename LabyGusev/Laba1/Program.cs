using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабороторная_1
{
    class Program
    {
        static double enterErr(int num)
        {
            while (true)
            {
                try
                {
                    Console.Write($"Введите {num}-е значение: ");
                    return double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Значение введено неверно, попробуйте снова!");
                }
            }
        }

        static void convertdouble(string[] args, double[] mass)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    mass[i] = Convert.ToDouble(args[i]);
                }
                catch
                {
                    mass[i] = enterErr(i + 1);
                }
            }
        }

        static void print(double[] a)
        {
            if (a[0] != 0)
            {
                if (a[0] == -1 || a[0] == 1)
                {
                    if (a[0] == -1)
                        Console.Write("-x^4");
                    else
                        Console.Write("x^4");
                }
                else
                    Console.Write($"{a[0]}x^4");
            }
            if (a[1] != 0)
            {
                if (a[1] == -1 || a[1] == 1)
                {
                    if (a[1] == -1)
                        Console.Write("-x^2");
                    else
                    {
                        if (a[0] != 0)
                            Console.Write("+x^2");
                        else
                            Console.Write("x^2");
                    }
                }
                else if (a[1] != 0 && (a[1] != -1 || a[1] != 1))
                {
                    if (a[1] > 0)
                    {
                        if (a[0] != 0)
                            Console.Write($"+{a[1]}x^2");
                        else
                            Console.Write($"{a[1]}x^2");
                    }
                    else
                        Console.Write($"{a[1]}x^2");
                }
            }

            if (a[2] != 0)
            {
                if (a[2] > 0 && (a[0] != 0 || a[1] != 0))
                    Console.Write($"+{a[2]}=0\n");
                else if (a[0] == 0 && a[1] == 0)
                {
                    Console.Write($"{a[2]}!=0\n");
                }
                else
                    Console.Write($"{a[2]}=0\n");
            }
            else if (a[0] != 0 || a[1] != 0)
                Console.Write("=0\n");
            else
                Console.Write("Все значения равны 0!\n");

        }

        static void calculation(double[] a)
        {
            double t1, t2, x1, x2, x3, x4;

            double d = Math.Pow(a[1], 2) - 4 * a[0] * a[2];

            if (d >= 0 && a[0] != 0 && a[1] != 0)
            {
                t1 = (-a[1] + Math.Sqrt(d)) / (2 * a[0]);
                t2 = (-a[1] - Math.Sqrt(d)) / (2 * a[0]);

                Console.ForegroundColor = ConsoleColor.Red;
                if (t1 < 0 && t2 < 0)
                {
                    Console.WriteLine("\nКорней нет!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (t1 >= 0)
                    {
                        x1 = Math.Sqrt(t1);
                        x2 = -Math.Sqrt(t1);
                        if (x1 == x2)
                            Console.WriteLine($"\nx1= { x1 }\n");
                        else
                            Console.WriteLine($"\nx1= { x1 }\nx2= { x2 }\n");
                    }
                    if (t2 >= 0 && (t1 != t2))
                    {
                        x3 = Math.Sqrt(t2);
                        x4 = -Math.Sqrt(t2);
                        if (x3 == x4)
                            Console.WriteLine($"x3= { x3 }\n");
                        else
                            Console.WriteLine($"x3= { x3 }\nx4= { x4 }\n");
                    }
                    Console.ResetColor();
                }
            }
            else if (a[0] == 0 && a[1] != 0)
            {
                if (a[2] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    x1 = Math.Sqrt(-a[2] / a[1]);
                    x2 = -Math.Sqrt(-a[2] / a[1]);
                    if (x1 == x2)
                        Console.WriteLine($"\nx1= { x1 }\n");
                    else
                        Console.WriteLine($"\nx1= { x1 }\nx2= { x2 }\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nКорней нет!");
                    Console.ResetColor();
                }
            }
            else if (a[1] == 0 && a[0] != 0)
            {
                if (a[2] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    x1 = Math.Sqrt(Math.Sqrt(-a[2] / a[0]));
                    x2 = -Math.Sqrt(Math.Sqrt(-a[2] / a[0]));
                    if (x1 == x2)
                        Console.WriteLine($"\nx1= { x1 }\n");
                    else
                        Console.WriteLine($"\nx1= { x1 }\nx2= { x2 }\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nКорней нет!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nКорней нет!");
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Гусев Сергей ИУ5Ц-Б";
            Console.WriteLine("\t\tРешение биквадратного уравнения\n");

            double[] a = new double[3];

            if (args.Length != 0 && args.Length == 3)
            {
                convertdouble(args, a);
            }
            else
            {
                a[0] = enterErr(1);
                a[1] = enterErr(2);
                a[2] = enterErr(3);
            }

            char c = 'y';
            while (c == 'y')
            {
                print(a);
                calculation(a);
                Console.Write("Продолжить вычисления(y/n): ");
                c = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (c == 'y')
                {
                    a[0] = enterErr(1);
                    a[1] = enterErr(2);
                    a[2] = enterErr(3);
                }
            }


            Console.ReadKey();
        }
    }
}