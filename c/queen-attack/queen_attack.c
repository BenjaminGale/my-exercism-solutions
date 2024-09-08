#include "queen_attack.h"

#include <stdbool.h>
#include <stdlib.h>

static bool is_in_range(uint8_t num, uint8_t min, uint8_t max) {
    return num >= min && num <= max;
}

static bool is_on_board(position_t queen) {
    return is_in_range(queen.row, 0, 7) && is_in_range(queen.column, 0, 7);
}

static bool isValidSetup(position_t queen_1, position_t queen_2) {
    return is_on_board(queen_1) && is_on_board(queen_2) && (queen_1.row != queen_2.row || queen_1.column != queen_2.column);
}

attack_status_t can_attack(position_t queen_1, position_t queen_2) {
    if (!isValidSetup(queen_1, queen_2)) return INVALID_POSITION;
    
    if (queen_1.row == queen_2.row) return CAN_ATTACK;
    if (queen_1.column == queen_2.column) return CAN_ATTACK;

    if (abs(queen_1.row - queen_2.row) == abs(queen_1.column - queen_2.column)) return CAN_ATTACK;

    return CAN_NOT_ATTACK;
}
