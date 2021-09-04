
#include <string.h>

#include "hamming.h"

int compute(const char *leftString, const char *rightString)
{
    int distance = 0;

    char leftCharacter = *leftString;
    char rightCharacter = *rightString;

    while (leftCharacter != '\0' && rightCharacter != '\0')
    {
        if (leftCharacter != rightCharacter)
        {
            distance++;
        }

        leftCharacter = *(++leftString);
        rightCharacter = *(++rightString);
    }

    int areSameLength = leftCharacter == '\0' && rightCharacter == '\0';

    return areSameLength ? distance : -1;
}