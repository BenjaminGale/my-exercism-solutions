const std = @import("std");
const mem = std.mem;

pub fn abbreviate(allocator: mem.Allocator, sentence: []const u8) mem.Allocator.Error![]u8 {
    var result = std.ArrayList(u8).init(allocator);
    defer result.deinit();

    var words = std.mem.tokenizeAny(u8, sentence, " -_");

    while (words.next()) |word| {
        try result.append(std.ascii.toUpper(word[0]));
    }
    
    return result.toOwnedSlice();
}
