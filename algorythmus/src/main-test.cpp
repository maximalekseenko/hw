template<class T>
class Number{
    T data;
    Number(T num) { data = num ;}
    bool operator==(T &other){ return data == other; }
};

template<typename T>
class Integer : public Number<T> {
    int iData;
    // Integer(int i) { iData = i ; }
    bool operator==(Integer &other){ return iData == other.iData; }

};

// template <typename T>
// struct Base {
//     Base(int value) : value(value) {}
//     int value;

//     T* V1;
//     T* V2;

//     T* Foo1(){return V1;}
//     T* Foo2(){return V2;}
// };

// template <typename T>
// struct Derived : Base<T> {
//     using Base::Base;
//     T* Foo1(){return V2;}
//     T* Foo2(){return V1;}
// };


int main() {

}