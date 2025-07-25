const std = @import("std");

pub fn isArmstrongNumber(num: u128) bool {
    if (num == 0) return true;
    
    const digits = std.math.log10_int(num) + 1;

    var n = num;
    var sum: u128 = 0;

    while (n > 0) : (n /= 10) {
        sum += std.math.pow(u128, n % 10, digits);
    }
    
    return num == sum;
}
