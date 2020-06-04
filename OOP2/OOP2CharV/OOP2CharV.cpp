#include <iostream>
#include <string>
#include <sstream>
#include <iterator>
#include <algorithm>
using namespace std;

class MyString
{
private:
    char* _text = new char[500];
    //char _text[500];
public:
    void Init();
    string get();
};

class ChangeString
{
private:
    MyString Text;
public:
    string add(string, string);
    string Sdelete(string, int, int);
    string SClear(string);
    string ToUp(string, string);
    string KeyS(string, string);
    int AoS(string, int);
};

int main()
{
    system("chcp 1251");
    system("cls");
    MyString New;
    MyString New2;
    ChangeString Add;
    ChangeString SDel;
    ChangeString SCl;
    ChangeString STU;
    ChangeString SK;
    ChangeString AS;
    New.Init();
    New2.Init();
    cout << "Без змін: " << New.get() << " | " << New2.get() << endl;
    int b1, b2;
    cout << "Введіть позиції з якої до якої треба видалити рядок\n";
    cout << "З: "; cin >> b1; cout << "До: "; cin >> b2;
    string str1 = New.get();
    string str2 = New2.get();
    string strMain = Add.add(str1, str2);
    string strMain1 = strMain;
    string strMain2 = strMain;
    string strMain3 = strMain;
    string strMain4 = strMain;
    string strMain5 = strMain;
    string str4 = SDel.Sdelete(strMain1, b1, b2);
    string str5 = SCl.SClear(strMain2);
    string str6 = STU.ToUp(strMain, strMain3);
    string str7 = SK.KeyS(strMain, strMain4);
    cout << "Результат додавання: " << strMain << endl;
    cout << "Результат видалення: " << str4 << endl;
    cout << "Результат очищення: << " << str5 << " >>" << endl;
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
    int i = 0;
    while (_text[i] != '\n')
    {
        cin >> _text[i];
        i++;
    }
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

string ChangeString::ToUp(string a, string b)
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

int ChangeString::AoS(string a, int b)
{
    size_t n = b;
    istringstream iss(a);
    istream_iterator<std::string> beg(iss), eof;
    size_t count = std::count_if(beg, eof, [n](std::string word) {return (word.size() <= n); });
    return count;
}