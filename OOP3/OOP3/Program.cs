using System;

namespace OOP_Laba3
{
    class Program
    {
        class Matrix
        {
            private char[,] Mat = new char[4, 4] { { 'a', 'b', 'c', 'd' }, { 'e', 'h', 'h', 'd' }, { 'l', 'e', 'r', 'q' }, { 'p', 'v', 'b', 'k' } };
            private int HardLetter = 0;
            public string this[int i]
            {
                get
                {
                    char[] temp = new char[4];
                    for (int k = 0; k < 4; k++)
                    {
                        temp[k] = Mat[i, k];
                    }
                    string str = new string(temp);
                    return str;
                }
            }
            public int AHR
            {
                get
                {
                    return this.HardLetter;
                }
            }//індексатор на масив
            public int CL()
            {
                char A = 'a';
                char E = 'e';
                char Y = 'y';
                char U = 'u';
                char I = 'i';
                char O = 'o';
                for (int k = 0; k < 4; k++)
                {
                    for (int m = 0; m < 4; m++)
                    {
                        if (Mat[k, m] != A && Mat[k, m] != E && Mat[k, m] != Y && Mat[k, m] != U && Mat[k, m] != I && Mat[k, m] != O)
                        {
                            HardLetter++;
                        }
                    }
                }
                return HardLetter;
            }//ф-я підрахунку приголосних букв
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;//укр мова
            Console.WriteLine("\tКравчука Максима\n\tІС-92");
            Console.WriteLine("Введіть бажаний рядок на вивід");
            int n = Convert.ToInt32(Console.ReadLine());//змінна для рядка
            Matrix str = new Matrix();//створення об'єкту класу
            Console.WriteLine("Рядок який потрібно вивести");
            Console.WriteLine(str[n]);//вивід рядка
            str.CL();//метод підрахунку приголосних
            Console.WriteLine("Кількість приголосних");
            Console.WriteLine(str.AHR);//властивість виводу к-сті приголосних літер 
        }
    }
}
