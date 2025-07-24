
pub fn hamming_distance(s1: &str, s2: &str) -> Option<usize> {
    if s1.len() != s2.len() { return None };

    let mut count = 0;
    
    for (a, b) in s1.chars().zip(s2.chars()) {
        if a != b { count += 1 };
    }
    
    Some(count)
}
