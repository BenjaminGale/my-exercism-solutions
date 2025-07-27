
pub const ComputationError = error {
    IllegalArgument,
};

pub fn steps(number: usize) anyerror!usize {
    if (number <= 0) return ComputationError.IllegalArgument;

    var curr: usize = number;
    var count: usize = 0;

    while (curr != 1) : (count += 1) {
        if (curr % 2 == 0) {
            curr = curr / 2;
        } else {
            curr = (curr * 3) + 1;
        }
    }

    return count;
}
