#include <iostream>
#include "dict.h"
#include <string>


int main()
{
    int size, hashSize;
    std::cout << "input dict size and hashsize: ";
    std::cin >> size >> hashSize;

    // int newElement;
    // Dict<int> dict(size, hashSize, [size](int key){ return key % size; });
    std::string newElement;
    Dict<std::string> dict(size, hashSize, [size](std::string key)
    { 
        int h = 0;
        for (auto e : key) h += (int)e;
        return h % size; 
    });


    std::cout << "Input elements to add" << std::endl;
    while (true)
    {
        std::cout << "----------" << std::endl;
        dict.out();
        std::cout << "----------" << std::endl;
        std::cin >> newElement;
        dict.set(newElement);
    }

}