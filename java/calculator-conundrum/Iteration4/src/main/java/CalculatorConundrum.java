import java.util.List;
import java.util.Arrays;

class CalculatorConundrum {
    
    public String calculate(int a, int b, String operation) {
        if (operation == null) throw new IllegalArgumentException("Operation cannot be null");
        if (operation == "") throw new IllegalArgumentException("Operation cannot be empty");
        
        try {
            switch (operation) {
                case "+":
                    return format(a, b, operation, a + b);
                case "*":
                    return format(a, b, operation, a * b);
                case "/":
                    return format(a, b, operation, a / b);
            }
        } catch (ArithmeticException e) {
            throw new IllegalOperationException("Division by zero is not allowed", e);
        }

        throw new IllegalOperationException(String.format("Operation '%s' does not exist", operation));
    }

    private String format(int a, int b, String operation, int result) {
        return String.format("%d %s %d = %d", a, operation, b, result);
    }
}
