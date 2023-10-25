#include "circle.h"


#include <math.h>
#include "triangle.h"



circle::circle (){}


circle::circle (float r, float x, float y){
    this->radius = r;
    this->x_center = x;
    this->y_center = y;
}

void circle::set_circle (float r, float x, float y){
    this->radius = r;
    this->x_center = x;
    this->y_center = y;
}

float circle::square (){
    return M_PI * pow(this->radius, 2);
}

bool circle::triangle_around (float a, float b, float c){
    triangle __triangle;
    __triangle.set(a, b, c);
    return __triangle.a * __triangle.b * __triangle.c / 4 / this->radius == __triangle.square();
}

bool circle::triangle_in (float a, float b, float c){
    triangle __triangle;
    __triangle.set(a, b, c);
    return __triangle.perimetr() * this->radius / 2 == __triangle.square();
}

bool circle::check_circle (float r, float x_cntr, float y_cntr){
    return sqrt(pow(x_cntr - this->x_center, 2) + pow(y_cntr - this->y_center, 2)) <= r + this->radius;
}

