
#include <string.h>

#include "hamming.h"

int compute(const char *lhs, const char *rhs)
{
    int lLen = strlen(lhs);
    int rLen = strlen(rhs);

    if (lLen != rLen) return -1;

    int distance = 0;
    
    for (int i = 0; i <= lLen; i++)
    {
        if (lhs[i] != rhs[i])
        {
            distance++;
        }
    }

    return distance;
}