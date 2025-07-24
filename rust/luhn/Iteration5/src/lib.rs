
pub fn is_valid(code: &str) -> bool {
    if code.trim().len() <= 1 { return false }
    if !code.chars().all(|c| c.is_ascii_digit() || c.is_whitespace()) { return false }
    
    code
        .chars()
        .filter(|c| c.is_ascii_digit())
        .rev()
        .map(|c| c.to_digit(10).unwrap())
        .zip([1, 2].into_iter().cycle())
        .map(|(digit, multiplier)| digit * multiplier)
        .map(|product| if product > 9 { product - 9 } else { product })
        .sum::<u32>() % 10 == 0
}
