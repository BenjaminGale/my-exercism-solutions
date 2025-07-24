#include "binary.h"
#include <string.h>
#include <stdint.h>
#include <math.h>

int convert(const char *input) {
    size_t len = strlen(input);
    uint32_t result = 0;
    
    for (size_t i = 0; i < len; i++) {
        if (input[i] != '0' && input[i] != '1') {
            return INVALID;
        }

        result += (input[i] - '0') * pow(2, len - i - 1);
    }
    
    return result;
}
