
pub fn is_armstrong_number(num: u32) -> bool {

    let mut val = num;
    let mut digits = Vec::new();

    while val > 0 {
        digits.push(val % 10);
        val /= 10;
    }

    let power = digits.len() as u32;
    let sum_of_powers = digits.iter().map(|digit| digit.pow(power)).sum();
    
    num == sum_of_powers
}
