using System;
using System.Linq;

namespace OOP5cs
{
    //-----------1 Завдання
    class Lines //Базовий клас
    {
        private double _xS, _yS; //координати точок лінії
        private double _xE, _yE;
        private double _len;

        public Lines(double xS, double yS, double xE, double yE) //конструктор з параметром
        {
            _xS = xS; _yS = yS;
            _xE = xE; _yE = yE;
        }
        public double XS //звертання до приватних полей - властивість
        {
            get { return _xS; }
            set { _xS = value; }
        }
        public double XE
        {
            get { return _xE; }
            set { _xE = value; }
        }
        public double YS
        {
            get { return _yS; }
            set { _yS = value; }
        }
        public double YE
        {
            get { return _yE; }
            set { _yE = value; }
        }

        public double Len(Lines L) //метод визначення довжини
        {
            _len = Math.Sqrt((Math.Pow((L._xE - L._xS), 2)) + Math.Pow((L._yE - L._yS), 2));
            return _len;
        }
        public void Out(Lines S) //метод виводу даних на єкран
        {
            Console.WriteLine("Coords: <{0};{1}> <{2};{3}>", S.XS, S.XE, S.YS, S.YE);
        }
    }
    class Section : Lines //Похідний клас
    {
        public Section(double xS, double yS, double xE, double yE) :base( xS, yS, xE, yE) { } //конструктор з параметром
        public void Decrease(Section S, double a) // метод зменшяння відрізка на 5 одиниць
        {
            double NLen = S.Len(S) - a;
            S.XS = (S.XS * NLen) / S.Len(S);
            S.XE = (S.XE * NLen) / S.Len(S);
            S.YS = (S.YS * NLen) / S.Len(S);
            S.YE = (S.YE * NLen) / S.Len(S);
        }
    }
    //---------------------------------------------------------------------------------------------------------

    class NStr //Базовий клас
    {
        public int cnt=0; //змінна кількості символів у рядку
        public string _str { get; set; }
        public NStr(string str) //конструктор з параметром
        {
            _str = str;
        }
        public virtual int ChCount() //метод підрахунку символів
        {
            char[] check = _str.ToCharArray();
            foreach(char c in check)
            {
                cnt++;
            }
            return cnt;
        }
        public virtual void ChChange() //метод зміни структури рядка
        {
            string sFirst = _str.Substring(_str.Length - 1, 1);
            string sLast = _str.Substring(0, 1);
            _str = _str.Remove(0, 1);
            _str = _str.Remove(_str.Length - 1, 1);
            _str = sFirst + _str + sLast;
        }
        public void Print() //метод виводу даних на екан
        { 
            Console.WriteLine(_str);
        }
    }
    class NIntStr : NStr //Похідний клас
    {
        public NIntStr(string str) :base(str){ } //конструктор
        public override int ChCount() //метод підрахунку символів 
        {
            char[] check = _str.ToCharArray();
            foreach(char c in check)
            {
                if(c=='1'|| c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' || c == '0')
                {
                    cnt++;
                }
            }
            return cnt;
        }
        public override void ChChange() //метод зміни структури рядка
        {
            string sFirst = _str.Substring(_str.Length - 1, 1);
            _str = _str.Remove(_str.Length - 1, 1);
            _str = sFirst + _str;
        }
    }

    class NSmlChar : NStr //Похідний клас
    {
        public NSmlChar(string str) :base(str) { } //конструктор
        public override int ChCount() //метод підрахунку символів 
        {
            char[] check = _str.ToCharArray();
            var count = check.Where((n) => n >= 'a' && n <= 'z').Count();
            return count;
        }
        public override void ChChange() //метод зміни структури рядка
        {
            string sLast = _str.Substring(0, 1);
            _str = _str.Remove(0, 1);
            _str = _str + sLast;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.WriteLine("\tКравчук Максим\n\tІС-92\n");
            //----------------------------------
            Lines L1 = new Lines(5, 9, 56, 88);
            double res = L1.Len(L1);
            Console.WriteLine($"Довжина лінії {res}");
            Section S1 = new Section(0, 5, 6, 9);
            Console.WriteLine("До");
            S1.Out(S1);
            Console.WriteLine(S1.Len(S1));
            S1.Decrease(S1, 5);
            Console.WriteLine("Після");
            S1.Out(S1);
            Console.WriteLine(S1.Len(S1));
            Console.WriteLine("\n-------------------------------");
            //-----------------------------------
            NStr Str1 = new NStr("jshadjdhAHDJShj12");
            Console.WriteLine("Рядок до змін");
            Str1.Print();
            int res11 = Str1.ChCount();
            Console.WriteLine($"Кількість символів у рядку {res11}");
            Str1.ChChange();
            Console.WriteLine("Рядок після змін");
            Str1.Print();
            Console.WriteLine("\n-------------------------------");
            //-------------------------------------------
            NIntStr IStr1 = new NIntStr("qwerty1qw23we3");
            Console.WriteLine("Рядок до змін");
            IStr1.Print();
            int res22 = IStr1.ChCount();
            Console.WriteLine($"Кількість цифр у рядку {res22}");
            IStr1.ChChange();
            Console.WriteLine("Рядок після змін");
            IStr1.Print();
            Console.WriteLine("\n-------------------------------");
            //-----------------------------------------------
            NSmlChar SmlStr1 = new NSmlChar("ADSdadADAadasda");
            Console.WriteLine("Рядок до змін");
            SmlStr1.Print();
            int res33 = SmlStr1.ChCount();
            Console.WriteLine($"Кількість малих букв у рядку {res33}");
            SmlStr1.ChChange();
            Console.WriteLine("Рядок після змін");
            SmlStr1.Print();
            //----------------------------------------------------

            

        }
    }
}
