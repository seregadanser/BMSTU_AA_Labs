#include "time_compare.hpp"
#include "getCPUTime.hpp"
#include <iostream>
#include <iomanip>

using namespace std;

void time_compare(gen_func_t gen_func) {
    double start;
    double end;
    double copy_t;
    int repeats = 1000000;
    cout << setw(33) << "Time in ms" << endl;
    cout << setw(3) << "Len" << setw(15) << "Smooth" << setw(15) << "Merge" << setw(15) << "Bucket" << endl;
    for (int len = 10; len < 100; len += 10) {
        cout << setw(3) << len;

        vector<int> arr, arr_copy;

        gen_func(len, arr);
        //memcpy(arr_copy, arr, len * sizeof(int));
        copy(arr.begin(), arr.end(), back_inserter(arr_copy));
        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            copy(arr.begin(), arr.end(), back_inserter(arr_copy));
            arr_copy.clear();
        }
        end = getCPUTime();
        copy_t = (end - start) / repeats;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            copy(arr.begin(), arr.end(), back_inserter(arr_copy));
            smooth_sort(arr_copy);
            arr_copy.clear();
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats - copy_t;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            copy(arr.begin(), arr.end(), back_inserter(arr_copy));
            merge_sort(arr_copy, 0, len - 1);
            arr_copy.clear();
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats - copy_t;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            copy(arr.begin(), arr.end(), back_inserter(arr_copy));
            bucketSort(arr_copy, len, 6);
            arr_copy.clear();
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats - copy_t << endl;

    }
     repeats = 100000;
     for (int len = 100; len < 600; len += 100) {
         cout << setw(3) << len;

         vector<int> arr, arr_copy;

         gen_func(len, arr);
         //memcpy(arr_copy, arr, len * sizeof(int));
         copy(arr.begin(), arr.end(), back_inserter(arr_copy));
         start = getCPUTime();
         for (int i = 0; i < repeats; i++) {
             copy(arr.begin(), arr.end(), back_inserter(arr_copy));
             arr_copy.clear();
         }
         end = getCPUTime();
         copy_t = (end - start) / repeats;

         start = getCPUTime();
         for (int i = 0; i < repeats; i++) {
             copy(arr.begin(), arr.end(), back_inserter(arr_copy));
             smooth_sort(arr_copy);
             arr_copy.clear();
         }
         end = getCPUTime();
         cout << setw(15) << (end - start) / repeats - copy_t;


         start = getCPUTime();
         for (int i = 0; i < repeats; i++) {
             copy(arr.begin(), arr.end(), back_inserter(arr_copy));
             merge_sort(arr_copy, 0, len - 1);
             arr_copy.clear();
         }
         end = getCPUTime();
         cout << setw(15) << (end - start) / repeats - copy_t;

   
         start = getCPUTime();
         for (int i = 0; i < repeats; i++) {
             copy(arr.begin(), arr.end(), back_inserter(arr_copy));
             bucketSort(arr_copy, len, 6);
             arr_copy.clear();
         }
         end = getCPUTime();
         cout << setw(15) << (end - start) / repeats - copy_t << endl;
     }
}
