#include "resistor_color_duo.h"

uint16_t color_code(const resistor_band_t resistorBands[static 2])
{
    uint16_t resistorValue = 0;

    for (int i = 0; i < 2; i++)
    {
        resistorValue *= 10;
        resistorValue += *(resistorBands + i);
    }
    
    return resistorValue;
}