pub fn isIsogram(str: []const u8) bool {
    var characterFlags: u26 = 0;

    for (str) |character| {
        if (charToInt(character)) |charIndex| {
            const mask = @as(u26, 1) << charIndex;
            if (characterFlags & mask != 0) return false;
            characterFlags |= mask;
        }
    }

    return true;
}

fn charToInt(c: u8) ?u5 {
    return switch (c) {
        'a'...'z' => @intCast(c - 'a'),
        'A'...'Z' => @intCast(c - 'A'),
        else => null,
    };
}
