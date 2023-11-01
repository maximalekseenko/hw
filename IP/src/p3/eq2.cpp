#include "eq2.h"
#include <math.h>
#include <algorithm>


eq2 eq2::operator+ (eq2 &obj2) {
    return eq2(this->a + obj2.a, this->b + obj2.b, this->c + obj2.c);
}

eq2::eq2(){}

eq2::eq2 (double a1, double b1, double c1){
    this->set(a1, b1, c1);
}

void eq2::set (double a1, double b1, double c1){
    this->a = a1;
    this->b = b1;
    this->c = c1;
    this->D = pow(this->b, 2) - 4 * this->a * this->c;
}

double eq2::find_X (){
    if (D < 0) return 0;
    if (D == 0) return (-b + sqrt(this->D)) / (2 * this->a);
    if (D > 0) return std::max((-b + sqrt(this->D)) / (2 * this->a), (-b - sqrt(this->D)) / (2 * this->a));
    return 0;
}

double eq2::find_Y (double x1){
    return this->a * pow(x1, 2) + this->b * x1 + this->c;
}
