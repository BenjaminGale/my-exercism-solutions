#include "darts.h"
#include <math.h>
#include <stdio.h>

static float distance_from_centre(coordinate_t coord) {
    return sqrt(pow(coord.x, 2) + pow(coord.y, 2));
}

uint8_t score(coordinate_t coord) {
    float dist = distance_from_centre(coord);
    
    if (dist >= 0 && dist <= 1) return 10;
    if (dist >= 1 && dist <= 5) return 5;
    if (dist >= 5 && dist <= 10) return 1;
    
    return 0;
}
