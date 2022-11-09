
#include <ctime>
#include <iostream>
#include "algos.hpp"
#include "Gen.hpp"
#include "TimeCompare.hpp"


int main()
{
    srand(time(0));
   /* char s1[256], s2[256];
      gen_case(s1, 11);
      printf("%s", s1);
      gen_case(s2,11);
      printf("%s", s2);
      int r3 = non_rec_lev(s1, s2);

      int r = non_rec_dam_lev(s1, s2);
      int r1 = cache_dam_lev(s1, s2);

      int r2 = rec_dam_lev(s1, s2);

      printf("%d , %d %d %d", r3, r, r1, r2);*/
    time_compare(gen_case);


    return 0;
}

