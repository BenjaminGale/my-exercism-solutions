#include "perfect_numbers.h"

static int32_t aliquot_sum(int32_t number) {
    int32_t sum = 0;
    
    for (int32_t factor = 1; factor < number; factor++) {
        if (number % factor == 0) {
            sum += factor;
        }
    }
    
    return sum;
}

kind classify_number(int32_t number) {
    if (number < 1) return ERROR;
    
    int32_t sum = aliquot_sum(number);
    
    if (number == sum) return PERFECT_NUMBER;
    if (number < sum)  return ABUNDANT_NUMBER;
    if (number > sum)  return DEFICIENT_NUMBER;

    return ERROR;
}
