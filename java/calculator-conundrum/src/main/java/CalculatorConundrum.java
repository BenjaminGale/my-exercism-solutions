import java.util.List;
import java.util.Arrays;

class CalculatorConundrum {

    private static final String ResultFormat = "%d %s %d = %d";
    private static final List<String> allowedOperations = Arrays.asList("+", "*", "/");
    
    public String calculate(int a, int b, String operation) {
        if (operation == null) throw new IllegalArgumentException("Operation cannot be null");
        if (operation == "") throw new IllegalArgumentException("Operation cannot be empty");
        
        try {
            switch (operation) {
                case "+":
                    return String.format(ResultFormat, a, operation, b, a + b);
                case "*":
                    return String.format(ResultFormat, a, operation, b, a * b);
                case "/":
                    return String.format(ResultFormat, a, operation, b, a / b);
            }
        } catch (ArithmeticException e) {
            throw new IllegalOperationException("Division by zero is not allowed", e);
        }

        throw new IllegalOperationException(String.format("Operation '%s' does not exist", operation));
    }
}
