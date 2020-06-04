#include <iostream>
#include <string>
using namespace std;
//----------------------------1 Завдання
class Lines //Базовий клас
{
public:
    double _xS, _yS; //координати точок лінії
    double _xE, _yE;
    double _len;
    Lines(double xS, double yS, double xE, double yE) //конструктор з параметром
    {
        _xS = xS; _yS = yS;
        _xE = xE; _yE = yE;
    }
    double Len(Lines L) //метод визначення довжини
    {
        _len = sqrt(pow((L._xE-L._xS),2)+pow((L._yE-L._yS),2));
        return _len;
    }
    void Out(Lines L) //метод виводу даних на єкран
    {
        cout << "Coords: <" << L._xS << " ; " << L._yS << "> <" << L._xE << " ; " << L._yE << ">\n";
    }
};

class Section : public Lines //Похідний клас
{
public:
    Section(double xS, double yS, double xE, double yE) : Lines(xS, yS, xE, yE){} //конструктор з параметром
    void Decrease(Section S,double a) // метод зменшяння відрізка на 5 одиниць
    {
        double NLen = S.Len(S) - a;
        _xS = (_xS * NLen) / S.Len(S);
        _xE = (_xE * NLen) / S.Len(S);
        _yS = (_yS * NLen) / S.Len(S);
        _yE = (_yE * NLen) / S.Len(S);
    }

};
//-----------------------------------------------------

class NStr //Базовий клас
{
public:
    int cnt = 0; //змінна кількості символів у рядку
    string _str; //рядок
    NStr(string str) //конструктор з параметром
    {
        _str = str;
    }
    virtual int ChCount() //метод підрахунку символів
    {
        for (int i = 0; i < size(_str); i++)
        {
            if(isalpha(_str[i])) cnt++;
        }
        return cnt;
    }
    virtual void ChChange() //метод зміни структури рядка
    {
        string sFirst = _str.substr(size(_str) - 1, 1);
        string sLast = _str.substr(0, 1);
        _str = _str.erase(0, 1);
        _str = _str.erase(size(_str) - 1, 1);
        _str = sFirst + _str + sLast;
    }
    void Print() //метод виводу даних на екан
    {
        cout << _str << endl;
    }
};

class NIntStr : public NStr //Похідний клас
{
public:
    NIntStr(string str) : NStr(str){} //конструктор
    int ChCount() //метод підрахунку символів 
    {
        for (int i = 0; i < size(_str); i++)
        {
            if (isdigit(_str[i])) cnt++;
        }
        return cnt;
    }
    void ChChange() //метод зміни структури рядка
    {
        string sFirst = _str.substr(size(_str) - 1, 1);
        _str = _str.erase(size(_str) - 1, 1);
        _str = sFirst + _str;
    }
};

class NSmlChar : public NStr //Похідний клас
{
public:
    NSmlChar(string str) :NStr(str) {} //конструктор
    int ChCount() //метод підрахунку символів 
    {
        for (int i = 0; i < size(_str); i++)
        {
            if (isalpha(_str[i]))
            {
                if (islower(_str[i])) cnt++;
            }
        }
        return cnt;
    }
    void ChChange() //метод зміни структури рядка
    {
        string sLast = _str.substr(0, 1);
        _str = _str.erase(0, 1);
        _str = _str + sLast;
    }
};

int main()
{
    system("chcp 1251");
    system("cls");
    cout << "\tКравчук Максим\n\tІС-92\n";
    cout << "1 завдання\n";
    //-------------------
    Lines L1(5, 9, 56, 88);
    double res = L1.Len(L1);
    cout <<"Довжина лінії "<< res << endl;

    Section S1(0, 5, 6, 9);
    cout << "До\n";
    S1.Out(S1);
    cout <<"Довжина відрізка "<<S1.Len(S1)<<endl;
    S1.Decrease(S1, 5);

    cout << "Після\n";
    S1.Out(S1);
    cout << S1.Len(S1);

    cout << "\n-------------------------------\n";

    //----------------------
    cout << "2 завдання\n";
    NStr Str1("jshadjdhAHDJShj12");
    cout << "Рядок до змін\n";
    Str1.Print();
    int res11 = Str1.ChCount();
    cout << "Кількість символів у рядку\n";
    cout << res11 << endl;
    Str1.ChChange();
    cout << "Рядок після змін\n";
    Str1.Print();

    cout << "\n-------------------------------\n";

    NIntStr IStr1("qwerty1qw23we3");
    cout << "Рядок до змін\n";
    IStr1.Print();
    int res22 = IStr1.ChCount();
    cout << "Кількість цифр у рядку\n";
    cout << res22 << endl;
    IStr1.ChChange();
    cout << "Рядок після змін\n";
    IStr1.Print();

    cout << "\n-------------------------------\n";

    NSmlChar SmlStr1("ADSdadADAadasda");
    cout << "Рядок до змін\n";
    SmlStr1.Print();
    int res33 = SmlStr1.ChCount();
    cout << "Кількість малих букв у рядку\n";
    cout << res33 << endl;
    SmlStr1.ChChange();
    cout << "Рядок після змін\n";
    SmlStr1.Print();
}