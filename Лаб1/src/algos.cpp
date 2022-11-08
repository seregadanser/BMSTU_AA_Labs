#include "algos.hpp"
#include <cmath>

int rec_dam_lev1(const char* s1, const char* s2, const int li1, const int li2);

int rec_dam_lev(const char* s1, const char* s2)
{
    return rec_dam_lev1(s1, s2, strlen(s1), strlen(s2));
}

int rec_dam_lev1(const char* s1, const char* s2, const int li1, const int li2)
{
    int result = -1;

    if (li1 == 0 || li2 == 0)
        return std::abs(li1 - li2);

    result = min_int(3,
        rec_dam_lev1(s1, s2, li1 - 1, li2) + 1,rec_dam_lev1(s1, s2, li1, li2 - 1) + 1, 
        rec_dam_lev1(s1, s2, li1 - 1, li2 - 1) + (s1[li1 - 1] != s2[li2 - 1]));

    if (li1 > 1 && li2 > 1 && s1[li1 - 1] == s2[li2 - 2] && s1[li1 - 2] == s2[li2 - 1])
        result = min_int(2,result,rec_dam_lev1(s1, s2, li1 - 2, li2 - 2) + 1);

    return result;
}

int non_rec_lev(const char* s1, const char* s2)
{

    int n = strlen(s1) + 1;
    int m = strlen(s2) + 1;

    if (n == 1)
        return m - 1;

    if (m == 1)
        return n - 1;

        data_t mtrx;
        mtrx.matrix = create_matrix(strlen(s1) + 1, strlen(s2) + 1);
        mtrx.n = strlen(s1) + 1;
        mtrx.m = strlen(s2) + 1;


    for (int i = 0; i < n; ++i)
    {

        for (int j = 0; j < m; ++j)
        {
     
            if (i == 0 && j == 0)
                mtrx.matrix[i][j] = 0;
            else if (i == 0)
                mtrx.matrix[i][j] = j;
            else if (j == 0)
                mtrx.matrix[i][j] = i;
            else
                mtrx.matrix[i][j] = min_int(3, mtrx.matrix[i][j - 1] + 1,mtrx.matrix[i - 1][j] + 1,
                    mtrx.matrix[i - 1][j - 1] + (s1[i - 1] != s2[j - 1])
                );
        }
    }


    int result = mtrx.matrix[n - 1][m - 1];

     free_matrix(&mtrx);
    
    return result;
}

int non_rec_dam_lev(const char* s1, const char* s2)
{
    int n = strlen(s1) + 1;
    int m = strlen(s2) + 1;

    if (n == 1)
        return m - 1;

    if (m == 1)
        return n - 1;

            data_t mtrx;
        mtrx.matrix = create_matrix(strlen(s1) + 1, strlen(s2) + 1);
        mtrx.n = strlen(s1) + 1;
        mtrx.m = strlen(s2) + 1;

    for (int i = 0; i < n; ++i)
    {
        for (int j = 0; j < m; ++j)
        {
            if (i == 0 && j == 0)
                mtrx.matrix[i][j] = 0;
            else if (i == 0)
                mtrx.matrix[i][j] = j;
            else if (j == 0)
                mtrx.matrix[i][j] = i;
            else
            {
                mtrx.matrix[i][j] = min_int(3,
                    mtrx.matrix[i][j - 1] + 1,
                    mtrx.matrix[i - 1][j] + 1,
                    mtrx.matrix[i - 1][j - 1] + (s1[i - 1] != s2[j - 1])
                );
                if (i > 1 && j > 1 && s1[i - 1] == s2[j - 2] && s1[i - 2] == s2[j - 1])
                    mtrx.matrix[i][j] = min_int(2, mtrx.matrix[i][j], mtrx.matrix[i - 2][j - 2] + 1);
            }
        }
    }

    int result = mtrx.matrix[n - 1][m - 1];

    free_matrix(&mtrx);

    return result;
}

static void fill_mtrx_with_inf(data_t* const mtrx)
{
    for (int i = 0; i < mtrx->n; ++i)
        for (int j = 0; j < mtrx->m; ++j)
            mtrx->matrix[i][j] = LONG_MAX;
}

int cache_dam_lev1(data_t* cache, const char* s1, const char* s2, const int li1, const int li2);

int cache_dam_lev(const char* s1, const char* s2)
{
        data_t cache;
        cache.matrix = create_matrix(strlen(s1) + 1, strlen(s2) + 1);
        cache.n = strlen(s1) + 1;
        cache.m = strlen(s2) + 1;
        fill_mtrx_with_inf(&cache);

        int r = cache_dam_lev1(&cache, s1, s2, strlen(s1), strlen(s2));
        
        free_matrix(&cache);
        return r;
}

int cache_dam_lev1(data_t* cache, const char* s1, const char* s2, const int li1, const int li2)
{
    if (cache->matrix[li1][li2] != LONG_MAX)
        return cache->matrix[li1][li2];

    if (li1 == 0 && li2 == 0)
    {
        cache->matrix[li1][li2] = 0;
        return cache->matrix[li1][li2];
    }

    if (li1 == 0 && li2 > 0)
    {
        cache->matrix[li1][li2] = li2;
        return li2;
    }

    if (li2 == 0 && li1 > 0)
    {
        cache->matrix[li1][li2] = li1;
        return li1;
    }

    int r1 = 0, r2 = 0, r3 = 0;

    r1 = cache_dam_lev1(cache, s1, s2, li1 - 1, li2) + 1;
    r2 = cache_dam_lev1(cache, s1, s2, li1, li2 - 1) + 1;
    r3 = cache_dam_lev1(cache, s1, s2, li1 - 1, li2 - 1) + (s1[li1 - 1] != s2[li2 - 1]);

    cache->matrix[li1][li2] = min_int(3, r1, r2, r3);
    int result = 0;

    if (li1 > 1 && li2 > 1 && s1[li1 - 1] == s2[li2 - 2] && s1[li1 - 2] == s2[li2 - 1])
    {
        int r4 = 0;

        r4 = cache_dam_lev1(cache, s1, s2, li1 - 2, li2 - 2) + 1;


        cache->matrix[li1][li2] = min_int(2, cache->matrix[li1][li2], r4);
    }


    return cache->matrix[li1][li2];
}

   