using System;

namespace OOP8
{
    class OOP8cs
    {
        //-----1ч
        public delegate void Func1(string[,] _str); //делегат
        //-------
        //----2ч----
        static void Empty() //ф-я події
        {
            Console.WriteLine("Not enough money on phone!");
        }
        //-----2ч----
        static void Main(string[] args)
        {
            Console.WriteLine("\tKravchuk Maxim IS-92");
            //------------------1ч
            Console.WriteLine("-----------------------------------------------1 part---------------------------------");
            StrMass tst = new StrMass(new string[,] { {"q","w","e"},{"r","t","y"},{"u","i","o"} }); //ініціалізація об'єкта 
            tst.DS(); //екземплярна ф-я
            Func1 f; //об'явлення делегату 
            f = StrMass.sDS; //ініціалізація
            if (f != null)
            {
                f(new string[,] { { "q", "w", "e" }, { "r", "t", "y" }, { "u", "i", "o" } }); //виклик делегату
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
            //---------------------
            //------------------2ч
            Console.WriteLine("\n\n-----------------------------------------------2 part---------------------------------");
            Phone P1 = new Phone(); //ініціалізація об'єкта 
            P1.MyEvent += Empty; //підписка на подію

            P1.Control(); //головна ф-я 2ї частини завдання
        }
    }
}
