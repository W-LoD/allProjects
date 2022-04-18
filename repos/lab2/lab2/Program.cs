using System;
using System.Globalization;
namespace lr3ch
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            string str;
            double X, Y, Z = 0;
            int N, A = 1, B = 2, C=3;
            Console.Write("Введите кэффициент X: ");
            str = Console.ReadLine();
            X = Convert.ToDouble(str, numberFormatInfo);
            Console.Write("Введите кэффициент Y: ");
            str = Console.ReadLine();
            Y = Convert.ToDouble(str, numberFormatInfo);
            Console.Write("Введите количество слагаемых: ");
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                if ((A / 2) % 2 == 0)
                    Z -= Math.Pow(X, A) / (A * B * C);
                else
                    Z += Math.Pow(Y, A) / (A * B * C);
                A += 2;
                B += 2;
                C += 2;
            }
            Console.WriteLine(Z);
        }
    }
}