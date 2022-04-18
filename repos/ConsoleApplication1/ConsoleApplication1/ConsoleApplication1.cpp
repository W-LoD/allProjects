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
        cout << "�������� ������: " << name << endl;
        cout << "���� ���������: " << date << endl;
        cout << "���������� �������: " << inhabitants << endl;
        cout << "������� ���������� ����������: " << area << endl;
        cout << endl;
    }
};
int main()
{
    setlocale(LC_ALL, "Russian");
    int n = 0;
    cout << "������� ������ �������: " << endl;
    cin >> n;
    City** city = new City * [n];
    for (int i = 0; i < n; i++)
    {
        city[i] = new City;
    }
    for (int i = 0; i < n; i++)
    {
        cout << "������� �������� ������: ";
        cin >> city[i]->name;
        cout << "������� ���� ��������� ������: ";
        cin >> city[i]->date;
        cout << "������� ���������� ������� ������: ";
        cin >> city[i]->inhabitants;
        cout << "������� ������� ���������� ���������� ������: ";
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
