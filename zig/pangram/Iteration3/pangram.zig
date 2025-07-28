const std = @import("std");

pub fn isPangram(str: []const u8) bool {
    var foundLetters = std.bit_set.StaticBitSet(26).initEmpty();
    
    for (str) |letter| {
        if (letterIndex(letter)) |index| {
            foundLetters.set(index);
        }
    }

    return foundLetters.count() == 26;
}

fn letterIndex(char: u8) ?u5 {
    return switch (char) {
        'a'...'z' => @intCast(char - 'a'),
        'A'...'Z' => @intCast(char - 'A'),
        else => null
    };
}
