#include <initializer_list>
#include <iostream>
#include <climits>

#include <string>
#include <regex>


// Prototype of a utility function to swap two integers
void swap(int *x, int *y);

///@brief A class for Heap
class TreeHeap {


    private: // +++VARIABLES+++


        ///@brief Pointer to array of elements in heap
        int *harr;


        ///@brief Maximum possible size of heap
        int capacity; 


        ///@brief Current number of elements in min heap
        int heap_size;

    public: // +++CONSTRUCTORS & DESTRUCTORS+++


        ///@brief Construct a new TreeHeap
        TreeHeap(int capacity, bool ismin = true) : heap_size(0), capacity(capacity), harr(new int[capacity]) {}


        ///@brief Construct a new TreeHeap from a given array
        TreeHeap(int capacity, std::initializer_list<int> init_values, bool ismin = true) : heap_size(0), capacity(capacity), harr(new int[capacity]) {
            for (auto value : init_values) insertKey(value);
        }
        
        ///@brief Destroy the TreeHeap
        ~TreeHeap() { delete[] harr; }

    public: // +++FUNCTIONS+++

        ///@brief Heapifys a subtree with the root at given index
        void MinHeapify(int index){
            int indexL = left(index);
            int indexR = right(index);

            int smallest = index;
            if (indexL < heap_size && comp_less(harr[indexL], harr[index]))
                smallest = indexL;
            if (indexR < heap_size && comp_less(harr[indexR], harr[smallest]))
                smallest = indexR;
                
            if (smallest != index) {
                swap(&harr[index], &harr[smallest]);
                MinHeapify(smallest);
            }
        }


        ///@brief Get parent index by chield index
        int parent(int index) { return (index - 1) / 2; }


        ///@brief Get left chield by parent
        int left(int index) { return (2 * index + 1); }


        ///@brief Get right chield by parent
        int right(int index) { return (2 * index + 2); }


        ///@brief Extracts the root which is the minimum element
        int extractRoot(){
            if (heap_size <= 0)
                return INT_MAX;
            if (heap_size == 1) {
                heap_size--;
                return harr[0];
            }

            // Store the minimum value, and remove it from heap
            int root = harr[0];
            harr[0] = harr[heap_size-1];
            heap_size--;
            MinHeapify(0);

            return root;
        }


        ///@brief Decreases key value of key at index i to new_val
        void decreaseKey(int i, int new_val) {
            harr[i] = new_val;
            while (i != 0 && comp_more(harr[parent(i)], harr[i])) {
                swap(&harr[i], &harr[parent(i)]);
                i = parent(i);
            }
        }


        ///@brief Returns the minimum key (key at root) from min heap
        int getRoot() { return harr[0]; }


        ///@brief Deletes a key stored at index i
        void deleteKey(int i) {
            decreaseKey(i, INT_MIN);
            extractRoot();
        }


        ///@brief Inserts a new key
        void insertKey(int value) {

            // check for heap size
            if (heap_size == capacity)
                throw std::runtime_error("Overflow: Could not insertKey");

            // First insert the new key at the end
            heap_size++;
            int i = heap_size - 1;
            harr[i] = value;

            // Fix the min heap property if it is violated
            while (i != 0 && comp_more(harr[parent(i)], harr[i])) {
                swap(&harr[i], &harr[parent(i)]);
                i = parent(i);
            }
        }

        ///@brief converts heap to string for output
        std::string ToString() { return NodeString(0); }
        
    private: // +++ADDITIONAL FUNCTIONS+++

        std::string NodeString(int index) {
            std::string returnString = std::to_string(harr[index]);
            if (left(index) < heap_size) 
                returnString += "\n├" + std::regex_replace(NodeString(left(index)), std::regex("\n"), "\n│");
            if (right(index) < heap_size) 
                returnString += "\n├" + std::regex_replace(NodeString(right(index)), std::regex("\n"), "\n│");
            return returnString;
        }

        bool comp_more(int val1, int val2) { return val1 < val2; }
        bool comp_less(int val1, int val2) { return val1 > val2; }
};


// A utility function to swap two elements
void swap(int *x, int *y)
{
    int temp = *x;
    *x = *y;
    *y = temp;
}



