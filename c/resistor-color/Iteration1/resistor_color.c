
#include <stddef.h>

#include "resistor_color.h"

static resistor_band_t _colors[] = {
    BLACK,
    BROWN,
    RED,
    ORANGE,
    YELLOW,
    GREEN,
    BLUE,
    VIOLET,
    GREY,
    WHITE
};

unsigned int color_code(resistor_band_t resistorBand)
{
    int result = 0;

    for (resistor_band_t* color = _colors; color != NULL; color++)
    {
        if (*color == resistorBand) break;
        result++;
    }

    return result;
}

resistor_band_t* colors()
{
    return _colors;
}