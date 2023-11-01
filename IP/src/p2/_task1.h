#include <iostream>
#include <vector>

#include "triangle.h"
#include "circle.h"
#include "figure.h"


int task1(){
    triangle triangles[3];

    // input
    double a, b, c;
    for (triangle& _triangle: triangles){
        std::cout << "input 3 sides for a triangle at " << &_triangle << std::endl;
        while (!_triangle.exst_tr()){
            std::cin >> a >> b >> c;
            _triangle.set(a, b, c);
        }
    }

    // output
    for (triangle& _triangle: triangles){
        _triangle.show();
        std::cout << " perimeter is " << _triangle.perimetr() << std::endl;
        std::cout << " square is " << _triangle.square() << std::endl;
        
    }

    return 1;   
}