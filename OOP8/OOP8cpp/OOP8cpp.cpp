#include <iostream>
#include <string>

using namespace std;
//----------1ч
    void DS(char str[3][3]) //ф-я пошуку діагонального рядка
    {
        for (int i = 0; i < 3; i++)
        {
            cout << str[i][i] << ' ';
        }
        cout << endl;
    }
//---------------

int main()
{
    //------1ч
    char cmas[3][3] = { {'q','w','e'},{'r','t','y'},{'u','i','o'} }; ////ініціалізація об'єкта
    void(*Pointer)(char str[3][3]); //вказівник на фу-ю
    Pointer = DS;
    Pointer(cmas); //виклик ф-ї через вказівник
    //---------




}
