
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
    return resistorBand;
}

const resistor_band_t* colors(void)
{
    return _colors;
}