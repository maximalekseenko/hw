#include <iostream>
#include "tree.h"
#include "random.h"
#include <string>

int main() {
    char task = 'A';
    int num = 20;

    // std::cin >> num;
    Tree root(Random::FromRange(0, 100));
    for (int i = 0; i < num; i ++) root.AddNode(Random::FromRange(0, 100));

    while (task != ' '){
        std::cout << "Для готового дерева операции:" << std::endl;
        std::cout << "1 a) добавление нового узла в дерево;" << std::endl;
        std::cout << "2 b) обход дерева (прямой, обратный или симметричный – по выбору) и печать элементов дерева на экран;" << std::endl;
        std::cout << "3 c) вычисление глубины (высоты) дерева;" << std::endl;
        std::cout << "4 d) поиск конкретного элемента в дереве" << std::endl;
        std::cout << "5 e*) удаление определенного узла в дереве;" << std::endl;

        std::cin >> task;
        switch (task) {
            case '1': case 'a':
                std::cin >> num;
                root.AddNode(num);
                break;
            case '2': case 'b':
                root.PrintTree();
                break;
            case '3': case 'c':
                std::cout << root.DepthTree() << std::endl;
                break;
            case '4': case 'd':
                std::cin >> num;
                std::cout << root.SearchNode(num)->__get_value() << std::endl;
                break;
            case '5': case 'e':
                std::cin >> num;
                root.SearchNode(num)->DelNode();
                break;
            
            default: task = ' ';
        }
    }

    root.DelTree();
}