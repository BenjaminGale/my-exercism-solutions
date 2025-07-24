use std::collections::HashSet;

pub fn is_pangram(sentence: &str) -> bool {
    let all_allphabet_chars: HashSet<char> = ('A'..='Z').collect();
    
    let sentence_chars: HashSet<char> =
        sentence
            .to_uppercase()
            .chars()
            .collect();
    
    all_allphabet_chars.is_subset(&sentence_chars)
}
