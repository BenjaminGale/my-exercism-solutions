use std::collections::HashSet;

pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    factors
        .iter()
        .filter(|&num| *num > 0)
        .map(|factor| (0..limit).filter(move |n| n % factor == 0))
        .flatten()
        .collect::<HashSet<_>>()
        .iter()
        .sum()
}
