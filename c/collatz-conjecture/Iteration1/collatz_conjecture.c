#include "collatz_conjecture.h"

int steps(int start) {
    if (start <=0) return ERROR_VALUE;

    int numSteps = 0;
    int value = start;
    
    while (value > 1) {
        if (value % 2 ==0) {
            value = value / 2;
        } else {
            value = (3 * value) + 1;
        }

        numSteps++;
    }
    
    return numSteps;
}
