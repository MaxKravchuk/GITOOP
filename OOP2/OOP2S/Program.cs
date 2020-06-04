using System;
using System.Globalization;


namespace OOP2S
{
    class MyString //клас-рядок
    {
        private string _text;
        public void Init()
        {
            _text = Console.ReadLine();
        }
        public string get()
        {
            return _text;
        }
    }
    class ChangeString //клас методів обробки рядка
    {
        private MyString Text;
        public string add(string a,string b) //ф-я додавання рядків
        {
            return a + b;
        }
        public string Sdelete(string a, int b1, int b2) //ф-я видалення певного діапазону в рядку
        {
            a.Remove(b1, b2);
            return a;
        }
        public string SClean(string a) //ф-я очищення рядка
        {
            return a.Remove(0);
        }
       public string ToUp(string a) //ф-я приведення перших букв до верхнього регістру
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            a = textInfo.ToTitleCase(a);
            return a;
        }
        public int AoS(string a,int b) //ф-я підрахунку к-сті слів певної довжини
        {
            int cnt = 0;
            string[] words = a.Split('\n',' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < b+1) cnt++;
            }
            return cnt;
        }
        public string KeyS(string a, string b) //ф-я створення рядка ключа
        {
            b = String.Empty;
            string[] array = a.Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                b += array[i][0];
            }
            return b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; //підключення укр.мови
            MyString New = new MyString(); //створення об'єкту
            MyString New2 = new MyString();
            ChangeString Add = new ChangeString(); //створення об'єкту
            ChangeString SDel = new ChangeString();
            ChangeString SCl = new ChangeString();
            ChangeString STU = new ChangeString();
            ChangeString SK = new ChangeString();
            ChangeString AS = new ChangeString();
            New.Init(); //ініціалізація об'єкту
            New2.Init();
            Console.WriteLine("Без змін: {0} | {1}", New.get(), New2.get());
            int b1, b2; //границі видалення
            Console.WriteLine("Введіть позиції з якої до якої треба видалити рядок");
            Console.Write("З: "); b1 = Convert.ToInt32(Console.ReadLine()); //введення змінних
            Console.Write("До: "); b2 = Convert.ToInt32(Console.ReadLine());
            string str1 = New.get(); //створення рядків для їх обробки
            string str2 = New2.get();
            string strMain = Add.add(str1, str2);
            string strMain1 = strMain;
            string strMain2 = strMain;
            string strMain3 = strMain;
            string strMain4 = strMain;
            string strMain5 = strMain;
            string str4 = SDel.Sdelete(strMain1, b1, b2);
            string str5 = SCl.SClean(strMain2);
            string str6 = STU.ToUp(strMain3);
            string str7 = SK.KeyS(strMain, strMain4);
            Console.WriteLine("Результат додавання: {0}",strMain);
            Console.WriteLine("Результат видалення: {0}", str4);
            Console.WriteLine("Результат очищення: << {0} >>", str5);
            Console.WriteLine("Результат приведення перших літер усіх слів тексту до верхнього регістру: {0}", str6);
            Console.WriteLine("Отримання рядка ключа: {0}", str7);
            int amount;
            Console.Write("Введіть кількість букв: ");
            amount = Convert.ToInt32(Console.ReadLine());
            int counter = AS.AoS(strMain5, amount);
            Console.WriteLine("Кількість рядків заданої довжини: {0}", counter);
        }
    }
}
