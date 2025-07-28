const std = @import("std");

pub fn isIsogram(str: []const u8) bool {
    var foundLetters = std.bit_set.StaticBitSet(26).initEmpty();

    for (str) |letter| {
        if (letterIndex(letter)) |index| {
            if (foundLetters.isSet(index)) return false;
            foundLetters.set(index);
        }
    }

    return true;
}

fn letterIndex(c: u8) ?u5 {
    return switch (c) {
        'a'...'z' => @intCast(c - 'a'),
        'A'...'Z' => @intCast(c - 'A'),
        else => null,
    };
}
