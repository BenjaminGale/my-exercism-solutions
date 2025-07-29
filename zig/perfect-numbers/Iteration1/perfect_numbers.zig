
pub const Classification = enum {
    deficient,
    perfect,
    abundant,
};

fn aliquotSum(n: u64) u64 {
    var factor = n - 1;
    var sum: u64 = 0;

    while (factor > 0) {
        if (n % factor == 0) {
            sum += factor;
        }

        factor -= 1;
    }

    return sum;
}

pub fn classify(n: u64) Classification {
    const sum = aliquotSum(n);

    if      (sum == n) { return Classification.perfect; }
    else if (sum > n)  { return Classification.abundant; }
    else               { return Classification.deficient; }
}
