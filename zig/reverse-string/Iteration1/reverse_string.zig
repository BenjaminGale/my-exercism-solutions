
pub fn reverse(buffer: []u8, s: []const u8) []u8 {
    var i: usize = s.len;
    
    while (i > 0) {
        i -= 1;
        buffer[s.len - i - 1] = s[i];
    }

    return buffer;
}
