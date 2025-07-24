
pub fn is_valid(code: &str) -> bool {
    if code.trim().len() <= 1 { return false }
    if !code.chars().all(|c| c.is_ascii_digit() || c.is_whitespace()) { return false }
    
    let checksum: u32 = code
        .chars()
        .filter(|c| c.is_ascii_digit())
        .rev()
        .map(|c| c.to_digit(10).unwrap())
        .zip([1, 2].iter().cycle())
        .map(|(a, &b)| sum_digits(a, b))
        .sum();

    checksum % 10 == 0
}

fn sum_digits(a: u32, b: u32) -> u32 {
    let mut product = a * b;
    if product > 9 { product -= 9 }
    product
}
