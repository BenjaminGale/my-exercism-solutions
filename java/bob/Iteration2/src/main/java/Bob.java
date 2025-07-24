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

    private boolean isSilent(String input) {
        return input.length() == 0;
    }
}
