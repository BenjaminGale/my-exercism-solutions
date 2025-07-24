
pub const ColorBand = enum {
    black,
    brown,
    red,
    orange,
    yellow,
    green,
    blue,
    violet,
    grey,
    white
};

pub fn colorCode(colors: [2]ColorBand) usize {
    return (@intFromEnum(colors[0]) * @as(usize, 10)) + @intFromEnum(colors[1]);
}
