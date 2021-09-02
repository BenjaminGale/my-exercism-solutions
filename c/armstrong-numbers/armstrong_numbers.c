
#include <stdbool.h>
#include <math.h>

#include "armstrong_numbers.h"

bool is_armstrong_number(int candidate)
{
    int numberOfDigits = log10(candidate) + 1;
    int sum = 0;

    int value = candidate;

    while (value != 0)
    {
        int digit = value % 10;
        sum += pow(digit, numberOfDigits);
        value /= 10;
    }

    return candidate == sum;
}