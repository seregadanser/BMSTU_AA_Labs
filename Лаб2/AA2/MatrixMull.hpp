#ifndef UNIT_MATRIX_H
#define UNIT_MATRIX_H

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define WRONG_SIZE 12
#define NULL_ELEMENTS 7

typedef struct
{
    int** matrix;
    int n;
    int m;
} data_t;

void free_matrix(int** data, int n);
int** create_matrix(const int n, const int m);

data_t matrix_multiplication(data_t m1, data_t m2);
data_t matrix_multiplication_Vinograd(const data_t m1, const data_t m2);
data_t matrix_multiplication_VinogradOptimase(const data_t m1, const data_t m2);

#endif