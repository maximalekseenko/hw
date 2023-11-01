#include "rational.h"
#include <cstdlib>
#include <numeric>
#include <iostream>


rational::rational (){
    this->set(1, 1);
}

rational::rational (int a1, int b1){
    this->set(a1, b1);
}

void rational::set (int a1, int b1){
    if (b1 == 0) throw;

    if (a1 > b1) a1 = a1 %= b1;

    int gcd = std::gcd(a1, b1);
    a1 /= gcd;
    b1 /= gcd;

    this->a = a1;
    this->b = b1;

}

void rational::show (){
    std::cout << "<rational " << this->a << "/" << this->b <<" at " << this << ">" << std::endl;
}

rational rational::operator+(rational& _obj){
    return rational(this->a * _obj.b + _obj.a * this->b, this->b * _obj.b);
}

rational rational::operator-(rational& _obj){
    return rational(this->a * _obj.b - _obj.a * this->b, this->b * _obj.b);
}

bool rational::operator==(rational& _obj){
    return (this->a == _obj.a) && (this->b == _obj.b);
}

bool rational::operator>(rational& _obj){
    return this->a * _obj.b > _obj.a * this->b;
}

bool rational::operator<(rational& _obj){
    return this->a * _obj.b < _obj.a * this->b;
}
