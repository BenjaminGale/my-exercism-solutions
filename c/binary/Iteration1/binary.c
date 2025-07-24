#include "binary.h"
#include <string.h>
#include <stdint.h>
#include <math.h>

int convert(const char *input) {
    uint8_t len = strlen(input);
    uint32_t result = 0;
    
    for (uint8_t i = 0; i < len; i++) {
        uint8_t bit = input[i] - 48;
        
        if (bit != 0 && bit != 1) { return INVALID; }

        result += bit * pow(2, len - i - 1);
    }
    
    return result;
}
