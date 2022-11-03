#include "MatrixMull.hpp"
#include <vector>

void free_matrix(int** data, int n)
{
    for (int i = 0; i < n; i++)
        free(data[i]);
    free(data);
}

int** create_matrix(const int n, const int m)
{
    int** data = (int **)calloc(n, sizeof(int*));
    if (!data)
        return NULL;
    for (int i = 0; i < n; i++)
    {
        data[i] = (int*)malloc(m * sizeof(int));
        if (!data[i])
        {
            free_matrix(data, n);
            return NULL;
        }
    }
    return data;
}

data_t matrix_multiplication(const data_t m1, const data_t m2)
{
    data_t result;
    result.n = m1.n;
    result.m = m2.m;
    result.matrix = create_matrix(m1.n, m2.m);
    if (!result.matrix)
        return result;
    for (int i = 0; i < m1.n; i++)
        for (int j = 0; j < m2.m; j++)
        {
            result.matrix[i][j] = 0;
            for (int k = 0; k < m1.m; k++)
                result.matrix[i][j] += m1.matrix[i][k] * m2.matrix[k][j];
        }
   // free_matrix(result.matrix, result.n);
    return result;
}

data_t matrix_multiplication_Vinograd(const data_t m1, const data_t m2)
{
    data_t result;
    result.n = m1.n;
    result.m = m2.m;
    result.matrix = create_matrix(m1.n, m2.m);
    if (!result.matrix)
        return result;
    int n = m1.n;
    int m = n;
    int d = n / 2;
    int *rowFactor = (int *)calloc(n, sizeof(int)), *colFactor = (int*)calloc(n, sizeof(int));

    for (int i = 0; i < n; ++i)
    {
        rowFactor[i] = m1.matrix[i][0] * m1.matrix[i][1];
        for (int j = 1; j < m / 2; ++j)
            rowFactor[i] = rowFactor[i] + m1.matrix[i][2 * j] * m1.matrix[i][2 * j + 1];
    }

    for (int i = 0; i < n; ++i)
    {
        colFactor[i] = m2.matrix[0][i] * m2.matrix[1][i];
        for (int j = 1; j < m / 2; ++j)
            colFactor[i] = colFactor[i] + m2.matrix[2 * j][i] * m2.matrix[2 * j + 1][i];
    };

    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
        {
            result.matrix[i][j] = -(rowFactor[i] + colFactor[j]);
            for (int k = 0; k < m / 2; ++k)
            {
                result.matrix[i][j] = result.matrix[i][j] + (m1.matrix[i][2 * k] + m2.matrix[2 * k + 1][j]) * (m1.matrix[i][2 * k + 1] + m2.matrix[2 * k][j]);
            }
        }

    if (m % 2 != 0)
    {
        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
            {
                result.matrix[i][j] = result.matrix[i][j] + m1.matrix[i][m - 1] * m2.matrix[m - 1][j];
            }
    }
   // free_matrix(result.matrix, result.n);
    free(rowFactor);
    free(colFactor);
    return result;
}

data_t matrix_multiplication_VinogradOptimase(const data_t m1, const data_t m2)
{
    data_t result;
    result.n = m1.n;
    result.m = m2.m;
    result.matrix = create_matrix(m1.n, m2.m);
    if (!result.matrix)
        return result;
       int n = m1.n;
    int m = n;
    int d = n / 2;
    int odd = m % 2 ? 1 : 0;
    int *rowFactor = (int *)calloc(n, sizeof(int)), *colFactor = (int*)calloc(n, sizeof(int));

    for (int i = 0; i < n; ++i)
    {
        for (int j = 1; j < m / 2; ++j)
            rowFactor[i] += m1.matrix[i][ j<<1] * m1.matrix[i][ (j<<1) + 1];
    }

    for (int i = 0; i < n; ++i)
    {
        for (int j = 1; j < m / 2; ++j)
            colFactor[i] += m2.matrix[j<<1][i] * m2.matrix[(j<<1) + 1][i];
    };
    int temp;

    for (int i = 0; i < n; ++i)
        for (int j = 0; j < n; ++j)
        {
            temp = odd ? m1.matrix[i][m - 1] * m2.matrix[m - 1][j] : 0;
            temp -= rowFactor[i] + colFactor[j];

            for (int k = 0; k < d; ++k)
                temp += \
                (m1.matrix[i][2 * k] + m2.matrix[2 * k + 1][j]) * (m1.matrix[i][2 * k + 1] + m2.matrix[2 * k][j]);

            result.matrix[i][j] = temp;
        }

    
   // free_matrix(result.matrix, result.n);
    free(rowFactor);
    free(colFactor);
    return result;
}
