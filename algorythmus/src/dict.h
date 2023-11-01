#include <functional>
#include <iostream>

template<typename T>
struct Dict
{
    protected:
        std::function<int(T)> f;
        int size, hashSize;
        int *hashSums;
        T** data;

    public:
        Dict(int size, int hashSize, std::function<int(T)> f)
            : data(new T*[size]), 
            f(f),
            size(size), 
            hashSize(hashSize), hashSums(new int[size])
        {
            for (int i = 0; i < size; i ++)
            {
                data[i] = nullptr;
                hashSums[i] = 0;
            }
        }

        ~Dict()
        {
            for (int i = 0; i < size; i ++)
                if (data[i] != nullptr)
                    delete[] data[i];
            delete[] data;
            delete[] hashSums;
        }

    public:
        // T get(T key)
        // {
        //     int iKey = f(key);
        //     if (iKey >= hashSize) throw std::runtime_error("iKey error with " + std::to_string(key));

        //     for (int i = 0; i < hashSums[iKey]; i ++)
        //     {
        //         if (data[iKey][i])
        //         return 
        //     }

        //     return
        // }

        void set(T key)
        {
            int iKey = f(key);
            if (iKey >= hashSize) throw std::runtime_error("iKey error");

            if (hashSums[iKey] == 0)
                data[iKey] = new T[hashSize];

            if (hashSums[iKey] == hashSize) throw std::runtime_error("hash overflow error");

            data[iKey][hashSums[iKey]] = key;
            hashSums[iKey] ++;
        }


        void out()
        {
            std::cout << "\t\t";
            for (int iHash = 0; iHash < hashSize; iHash ++)
                std::cout << iHash << "\t";
            std ::cout << std::endl;


            for (int iData = 0; iData < size; iData ++){
                std::cout << iData << "\t|\t";
                for (int iHash = 0; iHash < hashSize; iHash ++){
                    if (hashSums[iData] != 0 && hashSums[iData] > iHash)
                        std::cout << data[iData][iHash] << '\t';
                    else std::cout << " " << '\t';
                }
                std::cout << std::endl;
            }
        }
};