#include "figure.h"
#include "triangle.h"
#include <math.h>
#include <iostream>



figure::figure(){}


figure::figure (float x1, float x2, float x3, float x4, float y1, float y2, float y3, float y4){
    this->x1 = x1;
    this->x2 = x2;
    this->x3 = x3;
    this->x4 = x4;

    this->y1 = y1;
    this->y2 = y2;
    this->y3 = y3;
    this->y4 = y4;

    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    float diagonale1 = sqrt(pow(this->x1 - this->x3, 2) + pow(this->y1 - this->y3, 2));
    float diagonale2 = sqrt(pow(this->x2 - this->x4, 2) + pow(this->y2 - this->y4, 2));

    triangle triangle1, triangle2;
    triangle1.set(side1, side2, diagonale1);
    triangle1.set(side3, side4, diagonale1);

    this->P = side1 + side2 + side3 + side4;
    this->S = triangle1.square() + triangle2.square();
}

void figure::show(){
    std::cout << "<figure at " << this << " with points at" 
        << "(" << this->x1 << "," << this->y1 << "), "
        << "(" << this->x2 << "," << this->y2 << "), "
        << "(" << this->x3 << "," << this->y3 << ") and "
        << "(" << this->x4 << "," << this->y4 << "); "
        << "P=" << this->P << ", S=" << this->S
        << ">" << std::endl;
}

bool figure::is_prug(){
    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    float diagonale1 = sqrt(pow(this->x1 - this->x3, 2) + pow(this->y1 - this->y3, 2));
    float diagonale2 = sqrt(pow(this->x2 - this->x4, 2) + pow(this->y2 - this->y4, 2));
    return (side1 == side3) && (side2 == side4) && (diagonale1 == diagonale2);
}

bool figure::is_square(){
    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    float diagonale1 = sqrt(pow(this->x1 - this->x3, 2) + pow(this->y1 - this->y3, 2));
    float diagonale2 = sqrt(pow(this->x2 - this->x4, 2) + pow(this->y2 - this->y4, 2));
    return (side1 == side2 == side3 == side4) && (diagonale1 == diagonale2);
}

bool figure::is_romb(){
    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    float diagonale1 = sqrt(pow(this->x1 - this->x3, 2) + pow(this->y1 - this->y3, 2));
    float diagonale2 = sqrt(pow(this->x2 - this->x4, 2) + pow(this->y2 - this->y4, 2));
    return (side1 == side2 == side3 == side4);
}

bool figure::is_in_circle(){
    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    return side1 + side3 == side2 + side4;
}

bool figure::is_out_circle(){
    float side1 = sqrt(pow(this->x1 - this->x2, 2) + pow(this->y1 - this->y2, 2));
    float side2 = sqrt(pow(this->x2 - this->x3, 2) + pow(this->y2 - this->y3, 2));
    float side3 = sqrt(pow(this->x3 - this->x4, 2) + pow(this->y3 - this->y4, 2));
    float side4 = sqrt(pow(this->x4 - this->x1, 2) + pow(this->y4 - this->y1, 2));
    float diagonale1 = sqrt(pow(this->x1 - this->x3, 2) + pow(this->y1 - this->y3, 2));
    float diagonale2 = sqrt(pow(this->x2 - this->x4, 2) + pow(this->y2 - this->y4, 2));
    return diagonale1 * diagonale2 == side1 * side3 + side2 * side4;
}

