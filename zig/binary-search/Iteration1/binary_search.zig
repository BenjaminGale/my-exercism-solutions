
pub fn binarySearch(comptime T: type, target: T, items: []const T) ?usize {
    if (items.len == 0) return null;
    
    var start: usize = 0;
    var end: usize = items.len - 1;

    while (start <= end) {
        const mid = (start + end) / 2;
        const curr = items[mid];

        if (curr == target) return mid;
        if (mid == 0) return null;

        if (target > curr) start = mid + 1;
        if (target < curr) end = mid - 1;
    }

    return null;
}
