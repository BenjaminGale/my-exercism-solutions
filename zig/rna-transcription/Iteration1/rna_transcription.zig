const std = @import("std");
const mem = std.mem;

pub fn toRna(allocator: mem.Allocator, dna: []const u8) mem.Allocator.Error![]const u8 {
    const result = try allocator.alloc(u8, dna.len);
    
    for (0..dna.len, dna) |i, nuc| {
        result[i] = dnaToRna(nuc);
    }

    return result;
}

fn dnaToRna(nuc: u8) u8 {
    return switch (nuc) {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        else => unreachable
    };
}
