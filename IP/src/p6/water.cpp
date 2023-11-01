#include "water.h"

#include <iostream>
#include <string>



std::ostream& operator<<(std::ostream& stream, Gulf& __gulf) {
    stream << __gulf.name << " gulf";
    return stream;
}

Gulf::Gulf() : name("no") {}
Gulf::Gulf(std::string __name) : name(__name) {}



std::ostream& operator<<(std::ostream& stream, Sea& __sea) {
    stream << __sea.name << " sea with " << __sea.Gulf::name << " gulf";
    return stream;
}

Sea::Sea() : name("no") {}
Sea::Sea(std::string __name) : name(__name) {}
Sea::Sea(std::string __name, Gulf& __gulf) : name(__name), Gulf(__gulf) {}




std::ostream& operator<<(std::ostream& stream, Ocean& __ocean) {
    stream << __ocean.name << " ocean with " << __ocean.Sea::name << " sea and " << __ocean.Gulf::name << " gulf";
    return stream;
}

Ocean::Ocean() : name("no") {}
Ocean::Ocean(std::string __name) : name(__name) {}
Ocean::Ocean(std::string __name, Sea& __sea) : name(__name), Sea(__sea) {}
Ocean::Ocean(std::string __name, Gulf& __gulf) : name(__name), Gulf(__gulf) {}
Ocean::Ocean(std::string __name, Sea& __sea, Gulf& __gulf) : name(__name), Sea(__sea), Gulf(__gulf) {}