#include "space_age.h"

const uint64_t EARTH_SECONDS_IN_YEAR = 31557600;

static float age_on_earth(int64_t seconds) {
    return seconds / EARTH_SECONDS_IN_YEAR;
}

static float orbital_period(planet_t planet) {
    switch (planet) {
        case MERCURY:
            return 0.2408467;
        case VENUS:
            return 0.61519726;
        case EARTH:
            return 1;
        case MARS:
            return 1.8808158;
        case JUPITER:
            return 11.862615;
        case SATURN:
            return 29.447498;
        case URANUS:
            return 84.016846;
        case NEPTUNE:
            return 164.79132;
    }

    return 1;
}

float age(planet_t planet, int64_t seconds) {
    if (planet < MERCURY || planet > NEPTUNE)
        return -1;
    
    return age_on_earth(seconds) / orbital_period(planet);
}
