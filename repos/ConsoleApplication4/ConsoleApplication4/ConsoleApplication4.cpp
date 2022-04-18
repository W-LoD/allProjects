#include <iostream>
using namespace std;

int main()
{
    int n, m;
    cout << " Введите  n и m" << endl;
    cin >> n >> m;
    int i = 0, j = 0, lab = 1, s = 0, f = 0;
    int mas[n][m];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            mas[i][j] = 0;
            cout << mas[i][j] << " ";
        }
    }
    cout << endl;
    while (f != (n * m)) {
        if (s = 0)
        {
            for (; j < m - lab; j++)
            {
                cin >> mas[i][j];
                f++;
            }
            for (; i < n - lab; i++)
            {
                cin >> mas[i][j];
                f++;
            }
            s++;
        }
        else
        {
            for (; j <= 0; j--)
            {
                cin >> mas[i][j];
                f++;
            }
            for (; i <= lab; i--)
            {
                cin >> mas[i][j];
                f++;
            }
            s--;
            lab++;
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j] << " ";
        }
    }
    return 0;
}
