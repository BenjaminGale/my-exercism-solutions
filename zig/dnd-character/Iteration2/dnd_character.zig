const std = @import("std");
const random = std.crypto.random;

pub fn modifier(score: i8) i8 {
    return @divFloor((score - 10), 2);
}

pub fn ability() i8 {
    var score: i8 = 0;
    var min: i8 = 6;

    inline for (0..4) |_| { 
        const val = random.intRangeAtMost(i8, 1, 6);
        score += val;
        min = @min(min, val);
    }

    score -= min;

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
        var char: Character = undefined;

        inline for(@typeInfo(Character).Struct.fields) |field| {
            @field(char, field.name) = ability();
        }
            
        char.hitpoints = 10 + modifier(char.constitution);
        
        return char;
    }
};
