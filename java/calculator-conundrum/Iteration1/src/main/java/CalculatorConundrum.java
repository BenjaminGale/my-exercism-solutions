import java.util.List;
import java.util.Arrays;

class CalculatorConundrum {

    private final List<String> allowedOperations = Arrays.asList("+", "*", "/");
    
    public String calculate(int operand1, int operand2, String operation) {
        if (operation == null)
            throw new IllegalArgumentException("Operation cannot be null");
        
        if (operation == "")
            throw new IllegalArgumentException("Operation cannot be empty");
        
        if (!allowedOperations.contains(operation))
            throw new IllegalOperationException(String.format("Operation '%s' does not exist", operation));
        
        try {
            var result = 0;
            
            switch (operation) {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;
            } 

            return String.format("%d %s %d = %d", operand1, operation, operand2, result);
        } catch (ArithmeticException e) {
            throw new IllegalOperationException("Division by zero is not allowed", e);
        }
    }
}
