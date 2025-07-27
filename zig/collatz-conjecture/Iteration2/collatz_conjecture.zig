
pub const ComputationError = error {
    IllegalArgument,
};

pub fn steps(number: usize) ComputationError!usize {
    if (number <= 0) return ComputationError.IllegalArgument;

    var curr: usize = number;
    var count: usize = 0;

    while (curr != 1) : (count += 1) {
        curr = switch (curr % 2) {
            0    => curr / 2,
            else => (curr * 3) + 1
        };
    }

    return count;
}
