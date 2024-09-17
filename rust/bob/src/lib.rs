pub fn reply(msg: &str) -> &str {

    if is_silent(msg) { return "Fine. Be that way!" }
    if is_shouting(msg) && is_question(msg) { return "Calm down, I know what I'm doing!" }
    if is_shouting(msg) { return "Whoa, chill out!" }
    if is_question(msg) { return "Sure." }
    
    "Whatever."
}

fn is_shouting(msg: &str) -> bool {
    msg.chars().any(is_alphabetic()) && msg.to_uppercase() == msg
}

fn is_question(msg: &str) -> bool {
    msg.trim().ends_with('?')
}

fn is_silent(msg: &str) -> bool {
    msg.is_empty() || msg.chars().all(|c| c.is_whitespace())
}
