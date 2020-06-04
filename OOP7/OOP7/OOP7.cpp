#include <iostream>

using namespace std;

struct Elem//Структура комірки
{
	long data;//поле-значення
	Elem* next,//показчик на наступний ел
		* prev;//показчик на попередній ел
};

class List//клас список
{
	Elem* Head,//поле-голова
		* Tail;//поле-хвіст
	int ElementsCounter;//поле-розмір списку

public:

	//конструктор
	List()
	{
		Head = Tail = NULL;
		ElementsCounter = 0;
	}

	//ф-я додавання в кінець
	void AddToTail(long Item) 
	{
		Elem* temp = new Elem;
		temp->next = 0;
		temp->data = Item;
		temp->prev = Tail;

		if (Tail != NULL) Tail->next = temp;
		if (ElementsCounter == NULL) Head = Tail = temp;
		else Tail = temp;

		ElementsCounter++;
	} 

	//ф-я виводу списку
	void ShowList() 
	{
		if (ElementsCounter != 0)
		{
			Elem* temp = Head;
			cout << "| ";
			while (temp->next != NULL)
			{
				cout << temp->data << " | ";
				temp = temp->next;
			}

			cout << temp->data << " |\n";
		}
		else
		{
			cout << "No items in list\n";
		}
	}

	//ф-я підрахунку к-сті елементів, що % на 5 і стоять на парних поз
	int GetElemWhithMulOf5()
	{
		int cnt = 0;
		for (int i = 1; i < ElementsCounter; i = i + 1)
		{
			long _tempdata = GetItem(i);
			if (_tempdata % 5 == 0)
			{
				cnt++;
			}
		}
		return cnt;
	}

	//ф-я видалення ел, що більші за середнє значення
	void DelItemsWBiggerTAvg()
	{
		int avg = GetAnAvgOfAllItems();
		Elem* temp = Head;
		int _tempSize = ElementsCounter;
		int i = 1;
		while (i <= _tempSize)
		{
			if (temp->data > avg)
			{
				temp = temp->next;
				DelFunc(i);
				_tempSize--;
			}
			else
			{
				i++;
				if (temp->next != NULL)
					temp = temp->next;
			}
		}
	}

private://допоміжні ф-ї

	//ф-я видалення за індексом
	void DelFunc(int k)
	{

		if (k == 1)
		{
			//Elem* temp = Head;
			Head = Head->next;
			delete(Head->prev);
			//ElementsCounter--;
		}

		if (k == ElementsCounter)
		{
			//Elem* temp = Tail;
			Tail = Tail->prev;
			Tail->next = NULL;
			delete(Tail->next);
			//ElementsCounter--;
		}

		if (k > 1 && k < ElementsCounter)
		{
			int i = 1;

			Elem* Del = Head;

			while (i < k)
			{
				// Доходим до элемента, 
				// который удаляется
				Del = Del->next;
				i++;
			}

			// Доходим до элемента, 
			// который предшествует удаляемому
			Elem* PrevDel = Del->prev;
			// Доходим до элемента, который следует за удаляемым
			Elem* AfterDel = Del->next;

			// Если удаляем не голову
			if (PrevDel != 0 && ElementsCounter != 1)
				PrevDel->next = AfterDel;
			// Если удаляем не хвост
			if (AfterDel != 0 && ElementsCounter != 1)
				AfterDel->prev = PrevDel;
			delete Del;
			//ElementsCounter--;
		}
	}

	//ф-я пошуку елементу за індексом
	long GetItem(int pos)
	{
		// Позиция от 1 до Count?
		if (pos < 1 || pos > ElementsCounter)
		{
			// Неверная позиция
			cout << "Incorrect position !!!\n";
			return 0;
		}

		Elem* temp;

		// Определяем с какой стороны 
		// быстрее двигаться
		if (pos <= ElementsCounter / 2)
		{
			// Отсчет с головы
			temp = Head;
			int i = 1;

			while (i < pos)
			{
				// Двигаемся до нужного элемента
				temp = temp->next;
				i++;
			}
		}
		else
		{
			// Отсчет с хвоста
			temp = Tail;
			int i = 1;

			while (i <= ElementsCounter - pos)
			{
				// Двигаемся до нужного элемента
				temp = temp->prev;
				i++;
			}
		}
		return temp->data;
	}

	//ф-я похуку середнього значення
	int GetAnAvgOfAllItems()
	{
		int Sum = 0;
		int AvgSum = 0;
		Elem* temp = Head;
		while (temp != 0)
		{
			Sum += temp->data;
			temp = temp->next;
		}
		AvgSum = Sum / ElementsCounter;
		return AvgSum;
	}

};

int main()
{
	cout << "Maxim Kravchuk\nIS-92\nC++\n\n";

	List l;//ініціалізую список

	long a[5] = { 88,95,93,55,64 };

	for (int i = 0; i < 5; i++)//заповнюю список
	{
		l.AddToTail(a[i]);
	}

	cout << "List l:\n" << endl;
	l.ShowList();
	cout << endl;
	cout << "The number of elements multiples of 5 that located in pairs -> " << l.GetElemWhithMulOf5() << endl << endl;

	l.DelItemsWBiggerTAvg();
	cout << "List l after deleting items that are larger than average\n\n";
	l.ShowList();
}