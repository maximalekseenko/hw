#include "eq2.h"
#include "rational.h"

#include <iostream>
#include <vector>


int task2(){
    std::vector<rational> rationals;

    double a, b;
    // input
    for (int i = 0; i < 3; i ++){
        rational _rational;
        std::cout << "input a and b for a rational at " << &_rational << std::endl;
        std::cin >> a >> b;
        _rational.set(a, b);
        rationals.push_back(_rational);
    }

    // output
    for (auto _rational : rationals){
        _rational.show();
    }

    return 1;
}