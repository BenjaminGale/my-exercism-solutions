const std = @import("std");
const random = std.crypto.random;

pub fn modifier(score: i8) i8 {
    return @divFloor((score - 10), 2);
}

pub fn ability() i8 {
    var throws: [4]i8 = undefined;

    for (0..4) |n| throws[n] = random.intRangeAtMost(i8, 1, 6);
    std.mem.sort(i8, &throws, {}, comptime std.sort.asc(i8));

    var score: i8 = 0;
    for (throws[1..]) |throw| score += throw;

    return score;
}

pub const Character = struct {
    strength: i8,
    dexterity: i8,
    constitution: i8,
    intelligence: i8,
    wisdom: i8,
    charisma: i8,
    hitpoints: i8,

    pub fn init() Character {
        const constitution = ability();
    
        return Character {
            .strength = ability(),
            .dexterity = ability(),
            .constitution = constitution,
            .intelligence = ability(),
            .wisdom = ability(),
            .charisma = ability(),
            .hitpoints = 10 + modifier(constitution),
        };
    }
};
