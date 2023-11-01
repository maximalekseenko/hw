#include <iostream>
#include "treeHeap.h"
#include "random.h"
#include <string>

int main() {
    char task = 'A';
    int num = 20;
    
    std::cout << ">>Input heap size: ";
    std::cin >> num;

    TreeHeap heap(num, {6, 3, 8, 4, 7, 0, 2, 7});


    std::cout << "---COMMANDS---" << std::endl;
    std::cout << "1) get root" << "\t";
    std::cout << "2) delete root" << "\t";
    std::cout << "3) add element" << std::endl;
    std::cout << "4) quit" << std::endl;


    while (task != ' '){
        std::cout << std::endl;
        std::cout << "---TREE---" << std::endl;
        std::cout << heap.ToString() << std::endl;

        std::cout << ">>command: ";
        std::cin >> task;
        
        switch (task) {
            case '1':
                std::cout << "<<: " << heap.getRoot();
                break;
            case '2':
                heap.deleteKey(heap.getRoot());
                break;
            case '3':
                std::cin >> num;
                heap.insertKey(num);
                break;
            
            default: task = ' ';
        }
    }
}