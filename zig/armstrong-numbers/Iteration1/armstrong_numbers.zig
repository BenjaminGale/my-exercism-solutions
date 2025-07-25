const std = @import("std");

pub fn isArmstrongNumber(num: u128) bool {
    if (num == 0) return true;
    
    const digits = std.math.log10_int(num) + 1;

    var curr = num;
    var sum: u128 = 0;

    while (curr > 0) {
        const digit = curr % 10;
        sum += std.math.pow(u128, digit, digits);
        curr = curr / 10;
    }
    
    return num == sum;
}
