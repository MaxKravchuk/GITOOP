using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualBasic.FileIO;

namespace OOP7cs
{
    public class Elem//клас комірка
    {
        private long _Data;//поле-значення
        private Elem _Next;//показчик на наступний ел
        private Elem _Prev;//показчик на попередній ел

        //всластивосі звернення до приватних полей
        public long Value
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public Elem(long Data)
        {
            this._Data = Data;
        }
        public Elem Next
        {
            get { return this._Next; }
            set { this._Next = value; }
        }
        public Elem Prev
        {
            get { return this._Prev; }
            set { this._Prev = value; }
        }

    }

    class List//клас список
    {

        private Elem Head;//поле-голова
        private Elem Current;//поле-поточний ел
        private Elem Tail;//поле-хвіст
        private int size;//поле-розмір списку

        public int Count
        {
            get { return size; }
            set { size = value; }
        }//властивість для розміру

        public List()
        {
            size = 0;
            Head = Current = Tail = null;
        }//конструктор

        public void AddToTail(long newElement)
        {
            Elem newElem = new Elem(newElement);

            if (Head == null)
            {
                Head = Tail = newElem;
            }
            else
            {
                Tail.Next = newElem;
                newElem.Prev = Tail;
                Tail = newElem;
            }
            Count++;
        }//ф-я додавання в кінець

        public void ShowList()
        {
            if (Count != 0)
            {
                Current = Head;
                Console.Write("| ");
                while (Current != null)
                {
                    Console.Write(Current.Value + " | ");
                    Current = Current.Next;
                }
            }
            else
            {
                Console.WriteLine("No items in list");
            }
        }//ф-я виводу списку

        public int GetElemWhithMulOf5()
        {
            int cnt = 0;
            for(int i = 1; i<=Count;i=i+2)
            {
                long _tempdata = GetItem(i);
                if (_tempdata % 5 == 0)
                {
                    cnt++; 
                }
            }
            return cnt;
        }//ф-я підрахунку к-сті елементів, що % на 5 і стоять на парних поз

        public void DelItemsWBiggerTAvg()
        {
            int avg = GetAnAvgOfAllItems();
            Current = Head;
            int _tempsize = Count;
            int i = 1;
            while(i<=_tempsize)
            {
                if(Current.Value > avg)
                {
                    Current = Current.Next;
                    DelFunc(i);
                    _tempsize--;
                }
                else
                {
                    i++;
                    if (Current.Next != null) Current = Current.Next;
                }
            }
        }//ф-я видалення ел, що більші за середнє значення

        //допоміжні ф-ї

        private long GetItem(int pos)
        {
            if (pos < 1 || pos > Count)
                return 0;
            if (pos <= Count / 2)
            {
                Current = Head;
                int i = 1;
                while (i < pos)
                {
                    Current = Current.Next;
                    i++;
                }
            }
            else
            {
                Current = Tail;
                int i = 0;
                while (i <= Count - pos)
                {
                    Current = Current.Prev;
                    i++;
                }
            }
            return Current.Value;
        }//ф-я пошуку елементу за індексом

        private void DelFunc(int index)
        { //удалить элемент по индексу
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                Head = Head.Next;
                Head.Prev = null;

            }
            else if (index == size)
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }
            else if (index > 1 && index < Count)
            {
                uint i = 1;
                Current = Head;
                Elem Del = Head;

                while (i < index)
                {
                    Del = Del.Next;
                    i++;
                }
                Elem PrevDel = Del.Prev;
                Elem AfterDel = Del.Next;
                if (PrevDel != null && Count != 1)
                    PrevDel.Next = AfterDel;
                if (AfterDel != null && Count != 1)
                    AfterDel.Prev = PrevDel;
                Del = null;
            }
        }//ф-я видалення за індексом

        private int GetAnAvgOfAllItems()
        {
            int Sum = 0, AvgSum=0;
            Current = Head;
            while(Current!=null)
            {
                Sum += (int)Current.Value;
                Current = Current.Next;
            }
            AvgSum = Sum / Count;
            return AvgSum;
        }//ф-я похуку середнього значення

    }

    class OOP7cs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maxim Kravchuk\nIS-92\nC#\n\n");

            List L = new List();//ініціалізую список

            long[] a = new long[5] { 88, 95, 93, 55, 64 };

            for(int i = 0; i<5; i++)//заповнюю список
            {
                L.AddToTail(a[i]);
            }

            Console.WriteLine("List L:\n");
            L.ShowList();
            Console.WriteLine();

            Console.WriteLine($"The number of elements multiples of 5 that located in pairs -> {L.GetElemWhithMulOf5()}\n\n");

            L.DelItemsWBiggerTAvg();
            Console.WriteLine("List l after deleting items that are larger than average\n\n");
            L.ShowList();
        }
    }
}
