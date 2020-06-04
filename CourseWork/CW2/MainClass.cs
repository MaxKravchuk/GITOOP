using CWLib;//Connecting a class library
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace CW2
{
    class MainClass
    {

        //Input error notification method
        public static void TextIsZero()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There must be text here!\n");
            Console.ResetColor();
        }

        //Method for displaying notification of the first launch of a program
        public static void FirstEnter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This is the first launch of the program. Please register\n");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Курсова робота\nСтудента IС-92\nКравчукаМаксима\nТема: Онлайн новини\n");

            //Seclaring an instance of the News class
            News n = new News();

            //Event Subscription
            n.NoTextEvent += TextIsZero;
            n.FirstEnterEvent += FirstEnter;

            //Сall the interface(main) function
            ((IMainMenu)n).Control();

        }
    }

}