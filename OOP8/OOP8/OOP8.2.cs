using System;
using System.Collections.Generic;
using System.Text;

namespace OOP8
{
    delegate void DelEventType(); //делегат
    class Phone
    {
        private double _SumOnPhone; //поле сума на рахунку
        private double _TimeOnPhone; //поле загальгий час розмов
        public event DelEventType MyEvent; //полія
        protected virtual void OnMyEvent()
        {
            if (MyEvent != null)
            {
                MyEvent();
            }
        }
        //-----------
        public void Control() //"інтерфейсна" ф-я
        {
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine("Press 1 - START\nPress 2 - Add money\nPress 3 - Speak\nPress 4 - Check\nPress 0 - END session");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        this.Start();
                        break;
                    case 2:
                        this.Add();
                        break;
                    case 3:
                        this.Speak();
                        break;
                    case 4:
                        this.Check();
                        break;
                }
                if (i == 0)
                {
                    Flag = false;
                    Console.WriteLine("Session is ended");
                }
            }
        }

        public void Start() //ф-я активізації пакету та поповнення рахунку
        {
            Console.WriteLine("You have just activated the package!\n Please Add money on the account");
            _SumOnPhone = 0;
            Add();
        }

        public void Add()//ф-я поповнення рахунку
        {
            Console.WriteLine("On your account {0} UAH", _SumOnPhone);
            Console.WriteLine("How much money do you want to put on the account?");
            double _sum = Convert.ToDouble(Console.ReadLine());
            if (_sum == 0)
            {
                Console.WriteLine("You can not fund your account by 0\t Try again!");
                _sum = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                _SumOnPhone += _sum;
                Console.WriteLine("On your account {0} UAH", _SumOnPhone);
            }
        }

        public void Speak() //ф-я розмови
        {
            double limit = _SumOnPhone / (1.5);
            Console.WriteLine("How many minutes did you talk?");
            double _mints = Convert.ToDouble(Console.ReadLine());
            double _TempTimeOnPhone = _TimeOnPhone;
            double _TempSumOnPhone = _mints * 1.5;
            _TempTimeOnPhone += _mints;

            if (_TempTimeOnPhone >= limit)
            {
                OnMyEvent();
                _TimeOnPhone = _mints - limit;
                _SumOnPhone = 0;
                Console.WriteLine("You talked for {0} minutes", Math.Round(limit, 2));

            }
            else
            {
                _TimeOnPhone += _mints;
                _SumOnPhone -= _TempSumOnPhone;

            }
            Console.WriteLine("You talked for {0} minutes", Math.Round(_mints, 2));
        }

        public void Check() //ф-я перевірки стану рахунка
        {
            Console.WriteLine("You talked for {0} minutes\tIn your account {1} UAH", _TimeOnPhone, _SumOnPhone);
        }
    }
}
