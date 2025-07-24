
#include <stddef.h>

#include "isogram.h"

bool is_isogram(const char phrase[])
{
    if (phrase == NULL) return false;
    if (*phrase == '\0') return true;
    
    unsigned int characterCounts[26] = { 0 };
    
    for (const char* c = phrase; *c != '\0'; c++)
    {
        char character = *c;
        
        if (character >= 'a' && character <= 'z')
        {
            int charIndex = character - 97;
            characterCounts[charIndex]++;
        }
    
        if (character >= 'A' && character <= 'Z')
        {
            int charIndex = character - 65;
            characterCounts[charIndex]++;
        }
    }
    
    for (int i = 0; i < 26; i++)
    {
        if (characterCounts[i] > 1) return false;
    }
    
    return true;
}