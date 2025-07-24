const std = @import("std");

pub fn isPangram(str: []const u8) bool {
    var foundLetters = std.bit_set.IntegerBitSet(26).initEmpty();
    
    for (str) |c| {
        if (charIndex(c)) |index| {
            foundLetters.set(index);
        }
    }

    return foundLetters.count() == 26;
}

fn charIndex(char: u8) ?u5 {
    return switch (char) {
        'a'...'z' => @intCast(char - 'a'),
        'A'...'Z' => @intCast(char - 'A'),
        else => null
    };
}
