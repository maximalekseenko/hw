#include <iostream>
#include <vector>


#include "_task1.h"
#include "_task2.h"
#include "_task3.h"


int main(int argc, char *argv[]){

    // run
    switch (*argv[1]) {
        case '1': return task1();
        case '2': return task2();
        case '3': return task3();
        default: throw;
    }
}