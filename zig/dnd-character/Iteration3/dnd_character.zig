const std = @import("std");

pub fn modifier(score: u8) i8 {
    return @intCast(@divFloor(@as(i16, score) - 10, 2));
}

pub fn ability(random: std.Random) u8 {
    var score: u8 = 0;
    var min: u8 = 6;

    for (0..4) |_| {
        const roll = random.intRangeAtMost(u8, 1, 6);
        score += roll;
        min = @min(min, roll);
    }

    return score - min;
}

pub const Character = struct {
    strength: u8,
    dexterity: u8,
    constitution: u8,
    intelligence: u8,
    wisdom: u8,
    charisma: u8,
    hitpoints: i8,

    pub fn init(random: std.Random) Character {
        var character = Character{
            .strength = ability(random),
            .dexterity = ability(random),
            .constitution = ability(random),
            .intelligence = ability(random),
            .wisdom = ability(random),
            .charisma = ability(random),
            .hitpoints = 0,
        };

        character.hitpoints = 10 + modifier(character.constitution);

        return character;
    }
};
