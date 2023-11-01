#pragma once



class triangle {
    public:
        double a = 0;
        double b = 0;
        double c = 0;

        bool exst_tr();
        void set (double a1, double b1, double c1);
        void show ();
        double perimetr ();
        double square ();
};