#include <iostream>
#include <map>
#include <string>


std::map<char, int> hash;

void f(std::string line)
{
    for (auto element : line)
    {
        auto iter = hash.find(element);
        if (iter == hash.end()) hash.insert({element, 1});
        else iter->second ++;
    }

    for (auto item : hash)
        std::cout << item.first << " : " << item.second << std::endl;
}
int main()
{
    std::string line;
    std::cout << "Input line with no spaces: ";
    std::cin >> line;
    f(line);
}