#include "eq2.h"
#include "rational.h"

#include <iostream>
#include <vector>


int task1(){
    eq2 A, B, C;
    double a, b, c, x;

    std::cout << "input a, b and c for equasion at " << &A << std::endl;
    std::cin >> a >> b >> c;
    A.set(a, b, c);

    std::cout << "input a, b and c for equasion at " << &B << std::endl;
    std::cin >> a >> b >> c;
    B.set(a, b, c);

    C = A + B;

    std::cout << "input x for equasions at " << &A << " and " << &B << std::endl;
    std::cin >> x;

    std::cout << &A << ":" << std::endl;
    std::cout << " x is " << A.find_X() << std::endl;
    std::cout << " y is " << A.find_Y(x) << std::endl;

    std::cout << &B << ":" << std::endl;
    std::cout << " x is " << B.find_X() << std::endl;
    std::cout << " y is " << B.find_Y(x) << std::endl;

    std::cout << &A << " + " << &B << ":" << std::endl;
    std::cout << " x is " << C.find_X() << std::endl;
    std::cout << " y is " << C.find_Y(x) << std::endl; 

    return 1;   
}