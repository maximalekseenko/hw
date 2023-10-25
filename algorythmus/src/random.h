#ifndef RANDOM_H
#define RANDOM_H

#ifndef _LIBCPP_RANDOM
    #include <random>
#endif //_LIBCPP_RANDOM

#ifndef _LIBCPP_MATH_H
    #include <math.h>
#endif // _LIBCPP_MATH_H


class Random{
    private:
        static std::uniform_real_distribution<double> distrib;
        static std::random_device dev;
        static std::mt19937 gen;

    public:
        static double Double(){
            return distrib(gen);
        }
        static int FromRange(int a, int b){
            return round(distrib(gen) * (b - a) + a);
        }
};

std::uniform_real_distribution<double> Random::distrib = std::uniform_real_distribution<double>(0, 1);
std::random_device Random::dev = std::random_device();
std::mt19937 Random::gen = std::mt19937(Random::dev());


#endif