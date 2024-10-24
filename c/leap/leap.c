#include "leap.h"

bool is_divisible_by(int year, int divisor);

bool leap_year(int year) {
    return (is_divisible_by(year, 4) && !is_divisible_by(year, 100)) || is_divisible_by(year, 400);
}

bool is_divisible_by(int year, int divisor) {
    return (year % divisor) == 0;
}
