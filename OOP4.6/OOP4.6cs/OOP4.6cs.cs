using System;
using System.IO;

namespace OOP4
{
    class Romb
    {
        private double x1, y1;
        private double x2, y2;
        private double x3, y3;
        private double x4, y4;
        public Romb() //конструктор за замовчуванням
        {
            x1 = 0; y1 = 0;
            x2 = 4; y2 = 0;
            x3 = 2; y3 = 3;
            x4 = 2; y4 = -3;
        }
        public Romb(Romb preRomb) //конструктор копіювання
        {
            x1 = preRomb.x1; y1 = preRomb.y1;
            x2 = preRomb.x2; y2 = preRomb.y2;
            x3 = preRomb.x3; y3 = preRomb.y3;
            x4 = preRomb.x4; y4 = preRomb.y4;
        }
        public Romb(double _x1, double _y1, double _x2, double _y2, double _x3, double _y3, double _x4, double _y4) //конструтор за параметром
        {
            x1 = _x1; y1 = _y1;
            x2 = _x2; y2 = _y2;
            x3 = _x3; y3 = _y3;
            x4 = _x4; y4 = _y4;
        }
        public double X1 //звертання до приватних полей - властивість
        {
            get { return x1; }
            set { x1 = value; }
        }
        public double X2 //звертання до приватних полей - властивість
        {
            get { return x2; }
            set { x2 = value; }
        }
        public double X3 //звертання до приватних полей - властивість
        {
            get { return x3; }
            set { x3 = value; }
        }
        public double Y3 //звертання до приватних полей - властивість
        {
            get { return y3; }
            set { y3 = value; }
        }
        public double Y4 //звертання до приватних полей - властивість
        {
            get { return y4; }
            set { y4 = value; }
        }
        public double Space(Romb temp) //функція пошуку площи ромба
        {
            double d1, d2;
            double res;
            d1 = Math.Sqrt(Math.Pow((temp.x4 - temp.x2), 2) + (Math.Pow((temp.y4 - temp.y2), 2))); //пошук диагоналей ромба
            d2 = Math.Sqrt(Math.Pow((temp.x3 - temp.x1), 2) + (Math.Pow((temp.y3 - temp.y1), 2)));
            res = (d1 * d2) / 2; //пошук площи
            return res;
        }

        public double Perimetr(Romb temp) //функція пошуку периметра ромба
        {
            double a1;
            a1 = Math.Sqrt(Math.Pow((temp.x1 - temp.x2), 2) + (Math.Pow((temp.y1 - temp.y2), 2))); //пошук сторони ромба
            double res = a1 * 4; //пошук периметра
            return res;
        }
        public void Out(Romb t) //функція виводу координат ромба
        {
            Console.WriteLine("Coords: <{0};{1}> <{2};{3}> <{4};{5}> <{6};{7}>", t.x1, t.y1, t.x2, t.y2, t.x3, t.y3, t.x4, t.y4);
        }
        public static Romb operator *(Romb left, int a) //перегрузка оператора множення
        {
            if (a == 0) { throw new ArithmeticException(); } //виклик виключення при умові, що один із множників = 0
            Romb temp = new Romb();
            temp.x1 = left.x1 * a; temp.y1 = left.y1 * a;
            temp.x2 = left.x2 * a; temp.y2 = left.y2 * a;
            temp.x3 = left.x3 * a; temp.y3 = left.y3 * a;
            temp.x4 = left.x4 * a; temp.y4 = left.y4 * a;
            return temp;
        }
        public static Romb operator -(Romb left, Romb right) //перегрузка оператора віднімання
        {
            Romb temp = new Romb();
            temp.x1 = left.x1 - right.x1; temp.y1 = left.y1 - right.y1;
            temp.x2 = left.x2 - right.x2; temp.y2 = left.y2 - right.y2;
            temp.x3 = left.x3 - right.x3; temp.y3 = left.y3 - right.y3;
            temp.x4 = left.x4 - right.x4; temp.y4 = left.y4 - right.y4;
            return temp;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tKravchuk Maxim\n\tIS-92");
            Console.WriteLine("First Thomb");
            Romb P1 = new Romb(); //оголошення об'єкту
            P1.Out(P1);
            double sP1 = P1.Space(P1); //знаходження площи
            double pP1 = P1.Perimetr(P1); //знаходження периметру
            Console.WriteLine("P1 Square: {0}; P1 Perimeter: {1}", Math.Round(sP1, 3), Math.Round(pP1, 3));
            Console.WriteLine();

            Console.WriteLine("Second Thomb");
            Romb P2 = new Romb(P1); //оголошення об'єкту
            P2.Out(P2);
            double sP2 = P2.Space(P2); //знаходження площи
            double pP2 = P2.Perimetr(P2); //знаходження периметру
            Console.WriteLine("P2 Square: {0}; P2 Perimeter: {1}", Math.Round(sP2, 3), Math.Round(pP2, 3));
            Console.WriteLine();

            Console.WriteLine("Third Thomb");
            Romb P3 = new Romb(1.5, 0, 2, 1, 2.5, 0, 2, -1); //оголошення об'єкту
            //--------Перевірка на ромб
            try
            {
                if (P3.X1 == P3.X2 && P3.X2 == P3.X3 && P3.Y3 == P3.Y4)
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ERROR! This is not a romb! Try to change coords");
                System.Environment.Exit(1);

            }
            //-----------
            P3.Out(P3);
            double sP3 = P3.Space(P3); //знаходження площи
            double pP3 = P3.Perimetr(P3); //знаходження периметру
            Console.WriteLine("P3 Square: {0}; P3 Perimeter: {1}", Math.Round(sP3, 3), Math.Round(pP3, 3));
            Console.WriteLine();

            Console.WriteLine("Altered P3");
            //--------------Перевірка умови
            try
            {
                P3 = P3 * 0; //збільшення P3 у 2 рази
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("ERROR! Multiplication by zero is not possible");
                System.Environment.Exit(1);
            }
            //--------
            P3.Out(P3);
            double sP3a = P3.Space(P3); //знаходження площи
            double pP3a = P3.Perimetr(P3); //знаходження периметру
            Console.WriteLine("P3a Square: {0}; P3a Perimeter: {1}", Math.Round(sP3a, 3), Math.Round(pP3a, 3));
            Console.WriteLine();

            Console.WriteLine("Altered P1");
            P1 = P3 - P2; //віднімення від P3 P2
            P1.Out(P1);
            double sP1a = P1.Space(P1); //знаходження площи
            double pP1a = P1.Perimetr(P1); //знаходження периметру
            Console.WriteLine("P1a Square: {0}; P1a Perimeter: {1}", Math.Round(sP1a, 3), Math.Round(pP1a, 3));
        }
    }
}
