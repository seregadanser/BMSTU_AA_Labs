#ifndef ALGOS_H
#define ALGOS_H

#include <stdlib.h>
#include <string.h>
#include <limits.h>
#include <stdbool.h>

#include "Matrix.hpp"
#include "mytools.hpp"

int non_rec_dam_lev(const char* s1, const char* s2);
int cache_dam_lev(const char* s1, const char* s2);
int rec_dam_lev(const char* s1,const char* s2);

int non_rec_lev(const char *s1, const char *s2);

#endif
