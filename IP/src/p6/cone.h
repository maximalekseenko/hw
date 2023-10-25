#pragma once

#include <iostream>

class Cone {
    public:
        double x, y, z;
        double radius;
        double height;
    
        Cone();
        Cone(double __radius, double __height);
        Cone(double __x, double __y, double __z, double __radius, double __height);

        void In();
        void Out();

        double P();
        double V();
};


class ConeFrustum : public Cone {
    public:
        double radius2;

        ConeFrustum();
        ConeFrustum(double __radius, double __radius2, double __height);
        ConeFrustum(double __x, double __y, double __z, double __radius, double __radius2, double __height);
        
        friend std::istream &operator>>(std::istream &stream, ConeFrustum &cone);
        friend std::ostream &operator<<(std::ostream &stream, ConeFrustum &cone);

        bool operator==(ConeFrustum &cone);

        double P();
        double V();
};