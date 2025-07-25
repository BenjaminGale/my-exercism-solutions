const std = @import("std");
const mem = std.mem;

pub fn sum(allocator: mem.Allocator, factors: []const u32, limit: u32) !u64 {
    var multiples = std.AutoHashMap(u32, void).init(allocator);
    defer multiples.deinit();

    for (factors) |factor| {
        if (factor == 0) continue;

        var multiple: u32 = factor;

        while (multiple < limit) : (multiple += factor) {
            try multiples.put(multiple, {});
        }
    }

    var total: u64 = 0;
    var iter = multiples.keyIterator();
    while (iter.next()) |key| total += key.*;

    return total;
}
