#include <iostream>

#include "water.h"


int task3(){

    // sea, no gulf
    Sea s1("S1");
    std::cout << s1 << std::endl << std::endl;

    // ocean with sea
    Sea s2("S2");
    Ocean o2("O2", s2);
    std::cout << o2 << std::endl << std::endl;

    // ocean with gulf and sea, but sea with no gluf
    Gulf g3("G3");
    Sea s3("S3");
    Ocean o3("O3", s3, g3);

    std::cout << o3 << std::endl;
    std::cout << s3 << std::endl << std::endl;

    return 1;
}