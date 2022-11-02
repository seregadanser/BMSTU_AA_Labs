#include "arr_gen.hpp"
#include <random>

using namespace std;

void gen_best_case(int len, vector<int>& arr) {
    for (int i = 0; i < len; i++) {
        arr.push_back(i);
    }
}

void gen_normal_case(int len, vector<int>& arr) {
    for (int i = 0; i < len; i++) {
        arr.push_back(rand() % len);
    }
}

void gen_worst_case(int len, vector<int>& arr) {
    for (int i = 0; i < len; i++) {
        arr.push_back(len - i - 1);
    }
}
