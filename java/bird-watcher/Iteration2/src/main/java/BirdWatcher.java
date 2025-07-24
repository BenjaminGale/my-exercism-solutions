import java.util.*; 
import java.util.stream.*;

class BirdWatcher {
    private final int[] birdsPerDay;

    public BirdWatcher(int[] birdsPerDay) {
        this.birdsPerDay = birdsPerDay.clone();
    }

    public int[] getLastWeek() {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int getToday() {
        return birdsPerDay[birdsPerDay.length - 1];
    }

    public void incrementTodaysCount() {
        birdsPerDay[birdsPerDay.length - 1]++;
    }

    public boolean hasDayWithoutBirds() {
        return Arrays
            .stream(birdsPerDay)
            .anyMatch(c -> c == 0);
    }

    public int getCountForFirstDays(int numberOfDays) {
        return Arrays
            .stream(birdsPerDay)
            .limit(numberOfDays)
            .sum();
    }

    public int getBusyDays() {
        return (int)Arrays
            .stream(birdsPerDay)
            .filter(c -> c >= 5)
            .count();
    }
}
