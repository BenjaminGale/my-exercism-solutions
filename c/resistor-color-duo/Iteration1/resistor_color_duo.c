#include "resistor_color_duo.h"

uint16_t color_code(resistor_band_t* resistorBands)
{
    uint16_t resistorValue = 0;

    for (int i = 0; i < 2; i++)
    {
        resistorValue *= 10;
        resistorValue += *(resistorBands + i);
    }
    
    return resistorValue;
}