#include "queen_attack.h"

#include <stdbool.h>
#include <stdlib.h>

bool queen_is_on_board(position_t queen);
bool is_on_board(uint8_t num);
bool is_in_range(uint8_t num, uint8_t min, uint8_t max);

bool queen_is_on_board(position_t queen) {
    return is_on_board(queen.row) && is_on_board(queen.column);
}

bool is_on_board(uint8_t num) {
    return is_in_range(num, 0, 7);
}

bool is_in_range(uint8_t num, uint8_t min, uint8_t max) {
    return num >= min && num <= max;
}

attack_status_t can_attack(position_t queen_1, position_t queen_2) {
    if (!queen_is_on_board(queen_1)) return INVALID_POSITION;
    if (!queen_is_on_board(queen_2)) return INVALID_POSITION;
    if (queen_1.row == queen_2.row && queen_1.column == queen_2.column) return INVALID_POSITION;
    
    if (queen_1.row == queen_2.row) return CAN_ATTACK;
    if (queen_1.column == queen_2.column) return CAN_ATTACK;

    if (abs(queen_1.row - queen_2.row) == abs(queen_1.column - queen_2.column)) return CAN_ATTACK;

    return CAN_NOT_ATTACK;
}
