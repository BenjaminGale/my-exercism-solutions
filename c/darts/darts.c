#include "darts.h"
#include <math.h>
#include <stdio.h>

const uint8_t CENTRE = 0;
const uint8_t INNER_RADIUS = 1;
const uint8_t MIDDLE_RADIUS = 5;
const uint8_t OUTER_RADIUS = 10;

static float distance_from_centre(coordinate_t coord) {
    return sqrt(pow(coord.x, 2) + pow(coord.y, 2));
}

uint8_t score(coordinate_t coord) {
    float dist = distance_from_centre(coord);
    
    if (dist >= CENTRE && dist <= INNER_RADIUS) return 10;
    if (dist >= INNER_RADIUS && dist <= MIDDLE_RADIUS) return 5;
    if (dist >= MIDDLE_RADIUS && dist <= OUTER_RADIUS) return 1;
    
    return 0;
}
