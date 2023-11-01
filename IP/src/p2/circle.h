#pragma once


class circle{
    private:
        float radius = 0;
        float x_center = 0;
        float y_center = 0;
    public:
        circle ();
        circle (float r, float x, float y);
        void set_circle (float r, float x, float y);
        float square ();
        bool triangle_around (float a, float b, float c);
        bool triangle_in (float a, float b, float c);
        bool check_circle (float r, float x_cntr, float y_cntr);
};