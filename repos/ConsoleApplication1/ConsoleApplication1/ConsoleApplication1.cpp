#include "pch.h"
#include <iostream>
#include <string.h>
using namespace std;
struct City {
    string name;
    int date; 
    int inhabitants;
    float area;
    void print()
    {
        cout << "Название города: " << name << endl;
        cout << "Дата основания: " << date << endl;
        cout << "Количество жителей: " << inhabitants << endl;
        cout << "Площадь занимаемой территории: " << area << endl;
        cout << endl;
    }
};
int main()
{
    setlocale(LC_ALL, "Russian");
    int n = 0;
    cout << "Введите размер массива: " << endl;
    cin >> n;
    City** city = new City * [n];
    for (int i = 0; i < n; i++)
    {
        city[i] = new City;
    }
    for (int i = 0; i < n; i++)
    {
        cout << "Введите название города: ";
        cin >> city[i]->name;
        cout << "Введите дату основания города: ";
        cin >> city[i]->date;
        cout << "Введите количество жителей города: ";
        cin >> city[i]->inhabitants;
        cout << "Введите площадь занимаемой территории города: ";
        cin >> city[i]->area;
        cout << endl;
    }
    City* swap;
    for (int i = 0; i < n; i++)
        for (int j = i + 1; j < n; j++) {
            if ((city[j]->inhabitants > city[i]->inhabitants) || (city[i]->area < city[j]->area))
            {
                swap = city[i];
                city[i] = city[j];
                city[j] = swap;
            }
        }
    for (int i = 0; i < n; i++)
    {
        city[i]->print();
    }
    return 0;
}
