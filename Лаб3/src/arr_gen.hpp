#ifndef INC_01_STRING_GEN_HPP
#define INC_01_STRING_GEN_HPP
#include <vector>
using namespace std;
typedef void (*gen_func_t)(int, vector<int>&);

void gen_best_case(int len, vector<int>&);

void gen_normal_case(int len, vector<int>&);

void gen_worst_case(int len, vector<int>&);

#endif
