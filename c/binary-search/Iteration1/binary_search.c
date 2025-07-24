#include "binary_search.h"

const int *binary_search(int value, const int *arr, size_t length) {
    if (length == 0) return NULL;
    
    int start = 0;
    int end = length - 1;

    while (start <= end) {
        size_t middle = ((start + end) / 2);
        const int * focus = &arr[middle];

        if (value < *focus) {
            end = middle - 1;
        } else if (value > *focus) {
            start = middle + 1;
        } else {
            return focus;
        }
    }

    return NULL;
}
