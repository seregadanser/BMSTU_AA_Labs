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

void free_matrix(data_t *m);
int** create_matrix(const int n, const int m);

#endif