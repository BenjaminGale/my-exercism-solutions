const std = @import("std");
const mem = std.mem;

pub fn detectAnagrams(allocator: mem.Allocator, word: []const u8, candidates: []const []const u8) !std.BufSet {
    var anagrams = std.BufSet.init(allocator);

    const sortedLowerWord = try allocSortedLowerString(allocator, word);
    defer allocator.free(sortedLowerWord);

    for (candidates) |candidate| {
        if (candidate.len != word.len) continue;
        if (std.ascii.eqlIgnoreCase(word, candidate)) continue;

        const sortedLowerCandidate = try allocSortedLowerString(allocator, candidate);
        defer allocator.free(sortedLowerCandidate);

        if (mem.eql(u8, sortedLowerWord, sortedLowerCandidate)) {
            try anagrams.insert(candidate);
        }
    }

    return anagrams;
}

fn allocSortedLowerString(allocator: mem.Allocator, ascii_string: []const u8) ![] u8 {
    const str = try std.ascii.allocLowerString(allocator, ascii_string);
    mem.sort(u8, str, {}, std.sort.asc(u8));
    return str;
}
