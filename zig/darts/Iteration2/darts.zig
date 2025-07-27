const std = @import("std");
const math = std.math;

pub const Coordinate = struct {
    x_coord: f32,
    y_coord: f32,

    pub fn init(x_coord: f32, y_coord: f32) Coordinate {
        return Coordinate {
            .x_coord = x_coord,
            .y_coord = y_coord,
        };
    }

    fn distanceFromCentre(coord: Coordinate) f32 {
        return math.sqrt(math.pow(f32, coord.x_coord, 2) + math.pow(f32, coord.y_coord, 2));
    }
    
    pub fn score(self: Coordinate) usize {
        const dist = self.distanceFromCentre();

        if (dist <= 1)  return 10;
        if (dist <= 5)  return 5;
        if (dist <= 10) return 1;
    
        return 0;
    }
};
