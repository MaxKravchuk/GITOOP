#include <iostream>
#include "math.h"
#include<cstdio>

using namespace std;

class Romb
{
    //int a = 2;
private:
    double x1, y1;
    double x2, y2;
    double x3, y3;
    double x4, y4;
public:
    Romb operator*(int a);
    Romb operator-(Romb temp);
    Romb() //конструктор за замовчуванням
    {
        x1 = 0; y1 = 0;
        x2 = 4; y2 = 0;
        x3 = 2; y3 = 3;
        x4 = 2; y4 = -3;
    }
    Romb(const Romb& preRomb) //конструктор копіювання
    {

        x1 = preRomb.x1; y1 = preRomb.y1;
        x2 = preRomb.x2; y2 = preRomb.y2;
        x3 = preRomb.x3; y3 = preRomb.y3;
        x4 = preRomb.x4; y4 = preRomb.y4;
    }
    Romb(double _x1, double _y1, double _x2, double _y2, double _x3, double _y3, double _x4, double _y4) //конструтор за параметром
    {
        x1 = _x1; y1 = _y1;
        x2 = _x2; y2 = _y2;
        x3 = _x3; y3 = _y3;
        x4 = _x4; y4 = _y4;
    }
    double Space(Romb temp) //функція пошуку площи ромба
    {
        double d1, d2;
        double res;
        d1 = sqrt(pow((temp.x4 - temp.x2), 2) + (pow((temp.y4 - temp.y2), 2)));
        d2 = sqrt(pow((temp.x3 - temp.x1), 2) + (pow((temp.y3 - temp.y1), 2)));
        res = (d1 * d2) / 2;
        return res;
    }

    double Perimetr(Romb temp) //функція пошуку периметра ромба
    {
        double a1;
        a1 = sqrt(pow((temp.x1 - temp.x2), 2) + (pow((temp.y1 - temp.y2), 2)));
        double res = a1 * 4;
        return res;
    }
    void Out(Romb t) //функція виводу координат ромба
    {
        cout << "Coords: <" << t.x1 << ";" << t.y1 << "> <" << t.x2 << ";" << t.y2 << "> <" << t.x3 << ";" << t.y3 << "> <" << t.x4 << ";" << t.y4 << ">" << endl;
    }
};

Romb Romb::operator*(int a) //перегрузка оператора множення
{
    //------------
    Romb temp;
    temp.x1 = x1 * a; temp.y1 = y1 * a;
    temp.x2 = x2 * a; temp.y2 = y2 * a;
    temp.x3 = x3 * a; temp.y3 = y3 * a;
    temp.x4 = x4 * a; temp.y4 = y4 * a;
    return temp;
    //---------
}

Romb Romb::operator-(Romb left) //перегрузка оператора віднімання
{
    Romb temp;
    temp.x1 = left.x1 - x1; temp.y1 = left.y1 - y1;
    temp.x2 = left.x2 - x2; temp.y2 = left.y2 - y2;
    temp.x3 = left.x3 - x3; temp.y3 = left.y3 - y3;
    temp.x4 = left.x4 - x4; temp.y4 = left.y4 - y4;
    return temp;
}

int main()
{
    cout << "\tKravchuk Maxim\n\tIS-92\n";
    cout << "First Thombus\n";
    Romb P1; //оголошення об'єкту
    P1.Out(P1);
    double sP1 = P1.Space(P1); //знаходження площи
    double pP1 = P1.Perimetr(P1); //знаходження периметру
    cout << "P1 Square: " << round(sP1) << " ; P1 Perimeter: " << round(pP1) << endl;
    cout << endl;

    cout << "Second Thomb" << endl;
    Romb P2(P1); //оголошення об'єкту
    P2.Out(P2);
    double sP2 = P2.Space(P2); //знаходження площи
    double pP2 = P2.Perimetr(P2); //знаходження периметру
    cout << "P2 Square: " << round(sP2) << " ; P2 Perimeter: " << round(pP2) << endl;
    cout << endl;

    cout << "Third Thomb" << endl;
    Romb P3(1.5, 0, 2, 1, 2.5, 0, 2, -1); //оголошення об'єкту
    P3.Out(P3);
    double sP3 = P3.Space(P3); //знаходження площи
    double pP3 = P3.Perimetr(P3); //знаходження периметру
    cout << "P3 Square: " << round(sP3) << "; P3 Perimeter: " << round(pP3) << endl;
    cout << endl;

    cout << "Altered P3\n";
    P3 = P3 * 2; //збільшення P3 у 2 рази
    P3.Out(P3);
    double sP3a = P3.Space(P3); //знаходження площи
    double pP3a = P3.Perimetr(P3); //знаходження периметру
    cout << "P3a Square: " << round(sP3a) << "; P3a Perimeter: " << round(pP3a) << endl;
    cout << endl;

    cout << "Altered P1";
    P1 = P2-P3; //віднімення від P3 P2
    P1.Out(P1);
    double sP1a = P1.Space(P1); //знаходження площи
    double pP1a = P1.Perimetr(P1); //знаходження периметру
    cout << "P1a Square: " << round(sP1a) << "; P1a Perimeter: " << round(pP1a) << endl;
}

