#include <iostream>

using namespace std;

void F(int n)
{
	cout << n << endl;
	if (n < 6)
	{
		F(n + 2);
		F(n * 3);
	}
}

int main()
{
	F(1);

	return 0;
}