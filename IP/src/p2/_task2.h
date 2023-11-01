#include <iostream>
#include <vector>

#include "triangle.h"
#include "circle.h"
#include "figure.h"


int task2(){
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

    std::vector<circle> circles;

    // input
    double r, x, y;
    for (int i = 0; i < 3; i ++){
        circle _circle;
        std::cout << "input radius, x and y for a circle at " << &_circle << std::endl;
        std::cin >> r >> x >> y;
        _circle.set_circle(r, x, y);
        circles.push_back(_circle);
    }

    // output
    for (circle& _circle : circles){
        std::cout << "circle at " << &_circle << std::endl;
        std::cout << " square is " << _circle.square() << std::endl;

        for (triangle& _triangle: triangles){
            std::cout << " for triangle at " << &_triangle << std::endl;
            std::cout << "  around is " << _circle.triangle_around(_triangle.a, _triangle.b,c) << std::endl;
            std::cout << "  in is " << _circle.triangle_in(_triangle.a, _triangle.b,c) << std::endl;
        }
        for (circle& _circle : circles){
            for (circle& _circle2 : circles){
                std::cout << &_circle << " " << &_circle2 << std::endl;
                // std::cout << " check_circle for circles at " << &_circle << " and " << &_circle2 << " is " << _circle.check_circle(&_circle.) << std::endl;
                
            }
        }
    }

    return 1;   
}