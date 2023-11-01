#include <iostream>
#include <vector>

#include "triangle.h"
#include "circle.h"
#include "figure.h"


int task3(){

    std::vector<figure> figures;

    // input
    double x1, x2, x3, x4, y1, y2, y3, y4;
    for (int i = 0; i < 3; i ++){
        std::cout << "input x1, x2, x3, x4, y1, y2, y3, y4 for a figure" << std::endl;
        std::cin >> x1 >> x2 >> x3 >> x4 >> y1 >> y2 >> y3 >> y4;
        figures.push_back(figure(x1, x2, x3, x4, y1, y2, y3, y4));
    }

    // output
    for (figure& _figure : figures){
        _figure.show();

        std::cout << " prug " << _figure.is_prug() << std::endl;
        std::cout << " square " << _figure.is_square() << std::endl;
        std::cout << " romb " << _figure.is_romb() << std::endl;
        std::cout << " in circle " << _figure.is_in_circle() << std::endl;
        std::cout << " out circle " << _figure.is_out_circle() << std::endl;
    }

    return 1;   
}