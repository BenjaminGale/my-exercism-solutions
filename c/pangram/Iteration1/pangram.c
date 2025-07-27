#include <stddef.h>
#include <ctype.h>

#include "pangram.h"

const unsigned long all_letters_mask = (1UL << 26) - 1;

bool is_pangram(const char *sentence) {
    if (sentence == NULL) return false;
    if (*sentence == '\0') return false;

    unsigned long letterFlags = 0;
    
    for (const char* p = sentence; *p != '\0'; p++) {
        char c = tolower(*p);
        int letterIndex = 0;
        
        if (c >= 'a' && c <= 'z')
        {
            letterIndex = c - 'a';
            letterFlags |= (1UL << letterIndex);
        }
    }
    
    return (letterFlags & all_letters_mask) == all_letters_mask;
}
