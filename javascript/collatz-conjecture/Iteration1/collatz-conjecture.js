
export const steps = (number) => {
    if (number <= 0) {
        throw 'Only positive numbers are allowed'
    }

    var numberOfSteps = 0;
    var result = number

    while (result !== 1) {
        
        if (isEven(result)) {
            result = result / 2;
        }
        else {
            result = (3 * result) + 1;
        }

        numberOfSteps++;
    }

    return numberOfSteps;
};

function isEven(number) {
    return (number % 2) === 0;
}
