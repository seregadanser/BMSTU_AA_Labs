#include <iostream>
#include <string>
#include "time_compare.hpp"

using namespace std;

int main() {
    cout << endl << "Results for the best case:" << endl;
    time_compare(gen_best_case);

    cout << endl << "Results for normal case:" << endl;
    time_compare(gen_normal_case);

    cout << endl << "Results for the worst case:" << endl;
    time_compare(gen_worst_case);
    return 0;
}
