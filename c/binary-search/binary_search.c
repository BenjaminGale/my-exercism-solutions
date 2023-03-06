#include "binary_search.h"

const int *binary_search(int value, const int *arr, size_t length) {
    int end = length - 1;

    if (end < 0) return NULL;
    
    size_t middle = (end / 2);
    const int * focus = &arr[middle];

    if (value < *focus) {
        return binary_search(value, arr, middle - 1);
    } else if (value > *focus) {
        int start = middle + 1;
        return binary_search(value, &arr[start], length - start);
    } else {
        return focus;
    }
}
