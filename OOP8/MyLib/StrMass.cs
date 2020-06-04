using System;

namespace MyLib
{
    class StrMass
    {
        private string[,] _str = new string[3, 3]; //поле-матриця
        public StrMass(string[,] str)//конструктор
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _str[i, j] = str[i, j];
                }
            }
        }
        public void DS() //екзем-на ф-я
        {

            for (int i = 0; i < 3; i++)
            {
                Console.Write(_str[i, i] + "\t");
            }
            Console.WriteLine();
        }

        public static void sDS(string[,] _str) //статична ф-я
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(_str[i, i] + "\t");
            }
            Console.WriteLine();
        }
    }
}
