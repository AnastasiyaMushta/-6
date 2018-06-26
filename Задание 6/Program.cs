using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Задание 6");
            Console.ResetColor();
            //ввод чисел
            double a, b, c, m;
            int n;
            Console.WriteLine("Введите число a1:"); //первое число
            a = inputNumbers();
            Console.WriteLine("Введите число a2:"); //второе число
            b = inputNumbers();
            Console.WriteLine("Введите число a3:"); //третье число
            c = inputNumbers();
            Console.WriteLine("Введите число M:");  //число для сравнения
            m = inputNumbers();
            Console.WriteLine("Введите число N:");  // длина последовательности
            while(!Int32.TryParse(Console.ReadLine(), out n) || (n <= 0) || (n>100))
            {
                Console.WriteLine("Введите целое число от 0 до 100");
            }

            //вычисление членов последовательности
            if (a.Equals(0) && b.Equals(0) && c.Equals(0) && !m.Equals(0)) { Console.WriteLine("Вычислить невозможно."); }
            else
            {
                Console.Write("\nПолученная последовательность: \n{0}; {1}; {2}; ", a, b, c);
                Next(3, n, a, b, c, m);
            }

            Console.ReadKey(); 
        }
        /// <summary>
        /// Проверка ввода
        /// </summary>
        /// <returns></returns>
        static double inputNumbers()
        {
            double x;
            while (!Double.TryParse(Console.ReadLine(), out x) || x > int.MaxValue)
                Console.WriteLine("Веедите число не выходящее за пределы допустимого значения {0}!", int.MaxValue);
            return x;
        }

        /// <summary>
        /// /Вычисление следующего члена последовательности
        /// </summary>
        /// <param name="j">Количество элементов последовательности</param>
        /// <param name="n">Длина последовательности</param>
        /// <param name="a">Первый элемент последовательности</param>
        /// <param name="b">Второй элемент последовательности</param>
        /// <param name="c">Третий элемент последовательности</param>
        /// <param name="m">Число для сравнения</param>
        static void Next(int j, int n, double a, double b, double c, double m)
        {
            double d = 3 * a / 2 + 2 * b / 3 - c / 3; //вычисление последующего элемента последовательности
            if (Math.Abs(d) < m && !Double.IsInfinity(d)) //если граница
            {
                Console.Write("{0}; ",Math.Round(d,2)); //вывод члена последовательности
                j++;                     //увеличение счётчика членов последовательности
                Next(j, n, b, c, d, m);
            }
            else
            {
                if (Double.IsInfinity(d)) { Console.WriteLine("\nВычислить невозможно"); } //проверка на бесконечность
                else
                {
                    bool equals = Math.Abs(d).Equals(m);  //равенство последнего члена последовательности 
                                                //и Числа для сравнения 
                    Console.WriteLine("\nВыполнение равенства: " + equals);
                    Console.WriteLine("Количество членов последовательности: " + (j));
                    Console.WriteLine("Сравнить J={0} и N={1}", j, n);
                    Console.WriteLine( j < n ? "J<N" : j == n ? "J=N" : "J>N");
                }
            }
        }
    }
}
