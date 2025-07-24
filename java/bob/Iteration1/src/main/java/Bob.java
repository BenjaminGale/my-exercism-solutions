class Bob {

    String hey(String input) {
        var inputTrimmed = input.trim();
        
        if (inputTrimmed.length() == 0) return "Fine. Be that way!";
        if (isYelling(inputTrimmed) && isAsking(inputTrimmed)) return "Calm down, I know what I'm doing!";
        if (isYelling(inputTrimmed)) return "Whoa, chill out!";
        if (isAsking(inputTrimmed)) return "Sure.";
        
        return "Whatever.";
    }
    
    private boolean isYelling(String input) {
        var isYelling = false;
        
        for (char character: input.toCharArray()) {
            if (Character.isLetter(character)) {
                if (Character.isLowerCase(character)) {
                    return false;
                }
                isYelling = true;
            }
        }
        
        return isYelling;
    }
    
    private boolean isAsking(String input) {
        return input.endsWith("?");
    }
}
