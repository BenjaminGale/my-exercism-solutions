#include "resistor_color_trio.h"

resistor_value_t color_code(resistor_band_t resistorBands[static 3])
{
    resistor_value_t resistor;
    resistor.value = 0;
    resistor.unit = OHMS;
    
    for (int i = 0; i < 2; i++)
    {
        resistor.value *= 10;
        resistor.value += resistorBands[i];
    }

    int exponent = resistorBands[2];
    
    for (int i = 0; i < exponent; i++)
    {
        resistor.value *= 10;
    }

    if (resistor.value > 1000000000)
    {
        resistor.value /= 1000000000;
        resistor.unit = GIGAOHMS;
    }
    
    if (resistor.value > 1000000)
    {
        resistor.value /= 1000000;
        resistor.unit = MEGAOHMS;
    }
    
    if (resistor.value > 1000)
    {
        resistor.value /= 1000;
        resistor.unit = KILOOHMS;
    }
    
    return resistor;
}