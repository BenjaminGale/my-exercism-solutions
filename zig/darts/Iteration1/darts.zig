const std = @import("std");
const math = std.math;

const centre:       f32 = 0;
const innerRadius:  f32 = 1;
const middleRadius: f32 = 5;
const outerRadius:  f32 = 10;

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

        if (dist >= centre and dist <= innerRadius) return 10;
        if (dist >= innerRadius and dist <= middleRadius) return 5;
        if (dist >= middleRadius and dist <= outerRadius) return 1;
    
        return 0;
    }
};
