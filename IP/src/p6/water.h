#include <string>
#include <iostream>



class Gulf {
    public:
        std::string name;

        friend std::ostream& operator<<(std::ostream& stream, Gulf& __gulf);

        Gulf();
        Gulf(std::string __name);
};

class Sea : virtual public Gulf {
    public:
        std::string name;

        friend std::ostream& operator<<(std::ostream& stream, Sea& __sea);

        Sea();
        Sea(std::string __name);
        Sea(std::string __name, Gulf& __gulf);

};

class Ocean : virtual public Sea, virtual public Gulf {
    public:
        std::string name;

        friend std::ostream& operator<<(std::ostream& stream, Ocean& __ocean);

        Ocean();
        Ocean(std::string __name);
        Ocean(std::string __name, Sea& __sea);
        Ocean(std::string __name, Gulf& __gulf);
        Ocean(std::string __name, Sea& __sea, Gulf& __gulf);
};