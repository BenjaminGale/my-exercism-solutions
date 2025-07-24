pub fn isIsogram(str: []const u8) bool {

    var characterFlags: u32 = 0;

    for (str) |character| {

        var charIndex: u5 = 0;
        
        if (character >= 'a' and character <= 'z') {
            charIndex = @intCast(character - 'a');
        }
        else if (character >= 'A' and character <= 'Z') {
            charIndex = @intCast(character - 'A');
        }
        else {
            continue;
        }

        const mask = @as(u32, 1) << charIndex;

        if (characterFlags & mask != 0) return false;
        characterFlags |= mask;
    }

    return true;
}
