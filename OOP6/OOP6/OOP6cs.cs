using System;

namespace OOP6
{
    class Exr
    {
        private double _a, _b, _c, _d;//змінні

        public Exr(double a, double b, double c, double d)//конструктор
        {
            _a = a; _b = b; _c = c; _d = d;
        }

        private double SolveSqrt()//метод визначення кореня
        {
            if ((24 + _d - _c) < 0)
            {
                throw new ArithmeticException();
            }
            return Math.Sqrt(24 + _d - _c);
        }

        private double SolveDen()//метод визначення знаменника рівняння
        {
            double a = SolveSqrt() + (_a / _b);
            if (_b == 0 || a==0)
            {
                throw new DivideByZeroException();
            }
            else
                return SolveSqrt() + (_a / _b);
        }

        public double Answer()//метод підрахунку відповіді
        {
            return ((1 + _a - _b / 2) / SolveDen());
        }
        public void Checker()//метод перевірки виключень
        {
            try
            {
                SolveSqrt();
                try
                {
                    SolveDen();
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("\n\nWARNING!!!____Error! You cannot divide by 0____WARNING!!!\n\n");
                }
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("\n\nWARNING!!!____Error! Negative number under the sqrt____WARNING!!!\n\n");
            }
        }
        class OOP6cs
        {
            static void Main(string[] args)
            {
                double a, b, c, d;
                Console.WriteLine("\tMaxim Kravchuk\n\tIS-92");
                Console.Write("Enter an amount of exercises -> ");
                int n = Convert.ToInt32(Console.ReadLine());
                Exr[] exercise = new Exr[n];//створення масиву об'єктів
                for(int i = 0; i<n;i++)//заповнення об'єктів
                {
                    Console.WriteLine("{0} try", (i+1));
                    Console.Write("Enter A -> ");
                    a = Convert.ToInt32(Console.ReadLine());//ініціалізація змінних
                    Console.Write("Enter B (B!=0) -> ");
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter C -> ");
                    c = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter D -> ");
                    d = Convert.ToInt32(Console.ReadLine());
                    exercise[i] = new Exr(a, b, c, d);//ініціалізація об'єкта
                    exercise[i].Checker();
                    Console.WriteLine("Resulr is -> " + Math.Round(exercise[i].Answer(),4));//вивід відповіді
                }
            }
        }
    }
}
