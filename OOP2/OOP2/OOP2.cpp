#include <iostream>
#include <string>
#include <sstream>
#include <iterator>
#include <algorithm>
using namespace std;

class MyString //клас-рядок
{
private:
    string _text;
public:
    void Init();
    string get();
};

class ChangeString //клас методів обробки рядка
{
private:
    MyString Text;
public:
    string add(string,string); //ф-я додавання рядків
    string Sdelete(string, int, int); //ф-я видалення певного діапазону в рядку
    string SClear(string); //ф-я очищення рядка
    string ToUp(string,string); //ф-я приведення перших букв до верхнього регістру
    string KeyS(string, string); //ф-я створення рядка ключа
    int AoS(string,int); //ф-я підрахунку к-сті слів певної довжини
};

int main()
{
    system("chcp 1251"); //підключення укр.мови
    system("cls");
    MyString New; //створення об'єкту
    MyString New2;
    ChangeString Add; //створення об'єкту
    ChangeString SDel;
    ChangeString SCl;
    ChangeString STU;
    ChangeString SK;
    ChangeString AS;
    New.Init(); //ініціалізація об'єкту
    New2.Init();
    cout << "Без змін: " << New.get() << " | " << New2.get() << endl;
    int b1, b2; //границі видалення
    cout << "Введіть позиції з якої до якої треба видалити рядок\n";
    cout << "З: "; cin >> b1; cout << "До: "; cin >> b2; //введення змінних
    string str1 = New.get(); //створення рядків для їх обробки
    string str2 = New2.get();
    string strMain = Add.add(str1, str2);
    string strMain1 = strMain;
    string strMain2 = strMain;
    string strMain3 = strMain;
    string strMain4 = strMain;
    string strMain5 = strMain;
    string str4 = SDel.Sdelete(strMain1, b1, b2);
    string str5 = SCl.SClear(strMain2);
    string str6 = STU.ToUp(strMain,strMain3);
    string str7 = SK.KeyS(strMain, strMain4);
    cout << "Результат додавання: " << strMain <<endl;
    cout << "Результат видалення: " << str4 << endl;
    cout << "Результат очищення: << " << str5 <<" >>"<< endl;
    cout << "Результат приведення перших літер усіх слів тексту до верхнього регістру: \n" << str6 << endl;
    cout << "Отримання рядка ключа: " << str7 << endl;
    int amount;
    cout << "Введіть кількість букв: ";
    cin >> amount;
    int counter = AS.AoS(strMain5, amount);
    cout << "Кількість рядків заданої довжини: " << counter << endl;
}

void MyString::Init()
{
    getline(cin, _text);
}

string MyString::get()
{
    return _text;
}

string ChangeString::add(string a, string b)
{
    return a + b;
}

string ChangeString::Sdelete(string a, int b1, int b2)
{
    a.erase(b1, b2);
    return a;
}

string ChangeString::SClear(string a)
{
    a.clear();
    return a;
}

string ChangeString::ToUp(string a,string b)
{
    b[0] = toupper(a[0]);
    for (int i = 1; i < size(a); i++)
    {
        if (isalpha(a[i]) && a[i - 1] == ' ')
        {
            b[i] = toupper(a[i]);
        }
    }
    return b;
}

string ChangeString::KeyS(string a, string b)
{
    for (int i = 0; i < size(a); i++)
    {
        b[i] = NULL;
    }

    b[0] = a[0];
    int c = 1;
    for (int i = 1; i < size(a); i++)
    {
        if (isalpha(a[i]) && a[i - 1] == ' ')
        {
            b[c] = a[i];
            c++;
        }
    }
    return b;
}

int ChangeString::AoS(string a,int b)
{
    size_t n = b;     
    istringstream iss(a);
    istream_iterator<std::string> beg(iss), eof;
    size_t count = std::count_if(beg, eof, [n](std::string word) {return (word.size() <= n); });
    return count;
}