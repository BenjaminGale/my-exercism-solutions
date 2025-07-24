use std::collections::HashSet;

pub fn is_pangram(sentence: &str) -> bool {
    let all_allphabet_chars: HashSet<char> =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".chars().collect();
    
    let sentence_chars: HashSet<char> =
        sentence
            .to_uppercase()
            .chars()
            .collect();
    
    all_allphabet_chars.is_subset(&sentence_chars)
}
