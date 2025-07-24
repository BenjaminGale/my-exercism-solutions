
pub fn reverse(buffer: []u8, s: []const u8) []u8 {
    for (0..s.len) |i| {
        buffer[s.len - i - 1] = s[i];
    }

    return buffer;
}
