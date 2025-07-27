#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>

#include "nucleotide_count.h"

char *count(const char *dna_strand) {
    int32_t a_count = 0;
    int32_t c_count = 0;
    int32_t g_count = 0;
    int32_t t_count = 0;

    char *buffer = malloc(50);
    buffer[0] = '\0';
    
    for (const char *p = dna_strand; *p != '\0'; p++) {
        char n = *p;

        if      (n == 'A') { a_count++; }
        else if (n == 'C') { c_count++; }
        else if (n == 'G') { g_count++; }
        else if (n == 'T') { t_count++; }
        else               { return buffer; }
    }
    
    snprintf(buffer, 50, "A:%d C:%d G:%d T:%d", a_count, c_count, g_count, t_count);
    return buffer;
}
