#include <stdlib.h>
#include <math.h>

#include "dnd_character.h"

int ability(void) {
    int score = 0;
    int min = 6;

    for (int i = 0; i < 4; i++) {
        int val = (rand() % 6) + 1;
        score += val;

        if (val < min) {
            min = val;
        }
    }

    score -= min;

    return score;
}

int modifier(int score) {
    return floor((score - 10) / 2.0);
}

dnd_character_t make_dnd_character(void) {
    int constitution = ability();
    
    return (dnd_character_t) {
        .strength = ability(),
        .dexterity = ability(),
        .constitution = constitution,
        .intelligence = ability(),
        .wisdom = ability(),
        .charisma = ability(),
        .hitpoints = 10 + modifier(constitution)
    };
}
