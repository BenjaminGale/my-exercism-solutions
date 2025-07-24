use std::collections::HashSet;

pub fn is_pangram(sentence: &str) -> bool {
    let allAlphabetChars: HashSet<char> =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".chars().collect();
    
    let sentenceChars: HashSet<char> =
        sentence
            .to_uppercase()
            .chars()
            .collect();
    
    allAlphabetChars.is_subset(&sentenceChars)
}
