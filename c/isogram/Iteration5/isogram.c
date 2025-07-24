
#include <stddef.h>

#include "isogram.h"

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) return false;
    if (*phrase == '\0') return true;

    unsigned long characterFlags = 0;
    
    for (const char* c = phrase; *c != '\0'; c++)
    {
        char character = *c;
        int charPosition = 0;
        
        if (character >= 'a' && character <= 'z')
        {
            charPosition = character - 'a';
        }
        else if (character >= 'A' && character <= 'Z')
        {
            charPosition = character - 'A';
        }
        else
        {
            continue;    
        }

        unsigned long mask = 1UL << charPosition;
        
        if (characterFlags & mask) return false;
        characterFlags |= mask;
    }
    
    return true;
}