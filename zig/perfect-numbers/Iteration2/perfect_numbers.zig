
pub const Classification = enum {
    deficient,
    perfect,
    abundant,
};

fn aliquotSum(n: u64) u64 {
    var sum: u64 = 0;
    
    for (1..n) |factor| {
        if (n % factor == 0) sum += factor;
    }

    return sum;
}

pub fn classify(n: u64) Classification {
    const sum = aliquotSum(n);

    if (sum < n) return Classification.deficient;
    if (sum > n) return Classification.abundant;
    return Classification.perfect;
}
