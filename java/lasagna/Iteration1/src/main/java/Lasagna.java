public class Lasagna {

    private static final int MINUTES_PER_LAYER = 2;
    
    public int expectedMinutesInOven() {
        return 40;
    }

    public int remainingMinutesInOven(int minutesInOven) {
        return expectedMinutesInOven() - minutesInOven; 
    }

    public int preparationTimeInMinutes(int numberOfLayers) {
        return MINUTES_PER_LAYER * numberOfLayers;
    }

    public int totalTimeInMinutes(int numberOfLayers, int minutesInOven) {
        return preparationTimeInMinutes(numberOfLayers) + minutesInOven;
    }
}
