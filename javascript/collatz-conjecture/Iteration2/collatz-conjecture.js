
export const steps = (number) => {
    if (number <= 0) {
        throw 'Only positive numbers are allowed'
    }

    var numberOfSteps = 0;

    while (number !== 1) {
        
        if (isEven(number)) {
            number = number / 2;
        }
        else {
            number = (3 * number) + 1;
        }

        numberOfSteps++;
    }

    return numberOfSteps;
};

function isEven(number) {
    return (number % 2) === 0;
}
