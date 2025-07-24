#include "binary_search.h"

const int *binary_search(int value, const int *arr, size_t length) {
    int start = 0;
    int end = length - 1;

    if (start > end) return NULL;
    
    size_t middle = ((start + end) / 2);
    const int * focus = &arr[middle];

    if (value < *focus) {
        return binary_search(value, arr, middle - 1);
    } else if (value > *focus) {
        return binary_search(value, &arr[middle + 1], length - (middle + 1));
    } else {
        return focus;
    }

    return NULL;
}
