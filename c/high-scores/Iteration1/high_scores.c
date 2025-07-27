#include "high_scores.h"

int32_t latest(const int32_t *scores, size_t scores_len) {
    return scores[scores_len -1];
}

int32_t personal_best(const int32_t *scores, size_t scores_len) {
    int32_t best = 0;

    for (size_t i = 0; i < scores_len; i ++) {
        int32_t val = scores[i];

        if (val > best) best = val;
    }

    return best;
}

size_t personal_top_three(const int32_t *scores, size_t scores_len, int32_t *output) {
    int32_t first = 0;
    int32_t second = 0;
    int32_t third = 0;
    
    for (size_t i = 0; i < scores_len; i ++) {
        int32_t val = scores[i];

        if (val > first) {
            third = second;
            second = first;
            first = val;
        } else if (val > second) {
            third = second;
            second = val;
        } else if (val > third) {
            third = val;
        }
    }

    output[0] = first;
    output[1] = second;
    output[2] = third;
    
    return (first > 0 ? 1 : 0) + (second > 0 ? 1 : 0) + (third > 0 ? 1 : 0);
}
