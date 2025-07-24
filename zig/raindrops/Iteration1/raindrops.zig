const std = @import("std");

const Raindrop = struct {
    divisor: u3,
    sound: []const u8
};

const Raindrops = [3]Raindrop {
    .{ .divisor = 3, .sound = "Pling" },
    .{ .divisor = 5, .sound = "Plang" },
    .{ .divisor = 7, .sound = "Plong" },
};

pub fn convert(buffer: []u8, n: u32) []const u8 {
    var stream = std.io.fixedBufferStream(buffer);

    for (Raindrops) |raindrop| {
        if (n % raindrop.divisor == 0) {
            _ = stream.writer().write(raindrop.sound) catch unreachable;
        }
    }

    if (stream.pos == 0) {
        _ = stream.writer().print("{}", .{n}) catch unreachable;
    }

    return stream.getWritten();
}
