#include "cone.h"

#include <iostream>


int task1(){
    // Объявите конус с центром в начале координат и произвольный конуса как статические объекты созданного типа, найдите площадь поверхности и объём каждого.
    Cone c1(3, 7);
    Cone c2(1, 2, 3, 5, 10);

    std::cout << "c1.P = " << c1.P() << " c1.V = " << c1.V() << std::endl;
    std::cout << "c2.P = " << c2.P() << " c2.V = " << c2.V() << std::endl;

    // Объявите динамический объект по умолчанию, введите данные и выведите на экран.
    Cone *c3 = new Cone();
    c3->In();
    c3->Out();
    delete c3;

    // Объявите массив из 2-3 конусов. Найдите способ присвоить им значения при создании объектов.
    c3 = new Cone[3];
    for (int i = 0; i < 3; i ++){
        c3[i] = Cone();
        c3[i].In();
    }

    return 1;   
}