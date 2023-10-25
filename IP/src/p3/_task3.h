#include "eq2.h"
#include "rational.h"

#include <iostream>
#include <vector>


int task3(){
    rational r1, r2;
    int a, b;

    // input
    std::cout << "input a and b for a rational at " << &r1 << std::endl;
    std::cin >> a >> b;
    r1.set(a, b);
    std::cout << "input a and b for a rational at " << &r2 << std::endl;
    std::cin >> a >> b;
    r2.set(a, b);

    //output
    std::cout << &r1 << " + " << &r2 << " = ";
    (r1 + r2).show();
    std::cout << &r1 << " - " << &r2 << " = ";
    (r1 - r2).show();
    // std::cout << &r1 << " ++ " << " = ";
    // (r1++).show();
    std::cout << &r1 << " == " << &r2 << " = " << (r1 == r2) << std::endl;
    std::cout << &r1 << " > " << &r2 << " = " << (r1 > r2) << std::endl;
    std::cout << &r1 << " < " << &r2 << " = " << (r1 < r2) << std::endl;
    
    return 1;
}