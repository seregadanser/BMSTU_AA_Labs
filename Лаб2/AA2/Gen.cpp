#include "Gen.hpp"
#include <random>

using namespace std;

void gen_best_case(data_t* m, int n) {
	m->n = n;
	m->m = n;

	m->matrix = create_matrix(m->n, m->m);
	for (int i = 0; i < m->n; i++)
		for (int j = 0; j < m->m; j++)
			m->matrix[i][j] = rand()%5;

}
