
pub fn reverse(input: &str) -> String {
    let chars: Vec<char> = input.chars().collect();
    let mut reversed = vec![' '; chars.len()];
    
    for (i, c) in chars.iter().enumerate() {
        let reverse_index = chars.len() - i - 1;
        reversed[reverse_index] = *c;
    }

    reversed.into_iter().collect()
}
