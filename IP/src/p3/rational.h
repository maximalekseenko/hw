#pragma once

class rational{
    public:
        int a, b;
        rational();
        rational (int a1, int b1);
        void set (int a1, int b1);
        void show ();

        rational operator+(rational& _obj);
        rational operator-(rational& _obj);
        bool operator==(rational& _obj);
        bool operator>(rational& _obj);
        bool operator<(rational& _obj);
};