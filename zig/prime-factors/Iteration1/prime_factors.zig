const std = @import("std");
const mem = std.mem;

pub fn factors(allocator: mem.Allocator, value: u64) mem.Allocator.Error![]u64 {
    var results = std.ArrayList(u64).init(allocator);

    var remainder = value;
    var divisor: usize = 2;

    while (divisor * divisor <= remainder) {
        if (remainder % divisor == 0) {
            try results.append(divisor);
            remainder = remainder / divisor;
        } else {
            divisor += 1;
        }
    }

    if (remainder > 1) {
        try results.append(remainder);
    }

    return results.toOwnedSlice();
}
