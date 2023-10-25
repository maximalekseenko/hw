#include "triangle.h"
#include <iostream>
#include <math.h>



bool triangle::exst_tr(){
    return (this->a + this->b > this->c) && (this->a + this->c > this->b) && (this->b + this->c > this->a);
}

void triangle::set (double a1, double b1, double c1){
    this->a = a1;
    this->b = b1;
    this->c = c1;
}

void triangle::show (){
    std::cout << "<triangle at " << this << " with sides: " << this->a << " " << this->b << " " << this->c << ">" << std::endl;
}

double triangle::perimetr (){
    return this->a + this->b + this->c;
}

double triangle::square (){
    double p = this->perimetr() / 2;
    return sqrt(p * (p - this->a) * (p - this->b) * (p - this->c));
}
