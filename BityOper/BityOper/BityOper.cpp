#include <iostream>
using namespace std;

int Decrease(int);
void HiB(int, int);

int main()
{
    cout << "\tKravchuk Maxim\n\tIS-92\n";
    int a;
    int b;
    cout<<"Enter First and Second digits\n";
    cin >> a;
    cin >> b;
    HiB(a, b);
    cout<<a<<" - 1 = "<< Decrease(a)<<endl<<b<<" - 1 = "<<Decrease(b);
}
int Decrease(int a)
{
    int b = ~- a;
    return b;
}
void HiB(int a, int b)
{
    int ans = b & ((a - b) >> 31) | a & (~(a - b) >> 31);
    cout<<ans<<" is bigger\n";
}
