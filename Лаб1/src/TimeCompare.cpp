#include "TimeCompare.hpp"
#include "GetCPUTime.hpp"
#include <iostream>
#include <iomanip>

using namespace std;

void time_compare(gen_func_t gen_func) {
    double start;
    double end;
    double copy_t;
    int repeats = 10000;
    cout << setw(33) << "Time in ms" << endl;
    cout << setw(3) << "Size" << setw(15) << "NRL" << setw(15) << "NRDL" << setw(15) << "CDL" <<"RDL" << endl;
    for (int len = 1; len < 15; len += 1) {
        cout << setw(3) << len;
      char s1[256], s2[256];
     gen_case(s1, len);
     gen_case(s2, len);
       
        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            non_rec_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
      non_rec_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
     cache_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

         start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
     rec_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats << endl;
    
    }

    /*for (int len = 100; len < 600; len += 100) {
        cout << setw(3) << len;
      char s1[707], s2[707];
     gen_case(s1, len);
     gen_case(s2, len);
       
        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
            non_rec_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats;


        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
      non_rec_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats ;

        start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
     cache_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats <<endl;

         start = getCPUTime();
        for (int i = 0; i < repeats; i++) {
     rec_dam_lev(s1, s2);
        }
        end = getCPUTime();
        cout << setw(15) << (end - start) / repeats << endl;
    
    }
   

 */
}
