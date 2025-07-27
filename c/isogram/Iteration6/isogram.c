#include <ctype.h>
#include <stddef.h>

#include "isogram.h"

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) return false;
    if (*phrase == '\0') return true;

    unsigned long letterFlags = 0;
    
    for (const char* p = phrase; *p != '\0'; p++)
    {
        char c = *p;
        int letterBit = 0;
        
        if (isalpha(c))
        {
            letterBit = tolower(c) - 'a';

            unsigned long letter_found_mask = 1UL << letterBit;
        
            if (letterFlags & letter_found_mask) return false;
            letterFlags |= letter_found_mask;
        }
    }
    
    return true;
}