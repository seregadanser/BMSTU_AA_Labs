#include "Matrix.hpp"


void free_matrix(data_t *m)
{
    int n = m->n;
    for (int i = 0; i < n; i++)
        free(m->matrix[i]);
    free(m->matrix);
}

int** create_matrix(const int n, const int m)
{
    int** data = (int **)calloc(n, sizeof(int*));
    if (!data)
        return NULL;
    for (int i = 0; i < n; i++)
    {
        data[i] = (int*)malloc(m * sizeof(int));
     
    }
    return data;
}

