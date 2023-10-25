#include <iostream>
#include <string>
#include <random>
#include <algorithm>



const std::string alphabet = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";


int main()
{


    std::string line;
    std::cout << "Input line in CAPS with no spaces: ";
    std::cin >> line;

    int key;
    std::cout << "Input key fow Caesaw encoding: ";
    std::cin >> key;

    std::mt19937 gen((std::random_device()()));
    std::string newAlphabet = alphabet;
    std::shuffle(newAlphabet.begin(), newAlphabet.end(), gen);
    std::cout << "Alphabet for chande encoding: ";
    for (auto element : newAlphabet)
        std::cout << element;
    std::cout << std::endl;
    
    std::cout << "Line encoded with Caesaw encoding: ";
    for (auto element : line)
        std::cout << alphabet[(alphabet.size() + key + alphabet.find(element)) % alphabet.size()];
    std::cout << std::endl;

    std::cout << "Line encoded with change encoding: ";
    for (auto element : line)
        std::cout << newAlphabet[alphabet.find(element)];
    std::cout << std::endl;

        
}