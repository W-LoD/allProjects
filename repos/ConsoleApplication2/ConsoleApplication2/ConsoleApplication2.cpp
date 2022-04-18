#include "pch.h"
#include "App.h"
#include <iostream>
#include <string>
#include <fstream>
#include <tchar.h>
#using <system.dll>
#using <mscorlib.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System;
using namespace std;

void sort(App mass[], int n);
void save(App mas[], string txt, int n);
App* load(string txt, int n);
void print(App arr);
void add(App& A);

class List
{
	App info;
	List* prev = NULL;;
	List* next = NULL;
	public:
	void Add(App inf)
	{
		
		info.name = inf.name;
		info.manufacturer = inf.manufacturer;
		info.size_on_disk = inf.size_on_disk;
		info.price = inf.price;
	}


};

int main()
{
	setlocale(LC_ALL, "rus");
	int N = 0, r = 0;
	cout << "Введите размер массива: ";
	cin >> N;
	App* Applications = new App[N];
	for (int i = 0; i < N; i++)
	{
		add(Applications[i]);
	}
	cout << "Введённые приложения: " << endl;
	for (int i = 0; i < N; i++)
	{
		try
		{

			if (Applications[i].size_on_disk <= 0)
				throw Applications[i];

		}
		catch (App A)
		{
			String^ sSource;
			String^ sLog;
			String^ sEvent;

			sSource = gcnew String("Application");
			sLog = gcnew String("Application1");
			sEvent = gcnew String("Ошибка, размер на диске не может быть меньше нуля!");

			if (!(EventLog::SourceExists(sSource)))
				EventLog::CreateEventSource(sSource, sLog);

			EventLog::WriteEntry(sSource, sEvent);
			/*EventLog::WriteEntry(sSource, sEvent,
				EventLogEntryType::Warning, 234);*/
		}
		try
		{

			if (Applications[i].price < 0)
				throw Applications[i];

		}
		catch (App A)
		{
			cout << "Ошибка: " << A.price << " < 0" << endl;
		}
	}
	for (int i = 0; i < N; i++)
	{
		print(Applications[i]);
	}
	string filename;
	cout << "Введите имя файла: ";
	cin >> filename;
	save(Applications, filename, N);
	App* App2 = new App[N];
	App2 = load(filename, N);
	sort(App2, N);
	cout << "Загруженные приложения: " << endl;
	for (int i = 0; i < N; i++)
	{
		print(App2[i]);
	}
	return 0;
}
void save(App mas[], string txt, int n)
{
	ofstream out;
	out.exceptions(ofstream::badbit | ofstream::failbit);
	try
	{
		out.open(txt);
	}
	catch (const std::exception& e)
	{
		cout << e.what() << endl;
		cout << "Ошибка открытия файла!" << endl;
	}
	if (out.is_open())
	{
		for (int i = 0; i < n; i++)
			out.write((char*)&mas[i], sizeof(App));
	}
	out.close();
}
App* load(string txt, int n)
{
	App* mas = new App[n];
	ifstream in;
	in.exceptions(ifstream::badbit | ifstream::failbit);
	try
	{
		in.open(txt);
	}
	catch (const std::exception& e)
	{
		cout << e.what() << endl;
		cout << "Ошибка открытия файла!" << endl;
	}
	if (in.is_open())
	{
		for (int i = 0; i < n; i++)
			in.read((char*)&mas[i], sizeof(App));
	}
	in.close();
	return mas;
}
void add(App& A)
{
	cout << "Введите наименование " << " приложения: ";
	cin >> A.name;
	cout << "Введите производителя " << " приложения: ";
	cin >> A.manufacturer;
	cout << "Введите размер на диске " << " приложения: ";
	cin >> A.size_on_disk;
	cout << "Введите цену " << " приложения: ";
	cin >> A.price;
	cout << endl;
}

void print(App arr)
{
	cout << "Наименование приложения: " << arr.name << endl;
	cout << "Производитель: " << arr.manufacturer << endl;
	cout << "Размер на диске: " << arr.size_on_disk << endl;
	cout << "Цена: " << arr.price << endl << endl;
}



void sort(App mass[], int n)
{
	App re;
	App* ptr = new App[n];
	for (int i = 0; i < n; i++)
		for (int j = i + 1; j < n; j++)
			if ((ptr[i].manufacturer > ptr[j].manufacturer) || (ptr[i].price > ptr[j].price))
			{
				re = ptr[i];
				ptr[i] = ptr[j];
				ptr[j] = re;
			}
}
