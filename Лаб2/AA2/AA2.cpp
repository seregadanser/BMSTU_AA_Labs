#include <ctime>
#include <iostream>
#include "MatrixMull.hpp"
#include "Gen.hpp"
#include "TimeCompare.hpp"

void output_matrix(data_t m)
{
    printf("%d %d\n", m.n, m.m);

    for (int i = 0; i < m.n; i++)
    {
        for (int j = 0; j < m.m; j++)
            printf("%d ", m.matrix[i][j]);
        printf("\n");
    }
}


int main()
{
    srand(time(0));
    //data_t m, n;
    time_compare(gen_best_case);
    /*gen_best_case(&m, 2);
    gen_best_case(&n,2);
    output_matrix(m);
    output_matrix(n);
    output_matrix(matrix_multiplication(m, n));
    output_matrix(matrix_multiplication_Vinograd(m, n));
    output_matrix(matrix_multiplication_VinogradOptimase(m, n));
    free_matrix(m.matrix, m.n);
    free_matrix(n.matrix, n.n);*/
    return 0;
}

