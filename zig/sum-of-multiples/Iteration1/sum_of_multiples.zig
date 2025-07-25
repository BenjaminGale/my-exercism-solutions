const std = @import("std");
const mem = std.mem;

pub fn sum(allocator: mem.Allocator, factors: []const u32, limit: u32) !u64 {
    var map = std.AutoHashMap(u32, void).init(allocator);
    defer map.deinit();

    var num: u32 = 1;

    while (num < limit) : (num += 1) {
        for (factors) |factor| {
            if (factor > 0 and num % factor == 0 and !map.contains(num)) {
                try map.put(num, {});
            }
        }
    }

    var total: u64 = 0;
    var iter = map.keyIterator();

    while (iter.next()) |key| {
        total += key.*;
    }

    return total;
}
