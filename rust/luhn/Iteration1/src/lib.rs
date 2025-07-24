
pub fn is_valid(code: &str) -> bool {
    if code.trim().len() <= 1 { return false }
    if code.chars().any(|c| !(c.is_digit(10) || c.is_whitespace())) { return false }

    let trimmed: String = code
        .chars()
        .filter(|c| c.is_digit(10))
        .collect();
    
    let multiplier = if trimmed.len() % 2 == 0 {
        vec![2, 1]
    } else {
        vec![1, 2]
    };
    
    let checksum: u32 = trimmed
        .chars()
        .map(|c| c.to_digit(10).unwrap())
        .zip(multiplier.iter().cycle())
        .map(|(a, &b)| sum_digits(a, b))
        .sum();

    checksum % 10 == 0
}

fn sum_digits(a: u32, b: u32) -> u32 {
    let mut product = a * b;
    if product > 9 { product -= 9 }
    product
}
