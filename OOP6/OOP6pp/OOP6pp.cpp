#include <iostream>
#include <cmath>
#include <iomanip>
#include<cstdio>
using namespace std;

class Exr
{
private:
    double _a, _b, _c, _d; //змінні
    double SolveSqrt()//метод визначення кореня
    {
        try
        {
            if ((24 + _d - _c) < 0)
                throw 1;
            else
            {
                return sqrt(24 + _d - _c);
            }
        }
        catch (int i)
        {
            cout << "\n\nWARNING!!!____Error! Negative number under the sqrt____WARNING!!!\n\n";
            exit(0);
        }
    }
    double SolveDen()//метод визначення знаменника рівняння
    {
        int a = SolveSqrt() + (_a / _b);
        try
        {
            if (_b == 0)
                throw 1;
            if (a == 0)
                throw 1.0;
            else
            {
                return SolveSqrt() + (_a / _b);
            }
        }
        catch (int i)
        {
            cout << "\n\nWARNING!!!____Error! B cannot be 0____WARNING!!!\n\n";
            exit(0);
        }
        catch (double i)
        {
            cout << "\n\nWARNING!!!____You cannot devide by 0____WARNING!!!\n\n";
            exit(0);
        }
    }
public:
    Exr(){};//конструктор
    Exr(double a, double b, double c, double d)//конструктор
    {
        _a = a; _b = b; _c = c; _d = d;
    }
    double Answer()//метод підрахунку відповіді
    {
        return ((1 + _a - _b / 2) / SolveDen());
    }
};

int main()
{
    cout << "\tKravchuk Maxim\n\tIS-92\n";
    double a, b, c, d;
    int size;
    cout << "Enter an amount of exercises -> ";
    cin >> size;
    Exr* exercise = new Exr[size];//створення масиву об'єктів
    for (int i = 0; i < size; i++)//заповнення об'єктів
    {
        cout << i << "----------\n";
        cout << "Enter A -> ";
        cin >> a;//ініціалізація змінних
        cout << "Enter B (B!=0) -> ";
        cin >> b;
        cout << "Enter C -> ";
        cin >> c;
        cout << "Enter D -> ";
        cin >> d;
        exercise[i] = Exr(a, b, c, d);//ініціалізація об'єкта
        cout << "Result is -> " << setw(5) << setprecision(2) << exercise[i].Answer()<<endl;//вивід відповіді
    }
}