#include "cone.h"
#include <iostream>
#include <math.h>


Cone::Cone() 
        : x(0), y(0), z(0), 
        radius(0), height(0) {}

Cone::Cone(double __radius, double __height) 
        : x(0), y(0), z(0), 
        radius(__radius), height(__height) {}

Cone::Cone(double __x, double __y, double __z, double __radius, double __height) 
        : x(__x), y(__y), z(__z), 
        radius(__radius), height(__height) {}

void Cone::In() {
    std::cout << "input " << this << ".x: "; std::cin >> x;
    std::cout << "input " << this << ".y: "; std::cin >> y;
    std::cout << "input " << this << ".z: "; std::cin >> z;
    std::cout << "input " << this << ".radius: "; std::cin >> radius;
    std::cout << "input " << this << ".height: "; std::cin >> height;
}

void Cone::Out() {
    std::cout << "<Cone at " << this << " with";
    std::cout << " x=" << x <<  " y=" << y <<  " z=" << z;
    std::cout << " r=" << radius <<  " h=" << height;
    std::cout << '>' << std::endl;
}

double Cone::P() {
    return M_PI * radius * (radius + sqrt(height * height + radius * radius));
}

double Cone::V() {
    return M_PI * radius * radius * height / 3;
}



ConeFrustum::ConeFrustum()
        : radius2(), 
        Cone() {}

ConeFrustum::ConeFrustum(double __radius, double __radius2, double __height)
        : radius2(__radius2), 
        Cone(__radius, __height) {}
ConeFrustum::ConeFrustum(double __x, double __y, double __z, double __radius, double __radius2, double __height)
        : radius2(__radius2), 
        Cone(__x, __y, __z, __radius, __height) {}



std::istream &operator>>(std::istream &stream, ConeFrustum &cone) {
    std::cout << "input " << &cone << ".x: "; stream >> cone.x;
    std::cout << "input " << &cone << ".y: "; stream >> cone.y;
    std::cout << "input " << &cone << ".z: "; stream >> cone.z;
    std::cout << "input " << &cone << ".radius: "; stream >> cone.radius;
    std::cout << "input " << &cone << ".radius2: "; stream >> cone.radius2;
    std::cout << "input " << &cone << ".height: "; stream >> cone.height;
    return stream;
}

std::ostream &operator<<(std::ostream &stream, ConeFrustum &cone) {
    stream << "<ConeFrustum at " << &cone << " with";
    stream << " x=" << cone.x <<  " y=" << cone.y <<  " z=" << cone.z;
    stream << " r=" << cone.radius << " r2=" << cone.radius2 <<  " h=" << cone.height;
    stream << '>' << std::endl;
    return stream;
}

bool ConeFrustum::operator==(ConeFrustum &cone) {
    return (this->radius == cone.radius) && (this->radius2 == cone.radius2) && (this->height == cone.height);
}

double ConeFrustum::P() {
    double hx = height / (1 - radius2 / radius);
    return Cone(radius, hx).P() + Cone(radius2, hx - height).P() - M_PI * radius2 * radius2 * 2;
}

double ConeFrustum::V() {
    double hx = height / (1 - radius2 / radius);
    return Cone(radius, hx).V() - Cone(radius2, hx - height).V();
}