#ifndef INC_01_STRING_GEN_HPP
#define INC_01_STRING_GEN_HPP
#include "MatrixMull.hpp"
using namespace std;

typedef void (*gen_func_t)(data_t* m, int s);

void gen_best_case(data_t* m, int size);


#endif
