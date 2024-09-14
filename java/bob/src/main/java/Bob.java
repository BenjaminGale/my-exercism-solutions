class Bob {

    String hey(String input) {
        input = input.trim();
        
        if (isSilent(input)) return "Fine. Be that way!";
        if (isYelling(input) && isAsking(input)) return "Calm down, I know what I'm doing!";
        if (isYelling(input)) return "Whoa, chill out!";
        if (isAsking(input)) return "Sure.";
        
        return "Whatever.";
    }
    
    private boolean isYelling(String input) {
        return input.chars().anyMatch(Character::isLetter) &&
            input.chars().filter(Character::isLetter).allMatch(Character::isUpperCase);
    }
    
    private boolean isAsking(String input) {
        return input.endsWith("?");
    }

    private boolean isSilent(String input) {
        return input.length() == 0;
    }
}
