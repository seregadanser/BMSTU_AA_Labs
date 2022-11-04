#include "TimeCompare.hpp"
#include "GetCPUTime.hpp"
#include <iostream>
#include <iomanip>

using namespace std;

void time_compare(gen_func_t gen_func) {
    double start;
    double end;
    double copy_t;
    int repeats = 2000;
    cout << setw(33) << "Time in ms" << endl;
    cout << setw(3) << "Size" << setw(15) << "Easy" << setw(20) << "Vinograde" << setw(20) << "VinogradeOptimise" << endl;
    for (int len = 10; len < 100; len += 10) {
        cout << setw(3) << len;
        data_t m1, m2;
        gen_func(&m1, len);
        gen_func(&m2, len);

       
        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_Vinograd(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_VinogradOptimase(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats << endl;
        free_matrix(m1.matrix, len);
        free_matrix(m2.matrix, len);
    }

    for (int len = 100; len < 600; len += 100) {
        cout << setw(3) << len;
        data_t m1, m2;
        gen_func(&m1, len);
        gen_func(&m2, len);


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_Vinograd(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_VinogradOptimase(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats<< endl;
        free_matrix(m1.matrix, len);
        free_matrix(m2.matrix, len);
    }
    for (int len = 11; len < 101; len += 10) {
        cout << setw(3) << len;
        data_t m1, m2;
        gen_func(&m1, len);
        gen_func(&m2, len);

       
        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_Vinograd(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_VinogradOptimase(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats << endl;
        free_matrix(m1.matrix, len);
        free_matrix(m2.matrix, len);
    }

    for (int len = 101; len < 601; len += 100) {
        cout << setw(3) << len;
        data_t m1, m2;
        gen_func(&m1, len);
        gen_func(&m2, len);


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_Vinograd(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            matrix_multiplication_VinogradOptimase(m1, m2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats<< endl;
        free_matrix(m1.matrix, len);
        free_matrix(m2.matrix, len);
    }
}
