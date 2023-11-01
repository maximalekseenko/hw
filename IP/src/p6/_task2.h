#include <iostream>


int task2(){
    // Объявите несколько усеченных конусов, выведите на экран их площади поверхности и объемы.
    ConeFrustum A, B;
    std::cin >> A;
    std::cout << A << "P=" << A.P() << " V=" << A.V() << std::endl;
    std::cin >> B;
    std::cout << B << "P=" << B.P() << " V=" << B.V() << std::endl;
    std::cout << (A == B? "A == B" : "A != B") << std::endl;
    return 1;
}