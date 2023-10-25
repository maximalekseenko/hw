#include <iostream>
#include <tuple>
#include <cstdio>


void gcdex(int a, int b, int* d, int* x, int* y)
{
    if (b == 0)
    {
        *d = a;
        *x = 1;
        *y = 0;
    }
    else gcdex(b, a%b, d, x, y);
}

int main() {
    int a,b,d,x,y;
    std::cout << "gcdex:";
    std::cout << "a="; std::cin >> a;
    std::cout << "b="; std::cin >> b;
    gcdex(a, b, &d, &x, &y);
    std::printf("gcdex: %i * %i + %i * %i = %i", a,x,b,y,d);
}
